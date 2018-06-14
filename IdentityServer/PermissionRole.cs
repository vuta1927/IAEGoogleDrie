using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IAEGoogleDrie.Security;
using IAEGoogleDrie.Security.Permissions;

namespace IdentityServer
{
    public class PermissionRole
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public virtual Role Role { get; set; }
        public int PermissionId { get; set; }
        public virtual Permission Permission { get; set; }
    }
}
