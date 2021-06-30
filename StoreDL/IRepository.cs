using System;
using System.Collections.Generic;
using StoreModel;
namespace StoreDL
{
    public interface IRepository
    {
       List<Customer> GetAllCustomers(); 

       Customer GetCustomer(Customer p_cust);

       Customer AddCustomer(Customer p_cust);
    }
}
