using System;

namespace StoreModel
{
        public class LineItems
        {
            public LineItems(){ }

            public int Id{get; set;}
            public int ProductId{get;set;}
            
            public string ProductName{get;set;}
            public int StoreId{get;set;}
            public int Quantity{get;set;}

            public override string ToString()
            {
                return "ID: "+Id+"| ProductId: "+ProductId+" | Product Name: "+ ProductName+" | StoreId: "+StoreId+" | Quantity: "+Quantity;
            }
        }

}