using System;
using System.Collections.Generic;
using StoreModel;

namespace StoreBL
{
    public interface IStoreFrontBL
    {
        List<StoreFront> GetAllStoreFronts();
         List<LineItem> GetInventory(int p_storeFrontId);
        List<LineItem>  getAllInventory();
          List<Product> GetProducts(int p_storeFrontId);
           List<Product> GetAllProducts();
        StoreFront GetStoreFront(int p_storeFrontId);
         LineItem AddInventory(LineItem p_lineitem, int amount);
         LineItem RemoveInventory(LineItem p_lineItem, int amount);
         List<Order> GetOrders(StoreFront p_storeFront);

         Order AddOrder(StoreFront p_storeFront, Customer p_customer, Order p_order);
    }
}