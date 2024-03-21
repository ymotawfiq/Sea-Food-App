using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SeaFoodApp.Models.Entities
{
    public class DishOrder
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        public Guid DishId { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }

        [Required]
        public int OrderTimes { get; set; }

        [Required]
        public int OrderTimesBerDay { get; set; }
    }
}
