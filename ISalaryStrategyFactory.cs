namespace EmployeeManagementSystem.Strategy
{
    public interface ISalaryStrategyFactory
    {
        ISalaryStrategy Create(string employeeType);
    }
}
