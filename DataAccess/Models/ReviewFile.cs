using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class ReviewFile
    {
        public int? ReviewId { get; set; }
        public string? Link { get; set; }
        public int? FileOrder { get; set; }
        public string? FileType { get; set; }

        public virtual Review? Review { get; set; }
    }
}
