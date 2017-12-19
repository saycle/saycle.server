using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace saycle.server.Models
{
    public class Login
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid LoginID { get; set; }

        [Required]
        public DateTime Timestamp { get; set; }

        public string IP { get; set; }

        public string Browser { get; set; }

        public string Url { get; set; }

        public string Region { get; set; }

        public Guid UserID { get; set; }

        [ForeignKey(nameof(UserID))]
        public User User { get; set; }
    }
}