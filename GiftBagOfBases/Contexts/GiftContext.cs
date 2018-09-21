using GiftBagOfBases.Models;
using Microsoft.EntityFrameworkCore;
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
                entry.State = EntityState.Modified;
                entry.Property("SoftDeleted").CurrentValue = true;
            }

            return base.SaveChanges();
        }
    }
}