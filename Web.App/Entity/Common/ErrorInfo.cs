namespace Web.App.Entity.Common
{
    public class ErrorInfo : System.Object
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public ErrorInfo(string source, string correlationId, ErrorInfoDetail[] exceptions) { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        public string Source { get; set; }
        public string CorrelationId { get; set; }
#nullable disable
        public ErrorInfoDetail[] Exceptions { get; set; }
        public string DisplayMessage { get; }

#nullable enable
    }
}
