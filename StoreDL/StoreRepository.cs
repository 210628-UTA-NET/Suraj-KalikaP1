using System;
using System.Collections.Generic;
using StoreModel;
using System.Linq;
namespace StoreDL
{
    public class StoreRepository : IStoreRepository
    {
                private StoreDBContext _context;

        public StoreRepository(StoreDBContext p_context)
        {
            _context = p_context;
        }     
        public List<StoreFront> GetAllStoreFronts()
        {
            return _context.StoreFronts.Select(store =>  store ).ToList();
        }
        public StoreFront GetStoreFront(int p_storeFrontId)
        {
            return _context.StoreFronts.FirstOrDefault(store => store.Id == p_storeFrontId);
        }
        public Order AddOrder(StoreFront p_storeFront, Customer p_customer, Order p_order)
        {
            _context.Orders.Add(new Order{
                Id = p_order.Id,
                StoreFrontId = p_storeFront.Id,
                CustomerId = p_customer.Id,
                TotalPrice = p_order.TotalPrice
            });
            _context.SaveChanges();
            return p_order;
        }
        public List<LineItem> GetInventory(int p_storeFrontId)
        {
            return _context.LineItems
                    .Where(lineitem => lineitem.StoreFrontId == p_storeFrontId)
                    .Select(lineitem => lineitem)
                    .ToList();


            
        }
        public List<LineItem>  getAllInventory()
        {
            return _context.LineItems.Select(lineitem => lineitem).ToList();

            
        }
        public List<Order> GetOrders(StoreFront p_storeFront)
        {
            return _context.Orders
                .Where(order => order.StoreFrontId == p_storeFront.Id)
                .Select(order => order)
                .ToList();


        }

        public List<Product> GetAllProducts()
        {
            return _context.Products.Select(prod => prod).ToList();
        }
        public List<Product> GetProducts(int p_storeFrontId)
        {
           List<LineItem> storeInventory = GetInventory(p_storeFrontId);
            List<Product> allProducts = _context.Products.Select(prod => prod).ToList();
            List<Product> storeProducts = new List<Product>();  
             foreach(Product prod in allProducts )
             {
                 foreach(LineItem lineItems in storeInventory)
                {
                 if(prod.Id== lineItems.ProductId)
                 {
                     storeProducts.Add(prod);
                 }
                }
             }
             return storeProducts;
        }

        public LineItem AddInventory(LineItem p_lineItem, int amount)
        {
                

             _context.LineItems.First(
                x=> 
                x.Id == p_lineItem.Id
            ).Quantity = _context.LineItems.First(
                x=> 
                x.Id == p_lineItem.Id
            ).Quantity + amount;
            
            _context.SaveChanges();
        
            return p_lineItem;

        }

        public LineItem RemoveInventory(LineItem p_lineItem, int amount)
        {
                

           int? x =  _context.LineItems.First(
                x=> 
                x.Id == p_lineItem.Id
            ).Quantity = _context.LineItems.First(
                x=> 
                x.Id == p_lineItem.Id
            ).Quantity - amount;
            
            if(x<0)
            {
                throw new System.ArithmeticException(); // so inventory can't be negative
            }

            _context.SaveChanges();
        
            return p_lineItem;

        }
    }

}
