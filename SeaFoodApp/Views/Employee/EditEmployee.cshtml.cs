using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SeaFoodApp.Models.Entities;

namespace SeaFoodApp.Views.Employee
{
    [BindProperties]
    public class EditEmployee : PageModel
    {

        //private readonly IEmployee _employeeService;

        //public SeaFoodApp.Models.Entities.Employee employee { get; set; }

        //public EditEmployee(IEmployee _employeeService)
        //{
        //    this._employeeService = _employeeService;
        //}

        //public void OnGet(Guid id)
        //{
        //    if (id != null)
        //    {
        //        employee = _employeeService.GetEmployeeById(id);
        //    }
        //}

    }
}
