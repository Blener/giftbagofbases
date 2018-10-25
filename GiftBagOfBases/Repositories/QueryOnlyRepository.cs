using GiftBagOfBases.Interfaces.Infra.Data;
using GiftBagOfBases.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GiftBagOfBases.Repositories
{
    public abstract class QueryOnlyRepository<TEntity, TContext> : IQueryOnlyRepository<TEntity> where TEntity : Entity where TContext : DbContext
    {
        protected readonly TContext Db;
        protected DbSet<TEntity> DbSet => Db.Set<TEntity>();

        protected QueryOnlyRepository(TContext db)
        {
            Db = db;
        }

        public void Dispose() => GC.SuppressFinalize(this);

        public IQueryable<TEntity> GetAll()
        {
            return DbSet;
        }

        public IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> wherePredicate)
        {
            return GetAll().Where(wherePredicate);
        }

        public Task<TEntity> Get(Expression<Func<TEntity, bool>> wherePredicate)
        {
            return DbSet.FirstOrDefaultAsync(wherePredicate);
        }

        public Task<TEntity> Get(Guid aggregateId)
        {
            return Get(x => x.Id == aggregateId);
        }

        public Task<bool> ExistAggregateId(Guid aggregateId)
        {
            return GetAll()
                .AnyAsync(x => x.Id == aggregateId);
        }
    }
}