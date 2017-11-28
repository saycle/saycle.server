using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace saycle.server.Models
{
    public class CycleRating : Rating
    {
        public Guid CycleID { get; set; }

        [ForeignKey(nameof(CycleID))]
        public Cycle Cycle { get; set; }
    }
}