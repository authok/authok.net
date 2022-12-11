using System.Runtime.Serialization;

namespace Authok.ManagementApi.Models
{
    /// <summary>
    /// The type of rotation for a <see cref="RefreshToken"/>
    /// </summary>
    public enum RefreshTokenRotationType
    {        
        /// <summary>
        /// Rotating
        /// </summary>
        [EnumMember(Value = "rotating")]
        Rotating,

        /// <summary>
        /// Non-Rotating
        /// </summary>
        [EnumMember(Value = "non-rotating")]
        NonRotating,
    }
}
