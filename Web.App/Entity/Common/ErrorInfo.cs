using static Web.App.Controllers.FlightTicketController;

namespace Web.App.Entity.Common
{
    public class ErrorInfo : System.Object
    {
        public ErrorInfo(string source, string correlationId, ErrorInfoDetail[] exceptions) { }

        public string Source { get; set; }
        public string CorrelationId { get; set; }
#nullable disable
        public ErrorInfoDetail[] Exceptions { get; set; }
        public string DisplayMessage { get; }

#nullable enable
    }
}
