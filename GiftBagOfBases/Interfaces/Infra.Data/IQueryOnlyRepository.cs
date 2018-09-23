using GiftBagOfBases.Models;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GiftBagOfBases.Interfaces.Infra.Data
{
    public interface IQueryOnlyRepository<TEntity> : IDisposable where TEntity : Entity
    {
        Task<TEntity> Get(Guid aggregateId);

        Task<TEntity> Get(Expression<Func<TEntity, bool>> wherePredicate);

        IQueryable<TEntity> GetAll();

        IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> wherePredicate);

        Task<bool> ExistAggregateId(Guid aggregateId);
    }
}