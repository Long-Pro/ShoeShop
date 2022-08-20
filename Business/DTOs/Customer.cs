using System;
using System.Collections.Generic;

namespace DataAccess.DTOs
{
    public partial class CustomerDTO
    {
        public CustomerDTO()
        {
            Bills = new HashSet<BillDTO>();
            Carts = new HashSet<CartDTO>();
            Reviews = new HashSet<ReviewDTO>();
        }

        public int Id { get; set; }
        public int AccountId { get; set; }
        public string Name { get; set; } = null!;
        public DateTime BirthDate { get; set; }
        public string Phone { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Gender { get; set; } = null!;
        public string Avatar { get; set; } = null!;

        public virtual AccountDTO Account { get; set; } = null!;
        public virtual ICollection<BillDTO> Bills { get; set; }
        public virtual ICollection<CartDTO> Carts { get; set; }
        public virtual ICollection<ReviewDTO> Reviews { get; set; }
    }
}
