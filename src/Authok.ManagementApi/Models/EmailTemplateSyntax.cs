using System.Runtime.Serialization;

namespace Authok.ManagementApi.Models
{
    public enum EmailTemplateSyntax
    {
        /// <summary>
        /// Liquid syntax is used for the template
        /// </summary>
        [EnumMember(Value = "liquid")]
        Liquid
    }
}