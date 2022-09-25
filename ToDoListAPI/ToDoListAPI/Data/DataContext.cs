using Microsoft.EntityFrameworkCore;
using ToDoListAPI.Models;

namespace ToDoListAPI.Data
{
    public class DataContext : DbContext
    {
        public DbSet<TaskModel> Tasks { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        {

        }
    }
}
