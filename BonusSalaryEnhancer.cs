namespace EmployeeManagementSystem.Decorator
{
    public class BonusSalaryEnhancer
        : ISalaryEnhancer
    {
        public double Enhance(double baseSalary)
        {
            ISalaryComponent salary =
                new BaseSalary(baseSalary);

            salary = new BonusDecorator(salary);

            return salary.GetSalary();
        }
    }
}
