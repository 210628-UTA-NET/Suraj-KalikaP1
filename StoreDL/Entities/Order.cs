using System;
using System.Collections.Generic;

#nullable disable

namespace StoreDL.Entities
{
    public partial class Order
    {
        public Order()
        {
            Customers = new HashSet<Customer>();
        }

        public int Id { get; set; }
        public int? LineItemId { get; set; }

        public virtual LineItem LineItem { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
    }
}
