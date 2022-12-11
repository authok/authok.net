using Newtonsoft.Json;

namespace Authok.ManagementApi.Models.Rules
{

    /// <summary>
    /// 
    /// </summary>
    [JsonObject]
    public class RulesContextSsoConfiguration
    {

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("current_clients")]
        public string[] CurrentClients { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("with_authok")]
        public bool WithAuthok { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("with_dbconn")]
        public bool WithDatabaseConnection { get; set; }

    }
}
