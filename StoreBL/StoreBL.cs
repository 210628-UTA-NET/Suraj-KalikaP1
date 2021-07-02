using System;
using System.Collections.Generic;
using StoreDL;
using StoreModel;
namespace StoreBL
{
    public class SBL : IStoreBL
    {

        private IRepository _repo;
        public SBL(IRepository p_repo)
        {
            _repo = p_repo;
        }

        public Customer AddCustomer(Customer p_cust)
        {
            p_cust.Email.Contains("@");
            return _repo.AddCustomer(p_cust);
        }

        public List<Customer> GetAllCustomers()
        {
            return _repo.GetAllCustomers();
        }
    }
}
