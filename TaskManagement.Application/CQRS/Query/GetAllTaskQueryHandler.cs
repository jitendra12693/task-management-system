using MediatR;
using TaskManagement.Application.Dtos;
using TaskManagement.Domain.IRepository;

namespace TaskManagement.Application.CQRS.Query
{
    public class GetAllTaskQueryHandler(ITaskRepository task) : IRequestHandler<GetAllTaskQueryCommand, Response>
    {
        public async Task<Response> Handle(GetAllTaskQueryCommand request, CancellationToken cancellationToken)
        {
            var taskList = await task.GetTasksAsync(request?.status, request.assignee);
            var tasks = taskList.OrderByDescending(x => x.CreatedAt).Select(t => new TaskResponse(
                t.Id,
                t.Title,
                t.Status.ToString(),
                t.Priority,
                t.Assignee?.Username ?? "Unassigned",
                t.Creator!.Username,
                t.AssigneeId,
                t.Description
                )).ToList();
            return new Response
            {
                StatusCode = 200,
                StatusMessage = "Tasks retrieved successfully",
                Result = tasks
            };
        }
    }
}
