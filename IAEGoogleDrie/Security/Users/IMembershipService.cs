﻿using System.Security.Claims;
using System.Threading.Tasks;

namespace IAEGoogleDrie.Security.Users
{
    public interface IMembershipService
    {
        Task<User> GetUserAsync(string userName);
        Task<bool> CheckPasswordAsync(string userName, string password);
        Task<ClaimsPrincipal> CreateClaimsPrincipal(User user);
    }
}