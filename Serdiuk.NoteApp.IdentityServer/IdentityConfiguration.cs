using IdentityServer4.Models;
using IdentityServer4;
using IdentityModel;
using static System.Net.WebRequestMethods;

namespace Serdiuk.NoteApp.IdentityServer
{
    public class IdentityConfiguration
    {
        internal static IEnumerable<ApiResource> ApiResources()
        {
            yield return new ApiResource("NotesApi", "Notes");
        }

        internal static IEnumerable<ApiScope> ApiScopes()
        {
            yield return new ApiScope("NotesApi", "Pizza every day");
        }

        internal static IEnumerable<Client> Clients()
        {
            yield return new Client()
            {
                RedirectUris = { "http://localhost:3000/signin-oidc" },
                
                AllowedGrantTypes = GrantTypes.Implicit,
                ClientId = "client_id_react",
                RequireClientSecret = false,
                RequirePkce = true,
                AllowedScopes =
                {   
                    "NotesApi",
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Email,
                    IdentityServerConstants.StandardScopes.Profile,
                },
                AllowedCorsOrigins =
                {
                    "http://localhost:3000"
                },
                PostLogoutRedirectUris =
                {
                    "http://localhost:3000/signout-oidc"
                },
                AllowAccessTokensViaBrowser = true,
                AllowOfflineAccess = true,
            };
            yield return new Client
            {
                ClientId = "client_id_swagger",
                ClientSecrets = { new Secret("client_secret_swagger".ToSha256()) },
                AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                AllowedCorsOrigins = { "https://localhost:7035" },
                AllowedScopes =
                {
                    "NotesApi",
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile
                }
            };
        }

        internal static IEnumerable<IdentityResource> IdentityResources()
        {
            yield return new IdentityResources.OpenId();
            yield return new IdentityResources.Profile();
            yield return new IdentityResources.Email();
        }
    }
}
