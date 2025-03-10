using TaskManagement.Application.Dtos.Responses.SubTasksResponses;

namespace TaskManagement.Application.Services.Interfaces;

public interface ISubTaskService
{
    Task<CreateSubTaskResponse> CreateSubTaskAsync(string description, int taskId);
    Task<UpdateSubTaskResponse> UpdateSubTaskAsync(int subTaskId, string description);
    Task DeleteSubTaskAsync(int subTaskId);
}