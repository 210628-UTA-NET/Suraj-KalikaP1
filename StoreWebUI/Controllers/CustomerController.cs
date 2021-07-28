using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StoreWebUI.Models;
using StoreBL;
using StoreModel;
using Serilog;
namespace StoreWebUI.Controllers
{
    public class CustomerController : Controller
    {
        private StoreBL.ICustomerBL _custBL;
        private StoreBL.IStoreFrontBL _storeBL;
        List<LineItemViewModel> storeProductsVM = new List<LineItemViewModel>();
                public static List<LineItemViewModel> cart = new List<LineItemViewModel>();
        public CustomerController(ICustomerBL p_custBL,IStoreFrontBL p_storeBL)
        {
            _custBL=p_custBL;
            _storeBL=p_storeBL;
        }
        public IActionResult Index()
        {
            return View(
                _custBL.GetAllCustomers()
                .Select(cust => new StoreWebUI.Models.CustomerViewModel(cust))
                .ToList()
            );
        }
        public IActionResult AddCustomer()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CustomerViewModel p_custVM)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    _custBL.AddCustomer(new Customer
                    {
                        Name = p_custVM.Name,
                        Address = p_custVM.Address,
                        Email = p_custVM.Email,
                        PhoneNumber=p_custVM.PhoneNumber,
                        Password = p_custVM.Password
                    });
                }
                Log.Information("Customer added.");
                return RedirectToAction(nameof(Index));
            }
            catch(Exception)
            {
                Log.Error("Customer was not added.");
            return RedirectToAction(nameof(AddCustomer));
            }
        }
        
        [HttpPost]
        public IActionResult ViewCustomer(int p_Id, string sort, string custName)
        {   
            TempData["cust_Id"]= p_Id;
           if(sort =="priceAsc")
            {
                return View(_custBL.GetOrders(p_Id)
                            .Select(order => new OrderViewModel(order))
                            .ToList()
                            .OrderBy(order => order.TotalPrice)
                                );
            }
            else if(sort =="priceDesc")
            {
                return View(_custBL.GetOrders(p_Id)
                                .Select(order => new OrderViewModel(order))
                                .ToList()
                                .OrderByDescending(order => order.TotalPrice)
                                );
            }
            else if(sort=="oldest")
            {
                    return View(_custBL.GetOrders(p_Id)
                                .Select(order => new OrderViewModel(order))
                                .ToList()
                                .OrderBy(order => order.Id)
                                );
            }
            else if(sort=="latest")
            {
                            return View(_custBL.GetOrders(p_Id)
                                .Select(order => new OrderViewModel(order))
                                .ToList()
                                .OrderByDescending(order => order.Id)
                                );
            }
            else{
            
            return View(_custBL.GetOrders(_custBL.FindCustomerByName(custName).Id)
                                        .Select(order => new OrderViewModel(order))
                                        .ToList()
                                );
            }
        }

        public IActionResult ViewCustomer(int p_Id)
        {   
            TempData["cust_Id"]= p_Id;
            return View(
                _custBL.GetOrders(p_Id)
                .Select(order => new OrderViewModel(order))
                .ToList()
            );
        }
        public IActionResult SelectStore(int p_id)
        {
            return View(
                _storeBL.GetAllStoreFronts()
                .Select(store => new StoreWebUI.Models.StoreFrontViewModel(store))
                .ToList()
            );
        }
        [HttpPost]
        public IActionResult CreateOrder(LineItemViewModel CartItem, int StoreId, int CustomerId)
        {
                
                if(cart.Count > 0)
                {
                    foreach(var inv in cart)
                    {
                        if(inv.ProductId == CartItem.ProductId)
                        {
                            Log.Information("Same Product in Cart");
                            inv.Quantity += CartItem.Quantity;
                            Console.WriteLine(inv.Quantity);
                        }
                        else
                        {
                            Log.Information("Adding to Cart");
                            cart.Add(CartItem);
                        } 
                    }
                }
                else{
                    Log.Information("Adding to Cart");
                cart.Add(CartItem);
                }
            
    
            return RedirectToAction("CreateOrder","Customer", new {p_id=CustomerId, p_storeId=CartItem.StoreFrontId});
        }

        [HttpPost]
        public IActionResult CancelOrder(int p_storeId, int p_custId)
        {
            Log.Information("Clearing Cart");
            cart.Clear();
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public IActionResult PlaceOrder(int p_storeId, int p_custId)
        {
            Order newOrder = new Order();
            foreach(LineItemViewModel item in cart)
            {
                    newOrder.TotalPrice += item.Product.Price * item.Quantity;
            }
            StoreFront store = _storeBL.GetStoreFront(p_storeId);
            Customer cust = _custBL.FindCustomerById(p_custId);
            newOrder.CustomerId=p_custId;
            newOrder.StoreFrontId=p_storeId;
            Log.Information("Removing items from Store Inventory");
            foreach(LineItemViewModel item in cart)
            {   
                foreach(LineItem Li in _storeBL.getAllInventory())
                {
                    if(Li.Id==item.Id)
                    {
                        _storeBL.RemoveInventory(Li,item.Quantity);
                    }
                }
            }
            Log.Information("Items Removed from Store Inventory");
            Log.Information("Placing Order");
            _storeBL.AddOrder(store,cust,newOrder);
            Log.Information("Placed Order");
            Log.Information("Clearing Cart");
            cart.Clear();
            Log.Information("Cleared Cart");
            return RedirectToAction("ViewCustomer","Customer", new{p_Id = p_custId});
        }
        public IActionResult Checkout(int p_CustomerId, int p_StoreId)
        {
            Log.Information("Checkout out for CustomerId:"+p_CustomerId+" And StoreFrontId:"+p_StoreId);
            Order newOrder = new Order();

            foreach(LineItemViewModel item in cart)
            {
                    newOrder.TotalPrice += item.Product.Price * item.Quantity;
            }
            TempData["cust_Id"]= p_CustomerId;
            TempData["store_Id"]= p_StoreId;
            TempData["TotalPrice"] = newOrder.TotalPrice;
            return View(cart);
        }
        public IActionResult CreateOrder(int p_id, int p_storeId)
        {
            List<LineItem> storeProducts = new List<LineItem>();
            
            StoreFrontViewModel store = new StoreFrontViewModel(_storeBL.GetStoreFront(p_storeId));
            store.Inventory=_storeBL.GetInventory(p_storeId);
            foreach(var prod in store.Inventory)
            {
                foreach(var products in _storeBL.GetProducts(p_storeId))
                {
                    if(prod.ProductId==products.Id)
                    {   prod.Product=products;           
                        storeProducts.Add(prod);
                    }
                }
                
            }
            foreach(var item in storeProducts)
            {
                
                LineItemViewModel lineItemView = new LineItemViewModel(item);
                storeProductsVM.Add(lineItemView);
                
            }
            
            return View(storeProductsVM);
        }
    }
}