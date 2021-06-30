using System;
using StoreBL;
using StoreDL;
using StoreModel;
using System.Collections;
namespace StoreUI
{
    class Program
    {
        static void Main(string[] args)
        {
            IMenu custMenu = new MainMenu();
            bool repeat = true;
            MenuType currentMenu = MenuType.MainMenu;
            while(repeat)
            {
                 Console.Clear();
                custMenu.Menu();
                currentMenu = custMenu.YourChoice();
                switch(currentMenu)
                {
                    case MenuType.MainMenu:
                        custMenu = new MainMenu();
                        break;

                    case MenuType.CustomerMenu:
                        custMenu = new CustomerMenu();
                        break;
                    case MenuType.ShowCustomerMenu:
                        custMenu = new ShowCustomerMenu(new StoreBL());
                        break;
                    case MenuType.Exit:
                        repeat = false;
                        break;

                    default:
                        Console.WriteLine("Cannot process what you want please try again");
                        break;
            }


        }

    }
}
}