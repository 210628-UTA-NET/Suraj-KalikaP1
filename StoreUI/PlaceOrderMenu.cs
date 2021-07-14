using System;
using System.Collections.Generic;
using StoreModel;
using StoreBL;

namespace StoreUI
{
    public class PlaceOrderMenu : IMenu
    {
        private IStoreFrontBL _storeFrontBL;
        private ICustomerBL _customerBL;

        private static Customer customer = new Customer();
        private static StoreFront storeFront = new StoreFront();

        public void storeInformation(StoreFront p_storefront)
        {
            storeFront = p_storefront;
        }

        public void customerInformation(Customer p_customer)
        {
            customer = p_customer;
        }
        private static double totalPrice;
        public PlaceOrderMenu(IStoreFrontBL p_storeFrontBL, ICustomerBL p_customerBL)
        {
            _storeFrontBL = p_storeFrontBL;
            _customerBL = p_customerBL;
        }

        
        private static List<int> shoppingQuantity = new List<int>();
        private static List<Products> shoppingCart = new List<Products>();
        public void Menu()
        {
            Console.WriteLine("Please Select a Store");
             List<StoreFront> stores = _storeFrontBL.GetAllStoreFronts();
                foreach(StoreFront store in stores)
                {
                    Console.WriteLine("["+store.Id+"] "+store.Name +" Located at "+ store.Address);
                }
            Console.WriteLine("[0] Go Back");
        }

