using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore;
using Web.App.Database.DbSet;
using Web.App.Entity.Dto;
using Web.App.Entity.Response;

namespace Web.App.Application.Reservations.Command
{
    public class CreateReservationCommandHandler : IRequestHandler<CreateReservationCommandDto, CreateReservationCommandResponse>
    {
        private readonly IReservationService _reservationService;
        private readonly IMapper _mapper;

        public CreateReservationCommandHandler(IReservationService reservationService, IMapper mapper)
        {
            _reservationService = reservationService;
            _mapper = mapper;
        }

        public async Task<CreateReservationCommandResponse> Handle(CreateReservationCommandDto command, CancellationToken cancellationToken)
        {
            // Get
            var reservations = _reservationService.CreateEntity(_mapper.Map<Reservation>(command));

            // Map
            var response = _mapper.Map<CreateReservationCommandResponse>(reservations);

            // Return
            return response;
        }
    }
}
