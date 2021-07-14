using System;
using StoreBL;
using StoreModel;
using System.Collections.Generic;
namespace StoreUI
{
    public class StoreOrderHistoryMenu : IMenu
    {

        private IStoreFrontBL _storeBL;
        public StoreOrderHistoryMenu(IStoreFrontBL p_StoreFrontBL)
        {
            _storeBL= p_StoreFrontBL;
        }
        
        public static StoreFront _storeFront = new StoreFront();
        public void Menu()
        {
            List<Orders> storeOrderHistory = _storeBL.GetOrders(_storeFront);
            Console.WriteLine("Store Order History for "+_storeFront.Name+" at "+_storeFront.Address);
            Console.WriteLine("--------------------------------");
            foreach(Orders order in storeOrderHistory)
            {
                Console.WriteLine(order);
            }
            Console.WriteLine("--------------------------------");
            Console.WriteLine("[0] Go back");

        }
    public void currentStore(StoreFront p_storeFront)
        {
            _storeFront = p_storeFront;
        }
        public MenuType YourChoice()
        {
           string userInput = Console.ReadLine();
           switch(userInput)
           {
               case "0":
                    return MenuType.StoreManageMenu;
                default:
                Console.WriteLine("Invalid Selection");
                Console.WriteLine("Press Enter to Continue.");
                Console.ReadLine();
                    return MenuType.StoreOrderHistoryMenu;
           }
        }
    }
}