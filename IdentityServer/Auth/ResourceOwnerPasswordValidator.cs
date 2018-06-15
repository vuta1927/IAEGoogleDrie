﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.Models;
using IdentityServer4.Validation;

namespace IdentityServer.Auth
{
    public class ResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {
        IAuthRepository _rep;

        public ResourceOwnerPasswordValidator(IAuthRepository rep)
        {
            this._rep = rep;
        }

        public Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            if (_rep.GetUserByUsername(context.UserName) != null)
            {
                context.Result = new GrantValidationResult(_rep.GetUserByUsername(context.UserName).Id.ToString(), "password", null, "local", null);
                return Task.FromResult(context.Result);
            }
            context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant, "The username and password do not match", null);
            return Task.FromResult(context.Result);
        }
    }
}
