using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class Employee
    {
        public Employee()
        {
            Bills = new HashSet<Bill>();
            Exchanges = new HashSet<Exchange>();
            ImportNotes = new HashSet<ImportNote>();
        }

        public int Id { get; set; }
        public string? Account { get; set; }
        public string Name { get; set; } = null!;
        public DateTime BirthDate { get; set; }
        public string Phone { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? Gender { get; set; }

        public virtual Account? AccountNavigation { get; set; }
        public virtual ICollection<Bill> Bills { get; set; }
        public virtual ICollection<Exchange> Exchanges { get; set; }
        public virtual ICollection<ImportNote> ImportNotes { get; set; }
    }
}
