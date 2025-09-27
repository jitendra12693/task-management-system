using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Domain.Entities;

namespace TaskManagement.Application.Dtos
{
    public record RegisterUserCommand(
        string Username, 
        string Email, 
        string Password):IRequest<Response>;

    public record RegisterResponse(
        Guid Id,
        string Username,
        string Email,
        Role Role,
        DateTime? CreatedAt);

    public record GetAllUserQuery():IRequest<Response>;

    public record UpdateUserCommand(
        Guid Id,
        string? Username,
        string? Email,
        string? Password,
        Role? Role) : IRequest<Response>;
}
