using EmployeeManagementSystem.Models;

namespace EmployeeManagementSystem.Repository
{
    public interface IDepartmentRepository
    {
        IEnumerable<Department> GetAll();
    }
}
