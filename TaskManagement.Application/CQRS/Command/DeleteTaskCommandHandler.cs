using MediatR;
using TaskManagement.Application.Dtos;
using TaskManagement.Domain.IRepository;

namespace TaskManagement.Application.CQRS.Command
{
    public class DeleteTaskCommandHandler(ITaskRepository taskRepository) : IRequestHandler<DeleteTaskCommand, Response>
    {
        public async Task<Response> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                return new Response
                {
                    StatusCode = 400,
                    StatusMessage = "Invalid request",
                    Result = null
                };
            }
            if (request.Id == Guid.Empty)
            {
                return new Response
                {
                    StatusCode = 400,
                    StatusMessage = "Invalid task ID",
                    Result = null
                };
            }
            var existingTask = await taskRepository.GetByIdAsync(request.Id);
            if (existingTask == null)
            {
                return new Response
                {
                    StatusCode = 404,
                    StatusMessage = "Task not found",
                    Result = null
                };
            }
            await taskRepository.DeleteAsync(existingTask);
            return new Response
            {
                StatusCode = 200,
                StatusMessage = "Task deleted successfully",
                Result = null
            };
        }
    }
}
