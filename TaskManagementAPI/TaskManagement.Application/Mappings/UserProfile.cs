using AutoMapper;
using TaskManagement.Application.Dtos.Requests.UserResquests;
using TaskManagement.Application.Dtos.Responses.UserResponses;
using TaskManagement.Domain.Entities;

namespace TaskManagement.Application.Mappings;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<User, CreateUserRequest>()
            .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.PasswordHash))
            .ReverseMap();

        CreateMap<User, CreateUserResponse>()
            .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.PasswordHash))
            .ReverseMap();

        CreateMap<User, LoginUserRequest>()
            .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.PasswordHash))
            .ReverseMap();

        CreateMap<User, GetUserByIdResponse>()
        .ForMember(dest => dest.TasksUser, opt => opt.MapFrom(src => src.Tasks));

        CreateMap<User, GetAllUsersResponse>();

    }
}