using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class BillDetail
    {
        public int BillId { get; set; }
        public int ShoeStoreId { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }

        public virtual Bill Bill { get; set; } = null!;
        public virtual ShoeStore ShoeStore { get; set; } = null!;
    }
}
