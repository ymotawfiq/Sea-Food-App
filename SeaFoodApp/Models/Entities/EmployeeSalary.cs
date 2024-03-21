
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace SeaFoodApp.Models.Entities
{
    public class EmployeeSalary
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        public Guid EmployeeId { get; set; }

        [Required]
        [Range(3000, 100000)]
        public float BaseSalary { get; set; }

        [Required]
        [Range(0, 2000)]
        public float Bonus { get; set; }

        [Required]
        [Range(0, 500)]
        public float Discount { get; set; }

        [Required]
        public float TotalSalary { get; set; }

        [Required]
        public DateTime SalaryDate { get; set; }

        public bool IsPaid { get; set; }

        [ForeignKey("EmployeeId")]
        public Employee? Employee { get; set; }
    }
}
