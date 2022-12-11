using Newtonsoft.Json;

namespace Authok.ManagementApi.Models
{

    /// <summary>
    /// 
    /// </summary>
    public class RuleCreateRequest : RuleBase
    {

        /// <summary>
        /// Gets or sets the execution stage of the rule.
        /// </summary>
        [JsonProperty("stage")]
        public string Stage { get; set; }

    }

}