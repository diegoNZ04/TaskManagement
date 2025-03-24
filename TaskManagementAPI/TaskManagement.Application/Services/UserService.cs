using AutoMapper;
using FluentValidation;
using TaskManagement.Application.Dtos.Responses.UserResponses;
using TaskManagement.Application.Exceptions;
using TaskManagement.Application.Services.Interfaces;
using TaskManagement.Application.Validators.UserValidators;
using TaskManagement.Domain.Entities;
using TaskManagement.Infra.Repositories.Interfaces;

namespace TaskManagement.Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly IValidator<CreateUserValidator> _createUserValidator;
    private readonly IHasherService _hasherService;
    public UserService(IUserRepository userRepository, IMapper mapper, IValidator<CreateUserValidator> createUserValidator, IHasherService hasherService)
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _createUserValidator = createUserValidator;
        _hasherService = hasherService;
    }
    public async Task<CreateUserResponse> CreateUserAsync(string username, string email, string password)
    {
        var hashedpassword = _hasherService.HashPassword(password);

        var user = _mapper.Map<User>(new CreateUserResponse
        {
            Username = username,
            Email = email,
            Password = hashedpassword
        });

        var validationContext = new ValidationContext<User>(user);
        var validationResult = await _createUserValidator.ValidateAsync(validationContext);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

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
            throw new NotFoundException("User Not Found.");

        var userDto = _mapper.Map<GetUserByIdResponse>(user);
        return userDto;
    }
}