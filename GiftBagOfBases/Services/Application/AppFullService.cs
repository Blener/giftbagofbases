using AutoMapper;
using GiftBagOfBases.Interfaces.Application;
using GiftBagOfBases.Interfaces.Domain;
using GiftBagOfBases.Models;
using GiftBagOfBases.ViewModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GiftBagOfBases.Services.Application
{
    public abstract class AppFullService<TViewModel, TEntity> : AppCommandOnlyService<TViewModel>, IAppQueryOnlyService<TViewModel>
        where TViewModel : GiftViewModel
        where TEntity : Entity
    {
        protected readonly AppQueryOnlyService<TEntity, TViewModel> appQueryOnlyService;

        protected AppFullService(IMediatorHandler bus, IMapper mapper, AppQueryOnlyService<TEntity, TViewModel> appQueryOnlyService) : base(bus, mapper)
        {
            this.appQueryOnlyService = appQueryOnlyService;
        }

        public IEnumerable<TViewModel> GetAll()
        {
            return appQueryOnlyService.GetAll();
        }

        public Task<TViewModel> GetByAggregateId(Guid aggregateId)
        {
            return appQueryOnlyService.GetByAggregateId(aggregateId);
        }
    }
}