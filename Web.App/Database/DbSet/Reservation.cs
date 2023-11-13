namespace Web.App.Database.DbSet
{
    public class Reservation : EntityWithIdBase
    {
        public Plane? Plane { get; set; }

        public string? State { get; set; }
    }
}
