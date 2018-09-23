using GiftBagOfBases.Events.Interfaces;
using GiftBagOfBases.Interfaces.Infra.Data;
using Newtonsoft.Json;

namespace GiftBagOfBases.Events
{
    public class SqlEventStore : IEventStore
    {
        private readonly IEventStoreRepository eventStoreRepository;

        public SqlEventStore(IEventStoreRepository eventStoreRepository)
        {
            this.eventStoreRepository = eventStoreRepository;
        }

        public void Save<T>(T theEvent) where T : Event
        {
            var serializedData = JsonConvert.SerializeObject(theEvent);

            var storedEvent = new StoredEvent(theEvent, serializedData, "");

            eventStoreRepository.Store(storedEvent);
        }
    }
}