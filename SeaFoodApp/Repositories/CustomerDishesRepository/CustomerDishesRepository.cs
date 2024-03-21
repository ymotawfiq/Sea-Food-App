using Microsoft.EntityFrameworkCore;
using SeaFoodApp.Models.Data;
using SeaFoodApp.Models.Entities;

namespace SeaFoodApp.Repositories.CustomerDishesRepository
{
    public class CustomerDishesRepository : ICustomerDishes
    {
        private readonly ApplicationDbContext _dbContext;
        public CustomerDishesRepository(ApplicationDbContext _dbContext)
        {
            this._dbContext = _dbContext;
        }
        public CustomerDishes AddCustomerDish(CustomerDishes customerDish)
        {
            _dbContext.CustomerDishes.Add(customerDish);
            _dbContext.SaveChanges();
            return customerDish;
        }

        public CustomerDishes DeleteCustomerDishById(Guid id)
        {
            CustomerDishes customerDish = GetCustomerDishById(id);
            if (customerDish == null)
            {
                return null;
            }
            _dbContext.CustomerDishes.Remove(customerDish);
            _dbContext.SaveChanges();
            return customerDish;
        }

        public CustomerDishes EditCustomerDish(CustomerDishes customerDish)
        {
            CustomerDishes customerDish1 = GetCustomerDishById(customerDish.Id);
            if (customerDish == null)
            {
                return null;
            }
            customerDish1.DishId = customerDish.DishId;
            customerDish1.CusstomerId = customerDish.CusstomerId;
            _dbContext.SaveChanges();
            return customerDish1;
        }

        public IEnumerable<CustomerDishes> GetAllCustomerDishes()
        {
            return _dbContext.CustomerDishes.Include(e => e.Customer).Include(e => e.Dish).ToList();
        }

        public CustomerDishes GetCustomerDishById(Guid id)
        {
            return _dbContext.CustomerDishes.FirstOrDefault(e => e.Id == id);
        }
    }
}
