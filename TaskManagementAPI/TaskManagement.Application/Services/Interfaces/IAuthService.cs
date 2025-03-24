using TaskManagement.Application.Dtos.Responses.UserResponses;

namespace TaskManagement.Application.Services.Interfaces;

public interface IAuthService
{
    Task<LoginUserResponse> AuthenticateAsync(string email, string password);
}