using SeaFoodApp.Models.Entities;

namespace SeaFoodApp.Models.DTOs
{
    public class EmployeeInfoDto
    {
        public Guid EmployeeId { get; set; }
        public string Name { get; set; } = string.Empty;
        public IEnumerable<EmployeeJobs>? EmployeeJobs { get; set; }
        public IEnumerable<EmployeeSalary>? EmployeeSalaries { get; set; }
    }
}
