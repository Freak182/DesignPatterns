using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
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

        /// <summary>
        /// Attach graph and create new objects where needed.
        /// Attach has the advantage of including children compared to a _context.Add()
        /// https://gavilan.blog/2018/12/09/entity-framework-core-difference-between-add-entry-and-attach-methods/
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<TEntity> CreateEntity(TEntity entity)
        {
            AttachGraph(entity);

            await SaveChangesAsync();
            DetachGraph(entity);
            return entity;
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        ///  Go through object graph and set added only if there is no id set, TrackGraph only goes through actually non tracking objects
        /// </summary>
        /// <param name="entity"></param>
        protected virtual void AttachGraph(TEntity entity)
        {
            _dbContext.ChangeTracker.TrackGraph(entity, node => SetEntityState(node.Entry));
        }

        protected virtual void SetEntityState(EntityEntry entry)
        {
            entry.State = entry.IsKeySet ? EntityState.Unchanged : EntityState.Added;
        }

        /// <summary>
        /// Detach related entities and value objects. Used before we return the data to the upper layers.
        /// DbContext.Entry does not care about navigational property so we need to detach all children
        /// </summary>
        /// <param name="entity"></param>
        protected virtual void DetachGraph(TEntity entity)
        {
            _dbContext.Entry(entity).State = EntityState.Detached;
        }
    }
}
