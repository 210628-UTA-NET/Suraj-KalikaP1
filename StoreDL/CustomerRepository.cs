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
        private StoreDBContext _context;
        
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

        public Customer FindCustomerByName(String p_customerName)
        {
            return _context.Customers.AsNoTracking().FirstOrDefault(cust => cust.Name.Contains(p_customerName)); //If this works try changing this to a list and using Where instead of FirstOrDefault

           /* List<Customer> allCustomers = GetAllCustomers();
            foreach(Customer cust in allCustomers)
            {   
                if(p_customerName.Contains(cust.Name))
                {
                    return cust; // Will return the first Customer object if it contains the Inputted Name
                                // Either Validation or improved logic to show List of Customers Necessary
                }
                    
            }
            
           throw new System.IndexOutOfRangeException();*/
        }

        public List<Customer> GetAllCustomers()
        {
            return _context.Customers.Select( cust => cust ).ToList(); 
        }

        public List<Order> GetOrders(Customer p_customer)
        {

            return _context.Orders
                .Where(order => order.customerId == p_customer.Id)
                .Select(order => order)
                .ToList();

            /*List<Order> allOrders = _context.Orders.Select(
                order=>
                    new Order
                    {   Id = order.Id,
                        storeId = (int)order.StoreId,
                        customerId =(int)order.CustomerId,
                        TotalPrice = (double)order.TotalPrice
                    }
            ).ToList();
            List<Order> customerOrders = new List<Order>();
            foreach(Order order in allOrders)
            {
                if(order.customerId == p_customer.Id)
                    {
                        customerOrders.Add(order);
                    }
            }
            return customerOrders;*/
        }

    }
}