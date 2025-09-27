using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TaskManagement.Application.Dtos;
using TaskManagement.Domain.IRepository;

namespace TaskManagement.Application.CQRS.Command
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, Response>
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;
        public LoginCommandHandler(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }
        public async Task<Response> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByUsernameAsync(request.Username);
            if (user == null) return new Response { StatusCode = 401, StatusMessage = "Unauthorized" };

            bool verified = BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash);
            if (!verified) new Response { StatusCode = 401, StatusMessage = "Unauthorized" };

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration.GetSection("Authentication:Key").Value!);
            var securityKey = new SymmetricSecurityKey(key);
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                new Claim(ClaimTypes.Email,user.Email),
                new Claim(ClaimTypes.Name,user.Username),
                new Claim(ClaimTypes.Role, user.Role.ToString()!)
            };
            
            var token = new JwtSecurityToken(
                issuer: _configuration.GetSection("Authentication:Issuer").Value,
                audience: _configuration.GetSection("Authentication:Audience").Value,
                claims: claims,
                expires: DateTime.Now.AddHours(3),
                signingCredentials: credentials
            );
            return new Response
            {
                StatusCode = 200,
                StatusMessage = "Success",
                Result = new JwtSecurityTokenHandler().WriteToken(token)
            };
        }
    }
}
