using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;

namespace Authok.AuthenticationApi.Tokens
{
    internal class AsymmetricSignedDecoder : SignedDecoder
    {
        public AsymmetricSignedDecoder(IList<JsonWebKey> keys)
            : base(JwtSignatureAlgorithm.RS256, keys)
        {
        }
    }
}