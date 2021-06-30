using System;
using System.Collections.Generic;

namespace StoreModel{

    public class Customer
    {
        public Customer(){}

        public string Name{get;set;}

        public string Address{get;set;}

        public string Email{get;set;}

        public List<Orders> Orders {get;set;}
    }

}