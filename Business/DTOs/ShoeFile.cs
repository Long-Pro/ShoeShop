using System;
using System.Collections.Generic;

namespace DataAccess.DTOs
{
    public partial class ShoeFileDTO
    {
        public int Id { get; set; }
        public int ShoeId { get; set; }
        public string Link { get; set; } = null!;
        public int? FileOrder { get; set; }
        public string FileType { get; set; } = null!;

        public virtual ShoeDTO Shoe { get; set; } = null!;
    }
}
