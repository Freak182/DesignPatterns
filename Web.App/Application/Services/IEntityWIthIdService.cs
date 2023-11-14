using Microsoft.EntityFrameworkCore.Query;
using Web.App.Database;
using Web.App.Database.Mapping.Common;

namespace Web.App.Application.Common
{
    public interface IEntityWithIdService<TEntity> where TEntity : EntityWithIdBase
    {
        /// <summary>
        /// Get entity by id
        /// </summary>
        /// <param name="id">Entity id</param>
        /// <returns></returns>
        TEntity GetById(int id);

        /// <summary>
        /// Get entity by id. Doesnt use AsNo Tracking.
        /// Comes with includes
        /// </summary>
        /// <param name="id">Entity id</param>
        /// <param name="useTracking">Wether we are using EF funcitonnality of tracking changes</param>
        /// <returns></returns>
        TEntity GetByIdWithDetails(int id, List<Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>>? includes = null);

        /// <summary>
        /// Attach graph and create new objects where needed.
        /// Attach has the advantage of including children compared to a _context.Add()
        /// https://gavilan.blog/2018/12/09/entity-framework-core-difference-between-add-entry-and-attach-methods/
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<TEntity> CreateEntity(TEntity entity);
    }
}
