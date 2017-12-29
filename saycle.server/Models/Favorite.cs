using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace saycle.server.Models
{
    public class Favorite
    {
        [Key]
        public Guid UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public User User { get; set; }

        [Key]
        public Guid StoryId { get; set; }

        [ForeignKey(nameof(StoryId))]
        public Story Story { get; set; }
    }
}
