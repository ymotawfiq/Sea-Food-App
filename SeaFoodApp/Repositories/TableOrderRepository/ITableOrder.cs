using SeaFoodApp.Models.Entities;

namespace SeaFoodApp.Repositories.TableOrderRepository
{
    public interface ITableOrder
    {
        TableOrder AddTableOrder(TableOrder tableOrder);
        TableOrder EditTableOrder(TableOrder tableOrder);
        TableOrder DeleteTableOrderByOrderId(Guid id);
        TableOrder GetTableOrderByOrderId(Guid id);
        IEnumerable<TableOrder> GetTableOrdersByDate(DateTime dateTime);
        IEnumerable<TableOrder> GetAllTableOrders();
    }
}
