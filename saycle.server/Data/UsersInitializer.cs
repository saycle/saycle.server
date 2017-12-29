using System.Linq;
using Microsoft.AspNetCore.Identity;

using saycle.server.Models;
using saycle.server.Models.Enums;

namespace saycle.server.Data
{
    public class UsersInitializer : BaseInitializer
    {
        private UserManager<User> UserManager { get; }

        public UsersInitializer(SaycleContext context, UserManager<User> userManager) : base(context)
        {
            UserManager = userManager;
        }

        public override void Seed()
        {
            if (Context.Users.Any())
            {
                return;
            }
            var adminUser = new User()
            {
                UserName = "admin",
                Email = "admin@saycle.xyz",
                EmailConfirmed = true,
                Verified = true
            };
            UserManager.CreateAsync(adminUser, "QfJGkCFFEp9^pxM$RYX!x6").Wait();
            UserManager.AddToRoleAsync(adminUser, UserRoles.Administrator).Wait();
        }
    }
}
