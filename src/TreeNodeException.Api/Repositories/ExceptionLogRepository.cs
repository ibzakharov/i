using Microsoft.EntityFrameworkCore;
using TreeNodeException.Api.Models;

namespace TreeNodeException.Api.Repositories;

public class ExceptionLogRepository : IExceptionLogRepository
{
    private readonly ApplicationDbContext _context;

    public ExceptionLogRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<ExceptionLog>> GetAllLogsAsync()
    {
        return await _context.ExceptionLogs.ToListAsync();
    }

    public async Task<ExceptionLog> GetLogByIdAsync(int id)
    {
        return await _context.ExceptionLogs.FindAsync(id);
    }

    public async Task<ExceptionLog> AddLogAsync(ExceptionLog log)
    {
        _context.ExceptionLogs.Add(log);
        await _context.SaveChangesAsync();
        return log;
    }
}