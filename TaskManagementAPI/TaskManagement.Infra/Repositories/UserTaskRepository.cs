using Microsoft.EntityFrameworkCore;
using TaskManagement.Domain.Entities;
using TaskManagement.Infra.Data;
using TaskManagement.Infra.Repositories.Interfaces;

namespace TaskManagement.Infra.Repositories;

public class UserTaskRepository : IUserTaskRepository
{
    ApplicationDbContext _context;
    public UserTaskRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task AddUserTaskAsync(UserTask task)
    {
        _context.UserTasks.Add(task);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteUserTaskAsync(int id)
    {
        var user = await _context.UserTasks.FindAsync(id);

        _context.UserTasks.Remove(user);
        await _context.SaveChangesAsync();

    }

    public async Task<(IEnumerable<UserTask> Tasks, int TotalCount)> GetAllUserTasksAsync(int page, int pageSize)
    {
        var tasks = await _context.UserTasks.AsNoTracking()
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        var totalCount = await _context.UserTasks.CountAsync();

        return (tasks, totalCount);
    }

    public async Task<UserTask> GetUserTaskByIdAsync(int id)
    {
        return await _context.UserTasks
        .Include(u => u.SubTasks)
        .FirstOrDefaultAsync(u => u.Id == id);
    }

    public async Task UpdateUserTaskAsync(UserTask task)
    {
        _context.UserTasks.Update(task);
        await _context.SaveChangesAsync();
    }
}