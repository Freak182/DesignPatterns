using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Web.App.Database.DbSet;
using Web.App.Database.Mapping.Common;

namespace Web.App.Database.Mapping
{
    public class ReservationMapping : EntityTypeWithIdConfiguration<Reservation>
    {
        public override void Map(EntityTypeBuilder<Reservation> builder, bool isInMemory = false)
        {
            base.Map(builder, isInMemory);

            builder
                .ToTable("Reservations");

            builder
                .Property(x => x.Id)
                .HasColumnName("ReservationId");

            builder
                .Property(x => x.State)
                .IsRequired()
                .HasMaxLength(MappingConstants.Database.Lengths.RefCodeLength)
                .HasColumnType(MappingConstants.Database.Types.Varchar);

            builder
                .HasOne(x => x.Flight)
                .WithMany()
                .HasForeignKey("FlightId");
        }
    }
}
