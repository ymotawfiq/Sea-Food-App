using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SeaFoodApp.Models.Entities
{
    public class TableOrder
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        [Range(1,20)]
        public int TableNumber { get; set; }

        [Required]
        public Guid DishId { get; set; }

        public DateTime OrderDate { get; set; } = DateTime.Now;

        [ForeignKey("DishId")]
        public Dish? Dish { get; set; }
    }
}
