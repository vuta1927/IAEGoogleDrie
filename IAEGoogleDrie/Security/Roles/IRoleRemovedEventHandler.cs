using System.Threading.Tasks;

namespace IAEGoogleDrie.Security.Roles
{
    public interface IRoleRemovedEventHandler
    {
        Task RoleRemovedAsync(string roleName);
    }
}