using System;
using System.Collections.Generic;

namespace DataAccess.DTOs
{
    public partial class BrandDTO
    {
        public BrandDTO()
        {
            Shoes = new HashSet<ShoeDTO>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Image { get; set; } = null!;

        public virtual ICollection<ShoeDTO> Shoes { get; set; }
    }
}
