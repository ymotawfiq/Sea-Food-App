using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SeaFoodApp.Models.Entities;
using SeaFoodApp.Repositories.EmployeeSalaryRepository;
using SeaFoodApp.Repositories.EmployeeService;

namespace SeaFoodApp.Controllers
{

    [Route("[controller]")]
    [Authorize(Roles = "Admin")]
    public class EmployeeSalaryController : Controller
    {
        private readonly IEmployeeSalary _employeeSalaryRepository;
        private readonly IEmployee _employeeRepository;

        public EmployeeSalaryController(IEmployeeSalary _employeeSalaryRepository, IEmployee _employeeRepository)
        {
            this._employeeSalaryRepository = _employeeSalaryRepository;
            this._employeeRepository = _employeeRepository;
        }

        [HttpGet("[action]")]
        public IActionResult GetAllEmployeesSalaries()
        {

            var employeesSalaries = _employeeSalaryRepository.GetAllEmployeesSalaries();

            ViewData["employeesSalaries"] = employeesSalaries;
            return View();
        }

        [HttpGet("[action]/{id}")]
        public IActionResult AddEmployeeSalary(Guid id)
        {
            var employee = _employeeRepository.GetEmployeeById(id);
            var employeeSalary = new EmployeeSalary { Employee = employee};
            var employees = _employeeRepository.GetAllEmployees();
            ViewData["employees"] = employees;
            ViewData["employee"] = employee;
            return View(employeeSalary);
        }

        [HttpPost("[action]")]
        public IActionResult AddEmployeeSalary(EmployeeSalary employeeSalary, bool isPaid, string Id)
        {
            employeeSalary.IsPaid = isPaid;
            employeeSalary.EmployeeId = new Guid(Id);
            
            if (!ModelState.IsValid)
            {
                var employee = _employeeRepository.GetEmployeeById(employeeSalary.EmployeeId);
                ViewData["employee"] = employee;
                return View(employeeSalary);
            }
            else if (employeeSalary.SalaryDate.Year < 2023)
            {
                var employee = _employeeRepository.GetEmployeeById(employeeSalary.EmployeeId);
                ViewData["employee"] = employee;
                ModelState.AddModelError("dateError", "Salary year should be earlier than 2023");
                return View(employeeSalary);
            }
            employeeSalary.TotalSalary = employeeSalary.BaseSalary + employeeSalary.Bonus - employeeSalary.Discount;
            var employeeSalary1 = _employeeSalaryRepository.AddEmployeeSalary(employeeSalary);
            if (employeeSalary1 == null)
            {
                return Redirect($"AddEmployeeSalary/{employeeSalary.EmployeeId}");
            }
            ViewBag.Added = true;
            return Redirect($"/Employee/GetEmployeeInfo/{employeeSalary1.EmployeeId}");
        }

        [HttpGet("[action]/{id}")]
        public IActionResult EditEmployeeSalary(Guid id)
        {
            EmployeeSalary employeeSalary = _employeeSalaryRepository.GetEmployeeSalaryById(id);
            var employee = _employeeRepository.GetEmployeeById(employeeSalary.EmployeeId);
            ViewData["employee"] = employee;
            return View(employeeSalary);
        }

        [HttpPost("[action]")]
        public IActionResult EditEmployeeSalary(EmployeeSalary employeeSalary, bool isPaid,
            string Id, string empSalId)
        {
            employeeSalary.EmployeeId = new Guid(Id);
            employeeSalary.Id = new Guid(empSalId);
            employeeSalary.IsPaid = isPaid;
            var employee = _employeeRepository.GetEmployeeById(employeeSalary.EmployeeId);
            if (!ModelState.IsValid)
            {
                ViewData["employee"] = employee;
                return View(employeeSalary);
            }
            else if (employeeSalary.SalaryDate.Year < 2023)
            {
                ViewData["employee"] = employee;
                ModelState.AddModelError("dateError", "Salary year should be earlier than 2023");
                return View(employeeSalary);
            }
            employeeSalary.TotalSalary = employeeSalary.BaseSalary + employeeSalary.Bonus - employeeSalary.Discount;
            var employeeSalary1 = _employeeSalaryRepository.EditEmployeeSalary(employeeSalary);
            if (employeeSalary1 == null)
            {
                return Redirect($"EditEmployeeSalary/{employeeSalary.Id}");
            }
            ViewBag.edited = true;
            return Redirect($"/Employee/GetEmployeeInfo/{employeeSalary1.EmployeeId}");
        }

        [HttpGet("[action]/{id}")]
        public IActionResult DeleteEmployeeSalary(Guid id)
        {
            var employeeSalary = _employeeSalaryRepository.GetEmployeeSalaryById(id);
            if(employeeSalary == null)
            {
                ModelState.AddModelError("InvalidId", "Invalid Id.");
                return View();
            }
            var employeeSalary1 = _employeeSalaryRepository.DeleteEmployeeSalaryById(id);
            ViewBag.deleted = true;
            return Redirect($"/Employee/GetEmployeeInfo/{employeeSalary1.EmployeeId}");
        }

        [HttpGet("{employeeId}")]
        public IActionResult GetAllEmployeeSalariesByEmployeeId(Guid employeeId)
        {
            var employeeSalaries = _employeeSalaryRepository.GetAllEmployeeSalariesbyEmployeeId(employeeId);
            if (employeeSalaries == null)
            {
                ModelState.AddModelError("InvalidId", "Invalid Id.");
                return View();
            }
            ViewData["employeeSalaries"] = employeeSalaries;
            return Redirect($"/Employee/GetEmployeeInfo/{employeeId}");
        }
    }
}
