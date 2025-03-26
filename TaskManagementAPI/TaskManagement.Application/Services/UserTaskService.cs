using AutoMapper;
using FluentValidation;
using TaskManagement.Application.Dtos.Responses.UserTasksResponses;
using TaskManagement.Application.Exceptions;
using TaskManagement.Application.Services.Interfaces;
using TaskManagement.Application.Validators.TaskValidators;
using TaskManagement.Domain.Entities;
using TaskManagement.Domain.Enums;
using TaskManagement.Infra.Repositories.Interfaces;

namespace TaskManagement.Application.Services;

public class UserTaskService : IUserTaskService
{
    private readonly IUserTaskRepository _userTaskRepository;
    private readonly IMapper _mapper;
    private readonly IValidator<CreateTaskValidator> _createTaskValidator;
    private readonly IValidator<UpdateTaskValidator> _updateTaskValidator;
    public UserTaskService(IUserTaskRepository userTaskRepository, IMapper mapper, IValidator<CreateTaskValidator> createTaskValidator, IValidator<UpdateTaskValidator> updateTaskValidator)
    {
        _userTaskRepository = userTaskRepository;
        _mapper = mapper;
        _createTaskValidator = createTaskValidator;
        _updateTaskValidator = updateTaskValidator;
    }

    public async Task<CompleteTaskResponse> CompleteTaskAsync(int taskId)
    {
        var task = await _userTaskRepository.GetUserTaskByIdAsync(taskId);

        if (task == null)
            throw new NotFoundException("Task Not Found.");

        if (task.IsCompleted)
            throw new BadRequestException("Task is already completed.");

        task.IsCompleted = true;
        task.CompletedAt = DateTime.UtcNow;

        await _userTaskRepository.UpdateUserTaskAsync(task);

        return _mapper.Map<CompleteTaskResponse>(task);
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

        var validationContext = new ValidationContext<UserTask>(task);
        var validationResult = await _createTaskValidator.ValidateAsync(validationContext);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        await _userTaskRepository.AddUserTaskAsync(task);

        return _mapper.Map<CreateTaskResponse>(task);
    }

    public async Task DeleteTaskAsync(int taskId)
    {
        var task = await _userTaskRepository.GetUserTaskByIdAsync(taskId);

        if (task != null)
            await _userTaskRepository.DeleteUserTaskAsync(task.Id);
    }

    public async Task<(IEnumerable<GetAllTasksResponse> Tasks, int TotalCount)> GetAllTasksAsync(int page, int pageSize)
    {
        var (tasks, totalCount) = await _userTaskRepository.GetAllUserTasksAsync(page, pageSize);

        var tasksDto = _mapper.Map<IEnumerable<GetAllTasksResponse>>(tasks);

        return (tasksDto, totalCount);
    }

    public async Task<GetTaskByIdResponse> GetTaskByIdAsync(int taskId)
    {
        var task = await _userTaskRepository.GetUserTaskByIdAsync(taskId);

        if (task == null)
            throw new NotFoundException("Task Not Found.");

        var taskDto = _mapper.Map<GetTaskByIdResponse>(task);
        return taskDto;
    }

    public async Task<UpdateTaskResponse> UpdateTaskAsync(int taskId, string title, string description, TaskPriority priority)
    {
        var task = await _userTaskRepository.GetUserTaskByIdAsync(taskId);

        if (task == null)
            throw new NotFoundException("Task Not Found.");

        var updateTaskResponse = new UpdateTaskResponse
        {
            Title = title,
            Description = description,
            Priority = priority
        };

        _mapper.Map(updateTaskResponse, task);

        var validationContext = new ValidationContext<UserTask>(task);
        var validationResult = await _updateTaskValidator.ValidateAsync(validationContext);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        await _userTaskRepository.UpdateUserTaskAsync(task);

        return _mapper.Map<UpdateTaskResponse>(task);
    }
}