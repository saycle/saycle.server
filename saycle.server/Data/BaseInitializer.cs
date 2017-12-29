using System.Threading.Tasks;

namespace saycle.server.Data
{
    public abstract class BaseInitializer
    {
        protected SaycleContext Context { get; }

        public BaseInitializer(SaycleContext context)
        {
            Context = context;
        }

        public abstract void Seed();
    }
}
