using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace saycle.server.Models
{
    public class Bookmark
    {
        [Key]
        public Guid BookmarkID { get; set; }

        public DateTime? CreationTime { get; set; }

        public Guid UserID { get; set; }

        [ForeignKey(nameof(UserID))]
        public User User { get; set; }

        public Guid StoryID { get; set; }

        [ForeignKey(nameof(StoryID))]
        public Story Story { get; set; }
    }
}