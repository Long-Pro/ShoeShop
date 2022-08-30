using System;
using System.Collections.Generic;

namespace DataAccess.Entities
{
    public partial class ShoeStore
    {
        public ShoeStore()
        {
            BillDetails = new HashSet<BillDetail>();
            Carts = new HashSet<Cart>();
            ExchangeNewShoeStores = new HashSet<Exchange>();
            ExchangeOldShoeStores = new HashSet<Exchange>();
            ImportNotes = new HashSet<ImportNote>();
        }

        public int Id { get; set; }
        public int ShoeColorId { get; set; }
        public int Size { get; set; }
        public int Quantity { get; set; }
        public bool IsExists { get; set; }

        public virtual ShoeColor ShoeColor { get; set; } = null!;
        public virtual ICollection<BillDetail> BillDetails { get; set; }
        public virtual ICollection<Cart> Carts { get; set; }
        public virtual ICollection<Exchange> ExchangeNewShoeStores { get; set; }
        public virtual ICollection<Exchange> ExchangeOldShoeStores { get; set; }
        public virtual ICollection<ImportNote> ImportNotes { get; set; }
    }
}
