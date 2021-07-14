using System;
using System.Collections.Generic;

#nullable disable

namespace StoreDL.Entities
{
    public partial class LineItem
    {
        public int Id { get; set; }
        public int? ProductId { get; set; }
        public int? StoreId { get; set; }
        public int? Quantity { get; set; }

        public virtual Products Product { get; set; }
        public virtual StoreFront Store { get; set; }
    }
}
