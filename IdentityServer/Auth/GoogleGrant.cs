using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Google.Apis.Auth;
using IdentityModel;
using IdentityServer4.Validation;
using Google.Apis.Auth.OAuth2;
namespace IdentityServer.Auth
{
    public class GoogleGrant : IExtensionGrantValidator
    {
        private IAuthRepository _authRepository;
        public string GrantType => "googleAuth";
        public GoogleGrant(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        public async Task ValidateAsync(ExtensionGrantValidationContext context)
        {
            var idToken = context.Request.Raw.Get("id_token"); //.Raw.Get("username");

            if (string.IsNullOrEmpty(idToken))
            {
                context.Result = new GrantValidationResult(OidcConstants.TokenErrors.InvalidGrant, null);
                return;
            }

            // get user's identity
            HttpClient client = new HttpClient();

            var request = await GoogleJsonWebSignature.ValidateAsync(idToken);
            //var request = client.GetAsync("https://www.googleapis.com/oauth2/v3/tokeninfo?id_token=" + userToken).Result;

            if (request != null)
            {
                if (_authRepository.GetUserByUsername(request.Email) != null)
                {
                    context.Result = new GrantValidationResult(_authRepository.GetUserByUsername(request.Email).Id.ToString(), "password", null, "local", null);
                }
                return;
            }
            else
            {
                return;
            }
        }
    }
}
