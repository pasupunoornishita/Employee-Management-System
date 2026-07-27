using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementSystem.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        public double Salary { get; set; }

        public string EmployeeType { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Department")]
        public int DepartmentId { get; set; }

        public Department? Department { get; set; }
    }
}
