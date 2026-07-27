using EmployeeManagementSystem.Data;
using EmployeeManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystem.Repository
{
    public class EmployeeRepository
        : IEmployeeRepository
    {
        private readonly AppDbContext _context;

        public EmployeeRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Employee> GetAll()
        {
            return _context.Employees
                .Include(e => e.Department)
                .ToList();
        }

        public Employee? GetById(int id)
        {
            return _context.Employees
                .Include(e => e.Department)
                .FirstOrDefault(e => e.Id == id);
        }

        public void Add(Employee employee)
        {
            _context.Employees.Add(employee);
        }

        public void Update(Employee employee)
        {
            _context.Employees.Update(employee);
        }

        public void Delete(int id)
        {
            var emp = _context.Employees.Find(id);

            if (emp != null)
            {
                _context.Employees.Remove(emp);
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
