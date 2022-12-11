using System.Runtime.Serialization;

namespace Authok.ManagementApi.Models
{
    public enum GuardianEnrollmentStatus
    {
        [EnumMember(Value = "pending")]
        Pending,

        [EnumMember(Value = "confirmed")]
        Confirmed
    }
}