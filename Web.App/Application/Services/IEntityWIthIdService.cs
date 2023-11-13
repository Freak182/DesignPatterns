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
        public TEntity GetByIdWithDetails(int id, List<Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>>? includes = null);
    }
}
