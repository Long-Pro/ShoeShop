using System;
using System.Collections.Generic;

namespace DataAccess.DTOs
{
    public partial class CartDTO
    {
        public int CustomerId { get; set; }
        public int ShoeStoreId { get; set; }
        public int Quantity { get; set; }

        public virtual CustomerDTO Customer { get; set; } = null!;
        public virtual ShoeStoreDTO ShoeStore { get; set; } = null!;
    }
}
