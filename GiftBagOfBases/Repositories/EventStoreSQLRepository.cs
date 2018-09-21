using GiftBagOfBases.Contexts;
using GiftBagOfBases.Events;
using GiftBagOfBases.Interfaces.Infra.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GiftBagOfBases.Repositories
{
    public class EventStoreSQLRepository : IEventStoreRepository
    {
        private readonly EventStoreSQLContext context;

        public EventStoreSQLRepository(EventStoreSQLContext context)
        {
            this.context = context;
        }

        public IList<StoredEvent> All(Guid aggregateId)
        {
            return context.StoredEvent.Where(x => x.AggregateId == aggregateId).ToList();
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public void Store(StoredEvent theEvent)
        {
            context.StoredEvent.Add(theEvent);
            context.SaveChanges();
        }
    }
}