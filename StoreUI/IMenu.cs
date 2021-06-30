namespace StoreUI
{
    public interface IMenu
    {
        /// <summary>
        /// Will display the overall menu of the class and the choices you can make in that menu class
        /// </summary>


        void Menu();
        /// <summary>
        /// This method will record the user's choice and change your menu based on their input
        /// </summary>
        /// <returns>Returns a value that will dictate what menu to change to</returns>


        string YourChoice();
    }

}