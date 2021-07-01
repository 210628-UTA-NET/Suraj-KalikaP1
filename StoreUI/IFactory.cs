namespace StoreUI
{
    public interface IFactory
    {
        IMenu GetMenu(MenuType p_menu);
    }
}