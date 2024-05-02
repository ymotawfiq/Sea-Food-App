using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SeaFoodApp.Models.Entities;



namespace SeaFoodApp.Models.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            SeedRoles(builder);
        }

        private void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole { ConcurrencyStamp="1", Name="Admin", NormalizedName="Admin" },
                new IdentityRole { ConcurrencyStamp = "2", Name = "User", NormalizedName = "User" }
            );
        }

        public DbSet<Employee> Employee { get; set; }

        public DbSet<Job> Job { get; set; }

        public DbSet<EmployeeJobs> EmployeeJobs { get; set; }

        public DbSet<EmployeeSalary> EmployeeSalary { get; set; }

        public DbSet<Dish> Dishes { get; set; }

        public DbSet<DishOrder> DishOrders { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<CustomerInfo> CustomerInfo { get; set; }

        public DbSet<CustomerDishes> CustomerDishes { get; set; }

        public DbSet<TableOrder> TableOrders { get; set; }

    }
}
