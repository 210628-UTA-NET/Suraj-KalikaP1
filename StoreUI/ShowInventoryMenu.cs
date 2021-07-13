using System;
using StoreModel;
using StoreBL;
using System.Collections.Generic;

namespace StoreUI
{
    public class ShowInventoryMenu : IMenu
    {        
        private IStoreFrontBL _storeFrontBL;

        public ShowInventoryMenu(IStoreFrontBL p_storeFrontBL)
        {
            _storeFrontBL = p_storeFrontBL;
        }
          public void Menu()
         {
             Console.WriteLine("Inventory Managegement Menu for "+StoreManageMenu._storeFront.Name + " Located at "+StoreManageMenu._storeFront.Address);
             Console.WriteLine("[2] View Store Inventory");
             Console.WriteLine("[1] Replenish Store Inventory");
             Console.WriteLine("[0] Go Back");

         }

          public MenuType YourChoice()
         {
             List<LineItems> lineItems = _storeFrontBL.GetInventory(StoreManageMenu._storeFront);
            string userInput = Console.ReadLine();
            switch(userInput)
            {
                case "0":
                    return MenuType.StoreManageMenu;
                case "1":
                Console.WriteLine("Which Item(Id) to restock?");
                Console.WriteLine("Inventory");
                    Console.WriteLine("----------");
                   
                    foreach(LineItems item in lineItems)
                    {
                        Console.WriteLine(item);
                    }
                    string inventoryInput = Console.ReadLine();
                    foreach(LineItems item in lineItems)
                    {
                        if(inventoryInput == item.Id.ToString())
                        {
                            Console.WriteLine("How many "+item.ProductName+" would you like to add?");
                            string amount = Console.ReadLine();
                            //_storeFrontBL.AddInventory
                            
                        }
                    }
                    return MenuType.ShowInventoryMenu;
                case "2": 
                Console.WriteLine("Inventory");
                    Console.WriteLine("----------");
                   
                    foreach(LineItems item in lineItems)
                    {
                        Console.WriteLine(item);
                    }
                    Console.WriteLine("Press ENTER to continue");
                    Console.ReadLine();
                    return MenuType.ShowInventoryMenu;
                default:
                Console.WriteLine("Invalid Selection");
                    return MenuType.ShowInventoryMenu;
            }
         }
    
    }
}