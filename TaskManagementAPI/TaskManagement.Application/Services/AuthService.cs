using AutoMapper;
using FluentValidation;
using TaskManagement.Application.Dtos.Requests.UserResquests;
using TaskManagement.Application.Dtos.Responses.UserResponses;
using TaskManagement.Application.Exceptions;
using TaskManagement.Application.Services.Interfaces;
using TaskManagement.Domain.Entities;
using TaskManagement.Infra.Repositories.Interfaces;

namespace TaskManagement.Application.Services;

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly IJwtService _jwtService;
    private readonly IHasherService _hasherService;
    private readonly IValidator<LoginUserRequest> _loginUserValidator;
    public AuthService(
        IUserRepository userRepository,
        IMapper mapper,
        IHasherService hasherService,
        IJwtService jwtService,
        IValidator<LoginUserRequest> loginUserValidator)
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _hasherService = hasherService;
        _jwtService = jwtService;
        _loginUserValidator = loginUserValidator;
    }

    public async Task<LoginUserResponse> AuthenticateAsync(LoginUserRequest request)
    {
        var validationResult = await _loginUserValidator.ValidateAsync(request);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var user = await _userRepository.GetUserByEmailAsync(request.Email);

        if (user == null || !_hasherService.VerifyPassword(request.Password, user.PasswordHash))
            throw new UnauthorizedException("Invalid credentials.");

        var token = _jwtService.GenerateToken(user);

        var response = _mapper.Map<LoginUserResponse>(user);
        response.Token = token;

        return response;
    }
}