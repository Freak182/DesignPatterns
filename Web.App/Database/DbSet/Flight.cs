using Web.App.Entity.Response;

namespace Web.App.Database.DbSet
{
    public class Flight : EntityWithIdBase
    {
        public int FlightId { get; set; }
        public int Price { get; set; }
    }
}
