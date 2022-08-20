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
        public string Gender { get; set; } = null!;
        public int Price { get; set; }
        public int Status { get; set; }

        public virtual BrandDTO Brand { get; set; } = null!;
        public virtual ICollection<ReviewDTO> Reviews { get; set; }
        public virtual ICollection<ShoeColorDTO> ShoeColors { get; set; }
        public virtual ICollection<ShoeFileDTO> ShoeFiles { get; set; }
    }
}
