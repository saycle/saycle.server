using System.Linq;
using System.Threading.Tasks;
using saycle.server.Models;

namespace saycle.server.Data
{
    public class UsersInitializer : BaseInitializer
    {
        public UsersInitializer(SaycleContext context) : base(context)
        {
            
        }

        public override async Task Seed()
        {
            if (Context.Users.Any())
            {
                return;
            }
            var adminUser = new User()
            {
                UserName = "Administrator",
                Email = "admin@saycle.xyz",
                
            };
            await Context.SaveChangesAsync();
        }
    }
}
