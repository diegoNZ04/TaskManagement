using TaskManagement.Domain.Entities;

namespace TaskManagement.Infra.Repositories.Interfaces;

public interface IUserTaskRepository
{
    Task<IEnumerable<UserTask>> GetAllUserTasksAsync();
    Task<UserTask> GetUserTaskByIdAsync(int id);
    Task AddUserTaskAsync(UserTask task);
    Task UpdateUserTaskAsync(UserTask task);
    Task DeleteUserTaskAsync(int id);
}