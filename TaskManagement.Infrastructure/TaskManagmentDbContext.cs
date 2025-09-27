using Microsoft.EntityFrameworkCore;
using TaskManagement.Domain.Entities;
using TaskStatus = TaskManagement.Domain.Entities.TaskStatus;

namespace TaskManagement.Infrastructure
{
    public class TaskManagementAppDbContext : DbContext
    {
        public DbSet<User> Users => Set<User>();
        public DbSet<TaskItem> Tasks => Set<TaskItem>();
        public TaskManagementAppDbContext(DbContextOptions<TaskManagementAppDbContext> options) : base(options) { }

    }
}
