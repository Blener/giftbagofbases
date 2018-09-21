using GiftBagOfBases.Events;
using System;
using System.Collections.Generic;

namespace GiftBagOfBases.Interfaces.Infra.Data
{
    public interface IEventStoreRepository : IDisposable
    {
        void Store(StoredEvent theEvent);

        IList<StoredEvent> All(Guid aggregateId);
    }
}