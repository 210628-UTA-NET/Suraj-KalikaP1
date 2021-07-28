  using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using StoreModel;
using System.Linq;
using Microsoft.EntityFrameworkCore;
namespace StoreDL
{
    public class CustomerRepository : ICustomerRepository
    {
        private  StoreDBContext _context;
        
        public CustomerRepository(StoreDBContext p_context)
        {
            _context = p_context;
        }
        
        public Customer AddCustomer(Customer p_cust)
        {   

            _context.Customers.Add(p_cust);
            _context.SaveChanges();
            return p_cust;
        }

        public Customer FindCustomerById(int p_customerId)
        {
            return _context.Customers.Find(p_customerId);
        }
        public Customer FindCustomerByName(String p_customerName)
        {
            return _context.Customers.AsNoTracking().FirstOrDefault(cust => cust.Name.Contains(p_customerName)); //If this works try changing this to a list and using Where instead of FirstOrDefault

          
        }

        public List<Customer> GetAllCustomers()
        {
            return _context.Customers.Select( cust => cust ).ToList(); 
        }

        public List<Order> GetOrders(int p_customerId)
        {

            return _context.Orders
                .Where(order => order.CustomerId == p_customerId)
                .Select(order => order)
                .ToList();

            
        }

    }
}