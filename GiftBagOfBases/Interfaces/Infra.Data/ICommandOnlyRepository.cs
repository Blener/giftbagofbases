using GiftBagOfBases.Models;
using System;
using System.Threading.Tasks;

namespace GiftBagOfBases.Interfaces.Infra.Data
{
    public interface ICommandOnlyRepository<TEntity> : IDisposable where TEntity : Entity
    {
        void Add(TEntity obj);

        void Update(TEntity obj);

        Task Remove(Guid id);

        void AddRelation<TRelation>(TRelation relation) where TRelation : Entity;
    }
}