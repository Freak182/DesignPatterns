namespace Web.App.Database.DbSet
{
    public class Reservation : EntityWithIdBase
    {
        public Flight? Flight { get; set; }

        public string? State { get; set; }
    }
}
