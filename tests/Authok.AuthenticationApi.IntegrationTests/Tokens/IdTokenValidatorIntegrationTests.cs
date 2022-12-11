using Authok.AuthenticationApi.Models;
using Authok.AuthenticationApi.Tokens;
using Authok.ManagementApi;
using Authok.ManagementApi.Models;
using Authok.Tests.Shared;
using FluentAssertions;
using System;
using System.Threading.Tasks;
using Authok.AuthenticationApi.IntegrationTests.Testing;
using Authok.IntegrationTests.Shared.CleanUp;
using Xunit;

namespace Authok.AuthenticationApi.IntegrationTests.Tokens
{
    public class IdTokenValidatorIntegrationTests : ManagementTestBase, IAsyncLifetime
    {
        private Connection _connection;
        private User _user;
        private const string Password = "4cX8awB3T%@Aw-R:=h@ae@k?";

        public async Task InitializeAsync()
        {
            string token = await GenerateManagementApiToken();

            ApiClient = new ManagementApiClient(token, GetVariable("AUTHOK_MANAGEMENT_API_URL"), new HttpClientManagementConnection(options: new HttpClientManagementConnectionOptions { NumberOfHttpRetries = 9 }));

            var tenantSettings = await ApiClient.TenantSettings.GetAsync();

            if (string.IsNullOrEmpty(tenantSettings.DefaultDirectory))
            {
                throw new Exception("Tests require a tenant with a Default Directory selected.\r\n" +
                    "Enable OAuth 2.0 API Authorization under Account Settings | General and " +
                    "select a Default Directory under Account Settings | General");
            }

            // We will need a connection to add the users to...
            _connection = await ApiClient.Connections.CreateAsync(new ConnectionCreateRequest
            {
                Name = $"{TestingConstants.ConnectionPrefix}-{MakeRandomName()}",
                Strategy = "authok",
                EnabledClients = new[] {
                    GetVariable("AUTHOK_CLIENT_ID"),
                    GetVariable("AUTHOK_HS256_CLIENT_ID"),
                    GetVariable("AUTHOK_MANAGEMENT_API_CLIENT_ID")
                }
            });

            // And add a dummy user to test against
            _user = await ApiClient.Users.CreateAsync(new UserCreateRequest
            {
                Connection = _connection.Name,
                Email = $"{MakeRandomName()}{TestingConstants.UserEmailDomain}",
                EmailVerified = true,
                Password = Password
            });
        }

        public override async Task DisposeAsync()
        {
            await CleanupAndDisposeAsync(CleanUpType.Connections);
            await CleanupAndDisposeAsync(CleanUpType.Users);
        }

        [Fact]
        public async Task Passes_Token_Validation_RS256()
        {
            var authUrl = GetVariable("AUTHOK_AUTHENTICATION_API_URL");
            var clientId = GetVariable("AUTHOK_CLIENT_ID");
            var clientSecret = GetVariable("AUTHOK_CLIENT_SECRET");

            // Arrange
            using (var authenticationApiClient = new TestAuthenticationApiClient(authUrl))
            {
                // Act
                var authenticationResponse = await authenticationApiClient.GetTokenAsync(new ResourceOwnerTokenRequest
                {
                    ClientId = clientId,
                    ClientSecret = clientSecret,
                    Realm = _connection.Name,
                    Scope = "openid",
                    Username = _user.Email,
                    Password = Password
                });

                var issuer = $"https://{authUrl}/";
                var requirements = new IdTokenRequirements(JwtSignatureAlgorithm.RS256, issuer, clientId, TimeSpan.FromMinutes(1));
                await new IdTokenValidator().Assert(requirements, authenticationResponse.IdToken, clientSecret);
            }
        }

        [Fact]
        public async Task Passes_Token_Validation_RS256_With_Document_Retreiver()
        {
            var authUrl = GetVariable("AUTHOK_AUTHENTICATION_API_URL");
            var clientId = GetVariable("AUTHOK_CLIENT_ID");
            var clientSecret = GetVariable("AUTHOK_CLIENT_SECRET");

            // Arrange
            var connection = new TestHttpClientAuthenticationConnection();
            var documentRetreiver = new OpenIdConnectDocumentRetriever(connection);
            using (var authenticationApiClient = new TestAuthenticationApiClient(authUrl, connection))
            {
                // Act
                var authenticationResponse = await authenticationApiClient.GetTokenAsync(new ResourceOwnerTokenRequest
                {
                    ClientId = clientId,
                    ClientSecret = clientSecret,
                    Realm = _connection.Name,
                    Scope = "openid",
                    Username = _user.Email,
                    Password = Password
                });

                var issuer = $"https://{authUrl}/";
                var requirements = new IdTokenRequirements(JwtSignatureAlgorithm.RS256, issuer, clientId, TimeSpan.FromMinutes(1));
                await new IdTokenValidator(documentRetreiver).Assert(requirements, authenticationResponse.IdToken, clientSecret);
            }
        }

        [Fact]
        public async Task Passes_Token_Validation_HS256()
        {
            var authUrl = GetVariable("AUTHOK_AUTHENTICATION_API_URL");
            var clientId = GetVariable("AUTHOK_HS256_CLIENT_ID");
            var clientSecret = GetVariable("AUTHOK_HS256_CLIENT_SECRET");

            // Arrange
            using (var authenticationApiClient = new TestAuthenticationApiClient(authUrl))
            {
                // Act
                var authenticationResponse = await authenticationApiClient.GetTokenAsync(new ResourceOwnerTokenRequest
                {
                    ClientId = clientId,
                    ClientSecret = clientSecret,
                    Realm = _connection.Name,
                    SigningAlgorithm = JwtSignatureAlgorithm.HS256,
                    Scope = "openid",
                    Username = _user.Email,
                    Password = Password
                });

                var issuer = $"https://{authUrl}/";
                var requirements = new IdTokenRequirements(JwtSignatureAlgorithm.HS256, issuer, clientId, TimeSpan.FromMinutes(1));
                await new IdTokenValidator().Assert(requirements, authenticationResponse.IdToken, clientSecret);
            }
        }

