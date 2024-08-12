namespace TreeNodeException.Api.Models;

public class ExceptionLog
{
    public int EventId { get; set; }
    public DateTime Timestamp { get; set; }
    public string RequestQueryParams { get; set; }
    public string RequestBody { get; set; }
    public string StackTrace { get; set; }
    public string ExceptionMessage { get; set; }
    public string ExceptionType { get; set; }
}