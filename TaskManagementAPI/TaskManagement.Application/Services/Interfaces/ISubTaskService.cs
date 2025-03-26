using TaskManagement.Application.Dtos.Requests.SubTasksRequests;
using TaskManagement.Application.Dtos.Responses.SubTasksResponses;

namespace TaskManagement.Application.Services.Interfaces;

public interface ISubTaskService
{
    Task<CompleteSubTaskResponse> CompleteSubTaskAsync(int subTaskId);
    Task<CreateSubTaskResponse> CreateSubTaskAsync(CreateSubTaskRequest request);
    Task<GetSubTaskByIdResponse> GetSubTaskByIdAsync(int subTaskId);
    Task<UpdateSubTaskResponse> UpdateSubTaskAsync(int subTaskId, string description);
    Task DeleteSubTaskAsync(int subTaskId);
}