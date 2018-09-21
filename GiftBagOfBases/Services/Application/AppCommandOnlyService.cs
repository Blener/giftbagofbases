using AutoMapper;
using GiftBagOfBases.Commands;
using GiftBagOfBases.Interfaces.Application;
using GiftBagOfBases.Interfaces.Domain;
using GiftBagOfBases.ViewModel;
using System;

namespace GiftBagOfBases.Services.Application
{
    public abstract class AppCommandOnlyService<TViewModel> : IAppCommandOnlyService<TViewModel> where TViewModel : GiftViewModel
    {
        private readonly IMediatorHandler bus;
        private readonly IMapper mapper;

        public AppCommandOnlyService(IMediatorHandler bus, IMapper mapper)
        {
            this.bus = bus;
            this.mapper = mapper;
        }

        public abstract void Add(TViewModel viewModel);

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public abstract void Remove(Guid aggregateId);

        public abstract void Restore(Guid aggregateId);

        public abstract void Update(TViewModel viewModel);

        protected void MapAndSendCommand<TCommand>(TViewModel viewModel) where TCommand : Command => bus.SendCommand(mapper.Map<TCommand>(viewModel));

        protected void MapAndSendCommand<TCommand>(Guid aggregateId) where TCommand : Command => bus.SendCommand(mapper.Map<TCommand>(aggregateId));

        protected void MapAndSendCommand<TCommand, TMethodViewModel>(TMethodViewModel viewModel)
            where TCommand : Command where TMethodViewModel : GiftViewModel
            => bus.SendCommand(mapper.Map<TCommand>(viewModel));
    }
}