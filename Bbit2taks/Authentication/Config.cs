using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Security.Claims;

public static class Config
{
    public static IEnumerable<Client> Clients =>
        new List<Client>
        {
            new Client
            {
                ClientId = "client_id",
                ClientSecrets = { new Secret("your_client_secret".Sha256()) },
                AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                AllowedScopes = { "api_name", "offline_access" }
            }
        };

    public static IEnumerable<IdentityResource> IdentityResources =>
        new List<IdentityResource>
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
        };

    public static IEnumerable<ApiScope> ApiScopes =>
        new List<ApiScope>
        {
            new ApiScope("api_name", "API Name"),
        };

    public static IEnumerable<ApiResource> ApiResources =>
        new List<ApiResource>
        {
            new ApiResource("api_name", "API Name")
            {
                Scopes = { "api_name" }
            }
        };

    public static List<TestUser> Users =>
        new List<TestUser>
        {
            new TestUser
            {
                SubjectId = "1",
                Username = "testmanager",
                Password = "testmanager",
                Claims = new List<Claim>
                {
                    new Claim(JwtClaimTypes.Role, "Manager")
                }
            },
            new TestUser
            {
                SubjectId = "2",
                Username = "testresident",
                Password = "testresident",
                Claims = new List<Claim>
                {
                    new Claim(JwtClaimTypes.Role, "Resident")
                }
            }
        };
}
