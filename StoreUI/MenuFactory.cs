using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using StoreBL;
using StoreDL;
using StoreDL.Entities;

namespace StoreUI
{
    public class MenuFactory : IFactory
    {
        public IMenu GetMenu(MenuType p_menu)
        {     
                 //Get the configuration from our appsetting.json file
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsetting.json")
                .Build();

            //Grabs our connectionString from our appsetting.json
            string connectionString = configuration.GetConnectionString("Reference2DB");

            DbContextOptions<storeDBContext> options = new DbContextOptionsBuilder<storeDBContext>()
                .UseSqlServer(connectionString)
                .Options;

            switch(p_menu)
            {
                case MenuType.MainMenu:
                    return new MainMenu();
                case MenuType.CustomerMenu:
                    return new CustomerMenu(new SBL(new Repository()));
                case MenuType.ShowCustomerMenu:
                    return new ShowCustomerMenu(new SBL(new Repository()));
                case MenuType.FindCustomerMenu:
                    return new FindCustomerMenu();
                default:
                    return null;
                
            }
        }
    }
}