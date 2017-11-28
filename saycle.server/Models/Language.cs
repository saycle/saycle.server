using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace saycle.server.Models
{
    public class Language
    {
        [Key]
        public Guid LanguageID { get; set; }

        public string Code { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Story> Stories { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}