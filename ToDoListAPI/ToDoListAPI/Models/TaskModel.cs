using System.ComponentModel.DataAnnotations;

namespace ToDoListAPI.Models
{
    public class TaskModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Title { get; set; }
        [MaxLength(200)]
        public string Description { get; set; }
        public bool Done { get; set; } = false;
        public DateTime CreateTime { get; set; }
        public DateTime LastEditTime { get; set; }
        public DateTime DoneTime { get; set; }
    }
}
