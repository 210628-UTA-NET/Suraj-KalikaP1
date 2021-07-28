using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreModel
{

    public class Order
    {
        public Order(){}

        public int Id{get;set;}

        [Required]
        public int StoreFrontId {get;set;}
        [Required]
        public int CustomerId{get;set;}
        public double TotalPrice{get;set;}
        [NotMapped]
        public List<LineItem> OrderList{get;set;}
        #nullable enable

        public override string ToString()
        {
            return "storeId: "+ StoreFrontId+" | customerId: "
            +CustomerId+" | Price: $"+TotalPrice;
        }

    }
}