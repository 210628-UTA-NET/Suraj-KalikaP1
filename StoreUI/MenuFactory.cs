using StoreBL;
using StoreDL;

namespace StoreUI
{
    public class MenuFactory : IFactory
    {
        public IMenu GetMenu(MenuType p_menu)
        {
            switch(p_menu)
            {
                case MenuType.MainMenu:
                    return new MainMenu();
                case MenuType.CustomerMenu:
                    return new CustomerMenu(new SBL(new Repository()));
                case MenuType.ShowCustomerMenu:
                    return new ShowCustomerMenu(new SBL(new Repository()));
                default:
                    return null;
                
            }
        }
    }
}