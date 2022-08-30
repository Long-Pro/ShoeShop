using System;
using System.Collections.Generic;

namespace DataAccess.DTOs
{
    public partial class ReviewDTO
    {
        public ReviewDTO()
        {
            ReviewFiles = new HashSet<ReviewFileDTO>();
        }

        public int Id { get; set; }
        public int ShoeId { get; set; }
        public int CustomerId { get; set; }
        public int Star { get; set; }
        public string Comment { get; set; } = null!;

        public virtual CustomerDTO Customer { get; set; } = null!;
        public virtual ShoeDTO Shoe { get; set; } = null!;
        public virtual ICollection<ReviewFileDTO> ReviewFiles { get; set; }
    }
}
