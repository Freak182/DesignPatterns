using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Web.App.Database;

namespace Web.App.Application.Repositories
{
    /// <summary>
    /// Base <see cref="IRepository "/> class that provides the <see cref="DbSet{TEntity}"/>. 
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class EntityWithIdRepository<TEntity> : IEntityWithIdRepository<TEntity>
        where TEntity : EntityWithIdBase
    {
        protected readonly IDbContext _dbContext;

        public EntityWithIdRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Get entity by id. Doesnt use AsNo Tracking
        /// </summary>
        /// <param name="id">Entity id</param>
        /// <param name="useTracking">Wether we are using EF funcitonnality of tracking changes</param>
        /// <returns></returns>
        public virtual TEntity GetById(int id, bool useTracking = false)
        {
            var query = DbSetWithIncludes();
            query = query.AsNoTracking();

            return query.FirstOrDefault(entity => entity.Id == id);
        }

        /// <summary>
        /// Get entity by id. Doesnt use AsNo Tracking
        /// </summary>
        /// <param name="id">Entity id</param>
        /// <param name="useTracking">Wether we are using EF funcitonnality of tracking changes</param>
        /// <returns></returns>
        public virtual TEntity GetByIdWithDetails(int id,
            List<Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>>? includes = null)
        {
            var query = DbSetWithIncludes();

            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = include(query);
                }
            }

            query = query.AsNoTracking();

            return query.FirstOrDefault(entity => entity.Id == id);
        }



        /// <summary>
        /// When we want to retrive with only the minimum attached entities in th graph
        /// </summary>
        /// <returns></returns>
        protected virtual IQueryable<TEntity> DbSetWithIncludes()
        {
            return _dbContext.Set<TEntity>().AsQueryable();
        }

        /// <summary>
        /// Full detail includes
        /// </summary>
        /// <returns></returns>
        protected virtual IQueryable<TEntity> DbSetWithDetailIncludes()
        {
            return _dbContext.Set<TEntity>().AsQueryable();
        }
    }
}
