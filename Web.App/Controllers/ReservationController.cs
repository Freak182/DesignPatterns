using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Web.App.Entity.Common;
using Web.App.Entity.Dto;
using Web.App.Entity.Response;

namespace Web.App.Controllers
{
    [ApiController]
    [Route("/api/reservations")]
    public class ReservationController : BaseController
    {
        private readonly ILogger<PlaneTicketController> _logger;
        private readonly IMediator _mediator;

        public ReservationController(ILogger<PlaneTicketController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        /// <summary>
        /// Get the details of a reservation
        /// </summary>
        /// <param name="reservationId">Reservation Id</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <response code="200">Succesfully returned the flight price</response>
        /// <response code="204">No flight was found</response>
        /// <response code="400">An error has occured</response>
        /// <response code="403">Unauthorized/Forbiden</response>
        /// <response code="500">Internal/Service error(s)</response>
        [HttpGet]
        [ProducesResponseType(typeof(GetReservationResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorInfo), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorInfo), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ErrorInfo), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorInfo), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetReservation([FromQuery][Required] int reservationId)
        {
            return Ok(await _mediator.Send(new GetReservationQueryDto(reservationId), CancellationToken.None));
        }

        /// <summary>
        /// Create a new reservation
        /// </summary>
        /// <param name="command">Command with new object</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(CreateReservationCommandResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorInfo), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorInfo), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ErrorInfo), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorInfo), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateReservation([FromBody][Required] CreateReservationCommandDto command)
        {
            return Ok(await _mediator.Send(command, CancellationToken.None));
        }

    }
}
