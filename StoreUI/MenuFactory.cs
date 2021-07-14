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

            DbContextOptions<customerDBContext> options = new DbContextOptionsBuilder<customerDBContext>()
                .UseSqlServer(connectionString)
                .Options;

            switch(p_menu)
            {
                case MenuType.MainMenu:
                    return new MainMenu();
                case MenuType.StoreMenu:
                    return new StoreMenu(new StoreFrontBL(new StoreRepository(new customerDBContext(options))));
                case MenuType.StoreManageMenu:
                    return new StoreManageMenu(new StoreFrontBL(new StoreRepository(new customerDBContext(options))));
                case MenuType.ShowInventoryMenu:
                    return new ShowInventoryMenu(new StoreFrontBL(new StoreRepository(new customerDBContext(options))));
               case MenuType.PlaceOrderMenu:
                    return new PlaceOrderMenu(new StoreFrontBL(new StoreRepository(new customerDBContext(options))),new CustomerBL(new CustomerRepository(new customerDBContext(options))));
                case MenuType.StoreOrderHistoryMenu:
                    return new StoreOrderHistoryMenu(new StoreFrontBL(new StoreRepository(new customerDBContext(options))));
                case MenuType.CustomerMenu:
                    return new CustomerMenu(new CustomerBL(new CustomerRepository(new customerDBContext(options))));
                case MenuType.ShowCustomerMenu:
                    return new ShowCustomerMenu(new CustomerBL(new CustomerRepository(new customerDBContext(options))));
                case MenuType.FindCustomerMenu:
                    return new FindCustomerMenu(new StoreFrontBL(new StoreRepository(new customerDBContext(options))),new CustomerBL(new CustomerRepository(new customerDBContext(options))));
                case MenuType.CustomerOrderHistoryMenu:
                    return new CustomerOrderHistoryMenu(new CustomerBL(new CustomerRepository(new customerDBContext(options))));
                default:
                    return null;
                
            }
        }
    }
}