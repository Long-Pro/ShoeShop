using System;
using System.Collections.Generic;

namespace DataAccess.DTOs
{
    public partial class ExchangeDTO
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int BillId { get; set; }
        public int OldShoeStoreId { get; set; }
        public int NewShoeStoreId { get; set; }
        public DateTime OrderTime { get; set; }
        public DateTime? DeliveryTime { get; set; }

        public virtual BillDTO Bill { get; set; } = null!;
        public virtual EmployeeDTO Employee { get; set; } = null!;
        public virtual ShoeStoreDTO NewShoeStore { get; set; } = null!;
        public virtual ShoeStoreDTO OldShoeStore { get; set; } = null!;
    }
}
