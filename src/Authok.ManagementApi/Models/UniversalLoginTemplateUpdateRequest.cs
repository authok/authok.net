using Newtonsoft.Json;

namespace Authok.ManagementApi.Models
{
    /// <summary>
    /// Request for updating the template for the New Universal Login Experience.
    /// </summary>
    public class UniversalLoginTemplateUpdateRequest
    {
        /// <summary>
        /// Gets or sets the custom page template for the New Universal Login Experience
        /// </summary>
        [JsonProperty("template")]
        public string Template { get; set; }
    }
}