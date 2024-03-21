using SeaFoodApp.Models.Entities;

namespace SeaFoodApp.Repositories.CustomerRepository
{
    public interface ICustomer
    {
        Customer AddCustomer(Customer customer);
        Customer EditCustomer(Customer customer);
        Customer DeleteCustomerById(Guid id);
        Customer GetCustomerById(Guid id);
        IEnumerable<Customer> GelAllCustomers();
    }
}
