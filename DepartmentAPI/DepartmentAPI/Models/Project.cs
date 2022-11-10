using System.ComponentModel.DataAnnotations;

namespace DepartmentAPI.Models
{
    public class Project
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public ICollection<Department>? Departments { get; set; }
    }
}
