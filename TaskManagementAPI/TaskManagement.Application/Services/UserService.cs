using AutoMapper;
using FluentValidation;
using TaskManagement.Application.Dtos.Requests.UserResquests;
using TaskManagement.Application.Dtos.Responses.UserResponses;
using TaskManagement.Application.Exceptions;
using TaskManagement.Application.Services.Interfaces;
using TaskManagement.Domain.Entities;
using TaskManagement.Infra.Repositories.Interfaces;

namespace TaskManagement.Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly IValidator<CreateUserRequest> _createUserValidator;
    private readonly IHasherService _hasherService;
    public UserService(IUserRepository userRepository, IMapper mapper, IValidator<CreateUserRequest> createUserValidator, IHasherService hasherService)
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _createUserValidator = createUserValidator;
        _hasherService = hasherService;
    }
    public async Task<CreateUserResponse> CreateUserAsync(CreateUserRequest request)
    {
        var validationResult = await _createUserValidator.ValidateAsync(request);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var hashedpassword = _hasherService.HashPassword(request.Password);

        var user = _mapper.Map<User>(request);
        user.PasswordHash = hashedpassword;

        await _userRepository.AddUserAsync(user);

        return _mapper.Map<CreateUserResponse>(user);
    }

    public async Task DeleteUserAsync(int userId)
    {
        var user = await _userRepository.GetUserByIdAsync(userId);

        if (user != null)
            await _userRepository.DeleteUserAsync(user.Id);
    }

    public async Task<(IEnumerable<GetAllUsersResponse> Users, int TotalCount)> GetAllUsersAsync(int page, int pageSize)
    {
        var (users, totalCount) = await _userRepository.GetAllUsersAsync(page, pageSize);

        var usersDto = _mapper.Map<IEnumerable<GetAllUsersResponse>>(users);

        return (usersDto, totalCount);
    }

    public async Task<GetUserByIdResponse> GetUserByIdAsync(int userId)
    {
        var user = await _userRepository.GetUserByIdAsync(userId);

        if (user == null)
            throw new NotFoundException("User Not Found.");

        var userDto = _mapper.Map<GetUserByIdResponse>(user);
        return userDto;
    }
}