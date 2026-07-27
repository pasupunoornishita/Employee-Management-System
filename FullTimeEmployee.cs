namespace EmployeeManagementSystem.Models
{
    public class FullTimeEmployee : Employee
    {
        public double Bonus { get; set; }

        public FullTimeEmployee()
        {
            EmployeeType = "FullTime";
            Bonus = 5000;
        }
    }
}