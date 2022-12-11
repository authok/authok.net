using System.Threading.Tasks;
using Authok.AuthenticationApi.IntegrationTests.Testing;
using Authok.ManagementApi;
using Authok.Tests.Shared;
using Xunit;

namespace Authok.AuthenticationApi.IntegrationTests
{
    public class TestBaseFixture : IAsyncLifetime
    {
        public ManagementApiClient ApiClient { get; private set; }

        public virtual async Task InitializeAsync()
        {
            string token = await TestBaseUtils.GenerateManagementApiToken();

            ApiClient = new ManagementApiClient(token, TestBaseUtils.GetVariable("AUTHOK_MANAGEMENT_API_URL"), new HttpClientManagementConnection(options: new HttpClientManagementConnectionOptions { NumberOfHttpRetries = 9 }));
        }

        public virtual async Task DisposeAsync()
        {
            await ManagementTestBaseUtils.CleanupAndDisposeAsync(ApiClient);
        }
    }
}
