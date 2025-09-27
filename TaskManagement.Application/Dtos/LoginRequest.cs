using MediatR;

namespace TaskManagement.Application.Dtos
{
    public record LoginCommand(string Username, string Password):IRequest<Response>;
}
