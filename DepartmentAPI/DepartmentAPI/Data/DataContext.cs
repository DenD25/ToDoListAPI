using DepartmentAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DepartmentAPI.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Member> Members { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<TaskModel> Tasks { get; set; }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Project>()
                .HasMany(t => t.Departments)
                .WithOne(t => t.Project)
                .HasForeignKey(t => t.ProjectId)
                .HasPrincipalKey(t => t.Id);

            modelBuilder
                .Entity<Department>()
                .HasMany(t => t.Members)
                .WithMany(t => t.Departments);

            modelBuilder
                .Entity<Department>()
                .HasMany(t => t.Tasks)
                .WithOne(t => t.Department)
                .HasForeignKey(t => t.DepatmentId)
                .HasPrincipalKey(t => t.Id);
                
        }
    }
}
