using System;
using System.Collections.Generic;

namespace DataAccess.DTOs
{
    public partial class BillDTO
    {
        public BillDTO()
        {
            BillDetails = new HashSet<BillDetailDTO>();
            Exchanges = new HashSet<ExchangeDTO>();
        }

        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int EmployeeId { get; set; }
        public int? PromotionId { get; set; }
        public DateTime OrderTime { get; set; }
        public DateTime? DeliveryTime { get; set; }
        public int Status { get; set; }

        public virtual CustomerDTO Customer { get; set; } = null!;
        public virtual EmployeeDTO Employee { get; set; } = null!;
        public virtual PromotionDTO? Promotion { get; set; }
        public virtual ICollection<BillDetailDTO> BillDetails { get; set; }
        public virtual ICollection<ExchangeDTO> Exchanges { get; set; }
    }
}
