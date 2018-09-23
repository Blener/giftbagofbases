using GiftBagOfBases.Interfaces.Application;
using GiftBagOfBases.Notifications;
using GiftBagOfBases.ViewModel;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace GiftBagOfBases.Controllers
{
    public abstract class GiftFullController<TViewModel> : GiftApiController where TViewModel : GiftViewModel
    {
        protected readonly IAppFullService<TViewModel> appFullService;

        protected GiftFullController(
            INotificationHandler<DomainNotification> notifications,
            IAppFullService<TViewModel> appFullService) : base(notifications)
        {
            this.appFullService = appFullService;
        }

        /// <summary>
        /// Get the requested list of entities
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public virtual IActionResult Get()
        {
            return Response(appFullService.GetAll());
        }

        [HttpGet("{id:required}")]
        public virtual async Task<IActionResult> Get(Guid id)
        {
            return Response(await appFullService.GetByAggregateId(id));
        }

        [HttpPost]
        public IActionResult Add([FromBody] TViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(viewModel);
            }

            appFullService.Add(viewModel);
            return Response(viewModel);
        }

        [HttpPut]
        public IActionResult Update([FromBody]TViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(viewModel);
            }

            appFullService.Update(viewModel);
            return Response(viewModel);
        }
    }
}