using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class Account
    {
        public Account()
        {
            Customers = new HashSet<Customer>();
            Employees = new HashSet<Employee>();
        }

        public string Account1 { get; set; } = null!;
        public string Password { get; set; } = null!;
        public int? RoleId { get; set; }

        public virtual Role? Role { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
