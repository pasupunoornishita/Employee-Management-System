namespace EmployeeManagementSystem.Adapter
{
    public interface IPayrollService
    {
        void ProcessSalary(
            string employeeName,
            double salary);
    }
}