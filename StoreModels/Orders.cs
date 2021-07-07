using System;
using System.Collections.Generic;

namespace StoreModel
{

    public class Orders
    {
        public Orders(){}

        public string Id{get;set;}
        public List<LineItems> LineItems {get;set;}

        public string Location {get;set;}

        public double TotalPrice{get;set;}

    }
}