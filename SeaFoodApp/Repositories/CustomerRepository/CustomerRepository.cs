using SeaFoodApp.Models.Data;
using SeaFoodApp.Models.Entities;

namespace SeaFoodApp.Repositories.CustomerRepository
{
    public class CustomerRepository : ICustomer
    {
        private readonly ApplicationDbContext _dbContext;
        public CustomerRepository(ApplicationDbContext _dbContext)
        {
            this._dbContext = _dbContext;
        }
        public Customer AddCustomer(Customer customer)
        {
            _dbContext.Customers.Add(customer);
            _dbContext.SaveChanges();
            return customer;
        }

        public Customer DeleteCustomerById(Guid id)
        {
            Customer customer = GetCustomerById(id);
            if (customer == null)
            {
                return null;
            }
            _dbContext.Customers.Remove(customer);
            _dbContext.SaveChanges();
            return customer;
        }

        public Customer EditCustomer(Customer customer)
        {
            Customer customer1 = GetCustomerById(customer.Id);
            if (customer == null)
            {
                return null;
            }
            customer1.Name = customer.Name;
            _dbContext.SaveChanges();
            return customer1;
        }

        public IEnumerable<Customer> GelAllCustomers()
        {
            return _dbContext.Customers.ToList();
        }

        public Customer GetCustomerById(Guid id)
        {
            return _dbContext.Customers.FirstOrDefault(e => e.Id == id);
        }
    }
}
