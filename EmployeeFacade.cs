using EmployeeManagementSystem.Adapter;
using EmployeeManagementSystem.Builder;
using EmployeeManagementSystem.Decorator;
using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.Observer;
using EmployeeManagementSystem.Repository;
using EmployeeManagementSystem.Strategy;

namespace EmployeeManagementSystem.Facade
{
    public class EmployeeFacade : IEmployeeFacade
    {
        private readonly IEmployeeRepository _repository;
        private readonly EmployeeDirector _director;
        private readonly ISalaryStrategyFactory _strategyFactory;
        private readonly ISalaryEnhancer _salaryEnhancer;
        private readonly INotificationService _notificationService;
        private readonly IPayrollService _payrollService;
        private readonly ILogger<EmployeeFacade> _logger;

        public EmployeeFacade(
            IEmployeeRepository repository,
            EmployeeDirector director,
            ISalaryStrategyFactory strategyFactory,
            ISalaryEnhancer salaryEnhancer,
            INotificationService notificationService,
            IPayrollService payrollService,
            ILogger<EmployeeFacade> logger)
        {
            _repository = repository;
            _director = director;
            _strategyFactory = strategyFactory;
            _salaryEnhancer = salaryEnhancer;
            _notificationService = notificationService;
            _payrollService = payrollService;
            _logger = logger;
        }

        public IEnumerable<Employee> GetAll()
        {
            return _repository.GetAll();
        }

        public Employee? GetById(int id)
        {
            return _repository.GetById(id);
        }

        public void AddEmployee(
            string name,
            int departmentId,
            double salary,
            string employeeType)
        {
            var employee = _director.CreateEmployee(
                name, departmentId, salary, employeeType);

            var strategy =
                _strategyFactory.Create(employeeType);

            employee.Salary = new SalaryContext(strategy)
                .Calculate(employee.Salary);

            employee.Salary =
                _salaryEnhancer.Enhance(employee.Salary);

            _repository.Add(employee);
            _repository.Save();

            _notificationService.NotifyEmployeeAdded(
                employee.Name);

            _payrollService.ProcessSalary(
                employee.Name,
                employee.Salary);

            _logger.LogInformation(
                "Employee added: {Name}, Salary: {Salary}",
                employee.Name,
                employee.Salary);
        }

        public void UpdateEmployee(Employee employee)
        {
            _repository.Update(employee);
            _repository.Save();

            _logger.LogInformation(
                "Employee updated: {Name}",
                employee.Name);
        }

        public void DeleteEmployee(int id)
        {
            _repository.Delete(id);
            _repository.Save();

            _logger.LogInformation(
                "Employee deleted: {Id}", id);
        }
    }
}
