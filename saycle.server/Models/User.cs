using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace saycle.server.Models
{
    public class User : IdentityUser<Guid>
    {
        public User() { }

        public User(string userName) : base(userName) { }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime? Birthday { get; set; }

        public DateTime? CreationTime { get; set; }

        public bool Verified { get; set; }

        public bool Deleted { get; set; }

        public virtual ICollection<UserLanguage> Languages { get; set; }

        public virtual ICollection<Story> CreatedStories { get; set; }

        public virtual ICollection<Favorite> Favorites { get; set; }

        public virtual ICollection<Cycle> Cycles { get; set; }

        public virtual ICollection<Rating> Ratings { get; set; }

        public virtual ICollection<Visit> Visits { get; set; }

        public virtual ICollection<Login> Logins { get; set; }

    }
}