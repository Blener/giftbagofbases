using GiftBagOfBases.Commands;
using GiftBagOfBases.Events;
using GiftBagOfBases.Events.Interfaces;
using GiftBagOfBases.Interfaces.Domain;
using GiftBagOfBases.Notifications;
using MediatR;
using System.Threading.Tasks;

namespace GiftBagOfBases.Bus
{
    public sealed class InMemoryBus : IMediatorHandler
    {
        private readonly IMediator _mediator;
        private readonly IEventStore _eventStore;

        public InMemoryBus(IEventStore eventStore, IMediator mediator)
        {
            _eventStore = eventStore;
            _mediator = mediator;
        }

        public Task SendCommand<T>(T command) where T : Command
        {
            if (!command.IsValid())
            {
                command.NotifyValidationErrors(this);
                return null;
            }

            return Publish(command);
        }

        public Task RaiseEvent<T>(T @event) where T : Event
        {
            if (!@event.MessageType.Equals(nameof(DomainNotification)))
                _eventStore?.Save(@event);

            return Publish(@event);
        }

        private Task Publish<T>(T message) where T : Message
        {
            return _mediator.Publish(message);
        }
    }
}