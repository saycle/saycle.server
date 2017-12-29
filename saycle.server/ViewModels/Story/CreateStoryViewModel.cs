using System;
using System.ComponentModel.DataAnnotations;
using saycle.server.Models.Enums;

namespace saycle.server.ViewModels.Story
{
    public class CreateStoryViewModel
    {
        [Required]
        public string Title { get; set; }

        public StoryMode? Mode { get; set; }

        public Guid CreatorId { get; set; }

        public Guid LanguageId { get; set; }
    }
}
