using Newtonsoft.Json;

namespace Authok.ManagementApi.Models
{
    public class UpdateGuardianFactorBase
    {
        /// <summary>
        /// States if this factor is enabled
        /// </summary>
        [JsonProperty("enabled")]
        public bool IsEnabled { get; set; }
    }
}