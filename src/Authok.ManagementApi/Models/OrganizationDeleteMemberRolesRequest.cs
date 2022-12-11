using Newtonsoft.Json;
using System.Collections.Generic;

namespace Authok.ManagementApi.Models
{
    public class OrganizationDeleteMemberRolesRequest
    {
        /// <summary>
        /// List of role IDs to remove from the user.
        /// </summary>
        [JsonProperty("roles")]
        public IList<string> Roles { get; set; }
    }
}
