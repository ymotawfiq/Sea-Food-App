

using SeaFoodApp.Models.Entities;

namespace SeaFoodApp.Repositories.EmployeeService
{
    public interface IEmployee
    {

        Employee AddEmployee(Employee employee);

        Employee EditEmployee(Employee employee);

        Employee DeleteEmployeeById(Guid employeeId);

        Employee GetEmployeeById(Guid employeeId);

        IEnumerable<Employee> GetAllEmployees();

    }
}
