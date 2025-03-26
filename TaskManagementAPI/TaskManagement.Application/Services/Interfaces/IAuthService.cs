using TaskManagement.Application.Dtos.Requests.UserResquests;
using TaskManagement.Application.Dtos.Responses.UserResponses;

namespace TaskManagement.Application.Services.Interfaces;

public interface IAuthService
{
    Task<LoginUserResponse> AuthenticateAsync(LoginUserRequest request);
}