using System;
using System.Collections.Generic;
using StoreModel;

namespace StoreBL
{
    /// <summary>
    /// Handles all the business logic for store model
    /// In charge of processing, cleaning, and validation of data
    /// </summary>
    public interface ICustomerBL
    {
        
        List<Customer> GetAllCustomers();

        Customer AddCustomer(Customer p_cust);
        Customer FindCustomerByName(String p_custName);
        Customer FindCustomerById(int p_customerId);

         List<Order> GetOrders(int p_customerId);
    }



}