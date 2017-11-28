using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace saycle.server.Models
{
    public class StoryRating : Rating
    {
        public Guid StoryID { get; set; }

        [ForeignKey(nameof(StoryID))]
        public Story Story { get; set; }
    }
}