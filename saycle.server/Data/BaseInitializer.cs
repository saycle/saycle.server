using System;
using System.Collections.Generic;
using System.Linq;
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

        public abstract Task Seed();
    }
}
