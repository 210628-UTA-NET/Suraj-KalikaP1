using System;
using System.Collections.Generic;
using StoreDL;
using StoreModel;
namespace StoreBL
{

    public class StoreFrontBL : IStoreFrontBL
    {
        private IStoreRepository _repo;

        public StoreFrontBL(IStoreRepository p_repo)
        {
            _repo = p_repo;
        }
        public List<StoreFront> GetAllStoreFronts()
        {
            return _repo.GetAllStoreFronts();
        }

        public List<LineItems> GetInventory(StoreFront p_storeFront)
        {
            return _repo.GetInventory(p_storeFront);
        }

        public List<Orders> GetOrders(StoreFront p_storeFront)
        {
            return _repo.GetOrders(p_storeFront);
        }

        public List<Products> GetProducts(StoreFront p_storeFront)
        {
            return _repo.GetProducts(p_storeFront);
        }
    }

}