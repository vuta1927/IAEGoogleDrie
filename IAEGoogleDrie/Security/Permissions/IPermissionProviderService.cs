using System.Collections.Generic;

namespace IAEGoogleDrie.Security.Permissions
{
    public interface IPermissionProviderService
    {
        IEnumerable<Permission> GetPermissions();
        Permission GetPermissionBy(string name);
    }
}