using Newtonsoft.Json;
using System.Collections.Generic;

namespace Authok.ManagementApi.Models
{
    public class OrganizationDeleteMembersRequest
    {
        /// <summary>
        /// List of user IDs to remove from the organization as members.
        /// </summary>
        [JsonProperty("members")]
        public IList<string> Members { get; set; }
    }
}
