using TaskManagement.Application.Dtos.Responses.SubTasksResponses;

namespace TaskManagement.Application.Services.Interfaces;

public interface ISubTaskService
{
    Task<CompleteSubTaskResponse> CompleteSubTaskAsync(int subTaskId);
    Task<CreateSubTaskResponse> CreateSubTaskAsync(string description, int taskId);
    Task<GetSubTaskByIdResponse> GetSubTaskByIdAsync(int subTaskId);
    Task<UpdateSubTaskResponse> UpdateSubTaskAsync(int subTaskId, string description);
    Task DeleteSubTaskAsync(int subTaskId);
}