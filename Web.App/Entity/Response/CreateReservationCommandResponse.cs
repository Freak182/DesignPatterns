using Web.App.Database.DbSet;

namespace Web.App.Entity.Response
{
    public class CreateReservationCommandResponse
    {
        public int ReservationId { get; set; }

        public Plane Plane { get; set; }

        public string? State { get; set; }
    }
}
