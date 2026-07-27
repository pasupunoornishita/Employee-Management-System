using EmployeeManagementSystem.Models;

namespace EmployeeManagementSystem.Builder
{
    public class EmployeeBuilder
        : IEmployeeBuilder
    {
        private readonly Employee _employee;

        public EmployeeBuilder(Employee employee)
        {
            _employee = employee;
        }

        public IEmployeeBuilder SetName(string name)
        {
            _employee.Name = name;
            return this;
        }

        public IEmployeeBuilder SetDepartmentId(
            int departmentId)
        {
            _employee.DepartmentId = departmentId;
            return this;
        }

        public IEmployeeBuilder SetSalary(double salary)
        {
            _employee.Salary = salary;
            return this;
        }

        public IEmployeeBuilder SetEmployeeType(
            string employeeType)
        {
            _employee.EmployeeType = employeeType;
            return this;
        }

        public Employee Build()
        {
            return _employee;
        }
    }
}
