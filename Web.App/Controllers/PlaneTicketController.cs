using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Web.App.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlaneTicketController : BaseController
    {
        private readonly ILogger<PlaneTicketController> _logger;
        private readonly IMediator _mediator;

        public PlaneTicketController(ILogger<PlaneTicketController> logger)
        {
            _logger = logger;
        }

        public class GetPriceTicketPriceResponse
        {
            public int Id { get; set; }
            public int Price { get; set; } = 0;
        }

        [HttpGet]
        public IEnumerable<GetPriceTicketPriceResponse> Get()
        {
            var result = (Enumerable.Range(1, 5).Select(index => new GetPriceTicketPriceResponse
            {
                Id = 1,
                Price = 123123141
            }))
            .ToArray();

            return result;
        }
    }
}
