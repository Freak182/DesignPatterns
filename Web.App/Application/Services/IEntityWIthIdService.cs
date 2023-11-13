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
    }
}
