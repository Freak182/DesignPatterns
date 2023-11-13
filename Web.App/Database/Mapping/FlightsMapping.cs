using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Web.App.Database.DbSet;
using Web.App.Database.Mapping.Common;

namespace Web.App.Database.Mapping.FlightsMapping
{
    public class FlightsMapping : EntityTypeWithIdConfiguration<Flight>
    {
        public override void Map(EntityTypeBuilder<Flight> builder, bool isInMemory = false)
        {
            base.Map(builder, isInMemory);

            builder
                .ToTable("Flights");

            builder
                .Property(x => x.Id)
                .HasColumnName("FlightId");

            builder
                .Property(x => x.Price)
                .HasColumnName("Price")
                .HasColumnType("integer");
        }
    }
}
