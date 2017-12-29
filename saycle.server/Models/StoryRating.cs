using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace saycle.server.Models
{
    public class StoryRating : Rating
    {
        public Guid StoryId { get; set; }

        [ForeignKey(nameof(StoryId))]
        public Story Story { get; set; }
    }
}