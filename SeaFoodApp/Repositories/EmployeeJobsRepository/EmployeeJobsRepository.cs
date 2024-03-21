using Microsoft.EntityFrameworkCore;
using SeaFoodApp.Models.Data;
using SeaFoodApp.Models.Entities;

namespace SeaFoodApp.Repositories.EmployeeJobsRepository
{
    public class EmployeeJobsRepository : IEmployeeJobs
    {
        private readonly ApplicationDbContext _dbContext;
        public EmployeeJobsRepository(ApplicationDbContext _dbContext)
        {
            this._dbContext = _dbContext;
        }
        public EmployeeJobs AddEmployeeJob(EmployeeJobs employeeJobs)
        {
            _dbContext.EmployeeJobs.Add(employeeJobs);
            _dbContext.SaveChanges();
            return employeeJobs;
        }

        public EmployeeJobs DeleteEmployeeJobById(Guid id)
        {
            EmployeeJobs employeeJob = GetEmployeeJobById(id);
            if (employeeJob == null)
            {
                return null;
            }
            _dbContext.EmployeeJobs.Remove(employeeJob);
            _dbContext.SaveChanges();
            return employeeJob;
        }

        public EmployeeJobs EditEmployeeJob(EmployeeJobs employeeJob)
        {
            EmployeeJobs employeeJob1 = GetEmployeeJobById(employeeJob.Id);
            if (employeeJob1 == null)
            {
                return null;
            }
            employeeJob1.JobId = employeeJob.JobId;
            employeeJob1.EmployeeId = employeeJob.EmployeeId;
            _dbContext.SaveChanges();
            return employeeJob1;
        }

        public IEnumerable<EmployeeJobs> GetAllEmployeesJobs()
        {
            return _dbContext.EmployeeJobs.Include(p => p.Employee).Include(p=>p.Job).ToList();
        }

        public EmployeeJobs GetEmployeeJobById(Guid id)
        {
            return  _dbContext.EmployeeJobs.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<EmployeeJobs> GetEmployeeJobs(Guid employeeId)
        {
            return (
                from e in  GetAllEmployeesJobs()
                where e.EmployeeId == employeeId
                select e
                );
        }
    }
}
