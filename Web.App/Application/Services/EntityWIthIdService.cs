using Web.App.Application.Repositories;
using Web.App.Database;

namespace Web.App.Application.Common
{
    public class EntityWIthIdService<TEntity> : IEntityWIthIdService<TEntity>
        where TEntity : EntityWithIdBase
    {
        protected readonly IEntityWithIdRepository<TEntity> _entityRepository;

        public EntityWIthIdService(IEntityWithIdRepository<TEntity> entityRepository)
        {
            _entityRepository = entityRepository;
        }
        /// <summary>
        /// Get entity by id
        /// </summary>
        /// <param name="id">Entity id</param>
        /// <returns></returns>
        public virtual TEntity GetById(int id)
        {
            return _entityRepository.GetById(id);
        }
    }
}
