using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.ComponentModel.DataAnnotations;

namespace Web.App.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IMediator _mediator;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        public class ErrorInfo
        {

        }

        public class GetPriceTicketPriceResponse
        {

        }

        /// <summary>
        /// Get plane ticket price for a specific flight
        /// </summary>
        /// <param name="flightId">Flight Id</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <response code="200">Succesfully returned the flight price</response>
        /// <response code="204">No flight was found</response>
        /// <response code="400">An error has occured</response>
        /// <response code="403">Unauthorized/Forbiden</response>
        /// <response code="500">Internal/Service error(s)</response>
        [HttpGet]
        [Route("resources/flights/{flightId:int}/price")]
        [ProducesResponseType(typeof(GetPriceTicketPriceResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorInfo), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorInfo), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ErrorInfo), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorInfo), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetPlaneTicketPrice([FromQuery][Required] int flightId, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(new GetPlaneTicketQueryDto(flightId), cancellationToken));
        }

        /// <summary>
        /// QueryHandler that updates a plane ticket price
        /// </summary>
        public class GetPlaneTicketQueryHandler : IRequestHandler<GetPlaneTicketQueryDto, GetPriceTicketPriceResponse>
        {
            public async Task<GetPriceTicketPriceResponse> Handle(GetPlaneTicketQueryDto query, CancellationToken cancellationToken)
            {
                // Get
                // Map
                // Return
                return new GetPriceTicketPriceResponse();
            }
        }

        /// <summary>
        /// GetPlaneTicketQuery class, transforms into GetPriceTicketPriceResponse
        /// </summary>
        public class GetPlaneTicketQueryDto : IRequest<GetPriceTicketPriceResponse>
        {
            private int flightId;

            public GetPlaneTicketQueryDto(int flightId)
            {
                this.flightId = flightId;
            }
        }

        /// <summary>
        /// Update the price of a ticket for a specific flight
        /// </summary>
        /// <param name="flightId">Flight Id</param>
        /// <param name="command">Update command</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        [HttpPut]
        [Route("resources/flights/{flightId:int}/price")]
        [ProducesResponseType(typeof(UpdateFlightPriceCommandResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorInfo), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorInfo), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ErrorInfo), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorInfo), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdatePlaneTicketPrice([FromQuery][Required] int flightId, [FromBody][Required] UpdateFlightPriceCommandDto command, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(command, cancellationToken));
        }

        /// <summary>
        /// Update the price of a plane ticket based on an updateCommand
        /// </summary>
        public class UpdateFlightPriceCommandHandler : IRequestHandler<UpdateFlightPriceCommandDto, UpdateFlightPriceCommandResponse>
        {
            public async Task<UpdateFlightPriceCommandResponse> Handle(UpdateFlightPriceCommandDto command, CancellationToken cancellationToken)
            {
                // Get
                // Map
                // Return
                return new UpdateFlightPriceCommandResponse();
            }
        }

        /// <summary>
        /// UpdateFlightPriceCommandDto class, transforms into UpdateFlightPriceCommandResponse
        /// </summary>
        public class UpdateFlightPriceCommandDto : IRequest<UpdateFlightPriceCommandResponse>
        {
            int flightId { get; set; } 
            int newPrice { get; set; }
        }

        public class UpdateFlightPriceCommandResponse
        {
            int flightId { get; set; }
        }
    }

    //internal partial class ChangeTicketPrice_September2023: Migration
    //{
    //    protected override void Up(MigrationBuilder migrationBuilder) 
    //    {
    //        new ChangeTicketPrice_September2023DataSeed().ExecuteMigration(migrationBuilder);
    //    }

    //    protected override void Down(MigrationBuilder migrationBuilder)
    //    {
    //        new ChangeTicketPrice_September2023DataSeed().ExecuteMigration(migrationBuilder, true);
    //    }
    //}

    //internal class ChangeTicketPrice_September2023DataSeed : ChangeTicketPriceDataSeed
    //{
    //    public override int oldTicketPrice => 100;
    //    public override int newTicketPrice => 50;

    //    public override void ExecuteMigration(MigrationBuilder migrationBuilder, Boolean dowm = false)
    //    {
    //        this.UpdateData(migrationBuilder, dowm);
    //    }

    //    public override void UpdateData(MigrationBuilder migrationBuilder, bool down)
    //    {
    //        ChangeTicketPriceTools.setTicketPrice(down ? oldTicketPrice : newTicketPrice);
    //    }
    //}

    //internal abstract class ChangeTicketPriceDataSeed: MigrationDataSeed
    //{
    //    public abstract int oldTicketPrice { get; }
    //    public abstract int newTicketPrice { get; }
    //    public Boolean down { get; set; }
    //}

    //internal abstract class MigrationDataSeed : IMigrationDataSeed
    //{
    //    public DateTime ModificationDateTime => DateTime.Now;
    //    public abstract void ExecuteMigration(MigrationBuilder migrationBuilder, Boolean down);
    //    public abstract void UpdateData(MigrationBuilder migrationBuilder, Boolean down);
    //}

    //internal interface IMigrationDataSeed
    //{
    //    public DateTime ModificationDateTime { get; }
    //    public abstract void ExecuteMigration(MigrationBuilder migrationBuilder, Boolean down);
    //    public abstract void UpdateData(MigrationBuilder migrationBuilder, Boolean down);
    //}

    //public class ChangeTicketPriceTools
    //{
    //    internal static void setTicketPrice(int ticketPrice)
    //    {
    //        // Change ticket price with EF CORE
    //    }
    //}

}

