using Microsoft.EntityFrameworkCore.Query;
using Web.App.Application.Repositories;
using Web.App.Database;

namespace Web.App.Application.Common
{
    public class EntityWithIdService<TEntity> : IEntityWithIdService<TEntity>
        where TEntity : EntityWithIdBase
    {
        protected readonly IEntityWithIdRepository<TEntity> _entityRepository;

        public EntityWithIdService(IEntityWithIdRepository<TEntity> entityRepository)
        {
            _entityRepository = entityRepository;
        }

        /// <summary>
        /// Get entity by id
        /// </summary>
        /// <param name="id">Entity id</param>
        /// <returns></returns>
        public TEntity GetById(int id)
        {
            return _entityRepository.GetById(id);
        }


        /// <summary>
        /// Get entity by id. Doesnt use AsNo Tracking.
        /// Comes with includes
        /// </summary>
        /// <param name="id">Entity id</param>
        /// <param name="useTracking">Wether we are using EF funcitonnality of tracking changes</param>
        /// <returns></returns>
        public TEntity GetByIdWithDetails(int id,
            List<Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>>? includes = null)
        {
            return _entityRepository.GetByIdWithDetails(id, includes);
        }

        /// <summary>
        /// Attach graph and create new objects where needed.
        /// Attach has the advantage of including children compared to a _context.Add()
        /// https://gavilan.blog/2018/12/09/entity-framework-core-difference-between-add-entry-and-attach-methods/
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public Task<TEntity> CreateEntity(TEntity entity)
        {
            return _entityRepository.CreateEntity(entity);
        }
    }
}
