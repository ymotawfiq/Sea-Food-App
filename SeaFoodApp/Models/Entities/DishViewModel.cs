using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace SeaFoodApp.Models.Entities
{
    public class DishViewModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        public string DishName { get; set; } = string.Empty;

        [Required]
        public string DishDescription { get; set; } = string.Empty;

        [Required]
        [Range(10, 5000)]
        public float DishCost { get; set; }

        [Required]
        [Range(1, 100)]
        public int TimeToPrepareInMinutes { get; set; }

        [Required]
        [NotNull]
        public IFormFile? Image { get; set; }

        public string? ImageUrl { get; set; }

    }
}
