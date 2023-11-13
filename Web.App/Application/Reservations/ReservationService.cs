using Web.App.Application.Common;
using Web.App.Application.Repositories;
using Web.App.Database.DbSet;

namespace Web.App.Application.Reservations
{
    public class ReservationService : IReservationService
    {
        protected readonly IReservationRepository _reservationRepository;

        public ReservationService(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        /// <summary>
        /// Get entity by id
        /// </summary>
        /// <param name="id">Entity id</param>
        /// <returns></returns>
        public Reservation GetById(int id)
        {
            return _reservationRepository.GetById(id);
        }
    }
}
