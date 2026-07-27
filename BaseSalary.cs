namespace EmployeeManagementSystem.Decorator
{
    public class BaseSalary
        : ISalaryComponent
    {
        private readonly double salary;

        public BaseSalary(double salary)
        {
            this.salary = salary;
        }

        public double GetSalary()
        {
            return salary;
        }
    }
}