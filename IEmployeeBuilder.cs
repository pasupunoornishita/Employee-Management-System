using EmployeeManagementSystem.Models;

namespace EmployeeManagementSystem.Builder
{
    public interface IEmployeeBuilder
    {
        IEmployeeBuilder SetName(string name);

        IEmployeeBuilder SetDepartmentId(int departmentId);

        IEmployeeBuilder SetSalary(double salary);

        IEmployeeBuilder SetEmployeeType(
            string employeeType);

        Employee Build();
    }
}
