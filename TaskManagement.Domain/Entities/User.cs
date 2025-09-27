
using System.ComponentModel.DataAnnotations;

namespace TaskManagement.Domain.Entities
{
    public class User
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Username { get;  set; } = string.Empty;
        public string Email { get;  set; } = string.Empty;
        public string PasswordHash { get;  set; } = string.Empty;
        public Role Role { get;  set; } = Role.USER;
        public DateTime CreatedAt { get;  set; } = DateTime.UtcNow;

        public void SetPassword(string hash) => PasswordHash = hash;
    }
}
