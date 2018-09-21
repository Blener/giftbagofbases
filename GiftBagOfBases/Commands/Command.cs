using FluentValidation.Results;
using GiftBagOfBases.Events;
using GiftBagOfBases.Interfaces.Domain;
using GiftBagOfBases.Notifications;
using System;

namespace GiftBagOfBases.Commands
{
    public abstract class Command : Message
    {
        public DateTime Timestamp { get; private set; }
        public ValidationResult ValidationResult { get; set; }

        protected Command()
        {
            Timestamp = DateTime.Now;
        }

        public abstract bool IsValid();

        public void NotifyValidationErrors(IMediatorHandler bus)
        {
            foreach (var error in ValidationResult.Errors)
            {
                bus.RaiseEvent(new DomainNotification(MessageType, error.ErrorMessage, false));
            }
        }

        public DomainNotification RaiseError(string errorMsg)
        {
            return new DomainNotification(MessageType, errorMsg, false);
        }

        public DomainNotification RaiseSuccess(string successMsg)
        {
            return new DomainNotification(MessageType, successMsg, true);
        }
    }
}