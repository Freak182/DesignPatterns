using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Web.App.Database
{
    //
    // Summary:
    //     Use this interface when getting injected a dbContext instead of the concrete
    //     class of DbContext It will then be easier to reuse DAL classes in all services
    //     and microservices. Those classes will get an IDbContext injected and micro services
    //     will have to configure DI with their own DbContext concrete class. Microsoft.EntityFrameworkCore.DbContext
    public interface IDbContext
    {
        DatabaseFacade Database
        {
            get;
        }

        ChangeTracker ChangeTracker
        {
            get;
        }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        EntityEntry<TEntity> Update<TEntity>(TEntity entity) where TEntity : class;

        EntityEntry<TEntity> Remove<TEntity>(TEntity entity) where TEntity : class;

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
