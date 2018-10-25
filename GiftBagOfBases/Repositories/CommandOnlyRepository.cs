using GiftBagOfBases.Interfaces.Infra.Data;
using GiftBagOfBases.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace GiftBagOfBases.Repositories
{
    public abstract class CommandOnlyRepository<TEntity, TContext> : ICommandOnlyRepository<TEntity> where TEntity : Entity where TContext : DbContext
    {
        protected readonly TContext Db;
        protected DbSet<TEntity> DbSet => Db.Set<TEntity>();

        protected CommandOnlyRepository(TContext db)
        {
            Db = db;
        }

        public void Add(TEntity obj)
        {
            DbSet.Add(obj);
        }

        public void AddRelation<TRelation>(TRelation relation) where TRelation : Entity
        {
            Db.Set<TRelation>().Add(relation);
        }

        public void Dispose() => GC.SuppressFinalize(this);

        public async Task Remove(Guid id)
        {
            DbSet.Remove(await DbSet.FirstOrDefaultAsync(x => x.Id == id));
        }

        public void Update(TEntity obj)
        {
            DbSet.Update(obj);
        }
    }
}