using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace saycle.server.Models
{
    public class Cycle
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }

        public string Text { get; set; }

        public DateTime? CreationTime { get; set; }

        public bool Deleted { get; set; }

        public Guid UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public User Author { get; set; }

        public Guid StoryId { get; set; }

        [ForeignKey(nameof(StoryId))]
        public Story Story { get; set; }

        public virtual ICollection<StoryRating> Ratings { get; set; }

        [NotMapped]
        public double? Rating => Ratings?.Average(r => r.Value);

        [NotMapped]
        public IEnumerable<User> Raters => Ratings?.Select(r => r.User);
    }
}