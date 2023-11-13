using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Web.App.Database.DbSet;
using Web.App.Entity.Dto;
using Web.App.Entity.Response;

namespace Web.App.Application.Reservations.Queries
{
    /// <summary>
    /// QueryHandler that get a reservation
    /// </summary>
    public class GetReservationQueryHandler : IRequestHandler<GetReservationQueryDto, GetReservationResponse>
    {
        private readonly IReservationService _reservationService;
        private readonly IMapper _mapper;

        public GetReservationQueryHandler(IReservationService reservationService, IMapper mapper)
        {
            _reservationService = reservationService;
            _mapper = mapper;
        }

        public async Task<GetReservationResponse> Handle(GetReservationQueryDto query, CancellationToken cancellationToken)
        {
            // Get
            List<Func<IQueryable<Reservation>, IIncludableQueryable<Reservation, object>>> includes = new();

            includes.Add(source =>
                    source.Include(reservation => reservation.Plane));

            var reservations = _reservationService.GetByIdWithDetails(query.ReservationId, includes);

            // Map
            var response = _mapper.Map<GetReservationResponse>(reservations);

            // Return
            return response;
        }
    }
}
