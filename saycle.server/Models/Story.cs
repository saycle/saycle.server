using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace saycle.server.Models
{
    public class Story
    {
        [Key]
        public Guid StoryID { get; set; }

        [Required]
        public string Title { get; set; }

        public DateTime? CreationTime { get; set; }

        public Guid UserID { get; set; }

        [ForeignKey(nameof(UserID))]
        public User Creator { get; set; }

        public virtual ICollection<Cycle> Cycles { get; set; }
    }
}