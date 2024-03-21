using Microsoft.EntityFrameworkCore;
using SeaFoodApp.Models.Data;
using SeaFoodApp.Models.Entities;

namespace SeaFoodApp.Repositories.EmployeeSalaryRepository
{
    public class EmployeeSalaryRepository : IEmployeeSalary
    {
        private readonly ApplicationDbContext _dbContext;

        public EmployeeSalaryRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        private int GetEmployeeSalaiesCount(Guid employeeId, DateTime dateTime)
        {
            return (from e in GetAllEmployeeSalariesbyEmployeeId(employeeId)
                    where e.SalaryDate.Year==dateTime.Year && e.SalaryDate.Month == dateTime.Month
                    select e).ToList().Count;
        }

        public EmployeeSalary AddEmployeeSalary(EmployeeSalary employeeSalary)
        {
            if(GetEmployeeSalaiesCount(employeeSalary.EmployeeId, employeeSalary.SalaryDate) > 0)
            {
                return null;
            }
            _dbContext.EmployeeSalary.Add(employeeSalary);
            _dbContext.SaveChanges();
            return employeeSalary;
        }

        public EmployeeSalary DeleteEmployeeSalaryById(Guid id)
        {
            EmployeeSalary employeeSalary = GetEmployeeSalaryById(id);
            if (employeeSalary == null)
            {
                return null;
            }
            _dbContext.EmployeeSalary.Remove(employeeSalary);
            _dbContext.SaveChanges();
            return employeeSalary;
        }

        public EmployeeSalary EditEmployeeSalary(EmployeeSalary employeeSalary)
        {
            if (GetEmployeeSalaiesCount(employeeSalary.EmployeeId, employeeSalary.SalaryDate) <= 1)
            {
                EmployeeSalary employeeSalary1 = GetEmployeeSalaryById(employeeSalary.Id);
                if (employeeSalary == null)
                {
                    return null;
                }
                employeeSalary1.IsPaid = employeeSalary.IsPaid;
                employeeSalary1.SalaryDate = employeeSalary.SalaryDate;
                employeeSalary1.TotalSalary = employeeSalary.TotalSalary;
                employeeSalary1.Discount = employeeSalary.Discount;
                employeeSalary1.Bonus = employeeSalary.Bonus;
                employeeSalary1.BaseSalary = employeeSalary.BaseSalary;
                _dbContext.SaveChanges();
                return employeeSalary1;
            }
            return null;
            
        }

        public IEnumerable<EmployeeSalary> GetAllEmployeeSalariesbyEmployeeId(Guid employeeId)
        {
            return (
                from e in GetAllEmployeesSalaries()
                where e.EmployeeId == employeeId
                select e
                );
        }

        public IEnumerable<EmployeeSalary> GetAllEmployeesSalaries()
        {
            return _dbContext.EmployeeSalary.Include(e=>e.Employee).ToList();
        }

        public EmployeeSalary GetEmployeeSalaryById(Guid id)
        {
            return _dbContext.EmployeeSalary.FirstOrDefault(e => e.Id == id);
        }
    }
}
