using Microsoft.EntityFrameworkCore;
using UniversityDbApp.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
var app = builder.Build();
app.UseDefaultFiles();
app.UseStaticFiles();
app.MapGet("/api/departments", async (AppDbContext db) =>
    await db.Departments.AsNoTracking().OrderBy(d => d.Id)
        .Select(d => new { d.Id, d.Name, TeacherCount = d.Teachers.Count }).ToListAsync());
app.MapGet("/api/teachers", async (AppDbContext db) =>
    await db.Teachers.AsNoTracking().OrderBy(t => t.Id)
        .Select(t => new { t.Id, t.FullName, t.DepartmentId, Department = t.Department.Name }).ToListAsync());
app.Run();
