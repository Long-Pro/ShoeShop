using System;
using System.Collections.Generic;

namespace DataAccess.Entities
{
    public partial class Promotion
    {
        public Promotion()
        {
            Bills = new HashSet<Bill>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Reason { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int PercentDiscount { get; set; }
        public int? MaxDiscountAmount { get; set; }
        public int? MaxQuantity { get; set; }
        public int UsedQuantity { get; set; }
        public bool IsExists { get; set; }

        public virtual ICollection<Bill> Bills { get; set; }
    }
}
