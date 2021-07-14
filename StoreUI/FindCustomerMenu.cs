using System;
using System.Collections.Generic;
using StoreBL;
using StoreModel;

namespace StoreUI
{

    public class FindCustomerMenu : IMenu
    {
    private static Customer customer = new Customer();
    
    private ICustomerBL _customerBL;

    private IStoreFrontBL _storeBL;

    public FindCustomerMenu(StoreFrontBL p_storeBL, CustomerBL p_custBL)
    {
        _customerBL = p_custBL;
        _storeBL = p_storeBL;
    }
        public void Menu()
        {   
            String asciiFindCustomerMenu = 
            @"
            
 __    __     _                            _          _   _          
/ / /\ \ \___| | ___ ___  _ __ ___   ___  | |_ ___   | |_| |__   ___ 
\ \/  \/ / _ \ |/ __/ _ \| '_ ` _ \ / _ \ | __/ _ \  | __| '_ \ / _ \
 \  /\  /  __/ | (_| (_) | | | | | |  __/ | || (_) | | |_| | | |  __/
  \/  \/ \___|_|\___\___/|_| |_| |_|\___|  \__\___/   \__|_| |_|\___|
                                                                     
   ___ _           _     ___          _                            
  / __(_)_ __   __| |   / __\   _ ___| |_ ___  _ __ ___   ___ _ __ 
 / _\ | | '_ \ / _` |  / / | | | / __| __/ _ \| '_ ` _ \ / _ \ '__|
/ /   | | | | | (_| | / /__| |_| \__ \ || (_) | | | | | |  __/ |   
\/    |_|_| |_|\__,_| \____/\__,_|___/\__\___/|_| |_| |_|\___|_|   
                                                                   
                           _ 
  /\/\   ___ _ __  _   _  / \
 /    \ / _ \ '_ \| | | |/  /
/ /\/\ \  __/ | | | |_| /\_/ 
\/    \/\___|_| |_|\__,_\/   
            ";
            Console.WriteLine(asciiFindCustomerMenu);
            Console.WriteLine("How would you like to search for a Customer?");
            Console.WriteLine("[2] List of all Customers");
            Console.WriteLine("[1] Search By Name");
            Console.WriteLine("[0] Go Back");
        }

        public MenuType YourChoice()
        {
            CustomerOrderHistoryMenu custOrderHist = new CustomerOrderHistoryMenu(_customerBL);
            string userChoice = Console.ReadLine();
                    PlaceOrderMenu newOrder = new PlaceOrderMenu(_storeBL,_customerBL);
            switch(userChoice)
            {
                case "0":
                    return MenuType.CustomerMenu;
                case "1":
                    Console.WriteLine("Please enter Customer Name");
                   customer.Name =  Console.ReadLine();
                  Console.WriteLine(_customerBL.FindCustomerByName(customer.Name));
                  Console.WriteLine("[2] Order History for this Customer");
                  Console.WriteLine("[1] Place an order for this Customer");
                  Console.WriteLine("[0] Go Back"); 
                  String exitInput = Console.ReadLine();
                  if(exitInput =="2")
                  {
                    custOrderHist.currentCustomer(_customerBL.FindCustomerByName(customer.Name));
                    return MenuType.CustomerOrderHistoryMenu;
                  }
                  else if(exitInput=="1")
                  {
                    newOrder.customerInformation(_customerBL.FindCustomerByName(customer.Name));
                        return MenuType.PlaceOrderMenu;
                  }
                  else if (exitInput != "0")
                  {
                      return MenuType.CustomerMenu;
                  }
                    else
                    {
                        Console.WriteLine("Incorrect input. Please try again.");
                        Console.WriteLine("Press ENTER to continue");
                         Console.ReadLine();
                         return MenuType.CustomerMenu;
                    } //Need to add onto here
                case "2":
                    return MenuType.ShowCustomerMenu;
                default:
                    return MenuType.FindCustomerMenu;

            }
        }
    }
}