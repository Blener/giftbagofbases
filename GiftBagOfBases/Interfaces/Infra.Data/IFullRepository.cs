using GiftBagOfBases.Models;

namespace GiftBagOfBases.Interfaces.Infra.Data
{
    public interface IFullRepository<TEntity> : IQueryOnlyRepository<TEntity>, ICommandOnlyRepository<TEntity>
        where TEntity : Entity
    {
    }
}