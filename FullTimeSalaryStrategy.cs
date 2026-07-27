namespace EmployeeManagementSystem.Strategy
{
    public class FullTimeSalaryStrategy
        : ISalaryStrategy
    {
        public double CalculateSalary(
            double baseSalary)
        {
            return baseSalary + 5000;
        }
    }
}