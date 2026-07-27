namespace EmployeeManagementSystem.Strategy
{
    public class ContractSalaryStrategy
        : ISalaryStrategy
    {
        public double CalculateSalary(
            double baseSalary)
        {
            return baseSalary;
        }
    }
}