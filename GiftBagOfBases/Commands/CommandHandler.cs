using GiftBagOfBases.Interfaces.Domain;
using GiftBagOfBases.Notifications;
using MediatR;
using System.Threading.Tasks;

namespace GiftBagOfBases.Commands
{
    public class CommandHandler
    {
        private readonly IUnitOfWork _uow;
        protected readonly IMediatorHandler _bus;
        private readonly DomainNotificationHandler _notifications;

        public CommandHandler(IUnitOfWork uow, IMediatorHandler bus, INotificationHandler<DomainNotification> notifications)
        {
            _uow = uow;
            _notifications = (DomainNotificationHandler)notifications;
            _bus = bus;
        }

        protected async Task RaiseDomainError(Command command, string errorMsg) => await _bus.RaiseEvent(command.RaiseError(errorMsg));

        protected async Task RaiseDomainSuccess(Command command, string successMsg) => await _bus.RaiseEvent(command.RaiseSuccess(successMsg));

        public bool Commit()
        {
            if (_notifications.HasErrors()) return false;
            var commandResponse = _uow.Commit();
            if (commandResponse.Success) return true;

            _bus.RaiseEvent(new DomainNotification("Commit", "An error has been raised while saving your data.", false));
            return false;
        }
    }
}