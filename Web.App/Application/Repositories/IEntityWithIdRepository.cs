using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Web.App.Application.Repositories.Base;
using Web.App.Database;

namespace Web.App.Application.Repositories
{
    public interface IEntityWithIdRepository<TEntity> : IRepository
        where TEntity : EntityWithIdBase
    {
        /// <summary>
        /// Get entity by id
        /// </summary>
        /// <param name="id">Entity id</param>
        /// <param name="useTracking">Whether we are using EF funcitonality of tracking changes</param>
        /// <returns></returns>
        TEntity GetById(int id, bool useTracking = false);

        /// <summary>
        /// Get entity by id. Doesnt use AsNo Tracking.
        /// Comes with includes
        /// </summary>
        /// <param name="id">Entity id</param>
        /// <param name="useTracking">Wether we are using EF funcitonnality of tracking changes</param>
        /// <returns></returns>
        TEntity GetByIdWithDetails(int id,
            List<Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>>? includes = null);
    }
}
