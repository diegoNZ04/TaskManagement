using TaskManagement.Domain.Entities;

namespace TaskManagement.Infra.Repositories.Interfaces;

public interface ISubTaskRepository
{
    Task<IEnumerable<SubTask>> GetAllSubTasksAsync();
    Task<SubTask> GetSubTaskByIdAsync(int id);
    Task AddSubTaskAsync(SubTask subTask);
    Task UpdateSubTaskAsync(SubTask subTask);
    Task DeleteSubTaskAsync(int id);
}