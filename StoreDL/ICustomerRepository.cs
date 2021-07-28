using System;
using System.Collections.Generic;
using StoreModel;
namespace StoreDL
{
    public interface ICustomerRepository
    {
       List<Customer> GetAllCustomers(); 

       Customer AddCustomer(Customer p_cust);

         List<Order> GetOrders(int p_customerId);
       Customer FindCustomerByName(String p_name);
       Customer FindCustomerById(int p_customerId);
    }
}
