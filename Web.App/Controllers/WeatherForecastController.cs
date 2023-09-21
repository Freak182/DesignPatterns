using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

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

