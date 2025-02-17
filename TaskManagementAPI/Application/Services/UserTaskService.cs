using TaskManagement.Domain.Entities;
using TaskManagementAPI.Application.Dtos.Responses;
using TaskManagementAPI.Application.Services.Interfaces;
using TaskManagementAPI.Domain.Entities.Interfaces;

namespace TaskManagementAPI.Application.Services
{
    public class TaskItemService : ITaskItemService
    {
        private readonly ITaskItemRepository _TaskItemRepository;
        public TaskItemService(ITaskItemRepository TaskItemRepository)
        {
            _TaskItemRepository = TaskItemRepository;
        }
        public async Task<TaskItemResponse> CreateNewTaskItem(string name, string description)
        {
            var task = new TaskItem
            {
                Name = name,
                Description = description
            };

            await _TaskItemRepository.AddAsync(task);

            return new TaskItemResponse
            {
                Id = task.Id,
                Name = task.Name,
                Description = task.Description
            };
        }

        public async Task DeleteTaskItemById(int taskId)
        {
            var task = await _TaskItemRepository.GetByIdAsync(taskId);

            if (task != null)
                await _TaskItemRepository.DeleteAsync(task.Id);
        }

        public Task<List<TaskItemResponse>> GetAllTaskItems()
        {
            throw new NotImplementedException();
        }

        public Task GetTaskItemById(int taskId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateTaskItemById(int taskId)
        {
            throw new NotImplementedException();
        }
    }
}