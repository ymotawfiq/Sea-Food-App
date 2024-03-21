using Microsoft.EntityFrameworkCore;
using SeaFoodApp.Models.Data;
using SeaFoodApp.Models.Entities;

namespace SeaFoodApp.Repositories.CustomerInfoRepository
{
    public class CustomerInfoRepository : ICustomerInfo
    {
        private readonly ApplicationDbContext _dbContext;
        public CustomerInfoRepository(ApplicationDbContext _dbContext)
        {
            this._dbContext = _dbContext;
        }
        public CustomerInfo AddCustomerInfo(CustomerInfo customerInfo)
        {
            _dbContext.CustomerInfo.Add(customerInfo);
            _dbContext.SaveChanges();
            return customerInfo;
        }

        public CustomerInfo DeleteCustomerInfoById(Guid id)
        {
            CustomerInfo customerInfo = GetCustomerInfoById(id);
            if (customerInfo == null)
            {
                return null;
            }
            _dbContext.CustomerInfo.Remove(customerInfo);
            _dbContext.SaveChanges();
            return customerInfo;
        }

        public CustomerInfo EditCustomerInfo(CustomerInfo customerInfo)
        {
            CustomerInfo customerInfo1 = GetCustomerInfoById(customerInfo.Id);
            if (customerInfo == null)
            {
                return null;
            }
            customerInfo1.PhoneNumber = customerInfo.PhoneNumber;
            customerInfo1.Address = customerInfo.Address;
            _dbContext.SaveChanges();
            return customerInfo1;
        }

        public IEnumerable<CustomerInfo> GelAllCustomerInfoByCustomerId(Guid customerId)
        {
            return (
                from e in GelAllCustomersInfo()
                where e.CustomerId==customerId
                select e
                );
        }

        public IEnumerable<CustomerInfo> GelAllCustomersInfo()
        {
            return _dbContext.CustomerInfo.Include(e=>e.Customer).ToList();
        }

        public CustomerInfo GetCustomerInfoById(Guid id)
        {
            return _dbContext.CustomerInfo.FirstOrDefault(e => e.Id == id);
        }
    }
}
