using System;
using System.Collections.Generic;

namespace DataAccess.Models
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
        public int? BrandId { get; set; }
        public string Description { get; set; } = null!;
        public string? Gender { get; set; }
        public int Price { get; set; }
        public int? Status { get; set; }

        public virtual Brand? Brand { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<ShoeColor> ShoeColors { get; set; }
        public virtual ICollection<ShoeFile> ShoeFiles { get; set; }
    }
}
