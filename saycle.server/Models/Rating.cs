using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace saycle.server.Models
{
    public class Rating
    {
        [Key]
        public Guid RatingID { get; set; }

        public int Value { get; set; }

        public DateTime? CreationTime { get; set; }

        public Guid UserID { get; set; }

        [ForeignKey(nameof(UserID))]
        public User User { get; set; }
    }
}