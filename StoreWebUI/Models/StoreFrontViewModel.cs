using Microsoft.AspNetCore.Mvc;
using StoreModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StoreWebUI.Models
{
    public class StoreFrontViewModel
    {
        public StoreFrontViewModel()
        {

        }
        public StoreFrontViewModel(StoreFront p_storeFront)
        {
            Id= p_storeFront.Id;
            Name= p_storeFront.Name;
            Address = p_storeFront.Address;
            Inventory = p_storeFront.Inventory;
            Orders = p_storeFront.Orders;
        }

        public int Id{get;set;}
    

        public List<LineItem>Inventory{get;set;}
        public List<Order> Orders{get;set;}
        public string Name{get;set;}
        public string Address{get;set;}
    }
}