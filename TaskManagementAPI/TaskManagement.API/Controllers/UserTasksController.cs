using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.Application.Dtos.Requests;
using TaskManagement.Application.Dtos.Requests.UserTasksRequests;
using TaskManagement.Application.Services.Interfaces;

namespace TaskManagement.API.Controllers;

[ApiController]
[Route("api/tasks")]
public class UserTasksController : ControllerBase
{
    private readonly IUserTaskService _taskService;
    public UserTasksController(IUserTaskService taskService)
    {
        _taskService = taskService;
    }
    [Authorize]
    [HttpPost("create-task")]
    public async Task<IActionResult> CreateTask([FromBody] CreateTaskRequest request)
    {
        var response = await _taskService.CreateTaskAsync(request.Title, request.Description, request.UserId, request.Priority);
        return CreatedAtAction(nameof(GetTaskById), new { id = response.Id }, response);
    }
    [Authorize]
    [HttpDelete("delete-task/{id}")]
    public async Task<IActionResult> DeleteTask(int id)
    {
        var task = await _taskService.GetTaskByIdAsync(id);

        if (task == null)
            return NotFound($"Task with ID {id} not found.");

        await _taskService.DeleteTaskAsync(id);

        return NoContent();
    }
    [Authorize]
    [HttpGet("get-all-tasks")]
    public async Task<IActionResult> GetAllTasks([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
    {
        var (tasks, totalCount) = await _taskService.GetAllTasksAsync(page, pageSize);

        if (!tasks.Any())
            return NoContent();

        var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);

        return Ok(new
        {
            tasks,
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
    [HttpGet("get-task-by-id/{id}")]
    public async Task<IActionResult> GetTaskById(int id)
    {
        var response = await _taskService.GetTaskByIdAsync(id);

        if (response == null)
            return NotFound($"Task with ID {id} not found.");

        return Ok(response);
    }
    [Authorize]
    [HttpPut("update-task/{id}")]
    public async Task<IActionResult> UpdateTask(UpdateTaskRequest request, int id)
    {
        var task = await _taskService.GetTaskByIdAsync(id);

        if (task == null)
            return NotFound($"Task with ID {id} not found.");

        var response = await _taskService.UpdateTaskAsync(task.Id, request.Title, request.Description, request.Priority);
        return Ok(response);
    }
    [Authorize]
    [HttpPatch("complete-task/{id}")]
    public async Task<IActionResult> CompleteTask(int id)
    {
        var task = await _taskService.GetTaskByIdAsync(id);

        if (task == null)
            return NotFound($"Task with ID {id} not found.");

        var response = await _taskService.CompleteTaskAsync(task.Id);
        return Ok(response);
    }
}