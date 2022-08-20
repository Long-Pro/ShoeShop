using System;
using System.Collections.Generic;

namespace DataAccess.DTOs
{
    public partial class EmployeeDTO
    {
        public EmployeeDTO()
        {
            Bills = new HashSet<BillDTO>();
            Exchanges = new HashSet<ExchangeDTO>();
            ImportNotes = new HashSet<ImportNoteDTO>();
        }

        public int Id { get; set; }
        public int AccountId { get; set; }
        public string Name { get; set; } = null!;
        public DateTime BirthDate { get; set; }
        public string Phone { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string IdentityCard { get; set; } = null!;
        public string? Gender { get; set; }
        public string Avatar { get; set; } = null!;

        public virtual AccountDTO Account { get; set; } = null!;
        public virtual ICollection<BillDTO> Bills { get; set; }
        public virtual ICollection<ExchangeDTO> Exchanges { get; set; }
        public virtual ICollection<ImportNoteDTO> ImportNotes { get; set; }
    }
}
