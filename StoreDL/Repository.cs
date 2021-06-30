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
        {   try{
            _jsonString = p_cust.ToString();
            File.WriteAllText(_filePath, _jsonString);
        }
        catch(System.Exception)
        {
            throw new Exception("Invalid Customer details");
        }
          return p_cust; // Need this return need to figure out another return here but this will be temp
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