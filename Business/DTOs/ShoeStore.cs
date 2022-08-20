using System;
using System.Collections.Generic;

namespace DataAccess.DTOs
{
    public partial class ShoeStoreDTO
    {
        public ShoeStoreDTO()
        {
            BillDetails = new HashSet<BillDetailDTO>();
            Carts = new HashSet<CartDTO>();
            ExchangeNewShoeStores = new HashSet<ExchangeDTO>();
            ExchangeOldShoeStores = new HashSet<ExchangeDTO>();
            ImportNotes = new HashSet<ImportNoteDTO>();
        }

        public int Id { get; set; }
        public int ShoeColorId { get; set; }
        public int Size { get; set; }
        public int Quantity { get; set; }

        public virtual ShoeColorDTO ShoeColor { get; set; } = null!;
        public virtual ICollection<BillDetailDTO> BillDetails { get; set; }
        public virtual ICollection<CartDTO> Carts { get; set; }
        public virtual ICollection<ExchangeDTO> ExchangeNewShoeStores { get; set; }
        public virtual ICollection<ExchangeDTO> ExchangeOldShoeStores { get; set; }
        public virtual ICollection<ImportNoteDTO> ImportNotes { get; set; }
    }
}
