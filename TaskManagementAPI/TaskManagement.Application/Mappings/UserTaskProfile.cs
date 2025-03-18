using AutoMapper;
using TaskManagement.Application.Dtos.Requests;
using TaskManagement.Application.Dtos.Requests.UserTasksRequests;
using TaskManagement.Application.Dtos.Responses.UserTasksResponses;
using TaskManagement.Domain.Entities;

namespace TaskManagement.Application.Mappings;

public class UserTaskProfile : Profile
{
    public UserTaskProfile()
    {
        CreateMap<UserTask, CreateTaskRequest>().ReverseMap();
        CreateMap<UserTask, UpdateTaskRequest>().ReverseMap();
        CreateMap<UserTask, CreateTaskResponse>().ReverseMap();
        CreateMap<UserTask, UpdateTaskResponse>().ReverseMap();
        CreateMap<UserTask, CompleteTaskResponse>().ReverseMap();

        CreateMap<UserTask, GetTaskByIdResponse>()
            .ForMember(dest => dest.SubtaskTask, opt => opt.MapFrom(src => src.SubTasks));

        CreateMap<UserTask, GetAllTasksResponse>();
    }
}