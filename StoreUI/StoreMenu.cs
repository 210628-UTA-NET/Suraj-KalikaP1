using System;
using StoreModel;
using StoreBL;
using System.Collections.Generic;
namespace StoreUI
{
    public class StoreMenu : IMenu
    {
        private static StoreFront store = new StoreFront();
        private IStoreFrontBL _storeFrontBL;
        
        public StoreMenu(StoreFrontBL p_storeFrontBL)
        {
            _storeFrontBL = p_storeFrontBL;
        }
        public void Menu()
        {
           Console.WriteLine("Welcome to the Store Menu!");
            Console.WriteLine("Please Select a Store");
             List<StoreFront> stores = _storeFrontBL.GetAllStoreFronts();
                foreach(StoreFront store in stores)
                {
                    Console.WriteLine("["+store.Id+"] "+store.Name +" Located at "+ store.Address);
                }
            Console.WriteLine("[0] Go Back");
        }

        public MenuType YourChoice()
        {
            List<StoreFront> stores = _storeFrontBL.GetAllStoreFronts();//had to run this again should figure out how to only declare list once
            StoreManageMenu storeChoice = new StoreManageMenu(_storeFrontBL);
            string userChoice = Console.ReadLine();
            switch(userChoice)
            {
                case "0":
                    return MenuType.MainMenu;
                case "1":
                    storeChoice.currentStore(stores[0]); // index starts at 0 for the list so 1-1 = 0
                    return MenuType.StoreManageMenu;
                default:
                    Console.WriteLine("Invalid store selection");
                    return MenuType.StoreMenu;
            }
        }
    }
}