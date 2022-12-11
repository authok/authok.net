using Authok.AuthenticationApi.Models;
using Authok.Tests.Shared;
using FluentAssertions;
using System.Threading.Tasks;
using Xunit;

namespace Authok.AuthenticationApi.IntegrationTests
{
    public class ImpersonationTests : TestBase
    {
        private string accessToken = "your access token";

        [Fact(Skip = "Run manually")]
        public async Task Can_impersonate_user()
        {
            using (var authenticationApiClient = new AuthenticationApiClient(GetVariable("AUTHOK_AUTHENTICATION_API_URL")))
            {
                var uri = await authenticationApiClient.GetImpersonationUrlAsync(new ImpersonationRequest
                {
                    ImpersonateId = "impersonate id",
                    Token = accessToken,
                    Protocol = "oauth2",
                    ClientId = GetVariable("AUTHOK_CLIENT_ID"),
                    ImpersonatorId = "impoersonator id"
                });

                uri.Should().NotBeNull();
            }
        }
    }
}