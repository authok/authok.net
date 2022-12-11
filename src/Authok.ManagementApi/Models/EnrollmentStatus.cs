using System.Runtime.Serialization;

namespace Authok.ManagementApi.Models
{
    /// <summary>
    /// Status of a Guardian Enrollment.
    /// </summary>
    public enum EnrollmentStatus
    {
        [EnumMember(Value = "pending")]
        Pending,

        [EnumMember(Value = "confirmed")]
        Confirmed
    }
}
