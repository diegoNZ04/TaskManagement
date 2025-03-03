using AutoMapper;
using TaskManagement.Application.Dtos.Requests.SubTasksRequests;
using TaskManagement.Application.Dtos.Responses.SubTasksResponses;
using TaskManagement.Domain.Entities;

namespace TaskManagement.Application.Mappings;

public class SubTaskProfile : Profile
{
    public SubTaskProfile()
    {
        CreateMap<SubTask, CreateSubTaskRequest>().ReverseMap();
        CreateMap<SubTask, UpdateSubTaskRequest>().ReverseMap();
        CreateMap<SubTask, CreateSubTaskResponse>().ReverseMap();
        CreateMap<SubTask, UpdateSubTaskResponse>().ReverseMap();
    }
}