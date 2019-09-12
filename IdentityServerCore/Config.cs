using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServerCore
{
    public class Config

    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };
        }

        public static List<TestUser> GetUsers()
        {
            return new List<TestUser>
            {
                new TestUser
                {
                    SubjectId="1",
                    Username="marco",
                    Password="password"
                },
                new TestUser
                {
                    SubjectId="2",
                    Username="bob",
                    Password="password"
                }
            };
        }

        public static IEnumerable<ApiResource> GetAllApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("api1", "Customer Api Test")
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "client",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = { new Secret("secret".Sha256()) },
                    AllowedScopes = { "api1" }
                },
                new Client
                {
                    ClientId= "client.ro",
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    ClientSecrets = { new Secret("secret".Sha256()) },
                    AllowedScopes = { "api1" }
                },
                new Client
                {
                    ClientId= "mvc",
                    ClientName="MVC Client",
                    AllowedGrantTypes = GrantTypes.Hybrid,
                       ClientSecrets =
    {
        new Secret("secret".Sha256())
    },
                    RedirectUris = { "http://localhost:5003/signin-oidc","http://localhost:4200/index.html"},
                    PostLogoutRedirectUris = { "http://localhost:5003/signout-callback-oidc" ,"http://localhost:4200/index.html"},

                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "api1"
                    },
                    AllowOfflineAccess = true,
                    AllowAccessTokensViaBrowser = true
                }
            };
        }
    }
}
