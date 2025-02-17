using TaskManagementAPI.Application.Dtos.Responses;

namespace TaskManagementAPI.Application.Services.Interfaces
{
    public interface ITaskItemService
    {
        Task<TaskItemResponse> CreateNewTaskItem(string name, string description);
        Task DeleteTaskItemById(int taskId);
        Task<List<TaskItemResponse>> GetAllTaskItems();
        Task GetTaskItemById(int taskId);
        Task UpdateTaskItemById(int taskId);
    }
}