namespace Web.App.Database.DbSet
{
    public class Reservation : EntityWithIdBase
    {
        public int ReservationId { get; set; }
        public int FlightsId { get; set; }
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public string State { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    }
}
