using System.ComponentModel.DataAnnotations;
namespace UniversityDbApp.Models;
public class Teacher
{
    public int Id { get; set; }
    [Required, MaxLength(150)]
    public string FullName { get; set; } = string.Empty;
    public int DepartmentId { get; set; }
    public Department Department { get; set; } = null!;
}
