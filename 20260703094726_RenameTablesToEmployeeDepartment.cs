using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class RenameTablesToEmployeeDepartment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Departments_DeptId",
                table: "Employees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Departments",
                table: "Departments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employees",
                table: "Employees");

            migrationBuilder.RenameTable(
                name: "Departments",
                newName: "Department");

            migrationBuilder.RenameTable(
                name: "Employees",
                newName: "Employee");

            migrationBuilder.RenameColumn(
                name: "DeptName",
                table: "Department",
                newName: "dept_name");

            migrationBuilder.RenameColumn(
                name: "DeptId",
                table: "Department",
                newName: "dept_id");

            migrationBuilder.RenameColumn(
                name: "EmployeeType",
                table: "Employee",
                newName: "employee_type");

            migrationBuilder.RenameColumn(
                name: "DeptId",
                table: "Employee",
                newName: "dept_id");

            migrationBuilder.RenameColumn(
                name: "EmpSalary",
                table: "Employee",
                newName: "salary");

            migrationBuilder.RenameColumn(
                name: "EmpName",
                table: "Employee",
                newName: "emp_name");

            migrationBuilder.RenameColumn(
                name: "EmpId",
                table: "Employee",
                newName: "emp_id");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_DeptId",
                table: "Employee",
                newName: "IX_Employee_dept_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Department",
                table: "Department",
                column: "dept_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employee",
                table: "Employee",
                column: "emp_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Department",
                table: "Employee",
                column: "dept_id",
                principalTable: "Department",
                principalColumn: "dept_id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Department",
                table: "Employee");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Department",
                table: "Department");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employee",
                table: "Employee");

            migrationBuilder.RenameTable(
                name: "Department",
                newName: "Departments");

            migrationBuilder.RenameTable(
                name: "Employee",
                newName: "Employees");

            migrationBuilder.RenameColumn(
                name: "dept_name",
                table: "Departments",
                newName: "DeptName");

            migrationBuilder.RenameColumn(
                name: "dept_id",
                table: "Departments",
                newName: "DeptId");

            migrationBuilder.RenameColumn(
                name: "employee_type",
                table: "Employees",
                newName: "EmployeeType");

            migrationBuilder.RenameColumn(
                name: "dept_id",
                table: "Employees",
                newName: "DeptId");

            migrationBuilder.RenameColumn(
                name: "salary",
                table: "Employees",
                newName: "EmpSalary");

            migrationBuilder.RenameColumn(
                name: "emp_name",
                table: "Employees",
                newName: "EmpName");

            migrationBuilder.RenameColumn(
                name: "emp_id",
                table: "Employees",
                newName: "EmpId");

            migrationBuilder.RenameIndex(
                name: "IX_Employee_dept_id",
                table: "Employees",
                newName: "IX_Employees_DeptId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Departments",
                table: "Departments",
                column: "DeptId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employees",
                table: "Employees",
                column: "EmpId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Departments_DeptId",
                table: "Employees",
                column: "DeptId",
                principalTable: "Departments",
                principalColumn: "DeptId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
