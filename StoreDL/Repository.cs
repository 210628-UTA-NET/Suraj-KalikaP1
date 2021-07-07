  using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using StoreModel;
using System.Linq;
namespace StoreDL
{
    public class Repository : IRepository
    {
        private Entities.storeDBContext _context;
        
        public Repository(Entities.storeDBContext p_context)
        {
            _context = p_context;
        }
        
        public Customer AddCustomer(Customer p_cust)
        {   
            // List<Customer> listofCustomers = this.GetAllCustomers();
            // listofCustomers.Add(p_cust);

            // _jsonString = JsonSerializer.Serialize(listofCustomers, new JsonSerializerOptions{WriteIndented = true});
            // File.WriteAllText(_filePath,_jsonString);
            // return p_cust;
            throw new System.NotImplementedException();
        }

        public List<Customer> GetAllCustomers()
        {
            return _context.Customers.Select(
                cust =>
                        new Customer()
                        {
                            Id = cust.Id,
                            Name = cust.CustomerName,
                            Address = cust.Address,
                            Email = cust.Email
                        }
            ).ToList(); 
            
        }

        public Customer GetCustomer(Customer p_cust)
        {
            throw new System.NotImplementedException();
        }
    }
}