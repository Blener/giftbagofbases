using GiftBagOfBases.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace GiftBagOfBases.Interfaces.Infra.Data
{
    public interface IQueryOnlyRepository<TEntity> : IDisposable where TEntity : Entity
    {
        Task<TEntity> GetByAggregateId(Guid aggregateId);

        IQueryable<TEntity> GetAll();

        Task<bool> ExistAggregateId(Guid aggregateId);
    }
}