using Microsoft.EntityFrameworkCore;
using TaskManagement.Domain.Entities;
using TaskManagement.Infra.Data;
using TaskManagement.Infra.Repositories.Interfaces;

namespace TaskManagement.Infra.Repositories;

public class SubTaskRepository : ISubTaskRepository
{
    ApplicationDbContext _context;
    public SubTaskRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task AddSubTaskAsync(SubTask subTask)
    {
        _context.SubTasks.Add(subTask);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteSubTaskAsync(int id)
    {
        var subTask = await _context.SubTasks.FindAsync(id);

        _context.SubTasks.Remove(subTask);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<SubTask>> GetAllSubTasksAsync()
    {
        return await _context.SubTasks.AsNoTracking().ToListAsync();
    }

    public async Task<SubTask> GetSubTaskByIdAsync(int id)
    {
        return await _context.SubTasks.FirstOrDefaultAsync(u => u.Id == id);
    }

    public async Task UpdateSubTaskAsync(SubTask subTask)
    {
        _context.SubTasks.Update(subTask);
        await _context.SaveChangesAsync();
    }
}