using System;
using System.Collections.Generic;
using StoreModel;

namespace StoreBL
{
    /// <summary>
    /// Handles all the business logic for store model
    /// In charge of processing, cleaning, and validation of data
    /// </summary>
    public interface IStoreBL
    {
        
        List<Customer> GetAllCustomers();
    }



}