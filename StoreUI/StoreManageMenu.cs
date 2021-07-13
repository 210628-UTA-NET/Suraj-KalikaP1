using System;
using System.Collections.Generic;
using StoreBL;
using StoreModel;

namespace StoreUI
{
    public class StoreManageMenu : IMenu
    {

        public static StoreFront _storeFront = new StoreFront();

        private static IStoreFrontBL _storeFrontBL;

        public StoreManageMenu(IStoreFrontBL p_storeFrontBL)
        {
            _storeFrontBL = p_storeFrontBL;
        }
        public void currentStore(StoreFront p_storeFront)
        {
            _storeFront = p_storeFront;
        }
        public void Menu()
        {
            Console.WriteLine("Welcome to the Store Management Menu");
            Console.WriteLine("This is the Management Menu for " + _storeFront.Name +" Located at "+_storeFront.Address);
            Console.WriteLine("[2] Manage Store Inventory");
            Console.WriteLine("[1] View Store Order History");
            Console.WriteLine("[0] Go Back");

        }

        public MenuType YourChoice()
        {
            string userInput = Console.ReadLine();

            switch(userInput)
            {   
                case "0":
                    return MenuType.StoreMenu;
                case "1":
                //Need to add implementation here 
                    return MenuType.StoreManageMenu;
                case "2":
                    currentStore(_storeFront);
                    return MenuType.ShowInventoryMenu;
                default:
                    currentStore(_storeFront);
                Console.WriteLine("Invalid Selection");
                    return MenuType.StoreManageMenu;
            }
        }
    }
}