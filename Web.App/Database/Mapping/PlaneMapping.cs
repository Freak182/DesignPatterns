using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Web.App.Database.DbSet;
using Web.App.Database.Mapping.Common;

namespace Web.App.Database.Mapping.FlightsMapping
{
    public class PlaneMapping : EntityTypeWithIdConfiguration<Plane>
    {
        public override void Map(EntityTypeBuilder<Plane> builder, bool isInMemory = false)
        {
            base.Map(builder, isInMemory);

            builder
                .ToTable("Plane");

            builder
                .Property(x => x.Id)
                .HasColumnName("PlaneId");

            builder
                .Property(x => x.Price)
                .HasColumnName("Price")
                .HasColumnType("integer");
        }
    }
}
