using System.Threading.Tasks;

namespace saycle.server.Data
{
    public class LanguagesInitializer : BaseInitializer
    {
        public LanguagesInitializer(SaycleContext context) : base(context)
        {
            
        }

        public override async Task Seed()
        {

            await Context.SaveChangesAsync();
        }
    }
}
