using AutoMapper;
using AutoMapper.QueryableExtensions;
using GiftBagOfBases.Interfaces.Application;
using GiftBagOfBases.Interfaces.Infra.Data;
using GiftBagOfBases.Models;
using GiftBagOfBases.ViewModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GiftBagOfBases.Services.Application
{
    public abstract class AppQueryOnlyService<TEntity, TViewModel> : IAppQueryOnlyService<TViewModel> where TEntity : Entity where TViewModel : GiftViewModel
    {
        protected readonly IQueryOnlyRepository<TEntity> queryRepository;
        protected readonly IMapper mapper;

        protected AppQueryOnlyService(IQueryOnlyRepository<TEntity> queryRepository, IMapper mapper)
        {
            this.queryRepository = queryRepository;
            this.mapper = mapper;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public IEnumerable<TViewModel> GetAll()
        {
            return queryRepository.GetAll().ProjectTo<TViewModel>();
        }

        public async Task<TViewModel> GetByAggregateId(Guid aggregateId)
        {
            return MapGetForReturn(await queryRepository.GetByAggregateId(aggregateId));
        }

        protected TViewModel MapGetForReturn(TEntity entity) => mapper.Map<TViewModel>(entity);
    }
}