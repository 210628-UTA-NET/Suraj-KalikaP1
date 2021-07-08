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

            _context.Customers.Add(new Entities.Customer{
                Id = p_cust.Id,
                CustomerName = p_cust.Name,
                Address = p_cust.Address,
                Email = p_cust.Email
            });

            _context.SaveChanges();
            return p_cust;
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