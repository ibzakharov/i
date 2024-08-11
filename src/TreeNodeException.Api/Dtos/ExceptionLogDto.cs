namespace TreeNodeException.Dtos;

public record ExceptionLogDTO(
    int EventID,
    DateTime Timestamp,
    string RequestParameters,
    string RequestBody,
    string StackTrace,
    string ExceptionMessage,
    string ExceptionType);