using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace saycle.server.Data
{
    public class Initializer : DropCreateDatabaseIfModelChanges<SchoolContext>
    {
    }
}
