using Microsoft.EntityFrameworkCore;
using Web.App.Database;
using Web.App.Entity.Common;

namespace Web.App.Entity.Common
{
    internal static class DbContexExtension
    {
        public static void AddOrUpdate<TEntity>(this DbSet<TEntity> set, TEntity entity) where TEntity : EntityWithIdBase
        {

            _ = !set.Any(e => e.Id == entity.Id) ? set.Add(entity) : set.Update(entity);

        }

        public static void AddOrUpdateRange<TEntity>(this DbSet<TEntity> set, IEnumerable<TEntity> entities) where TEntity : EntityWithIdBase

        {
            foreach (var entity in entities)
            {
                set.AddOrUpdate(entity);
            }

        }
    }
}
