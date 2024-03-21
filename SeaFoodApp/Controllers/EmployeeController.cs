using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SeaFoodApp.Models.DTOs;
using SeaFoodApp.Models.Entities;
using SeaFoodApp.Repositories.EmployeeJobsRepository;
using SeaFoodApp.Repositories.EmployeeSalaryRepository;
using SeaFoodApp.Repositories.EmployeeService;
using SeaFoodApp.Repositories.JobService;


namespace SeaFoodApp.Controllers
{

    [Route("[controller]")]
    [Authorize(Roles = "Admin")]
    public class EmployeeController : Controller
    {
        private readonly IEmployee _employeeRepository;
        private readonly IJob _jobRepository;
        private readonly IEmployeeJobs _employeeJobsRepository;
        private readonly IEmployeeSalary _employeeSalaryRepository;

        public EmployeeController(IEmployee _employeeRepository, IJob _jobRepository,
            IEmployeeJobs _employeeJobsRepository, IEmployeeSalary _employeeSalaryRepository)
        {
            this._employeeRepository = _employeeRepository;
            this._jobRepository = _jobRepository;
            this._employeeJobsRepository = _employeeJobsRepository;
            this._employeeSalaryRepository = _employeeSalaryRepository;
        }

        [HttpGet("[action]")]
        public IActionResult GetAllEmployees()
        {

            var employees = _employeeRepository.GetAllEmployees();

            ViewData["employees"] = employees;

            return View();
        }

        [HttpGet("[action]")]
        public IActionResult AddEmployee()
        {
            var employee = new Employee();
            return View(employee);
        }

        [HttpPost("[action]")]
        public IActionResult AddEmployee(Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return View(employee);
            }
            if (employee.StartingDate.Year < 2023)
            {
                ModelState.AddModelError("yearError", "Year Should be earlier than 2023");
                return View(employee);
            }
            var employee1 = _employeeRepository.AddEmployee(employee);
            if (employee1 == null)
            {
                return View();
            }
            ViewBag.Added = true;
            return View();
        }

        [HttpGet("[action]/{id}")]
        public IActionResult EditEmployee(Guid id)
        {
            Employee employee = _employeeRepository.GetEmployeeById(id);
            return View(employee);
        }

        [HttpPost("[action]")]
        public IActionResult EditEmployee(Employee employee, string Id)
        {
            employee.Id = new Guid(Id);
            if (!ModelState.IsValid)
            {
                return View(employee);
            }
            _employeeRepository.EditEmployee(employee);
            ViewBag.edited = true;
            return View();
        }

        [HttpGet("[action]/{id}")]
        public IActionResult DeleteEmployee(Guid id)
        {
            var employee = _employeeRepository.GetEmployeeById(id);
            if (employee == null)
            {
                return RedirectToAction("GetAllEmployees");
            }
            _employeeRepository.DeleteEmployeeById(id);
            ViewBag.deleted = true;
            return RedirectToAction("GetAllEmployees");
        }

        [HttpGet("[action]/{employeeId}")]
        public IActionResult GetEmployeeInfo(Guid employeeId)
        {
            Employee employee = _employeeRepository.GetEmployeeById(employeeId);
            var employeeJobs = _employeeJobsRepository.GetEmployeeJobs(employeeId);
            var employeeSalaries = _employeeSalaryRepository.GetAllEmployeeSalariesbyEmployeeId(employeeId);
            EmployeeInfoDto? employeeInfoDto = new EmployeeInfoDto
            {
                EmployeeId = employee.Id,
                EmployeeJobs = employeeJobs,
                Name= employee.Name,
                EmployeeSalaries = employeeSalaries
            };
            ViewData["employeeInfoDto"] = employeeInfoDto;
            return View();
        }

    }
}
