using System;
using System.Collections.Generic;

namespace DataAccess.DTOs
{
    public partial class ImportNoteDTO
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int ShoeStoreId { get; set; }
        public int Quantity { get; set; }
        public DateTime Time { get; set; }

        public virtual EmployeeDTO Employee { get; set; } = null!;
        public virtual ShoeStoreDTO ShoeStore { get; set; } = null!;
    }
}
