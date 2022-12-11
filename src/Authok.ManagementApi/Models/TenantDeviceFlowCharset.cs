using System.Runtime.Serialization;

namespace Authok.ManagementApi.Models
{
    /// <summary>
    /// The character set for generating a User Code.
    /// </summary>
    public enum TenantDeviceFlowCharset
    {
        [EnumMember(Value = "base20")]
        Base20,

        [EnumMember(Value = "digits")]
        Digits
    }
}
