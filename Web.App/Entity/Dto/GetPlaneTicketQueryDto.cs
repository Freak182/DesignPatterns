﻿using MediatR;
using Web.App.Entity.Response;

namespace Web.App.Entity.Dto
{
    /// <summary>
    /// GetPlaneTicketQuery class, transforms into GetPriceTicketPriceResponse
    /// </summary>
    public class GetPlaneTicketQueryDto : IRequest<GetPlaneTicketPriceResponse>
    {
        public GetPlaneTicketQueryDto() { }

        public GetPlaneTicketQueryDto(int flightId)
        {
            this.FlightId = flightId;
        }

        public int FlightId;
    }
}
