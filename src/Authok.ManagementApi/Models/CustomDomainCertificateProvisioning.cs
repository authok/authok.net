using System.Runtime.Serialization;

namespace Authok.ManagementApi.Models
{
    /// <summary>
    /// The custom domain provisioning type.
    /// </summary>
    public enum CustomDomainCertificateProvisioning
    {
        /// <summary>
        /// Using Authok-managed Certificates.
        /// </summary>
        [EnumMember(Value = "authok_managed_certs")]
        AuthokManagedCertificate,

        /// <summary>
        /// Using self-managed certificates.
        /// </summary>
        [EnumMember(Value = "self_managed_certs")]
        SelfManagedCertificate
    }
}