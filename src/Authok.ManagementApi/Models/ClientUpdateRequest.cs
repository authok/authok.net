﻿using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Authok.ManagementApi.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class ClientUpdateRequest : ClientBase
    {
        /// <summary>
        /// The type of application this client represents
        /// </summary>
        [JsonProperty("app_type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public ClientApplicationType? ApplicationType { get; set; }

        /// <summary>
        /// Defines the requested authentication method for the token endpoint.
        /// </summary>
        [JsonProperty("token_endpoint_auth_method")]
        [JsonConverter(typeof(StringEnumConverter))]
        public TokenEndpointAuthMethod? TokenEndpointAuthMethod { get; set; }
    }
}