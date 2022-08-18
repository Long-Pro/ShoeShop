using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class ShoeFile
    {
        public int Id { get; set; }
        public int? ShoeId { get; set; }
        public string? Link { get; set; }
        public int? FileOrder { get; set; }
        public string? FileType { get; set; }

        public virtual Shoe? Shoe { get; set; }
    }
}
