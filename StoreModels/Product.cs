using System;

namespace StoreModel
{
        public class Product
        {
                public Product(){}

                public int Id{get;set;}
                public string Name{get;set;}

                public double Price{get;set;}

                public string Description{get;set;}

                public string Category{get;set;}

                public override string ToString()
                {
                return "ID: "+Id+" | Name: " + Name+" | Description: " + Description
                +" | Category: "+ Category+ " | Price: "+Price;
                }

        }

}