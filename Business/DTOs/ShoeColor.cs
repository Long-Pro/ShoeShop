using System;
using System.Collections.Generic;

namespace DataAccess.DTOs
{
    public partial class ShoeColorDTO
    {
        public ShoeColorDTO()
        {
            ShoeStores = new HashSet<ShoeStoreDTO>();
        }

        public int Id { get; set; }
        public int ShoeId { get; set; }
        public string Color { get; set; } = null!;
        public string? Hex { get; set; }
        public string Image { get; set; } = null!;
        public bool IsExists { get; set; }

        public virtual ShoeDTO Shoe { get; set; } = null!;
        public virtual ICollection<ShoeStoreDTO> ShoeStores { get; set; }
    }
}
