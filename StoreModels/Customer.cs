using System;
using System.Collections.Generic;

namespace StoreModel{

    public class Customer
    {
        public Customer(){}

        public int Id{get; set;}
        public string Name{get;set;}

        public string Address{get;set;}

        public string Email{get;set;}

        public string PhoneNumber{get;set;}
        public string Password{get;set;}
        public List<Order> Orders {get;set;}

        public override string ToString()
        {
            return "ID: "+Id+"| Name: " + Name+"| Address: " + Address+"| Email: " +Email+"| Phone Number: "+ PhoneNumber;
        }
    }

}