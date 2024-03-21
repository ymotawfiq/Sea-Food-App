using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace SeaFoodApp.Views.Employee
{
    [BindProperties]
    public class AddJob : PageModel
    {


        [Required]
        public string Title { get; set; } = string.Empty;


    }
}
