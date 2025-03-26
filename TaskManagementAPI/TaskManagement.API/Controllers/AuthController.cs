using Microsoft.AspNetCore.Mvc;
using TaskManagement.Application.Dtos.Requests.UserResquests;
using TaskManagement.Application.Services.Interfaces;

namespace TaskManagement.API.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;
    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }
    [HttpPost("login-user")]
    public async Task<IActionResult> LoginUser([FromBody] LoginUserRequest request)
    {
        var response = await _authService.AuthenticateAsync(request);
        return Ok(response);
    }
}