using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace saycle.server.Models
{
    public class User
    {
        [Key]
        public Guid UserID { get; set; }

        [Required]
        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        public string Password { get; set; }

        public string Salt { get; set; }

        public DateTime? Birthday { get; set; }

        public DateTime? CreationTime { get; set; }

        public virtual ICollection<Language> Languages { get; set; }

        public virtual ICollection<Story> CreatedStories { get; set; }

        public virtual ICollection<Story> Favorites { get; set; }

        public virtual ICollection<Cycle> Cycles { get; set; }

        public virtual ICollection<Visit> Visits { get; set; }

        public virtual ICollection<Login> Logins { get; set; }
    }
}