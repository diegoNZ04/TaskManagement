using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.Application.Dtos.Requests.UserResquests;
using TaskManagement.Application.Services.Interfaces;

namespace TaskManagement.API.Controllers;

[ApiController]
[Route("api/users")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;
    public UsersController(IUserService userService)
    {
        _userService = userService;
    }
    [HttpPost("register-user")]
    public async Task<IActionResult> CreateUser([FromBody] CreateUserRequest request)
    {
        var response = await _userService.CreateUserAsync(request);
        return CreatedAtAction(nameof(GetUserById), new { id = response.Id }, response);
    }
    [Authorize]
    [HttpDelete("delete-user/{id}")]
    public async Task<IActionResult> DeleteUser(int id)
    {
        var user = await _userService.GetUserByIdAsync(id);

        if (user == null)
            return NotFound($"User with ID {id} not found.");

        await _userService.DeleteUserAsync(id);

        return NoContent();
    }
    [Authorize]
    [HttpGet("get-all-users")]
    public async Task<IActionResult> GetAllUsers([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
    {
        var (users, totalCount) = await _userService.GetAllUsersAsync(page, pageSize);

        if (!users.Any())
            return NoContent();

        var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);

        return Ok(new
        {
            users,
            pagination = new
            {
                currentPage = page,
                pageSize,
                totalItems = totalCount,
                totalPages
            }
        });
    }
    [Authorize]
    [HttpGet("get-user-by-id/{id}")]
    public async Task<IActionResult> GetUserById(int id)
    {
        var response = await _userService.GetUserByIdAsync(id);

        if (response == null)
            return NotFound($"User with ID {id} not found.");

        return Ok(response);
    }

}