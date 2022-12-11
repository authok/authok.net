using Newtonsoft.Json;

namespace Authok.ManagementApi.Models
{
    public class HookCreateRequest : HookBase
    {
        /// <summary>
        /// Gets or sets the triggerId of the hook. 
        /// </summary>
        [JsonProperty("triggerId")]
        public string TriggerId { get; set; }
    }
}