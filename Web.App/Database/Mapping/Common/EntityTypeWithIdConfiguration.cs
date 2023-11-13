using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Web.App.Entity.Mapping.Common;

namespace Web.App.Database.Mapping.Common
{
    public class EntityTypeWithIdConfiguration<TEntity> : IEntityMapping
        where TEntity : EntityWithIdBase
    {
        public virtual void Map(EntityTypeBuilder<TEntity> builder, bool isInMemory = false)
        {
            builder
                .HasKey(entity => entity.Id);

            builder
                .Property(entity => entity.Id)
                .UseMySqlIdentityColumn()
                .ValueGeneratedOnAdd();
        }

        public void Map(ModelBuilder builder, bool isInMemory = false)
        {
            Map(builder.Entity<TEntity>(), isInMemory);
        }
    }
}
