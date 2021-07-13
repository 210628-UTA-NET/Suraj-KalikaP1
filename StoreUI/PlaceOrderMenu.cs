using System;
using System.Collections.Generic;
using StoreModel;
using StoreBL;

namespace StoreUI
{
    public class PlaceOrderMenu : IMenu
    {
        private IStoreFrontBL _storeFrontBL;
        private ICustomerBL _customerBL;

        public PlaceOrderMenu(IStoreFrontBL p_storeFrontBL, ICustomerBL p_customerBL)
        {
            _storeFrontBL = p_storeFrontBL;
            _customerBL = p_customerBL;
        }
        public void Menu()
        {
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
            string userChoice = Console.ReadLine();
            List<StoreFront> stores = _storeFrontBL.GetAllStoreFronts();
            switch(userChoice)
            {   case "0":
                    return MenuType.FindCustomerMenu;
                case "1":
                    List<Products> storeProducts = _storeFrontBL.GetProducts(stores[0]);
                    foreach(Products prod in storeProducts)
                    {
                        Console.WriteLine(prod);
                    }
                    Console.WriteLine("Press ENTER to continue");
                    Console.ReadLine();
                    return MenuType.PlaceOrderMenu;
                default:
                Console.WriteLine("Invalid store selection");
                return MenuType.PlaceOrderMenu;
            }
            
        }
    }
}