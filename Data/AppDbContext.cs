using Microsoft.EntityFrameworkCore;
using UniversityDbApp.Models;
namespace UniversityDbApp.Data;
public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Department> Departments => Set<Department>();
    public DbSet<Teacher> Teachers => Set<Teacher>();
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Teacher>()
            .HasOne(t => t.Department).WithMany(d => d.Teachers)
            .HasForeignKey(t => t.DepartmentId).OnDelete(DeleteBehavior.Restrict);
        modelBuilder.Entity<Department>().HasData(
            new Department { Id = 1, Name = "Ақпараттық технологиялар" },
            new Department { Id = 2, Name = "Математика" });
        modelBuilder.Entity<Teacher>().HasData(
            new Teacher { Id = 1, FullName = "Айдана Серікқызы", DepartmentId = 1 },
            new Teacher { Id = 2, FullName = "Ерлан Асқарұлы", DepartmentId = 1 },
            new Teacher { Id = 3, FullName = "Мадина Болатқызы", DepartmentId = 2 });
    }
}
