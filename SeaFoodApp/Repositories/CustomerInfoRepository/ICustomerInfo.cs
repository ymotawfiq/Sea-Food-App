using SeaFoodApp.Models.Entities;

namespace SeaFoodApp.Repositories.CustomerInfoRepository
{
    public interface ICustomerInfo
    {
        CustomerInfo AddCustomerInfo(CustomerInfo customerInfo);
        CustomerInfo EditCustomerInfo(CustomerInfo customerInfo);
        CustomerInfo DeleteCustomerInfoById(Guid id);
        CustomerInfo GetCustomerInfoById(Guid id);
        IEnumerable<CustomerInfo> GelAllCustomersInfo();
        IEnumerable<CustomerInfo> GelAllCustomerInfoByCustomerId(Guid customerId);
    }
}