        [Fact]
        public async Task Passes_Token_Validation_HS256_With_Document_Retreiver()
        {
            var authUrl = GetVariable("AUTHOK_AUTHENTICATION_API_URL");
            var clientId = GetVariable("AUTHOK_HS256_CLIENT_ID");
            var clientSecret = GetVariable("AUTHOK_HS256_CLIENT_SECRET");

            // Arrange
            var connection = new TestHttpClientAuthenticationConnection();
            var documentRetreiver = new OpenIdConnectDocumentRetriever(connection);
            using (var authenticationApiClient = new TestAuthenticationApiClient(authUrl, connection))
            {
                // Act
                var authenticationResponse = await authenticationApiClient.GetTokenAsync(new ResourceOwnerTokenRequest
                {
                    ClientId = clientId,
                    ClientSecret = clientSecret,
                    Realm = _connection.Name,
                    SigningAlgorithm = JwtSignatureAlgorithm.HS256,
                    Scope = "openid",
                    Username = _user.Email,
                    Password = Password
                });

                var issuer = $"https://{authUrl}/";
                var requirements = new IdTokenRequirements(JwtSignatureAlgorithm.HS256, issuer, clientId, TimeSpan.FromMinutes(1));
                await new IdTokenValidator(documentRetreiver).Assert(requirements, authenticationResponse.IdToken, clientSecret);
            }
        }

        [Fact]
        public async Task Passes_Token_Validation_With_CNAME()
        {
            // Arrange
            using (var authenticationApiClient = new TestAuthenticationApiClient(GetVariable("AUTHOK_AUTHENTICATION_API_URL")))
            {
                // Act
                var authenticationResponse = await authenticationApiClient.GetTokenAsync(new ResourceOwnerTokenRequest
                {
                    ClientId = GetVariable("AUTHOK_CLIENT_ID"),
                    ClientSecret = GetVariable("AUTHOK_CLIENT_SECRET"),
                    Realm = _connection.Name,
                    Scope = "openid",
                    Username = _user.Email,
                    Password = Password
                });

                var issuer = $"https://{GetVariable("AUTHOK_AUTHENTICATION_API_URL")}/";
                var requirements = new IdTokenRequirements(JwtSignatureAlgorithm.RS256, issuer, GetVariable("AUTHOK_CLIENT_ID"), TimeSpan.FromMinutes(1));
                await new IdTokenValidator().Assert(requirements, authenticationResponse.IdToken, GetVariable("AUTHOK_CLIENT_SECRET"));
            }
        }

        [Fact]
        public async Task Fails_Token_Validation_With_Incorrect_Domain()
        {
            // Arrange
            using (var authenticationApiClient = new TestAuthenticationApiClient(GetVariable("AUTHOK_AUTHENTICATION_API_URL")))
            {
                // Act
                var authenticationResponse = await authenticationApiClient.GetTokenAsync(new ResourceOwnerTokenRequest
                {
                    ClientId = GetVariable("AUTHOK_CLIENT_ID"),
                    ClientSecret = GetVariable("AUTHOK_CLIENT_SECRET"),
                    Realm = _connection.Name,
                    Scope = "openid",
                    Username = _user.Email,
                    Password = Password

                });

                var requirements = new IdTokenRequirements(JwtSignatureAlgorithm.RS256, "https://authok.authok.cn/", GetVariable("AUTHOK_CLIENT_ID"), TimeSpan.FromMinutes(1));

                // Assert
                authenticationResponse.IdToken.Should().NotBeNull();
                await Assert.ThrowsAsync<IdTokenValidationKeyMissingException>(() => new IdTokenValidator().Assert(requirements, authenticationResponse.IdToken, GetVariable("AUTHOK_CLIENT_SECRET")));
            }
        }

        [Fact]
        public async Task Fails_Token_Validation_With_Incorrect_Audience()
        {
            // Arrange
            using (var authenticationApiClient = new TestAuthenticationApiClient(GetVariable("AUTHOK_AUTHENTICATION_API_URL")))
            {
                // Act
                var authenticationResponse = await authenticationApiClient.GetTokenAsync(new ResourceOwnerTokenRequest
                {
                    ClientId = GetVariable("AUTHOK_CLIENT_ID"),
                    ClientSecret = GetVariable("AUTHOK_CLIENT_SECRET"),
                    Realm = _connection.Name,
                    Scope = "openid",
                    Username = _user.Email,
                    Password = Password

                });

                var issuer = $"https://{GetVariable("AUTHOK_AUTHENTICATION_API_URL")}/";
                var requirements = new IdTokenRequirements(JwtSignatureAlgorithm.RS256, issuer, "invalid_audience", TimeSpan.FromMinutes(1));

                // Assert
                authenticationResponse.IdToken.Should().NotBeNull();
                await Assert.ThrowsAsync<IdTokenValidationException>(() => new IdTokenValidator().Assert(requirements, authenticationResponse.IdToken, GetVariable("AUTHOK_CLIENT_SECRET")));
            }
        }
    }
}