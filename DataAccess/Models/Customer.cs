using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Bills = new HashSet<Bill>();
            Carts = new HashSet<Cart>();
            Reviews = new HashSet<Review>();
        }

        public int Id { get; set; }
        public string? Account { get; set; }
        public string Name { get; set; } = null!;
        public DateTime BirthDate { get; set; }
        public string Phone { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? Gender { get; set; }
        public string? Avatar { get; set; }

        public virtual Account? AccountNavigation { get; set; }
        public virtual ICollection<Bill> Bills { get; set; }
        public virtual ICollection<Cart> Carts { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
    }
}
