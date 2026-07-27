using System;

namespace EmployeeManagementSystem.Adapter
{
    public class ThirdPartyPayroll
    {
        public void MakePayment(
            string employee,
            double amount)
        {
            Console.WriteLine(
                $"Payment of {amount} sent to {employee}");
        }
    }
}