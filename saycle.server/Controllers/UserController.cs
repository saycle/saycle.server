using System;
using System.Net;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;

using saycle.server.Data;
using saycle.server.Models;
using saycle.server.ViewModels.User;

namespace saycle.server.Controllers
{
    /// <summary>
    /// Handles requests on the <see cref="User"/> entity.
    /// </summary>
    [Route("api/[controller]")]
    public class UserController : BaseController
    {
        private UserManager<User> UserManager { get; }

        private SignInManager<User> SignInManager { get; }

        /// <summary>
        /// Initialize <see cref="User"/> controller.
        /// </summary>
        public UserController(SaycleContext context, IMapper mapper, UserManager<User> userManager,
            SignInManager<User> signInManager) : base(context, mapper)
        {
            UserManager = userManager;
            SignInManager = signInManager;
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
        /// Returns the <see cref="User"/> entity with the corresponding <see cref="IdentityUser{Guid}.UserName"/>.
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
        /// <param name="viewModel">ViewModel representation for registring a new User</param>
        [HttpPost(nameof(Register))]
        public async Task<HttpResponseMessage> Register([FromBody] RegisterUserViewModel viewModel)
        {
            var user = Mapper.Map<RegisterUserViewModel, User>(viewModel);
            user.CreationTime = DateTime.Now;
            var result = await UserManager.CreateAsync(user, viewModel.Password);
            if (result.Succeeded)
            {
                await SignInManager.SignInAsync(user, false);
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            return new HttpResponseMessage(HttpStatusCode.InternalServerError);
        }

        /// <summary>
        /// Login an existing <see cref="User"/>.
        /// </summary>
        /// <param name="viewModel">ViewModel representation with login information</param>
        [HttpPost(nameof(Login))]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<HttpResponseMessage> Login(LoginUserViewModel viewModel)
        {
            var result = await SignInManager
                .PasswordSignInAsync(viewModel.Password, viewModel.Password, viewModel.Remember, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            return new HttpResponseMessage(HttpStatusCode.Forbidden);
        }

        /// <summary>
        /// Logs the current user out.
        /// </summary>
        [HttpPost(nameof(Logout))]
        [ValidateAntiForgeryToken]
        public async Task<HttpResponseMessage> Logout()
        {
            await SignInManager.SignOutAsync();
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}
