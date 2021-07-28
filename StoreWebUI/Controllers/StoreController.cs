using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using StoreBL;
using System.Linq;
using StoreWebUI.Models;
using System.Threading;
using Serilog;
using StoreModel;

namespace StoreWebUI.Controllers
{
    public class StoreController : Controller
    {
        private  StoreBL.IStoreFrontBL _storeBL;

        public StoreController(IStoreFrontBL p_storeBL)
        {
            _storeBL=p_storeBL;
        }

        public IActionResult Index()
        {
            return View(
                _storeBL.GetAllStoreFronts()
                .Select(store => new StoreWebUI.Models.StoreFrontViewModel(store))
                .ToList()
            );
        }
        [HttpPost]
        public IActionResult StoreInventory(LineItemViewModel lineItem, int p_Id)
        {TempData["store_Id"]= lineItem.StoreFrontId;
            Console.WriteLine(lineItem.Id);
            LineItem item = new LineItem();
            item.Id=lineItem.Id;
            Log.Information("Adding to Store Inventory");
            _storeBL.AddInventory(item,lineItem.Quantity);
            Log.Information("Successfully Added to Store Inventory");
        return RedirectToAction("StoreInventory", "Store", new {p_Id=lineItem.StoreFrontId});
        }
        public IActionResult StoreInventory(int p_Id)
        {
            TempData["store_Id"]= p_Id;
            return View(_storeBL.GetInventory(p_Id)
                                .Select(inv => new LineItemViewModel(inv))
                                .ToList()
                                );
        }
        
        [HttpPost]
        public IActionResult StoreOrderHistory(int p_Id, string sort)
        {
            TempData["store_Id"]= p_Id;
            if(sort =="priceAsc")
            {
                return View(_storeBL.GetOrders(_storeBL.GetStoreFront(p_Id))
                                .Select(order => new OrderViewModel(order))
                                .ToList()
                                .OrderBy(order => order.TotalPrice)
                                );
            }
            else if(sort =="priceDesc")
            {
                return View(_storeBL.GetOrders(_storeBL.GetStoreFront(p_Id))
                                .Select(order => new OrderViewModel(order))
                                .ToList()
                                .OrderByDescending(order => order.TotalPrice)
                                );
            }
            else if(sort=="oldest")
            {
                    return View(_storeBL.GetOrders(_storeBL.GetStoreFront(p_Id))
                                .Select(order => new OrderViewModel(order))
                                .ToList()
                                .OrderBy(order => order.Id)
                                );
            }
            else if(sort=="latest")
            {
                            return View(_storeBL.GetOrders(_storeBL.GetStoreFront(p_Id))
                                .Select(order => new OrderViewModel(order))
                                .ToList()
                                .OrderByDescending(order => order.Id)
                                );
            }
            else
            {
                return View(_storeBL.GetOrders(_storeBL.GetStoreFront(p_Id))
                                .Select(order => new OrderViewModel(order))
                                .ToList()
                                );
            }
        }
        public IActionResult StoreOrderHistory(int p_Id)
        {
            TempData["store_Id"]= p_Id;
            return View(_storeBL.GetOrders(_storeBL.GetStoreFront(p_Id))
                                .Select(order => new OrderViewModel(order))
                                .ToList()
                                );
        }
    }
}