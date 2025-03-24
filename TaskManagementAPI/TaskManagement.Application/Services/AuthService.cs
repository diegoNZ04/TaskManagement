using AutoMapper;
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
    public AuthService(IUserRepository userRepository, IMapper mapper, IHasherService hasherService, IJwtService jwtService)
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _hasherService = hasherService;
        _jwtService = jwtService;
    }

    public async Task<LoginUserResponse> AuthenticateAsync(string email, string password)
    {
        var user = await _userRepository.GetUserByEmailAsync(email);

        if (user == null || !_hasherService.VerifyPassword(password, user.PasswordHash))
            throw new UnauthorizedException("Invalid credentials.");

        var token = _jwtService.GenerateToken(user);

        var loginReq = _mapper.Map<User>(new LoginUserResponse
        {
            Email = email,
            Password = password,
            Token = token
        });

        return _mapper.Map<LoginUserResponse>(loginReq);
    }
}