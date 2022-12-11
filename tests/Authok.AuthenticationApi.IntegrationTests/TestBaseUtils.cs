using Authok.AuthenticationApi.Models;
using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Authok.Tests.Shared
{
    public class TestBaseUtils
    {
        public static string GetVariable(string variableName, bool throwIfMissing = true)
        {
            var value = TestBase.Config[variableName];
            if (String.IsNullOrEmpty(value) && throwIfMissing)
                throw new ArgumentOutOfRangeException($"Configuration value '{variableName}' has not been set.");
            return value;
        }

        private static readonly Regex _alphaNumeric = new Regex("[^a-zA-Z0-9]");

        public static string MakeRandomName()
        {
            return _alphaNumeric.Replace(Convert.ToBase64String(Guid.NewGuid().ToByteArray()), "");
        }

        public static async Task<string> GenerateManagementApiToken()
        {
            using (var authenticationApiClient = new TestAuthenticationApiClient(GetVariable("AUTHOK_AUTHENTICATION_API_URL")))
            {
                // Get the access token
                var token = await authenticationApiClient.GetTokenAsync(new ClientCredentialsTokenRequest
                {
                    ClientId = GetVariable("AUTHOK_MANAGEMENT_API_CLIENT_ID"),
                    ClientSecret = GetVariable("AUTHOK_MANAGEMENT_API_CLIENT_SECRET"),
                    Audience = GetVariable("AUTHOK_MANAGEMENT_API_AUDIENCE")
                });

                return token.AccessToken;
            }
        }
    }
}