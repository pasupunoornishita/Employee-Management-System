namespace EmployeeManagementSystem.Models
{
    public class ContractEmployee : Employee
    {
        public int ContractMonths { get; set; }

        public ContractEmployee()
        {
            EmployeeType = "Contract";
            ContractMonths = 12;
        }
    }
}