using Microsoft.EntityFrameworkCore.Migrations;
#nullable disable
namespace UniversityDbApp.Migrations;
public partial class InitialDb : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(name: "Departments", columns: table => new
        {
            Id = table.Column<int>(type: "int", nullable: false).Annotation("SqlServer:Identity", "1, 1"),
            Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
        }, constraints: table => table.PrimaryKey("PK_Departments", x => x.Id));
        migrationBuilder.CreateTable(name: "Teachers", columns: table => new
        {
            Id = table.Column<int>(type: "int", nullable: false).Annotation("SqlServer:Identity", "1, 1"),
            FullName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
            DepartmentId = table.Column<int>(type: "int", nullable: false)
        }, constraints: table =>
        {
            table.PrimaryKey("PK_Teachers", x => x.Id);
            table.ForeignKey(name: "FK_Teachers_Departments_DepartmentId", column: x => x.DepartmentId,
                principalTable: "Departments", principalColumn: "Id", onDelete: ReferentialAction.Restrict);
        });
        migrationBuilder.CreateIndex(name: "IX_Teachers_DepartmentId", table: "Teachers", column: "DepartmentId");
        migrationBuilder.InsertData(table: "Departments", columns: new[] { "Id", "Name" },
            values: new object[,] { { 1, "Ақпараттық технологиялар" }, { 2, "Математика" } });
        migrationBuilder.InsertData(table: "Teachers", columns: new[] { "Id", "FullName", "DepartmentId" },
            values: new object[,] { { 1, "Айдана Серікқызы", 1 }, { 2, "Ерлан Асқарұлы", 1 }, { 3, "Мадина Болатқызы", 2 } });
    }
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(name: "Teachers");
        migrationBuilder.DropTable(name: "Departments");
    }
}
