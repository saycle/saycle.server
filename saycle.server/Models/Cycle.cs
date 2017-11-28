using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace saycle.server.Models
{
    public class Cycle
    {
        [Key]
        public Guid CycleID { get; set; }

        public string Text { get; set; }

        public DateTime? CreationTime { get; set; }

        public Guid UserID { get; set; }

        [ForeignKey(nameof(UserID))]
        public User Author { get; set; }

        public Guid StoryID { get; set; }

        [ForeignKey(nameof(StoryID))]
        public Story Story { get; set; }

        public virtual ICollection<StoryRating> Ratings { get; set; }

        [NotMapped]
        public double Rating => Ratings.Average(r => r.Value);

        [NotMapped]
        public IEnumerable<User> Raters => Ratings.Select(r => r.User);
    }
}