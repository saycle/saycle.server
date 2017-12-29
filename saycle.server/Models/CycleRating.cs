using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace saycle.server.Models
{
    public class CycleRating : Rating
    {
        public Guid CycleId { get; set; }

        [ForeignKey(nameof(CycleId))]
        public Cycle Cycle { get; set; }
    }
}