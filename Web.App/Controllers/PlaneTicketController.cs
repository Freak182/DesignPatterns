using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Web.App.Entity.Common;
using Web.App.Entity.Dto;
using Web.App.Entity.Response;

namespace Web.App.Controllers
{
    [ApiController]
    [Route("/api/planeflightticket")]
    public class PlaneTicketController : BaseController
    {
        private readonly ILogger<PlaneTicketController> _logger;
        private readonly IMediator _mediator;

        public PlaneTicketController(ILogger<PlaneTicketController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        /// <summary>
        /// Get plane ticket price for a specific flight
        /// </summary>
        /// <param name="planeId">Flight Id</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <response code="200">Succesfully returned the flight price</response>
        /// <response code="204">No flight was found</response>
        /// <response code="400">An error has occured</response>
        /// <response code="403">Unauthorized/Forbiden</response>
        /// <response code="500">Internal/Service error(s)</response>
        [HttpGet]
        [Route("resources/plane/{plane:int}/price")]
        [ProducesResponseType(typeof(GetPlaneTicketPriceResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorInfo), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorInfo), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ErrorInfo), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorInfo), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetPlaneTicketPrice([FromQuery][Required] int planeId)
        {
            return Ok(await _mediator.Send(new GetPlaneTicketQueryDto(planeId), CancellationToken.None));
        }
    }
}
