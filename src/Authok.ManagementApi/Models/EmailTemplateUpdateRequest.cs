﻿using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Authok.ManagementApi.Models
{
    /// <summary>
    /// Request for updating an email template
    /// </summary>
    public class EmailTemplateUpdateRequest : EmailTemplateBase
    {
        /// <summary>
        /// Whether or not the template is enabled.
        /// </summary>
        [JsonProperty("enabled")]
        public bool Enabled { get; set; }

        /// <summary>
        /// The syntax of the template body.
        /// </summary>
        [JsonProperty("syntax")]
        [JsonConverter(typeof(StringEnumConverter))]
        public EmailTemplateSyntax Syntax { get; set; }

        /// <summary>
        /// The template name.
        /// </summary>
        [JsonProperty("template")]
        [JsonConverter(typeof(StringEnumConverter))]
        public EmailTemplateName Template { get; set; }
    }
}