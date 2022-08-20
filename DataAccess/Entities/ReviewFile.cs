using System;
using System.Collections.Generic;

namespace DataAccess.Entities
{
    public partial class ReviewFile
    {
        public int Id { get; set; }
        public int ReviewId { get; set; }
        public string Link { get; set; } = null!;
        public int? FileOrder { get; set; }
        public string FileType { get; set; } = null!;

        public virtual Review Review { get; set; } = null!;
    }
}
