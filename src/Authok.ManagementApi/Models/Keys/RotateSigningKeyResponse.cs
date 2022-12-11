using Newtonsoft.Json;

namespace Authok.ManagementApi.Models.Keys
{
    public class RotateSigningKeyResponse
    {
        /// <summary>
        /// The id of the next signing key
        /// </summary>
        [JsonProperty("kid")]
        public string Kid { get; set; }

        /// <summary>
        /// The public certificate of the next signing key
        /// </summary>
        [JsonProperty("cert")]
        public string Cert { get; set; }
    }
}