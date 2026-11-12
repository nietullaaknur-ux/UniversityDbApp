using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using UniversityDbApp.Data;
#nullable disable
namespace UniversityDbApp.Migrations;
[DbContext(typeof(AppDbContext))]
[Migration("20261112000100_InitialDb")]
public partial class InitialDb
{
    protected override void BuildTargetModel(ModelBuilder modelBuilder)
    {
        modelBuilder.HasAnnotation("ProductVersion", "8.0.11").HasAnnotation("Relational:MaxIdentifierLength", 128);
        SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);
        modelBuilder.Entity("UniversityDbApp.Models.Department", b =>
        {
            b.Property<int>("Id").ValueGeneratedOnAdd().HasColumnType("int");
            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));
            b.Property<string>("Name").IsRequired().HasMaxLength(100).HasColumnType("nvarchar(100)");
            b.HasKey("Id");
            b.ToTable("Departments");
            b.HasData(new { Id = 1, Name = "Ақпараттық технологиялар" }, new { Id = 2, Name = "Математика" });
        });
        modelBuilder.Entity("UniversityDbApp.Models.Teacher", b =>
        {
            b.Property<int>("Id").ValueGeneratedOnAdd().HasColumnType("int");
            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));
            b.Property<int>("DepartmentId").HasColumnType("int");
            b.Property<string>("FullName").IsRequired().HasMaxLength(150).HasColumnType("nvarchar(150)");
            b.HasKey("Id");
            b.HasIndex("DepartmentId");
            b.ToTable("Teachers");
            b.HasData(new { Id = 1, FullName = "Айдана Серікқызы", DepartmentId = 1 },
                new { Id = 2, FullName = "Ерлан Асқарұлы", DepartmentId = 1 },
                new { Id = 3, FullName = "Мадина Болатқызы", DepartmentId = 2 });
        });
        modelBuilder.Entity("UniversityDbApp.Models.Teacher", b =>
        {
            b.HasOne("UniversityDbApp.Models.Department", "Department").WithMany("Teachers")
                .HasForeignKey("DepartmentId").OnDelete(DeleteBehavior.Restrict).IsRequired();
            b.Navigation("Department");
        });
        modelBuilder.Entity("UniversityDbApp.Models.Department", b => b.Navigation("Teachers"));
    }
}
