using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace saycle.server.Models
{
    public class Role : IdentityRole<Guid>
    {
        public Role() { }

        public Role(string roleName) : base(roleName) { }

        public virtual ICollection<User> Users { get; set; }
    }
}
