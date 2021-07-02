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
            List<Customer> listofCustomers = this.GetAllCustomers();
            listofCustomers.Add(p_cust);

            _jsonString = JsonSerializer.Serialize(listofCustomers, new JsonSerializerOptions{WriteIndented = true});
            File.WriteAllText(_filePath,_jsonString);
            return p_cust;
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