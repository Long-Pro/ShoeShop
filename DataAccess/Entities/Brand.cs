using System;
using System.Collections.Generic;

namespace DataAccess.Entities
{
    public partial class Brand
    {
        public Brand()
        {
            Shoes = new HashSet<Shoe>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Image { get; set; } = null!;
        public bool IsExists { get; set; }


        public virtual ICollection<Shoe> Shoes { get; set; }
    }
}
