using System;
using System.Collections.Generic;

namespace StoreModel
{

    public class Order
    {
        public Order(){}

        public int Id{get;set;}

        public int storeId {get;set;}
        public int customerId{get;set;}
        public double TotalPrice{get;set;}

        public override string ToString()
        {
            return "ID: "+Id+" | storeId: "+ storeId+" | customerId: "
            +customerId+" | Price $"+TotalPrice;
        }

    }
}