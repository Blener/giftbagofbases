using GiftBagOfBases.ViewModel;
using System;
using System.Threading.Tasks;

namespace GiftBagOfBases.Interfaces.Application
{
    public interface IAppCommandOnlyService<TViewModel> : IDisposable where TViewModel : GiftViewModel
    {
        Task Add(TViewModel viewModel);

        Task Update(TViewModel viewModel);

        Task Remove(Guid aggregateId);

        Task Restore(Guid aggregateId);
    }
}