using SeaFoodApp.Models.Entities;

namespace SeaFoodApp.Repositories.EmployeeJobsRepository
{
    public interface IEmployeeJobs
    {
        EmployeeJobs AddEmployeeJob(EmployeeJobs employeeJobs);
        EmployeeJobs EditEmployeeJob(EmployeeJobs employeeJob);
        EmployeeJobs GetEmployeeJobById(Guid id);
        EmployeeJobs DeleteEmployeeJobById(Guid id);
        IEnumerable<EmployeeJobs> GetAllEmployeesJobs();
        IEnumerable<EmployeeJobs> GetEmployeeJobs(Guid employeeId);
    }
}
