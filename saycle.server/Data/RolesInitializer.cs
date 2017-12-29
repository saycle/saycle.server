using System;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Identity;
using saycle.server.Models;
using saycle.server.Models.Enums;

namespace saycle.server.Data
{
    public class RolesInitializer : BaseInitializer
    {
        private RoleManager<Role> RoleManager { get; }

        public RolesInitializer(SaycleContext context, RoleManager<Role> roleManager) : base(context)
        {
            RoleManager = roleManager;
        }

        public override void Seed()
        {
            if (Context.Roles.Any())
            {
                return;
            }
            var roleNames = typeof(UserRoles).GetFields(BindingFlags.Public | BindingFlags.Static)
                .Where(f => f.FieldType == typeof(string)).Select(f => (string)f.GetValue(null));
            foreach (var roleName in roleNames)
            {
                var role = new Role(roleName);
                RoleManager.CreateAsync(role).Wait();
            }
            Context.SaveChangesAsync().Wait();
        }
    }
}
