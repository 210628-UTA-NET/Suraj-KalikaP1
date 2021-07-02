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
            IFactory menuFactory = new MenuFactory();

            while(repeat)
            {
                 Console.Clear();
                custMenu.Menu();
                currentMenu = custMenu.YourChoice();
                switch(currentMenu)
                {
                    case MenuType.MainMenu:
                        custMenu = menuFactory.GetMenu(MenuType.MainMenu);
                        break;

                    case MenuType.CustomerMenu:
                        custMenu = menuFactory.GetMenu(MenuType.CustomerMenu);
                        break;
                    case MenuType.ShowCustomerMenu:
                        custMenu = menuFactory.GetMenu(MenuType.ShowCustomerMenu);
                        break;
                    case MenuType.FindCustomerMenu:
                        custMenu = menuFactory.GetMenu(MenuType.FindCustomerMenu);
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