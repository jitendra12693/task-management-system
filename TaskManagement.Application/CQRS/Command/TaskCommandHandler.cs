using MediatR;
using TaskManagement.Application.Dtos;
using TaskManagement.Domain.Entities;
using TaskManagement.Domain.IRepository;

namespace TaskManagement.Application.CQRS.Command
{
    public class CreateTaskCommandHandler(ITaskRepository _taskRepository) : IRequestHandler<CreateTaskCommand, Response>
    {
        public async Task<Response> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        {
            var task =new TaskItem
            {
                Title = request.Title,
                Description = request.Description,
                Priority = request.Priority,
                Status = Domain.Entities.TaskStatus.TODO,
                AssigneeId = request.AssigneeId,
                CreatorId = request.UserId,
                CreatedAt = DateTime.UtcNow
            };

            await _taskRepository.AddAsync(task);

            return new Response
            {
                StatusCode = 200,
                StatusMessage = "Task created successfully",
                Result = new TaskResponse(
                    task.Id,
                    task.Title,
                    task.Status.ToString(),
                    task.Priority,
                    task.AssigneeId.HasValue ? task?.Assignee?.Username! : "Unassigned",
                    task?.Creator?.Username!,
                    task?.AssigneeId!,
                    task?.Description!
                )
            };
        }
    }
}
