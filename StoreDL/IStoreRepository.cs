using System;
using System.Collections.Generic;
using StoreModel;

namespace StoreDL
{
  public interface IStoreRepository
    {
       List<Product> GetAllProducts();
        List<StoreFront> GetAllStoreFronts();
         List<LineItem> GetInventory(int p_storeFrontId);
          StoreFront GetStoreFront(int p_storeFrontId);
         LineItem AddInventory(LineItem p_lineItem, int amount);
          List<LineItem>  getAllInventory();
          LineItem RemoveInventory(LineItem p_lineItem, int amount);
         List<Product> GetProducts(int p_storeFrontId);
         List<Order> GetOrders(StoreFront p_storeFront);
         Order AddOrder(StoreFront p_storeFront, Customer p_customer, Order p_order);
         
     }

}
