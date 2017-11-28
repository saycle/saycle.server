using System;
using System.ComponentModel.DataAnnotations;

namespace saycle.server.Models
{
    public class Visit
    {
        [Key]
        public Guid VisitID { get; set; }

        [Required]
        public DateTime Timestamp { get; set; }

        public virtual Cycle Cycle { get; set; }

        public virtual User User { get; set; }
    }
}