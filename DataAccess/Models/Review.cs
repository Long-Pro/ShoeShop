using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class Review
    {
        public int Id { get; set; }
        public int? ShoeId { get; set; }
        public int? CustomerId { get; set; }
        public int? Star { get; set; }
        public string? Comment { get; set; }

        public virtual Customer? Customer { get; set; }
        public virtual Shoe? Shoe { get; set; }
    }
}
