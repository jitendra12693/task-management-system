using MediatR;
using TaskManagement.Application.Dtos;
using TaskManagement.Domain.IRepository;

namespace TaskManagement.Application.CQRS.Query
{
    public class GetAllUserQueryHandler(IUserRepository userRepository) : IRequestHandler<GetAllUserQuery, Response>
    {
        public async Task<Response> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
        {
            var result = await userRepository.GetAllAsync();
            var userList = result.Select(x => new RegisterResponse(Id: x.Id,Username: x.Username,Email:x.Email,Role:x.Role, CreatedAt: x.CreatedAt));
            if (result is null)
                return new Response { StatusMessage = "No record found.", StatusCode = 404 };
            return new Response { Result = userList, StatusCode = 200, StatusMessage = "Data fetched successfully." };
        }
    }
}
