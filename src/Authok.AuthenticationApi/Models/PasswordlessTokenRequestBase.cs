﻿using Newtonsoft.Json;

namespace Authok.AuthenticationApi.Models
{
    /// <summary>
    /// Base class for all types of Passwordless requests.
    /// </summary>
    public abstract class PasswordlessTokenRequestBase
    {
        /// <summary>
        /// Client ID of the application.
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// Client Secret of the application.
        /// </summary>
        public string ClientSecret { get; set; }

        /// <summary>
        /// The user's verification code
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Unique identifier of the target API to access.
        /// </summary>
        /// <remarks>
        /// Optional except when requesting a token to call an API.
        /// </remarks>
        public string Audience { get; set; }

        /// <summary>
        /// Scopes to be requested. Separate multiple values with a space.
        /// </summary>
        /// <remarks>
        /// Optional, use `openid` to get an ID Token, or `openid profile email` to also include user profile information in the ID Token.
        /// </remarks>
        public string Scope { get; set; }

        /// <summary>
        /// What <see cref="JwtSignatureAlgorithm"/> is used to verify the signature
        /// of Id Tokens.
        /// </summary>
        public JwtSignatureAlgorithm SigningAlgorithm { get; set; }
    }
}