using System;
using System.Collections.Generic;

namespace DataAccess.DTOs
{
    public partial class ShoeDTO
    {
        public ShoeDTO()
        {
            Reviews = new HashSet<ReviewDTO>();
            ShoeColors = new HashSet<ShoeColorDTO>();
            ShoeFiles = new HashSet<ShoeFileDTO>();
        }

        public int Id { get; set; }
        public int BrandId { get; set; }
        public string Description { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string Name { get; set; } = null!;

        public string GenderType { get; set; } = null!;
        public int Price { get; set; }
        public bool IsExists { get; set; }

        public virtual BrandDTO Brand { get; set; } = null!;
        public virtual ICollection<ReviewDTO> Reviews { get; set; }
        public virtual ICollection<ShoeColorDTO> ShoeColors { get; set; }
        public virtual ICollection<ShoeFileDTO> ShoeFiles { get; set; }
    }
}
