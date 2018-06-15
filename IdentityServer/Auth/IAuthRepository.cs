using IAEGoogleDrie.Security;

namespace IdentityServer.Auth
{
    public interface IAuthRepository
    {
        User GetUserById(long id);
        User GetUserByUsername(string username);
    }
}