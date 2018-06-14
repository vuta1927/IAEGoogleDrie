using System.Collections.Generic;
using System.Threading.Tasks;

namespace IAEGoogleDrie.Security.Roles
{
    public interface IRoleProvider
    {
        Task<List<string>> GetRoleNamesAsync();
        Task<Role> FindByNormalizedRoleNameAsync(string normalizedRoleName);
    }
}