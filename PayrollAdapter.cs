namespace EmployeeManagementSystem.Adapter
{
    public class PayrollAdapter
        : IPayrollService
    {
        private readonly ThirdPartyPayroll
            _thirdPartyPayroll;

        public PayrollAdapter()
        {
            _thirdPartyPayroll =
                new ThirdPartyPayroll();
        }

        public void ProcessSalary(
            string employeeName,
            double salary)
        {
            _thirdPartyPayroll.MakePayment(
                employeeName,
                salary);
        }
    }
}