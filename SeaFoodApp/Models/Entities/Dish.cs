using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SeaFoodApp.Models.Entities
{
    public class Dish
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
        public string ImageUrl { get; set; } = string.Empty;

    }
}
