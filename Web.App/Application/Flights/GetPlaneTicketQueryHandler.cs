using MediatR;
using Web.App.Entity.Response;
using Web.App.Entity.Dto;

namespace Web.App.Application.Flights
{
    /// <summary>
    /// QueryHandler that get a plane ticket price
    /// </summary>
    public class GetPlaneTicketQueryHandler : IRequestHandler<GetPlaneTicketQueryDto, GetPlaneTicketPriceResponse>
    {
        public async Task<GetPlaneTicketPriceResponse> Handle(GetPlaneTicketQueryDto query, CancellationToken cancellationToken)
        {
            // Get
            var result = new GetPlaneTicketPriceResponse()
            {
                Id = 1,
                Price = 123
            };
            // Map

            // Return
            return result;
        }
    }
}
