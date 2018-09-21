using GiftBagOfBases.ViewModel;
using System;

namespace GiftBagOfBases.Interfaces.Application
{
    public interface IAppCommandOnlyService<TViewModel> : IDisposable where TViewModel : GiftViewModel
    {
        void Add(TViewModel viewModel);

        void Update(TViewModel viewModel);

        void Remove(Guid aggregateId);

        void Restore(Guid aggregateId);
    }
}