using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Services;
using IdentityServer4.Test;

namespace AuthServer
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
                    ClientId = "google",
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    AllowedGrantTypes =
                    {
                        "googleAuth"
                    },

                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OfflineAccess,
                        "api1"
                    },
                    AllowOfflineAccess = true,
                },
                new Client
                {
                    ClientId = "resourceOwner",
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,

                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OfflineAccess,
                        "api1"
                    },

                    UpdateAccessTokenClaimsOnRefresh = true,
                    AllowOfflineAccess = true,
                }
            };
        }

        public static List<TestUser> GetUsers()
        {
            return new List<TestUser>
            {
                new TestUser
                {
                    SubjectId = "0001",
                    Username = "behrooz",
                    Password = "mypass",
                },
                new TestUser
                {
                    SubjectId = "0002",
                    Username = "mahnaz",
                    Password = "anotherpass",
                }
            };
        }
    }
}
