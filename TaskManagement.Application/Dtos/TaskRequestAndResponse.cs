using MediatR;
using TaskStatus = TaskManagement.Domain.Entities.TaskStatus;

namespace TaskManagement.Application.Dtos
{
    public record CreateTaskCommand(
        string Title, 
        string Description,
        string Priority,
        Guid? AssigneeId,
        Guid UserId) :IRequest<Response>;
    public record TaskResponse(
        Guid Id, 
        string Title, 
        string Status, 
        string Priority, 
        string Assignee,
        string Creator,
        Guid? AssigneeId,
        string Description
    );

    public record GetAllTaskQueryCommand(string? status,Guid? assignee) : IRequest<Response>;

    public record UpdateTaskCommand(
        Guid Id,
        string? Title,
        string? Description,
        string? Priority,
        TaskStatus? Status,
        Guid? AssigneeId) : IRequest<Response>;

    public record DeleteTaskCommand(Guid Id) : IRequest<Response>;

    public record GetTaskByIdQuery(Guid Id) : IRequest<Response>;
}
