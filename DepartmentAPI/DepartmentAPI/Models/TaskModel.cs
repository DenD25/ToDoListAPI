using System.ComponentModel.DataAnnotations;

namespace DepartmentAPI.Models
{
    public class TaskModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int DepatmentId { get; set; }
        public Department? Department { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
