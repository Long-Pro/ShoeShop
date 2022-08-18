using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class ShoeColor
    {
        public ShoeColor()
        {
            ShoeStores = new HashSet<ShoeStore>();
        }

        public int Id { get; set; }
        public int? ShoeId { get; set; }
        public int? ColorId { get; set; }

        public virtual Color? Color { get; set; }
        public virtual Shoe? Shoe { get; set; }
        public virtual ICollection<ShoeStore> ShoeStores { get; set; }
    }
}
