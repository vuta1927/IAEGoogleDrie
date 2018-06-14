using System.Collections.Generic;
using System.Security.Claims;
using IAEGoogleDrie.Security;

namespace ApiServer.Auth
{
    public interface IUserService
    {
        User GetCurrentUser(ClaimsIdentity identity);

        ICollection<Role> GetCurrentRole(long UserId);
    }
}