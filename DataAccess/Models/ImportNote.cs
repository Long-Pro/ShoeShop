using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class ImportNote
    {
        public int Id { get; set; }
        public int? EmployeeId { get; set; }
        public int? ShoeStoreId { get; set; }
        public int Quantity { get; set; }
        public DateTime Time { get; set; }

        public virtual Employee? Employee { get; set; }
        public virtual ShoeStore? ShoeStore { get; set; }
    }
}
