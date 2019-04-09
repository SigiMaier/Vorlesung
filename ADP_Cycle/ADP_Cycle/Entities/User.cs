
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class User
    {
        IPermissions permissions;

        public void GetPermissions()
        {
            permissions.GrantPermissions();
        }
    }
}
