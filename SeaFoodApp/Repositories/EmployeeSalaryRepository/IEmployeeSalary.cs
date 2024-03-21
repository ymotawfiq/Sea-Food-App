using SeaFoodApp.Models.Entities;

namespace SeaFoodApp.Repositories.EmployeeSalaryRepository
{
    public interface IEmployeeSalary
    {
        EmployeeSalary AddEmployeeSalary(EmployeeSalary employeeSalary);
        EmployeeSalary EditEmployeeSalary(EmployeeSalary employeeSalary);
        EmployeeSalary DeleteEmployeeSalaryById(Guid id);
        EmployeeSalary GetEmployeeSalaryById(Guid id);
        IEnumerable<EmployeeSalary> GetAllEmployeesSalaries();
        IEnumerable<EmployeeSalary> GetAllEmployeeSalariesbyEmployeeId(Guid employeeId);
    }
}
