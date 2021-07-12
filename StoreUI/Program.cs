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
            IMenu menu = new MainMenu();
            bool repeat = true;
            MenuType currentMenu = MenuType.MainMenu;
            IFactory menuFactory = new MenuFactory();

            while(repeat)
            {
                 Console.Clear();
                menu.Menu();
                currentMenu = menu.YourChoice();
                switch(currentMenu)
                {
                    case MenuType.MainMenu:
                        menu = menuFactory.GetMenu(MenuType.MainMenu);
                        break;
                    case MenuType.CustomerMenu:
                        menu = menuFactory.GetMenu(MenuType.CustomerMenu);
                        break;
                    case MenuType.ShowCustomerMenu:
                        menu = menuFactory.GetMenu(MenuType.ShowCustomerMenu);
                        break;
                    case MenuType.FindCustomerMenu:
                        menu = menuFactory.GetMenu(MenuType.FindCustomerMenu);
                        break;
                    case MenuType.StoreMenu:
                        menu = menuFactory.GetMenu(MenuType.StoreMenu);
                        break;
                    case MenuType.StoreManageMenu:
                        menu = menuFactory.GetMenu(MenuType.StoreMenu);
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