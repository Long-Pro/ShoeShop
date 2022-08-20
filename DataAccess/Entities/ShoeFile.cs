using System;
using System.Collections.Generic;

namespace DataAccess.Entities
{
    public partial class ShoeFile
    {
        public int Id { get; set; }
        public int ShoeId { get; set; }
        public string Link { get; set; } = null!;
        public int? FileOrder { get; set; }
        public string FileType { get; set; } = null!;

        public virtual Shoe Shoe { get; set; } = null!;
    }
}
