using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SeaFoodApp.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace SeaFoodApp.Views.Employee
{
    [BindProperties]
    public class EditDish : PageModel
    {

        [Required]
        public IFormFile? Image { get; set; }


    }
}
