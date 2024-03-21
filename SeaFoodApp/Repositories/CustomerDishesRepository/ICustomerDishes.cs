using SeaFoodApp.Models.Entities;

namespace SeaFoodApp.Repositories.CustomerDishesRepository
{
    public interface ICustomerDishes
    {
        CustomerDishes AddCustomerDish(CustomerDishes customerDish);
        CustomerDishes EditCustomerDish(CustomerDishes customerDish);
        CustomerDishes DeleteCustomerDishById(Guid id);
        CustomerDishes GetCustomerDishById(Guid id);
        IEnumerable<CustomerDishes> GetAllCustomerDishes();
    }
}
