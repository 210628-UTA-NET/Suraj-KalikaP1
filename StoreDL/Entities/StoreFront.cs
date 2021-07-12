using System;
using System.Collections.Generic;

#nullable disable

namespace StoreDL.Entities
{
    public partial class StoreFront
    {
        public StoreFront()
        {
            LineItems = new HashSet<LineItem>();
        }

        public int Id { get; set; }
        public string StoreName { get; set; }
        public string Address { get; set; }

        public virtual ICollection<LineItem> LineItems { get; set; }
    }
}
