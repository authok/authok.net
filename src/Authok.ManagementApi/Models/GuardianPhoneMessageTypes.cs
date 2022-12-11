using Newtonsoft.Json;
using System.Collections.Generic;

namespace Authok.ManagementApi.Models
{
    public class GuardianPhoneMessageTypes
    {
        /// <summary>
        /// The list of phone factors to enable on the tenant. Can include `sms` and `voice`.
        /// </summary>
        [JsonProperty("message_types")]
        public IList<string> MessageTypes { get; set; }
    }
}