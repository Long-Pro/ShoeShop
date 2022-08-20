using System;
using System.Collections.Generic;

namespace DataAccess.Entities
{
    public partial class ImportNote
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int ShoeStoreId { get; set; }
        public int Quantity { get; set; }
        public DateTime Time { get; set; }

        public virtual Employee Employee { get; set; } = null!;
        public virtual ShoeStore ShoeStore { get; set; } = null!;
    }
}
