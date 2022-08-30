using System;
using System.Collections.Generic;

namespace DataAccess.DTOs
{
    public partial class ReviewFileDTO
    {
        public int Id { get; set; }
        public int ReviewId { get; set; }
        public string Link { get; set; } = null!;
        public int? FileOrder { get; set; }
        public string FileType { get; set; } = null!;

        public virtual ReviewDTO Review { get; set; } = null!;
    }
}
