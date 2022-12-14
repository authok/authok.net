using Newtonsoft.Json;
using System.Collections.Generic;

namespace Authok.ManagementApi.Models
{
    /// <summary>
    /// Requests structure for updating an organization.
    /// </summary>
    public class OrganizationUpdateRequest
    {
        /// <summary>
        /// The display name of the organization
        /// </summary>
        [JsonProperty("display_name")]
        public string DisplayName { get; set; }
        /// <summary>
        /// Organization specific branding settings
        /// </summary>
        [JsonProperty("branding")]
        public OrganizationBranding Branding { get; set; }
        /// <summary>
        /// Organization specific metadata
        /// </summary>
        [JsonProperty("metadata")]
        public dynamic Metadata { get; set; }
    }
}