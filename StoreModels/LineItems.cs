using System;

namespace StoreModel
{
        public class LineItems
        {
            public LineItems(){ }

            public int Id{get; set;}
            public int ProductId{get;set;}

            public int StoreId{get;set;}
            public int Quantity{get;set;}

        }

}