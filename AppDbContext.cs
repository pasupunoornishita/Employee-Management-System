using Microsoft.EntityFrameworkCore;
using EmployeeManagementSystem.Models;

namespace EmployeeManagementSystem.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(
            DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(
            ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>(entity =>
            {
                entity.ToTable("Departments");

                entity.HasKey(d => d.Id);

                entity.Property(d => d.Id)
                    .HasColumnName("DeptId");

                entity.Property(d => d.Name)
                    .HasColumnName("DeptName")
                    .IsRequired();
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employees");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                    .HasColumnName("EmpId");

                entity.Property(e => e.Name)
                    .HasColumnName("EmpName")
                    .IsRequired();

                entity.Property(e => e.Salary)
                    .HasColumnName("EmpSalary");

                entity.Property(e => e.DepartmentId)
                    .HasColumnName("DeptId");

                entity.Property(e => e.EmployeeType)
                    .HasColumnName("EmployeeType");

                entity.HasOne(e => e.Department)
                    .WithMany(d => d.Employees)
                    .HasForeignKey(e => e.DepartmentId);
            });
        }
    }
}
