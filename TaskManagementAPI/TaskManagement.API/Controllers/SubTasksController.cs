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
    [HttpPost("create-subtask")]
    public async Task<IActionResult> CreateSubTask([FromBody] CreateSubTaskRequest request)
    {
        var response = await _subTaskService.CreateSubTaskAsync(request.Description, request.UserTaskId);
        return CreatedAtAction(nameof(GetSubTaskById), new { id = response.Id }, response);
    }
    [HttpDelete("delete-subtask/{id}")]
    public async Task<IActionResult> DeleteSubTask(int id)
    {
        var subTask = await _subTaskService.GetSubTaskByIdAsync(id);

        if (subTask == null)
            return NotFound($"SubTask with ID {id} not found.");

        await _subTaskService.DeleteSubTaskAsync(id);

        return NoContent();
    }
    [HttpGet("get-subtask-by-id/{id}")]
    public async Task<IActionResult> GetSubTaskById(int id)
    {
        var response = await _subTaskService.GetSubTaskByIdAsync(id);

        if (response == null)
            return NotFound($"SubTask with ID {id} not found.");

        return Ok(response);
    }
    [HttpPut("update-subtask/{id}")]
    public async Task<IActionResult> UpdateSubTask(UpdateSubTaskRequest request, int id)
    {
        var subTask = await _subTaskService.GetSubTaskByIdAsync(id);

        if (subTask == null)
            return NotFound($"SubTask with ID {id} not found.");

        var response = await _subTaskService.UpdateSubTaskAsync(subTask.Id, request.Description);
        return Ok(response);
    }
    [HttpPatch("{id}/complete-subtask")]
    public async Task<IActionResult> CompleteSubTask(int id)
    {
        var subTask = await _subTaskService.GetSubTaskByIdAsync(id);

        if (subTask == null)
            return NotFound($"SubTask with ID {id} not found.");

        var response = await _subTaskService.CompleteSubTaskAsync(subTask.Id);
        return Ok(response);
    }
}