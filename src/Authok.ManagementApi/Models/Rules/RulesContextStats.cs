using Newtonsoft.Json;

namespace Authok.ManagementApi.Models.Rules
{

    /// <summary>
    /// An object containing specific user stats.
    /// </summary>
    [JsonObject]
    public class RulesContextStats
    {

        /// <summary>
        /// The number of times the User has logged in.
        /// </summary>
        [JsonProperty("loginsCount")]
        public int LoginCount { get; set; }

    }

}