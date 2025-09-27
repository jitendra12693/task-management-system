using Microsoft.EntityFrameworkCore;
using TaskManagement.Domain.Entities;
using TaskManagement.Domain.IRepository;
using TaskStatus = TaskManagement.Domain.Entities.TaskStatus;

namespace TaskManagement.Infrastructure.Repository
{
    public class TaskRepository : ITaskRepository
    {
        private readonly TaskManagementAppDbContext _ctx;
        public TaskRepository(TaskManagementAppDbContext ctx) => _ctx = ctx;

        public async Task<IEnumerable<TaskItem>> GetTasksAsync(string? status, Guid? assigneeId)
        {
            var query = _ctx.Tasks
                .Include(t => t.Assignee)
                .Include(t => t.Creator)
                .AsNoTracking()
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(status) && Enum.TryParse<TaskStatus>(status, true, out var parsedStatus))
            {
                query = query.Where(t => t.Status == parsedStatus);
            }

            if (assigneeId.HasValue)
            {
                query = query.Where(t => t.AssigneeId == assigneeId.Value);
            }

            return await query.ToListAsync();
        }

        public async Task<TaskItem?> GetByIdAsync(Guid id) => await _ctx.Tasks.FindAsync(id);

        public async Task AddAsync(TaskItem task)
        {
            _ctx.Tasks.Add(task);
            await _ctx.SaveChangesAsync();
        }

        public async Task UpdateAsync(TaskItem task)
        {
            _ctx.Tasks.Update(task);
            await _ctx.SaveChangesAsync();
        }

        public async Task DeleteAsync(TaskItem task)
        {
            _ctx.Tasks.Remove(task);
            await _ctx.SaveChangesAsync();
        }
    }
}
