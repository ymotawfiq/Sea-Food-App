using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SeaFoodApp.Models.Entities;
using SeaFoodApp.Repositories.DishRepository;


namespace SeaFoodApp.Controllers
{
    
    [Route("[controller]")]
    [Authorize(Roles = "Admin")]
    public class DishController : Controller
    {
        private readonly IDish _dishRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public DishController(IDish _dishRepository, IWebHostEnvironment _webHostEnvironment)
        {
            this._dishRepository = _dishRepository;
            this._webHostEnvironment = _webHostEnvironment;
        }

        [AllowAnonymous]
        [HttpGet("[action]")]
        public IActionResult GetAllDishes()
        {

            var dishes = _dishRepository.GetAllDishes();

            ViewData["dishes"] = dishes;

            return View();
        }


        [HttpGet("[action]")]
        public IActionResult AddDish()
        {
            DishViewModel dishViewModel = new DishViewModel();
            return View(dishViewModel);
        }


        [HttpPost("[action]")]
        public IActionResult AddDish(DishViewModel dishViewModel)
        {
            if (!ModelState.IsValid)
            {   
                return View(dishViewModel);
            }
            string image = SaveDishImage(dishViewModel);
            if (image == null)
            {
                return View();
            }
            Dish dish = new Dish
            {
                ImageUrl = image,
                DishCost = dishViewModel.DishCost,
                DishName = dishViewModel.DishName,
                DishDescription = dishViewModel.DishDescription,
                TimeToPrepareInMinutes = dishViewModel.TimeToPrepareInMinutes
            };
            var dish1 = _dishRepository.AddDish(dish);
            if (dish1 == null)
            {
                return View();
            }
            ViewBag.Added = true;
            return View();
        }


        [HttpGet("[action]/{id}")]
        public IActionResult EditDish(Guid id)
        {
            var dish = _dishRepository.GetDishById(id);
            var dishViewModel = new DishViewModel
            {
                Id = dish.Id,
                DishCost = dish.DishCost,
                DishDescription = dish.DishDescription,
                DishName = dish.DishName,
                ImageUrl = dish.ImageUrl,
                TimeToPrepareInMinutes = dish.TimeToPrepareInMinutes
            };
            ViewData["dish"] = dish;
            return View(dishViewModel);
        }


        [HttpPost("[action]")]
        public IActionResult EditDish(DishViewModel dishViewModel, string Id)
        {
            dishViewModel.Id = new Guid(Id);
            var dish = _dishRepository.GetDishById(dishViewModel.Id);
            if (!ModelState.IsValid)
            {
                ViewData["dish"] = dish;
                return View(dishViewModel);
            }
            var oldDish = _dishRepository.GetDishById(new Guid(Id));
            dishViewModel.ImageUrl = oldDish.ImageUrl;
            string image = SaveDishImage(dishViewModel);
            Dish dish1 = new Dish
            {
                DishDescription = dishViewModel.DishDescription,
                Id = dishViewModel.Id,
                ImageUrl = image,
                DishCost = dishViewModel.DishCost,
                DishName = dishViewModel.DishName,
                TimeToPrepareInMinutes = dishViewModel.TimeToPrepareInMinutes
            };
            _dishRepository.EditDish(dish1);
            ViewBag.edited = true;
            return View();
        }


        [HttpGet("[action]/{id}")]
        public IActionResult DeleteDish(Guid id)
        {
            Dish dish = _dishRepository.GetDishById(id);
            if (dish == null)
            {
                return View();
            }
            _dishRepository.DeleteDishById(id);
            DeleteExistingDishImage(dish.ImageUrl);
            ViewBag.deleted = true;
            return RedirectToAction("GetAllDishes");
        }

        private string SaveDishImage(DishViewModel dish)
        {
            string uniqueFileName = null;
            if (dish.Image != null)
            {
                DeleteExistingDishImage(dish.ImageUrl);
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "Images/Dishes");
                uniqueFileName = Guid.NewGuid().ToString().Substring(0,8) + "_" + dish.Image.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    dish.Image.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }

        private void DeleteExistingDishImage(string imageUrl)
        {
            string existingImage = Path.Combine(_webHostEnvironment.WebRootPath, $"Images/Dishes/{imageUrl}");
            if (System.IO.File.Exists(existingImage))
            {
                System.IO.File.Delete(existingImage);
            }
        }

    }
}
