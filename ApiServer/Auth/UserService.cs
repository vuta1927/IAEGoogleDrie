using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ApiServer.Model;
using IAEGoogleDrie.Security;

namespace ApiServer.Auth
{
    public class UserService : IUserService
    {
        private readonly IaeContext _context;
        public UserService(IaeContext vdsContext)
        {
            _context = vdsContext;
        }

        public User GetCurrentUser(ClaimsIdentity identity)
        {
            IEnumerable<Claim> claims = identity.Claims;
            foreach (var claim in claims)
            {
                if (claim.Type == "id" && !string.IsNullOrEmpty(claim.Value))
                {
                    var userId = long.Parse(claim.Value);
                    return _context.Users.SingleOrDefault(x => x.Id == userId);
                }
            }

            return null;
        }

        public ICollection<Role> GetCurrentRole(long userId)
        {
            var userRoles = _context.UserRoles.Where(x => x.UserId == userId);
            var result = new List<Role>();
            foreach (var r in userRoles)
            {
                result.Add(_context.Roles.SingleOrDefault(x => x.Id == r.RoleId));
            }
            return result;
        }
    }
}
