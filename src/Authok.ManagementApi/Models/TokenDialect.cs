using System.Runtime.Serialization;

namespace Authok.ManagementApi.Models
{
    public enum TokenDialect
    {
        [EnumMember(Value = "access_token")]
        AccessToken,

        [EnumMember(Value = "access_token_authz")]
        AccessTokenAuthZ
    }
}