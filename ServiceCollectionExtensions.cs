using EmployeeManagementSystem.Adapter;
using EmployeeManagementSystem.Builder;
using EmployeeManagementSystem.Data;
using EmployeeManagementSystem.Decorator;
using EmployeeManagementSystem.Facade;
using EmployeeManagementSystem.Factory;
using EmployeeManagementSystem.Observer;
using EmployeeManagementSystem.Repository;
using EmployeeManagementSystem.Strategy;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystem.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection
            AddEmployeeManagementServices(
                this IServiceCollection services,
                IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString(
                        "DefaultConnection")));

            services.AddScoped<
                IDepartmentRepository,
                DepartmentRepository>();

            services.AddScoped<
                IEmployeeRepository,
                EmployeeRepository>();

            services.AddSingleton<
                IEmployeeFactory,
                EmployeeFactory>();

            services.AddSingleton<
                ISalaryStrategyFactory,
                SalaryStrategyFactory>();

            services.AddSingleton<
                ISalaryEnhancer,
                BonusSalaryEnhancer>();

            services.AddScoped<
                INotificationService,
                NotificationService>();

            services.AddScoped<
                IPayrollService,
                PayrollAdapter>();

            services.AddScoped<EmployeeDirector>();

            services.AddScoped<
                IEmployeeFacade,
                EmployeeFacade>();

            return services;
        }
    }
}
