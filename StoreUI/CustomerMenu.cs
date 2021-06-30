using System;
using StoreApp;
using System.Collections;

namespace StoreUI
{
    public class CustomerMenu : IMenu
    {
        

        public void Menu()
        {
            
            Console.WriteLine("Welcome to the Customer Menu!");
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("[1] Add customer details");
            Console.WriteLine("[0] Go Back");
            
        }

        public string YourChoice()
        {
            string userChoice = Console.ReadLine();

            switch(userChoice)
            {
                case "0":
                    return "MainMenu";
                case "1":
                Customer customer = new Customer();
                 Console.WriteLine("Please Enter Your Name");
                customer.Name = Console.ReadLine();
                Console.WriteLine("Please enter Your Address");
                customer.Address = Console.ReadLine();
                Console.WriteLine("Please enter Your Email Address");
                customer.Email = Console.ReadLine();
                customerList.Add(customer);
                return "CustomerMenu";
                default: 
                    return "Unknown";


            }
        }
    }
}