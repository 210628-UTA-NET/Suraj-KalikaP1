using System;
using System.Collections.Generic;
using StoreBL;
using StoreModel;

namespace StoreUI
{
    public class StoreManageMenu : IMenu
    {
        private IStoreFrontBL _storeBL;

        public StoreManageMenu(IStoreFrontBL p_store)
        {
            _storeBL = p_store;
        }
        public void Menu()
        {
            Console.WriteLine("Welcome to the Store Management Menu");
            Console.WriteLine("This is the Management Menu for "+_storeBL);
        }

        public MenuType YourChoice()
        {
            throw new NotImplementedException();
        }
    }
}