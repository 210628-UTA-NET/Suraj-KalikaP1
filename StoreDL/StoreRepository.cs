using System;
using System.Collections.Generic;
using StoreModel;
using System.Linq;
namespace StoreDL
{
    public class StoreRepository : IStoreRepository
    {
                private Entities.customerDBContext _context;

        public StoreRepository(Entities.customerDBContext p_context)
        {
            _context = p_context;
        }     
        public List<StoreFront> GetAllStoreFronts()
        {
            return _context.StoreFronts.Select(
                store =>
                    new StoreFront()
                    {
                        Id = store.Id,
                        Name = store.StoreName,
                        Address = store.Address
                    }
            ).ToList();
        }

        public List<LineItems> GetInventory(StoreFront p_storeFront)
        {
            List<LineItems> allInventory = getAllInventory();
            List<LineItems> storeInventory = new List<LineItems>();

            foreach(LineItems inventory in allInventory)
            {
                if(inventory.StoreId == p_storeFront.Id)
                    storeInventory.Add(inventory);
            }
            return storeInventory;
        }
        public List<LineItems>  getAllInventory()
        {
            return  _context.LineItems.Select(
                inventory =>
                    new LineItems
                    {   
                        Id = inventory.Id,
                        ProductId = (int)inventory.ProductId,
                        StoreId = (int)inventory.StoreId,
                        Quantity = (int)inventory.Quantity
                    }
            ).ToList();
        }
        public List<Orders> GetOrders(StoreFront p_storeFront)
        {
            throw new NotImplementedException();
        }

        public List<Products> GetProducts(StoreFront p_storeFront)
        {
            throw new NotImplementedException();
        }
    }

}
