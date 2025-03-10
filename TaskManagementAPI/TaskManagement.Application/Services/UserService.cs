using AutoMapper;
using TaskManagement.Application.Dtos.Responses.UserResponses;
using TaskManagement.Application.Services.Interfaces;
using TaskManagement.Domain.Entities;
using TaskManagement.Infra.Repositories.Interfaces;

namespace TaskManagement.Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    public UserService(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }
    public async Task<CreateUserResponse> CreateUserAsync(string username, string password, string email)
    {
        var user = _mapper.Map<User>(new CreateUserResponse
        {
            Username = username,
            Password = password,
            Email = email
        });

        await _userRepository.AddUserAsync(user);

        return _mapper.Map<CreateUserResponse>(user);
    }

    public async Task DeleteUserAsync(int userId)
    {
        var user = await _userRepository.GetUserByIdAsync(userId);

        if (user != null)
            await _userRepository.DeleteUserAsync(user.Id);
    }

    public async Task<IEnumerable<GetAllUsersResponse>> GetAllUsersAsync()
    {
        var users = await _userRepository.GetAllUsersAsync();

        var usersDto = _mapper.Map<IEnumerable<GetAllUsersResponse>>(users);

        return usersDto;
    }

    public async Task<GetUserByIdResponse> GetUserByIdAsync(int userId)
    {
        var user = await _userRepository.GetUserByIdAsync(userId);

        if (user == null)
            throw new Exception("User Not Found.");

        var userDto = _mapper.Map<GetUserByIdResponse>(user);
        return userDto;
    }
}