﻿using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using IAEGoogleDrie.Helpers.Extensions;
using IAEGoogleDrie.Security;
using IAEGoogleDrie.Security.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace IAEGoogleDrie.AspNetCore.Mvc.Security
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly IOptions<IdentityOptions> _identityOptions;
        public UserService(UserManager<User> userManager, IOptions<IdentityOptions> identityOptions)
        {
            _userManager = userManager;
            _identityOptions = identityOptions;
        }

        public async Task<User> CreateUserAsync(string userName, string email, string[] roleNames, string password, Action<string, string> reportError)
        {
            var result = true;

            if (string.IsNullOrWhiteSpace(userName))
            {
                reportError("UserName", "A user name is required.");
                result = false;
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                reportError("Password", "A password is required.");
                result = false;
            }

            if (string.IsNullOrWhiteSpace(email))
            {
                reportError("Email", "An email is required.");
                result = false;
            }

            if (!result)
            {
                return null;
            }

            if (await _userManager.FindByEmailAsync(email) != null)
            {
                reportError(string.Empty, "The email is already used.");
                return null;
            }

            var user = new User
            {
                UserName = userName,
                Email = email,
//                RoleNames = new List<string>(roleNames)
            };
            
            var identityResult = await _userManager.CreateAsync(user, password);

            if (!identityResult.Succeeded)
            {
                ProcessValidationErrors(identityResult.Errors, user, reportError);
            }

            var roleResult = await _userManager.AddToRolesAsync(user, roleNames);
            if (!roleResult.Succeeded)
            {
                await _userManager.DeleteAsync(user);
            }

            return user;
        }


        public async Task<bool> ChangePasswordAsync(User user, string currentPassword, string newPassword, Action<string, string> reportError)
        {
            var identityResult = await _userManager.ChangePasswordAsync(user, currentPassword, newPassword);

            if (!identityResult.Succeeded)
            {
                ProcessValidationErrors(identityResult.Errors, user, reportError);
            }

            return identityResult.Succeeded;
        }

        public Task<User> GetAuthenticatedUserAsync(ClaimsPrincipal principal)
        {
            if (principal == null)
            {
                return Task.FromResult<User>(null);
            }

            return _userManager.GetUserAsync(principal);
        }

        private void ProcessValidationErrors(IEnumerable<IdentityError> errors, User user, Action<string, string> reportError)
        {
            foreach (var error in errors)
            {
                switch (error.Code)
                {
                    // Password
                    case "PasswordRequiresDigit":
                        reportError("Password", "Passwords must have at least one digit ('0'-'9').");
                        break;
                    case "PasswordRequiresLower":
                        reportError("Password", "Passwords must have at least one lowercase ('a'-'z').");
                        break;
                    case "PasswordRequiresUpper":
                        reportError("Password", "Passwords must have at least one uppercase('A'-'Z').");
                        break;
                    case "PasswordRequiresNonAlphanumeric":
                        reportError("Password", "Passwords must have at least one non letter or digit character.");
                        break;
                    case "PasswordTooShort":
                        reportError("Password", "Passwords must be at least {0} characters.".FormatWith(_identityOptions.Value.Password.RequiredLength));
                        break;

                    // CurrentPassword
                    case "PasswordMismatch":
                        reportError("CurrentPassword", "Incorrect password.");
                        break;

                    // User name
                    case "InvalidUserName":
                        reportError("UserName", "User name '{0}' is invalid, can only contain letters or digits.".FormatWith(user.UserName));
                        break;
                    case "DuplicateUserName":
                        reportError("UserName", "User name '{0}' is already used.".FormatWith(user.UserName));
                        break;

                    // Email
                    case "InvalidEmail":
                        reportError("Email", "Email '{0}' is invalid.".FormatWith(user.Email));
                        break;
                    default:
                        reportError(string.Empty, "Unexpected error: '{0}'.".FormatWith(error.Code));
                        break;
                }
            }
        }
    }
}