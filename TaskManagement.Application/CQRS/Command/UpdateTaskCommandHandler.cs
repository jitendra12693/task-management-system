using MediatR;
using TaskManagement.Application.Dtos;
using TaskManagement.Domain.IRepository;

namespace TaskManagement.Application.CQRS.Command
{
    public class UpdateTaskCommandHandler(ITaskRepository taskRepository) : IRequestHandler<UpdateTaskCommand, Response>
    {
        public async Task<Response> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
        {
            if(request.Id == Guid.Empty)
            {
                return new Response
                {
                    StatusCode = 400,
                    StatusMessage = "Invalid task ID."
                };
            }
            var existingTask = await taskRepository.GetByIdAsync(request.Id);
            if (existingTask == null)
            {
                return new Response
                {
                    StatusCode = 404,
                    StatusMessage = "Task not found."
                };
            }
            existingTask.Title = request.Title ?? existingTask.Title;
            existingTask.Description = request.Description ?? existingTask.Description;
            existingTask.Priority = request.Priority ?? existingTask.Priority;
            existingTask.Status = request.Status ?? existingTask.Status;
            existingTask.AssigneeId = request.AssigneeId ?? existingTask.AssigneeId;
            existingTask.UpdatedAt = DateTime.UtcNow;
            await taskRepository.UpdateAsync(existingTask);

            return new Response
            {
                StatusCode = 200,
                StatusMessage = "Task updated successfully.",
                Result = new TaskResponse(
                    existingTask.Id,
                    existingTask.Title,
                    existingTask.Status.ToString(),
                    existingTask.Priority,
                    existingTask.AssigneeId.HasValue ? existingTask?.Assignee?.Username! : "Unassigned",
                    existingTask?.Creator?.Username!,
                    existingTask?.AssigneeId,
                    existingTask?.Description!
                )
            };
        }
    }
}
