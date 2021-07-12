using System;

namespace StoreUI
{

public class MainMenu : IMenu
    {
        public void Menu()
        {
            Console.WriteLine("Welcome to the Main Menu!");
            Console.WriteLine("what would you like to do?");
            Console.WriteLine("[2]Store Info");
             Console.WriteLine("[1] Customer Info");
            Console.WriteLine("[0] Exit");
        }

        public MenuType YourChoice()
        {
            string userInput = Console.ReadLine();

            switch(userInput)
            {
                case "0":
                    return MenuType.Exit;
                case "1":
                    return MenuType.CustomerMenu;
                case "2":
                    return MenuType.StoreMenu;
                default:
                    Console.WriteLine("Input was not correct");
                    Console.WriteLine("Press Enter to continue");
                    Console.ReadLine();
                    return MenuType.MainMenu;
            }
        }

      
    }

}