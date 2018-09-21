using GiftBagOfBases.ViewModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GiftBagOfBases.Interfaces.Application
{
    public interface IAppQueryOnlyService<TViewModel> : IDisposable where TViewModel : GiftViewModel
    {
        Task<TViewModel> GetByAggregateId(Guid aggregateId);

        IEnumerable<TViewModel> GetAll();
    }
}