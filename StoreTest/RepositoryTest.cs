 using Microsoft.EntityFrameworkCore;
using StoreDL;
using StoreModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace StoreTest
{
    public class RepositoryTest
    {
        private readonly DbContextOptions<StoreDBContext> _options;

        public RepositoryTest()
        {
            _options = new DbContextOptionsBuilder<StoreDBContext>().UseSqlite("Filename = Test.db").Options;
            this.Seed();
        }
        private void Seed()
        {
            using (var context = new StoreDBContext(_options))
            {
                //We want to make sure our inmemory database gets deleted everytime before another test case runs it
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                context.Customers.AddRange(
                    new Customer
                    {
                        Id = 1,
                        Name = "Suraj Kalika",
                        Address = "Zimbabwe",
                        Email = "activisonsucks@gmail.com",
                        PhoneNumber = "1234567890",
                        Password = "Password",
                    },
                    new Customer
                    {
                        Id = 2,
                        Name = "Rick and Morty",
                        Address = "Is a Good Show Address",
                        Email = "ihighlyrecommendit@gmail.com",
                        PhoneNumber = "7777777",
                        Password = "admin",
                        
                    }
                );
                context.StoreFronts.AddRange(
                    new StoreFront
                    {
                        Id = 1,
                        Name = "Radio Shack",
                        Address = "Who Even Knows Address"
                    },
                    new StoreFront
                    {
                        Id = 2,
                        Name = "Sleepy Store",
                        Address = "Sleep Address",
                    }
                );
                context.Orders.AddRange(
                    new Order
                    {
                        Id = 1,
                        StoreFrontId = 1,
                        CustomerId = 1,
                        TotalPrice = 9001.99,
                    },
                    new Order
                    {
                        Id = 2,
                        StoreFrontId = 2,
                        CustomerId = 2,
                        TotalPrice = 2021.55,
                    }
                );
                context.LineItems.AddRange(
                    new LineItem
                    {
                        Id = 1,
                        StoreFrontId = 1,
                        ProductId = 1,
                        Quantity = 55,
                    },
                    new LineItem
                    {
                        Id = 2,
                        StoreFrontId = 2,
                        ProductId = 2,
                        Quantity = 99,
                    }
                );
                context.Products.AddRange(
                    new Product
                    {
                        Id = 1,
                        Name = "Pillow",
                        Price = 12.99,
                        Description = "It's a Pillow",
                        Category = "Sleep Category",
                    },
                    new Product
                    {
                        Id = 2,
                        Name = "Burrito",
                        Price = 4.99,
                        Description = "It's a Burrito",
                        Category = "Food",
                    }
                );
                context.SaveChanges();
            }
        }

        [Fact]
        public void GetAllCustomersShouldGetAllCustomers()
        {
            using (var context = new StoreDBContext(_options))
            {
                //Arrange
                ICustomerRepository repo = new CustomerRepository(context);
                List<Customer> customers;

                //Act
                customers = repo.GetAllCustomers();

                //Assert
                Assert.NotNull(customers);
                Assert.Equal(2, customers.Count);
            }
        }
        [Fact]
        public void GetAllStoreFrontsShouldGetAllStoreFronts()
        {
            using(var context = new StoreDBContext(_options))
            {
                //Arrange
                IStoreRepository repo = new StoreRepository(context);
                List<StoreFront> storeFronts;
                //Act
                storeFronts = repo.GetAllStoreFronts();
                //Assert
                Assert.NotNull(storeFronts);
                Assert.Equal(2, storeFronts.Count);
            }
        }
        [Fact]
        public void GetOrdersShouldGetAllOrdersForStoreFront()
        {
            using (var context = new StoreDBContext(_options))
            {
                //Arrange
                IStoreRepository repo = new StoreRepository(context);
                List<Order> orders;
                //Act
                orders = repo.GetOrders(repo.GetStoreFront(1));
                int x = orders.Count;
                //Assert
                Assert.NotNull(orders);
                Assert.Equal(1, x);
            }
        }
        [Fact]
        public void GetAllProductsShouldGetAllProducts()
        {
            using (var context = new StoreDBContext(_options))
            {
                //Arrange
                IStoreRepository repo = new StoreRepository(context);
                List<Product> products;
                //Act
                products = repo.GetAllProducts();
                //Assert
                Assert.NotNull(products);
                Assert.Equal(2, products.Count);
            }
        }
        [Fact]
        public void GetProductsShouldGetAllProductsForStoreFrontById()
        {
            using (var context = new StoreDBContext(_options))
            {
                //Arrange
                IStoreRepository repo = new StoreRepository(context);
                List<Product> products;
                //Act
                products = repo.GetProducts(1);
                int x = products.Count;
                //Assert
                Assert.NotNull(products);
                Assert.Equal(1, x);
            }
        }
        
        [Fact]
        public void GetAllInventoryShouldGetAllInventory()
        {
            using (var context = new StoreDBContext(_options))
            {
                //Arrange
                IStoreRepository repo = new StoreRepository(context);
                List<LineItem> inventory;
                //Act
                inventory = repo.getAllInventory();
                //Assert
                Assert.NotNull(inventory);
                Assert.Equal(2, inventory.Count);
            }
        }

        [Fact]
        public void FindCustomerShouldGetSpecificCustomerByName()
        {
            using (var context = new StoreDBContext(_options))
            {   //Arrange
                ICustomerRepository repo = new CustomerRepository(context);
                Customer tryToFindCust = new Customer()
                {
                    Name = "Suraj Kalika"
                };
                //Act
                Customer found = repo.FindCustomerByName(tryToFindCust.Name);
                //Assert
                Assert.NotNull(found);
                Assert.Equal(found.Name, tryToFindCust.Name);
            }
        }

        [Fact]
        public void FindCustomerShouldGetSpecificCustomerById()
        {
            using (var context = new StoreDBContext(_options))
            {   //Arrange
                ICustomerRepository repo = new CustomerRepository(context);
                Customer tryToFindCust = new Customer()
                {
                    Name = "Suraj Kalika",
                    Id = 1
                };
                //Act
                Customer found = repo.FindCustomerById(tryToFindCust.Id);
                //Assert
                Assert.NotNull(found);
                Assert.Equal(found.Id, tryToFindCust.Id);
            }
        }
        [Fact]
        public void GetStoreFrontShouldGetSpecificStoreFrontById()
        {
            using (var context = new StoreDBContext(_options))
            {
                //Arrange
                IStoreRepository repo = new StoreRepository(context);
                StoreFront tryToFindStore = new StoreFront()
                {
                    Name = "Sleepy Store",
                    Id = 2,
                    Address = "Sleep Address"
                };
                //Act
                StoreFront found = repo.GetStoreFront(tryToFindStore.Id);
                //Assert
                Assert.NotNull(found);
                Assert.Equal(found.Id, tryToFindStore.Id);
            }
        }
        [Fact]
        public void GetInventoryShouldGetInventoryForStoreFrontById()
        {
            using (var context = new StoreDBContext(_options))
            {
                //Arrange
                IStoreRepository repo = new StoreRepository(context);
                //Act
                int x= repo.GetInventory(1).Count;
                //Assert
                Assert.Equal(1, x);
            }
        }
        [Fact]
        public void AddOrderShouldAddOrder()
        {
            using(var context = new StoreDBContext(_options))
            {
                //Arrange
                IStoreRepository repo = new StoreRepository(context);
                ICustomerRepository custRepo = new CustomerRepository(context);
                int count = repo.GetOrders(repo.GetStoreFront(1)).Count;
                Order newOrder = new Order()
                {
                    StoreFrontId = 1,
                    CustomerId = 1,
                    TotalPrice = 123
                }
                    ;
                //Act
                repo.AddOrder(repo.GetStoreFront(1), custRepo.FindCustomerById(1), newOrder);
                //Assert
                Assert.Equal(count + 1, repo.GetOrders(repo.GetStoreFront(1)).Count);
            }
        }

        [Fact]
        public void AddInventoryShouldAddInventory()
        {
            using (var context = new StoreDBContext(_options))
            {
                //Arrange
                IStoreRepository repo = new StoreRepository(context);
                List<LineItem> inv= repo.getAllInventory();
                LineItem newInv = inv[0];
                int quantity = newInv.Quantity;
                int amount = 5;


                //Act
                repo.AddInventory(newInv, amount);
                //Assert
                
                Assert.Equal(quantity+amount, repo.getAllInventory()[0].Quantity);
            }
        }

        [Fact]
        public void RemoveInventoryShouldRemoveInventory()
        {
            using (var context = new StoreDBContext(_options))
            {
                //Arrange
                IStoreRepository repo = new StoreRepository(context);
                List<LineItem> inv = repo.getAllInventory();
                LineItem newInv = inv[0];
                int quantity = newInv.Quantity;
                int amount = 1;


                //Act
                repo.RemoveInventory(newInv, amount);
                //Assert

                Assert.Equal(quantity - amount, repo.getAllInventory()[0].Quantity);
            }
        }

        [Fact]
        public void AddCustomerShouldAddACustomer()
        {
            using(var context = new StoreDBContext(_options))
            {   //Arrange
                ICustomerRepository repo = new CustomerRepository(context);
                int count = repo.GetAllCustomers().Count;
                Customer newCust = new Customer();
                newCust.Name = "New Name";
                newCust.Password = "New Password";
                newCust.PhoneNumber = "1234512345";
                newCust.Address = "New Address";
                newCust.Email = "New Email who dis";
                //Act

                repo.AddCustomer(newCust);
                //Assert
                Assert.Equal(count + 1, repo.GetAllCustomers().Count);
            }
        }
        [Fact]
        public void GetOrdersForCustomerShouldGetOrdersForCustomerById()
        {
            using (var context = new StoreDBContext(_options))
            {
                //Arrange
                ICustomerRepository repo = new CustomerRepository(context);
                int customerId = 1;
                //Act
                List<Order> orderList=repo.GetOrders(customerId);

                //Assert
                Assert.Equal(customerId, orderList[0].CustomerId);
            }
        }

    }
}
