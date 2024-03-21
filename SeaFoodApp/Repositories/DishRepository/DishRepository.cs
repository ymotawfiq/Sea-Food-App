using SeaFoodApp.Models.Data;
using SeaFoodApp.Models.Entities;

namespace SeaFoodApp.Repositories.DishRepository
{
    public class DishRepository : IDish
    {
        private readonly ApplicationDbContext _dbContext;
        public DishRepository(ApplicationDbContext _dbContext)
        {
            this._dbContext = _dbContext;
        }
        public Dish AddDish(Dish dish)
        {
            _dbContext.Dishes.Add(dish);
            _dbContext.SaveChanges();
            return dish;
        }

        public Dish DeleteDishById(Guid id)
        {
            Dish dish = GetDishById(id);
            if (dish == null)
            {
                return null;
            }
            _dbContext.Dishes.Remove(dish);
            _dbContext.SaveChanges();
            return dish;
        }

        public Dish EditDish(Dish dish)
        {
            Dish dish1 = GetDishById(dish.Id);
            if (dish == null)
            {
                return null;
            }
            dish1.DishCost = dish.DishCost;
            dish1.DishName = dish.DishName;
            dish1.DishDescription = dish.DishDescription;
            dish1.TimeToPrepareInMinutes = dish.TimeToPrepareInMinutes;
            dish1.ImageUrl = dish.ImageUrl;
            _dbContext.SaveChanges();
            return dish1;
        }

        public IEnumerable<Dish> GetAllDishes()
        {
            return _dbContext.Dishes.ToList();
        }

        public Dish GetDishById(Guid id)
        {
            return _dbContext.Dishes.FirstOrDefault(p => p.Id == id);
        }
    }
}
