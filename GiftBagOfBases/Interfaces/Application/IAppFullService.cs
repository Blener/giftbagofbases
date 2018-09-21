using GiftBagOfBases.Interfaces.Infra.Data;
using GiftBagOfBases.Models;
using GiftBagOfBases.ViewModel;

namespace GiftBagOfBases.Interfaces.Application
{
    public interface IAppFullService<TViewModel, TEntity> : IQueryOnlyRepository<TEntity>, IAppCommandOnlyService<TViewModel>
        where TViewModel : GiftViewModel
        where TEntity : Entity
    {
    }
}