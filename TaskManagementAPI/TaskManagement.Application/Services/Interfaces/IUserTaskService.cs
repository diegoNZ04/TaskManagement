using TaskManagement.Application.Dtos.Responses.UserTasksResponses;
using TaskManagement.Domain.Enums;

namespace TaskManagement.Application.Services.Interfaces;

public interface IUserTaskService
{
    Task<CreateTaskResponse> CreateTaskAsync(string title, string description, int userId, TaskPriority priority);
    Task<IEnumerable<GetAllTasksResponse>> GetAllTasksAsync();
    Task<GetTaskByIdResponse> GetTaskByIdAsync(int taskId);
    Task<UpdateTaskResponse> UpdateTaskAsync(int taskId, string title, string description, TaskPriority priority);
    Task DeleteTaskAsync(int taskId);
}