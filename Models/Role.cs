using System;
using System.Collections.Generic;

namespace SWD392_Project.Models
{
    public partial class Role
    {
        public Role()
        {
            Users = new HashSet<User>();
        }

        public int RoleId { get; set; }
        public string RoleName { get; set; } = null!;
        public bool IsDelete { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
