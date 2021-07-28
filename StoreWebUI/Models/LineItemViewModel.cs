using System.ComponentModel.DataAnnotations;
using StoreModel;

namespace StoreWebUI.Models
{
    public class LineItemViewModel
    {
        public LineItemViewModel()
        {

        }
        public LineItemViewModel(LineItem p_lineItem)
        {
            Id= p_lineItem.Id;
            ProductId=p_lineItem.ProductId;
            Product=p_lineItem.Product;
            StoreFrontId=p_lineItem.StoreFrontId;
            Quantity = p_lineItem.Quantity;
        }
        public int Id { get; set; }
        [Required]
        public int ProductId { get; set; }
        public Product Product { get; set; }
        [Required]
        public int StoreFrontId { get; set; }
        public int Quantity{get;set;}
    }
}