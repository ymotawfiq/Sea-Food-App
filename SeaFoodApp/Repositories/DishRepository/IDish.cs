using SeaFoodApp.Models.Entities;

namespace SeaFoodApp.Repositories.DishRepository
{
    public interface IDish
    {
        Dish AddDish(Dish dish);
        Dish EditDish(Dish dish);
        Dish DeleteDishById(Guid id);
        Dish GetDishById(Guid id);
        IEnumerable<Dish> GetAllDishes();
    }
}
