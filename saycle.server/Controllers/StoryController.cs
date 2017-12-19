using System;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using saycle.server.Data;
using saycle.server.Models;
using saycle.server.ViewModels.Story;

namespace saycle.server.Controllers
{
    /// <summary>
    /// Handles requests on the <see cref="Story"/> entity.
    /// </summary>
    [Route("api/[controller]")]
    public class StoryController : BaseController
    {
        /// <summary>
        /// Initialize <see cref="Story"/> controller.
        /// </summary>
        public StoryController(SaycleContext context, IMapper mapper) : base(context, mapper)
        {
        }

        /// <summary>
        /// Returns all <see cref="Story"/> entities.
        /// </summary>
        /// <returns>Story entities as JSON</returns>
        [HttpGet]
        public JsonResult Get()
        {
            return Json(Context.Stories.ToList());
        }

        /// <summary>
        /// Returns the <see cref="Story"/> entity with the corresponding <see cref="Story.StoryID"/>.
        /// </summary>
        /// <param name="id">Identitfier of the user</param>
        /// <returns>Story entity as JSON</returns>
        [HttpGet("{id}")]
        public JsonResult Get(Guid id)
        {
            return Json(Context.Stories.FirstOrDefault(s => Equals(s.StoryID, id)));
        }

        /// <summary>
        /// Returns the <see cref="Story"/> entity with the corresponding <see cref="Story.Title"/>.
        /// </summary>
        /// <param name="title">Story title</param>
        /// <returns>Story entity as JSON</returns>
        [HttpGet("{title}")]
        public JsonResult Get(string title)
        {
            return Json(Context.Stories.FirstOrDefault(s => Equals(s.Title, title)));
        }

        /// <summary>
        /// Creates a new <see cref="Story"/>.
        /// </summary>
        /// <param name="viewModel">ViewModel representation for creating a new Story</param>
        [HttpPost]
        public JsonResult Post([FromBody]CreateStoryViewModel viewModel)
        {
            var story = Mapper.Map<CreateStoryViewModel, Story>(viewModel);
            story.CreationTime = DateTime.Now;
            story = Context.Stories.Add(story).Entity;
            Context.SaveChanges();
            return Json(story);
        }
    }
}
