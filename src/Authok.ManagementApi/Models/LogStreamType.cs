using System.Runtime.Serialization;

namespace Authok.ManagementApi.Models
{
    /// <summary>
    /// The possible types of log stream
    /// </summary>
    public enum LogStreamType
    {
        [EnumMember(Value = "http")]
        Http,

        [EnumMember(Value = "eventbridge")]
        EventBridge
    }
}
