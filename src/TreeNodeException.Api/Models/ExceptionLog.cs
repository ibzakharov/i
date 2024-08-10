namespace TreeNodeException.Api.Models;

public class ExceptionLog
{
    public int EventID { get; set; }
    public DateTime Timestamp { get; set; }
    public string RequestParameters { get; set; }
    public string RequestBody { get; set; }
    public string StackTrace { get; set; }
    public string ExceptionMessage { get; set; }
    public string ExceptionType { get; set; }
}