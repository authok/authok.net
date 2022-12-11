﻿using Newtonsoft.Json;

namespace Authok.ManagementApi.Models
{
    public class OrganizationInvitationInviter
    {
        /// <summary>
        /// The name of the user that is creating the invitation.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}