using System;
using System.Collections.Generic;

namespace DataAccess.DTOs
{
    public partial class AccountDTO
    {
        public AccountDTO()
        {
            Customers = new HashSet<CustomerDTO>();
            Employees = new HashSet<EmployeeDTO>();
        }

        public int Id { get; set; }
        public string AccountValue { get; set; } = null!;
        public string Password { get; set; } = null!;
        public int RoleId { get; set; }

        public virtual RoleDTO Role { get; set; } = null!;
        public virtual ICollection<CustomerDTO> Customers { get; set; }
        public virtual ICollection<EmployeeDTO> Employees { get; set; }
    }
}
