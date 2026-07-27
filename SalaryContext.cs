namespace EmployeeManagementSystem.Strategy
{
    public class SalaryContext
    {
        private ISalaryStrategy _strategy;

        public SalaryContext(
            ISalaryStrategy strategy)
        {
            _strategy = strategy;
        }

        public double Calculate(
            double salary)
        {
            return _strategy
                    .CalculateSalary(salary);
        }
    }
}