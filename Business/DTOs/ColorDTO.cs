using System;
using System.Collections.Generic;

namespace DataAccess.DTOs
{
    public partial class ColorDTO
    {
        public ColorDTO()
        {
            ShoeColors = new HashSet<ShoeColorDTO>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Hex { get; set; } = null!;

        public virtual ICollection<ShoeColorDTO> ShoeColors { get; set; }
    }
}
