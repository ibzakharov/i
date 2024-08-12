namespace TreeNodeException.Api.Dtos;

public record ExceptionLogDto(
    int EventID,
    DateTime Timestamp,
    string RequestParameters,
    string RequestBody,
    string StackTrace,
    string ExceptionMessage,
    string ExceptionType);