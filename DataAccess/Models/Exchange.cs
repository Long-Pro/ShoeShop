using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class Exchange
    {
        public int Id { get; set; }
        public int? EmployeeId { get; set; }
        public int? BillId { get; set; }
        public int? OldShoeStoreId { get; set; }
        public int? NewShoeStoreId { get; set; }
        public DateTime OrderTime { get; set; }
        public DateTime? DeliveryTime { get; set; }

        public virtual Bill? Bill { get; set; }
        public virtual Employee? Employee { get; set; }
        public virtual ShoeStore? NewShoeStore { get; set; }
        public virtual ShoeStore? OldShoeStore { get; set; }
    }
}
