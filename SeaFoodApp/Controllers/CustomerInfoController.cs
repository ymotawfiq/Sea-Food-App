using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SeaFoodApp.Models.Entities;
using SeaFoodApp.Repositories.CustomerInfoRepository;
using SeaFoodApp.Repositories.CustomerRepository;
using System;

namespace SeaFoodApp.Controllers
{
    [Route("[controller]")]
    [Authorize(Roles = "Admin")]
    public class CustomerInfoController : Controller
    {
        private readonly ICustomerInfo _customerInfoRepository;
        private readonly ICustomer _customerRepository;
        public CustomerInfoController(ICustomerInfo _customerInfoRepository, ICustomer _customerRepository)
        {
            this._customerInfoRepository = _customerInfoRepository;
            this._customerRepository = _customerRepository;
        }

        [HttpGet("[action]")]
        public IActionResult GetAllCustomersInfo()
        {
            var customersInfo = _customerInfoRepository.GelAllCustomersInfo();
            ViewData["customersInfo"] = customersInfo;
            return View();
        }

        [HttpGet("[action]/{id}")]
        public IActionResult AddCustomerInfo(Guid id)
        {
            Customer customer = _customerRepository.GetCustomerById(id);
            CustomerInfo customerInfo = new CustomerInfo();
            ViewData["customer"] = customer;
            return View(customerInfo);
        }

        [HttpPost("[action]")]
        public IActionResult AddCustomerInfo(CustomerInfo customerInfo, string cusId)
        {
            customerInfo.CustomerId = new Guid(cusId);
            if (!ModelState.IsValid)
            {
                Customer customer = _customerRepository.GetCustomerById(customerInfo.CustomerId);
                ViewData["customer"] = customer;
                return View(customerInfo);
            }
            _customerInfoRepository.AddCustomerInfo(customerInfo);
            return Redirect($"/CustomerInfo/GetCustomerInfo/{customerInfo.CustomerId}");
        }

        [HttpGet("[action]/{id}")]
        public IActionResult EditCustomerInfo(Guid id)
        {
            CustomerInfo customerInfo = _customerInfoRepository.GetCustomerInfoById(id);
            Customer customer = _customerRepository.GetCustomerById(customerInfo.CustomerId);
            if(customerInfo == null)
            {
                return Redirect($"/CustomerInfo/GetAllCustomersInfo");
            }
            ViewData["customerInfo"] = customerInfo;
            ViewData["customer"] = customer;
            return View();
        }

        [HttpPost("[action]")]
        public IActionResult EditCustomerInfo(CustomerInfo customerInfo, string Id, string cusId)
        {
            customerInfo.Id = new Guid(Id);
            customerInfo.CustomerId = new Guid(cusId);
            if (!ModelState.IsValid)
            {
                Customer customer = _customerRepository.GetCustomerById(customerInfo.CustomerId);
                if (customerInfo == null)
                {
                    return Redirect($"/CustomerInfo/GetAllCustomersInfo");
                }
                ViewData["customerInfo"] = customerInfo;
                ViewData["customer"] = customer;
                return View();
            }
            _customerInfoRepository.EditCustomerInfo(customerInfo);
            return Redirect($"/CustomerInfo/GetCustomerInfo/{customerInfo.CustomerId}");
        }

        [HttpGet("[action]/{id}")]
        public IActionResult DeleteCustomerInfo(Guid id)
        {
            CustomerInfo customerInfo = _customerInfoRepository.GetCustomerInfoById(id);
            if (customerInfo == null)
            {
                return Redirect($"CustomerInfo/GetAllCustomersInfo");
            }
            _customerInfoRepository.DeleteCustomerInfoById(id);
            return Redirect($"/CustomerInfo/GetCustomerInfo/{customerInfo.CustomerId}");
        }

        [HttpGet("[action]/{id}")]
        public IActionResult GetCustomerInfo(Guid id)
        {
            Customer customer = _customerRepository.GetCustomerById(id);
            IEnumerable<CustomerInfo> customerInfos = _customerInfoRepository.GelAllCustomerInfoByCustomerId(id);
            ViewData["customer"] = customer;
            ViewData["customerInfos"] = customerInfos;
            return View();
        }

    }
}
