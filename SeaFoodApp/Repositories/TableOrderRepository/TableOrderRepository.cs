using Microsoft.EntityFrameworkCore;
using SeaFoodApp.Models.Data;
using SeaFoodApp.Models.Entities;

namespace SeaFoodApp.Repositories.TableOrderRepository
{
    public class TableOrderRepository : ITableOrder
    {
        private readonly ApplicationDbContext _dbContext;
        public TableOrderRepository(ApplicationDbContext _dbContext)
        {
            this._dbContext = _dbContext;
        }
        public TableOrder AddTableOrder(TableOrder tableOrder)
        {
            _dbContext.TableOrders.Add(tableOrder);
            _dbContext.SaveChanges();
            return tableOrder;
        }

        public TableOrder DeleteTableOrderByOrderId(Guid id)
        {
            TableOrder tableOrder = GetTableOrderByOrderId(id);
            if (tableOrder == null)
            {
                return null;
            }
            _dbContext.TableOrders.Remove(tableOrder);
            _dbContext.SaveChanges();
            return tableOrder;
        }

        public TableOrder EditTableOrder(TableOrder tableOrder)
        {
            TableOrder tableOrder1 = GetTableOrderByOrderId(tableOrder.Id);
            if (tableOrder == null)
            {
                return null;
            }
            tableOrder1.DishId = tableOrder.DishId;
            tableOrder1.OrderDate = tableOrder.OrderDate;
            tableOrder1.TableNumber = tableOrder.TableNumber;
            _dbContext.SaveChanges();
            return tableOrder1;
        }

        public IEnumerable<TableOrder> GetAllTableOrders()
        {
            return _dbContext.TableOrders.Include(o=>o.Dish).ToList();
        }

        public IEnumerable<TableOrder> GetTableOrdersByDate(DateTime dateTime)
        {
            return (
                from o in GetAllTableOrders()
                where o.OrderDate.Year==dateTime.Year && o.OrderDate.Month==dateTime.Month
                    && o.OrderDate.Day==dateTime.Day
                select o
                );
        }

        public TableOrder GetTableOrderByOrderId(Guid id)
        {
            return _dbContext.TableOrders.FirstOrDefault(o => o.Id == id);
        }
    }
}
