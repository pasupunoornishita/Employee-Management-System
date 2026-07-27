using EmployeeManagementSystem.Models;

namespace EmployeeManagementSystem.Factory
{
    public interface IEmployeeFactory
    {
        Employee Create(string employeeType);
    }
}
