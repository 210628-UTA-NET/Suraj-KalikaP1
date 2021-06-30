using System;
using System.Collections;
namespace StoreUI
{
    class Program
    {
        static void Main(string[] args)
        {
            IMenu custMenu = new MainMenu();
            bool repeat = true;
            string currentMenu = "MainMenu";
            while(repeat)
            {
                 Console.Clear();
                custMenu.Menu();
                currentMenu = custMenu.YourChoice();
                switch(currentMenu)
                {
                    case "MainMenu":
                        custMenu = new MainMenu();
                        break;

                    case "Customer":
                        custMenu = new CustomerMenu();
                        break;
                    case "Exit":
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