using GiftBagOfBases.Events;
using GiftBagOfBases.Mappings;
using Microsoft.EntityFrameworkCore;

namespace GiftBagOfBases.Contexts
{
    public class EventStoreSQLContext : GiftContext<EventStoreSQLContext>
    {
        public EventStoreSQLContext(DbContextOptions<EventStoreSQLContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new StoredEventMap());

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<StoredEvent> StoredEvent { get; set; }
    }
}