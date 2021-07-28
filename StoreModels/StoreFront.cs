using System;
using System.Collections.Generic;

namespace StoreModel
{

        public class StoreFront
        {
            public StoreFront(){}

            public int Id{get;set;}
             public string Name{get;set;}

             public string Address{get;set;}

        public List<LineItem> Inventory{get;set;}
         public List<Order> Orders {get;set;}

        public override string ToString()
        {
            return "ID: "+Id+"| Name: " + Name+"| Address: " + Address;
        }

        }


}