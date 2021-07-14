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

        public LineItems AddInventory(LineItems p_lineitem, int amount)
        {
            if(amount<0)
            {
                throw new System.ArithmeticException();
            }
            
           return _repo.AddInventory(p_lineitem,amount);
        }

        public LineItems RemoveInventory(LineItems p_lineItem, int amount)
        {
            if(amount<0)
            {
                throw new System.ArithmeticException();
            }
            if(p_lineItem.Quantity-amount<=0)
            {
                throw new System.ArithmeticException();
            }
            return _repo.RemoveInventory(p_lineItem,amount);
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
        public Orders AddOrder(StoreFront p_storeFront, Customer p_customer, Orders p_order)
        {
            return _repo.AddOrder(p_storeFront,p_customer,p_order);
        }


    }

}