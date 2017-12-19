using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using saycle.server.Models.Enums;

namespace saycle.server.Models
{
    public class Story
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid StoryID { get; set; }

        [Required]
        public string Title { get; set; }

        public StoryMode Mode { get; set; }

        public DateTime? CreationTime { get; set; }

        public bool Deleted { get; set; }

        public Guid CreatorID { get; set; }

        [ForeignKey(nameof(CreatorID))]
        public User Creator { get; set; }

        public Guid LanguageID { get; set; }

        [ForeignKey(nameof(LanguageID))]
        public Language Language { get; set; }

        public virtual ICollection<Cycle> Cycles { get; set; }

        public virtual ICollection<StoryRating> Ratings { get; set; }

        public virtual ICollection<Bookmark> Bookmarks { get; set; }

        [NotMapped]
        public string Text => string.Join(" ", Cycles?.OrderBy(c => c.CreationTime).Select(c => c.Text ?? string.Empty) ?? new[] {""} );

        [NotMapped]
        public IEnumerable<User> Authors => Cycles?.Select(c => c.Author);

        [NotMapped]
        public double? Rating => Ratings?.Average(r => r.Value);

        [NotMapped]
        public IEnumerable<User> Raters => Ratings?.Select(r => r.User);

        [NotMapped]
        public IEnumerable<User> Bookmarkers => Bookmarks?.Select(b => b.User);
    }
}