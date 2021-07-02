using System;
using System.Collections;
using StoreModel;
using StoreBL;
using StoreDL;
namespace StoreUI
{
    public class CustomerMenu : IMenu
    {
        
        private static Customer customer = new Customer();
        private IStoreBL _storeBL;

        public CustomerMenu(SBL p_custBL)
        {
            _storeBL = p_custBL;
        }
        public void Menu()
        {
            
            Console.WriteLine("Welcome to the Customer Menu!");
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("[1] Add customer details");
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
                 Console.WriteLine("Please Enter Your Name");
                customer.Name = Console.ReadLine();
                Console.WriteLine("Please enter Your Address");
                customer.Address = Console.ReadLine();
                Console.WriteLine("Please enter Your Email Address");
                customer.Email = Console.ReadLine();
                _storeBL.AddCustomer(customer);
                return MenuType.ShowCustomerMenu;
                default: 
                    return MenuType.CustomerMenu;


            }
        }

    }
}