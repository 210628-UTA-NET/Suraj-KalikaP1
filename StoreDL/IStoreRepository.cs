using System;
using System.Collections.Generic;
using StoreModel;

namespace StoreDL
{
  public interface IStoreRepository
    {
        List<StoreFront> GetAllStoreFronts();
         List<LineItem> GetInventory(StoreFront p_storeFront);

         LineItem AddInventory(LineItem p_lineItem, int amount);
          LineItem RemoveInventory(LineItem p_lineItem, int amount);
         List<Product> GetProducts(StoreFront p_storeFront);
         List<Order> GetOrders(StoreFront p_storeFront);
         Order AddOrder(StoreFront p_storeFront, Customer p_customer, Order p_order);
         
     }

}
