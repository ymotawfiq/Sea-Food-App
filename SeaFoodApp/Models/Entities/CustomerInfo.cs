using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SeaFoodApp.Models.Entities
{
    public class CustomerInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [Required]
        public Guid CustomerId { get; set; }

        [Required]
        [RegularExpression("^01[0125][0-9]{8}$")]
        public string PhoneNumber { get; set; } = string.Empty;

        public string? Address { get; set; }

        [ForeignKey("CustomerId")]
        public Customer? Customer { get; set; }
    }
}
