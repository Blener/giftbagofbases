using GiftBagOfBases.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace GiftBagOfBases.Contexts
{
    public class GiftContext<T> : DbContext where T : DbContext
    {
        public GiftContext(DbContextOptions<T> options) : base(options)
        {
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker
                                    .Entries()
                                    .Where(entry => entry.Entity.GetType().IsAssignableFrom(typeof(SoftDeleteEntity<>))
                                                    && entry.State == EntityState.Deleted))
            {
                var castedEntity = entry.Entity as SoftDeleteEntity<Entity>;
                entry.State = EntityState.Modified;
                entry.Property(nameof(castedEntity.SoftDeleted)).CurrentValue = true;
            }

            foreach (var entry in ChangeTracker
                                    .Entries()
                                    .Where(entry => entry.Entity.GetType().IsAssignableFrom(typeof(Entity))
                                                    && ((Entity)entry.Entity).Id == Guid.Empty))
            {
                var castedEntity = entry.Entity as Entity;
                entry.Property(nameof(castedEntity.Id)).CurrentValue = Guid.NewGuid();
            }

            return base.SaveChanges();
        }
    }
}