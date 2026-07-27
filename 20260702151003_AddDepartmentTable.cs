using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EmployeeManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddDepartmentTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DeptId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeptName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DeptId);
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "DeptId", "DeptName" },
                values: new object[,]
                {
                    { 1, "IT" },
                    { 2, "HR" },
                    { 3, "Finance" }
                });

            migrationBuilder.DropColumn(
                name: "Department",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "Salary",
                table: "Employees",
                newName: "EmpSalary");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Employees",
                newName: "EmpName");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Employees",
                newName: "EmpId");

            migrationBuilder.AddColumn<int>(
                name: "DeptId",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DeptId",
                table: "Employees",
                column: "DeptId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Departments_DeptId",
                table: "Employees",
                column: "DeptId",
                principalTable: "Departments",
                principalColumn: "DeptId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Departments_DeptId",
                table: "Employees");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropIndex(
                name: "IX_Employees_DeptId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "DeptId",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "EmpSalary",
                table: "Employees",
                newName: "Salary");

            migrationBuilder.RenameColumn(
                name: "EmpName",
                table: "Employees",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "EmpId",
                table: "Employees",
                newName: "Id");

            migrationBuilder.AddColumn<string>(
                name: "Department",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
