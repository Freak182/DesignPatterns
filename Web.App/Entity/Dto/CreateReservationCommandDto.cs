using MediatR;
using Web.App.Database.DbSet;
using Web.App.Entity.Response;

namespace Web.App.Entity.Dto
{
    public class CreateReservationCommandDto : IRequest<CreateReservationCommandResponse>
    { 
        public Plane? Plane { get; set; }

        public string? State { get; set; }
    }
}
