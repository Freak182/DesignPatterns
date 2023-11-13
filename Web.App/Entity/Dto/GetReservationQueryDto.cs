using MediatR;
using Web.App.Entity.Response;

namespace Web.App.Entity.Dto
{
    public class GetReservationQueryDto : IRequest<GetReservationResponse>
    {
        public GetReservationQueryDto() { }

        public GetReservationQueryDto(int planeId)
        {
            this.ReservationId = planeId;
        }

        public int ReservationId;
    }
}
