using Authok.AuthenticationApi.Models;
using Authok.Tests.Shared;
using FluentAssertions;
using System.Threading.Tasks;
using Xunit;

namespace Authok.AuthenticationApi.IntegrationTests
{
    public class TokenTests : TestBase
    {
        [Fact]
        public async Task Can_get_token_using_client_credentials()
        {
            using (var authenticationApiClient = new AuthenticationApiClient(GetVariable("AUTHOK_AUTHENTICATION_API_URL")))
            {
                // Get the access token
                var token = await authenticationApiClient.GetTokenAsync(new ClientCredentialsTokenRequest
                {
                    ClientId = GetVariable("AUTHOK_MANAGEMENT_API_CLIENT_ID"),
                    ClientSecret = GetVariable("AUTHOK_MANAGEMENT_API_CLIENT_SECRET"),
                    Audience = GetVariable("AUTHOK_MANAGEMENT_API_AUDIENCE")
                });

                // Ensure that we received an access token back
                token.Should().NotBeNull();
            }
        }
    }
}
