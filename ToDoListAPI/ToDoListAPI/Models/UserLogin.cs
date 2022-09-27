using System.ComponentModel.DataAnnotations;

namespace ToDoListAPI.Models
{
    public class UserLogin
    {
        [Required(ErrorMessage = "Username is required")]
        [MaxLength(20)]
        public string Username { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [MaxLength(20)]
        public string Password { get; set; }
    }
}
