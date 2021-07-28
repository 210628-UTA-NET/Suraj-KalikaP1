using System.ComponentModel.DataAnnotations;
using StoreModel;

namespace StoreWebUI.Models
{
    public class OrderViewModel
    {
        public OrderViewModel()
        {

        }
        public OrderViewModel(Order p_order)
        {
            Id= p_order.Id;
            StoreFrontId=p_order.StoreFrontId;
            CustomerId=p_order.CustomerId;
            TotalPrice=p_order.TotalPrice;
        }

        public int Id{get;set;}
        [Required]
        public int StoreFrontId{get;set;}
        [Required]
        public int CustomerId{get;set;}
        public double TotalPrice{get;set;}
    }
}