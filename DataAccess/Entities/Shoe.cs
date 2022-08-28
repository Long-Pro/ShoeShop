using System;
using System.Collections.Generic;

namespace DataAccess.Entities
{
    public partial class Shoe
    {
        public Shoe()
        {
            Reviews = new HashSet<Review>();
            ShoeColors = new HashSet<ShoeColor>();
            ShoeFiles = new HashSet<ShoeFile>();
        }

        public int Id { get; set; }
        public int BrandId { get; set; }
        public string Description { get; set; } = null!;
        public int GenderType { get; set; }
        public int Price { get; set; }
        public bool IsExists { get; set; }


        public virtual Brand Brand { get; set; } = null!;
        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<ShoeColor> ShoeColors { get; set; }
        public virtual ICollection<ShoeFile> ShoeFiles { get; set; }
    }
}
