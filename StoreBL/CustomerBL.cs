using System;
using System.Collections.Generic;
using StoreDL;
using StoreModel;
namespace StoreBL
{
    public class CustomerBL : ICustomerBL
    {

        private ICustomerRepository _repo;
        public CustomerBL(ICustomerRepository p_repo)
        {
            _repo = p_repo;
        }

       
        public Customer AddCustomer(Customer p_cust)
        {
            p_cust.Email.Contains("@");
            return _repo.AddCustomer(p_cust);
        }

        public Customer FindCustomerByName(String p_custName)
        {
            return _repo.FindCustomerByName(p_custName);
        }

        public List<Customer> GetAllCustomers()
        {
            return _repo.GetAllCustomers();
        }
    }
}
