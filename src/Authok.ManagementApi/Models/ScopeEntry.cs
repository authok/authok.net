using Newtonsoft.Json;

namespace Authok.ManagementApi.Models
{

    /// <summary>
    /// 
    /// </summary>
    public class ScopeEntry
    {

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("actions")]
        public string[] Actions { get; set; }
    }
}