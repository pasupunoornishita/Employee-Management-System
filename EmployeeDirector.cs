using EmployeeManagementSystem.Factory;
using EmployeeManagementSystem.Models;

namespace EmployeeManagementSystem.Builder
{
    public class EmployeeDirector
    {
        private readonly IEmployeeFactory _factory;

        public EmployeeDirector(IEmployeeFactory factory)
        {
            _factory = factory;
        }

        public Employee CreateEmployee(
            string name,
            int departmentId,
            double salary,
            string employeeType)
        {
            var employee =
                _factory.Create(employeeType);

            return new EmployeeBuilder(employee)
                .SetName(name)
                .SetDepartmentId(departmentId)
                .SetSalary(salary)
                .SetEmployeeType(employeeType)
                .Build();
        }
    }
}
