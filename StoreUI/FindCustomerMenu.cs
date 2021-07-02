using System;
using System.Collections.Generic;

namespace StoreUI
{

    public class FindCustomerMenu : IMenu
    {
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
                    return MenuType.FindCustomerMenu; //Need to add onto here
                default:
                    return MenuType.FindCustomerMenu;

            }
        }
    }
}