using System.ComponentModel.DataAnnotations;
using StoreModel;
namespace StoreWebUI.Models
{
    public class ProductsViewModel
    {
        public ProductsViewModel()
        {

        }
        public ProductsViewModel(Product p_prod)
        {
            Id= p_prod.Id;
            Name=p_prod.Name;
            Description=p_prod.Description;
            Category=p_prod.Category;
            Price=p_prod.Price;
        }
        public int Id{get;set;}

        public string Name{get;set;}
        public double Price{get;set;}
        public string Description{get;set;}
        public string Category{get;set;}
    }
}