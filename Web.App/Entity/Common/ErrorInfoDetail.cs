namespace Web.App.Entity.Common
{
    public class ErrorInfoDetail : System.Object
    {
        public ErrorInfoDetail() { }

        public string? Code { get; init; }
        public string? Message { get; init; }
        public string? ReasonType { get; init; }
        public string? FriendlyMessage { get; init; }
#nullable disable
        public string Details { get; init; }

#nullable enable
    }
}
