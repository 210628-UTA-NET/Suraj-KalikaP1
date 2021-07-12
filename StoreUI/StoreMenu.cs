using System;
using StoreModel;
using StoreBL;
using System.Collections.Generic;
namespace StoreUI
{
    public class StoreMenu : IMenu
    {
        private static StoreFront store = new StoreFront();
        private IStoreFrontBL _storeBL;

        public StoreMenu(StoreFrontBL p_storeBL)
        {
            _storeBL = p_storeBL;
        }
        public void Menu()
        {
           Console.WriteLine("Welcome to the Store Menu!");
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("[1] Choose a Store");
            Console.WriteLine("[0] Go Back");
        }

        public MenuType YourChoice()
        {
            string userChoice = Console.ReadLine();

            switch(userChoice)
            {
                case "0":
                    return MenuType.MainMenu;
                case "1":
                    List<StoreFront> stores = _storeBL.GetAllStoreFronts();
                    foreach(StoreFront store in stores)
                    {
                        Console.WriteLine(store);
                    }
                    Console.WriteLine("Select a Store based on Id");
                    string storeChoice = Console.ReadLine();
                    switch(storeChoice)
                    {
                        case "1":
                        store.Id = 1;
                        return MenuType.StoreManageMenu;
                        default:
                        Console.WriteLine("Input was not correct");
                        Console.WriteLine("Press Enter to continue");
                        Console.ReadLine();
                        return MenuType.StoreMenu;
                        
                    }

                default:
                    return MenuType.StoreMenu;
            }
        }
    }
}