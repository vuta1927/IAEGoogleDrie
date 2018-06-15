using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4;
using IdentityServer4.Models;

namespace IdentityServer
{
    public class Config
    {
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("api1","IAE API")
            };
        }

        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "iae-client",
                    ClientSecrets =
                    {
                        new Secret("40A00C685411260BD89DF2459D8EE35FDE2FFAA3AD103EA9CD4362B544CEFE63".Sha256())
                    },
                    AllowedGrantTypes =
                    {
                        "googleAuth"
                    },

                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OfflineAccess,
                        "iae-api"
                    },
                    UpdateAccessTokenClaimsOnRefresh = true,
                    AllowOfflineAccess = true,
                },
                //new Client
                //{
                //    ClientId = "iae-client2",
                //    AllowedGrantTypes = GrantTypes.ClientCredentials.Union(GrantTypes.ResourceOwnerPassword).ToList(),
                //    AllowedScopes =
                //    {
                //        IdentityServerConstants.StandardScopes.OpenId,
                //        IdentityServerConstants.StandardScopes.Profile,
                //        IdentityServerConstants.StandardScopes.OfflineAccess,
                //        "api1"
                //    },
                //    ClientSecrets =
                //    {
                //        new Secret("40A00C685411260BD89DF2459D8EE35FDE2FFAA3AD103EA9CD4362B544CEFE63".Sha256())
                //    },
                //    UpdateAccessTokenClaimsOnRefresh = true,
                //    AllowOfflineAccess = true,
                //}
            };
        }
    }
}
