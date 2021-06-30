using System;

namespace StoreUI
{

public class MainMenu : IMenu
    {
        public void Menu()
        {
            Console.WriteLine("Welcome to the Main Menu!");
            Console.WriteLine("what would you like to do?");
            //Console.WriteLine("[2]Store Info")
             Console.WriteLine("[1] Customer Info");
            Console.WriteLine("[0] Exit");
        }

        public string YourChoice()
        {
            string userInput = Console.ReadLine();

            switch(userInput)
            {
                case "0":
                    return "Exit";
                case "1":
                    return "Customer";
                default:
                    return "Unknown";
            }
        }
    }

}