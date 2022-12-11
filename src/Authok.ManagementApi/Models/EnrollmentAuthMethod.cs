using System.Runtime.Serialization;

namespace Authok.ManagementApi.Models
{
    /// <summary>
    /// Method of authentication for a Guardian Enrollment.
    /// </summary>
    public enum EnrollmentAuthMethod
    {
        [EnumMember(Value = "authenticator")]
        Authenticator,

        [EnumMember(Value = "guardian")]
        Guardian,

        [EnumMember(Value = "sms")]
        SMS,

        [EnumMember(Value = "webauthn-roaming")]
        WebAuthNRoaming,

        [EnumMember(Value = "webauthn-platform")]
        WebAuthNPlatform,
        
    }
}
