using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace saycle.server.ViewModels.User
{
    public class LoginUserViewModel
    {
        public string UserName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public bool Remember { get; set; }
    }
}
