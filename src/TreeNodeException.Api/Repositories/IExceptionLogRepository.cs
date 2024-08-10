using TreeNodeException.Api.Models;

namespace TreeNodeException.Api.Repositories;

public interface IExceptionLogRepository
{
    Task<IEnumerable<ExceptionLog>> GetAllLogsAsync();
    Task<ExceptionLog> GetLogByIdAsync(int id);
    Task<ExceptionLog> AddLogAsync(ExceptionLog log);
}