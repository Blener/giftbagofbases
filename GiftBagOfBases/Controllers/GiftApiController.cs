using GiftBagOfBases.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading;

namespace GiftBagOfBases.Controllers
{
    public class GiftApiController : ControllerBase
    {
        private readonly DomainNotificationHandler _notifications;

        protected GiftApiController(INotificationHandler<DomainNotification> notifications)
        {
            _notifications = (DomainNotificationHandler)notifications;
        }

        protected bool IsValidOperation()
        {
            return !_notifications.HasErrors();
        }

        protected new IActionResult Response(object result = null)
        {
            if (IsValidOperation())
            {
                return Ok(new
                {
                    success = true,
                    messages = _notifications.GetConfirmations().Select(x => x.Value),
                    data = result
                });
            }

            return BadRequest(new
            {
                success = false,
                messages = _notifications.GetConfirmations().Select(x => x.Value),
                errors = _notifications.GetErrors().Select(n => n.Value)
            });
        }

        protected void NotifyModelStateErrors()
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            foreach (var error in errors)
            {
                var errorMsg = error.Exception == null ? error.ErrorMessage : error.Exception.Message;
                NotifyError(string.Empty, errorMsg);
            }
        }

        protected void NotifyError(string code, string message)
        {
            _notifications.Handle(new DomainNotification(code, message, false), new CancellationToken());
        }
    }
}