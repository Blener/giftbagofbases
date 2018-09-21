using GiftBagOfBases.Interfaces.Infra.Data;
using GiftBagOfBases.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace GiftBagOfBases.Repositories
{
    public class FullRepository<TEntity> : IFullRepository<TEntity> where TEntity : Entity
    {
        protected readonly IQueryOnlyRepository<TEntity> queryOnlyRepository;
        protected readonly ICommandOnlyRepository<TEntity> commandOnlyRepository;

        protected FullRepository(IQueryOnlyRepository<TEntity> queryOnlyRepository, ICommandOnlyRepository<TEntity> commandOnlyRepository)
        {
            this.queryOnlyRepository = queryOnlyRepository;
            this.commandOnlyRepository = commandOnlyRepository;
        }

        public void Add(TEntity obj)
        {
            commandOnlyRepository.Add(obj);
        }

        public void AddRelation<TRelation>(TRelation relation) where TRelation : Entity
        {
            commandOnlyRepository.AddRelation(relation);
        }

        public void Dispose()
        {
            queryOnlyRepository.Dispose();
            commandOnlyRepository.Dispose();
        }

        public Task<bool> ExistAggregateId(Guid aggregateId)
        {
            return queryOnlyRepository.ExistAggregateId(aggregateId);
        }

        public IQueryable<TEntity> GetAll()
        {
            return queryOnlyRepository.GetAll();
        }

        public Task<TEntity> GetByAggregateId(Guid aggregateId)
        {
            return queryOnlyRepository.GetByAggregateId(aggregateId);
        }

        public Task Remove(Guid id)
        {
            return commandOnlyRepository.Remove(id);
        }

        public void Update(TEntity obj)
        {
            commandOnlyRepository.Update(obj);
        }
    }
}