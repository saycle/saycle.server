using System;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using saycle.server.Data;
using saycle.server.Models;
using saycle.server.ViewModels.Story;
using saycle.server.ViewModels.User;

namespace saycle.server.Controllers
{
    /// <summary>
    /// Handles requests on the <see cref="User"/> entity.
    /// </summary>
    [Route("api/[controller]")]
    public class UserController : BaseController
    {
        /// <summary>
        /// Initialize <see cref="User"/> controller.
        /// </summary>
        public UserController(SaycleContext context, IMapper mapper) : base(context, mapper)
        {
        }

        /// <summary>
        /// Returns all <see cref="User"/> entities.
        /// </summary>
        /// <returns>User entities as JSON</returns>
        [HttpGet]
        public JsonResult Get()
        {
            return Json(Context.Users.ToList());
        }

        /// <summary>
        /// Returns the <see cref="User"/> entity with the corresponding <see cref="User.UserID"/>.
        /// </summary>
        /// <param name="id">Identitfier of the user</param>
        /// <returns>User entity as JSON</returns>
        [HttpGet("{id}")]
        public JsonResult Get(Guid id)
        {
            return Json(Context.Users.FirstOrDefault(u => Equals(u.UserID, id)));
        }

        /// <summary>
        /// Returns the <see cref="User"/> entity with the corresponding <see cref="User.UserName"/>.
        /// </summary>
        /// <param name="username">Username</param>
        /// <returns>User entity as JSON</returns>
        [HttpGet("{username}")]
        public JsonResult Get(string username)
        {
            return Json(Context.Users.FirstOrDefault(u => Equals(u.UserName, username)));
        }

        /// <summary>
        /// Creates a new <see cref="User"/>.
        /// </summary>
        /// <param name="viewModel">ViewModel representation for creating a new Story</param>
        [HttpPost]
        public JsonResult Post([FromBody] CreateUserViewModel viewModel)
        {
            var user = Mapper.Map<CreateUserViewModel, User>(viewModel);
            user.CreationTime = DateTime.Now;
            user = Context.Users.Add(user).Entity;
            Context.SaveChanges();
            return Json(user);
        }
    }
}
