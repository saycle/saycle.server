using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace saycle.server.Models
{
    public class UserLanguage
    {
        [Key]
        public Guid UserID { get; set; }

        [ForeignKey(nameof(UserID))]
        public User User { get; set; }
        
        [Key]
        public Guid LanguageID { get; set; }

        [ForeignKey(nameof(LanguageID))]
        public Language Language { get; set; }
    }
}
