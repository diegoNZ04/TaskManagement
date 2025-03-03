using AutoMapper;
using TaskManagement.Application.Dtos.Requests;
using TaskManagement.Application.Dtos.Requests.UserTasksRequests;
using TaskManagement.Application.Dtos.Responses.UserTasksResponses;
using TaskManagement.Domain.Entities;

namespace TaskManagement.Application.Mappings;

public class TaskProfile : Profile
{
    public TaskProfile()
    {
        CreateMap<UserTask, CreateTaskRequest>().ReverseMap();
        CreateMap<UserTask, UpdateTaskRequest>().ReverseMap();
        CreateMap<UserTask, CreateTaskResponse>().ReverseMap();
        CreateMap<UserTask, UpdateTaskResponse>().ReverseMap();
        CreateMap<UserTask, GetTaskByIdResponse>();
        CreateMap<UserTask, GetAllTasksResponse>();
    }
}