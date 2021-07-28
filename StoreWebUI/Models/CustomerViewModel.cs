using StoreModel;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;
namespace StoreWebUI.Models
{
    public class CustomerViewModel
    {
        
        public CustomerViewModel(Customer p_cust)
        {
            Id = p_cust.Id;
            Name = p_cust.Name;
            Address = p_cust.Address;
            PhoneNumber = p_cust.PhoneNumber;
            Email = p_cust.Email;
            Orders= p_cust.Orders;
        }
        public int Id{get;set;}
        public string Name{get;set;}
        public string Address{get;set;}
        public string Email{get;set;}
        public string PhoneNumber{get;set;}
        public string Password{get;set;}
        public List<Order> Orders{get;set;}

    }
}