using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SeaFoodApp.Models.Entities;
using SeaFoodApp.Repositories.EmployeeJobsRepository;
using SeaFoodApp.Repositories.EmployeeService;
using SeaFoodApp.Repositories.JobService;

namespace SeaFoodApp.Controllers
{

    [Route("[controller]")]
    [Authorize(Roles = "Admin")]
    public class EmployeeJobsController : Controller
    {
        private readonly IEmployeeJobs _employeeJobsRepository;
        private readonly IEmployee _employeeRepository;
        private readonly IJob _jobRepository;

        public EmployeeJobsController(IEmployeeJobs _employeeJobsRepository, IEmployee _employeeRepository,
            IJob _jobRepository)
        {
            this._employeeJobsRepository = _employeeJobsRepository;
            this._employeeRepository = _employeeRepository;
            this._jobRepository = _jobRepository;
        }

        [HttpGet("[action]")]
        public IActionResult GetAllEmployeesJobs()
        {

            var employeesJobs = _employeeJobsRepository.GetAllEmployeesJobs();

            ViewData["employeesJobs"] = employeesJobs;

            return View();
        }

        [HttpGet("[action]")]
        public IActionResult AddEmployeeJob()
        {
            var jobs = _jobRepository.GetAllJobs();
            var employees = _employeeRepository.GetAllEmployees();
            ViewData["employees"] = employees;
            ViewData["jobs"] = jobs;
            return View();
        }

        [HttpPost("[action]")]
        public IActionResult AddEmployeeJob(string employeeId, string jobId)
        {
            EmployeeJobs employeeJob = new EmployeeJobs { EmployeeId = new Guid(employeeId), JobId = new Guid(jobId) };
            if (!ModelState.IsValid)
            {
                return View(employeeJob);
            }
            if (employeeJob == null)
            {
                return View();
            }
            _employeeJobsRepository.AddEmployeeJob(employeeJob);
            ViewBag.Added = true;
            return Redirect($"/Employee/GetEmployeeInfo/{employeeId}");
        }

        [HttpGet("[action]/{id}")]
        public IActionResult EditEmployeeJob(Guid id)
        {
            EmployeeJobs employeeJob = _employeeJobsRepository.GetEmployeeJobById(id);
            var jobs = _jobRepository.GetAllJobs();
            var employees = _employeeRepository.GetAllEmployees();
            ViewData["employeeJob"] = employeeJob;
            ViewData["employees"] = employees;
            ViewData["jobs"] = jobs;
            return View();
        }

        [HttpPost("[action]")]
        public IActionResult EditEmployeeJob(string Id, string employeeId, string jobId)
        {
            EmployeeJobs employeeJob = new EmployeeJobs 
            {
                Id = new Guid(Id),
                EmployeeId = new Guid(employeeId),
                JobId = new Guid(jobId) 
            };
            if (!ModelState.IsValid)
            {
                return View();
            }
            _employeeJobsRepository.EditEmployeeJob(employeeJob);
            ViewBag.edited = true;
            return Redirect($"/Employee/GetEmployeeInfo/{employeeId}");
        }

        [HttpGet("[action]/{id}")]
        public IActionResult DeleteEmployeeJob(Guid id)
        {
            var employeeJob = _employeeJobsRepository.DeleteEmployeeJobById(id);
            ViewBag.deleted = true;
            return Redirect($"/Employee/GetEmployeeInfo/{employeeJob.EmployeeId}");
        }

        [HttpGet("{employeeId}")]
        public IActionResult GetAllEmployeeJobsByEmployeeId(Guid employeeId)
        {
            var employeeJobs = _employeeJobsRepository.GetEmployeeJobs(employeeId);
            ViewData["employeeJobs"] = employeeJobs;
            return Redirect($"/Employee/GetEmployeeInfo/{employeeId}");
        }

    }
}
