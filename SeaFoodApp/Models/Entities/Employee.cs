

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SeaFoodApp.Models.Entities
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        [MinLength(3, ErrorMessage ="Name must be at least 3 characters")]
        public string Name { get; set; } = string.Empty;

        public DateTime StartingDate { get; set; } = DateTime.Now;
    }
}
