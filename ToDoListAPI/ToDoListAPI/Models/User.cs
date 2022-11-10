using System.ComponentModel.DataAnnotations;

namespace ToDoListAPI.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string? Username { get; set; }
        public int? RoleId  { get; set; }
        public Role? Role { get; set; }
        public byte[]? PasswordHash { get; set; }
        public byte[]? PasswordSalt { get; set; }
    }
}
