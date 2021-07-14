using System;
using System.Collections.Generic;
using StoreModel;
namespace StoreDL
{
    public interface ICustomerRepository
    {
       List<Customer> GetAllCustomers(); 

       Customer AddCustomer(Customer p_cust);

         List<Orders> GetOrders(Customer p_customer);
       Customer FindCustomerByName(String p_name);
    }
}
