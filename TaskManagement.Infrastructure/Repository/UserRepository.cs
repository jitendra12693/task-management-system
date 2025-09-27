using Microsoft.EntityFrameworkCore;
using TaskManagement.Domain.Entities;
using TaskManagement.Domain.IRepository;

namespace TaskManagement.Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly TaskManagementAppDbContext _ctx;
        public UserRepository(TaskManagementAppDbContext ctx) => _ctx = ctx;

        public async Task<User?> GetByUsernameAsync(string username) =>
            await _ctx.Users.FirstOrDefaultAsync(u => u.Email == username);

        public async Task AddAsync(User user)
        {
            _ctx.Users.Add(user);
            await _ctx.SaveChangesAsync();
        }

        public async Task<IEnumerable<User>> GetAllAsync() => await _ctx.Users.ToListAsync();
    }

    
}
