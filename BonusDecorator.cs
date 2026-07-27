namespace EmployeeManagementSystem.Decorator
{
    public class BonusDecorator
        : ISalaryComponent
    {
        private readonly ISalaryComponent
            _salaryComponent;

        public BonusDecorator(
            ISalaryComponent salaryComponent)
        {
            _salaryComponent =
                salaryComponent;
        }

        public double GetSalary()
        {
            return _salaryComponent
                    .GetSalary() + 5000;
        }
    }
}