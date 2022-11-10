using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DepartmentAPI.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? ProjectId { get; set; }
        public Project? Project { get; set; }
        [NotMapped]
        public ICollection<int> MembersId { get; set; }
        public ICollection<Member>? Members { get; set; }
        public ICollection<TaskModel>? Tasks { get; set; }
    }
}
