using System;

namespace StoreUI
{

public class MainMenu : IMenu
    {
        public void Menu()
        {
            string asciiMainMenu = 
            @"
 __    __     _                            _          _   _          
/ / /\ \ \___| | ___ ___  _ __ ___   ___  | |_ ___   | |_| |__   ___ 
\ \/  \/ / _ \ |/ __/ _ \| '_ ` _ \ / _ \ | __/ _ \  | __| '_ \ / _ \
 \  /\  /  __/ | (_| (_) | | | | | |  __/ | || (_) | | |_| | | |  __/
  \/  \/ \___|_|\___\___/|_| |_| |_|\___|  \__\___/   \__|_| |_|\___|
                                                                     
              _                                   _ 
  /\/\   __ _(_)_ __     /\/\   ___ _ __  _   _  / \
 /    \ / _` | | '_ \   /    \ / _ \ '_ \| | | |/  /
/ /\/\ \ (_| | | | | | / /\/\ \  __/ | | | |_| /\_/                                     
\/    \/\__,_|_|_| |_| \/    \/\___|_| |_|\__,_\/   
            ";
            Console.WriteLine(asciiMainMenu);
            Console.WriteLine("what would you like to do?");
            Console.WriteLine("[2] Store Info");
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