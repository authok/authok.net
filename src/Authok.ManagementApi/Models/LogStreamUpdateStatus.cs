using System.Runtime.Serialization;

namespace Authok.ManagementApi.Models
{
    /// <summary>
    /// The possible statuses to update a log strem with
    /// </summary>
    public enum LogStreamUpdateStatus
    {
        /// <summary>
        /// Activate the log stream
        /// </summary>
        [EnumMember(Value = "active")]
        Active,

        /// <summary>
        /// Pause the log stream
        /// </summary>
        [EnumMember(Value = "paused")]
        Paused
    }
}
