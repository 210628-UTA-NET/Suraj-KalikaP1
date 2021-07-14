using System;
using StoreBL;
using StoreModel;
using System.Collections.Generic;
namespace StoreUI
{
    public class CustomerOrderHistoryMenu : IMenu
    {

        private ICustomerBL _customerBL;
        public CustomerOrderHistoryMenu(ICustomerBL p_customerBL)
        {
            _customerBL = p_customerBL;
        }
        
        public static Customer _customer = new Customer();
        public void Menu()
        {
            List<Orders> storeOrderHistory = _customerBL.GetOrders(_customer);
            Console.WriteLine("Store Order History for "+_customer.Name);
            Console.WriteLine("--------------------------------");
            foreach(Orders order in storeOrderHistory)
            {
                Console.WriteLine(order);
            }
            Console.WriteLine("--------------------------------");
            Console.WriteLine("[0] Go back");

        }
    public void currentCustomer(Customer p_customer)
        {
            _customer = p_customer;
        }
        public MenuType YourChoice()
        {
           string userInput = Console.ReadLine();
           switch(userInput)
           {
               case "0":
                    return MenuType.FindCustomerMenu;
                default:
                Console.WriteLine("Invalid Selection");
                Console.WriteLine("Press Enter to Continue.");
                Console.ReadLine();
                    return MenuType.CustomerOrderHistoryMenu;
           }
        }
    }
}