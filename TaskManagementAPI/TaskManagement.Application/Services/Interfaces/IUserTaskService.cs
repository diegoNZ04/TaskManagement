using TaskManagement.Application.Dtos.Requests;
using TaskManagement.Application.Dtos.Responses.UserTasksResponses;
using TaskManagement.Domain.Enums;

namespace TaskManagement.Application.Services.Interfaces;

public interface IUserTaskService
{
    Task<CompleteTaskResponse> CompleteTaskAsync(int taskId);
    Task<CreateTaskResponse> CreateTaskAsync(CreateTaskRequest request);
    Task<(IEnumerable<GetAllTasksResponse> Tasks, int TotalCount)> GetAllTasksAsync(int page, int pageSize);
    Task<GetTaskByIdResponse> GetTaskByIdAsync(int taskId);
    Task<UpdateTaskResponse> UpdateTaskAsync(int taskId, string title, string description, TaskPriority priority);
    Task DeleteTaskAsync(int taskId);
}