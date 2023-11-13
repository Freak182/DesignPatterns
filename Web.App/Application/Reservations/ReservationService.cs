using Web.App.Application.Common;
using Web.App.Application.Repositories;
using Web.App.Database.DbSet;

namespace Web.App.Application.Reservations
{
    public class ReservationService : EntityWithIdService<Reservation>, IReservationService
    {
        public ReservationService(IReservationRepository reservationRepository)
            : base(reservationRepository) 
        { 
        }
    }
}
