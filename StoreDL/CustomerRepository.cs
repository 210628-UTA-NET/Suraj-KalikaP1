  using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using StoreModel;
using System.Linq;
namespace StoreDL
{
    public class CustomerRepository : ICustomerRepository
    {
        private Entities.customerDBContext _context;
        
        public CustomerRepository(Entities.customerDBContext p_context)
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

        public Customer FindCustomerByName(String p_customerName)
        {
            List<Customer> allCustomers = GetAllCustomers();
            foreach(Customer cust in allCustomers)
            {   
                if(p_customerName == cust.Name)
                {
                    return cust; // Will return the first Customer object if it contains the Inputted Name
                                // Either Validation or improved logic to show List of Customers Necessary
                }
                    
            }
            
           throw new System.IndexOutOfRangeException();
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
                            Email = cust.Email,
                            PhoneNumber = cust.PhoneNumber
                        }
            ).ToList(); 
            
        }

        public Customer GetCustomer(Customer p_cust)
        {
            throw new System.NotImplementedException();
        }
    }
}