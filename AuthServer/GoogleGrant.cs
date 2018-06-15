using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using IdentityModel;
using IdentityServer4.Validation;

namespace AuthServer
{
    public class GoogleGrant : IExtensionGrantValidator
    {
        public string GrantType => "googleAuth";

        public async Task ValidateAsync(ExtensionGrantValidationContext context)
        {
            var userToken = context.Request.UserName; //.Raw.Get("username");

            if (string.IsNullOrEmpty(userToken))
            {
                context.Result = new GrantValidationResult(OidcConstants.TokenErrors.InvalidGrant, null);
                return;
            }

            // get user's identity
            HttpClient client = new HttpClient();

            var request = client.GetAsync("https://www.googleapis.com/oauth2/v3/tokeninfo?id_token=" + userToken).Result;

            if (request.StatusCode == System.Net.HttpStatusCode.OK)
            {
                context.Result = new GrantValidationResult("0001", "google");
                return;
            }
            else
            {
                return;
            }
        }
    }
}
