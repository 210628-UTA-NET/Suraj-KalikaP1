using System;
using System.Collections.Generic;

namespace StoreModel
{

        public class StoreFront
        {
            public StoreFront(){}

             public string Name{get;set;}

             public string Address{get;set;}


         public List<Orders> Orders {get;set;}

        }


}