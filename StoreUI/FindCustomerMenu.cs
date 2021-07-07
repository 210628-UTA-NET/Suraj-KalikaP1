using System;
using System.Collections.Generic;
using StoreBL;
using StoreModel;

namespace StoreUI
{

    public class FindCustomerMenu : IMenu
    {
    private static Customer customer = new Customer();
    private IStoreBL _storeBL;

        public void Menu()
        {
            Console.WriteLine("Welcome to the Find Customer Menu!");
            Console.WriteLine("How would you like to search for a Customer?");
            Console.WriteLine("[1] Search by Name");
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
                   customer.Name =  Console.ReadLine();
                   
                    return MenuType.FindCustomerMenu; //Need to add onto here
                default:
                    return MenuType.FindCustomerMenu;

            }
        }
    }
}