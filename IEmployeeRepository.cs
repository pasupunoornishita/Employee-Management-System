using EmployeeManagementSystem.Models;

namespace EmployeeManagementSystem.Repository
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAll();
        Employee? GetById(int id);
        void Add(Employee employee);
        void Update(Employee employee);
        void Delete(int id);
        void Save();
    }
}