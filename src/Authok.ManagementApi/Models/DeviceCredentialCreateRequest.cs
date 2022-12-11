using Newtonsoft.Json;

namespace Authok.ManagementApi.Models
{
    /// <summary>
    /// Represents a request to create device credentials.
    /// </summary>
    public class DeviceCredentialCreateRequest : DeviceCredentialBase
    {
        /// <summary>
        /// Gets or sets the value of the credentia
        /// </summary>
        [JsonProperty("value")]
        public string Value { get; set; }
    }
}