using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SeaFoodApp.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace SeaFoodApp.Views.Employee
{
    [BindProperties]
    public class EditEmployeeSalary : PageModel
    {


        [Required]
        public float BaseSalary { get; set; }

        [Required]
        public float Bonus { get; set; }

        [Required]
        public float Discount { get; set; }

        [Required]
        public float TotalSalary { get; set; }

        [Required]
        public DateTime SalaryDate { get; set; } = DateTime.Now;

    }
}
