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
            String asciiStoreManageMenu = 
            @"

 __    __     _                            _          _   _          
/ / /\ \ \___| | ___ ___  _ __ ___   ___  | |_ ___   | |_| |__   ___ 
\ \/  \/ / _ \ |/ __/ _ \| '_ ` _ \ / _ \ | __/ _ \  | __| '_ \ / _ \
 \  /\  /  __/ | (_| (_) | | | | | |  __/ | || (_) | | |_| | | |  __/
  \/  \/ \___|_|\___\___/|_| |_| |_|\___|  \__\___/   \__|_| |_|\___|
                                                                     
 __ _                 
/ _\ |_ ___  _ __ ___ 
\ \| __/ _ \| '__/ _ \
_\ \ || (_) | | |  __/
\__/\__\___/|_|  \___|
                      
                                                          _   
  /\/\   __ _ _ __   __ _  __ _  ___ _ __ ___   ___ _ __ | |_ 
 /    \ / _` | '_ \ / _` |/ _` |/ _ \ '_ ` _ \ / _ \ '_ \| __|
/ /\/\ \ (_| | | | | (_| | (_| |  __/ | | | | |  __/ | | | |_ 
\/    \/\__,_|_| |_|\__,_|\__, |\___|_| |_| |_|\___|_| |_|\__|
                          |___/                               
                           _ 
  /\/\   ___ _ __  _   _  / \
 /    \ / _ \ '_ \| | | |/  /
/ /\/\ \  __/ | | | |_| /\_/ 
\/    \/\___|_| |_|\__,_\/   
                             
            ";
            Console.WriteLine(asciiStoreManageMenu);
            Console.WriteLine("This is the Management Menu for " + _storeFront.Name +" Located at "+_storeFront.Address);
            Console.WriteLine("[2] Manage Store Inventory");
            Console.WriteLine("[1] View Store Order History");
            Console.WriteLine("[0] Go Back");

        }

        public MenuType YourChoice()
        {
            string userInput = Console.ReadLine();
            StoreOrderHistoryMenu orderHistory = new StoreOrderHistoryMenu(_storeFrontBL);
            switch(userInput)
            {   
                case "0":
                    return MenuType.StoreMenu;
                case "1":
                    orderHistory.currentStore(_storeFront);
                    return MenuType.StoreOrderHistoryMenu;
                case "2":
                    currentStore(_storeFront);
                    return MenuType.ShowInventoryMenu;
                default:
                    currentStore(_storeFront);
                Console.WriteLine("Invalid Selection");
                Console.WriteLine("Press Enter to Continue.");
                Console.ReadLine();
                    return MenuType.StoreManageMenu;
            }
        }
    }
}