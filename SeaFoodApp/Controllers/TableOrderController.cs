using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SeaFoodApp.Models.Entities;
using SeaFoodApp.Repositories.DishRepository;
using SeaFoodApp.Repositories.TableOrderRepository;

namespace SeaFoodApp.Controllers
{

    [Route("[controller]")]
    [Authorize(Roles = "Admin")]
    public class TableOrderController : Controller
    {
        private readonly ITableOrder _tableOrderRepository;
        private readonly IDish _dishRepository;
        public TableOrderController(ITableOrder _tableOrderRepository, IDish _dishRepository)
        {
            this._tableOrderRepository = _tableOrderRepository;
            this._dishRepository = _dishRepository;
        }

        [HttpGet("[action]")]
        public IActionResult GetAllTablesOrders()
        {
            var tablesOrders = _tableOrderRepository.GetAllTableOrders();
            return View(tablesOrders);
        }

        [HttpPost("[action]")]
        public IActionResult GetAllTablesOrdersByDate(DateTime dateTime)
        {
            var tablesOrders = _tableOrderRepository.GetTableOrdersByDate(dateTime);
            return View(tablesOrders);
        }


        [HttpGet("[action]/{tableNumber}")]
        public IActionResult AddTableOrder(int tableNumber)
        {
            if(tableNumber > 20 || tableNumber < 1)
            {
                return RedirectToAction("GetAllTablesOrders");
            }
            TableOrder tableOrder = new TableOrder { TableNumber = tableNumber };
            var dishes = _dishRepository.GetAllDishes();
            ViewData["dishes"] = dishes;
            return View(tableOrder);
        }

        [HttpPost("[action]")]
        public IActionResult AddTableOrder(TableOrder tableOrder, string dishId)
        {
            tableOrder.DishId = new Guid(dishId);
            tableOrder.OrderDate = DateTime.Now;
            if (!ModelState.IsValid)
            {
                var dishes = _dishRepository.GetAllDishes();
                ViewData["dishes"] = dishes;
                return View(tableOrder);
            }
            _tableOrderRepository.AddTableOrder(tableOrder);
            return RedirectToAction("GetAllTablesOrders");
        }

        [HttpGet("[action]/{id}")]
        public IActionResult EditTableOrder(Guid id)
        {
            TableOrder tableOrder = _tableOrderRepository.GetTableOrderByOrderId(id);
            if (tableOrder == null)
            {
                return RedirectToAction("GetAllTablesOrders");
            }
            var dishes = _dishRepository.GetAllDishes();
            ViewData["dishes"] = dishes;
            return View(tableOrder);
        }

        [HttpPost("[action]")]
        public IActionResult EditTableOrder(TableOrder tableOrder, string dishId)
        {
            tableOrder.DishId = new Guid(dishId);
            if (!ModelState.IsValid)
            {
                var dishes = _dishRepository.GetAllDishes();
                ViewData["dishes"] = dishes;
                return View(tableOrder);
            }
            _tableOrderRepository.EditTableOrder(tableOrder);
            return RedirectToAction("GetAllTablesOrders");
        }

        [HttpGet("[action]/{id}")]
        public IActionResult DeleteTableOrder(Guid id)
        {
            TableOrder tableOrder = _tableOrderRepository.GetTableOrderByOrderId(id);

            if (tableOrder == null)
            {
                return RedirectToAction("GetAllTablesOrders");
            }
            _tableOrderRepository.DeleteTableOrderByOrderId(id);
            return RedirectToAction("GetAllTablesOrders");
        }

    }
}
