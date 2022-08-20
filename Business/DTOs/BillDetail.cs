using System;
using System.Collections.Generic;

namespace DataAccess.DTOs
{
    public partial class BillDetailDTO
    {
        public int BillId { get; set; }
        public int ShoeStoreId { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }

        public virtual BillDTO Bill { get; set; } = null!;
        public virtual ShoeStoreDTO ShoeStore { get; set; } = null!;
    }
}
