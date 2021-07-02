using System;
using System.Collections.Generic;
using StoreBL;
using StoreModel;

namespace StoreUI
{
    public class ShowCustomerMenu : IMenu
    {
        private IStoreBL _storeBL;

        public ShowCustomerMenu(IStoreBL p_cust)
        {
            _storeBL = p_cust;
        }
        public void Menu()
        {
            
            Console.WriteLine("List of Customers");

            List<Customer> customers = _storeBL.GetAllCustomers();

            foreach (Customer cust in customers)
            {
                Console.WriteLine("=============================");
                Console.WriteLine(cust);
                Console.WriteLine("=============================");
            }

            Console.WriteLine("[0] Go Back");
        }

        public MenuType YourChoice()
        {
            string userInput = Console.ReadLine();
          //  log.Logger = new LoggerConfiguration().CreateLogger();
            switch (userInput)
            {
                case "0":
                    return MenuType.CustomerMenu;
                default:
                    Console.WriteLine("Input was not correct");
                    Console.WriteLine("Press Enter to continue");
                    Console.ReadLine();
                    return MenuType.ShowCustomerMenu;
        }
    }
}
}