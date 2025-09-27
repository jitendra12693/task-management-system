using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Domain.Entities
{
    public class TaskItem
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get;  set; } = string.Empty;
        public string Description { get;  set; } = string.Empty;
        public TaskStatus Status { get;  set; } = TaskStatus.TODO;
        public Guid? AssigneeId { get; set; }
        public string Priority { get;  set; } = "MEDIUM";
        [ForeignKey("AssigneeId")]
        public User? Assignee { get;  set; }
        public Guid? CreatorId { get; set; }
        [ForeignKey("CreatorId")]
        public User? Creator { get;  set; }
        public DateTime CreatedAt { get;  set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get;  set; } = DateTime.UtcNow;

        public void UpdateStatus(TaskStatus status)
        {
            Status = status;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
