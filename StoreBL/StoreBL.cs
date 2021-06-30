using System;
using System.Collections.Generic;
using StoreDL;
using StoreModel;
namespace StoreBL
{
    public class StoreBL : IStoreBL
    {

        private IRepository _repo;
        public StoreBL(IRepository p_repo)
        {
            _repo = p_repo;
        }
        public List<Customer> GetAllCustomers()
        {
            return _repo.GetAllCustomers();
        }
    }
}
