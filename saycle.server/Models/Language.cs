using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace saycle.server.Models
{
    public class Language
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid LanguageID { get; set; }

        public string Code { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Story> Stories { get; set; }

        public virtual ICollection<UserLanguage> Users { get; set; }
    }
}