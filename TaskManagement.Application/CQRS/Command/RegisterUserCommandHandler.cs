using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application.Dtos;
using TaskManagement.Domain.Entities;
using TaskManagement.Domain.IRepository;

namespace TaskManagement.Application.CQRS.Command
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, Response>
    {
        private readonly IUserRepository _userRepository;
        public RegisterUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public Task<Response> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            if(_userRepository.GetByUsernameAsync(request.Email).Result != null)
            {
                throw new Exception("Username already exists");
            }

            User user = new User
            {
                Username = request.Username,
                Email = request.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password),
                Role = Role.USER,
                CreatedAt = DateTime.UtcNow
            };

            _userRepository.AddAsync(user);
            return Task.FromResult(new Response
            {
                StatusCode = 200,
                StatusMessage = "User registered successfully",
                Result = new RegisterResponse(
                user.Id,
                user.Username,
                user.Email,
                user.Role,
                user.CreatedAt)
            });
        }
    }
}
