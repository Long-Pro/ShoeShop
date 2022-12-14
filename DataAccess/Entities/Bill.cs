using System;
using System.Collections.Generic;

namespace DataAccess.Entities
{
    public partial class Bill
    {
        public Bill()
        {
            BillDetails = new HashSet<BillDetail>();
            Exchanges = new HashSet<Exchange>();
        }

        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int EmployeeId { get; set; }
        public int? PromotionId { get; set; }
        public DateTime OrderTime { get; set; }
        public DateTime? DeliveryTime { get; set; }
        public string Status { get; set; } = null!;

        public virtual Customer Customer { get; set; } = null!;
        public virtual Employee Employee { get; set; } = null!;
        public virtual Promotion? Promotion { get; set; }
        public virtual ICollection<BillDetail> BillDetails { get; set; }
        public virtual ICollection<Exchange> Exchanges { get; set; }
    }
}
