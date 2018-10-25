using AutoMapper;
using GiftBagOfBases.Commands;
using GiftBagOfBases.Interfaces.Application;
using GiftBagOfBases.Interfaces.Domain;
using GiftBagOfBases.Interfaces.Infra.Data;
using GiftBagOfBases.Models;
using GiftBagOfBases.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GiftBagOfBases.Services.Application
{
    public abstract class AppFullService<TViewModel, TEntity> : IAppCommandOnlyService<TViewModel>, IAppQueryOnlyService<TViewModel>
        where TViewModel : GiftViewModel
        where TEntity : Entity
    {
        protected readonly IQueryOnlyRepository<TEntity> queryRepository;
        protected readonly IMediatorHandler bus;
        protected readonly IMapper mapper;

        protected AppFullService(IQueryOnlyRepository<TEntity> queryRepository, IMediatorHandler bus, IMapper mapper)
        {
            this.queryRepository = queryRepository;
            this.bus = bus;
            this.mapper = mapper;
        }

        public IEnumerable<TViewModel> GetAll()
        {
            return MapGetForReturn(queryRepository.GetAll());
        }

        public async Task<TViewModel> GetByAggregateId(Guid aggregateId)
        {
            return MapGetForReturn(await queryRepository.Get(aggregateId));
        }

        protected TViewModel MapGetForReturn(TEntity entity) => mapper.Map<TViewModel>(entity);

        protected IEnumerable<TViewModel> MapGetForReturn(IQueryable<TEntity> entityQuery) => mapper.Map<IEnumerable<TViewModel>>(entityQuery);

        public abstract Task Add(TViewModel viewModel);

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public abstract Task Remove(Guid aggregateId);

        public abstract Task Restore(Guid aggregateId);

        public abstract Task Update(TViewModel viewModel);

        protected Task MapAndSendCommand<TCommand>(TViewModel viewModel) where TCommand : Command => bus.SendCommand(mapper.Map<TCommand>(viewModel));

        protected Task MapAndSendCommand<TCommand>(Guid aggregateId) where TCommand : Command => bus.SendCommand(mapper.Map<TCommand>(aggregateId));

        protected Task MapAndSendCommand<TCommand, TMethodViewModel>(TMethodViewModel viewModel)
            where TCommand : Command where TMethodViewModel : GiftViewModel
            => bus.SendCommand(mapper.Map<TCommand>(viewModel));
    }
}