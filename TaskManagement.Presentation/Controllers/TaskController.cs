using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.Application.Dtos;

namespace TaskManagement.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TaskController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TaskController(IMediator mediator) => _mediator = mediator;

        [HttpGet("getTasks")]
        public async Task<IActionResult> Get(string? status, Guid? assignee)
        {
            var result = await _mediator.Send(new GetAllTaskQueryCommand(status!, assignee!));
            return Ok(result);
        }

        [HttpPost("createTask")]
        public async Task<IActionResult> Create(CreateTaskCommand req)
        {
            var task = await _mediator.Send(req);
            return Ok(task);
        }

        [HttpPut("updateTask/{id}")]
        public async Task<IActionResult> Update([FromRoute]Guid id, [FromBody]UpdateTaskCommand req)
        {
            var task = await _mediator.Send(req);
            return Ok(task);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var task = await _mediator.Send(new DeleteTaskCommand(id));
            return Ok(task);
        }
    }
}
