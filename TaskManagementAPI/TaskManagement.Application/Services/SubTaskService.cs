using AutoMapper;
using TaskManagement.Application.Dtos.Responses.SubTasksResponses;
using TaskManagement.Application.Services.Interfaces;
using TaskManagement.Domain.Entities;
using TaskManagement.Infra.Repositories.Interfaces;

namespace TaskManagement.Application.Services;

public class SubTaskService : ISubTaskService
{
    private readonly ISubTaskRepository _subTaskRepository;
    private readonly IMapper _mapper;
    public SubTaskService(ISubTaskRepository subTaskRepository, IMapper mapper)
    {
        _subTaskRepository = subTaskRepository;
        _mapper = mapper;
    }
    public async Task<CreateSubTaskResponse> CreateSubTaskAsync(string description, int taskId)
    {
        var subTask = _mapper.Map<SubTask>(new CreateSubTaskResponse
        {
            Description = description,
            UserTaskId = taskId
        });

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
            throw new Exception("SubTask Not Found.");

        var subTaskDto = _mapper.Map<GetSubTaskByIdResponse>(subTask);
        return subTaskDto;
    }

    public async Task<UpdateSubTaskResponse> UpdateSubTaskAsync(int subTaskId, string description)
    {
        var subTask = await _subTaskRepository.GetSubTaskByIdAsync(subTaskId);

        if (subTask == null)
            throw new Exception("SubTask Not Found.");

        var updateSubTaskResponse = new UpdateSubTaskResponse
        {
            Description = description
        };

        _mapper.Map(updateSubTaskResponse, subTask);

        await _subTaskRepository.UpdateSubTaskAsync(subTask);

        return _mapper.Map<UpdateSubTaskResponse>(subTask);
    }
}