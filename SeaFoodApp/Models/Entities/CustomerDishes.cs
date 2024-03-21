using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SeaFoodApp.Models.Entities
{
    public class CustomerDishes
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        public Guid CusstomerId { get; set; }

        [Required]
        public Guid DishId { get; set; }

        [ForeignKey("CusstomerId")]
        public Customer? Customer { get; set; }

        [ForeignKey("DishId")]
        public Dish? Dish { get; set; }
    }
}
