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
            List<LineItems> inventory=  _context.LineItems.Select(
                inventory =>
                    new LineItems
                    {   
                        Id = inventory.Id,
                        ProductId = (int)inventory.ProductId,
                        StoreId = (int)inventory.StoreId,
                        Quantity = (int)inventory.Quantity
                    }
            ).ToList();

            List<Products> allProducts = _context.Products.Select(
                prod =>
                    new Products
                    {
                        Id =  (int) prod.Id,
                        Name = prod.Name,
                        Description = prod.Description,
                        Category = prod.Category,
                        Price = (double)prod.Price
                    }
            ).ToList();

            foreach(LineItems lineItems in inventory)
            {
                foreach(Products prod in allProducts )
                {
                    if(lineItems.ProductId == prod.Id){
                        lineItems.ProductName = prod.Name;
                    }

                }
            }

            

            return inventory;
            
        }
        public List<Orders> GetOrders(StoreFront p_storeFront)
        {
            throw new NotImplementedException();
        }

        public List<Products> GetProducts(StoreFront p_storeFront)
        {   
            List<LineItems> storeInventory = GetInventory(p_storeFront);
            List<Products> allProducts = _context.Products.Select(
                prod =>
                    new Products
                    {
                        Id =  (int) prod.Id,
                        Name = prod.Name,
                        Description = prod.Description,
                        Category = prod.Category,
                        Price = (double)prod.Price
                    }
            ).ToList();
            List<Products> storeProducts = new List<Products>();  
             foreach(Products prod in allProducts )
             {
                 foreach(LineItems lineItems in storeInventory)
                {
                 if(prod.Id== lineItems.ProductId)
                 {
                     storeProducts.Add(prod);
                 }

                }
             }
             return storeProducts;
        }

        public LineItems AddInventory(LineItems p_lineItem, int amount)
        {
            throw new NotImplementedException();
        }
    }

}
