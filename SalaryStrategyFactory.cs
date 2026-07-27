namespace EmployeeManagementSystem.Strategy
{
    public class SalaryStrategyFactory
        : ISalaryStrategyFactory
    {
        private readonly Dictionary<string, ISalaryStrategy>
            _strategies = new(StringComparer.OrdinalIgnoreCase)
        {
            ["FullTime"] = new FullTimeSalaryStrategy(),
            ["Contract"] = new ContractSalaryStrategy()
        };

        public ISalaryStrategy Create(string employeeType)
        {
            if (_strategies.TryGetValue(
                    employeeType, out var strategy))
            {
                return strategy;
            }

            throw new ArgumentException(
                $"Unknown employee type: {employeeType}");
        }
    }
}
