using System;
using System.Collections.Generic;

namespace DataAccess.Entities
{
    public partial class Exchange
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int BillId { get; set; }
        public int OldShoeStoreId { get; set; }
        public int NewShoeStoreId { get; set; }
        public DateTime OrderTime { get; set; }
        public DateTime? DeliveryTime { get; set; }

        public virtual Bill Bill { get; set; } = null!;
        public virtual Employee Employee { get; set; } = null!;
        public virtual ShoeStore NewShoeStore { get; set; } = null!;
        public virtual ShoeStore OldShoeStore { get; set; } = null!;
    }
}
