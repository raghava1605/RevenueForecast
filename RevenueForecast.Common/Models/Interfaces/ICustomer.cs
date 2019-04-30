using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevenueForecast.Common.Models.Interfaces
{
    public interface ICustomer
    {
        IEnumerable<CustomerModel> GetCustomers();
        CustomerModel GetCustomerById(int customerId);
        string SaveCustomerDetails(CustomerModel customerModel);
        string DeleteCustomer(int customerId);
    }
}
