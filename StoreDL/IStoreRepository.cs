using System;
using System.Collections.Generic;
using StoreModel;

namespace StoreDL
{
  public interface IStoreRepository
    {
        List<StoreFront> GetAllStoreFronts();
         List<LineItems> GetInventory(StoreFront p_storeFront);
         List<Products> GetProducts(StoreFront p_storeFront);
         List<Orders> GetOrders(StoreFront p_storeFront);
     }

}
