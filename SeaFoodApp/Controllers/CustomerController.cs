using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SeaFoodApp.Models.Entities;
using SeaFoodApp.Repositories.CustomerRepository;
using SeaFoodApp.Repositories.EmployeeService;

namespace SeaFoodApp.Controllers
{

    [Route("[controller]")]
    [Authorize(Roles = "Admin")]
    public class CustomerController : Controller
    {
        private readonly ICustomer _customerRepository;
        public CustomerController(ICustomer _customerRepository)
        {
            this._customerRepository = _customerRepository;
        }

        [HttpGet("[action]")]
        public IActionResult GetAllCustomers()
        {
            IEnumerable<Customer> customers = _customerRepository.GelAllCustomers();
            return View(customers);
        }

        [HttpGet("[action]")]
        public IActionResult AddCustomer()
        {
            Customer customer = new Customer();
            return View(customer);
        }

        [HttpPost("[action]")]
        public IActionResult AddCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return View(customer);
            }
            _customerRepository.AddCustomer(customer);
            
            return RedirectToAction("GetAllCustomers");
        }

        [HttpGet("[action]/{id}")]
        public IActionResult EditCustomer(Guid id)
        {
            Customer customer = _customerRepository.GetCustomerById(id);
            if (customer == null)
            {
                return RedirectToAction("GetAllCustomers");
            }
            return View(customer);
        }

        [HttpPost("[action]")]
        public IActionResult EditCustomer(Customer customer, string Id)
        {
            customer.Id = new Guid(Id);
            if (!ModelState.IsValid || customer == null)
            {
                if (customer == null)
                {
                    return RedirectToAction("GetAllCustomers");
                }
                return View(customer);
            }
            _customerRepository.EditCustomer(customer);

            return RedirectToAction("GetAllCustomers");
        }

        [HttpGet("[action]/{id}")]
        public IActionResult DeleteCustomer(Guid id)
        {
            Customer customer = _customerRepository.GetCustomerById(id);
            if (customer == null)
            {
                return RedirectToAction("GetAllCustomers");
            }
            _customerRepository.DeleteCustomerById(id);
            return RedirectToAction("GetAllCustomers");
        }

        [HttpPost("[action]")]
        public IActionResult Search(string customerId)
        {
            if(customerId == null)
            {
                return Redirect($"/Customer/GetAllCustomers");
            }
            return Redirect($"/CustomerInfo/GetCustomerInfo/{customerId}");
        }
    }
}
