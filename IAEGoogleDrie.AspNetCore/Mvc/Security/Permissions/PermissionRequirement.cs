using IAEGoogleDrie.Helpers.Exception;
using IAEGoogleDrie.Security.Permissions;
using Microsoft.AspNetCore.Authorization;

namespace IAEGoogleDrie.AspNetCore.Mvc.Security.Permissions
{
    public class PermissionRequirement : IAuthorizationRequirement
    {
        public PermissionRequirement(Permission permission)
        {
            Throw.IfArgumentNull(permission, nameof(permission));
            Permission = permission;
        }

        public Permission Permission { get; set; }
    }
}