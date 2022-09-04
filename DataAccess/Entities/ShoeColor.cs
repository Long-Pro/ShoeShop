using System;
using System.Collections.Generic;

namespace DataAccess.Entities
{
    public partial class ShoeColor
    {
        public ShoeColor()
        {
            ShoeStores = new HashSet<ShoeStore>();
        }

        public int Id { get; set; }
        public int ShoeId { get; set; }
        public string Color { get; set; } = null!;
        public string? Hex { get; set; }
        public string Image { get; set; } = null!;
        public bool IsExists { get; set; }

        public virtual Shoe Shoe { get; set; } = null!;
        public virtual ICollection<ShoeStore> ShoeStores { get; set; }
    }
}
