using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.Application.Dtos.Requests.SubTasksRequests;
using TaskManagement.Application.Services.Interfaces;

namespace TaskManagement.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SubTasksController : ControllerBase
{
    private readonly ISubTaskService _subTaskService;
    public SubTasksController(ISubTaskService subTaskService)
    {
        _subTaskService = subTaskService;
    }
    [Authorize]
    [HttpPost("create-subtask")]
    public async Task<IActionResult> CreateSubTask([FromBody] CreateSubTaskRequest request)
    {
        var response = await _subTaskService.CreateSubTaskAsync(request);
        return CreatedAtAction(nameof(GetSubTaskById), new { id = response.Id }, response);
    }
    [Authorize]
    [HttpDelete("delete-subtask/{id}")]
    public async Task<IActionResult> DeleteSubTask(int id)
    {
        var subTask = await _subTaskService.GetSubTaskByIdAsync(id);

        if (subTask == null)
            return NotFound($"SubTask with ID {id} not found.");

        await _subTaskService.DeleteSubTaskAsync(id);

        return NoContent();
    }
    [Authorize]
    [HttpGet("get-subtask-by-id/{id}")]
    public async Task<IActionResult> GetSubTaskById(int id)
    {
        var response = await _subTaskService.GetSubTaskByIdAsync(id);

        if (response == null)
            return NotFound($"SubTask with ID {id} not found.");

        return Ok(response);
    }
    [Authorize]
    [HttpPut("update-subtask/{id}")]
    public async Task<IActionResult> UpdateSubTask(UpdateSubTaskRequest request, int id)
    {
        var subTask = await _subTaskService.GetSubTaskByIdAsync(id);

        if (subTask == null)
            return NotFound($"SubTask with ID {id} not found.");

        var response = await _subTaskService.UpdateSubTaskAsync(subTask.Id, request.Description);
        return Ok(response);
    }
    [Authorize]
    [HttpPatch("complete-subtask/{id}")]
    public async Task<IActionResult> CompleteSubTask(int id)
    {
        var subTask = await _subTaskService.GetSubTaskByIdAsync(id);

        if (subTask == null)
            return NotFound($"SubTask with ID {id} not found.");

        var response = await _subTaskService.CompleteSubTaskAsync(subTask.Id);
        return Ok(response);
    }
}