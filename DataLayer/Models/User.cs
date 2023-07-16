using System;
using System.Collections.Generic;

namespace SWD392_Project.Models
{
    public partial class User
    {
        public User()
        {
            Drugs = new HashSet<Drug>();
            Medicines = new HashSet<Medicine>();
            Reports = new HashSet<Report>();
        }

        public int Id { get; set; }
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Fullname { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public int RoleId { get; set; }
        public bool IsDelete { get; set; }
        public bool? IsActive { get; set; }

        public virtual Role Role { get; set; } = null!;
        public virtual ICollection<Drug> Drugs { get; set; }
        public virtual ICollection<Medicine> Medicines { get; set; }
        public virtual ICollection<Report> Reports { get; set; }
    }
}
