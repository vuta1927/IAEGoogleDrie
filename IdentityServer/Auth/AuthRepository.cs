using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IAEGoogleDrie.Security;

namespace IdentityServer.Auth
{
    public class AuthRepository : IAuthRepository
    {
        private IaeContext db;

        public AuthRepository(IaeContext context)
        {
            db = context;
        }

        public User GetUserById(long id)
        {
            var user = db.Users.FirstOrDefault(u => u.Id == id);
            return user;
        }

        public User GetUserByUsername(string username)
        {
            var user = db.Users.FirstOrDefault(x=>x.UserName.Equals(username));
            return user;
        }
    }
}
