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
        private ICustomerBL _customerBL;

        public CustomerMenu(CustomerBL p_custBL)
        {
            _customerBL = p_custBL;
        }
        public void Menu()
        {
            string asciiCustomerMenu = 
            @"
 __    __     _                            _          _   _          
/ / /\ \ \___| | ___ ___  _ __ ___   ___  | |_ ___   | |_| |__   ___ 
\ \/  \/ / _ \ |/ __/ _ \| '_ ` _ \ / _ \ | __/ _ \  | __| '_ \ / _ \
 \  /\  /  __/ | (_| (_) | | | | | |  __/ | || (_) | | |_| | | |  __/
  \/  \/ \___|_|\___\___/|_| |_| |_|\___|  \__\___/   \__|_| |_|\___|
                                                                     
   ___          _                                                        _ 
  / __\   _ ___| |_ ___  _ __ ___   ___ _ __    /\/\   ___ _ __  _   _  / \
 / / | | | / __| __/ _ \| '_ ` _ \ / _ \ '__|  /    \ / _ \ '_ \| | | |/  /
/ /__| |_| \__ \ || (_) | | | | | |  __/ |    / /\/\ \  __/ | | | |_| /\_/ 
\____/\__,_|___/\__\___/|_| |_| |_|\___|_|    \/    \/\___|_| |_|\__,_\/   
                                                                           
            ";
            Console.WriteLine(asciiCustomerMenu);
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("[2] Search for a Customer");
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
                 Console.WriteLine("Please Enter Customer Name");
                customer.Name = Console.ReadLine();
                Console.WriteLine("Please enter Customer Address");
                customer.Address = Console.ReadLine();
                Console.WriteLine("Please enter Customer Email Address");
                customer.Email = Console.ReadLine();
                Console.WriteLine("Please enter Customer Phone Number");
                 customer.PhoneNumber = Console.ReadLine();
                
                _customerBL.AddCustomer(customer);
                return MenuType.ShowCustomerMenu;
                case "2":
                    return MenuType.FindCustomerMenu;
                default: 
                    return MenuType.CustomerMenu;


            }
        }

    }
}