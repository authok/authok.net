using Newtonsoft.Json;
using System.Collections.Generic;

namespace Authok.ManagementApi.Models
{
    public class OrganizationAddMemberRolesRequest
    {
        /// <summary>
        /// List of role IDs to associated with the user.
        /// </summary>
        [JsonProperty("roles")]
        public IList<string> Roles { get; set; }
    }
}
