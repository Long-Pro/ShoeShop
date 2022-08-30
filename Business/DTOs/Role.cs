using System;
using System.Collections.Generic;

namespace DataAccess.DTOs
{
    public partial class RoleDTO
    {
        public RoleDTO()
        {
            Accounts = new HashSet<AccountDTO>();
        }

        public int Id { get; set; }
        public string Type { get; set; } = null!;
        public string Name { get; set; } = null!;

        public virtual ICollection<AccountDTO> Accounts { get; set; }
    }
}
