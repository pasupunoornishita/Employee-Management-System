using EmployeeManagementSystem.Models;

namespace EmployeeManagementSystem.Facade
{
    public interface IEmployeeFacade
    {
        IEnumerable<Employee> GetAll();
        Employee? GetById(int id);
        void AddEmployee(
            string name,
            int departmentId,
            double salary,
            string employeeType);
        void UpdateEmployee(Employee employee);
        void DeleteEmployee(int id);
    }
}
