using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace saycle.server.Models
{
    public class Favorite
    {
        [Key]
        public Guid UserID { get; set; }

        [ForeignKey(nameof(UserID))]
        public User User { get; set; }

        [Key]
        public Guid StoryID { get; set; }

        [ForeignKey(nameof(StoryID))]
        public Story Story { get; set; }
    }
}
