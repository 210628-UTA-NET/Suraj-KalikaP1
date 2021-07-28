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

        public LineItem AddInventory(LineItem p_lineitem, int amount)
        {
            if(amount<0)
            {
                throw new System.ArithmeticException();
            }
            
           return _repo.AddInventory(p_lineitem,amount);
        }

        public LineItem RemoveInventory(LineItem p_lineItem, int amount)
        {
            if(amount<0)
            {
                throw new System.ArithmeticException();
            }
            return _repo.RemoveInventory(p_lineItem,amount);
        }

        public List<StoreFront> GetAllStoreFronts()
        {
            return _repo.GetAllStoreFronts();
        }
        public StoreFront GetStoreFront(int p_storeFrontId)
        {
            return _repo.GetStoreFront(p_storeFrontId);
        }
        public List<LineItem> GetInventory(int p_storeFrontId)
        {
            return _repo.GetInventory(p_storeFrontId);
        }

        public List<LineItem>  getAllInventory()
        {
            return _repo.getAllInventory();
        }
        public List<Order> GetOrders(StoreFront p_storeFront)
        {
            return _repo.GetOrders(p_storeFront);
        }

        public List<Product> GetAllProducts()
        {
            return _repo.GetAllProducts();
        }
        public List<Product> GetProducts(int p_storeFrontId)
        {
            return _repo.GetProducts(p_storeFrontId);
        }
        public Order AddOrder(StoreFront p_storeFront, Customer p_customer, Order p_order)
        {
            return _repo.AddOrder(p_storeFront,p_customer,p_order);
        }


    }

}