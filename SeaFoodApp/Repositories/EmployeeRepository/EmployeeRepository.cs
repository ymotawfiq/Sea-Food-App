

using Microsoft.EntityFrameworkCore;
using SeaFoodApp.Models.Data;
using SeaFoodApp.Models.Entities;
using System.Collections.Generic;

namespace SeaFoodApp.Repositories.EmployeeService
{
    public class EmployeeService : IEmployee
    {

        private readonly ApplicationDbContext _dbContext;

        public EmployeeService(ApplicationDbContext _dbContext)
        {
            this._dbContext = _dbContext;
        }

        public Employee AddEmployee(Employee employee)
        {
            _dbContext.Employee.Add(employee);
            _dbContext.SaveChanges();
            return employee;
        }

        public Employee DeleteEmployeeById(Guid employeeId)
        {
            Employee employee =  GetEmployeeById(employeeId);
            if(employee == null)
            {
                return null;
            }
            _dbContext.Employee.Remove(employee);
            _dbContext.SaveChanges();
            return employee;
        }

        public Employee EditEmployee(Employee employee)
        {

            Employee employee1 = GetEmployeeById(employee.Id);
            employee1.Name = employee.Name;
            employee1.StartingDate = employee.StartingDate;
            _dbContext.SaveChanges();
            return employee1;

        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _dbContext.Employee.ToList();
        }

        public Employee GetEmployeeById(Guid employeeId)
        {
            Employee? employee =  _dbContext.Employee.FirstOrDefault(e => e.Id == employeeId);
            return employee;
        }
    }
}
