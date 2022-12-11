using Newtonsoft.Json;

namespace Authok.ManagementApi.Models
{
    /// <summary>
    /// The custom domain verification methods.
    /// </summary>
    public class CustomDomainVerification
    {
        /// <summary>
        /// The custom domain verification methods.
        /// </summary>
        [JsonProperty("methods")]
        public CustomDomainVerificationMethod[] Methods { get; set; }
    }
}