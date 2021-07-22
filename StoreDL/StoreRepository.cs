using System;
using System.Collections.Generic;
using StoreModel;
using System.Linq;
namespace StoreDL
{
    public class StoreRepository : IStoreRepository
    {
                private readonly StoreDBContext _context;

        public StoreRepository(StoreDBContext p_context)
        {
            _context = p_context;
        }     
        public List<StoreFront> GetAllStoreFronts()
        {
            return _context.StoreFronts.Select(store =>  store ).ToList();
        }
        public Order AddOrder(StoreFront p_storeFront, Customer p_customer, Order p_order)
        {
            _context.Orders.Add(new Order{
                Id = p_order.Id,
                storeId = p_storeFront.Id,
                customerId = p_customer.Id,
                TotalPrice = p_order.TotalPrice
            });
            _context.SaveChanges();
            return p_order;
        }
        public List<LineItem> GetInventory(StoreFront p_storeFront)
        {
            return _context.LineItems
                    .Where(lineitem => lineitem.StoreFrontId == p_storeFront.Id)
                    .Select(lineitem => lineitem)
                    .ToList();


            /*List<LineItem> allInventory = getAllInventory();
            List<LineItem> storeInventory = new List<LineItem>();

            foreach(LineItem inventory in allInventory)
            {
                if(inventory.StoreId == p_storeFront.Id)
                    storeInventory.Add(inventory);
            }
            return storeInventory;*/
        }
        public List<LineItem>  getAllInventory()
        {
            return _context.LineItems.Select(lineitem => lineitem).ToList();




            /*List<LineItem> inventory=  _context.LineItems.Select(
                inventory =>
                    new LineItem
                    {   
                        Id = inventory.Id,
                        ProductId = (int)inventory.ProductId,
                        StoreId = (int)inventory.StoreId,
                        Quantity = (int)inventory.Quantity
                    }
            ).ToList();

            List<Product> allProducts = _context.Products.Select(
                prod =>
                    new Product
                    {
                        Id =  (int) prod.Id,
                        Name = prod.Name,
                        Description = prod.Description,
                        Category = prod.Category,
                        Price = (double)prod.Price
                    }
            ).ToList();

            foreach(LineItem lineItems in inventory)
            {
                foreach(Product prod in allProducts )
                {
                    if(lineItems.ProductId == prod.Id){
                        lineItems.ProductName = prod.Name;
                    }

                }
            }

            return inventory;*/
            
        }
        public List<Order> GetOrders(StoreFront p_storeFront)
        {
            return _context.Orders
                .Where(order => order.storeId == p_storeFront.Id)
                .Select(order => order)
                .ToList();

            /*List<Order> allOrders = _context.Orders.Select(
                order=>
                    new Order
                    {
                        Id = order.Id,
                        storeId = (int)order.StoreId,
                        customerId =(int)order.CustomerId,
                        TotalPrice = (double)order.TotalPrice
                    }
            ).ToList();
            List<Order> storeOrders = new List<Order>();
            foreach(Order order in allOrders)
            {
                if(order.storeId == p_storeFront.Id)
                    {
                        storeOrders.Add(order);
                    }
            }
            return storeOrders;*/
        }

        public List<Product> GetProducts(StoreFront p_storeFront)
        {
           List<LineItem> storeInventory = GetInventory(p_storeFront);
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
