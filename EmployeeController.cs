using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using EmployeeManagementSystem.Facade;
using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.Repository;

namespace EmployeeManagementSystem.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeFacade _employeeFacade;
        private readonly IDepartmentRepository _departmentRepository;

        public EmployeeController(
            IEmployeeFacade employeeFacade,
            IDepartmentRepository departmentRepository)
        {
            _employeeFacade = employeeFacade;
            _departmentRepository = departmentRepository;
        }

        public IActionResult Index()
        {
            return View(_employeeFacade.GetAll());
        }

        public IActionResult Details(int id)
        {
            var employee = _employeeFacade.GetById(id);

            if (employee == null)
                return NotFound();

            return View(employee);
        }

        public IActionResult Create()
        {
            PopulateDepartments();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _employeeFacade.AddEmployee(
                    employee.Name,
                    employee.DepartmentId,
                    employee.Salary,
                    employee.EmployeeType);

                return RedirectToAction(nameof(Index));
            }

            PopulateDepartments(employee.DepartmentId);
            return View(employee);
        }

        public IActionResult Edit(int id)
        {
            var employee = _employeeFacade.GetById(id);

            if (employee == null)
                return NotFound();

            PopulateDepartments(employee.DepartmentId);
            return View(employee);
        }

        [HttpPost]
        public IActionResult Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _employeeFacade.UpdateEmployee(employee);

                return RedirectToAction(nameof(Index));
            }

            PopulateDepartments(employee.DepartmentId);
            return View(employee);
        }

        public IActionResult Delete(int id)
        {
            var employee = _employeeFacade.GetById(id);

            if (employee == null)
                return NotFound();

            return View(employee);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _employeeFacade.DeleteEmployee(id);

            return RedirectToAction(nameof(Index));
        }

        private void PopulateDepartments(
            int? selectedId = null)
        {
            ViewBag.Departments = new SelectList(
                _departmentRepository.GetAll(),
                "Id",
                "Name",
                selectedId);
        }
    }
}
