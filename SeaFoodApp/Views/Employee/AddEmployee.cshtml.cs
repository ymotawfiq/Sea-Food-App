using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace SeaFoodApp.Views.Employee
{
    [BindProperties]
    public class AddEmployee : PageModel
    {


        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public DateTime StartingDate { get; set; } = DateTime.Now;


    }
}
