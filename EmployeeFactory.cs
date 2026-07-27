using EmployeeManagementSystem.Models;

namespace EmployeeManagementSystem.Factory
{
    public class EmployeeFactory : IEmployeeFactory
    {
        private readonly Dictionary<string, Func<Employee>>
            _creators = new(StringComparer.OrdinalIgnoreCase)
        {
            ["FullTime"] = () => new FullTimeEmployee(),
            ["Contract"] = () => new ContractEmployee()
        };

        public Employee Create(string employeeType)
        {
            if (_creators.TryGetValue(
                    employeeType, out var create))
            {
                return create();
            }

            throw new ArgumentException(
                $"Invalid employee type: {employeeType}");
        }
    }
}