        public MenuType YourChoice()
        {   
            
            string userChoice = Console.ReadLine();
            List<StoreFront> stores = _storeFrontBL.GetAllStoreFronts();
            switch(userChoice)
            {   case "0":
                    return MenuType.FindCustomerMenu;
                
                case "1":
                    storeFront = stores[0];
                    List<Products> storeProducts = _storeFrontBL.GetProducts(storeFront);
                    List<LineItems> inventory = _storeFrontBL.GetInventory(storeFront);
                    foreach(LineItems item in inventory)
                    {
                        foreach(Products prod in storeProducts)
                        {   if(item.ProductId == prod.Id)
                            Console.WriteLine(prod+" | Quantity: "+ item.Quantity);
                        }
                    }
                    Console.WriteLine("Which Item to be purchased? (Choose by Product Id)");
                    string itemChoice =  Console.ReadLine();
                    string continueChoice;
                    string endChoice;
                    foreach(LineItems item in inventory){
                        
                        if(int.Parse(itemChoice) == item.Id)
                        {
                             Console.WriteLine("How many to add to cart?");
                            string itemQuantity = Console.ReadLine();
                            while(int.Parse(itemQuantity)>item.Quantity)
                            {
                                Console.WriteLine("Not enough of Product in available Inventory. ");
                                Console.WriteLine("Please enter a different amount.");
                                 itemQuantity = Console.ReadLine();
                            }
                            if(itemQuantity=="0")
                            {
                                  Console.WriteLine("--------------------");
                                Console.WriteLine("[2] Add more items to cart");
                                Console.WriteLine("[1] Checkout");
                                Console.WriteLine("[0] Cancel Order and Go Back");
                                continueChoice= Console.ReadLine();
    
                                if(continueChoice=="2")
                                {
                                return MenuType.PlaceOrderMenu;
                                }
                                else if (continueChoice=="1")
                                {
                                     Console.WriteLine("-------------------------");
                                    Console.WriteLine("Cart: ");
                                    Console.WriteLine("-------------------------");
                                
                                
                                    int count=0;
                                     foreach(Products prod in shoppingCart)
                                     {
                                    Console.WriteLine(prod+" Quantity:"+shoppingQuantity[count]+" Price: $"+Math.Round(prod.Price*shoppingQuantity[count]),2);
                                    count=+1;
                                    Console.WriteLine("-------------------------");
                                         }
                                      Console.WriteLine("Total Price: "+Math.Round(totalPrice, 2));
                                       Console.WriteLine("[1] Confirm Purchase");
                                      Console.WriteLine("[0] Cancel Order and Go back");
                                      endChoice = Console.ReadLine();
                                      while(endChoice!="1"|| endChoice!="0")
                                     {
                                        Console.WriteLine("Invalid input. Please try again.");
                                        endChoice = Console.ReadLine();
                                       }
                                         if(endChoice =="1")
                                      {
                                          
                                           Orders order = new Orders();
                                           order.TotalPrice = totalPrice;
                                          _storeFrontBL.AddOrder(storeFront,customer,order);
                                          foreach(LineItems items in inventory)
                                          {
                                                 count = 0;
                                                foreach(Products product in shoppingCart)
                                                {
                                                    if(product.Id == items.ProductId)
                                                    {
                                                        _storeFrontBL.RemoveInventory(items,shoppingQuantity[count]);
                                                        count=+1;
                                                    }
                                                }
                                          }
                                          Console.WriteLine("Purchase Successful");
                                          Console.WriteLine("Press Enter to go back to Main Menu");
                                          Console.ReadLine();
                                          shoppingCart.Clear();
                                             shoppingQuantity.Clear();
                                            return MenuType.MainMenu;
                                       }
                                           else
                                             {
                                              shoppingCart.Clear();
                                             shoppingQuantity.Clear();

                                              return MenuType.FindCustomerMenu;
                                              }

                                }
                                else 
                                {
                                    Console.WriteLine("Invalid input. Please enter to retry.");
                                    Console.ReadLine();
                                    return MenuType.FindCustomerMenu;
                                }
                            }
                            else{
                                foreach(Products prod in storeProducts)
                                {   
                                    if(item.ProductId == prod.Id)
                                    {   shoppingQuantity.Add(int.Parse(itemQuantity));
                                        item.Quantity =- int.Parse(itemQuantity);
                                        shoppingCart.Add(prod);
                                        totalPrice =totalPrice+ (prod.Price *int.Parse(itemQuantity));
                                    }
                                

                                  }
                                Console.WriteLine("--------------------");
                                Console.WriteLine("[2] Add more items to cart");
                                Console.WriteLine("[1] Checkout");
                                Console.WriteLine("[0] Cancel Order and Go Back");
                                continueChoice= Console.ReadLine();
                                
                                if(continueChoice=="2")
                                {
                                return MenuType.PlaceOrderMenu;
                                }
                                else if (continueChoice=="1")
                                {
                                    Console.WriteLine("-------------------------");
                                    Console.WriteLine("Cart: ");
                                    Console.WriteLine("-------------------------");
                                
                                
                                    int count=0;
                                     foreach(Products prod in shoppingCart)
                                     {
                                    Console.WriteLine(prod+" Quantity:"+shoppingQuantity[count]+" Price: $"+Math.Round(prod.Price*shoppingQuantity[count]),2);
                                    count=+1;
                                    Console.WriteLine("-------------------------");
                                         }
                                      Console.WriteLine("Total Price: $"+Math.Round(totalPrice, 2));
                                       Console.WriteLine("[1] Confirm Purchase");
                                      Console.WriteLine("[0] Cancel Order and Go back");
                                      endChoice = Console.ReadLine();
                
                                         if(endChoice =="1")
                                      {
                                           Orders order = new Orders();
                                           order.TotalPrice = totalPrice;
                                          _storeFrontBL.AddOrder(storeFront,customer,order);
                                          foreach(LineItems items in inventory)
                                          {
                                                 count = 0;
                                                foreach(Products product in shoppingCart)
                                                {
                                                    if(product.Id == items.ProductId)
                                                    {
                                                        _storeFrontBL.RemoveInventory(items,shoppingQuantity[count]);
                                                        count=+1;
                                                    }
                                                }
                                          }
                                          Console.WriteLine("Purchase Successful");
                                          Console.WriteLine("Press Enter to go back to Main Menu");
                                          Console.ReadLine();
                                          shoppingCart.Clear();
                                             shoppingQuantity.Clear();
                                            return MenuType.MainMenu;
                                       }
                                           else if(endChoice =="0")
                                             {
                                              shoppingCart.Clear();
                                             shoppingQuantity.Clear();

                                              return MenuType.FindCustomerMenu;
                                              }
                                            else {
                                                Console.WriteLine("Invalid input. Please Enter to Continue.");
                                                Console.ReadLine();
                                                return MenuType.PlaceOrderMenu;
                                            }

                                }

                                else 
                                {
                                    shoppingCart.Clear();
                                    shoppingQuantity.Clear();

                                    return MenuType.FindCustomerMenu;
                                }
                            }

                        }
                    }
                    return MenuType.PlaceOrderMenu;


                default:
                Console.WriteLine("Invalid store selection");
                return MenuType.PlaceOrderMenu;
            }
            
        }
    }
}