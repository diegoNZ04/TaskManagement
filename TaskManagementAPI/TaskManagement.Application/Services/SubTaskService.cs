using System.Net.Cache;
using AutoMapper;
using FluentValidation;
using TaskManagement.Application.Dtos.Requests.SubTasksRequests;
using TaskManagement.Application.Dtos.Responses.SubTasksResponses;
using TaskManagement.Application.Exceptions;
using TaskManagement.Application.Services.Interfaces;
using TaskManagement.Application.Validators.SubTaskValidators;
using TaskManagement.Domain.Entities;
using TaskManagement.Infra.Repositories.Interfaces;

namespace TaskManagement.Application.Services;

public class SubTaskService : ISubTaskService
{
    private readonly ISubTaskRepository _subTaskRepository;
    private readonly IMapper _mapper;
    private readonly IValidator<CreateSubTaskRequest> _createSubTaskValidator;
    private readonly IValidator<UpdateSubTaskRequest> _updateSubTaskValidator;
    public SubTaskService(
        ISubTaskRepository subTaskRepository,
        IMapper mapper, IValidator<CreateSubTaskRequest> createSubTaskValidator,
        IValidator<UpdateSubTaskRequest> updateSubTaskValidator)
    {
        _subTaskRepository = subTaskRepository;
        _mapper = mapper;
        _createSubTaskValidator = createSubTaskValidator;
        _updateSubTaskValidator = updateSubTaskValidator;
    }

    public async Task<CompleteSubTaskResponse> CompleteSubTaskAsync(int subTaskId)
    {
        var subTaks = await _subTaskRepository.GetSubTaskByIdAsync(subTaskId);

        if (subTaks == null)
            throw new NotFoundException("SubTask Not Found.");

        if (subTaks.IsCompleted)
            throw new BadRequestException("SubTask is already completed.");

        subTaks.IsCompleted = true;
        subTaks.CompletedAt = DateTime.UtcNow;

        await _subTaskRepository.UpdateSubTaskAsync(subTaks);

        return _mapper.Map<CompleteSubTaskResponse>(subTaks);
    }

    public async Task<CreateSubTaskResponse> CreateSubTaskAsync(CreateSubTaskRequest request)
    {
        var validationResult = await _createSubTaskValidator.ValidateAsync(request);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var subTask = _mapper.Map<SubTask>(request);

        await _subTaskRepository.AddSubTaskAsync(subTask);

        return _mapper.Map<CreateSubTaskResponse>(subTask);
    }

    public async Task DeleteSubTaskAsync(int subTaskId)
    {
        var subTask = await _subTaskRepository.GetSubTaskByIdAsync(subTaskId);

        if (subTask != null)
            await _subTaskRepository.DeleteSubTaskAsync(subTask.Id);
    }

    public async Task<GetSubTaskByIdResponse> GetSubTaskByIdAsync(int subTaskId)
    {
        var subTask = await _subTaskRepository.GetSubTaskByIdAsync(subTaskId);

        if (subTask == null)
            throw new NotFoundException("SubTask Not Found.");

        var subTaskDto = _mapper.Map<GetSubTaskByIdResponse>(subTask);
        return subTaskDto;
    }

    public async Task<UpdateSubTaskResponse> UpdateSubTaskAsync(int subTaskId, string description)
    {
        var subTask = await _subTaskRepository.GetSubTaskByIdAsync(subTaskId);

        if (subTask == null)
            throw new NotFoundException("SubTask Not Found.");

        var updateSubTaskResponse = new UpdateSubTaskResponse
        {
            Description = description
        };

        _mapper.Map(updateSubTaskResponse, subTask);

        var validationContext = new ValidationContext<SubTask>(subTask);
        var validationResult = await _updateSubTaskValidator.ValidateAsync(validationContext);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        await _subTaskRepository.UpdateSubTaskAsync(subTask);

        return _mapper.Map<UpdateSubTaskResponse>(subTask);
    }
}