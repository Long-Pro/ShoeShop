using System;
using System.Collections.Generic;

namespace DataAccess.Entities
{
    public partial class Review
    {
        public Review()
        {
            ReviewFiles = new HashSet<ReviewFile>();
        }

        public int Id { get; set; }
        public int ShoeId { get; set; }
        public int CustomerId { get; set; }
        public int Star { get; set; }
        public string Comment { get; set; } = null!;

        public virtual Customer Customer { get; set; } = null!;
        public virtual Shoe Shoe { get; set; } = null!;
        public virtual ICollection<ReviewFile> ReviewFiles { get; set; }
    }
}
