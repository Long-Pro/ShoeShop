using System;
using System.Collections.Generic;

namespace DataAccess.Entities
{
    public partial class Cart
    {
        public int CustomerId { get; set; }
        public int ShoeStoreId { get; set; }
        public int Quantity { get; set; }

        public virtual Customer Customer { get; set; } = null!;
        public virtual ShoeStore ShoeStore { get; set; } = null!;
    }
}
