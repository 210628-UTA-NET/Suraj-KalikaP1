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
        public List<Customer> GetAllCustomers()
        {
            return _repo.GetAllCustomers();
        }
    }
}
