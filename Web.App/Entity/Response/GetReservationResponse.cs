using System.Numerics;

namespace Web.App.Entity.Response
{
    public class GetReservationResponse
    {
        public int ReservationId { get; set; }

        public Plane? Plane { get; set; }

        public string? State { get; set; }
    }
}
