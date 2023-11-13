using MediatR;
using Web.App.Entity.Response;

namespace Web.App.Entity.Dto
{
    public class GetReservationQueryDto : IRequest<GetReservationResponse>
    {
        public GetReservationQueryDto() { }

        public GetReservationQueryDto(int flightId)
        {
            this.ReservationId = flightId;
        }

        public int ReservationId;
    }
}
