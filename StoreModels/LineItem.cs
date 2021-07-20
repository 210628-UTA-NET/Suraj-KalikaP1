using System;

namespace StoreModel
{
    public class LineItem
    {
        public LineItem() { }

        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int StoreFrontId { get; set; }

        public StoreFront StoreFront{get;set;}
            public int Quantity{get;set;}

            public override string ToString()
            {
                return "ID: "+Id+"| ProductId: "+ProductId+" | Product Name: "+ Product.Name+" | StoreId: "+StoreFrontId+" | Quantity: "+Quantity;
            }
        }

}