using System;
using System.Collections.Generic;

#nullable disable

namespace StoreDL.Entities
{
    public partial class Customer
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public int? Orders { get; set; }
        public string PhoneNumber { get; set; }

        public virtual Order OrdersNavigation { get; set; }
    }
}
