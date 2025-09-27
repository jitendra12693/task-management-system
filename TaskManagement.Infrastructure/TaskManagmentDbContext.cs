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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Users
            var admin = new User
            {
                Username = "admin",
                Email = "admin@example.com",
                Role = Role.ADMIN,
                CreatedAt = DateTime.UtcNow
            };
            admin.SetPassword(BCrypt.Net.BCrypt.HashPassword("Admin@123"));

            var user = new User
            {
                Username = "user",
                Email = "user@example.com",
                Role = Role.USER,
                CreatedAt = DateTime.UtcNow
            };
            user.SetPassword(BCrypt.Net.BCrypt.HashPassword("User@123"));

            modelBuilder.Entity<User>().HasData(admin, user);

            // Tasks
            var tasks = new List<TaskItem>
            {
                new TaskItem { Title = "Setup project repo", Description = "Initialize git and CI pipeline", Status = TaskStatus.TODO, Priority = "HIGH", CreatorId = admin.Id, AssigneeId = user.Id },
                new TaskItem { Title = "Design DB schema", Description = "ER diagram for tasks & users", Status = TaskStatus.IN_PROGRESS, Priority = "MEDIUM", CreatorId = admin.Id, AssigneeId = admin.Id },
                new TaskItem { Title = "Implement login API", Description = "JWT authentication", Status = TaskStatus.DONE, Priority = "HIGH", CreatorId = admin.Id, AssigneeId = user.Id },
                new TaskItem { Title = "Frontend dashboard", Description = "Task board columns", Status = TaskStatus.TODO, Priority = "LOW", CreatorId = user.Id, AssigneeId = user.Id },
                new TaskItem { Title = "Update CI/CD", Description = "Update CI/CD pipeline", Status = TaskStatus.TODO, Priority = "HIGH", CreatorId = admin.Id, AssigneeId = user.Id },
                new TaskItem { Title = "DB Validation", Description = "Validate all user Data", Status = TaskStatus.IN_PROGRESS, Priority = "MEDIUM", CreatorId = admin.Id, AssigneeId = admin.Id },
                new TaskItem { Title = "Auth Validation", Description = "JWT authentication validation", Status = TaskStatus.DONE, Priority = "HIGH", CreatorId = admin.Id, AssigneeId = user.Id },
                new TaskItem { Title = "Task Board", Description = "Task board columns", Status = TaskStatus.TODO, Priority = "LOW", CreatorId = user.Id, AssigneeId = user.Id }
            };

            modelBuilder.Entity<TaskItem>().HasData(tasks);
        }
    }
}
