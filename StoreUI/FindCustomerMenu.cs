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

    public FindCustomerMenu(CustomerBL p_custBL)
    {
        _customerBL = p_custBL;
    }
        public void Menu()
        {
            Console.WriteLine("Welcome to the Find Customer Menu!");
            Console.WriteLine("How would you like to search for a Customer?");
            Console.WriteLine("[3] List of all Customers");
            Console.WriteLine("[2] Search By Name");
            Console.WriteLine("[1] Search by ID");
            Console.WriteLine("[0] Go Back");
        }

        public MenuType YourChoice()
        {
            string userChoice = Console.ReadLine();

            switch(userChoice)
            {
                case "0":
                    return MenuType.CustomerMenu;
                case "1":
                Console.WriteLine("Please enter Customer ID");
                //customer.Id = Console.ReadLine();
                    return MenuType.FindCustomerMenu;
                case "2":
                    Console.WriteLine("Please enter Customer Name");
                   customer.Name =  Console.ReadLine();
                  Console.WriteLine(_customerBL.FindCustomerByName(customer.Name));
                  Console.WriteLine("[1] Place an order for this Customer");
                  Console.WriteLine("[0] Go Back"); 
                  String exitInput = Console.ReadLine();
                  if(exitInput=="1")
                        return MenuType.PlaceOrderMenu;
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
                case "3":
                    return MenuType.ShowCustomerMenu;
                default:
                    return MenuType.FindCustomerMenu;

            }
        }
    }
}