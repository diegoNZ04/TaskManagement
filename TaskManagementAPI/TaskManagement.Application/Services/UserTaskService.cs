using AutoMapper;
using TaskManagement.Application.Dtos.Responses.UserTasksResponses;
using TaskManagement.Application.Services.Interfaces;
using TaskManagement.Domain.Entities;
using TaskManagement.Domain.Enums;
using TaskManagement.Infra.Repositories.Interfaces;

namespace TaskManagement.Application.Services;

public class UserTaskService : IUserTaskService
{
    private readonly IUserTaskRepository _userTaskRepository;
    private readonly IMapper _mapper;
    public UserTaskService(IUserTaskRepository userTaskRepository, IMapper mapper)
    {
        _userTaskRepository = userTaskRepository;
        _mapper = mapper;
    }
    public async Task<CreateTaskResponse> CreateTaskAsync(string title, string description, int userId, TaskPriority priority)
    {
        var task = _mapper.Map<UserTask>(new CreateTaskResponse
        {
            Title = title,
            Description = description,
            UserId = userId,
            Priority = priority
        });

        await _userTaskRepository.AddUserTaskAsync(task);

        return _mapper.Map<CreateTaskResponse>(task);
    }

    public async Task DeleteTaskAsync(int taskId)
    {
        var task = await _userTaskRepository.GetUserTaskByIdAsync(taskId);

        if (task != null)
            await _userTaskRepository.DeleteUserTaskAsync(task.Id);
    }

    public async Task<IEnumerable<GetAllTasksResponse>> GetAllTasksAsync()
    {
        var tasks = await _userTaskRepository.GetAllUserTasksAsync();

        var tasksDto = _mapper.Map<IEnumerable<GetAllTasksResponse>>(tasks);

        return tasksDto;
    }

    public async Task<GetTaskByIdResponse> GetTaskByIdAsync(int taskId)
    {
        var task = await _userTaskRepository.GetUserTaskByIdAsync(taskId);

        if (task == null)
            throw new Exception("Task Not Found.");

        var taskDto = _mapper.Map<GetTaskByIdResponse>(task);
        return taskDto;
    }

    public async Task<UpdateTaskResponse> UpdateTaskAsync(int taskId, string title, string description, TaskPriority priority)
    {
        var task = await _userTaskRepository.GetUserTaskByIdAsync(taskId);

        if (task == null)
            throw new Exception("Task Not Found.");

        var updateTaskResponse = new UpdateTaskResponse
        {
            Title = title,
            Description = description,
            Priority = priority
        };

        _mapper.Map(updateTaskResponse, task);

        await _userTaskRepository.UpdateUserTaskAsync(task);

        return _mapper.Map<UpdateTaskResponse>(task);
    }
}