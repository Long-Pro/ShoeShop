using System;
using System.Collections.Generic;

namespace DataAccess.Entities
{
    public partial class Color
    {
        public Color()
        {
            ShoeColors = new HashSet<ShoeColor>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Hex { get; set; } = null!;

        public virtual ICollection<ShoeColor> ShoeColors { get; set; }
    }
}
