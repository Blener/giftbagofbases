using GiftBagOfBases.ViewModel;

namespace GiftBagOfBases.Interfaces.Application
{
    public interface IAppFullService<TViewModel> : IAppQueryOnlyService<TViewModel>, IAppCommandOnlyService<TViewModel> where TViewModel : GiftViewModel
    {
    }
}