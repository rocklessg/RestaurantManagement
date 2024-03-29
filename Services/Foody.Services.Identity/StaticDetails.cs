﻿using Duende.IdentityServer.Models;
using Duende.IdentityServer;

namespace Foody.Services.Identity
{
    public static class StaticDetails
    {
        public const string Admin = "Admin";
        public const string Customer = "Customer";

        public static IEnumerable<IdentityResource> IdentityResources => new List<IdentityResource>
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Email(),
            new IdentityResources.Profile()
        };

        public static IEnumerable<ApiScope> ApiScopes => new List<ApiScope>
        {
            new("foody", "Foody Server"),
            new (name: "read",   displayName: "Read your data."),
            new (name: "write",  displayName: "Write your data."),
            new (name: "delete", displayName: "Delete your data.")
        };

        public static IEnumerable<Client> Clients => new List<Client>
        {
            new Client
            {
                ClientId="client",
                ClientSecrets= { new Secret("secret".Sha256())},
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                AllowedScopes={ "read", "write","profile"}
            },
            new Client
            {
                ClientId="foody",
                ClientSecrets= { new Secret("secret".Sha256())},
                AllowedGrantTypes = GrantTypes.Code,
                RedirectUris={ "https://localhost:7151/signin-oidc" }, //"https://localhost:44354/signin-oidc", 
                PostLogoutRedirectUris={ "https://localhost:7151/signout-callback-oidc" }, //"https://localhost:44354/signout-callback-oidc",
                AllowedScopes=new List<string>
                {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                    IdentityServerConstants.StandardScopes.Email,
                    "foody"
                }
            },
        };
    }
}
