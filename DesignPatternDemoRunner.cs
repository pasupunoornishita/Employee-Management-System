using EmployeeManagementSystem.Adapter;
using EmployeeManagementSystem.Builder;
using EmployeeManagementSystem.Decorator;
using EmployeeManagementSystem.Facade;
using EmployeeManagementSystem.Factory;
using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.Observer;
using EmployeeManagementSystem.Repository;
using EmployeeManagementSystem.Singleton;
using EmployeeManagementSystem.Strategy;

namespace EmployeeManagementSystem.Demo
{
    public static class DesignPatternDemoRunner
    {
        public static void Run(WebApplication app)
        {
            Console.WriteLine(
                "===== DESIGN PATTERNS TESTING =====");

            RunFactoryDemo(app);
            RunBuilderDemo(app);
            RunStrategyDemo(app);
            RunSingletonDemo();
            RunObserverDemo();
            RunAdapterDemo();
            RunDecoratorDemo();
            RunRepositoryDemo(app);
            RunFacadeDemo(app);

            Console.WriteLine("===== END =====");
        }

        private static void RunFactoryDemo(WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var factory = scope.ServiceProvider
                .GetRequiredService<IEmployeeFactory>();

            var employee = factory.Create("FullTime");
            employee.Name = "John";
            employee.DepartmentId = 1;
            employee.Salary = 50000;

            Console.WriteLine("Factory Pattern");
            Console.WriteLine($"Employee : {employee.Name}");

            var repository = scope.ServiceProvider
                .GetRequiredService<IEmployeeRepository>();

            var exists = repository.GetAll()
                .Any(e => e.Name == "John"
                       && e.DepartmentId == 1);

            if (!exists)
            {
                repository.Add(employee);
                repository.Save();
                Console.WriteLine("John inserted into database.");
            }
            else
            {
                Console.WriteLine(
                    "John already exists in database.");
            }
        }

        private static void RunBuilderDemo(WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var director = scope.ServiceProvider
                .GetRequiredService<EmployeeDirector>();

            var employee = director.CreateEmployee(
                "Alice", 2, 40000, "FullTime");

            Console.WriteLine();
            Console.WriteLine("Builder Pattern");
            Console.WriteLine($"Employee : {employee.Name}");

            var strategyFactory = scope.ServiceProvider
                .GetRequiredService<ISalaryStrategyFactory>();

            employee.Salary = new SalaryContext(
                    strategyFactory.Create(
                        employee.EmployeeType))
                .Calculate(employee.Salary);

            var repository = scope.ServiceProvider
                .GetRequiredService<IEmployeeRepository>();

            var exists = repository.GetAll()
                .Any(e => e.Name == "Alice"
                       && e.DepartmentId == 2);

            if (!exists)
            {
                repository.Add(employee);
                repository.Save();
                Console.WriteLine(
                    "Alice inserted into database.");
            }
            else
            {
                Console.WriteLine(
                    "Alice already exists in database.");
            }
        }

        private static void RunStrategyDemo(WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var repository = scope.ServiceProvider
                .GetRequiredService<IEmployeeRepository>();

            var john = repository.GetAll()
                .FirstOrDefault(e => e.Name == "John");
            var alice = repository.GetAll()
                .FirstOrDefault(e => e.Name == "Alice");

            Console.WriteLine();
            Console.WriteLine("Strategy Pattern");

            if (john != null)
                Console.WriteLine(
                    $"John's Calculated Salary : {john.Salary}");

            if (alice != null)
                Console.WriteLine(
                    $"Alice's Calculated Salary : {alice.Salary}");
        }

        private static void RunSingletonDemo()
        {
            Console.WriteLine();
            Console.WriteLine("Singleton Pattern");

            Logger.Instance.Log("Employee Added");
            Logger.Instance.Log("Demo singleton logger");
        }

        private static void RunObserverDemo()
        {
            Console.WriteLine();
            Console.WriteLine("Observer Pattern");

            INotificationService notification =
                new NotificationService();

            notification.NotifyEmployeeAdded("John");
            notification.NotifyEmployeeAdded("Alice");
        }

        private static void RunAdapterDemo()
        {
            Console.WriteLine();
            Console.WriteLine("Adapter Pattern");

            IPayrollService payroll = new PayrollAdapter();

            payroll.ProcessSalary("John", 55000);
            payroll.ProcessSalary("Alice", 45000);
        }

        private static void RunDecoratorDemo()
        {
            Console.WriteLine();
            Console.WriteLine("Decorator Pattern");

            ISalaryEnhancer enhancer =
                new BonusSalaryEnhancer();

            Console.WriteLine(
                $"Salary with Bonus : {enhancer.Enhance(50000)}");
        }

        private static void RunRepositoryDemo(WebApplication app)
        {
            Console.WriteLine();
            Console.WriteLine("Repository Pattern");

            using var scope = app.Services.CreateScope();
            var repository = scope.ServiceProvider
                .GetRequiredService<IEmployeeRepository>();

            var employees = repository.GetAll();

            Console.WriteLine(
                $"Employees Count : {employees.Count()}");

            foreach (var emp in employees)
            {
                Console.WriteLine(
                    $"{emp.Id} - {emp.Name} - {emp.Department?.Name} - {emp.Salary}");
            }
        }

        private static void RunFacadeDemo(WebApplication app)
        {
            Console.WriteLine();
            Console.WriteLine("Facade Pattern");

            using var scope = app.Services.CreateScope();
            var facade = scope.ServiceProvider
                .GetRequiredService<IEmployeeFacade>();

            var repository = scope.ServiceProvider
                .GetRequiredService<IEmployeeRepository>();

            var exists = repository.GetAll()
                .Any(e => e.Name == "David");

            if (!exists)
            {
                facade.AddEmployee(
                    "David", 3, 60000, "FullTime");

                Console.WriteLine(
                    "David added using Facade Pattern.");
            }
            else
            {
                Console.WriteLine("David already exists.");
            }
        }
    }
}
