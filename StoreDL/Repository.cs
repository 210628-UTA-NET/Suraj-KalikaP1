  using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using StoreModel;

namespace StoreDL
{
    public class Repository : IRepository
    {
        private const string _filePath = "./../StoreDL/Database/Customer.json";
        private string _jsonString;
        public Customer AddCustomer(Customer p_cust)
        {
            throw new NotImplementedException();
        }

        public List<Customer> GetAllCustomers()
        {
            try{
                _jsonString = File.ReadAllText(_filePath);
            }
            catch(System.Exception)
            {
                throw new Exception("File path is invalid");
            }
            return JsonSerializer.Deserialize<List<Customer>>(_jsonString);
        }

        public Customer GetCustomer(Customer p_cust)
        {
            throw new System.NotImplementedException();
        }
    }
}