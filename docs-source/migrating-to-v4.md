# Migration Guide

## Migrating from v3 to v4

Version 4 of both the Authentication API SDK as well as the Management API SDK include breaking changes. This document will discuss the reason for these changes, as well as instructions on how to migrate to the new version.

### OIDC Conformance

The main reason for the breaking changes is related to improved OIDC compliance which was added to the Authentication API. Because of this, the behaviour of some of the existing Authentication API endpoints have changed, and other endpoints are being deprecated.

For a full background and other details please refer to the official [OIDC-conformant authentication migration guide](https://authok.cn/docs/api-auth/tutorials/adoption).

### Better separation of the Authentication and Management API

Because of the changes to the Authentication pipeline for OIDC conformance, some breaking changes were introduced and we are therefore required to increase the version number of the Authentication API SDK. One problem however was that some classes were shared in between the Authentication API SDK and the Management API SDK, in particular the information returned from the `/userinfo` endpoint. 

In the new OIDC conformant pipeline this is not the case anymore, as the endpoint return claims which conform to the [OIDC standard](http://openid.net/specs/openid-connect-core-1_0.html#StandardClaims).

Because of this single instance of shared data between the Authentication and Management API SDKs, a lot of the _Models_ returned by the various methods has been stored in the [Authok.Core NuGet package](https://www.nuget.org/packages/Authok.Core). With version 4 this is not the case anymore. 

All model classes are now stored in the NuGet package which they relate to. So all Authentication API SDK model classes are stored in the [Authok.AuthenticationAPI NuGet package](https://www.nuget.org/packages/Authok.AuthenticationApi). Likewise, all Management API SDK model classes are stored in the [Authok.ManagementAPI NuGet package](https://www.nuget.org/packages/Authok.ManagementApi).

The [Authok.Core NuGet package](https://www.nuget.org/packages/Authok.Core) only contains some shared classes used for communicating with the actual APIs, Exception classes etc.

The separation allows us to evolve these 2 packages in the future more easily in a separate directions.

## Difference between Version 3 and Version 4

Version 3 of the Authok.NET SDK can still be used for applications which do not use the OIDC-conformant pipeline. For these applications you must install the following NuGet packages:

* [Authok.AuthenticationAPI](https://www.nuget.org/packages/Authok.AuthenticationApi) Version 3.x
* [Authok.ManagementAPI](https://www.nuget.org/packages/Authok.ManagementApi) Version 3.x
* [Authok.Core](https://www.nuget.org/packages/Authok.Core) Version 3.x

Version 4 of the Authok.NET SDK **must be used** for applications which use the OIDC-conformant pipeline. For these applications you must install the following NuGet packages:

* [Authok.AuthenticationAPI](https://www.nuget.org/packages/Authok.AuthenticationApi) Version 4.x
* [Authok.ManagementAPI](https://www.nuget.org/packages/Authok.ManagementApi) Version 4.x
* [Authok.Core](https://www.nuget.org/packages/Authok.Core) Version 4.x

## List of changes

Here follows the list of changes made from Version 3 to Version 4 of the Authok.NET SDK, with guidance on how to change your applications.

### Authentication API

* **Removed** all members previously marked as obsolete. This relates mostly to the methods which did not conform to the *Async naming convention for .NET `async` methods.

* **Deprecated** the `AuthenticateAsync()` method as the legacy `oauth/ro` endpoint has been disabled. You should use `GetTokenAsync(ResourceOwnerTokenRequest)` instead. `AuthenticateAsync()` has been changed to simply call the new `GetTokenAsync(ResourceOwnerTokenRequest)` method. Note that confidential clients will need to provide a `ClientSecret` in addition to the `ClientId`. For more information see the [Resource Owner Password grant type](https://authok.cn/docs/api/authentication#resource-owner-password). 

* **Changed** the response of `AuthenticateAsync()` to now return an `AccessTokenResponse` instead of `AuthorizationResponse`. 

* **Renamed** the `Connection` property in `AuthenticationRequest` class to `Realm`. It is also now optional. If the Connection is not provided in the `Realm` property, the Authentication API will use the connection specified as the Default Directory in the [Account Settings](https://mgmt.authok.cn/#/account). **As noted above however**, you should use `GetTokenAsync(ResourceOwnerTokenRequest)` instead.

* **Deprecated** the `GetDelegationTokenAsync(RefreshTokenDelegationRequest)` method. The token refresh exchange must be done using the `GetTokenAsync(RefreshTokenRequest)` method.

* **Renamed** the `AccessToken` class returned by authentication and token methods to `AccessTokenResponse`. 

* **Changed** the response of the `GetUserInfoAsync()` method to return a `UserInfo` class instead of `User`. This is in order to conform to the [OIDC Specification](https://openid.net/specs/openid-connect-core-1_0.html#UserInfoResponse).

* **Removed** the `GetTokenInfoAsync()` method, based on the deprecated `/tokeninfo` endpoint.

* **Removed** the `GetAccessTokenAsync` method, based on the deprecated `/oauth/access_token` endpoint.

* **Removed** the `WithDevice()` method from `AuthorizationUrlBuilder`, because of obsoleted `device` parameter.

* **Added** support for adding `nonce`, `audience`, `response_mode` and multiple `response_type` parameters to the `/authorize` URL when using the `AuthorizationUrlBuilder` class. This was done by adding the `WithNonce()`, `WithAudience()`, `WithResponseMode()` and `WithResponseType()` methods.

* **Changed** `LogoutUrlBuilder` to now use the `v1/logout` endpoint. 

* **Added** support for adding `federated` and `clientId` parameters to the `v1/logout` endpoint when using the `LogoutUrlBuilder` class. This was done by adding the `Federated()` and `WithClientId()` methods.

* **Removed** the unused `OAuthToken` class. 

* **Moved** all model classes from the `Authok.Core` NuGet package to the `Authok.AuthenticationApi` NuGet package. For more information see the list of Core Classes which has been affected below.

### Management API

* **Moved** all model classes from the `Authok.Core` NuGet package to the `Authok.ManagementApi` NuGet package. For more information see the list of Core Classes which has been affected below.

### Core Classes

The following types have been moved from the `Authok.Core` NuGet package. Below you can see the list of classes with their old and new namespaces. Please update your code accordingly.

Class | Old Namespace | New Namespace
---------|----------|---------
Addons | Authok.Core | Authok.ManagementApi.Models
BlacklistedTokenBase | Authok.Core | Authok.ManagementApi.Models
Client | Authok.Core | Authok.ManagementApi.Models
ClientApplicationType | Authok.Core | Authok.ManagementApi.Models
ClientBase | Authok.Core | Authok.ManagementApi.Models
ClientGrant | Authok.Core | Authok.ManagementApi.Models
ClientGrantBase | Authok.Core | Authok.ManagementApi.Models
Connection | Authok.Core | Authok.ManagementApi.Models 
ConnectionBase | Authok.Core | Authok.ManagementApi.Models
DailyStatistics | Authok.Core | Authok.ManagementApi.Models
DeviceCredential | Authok.Core | Authok.ManagementApi.Models
DeviceCredentialBase | Authok.Core | Authok.ManagementApi.Models
EmailProvider | Authok.Core | Authok.ManagementApi.Models
EmailProviderBase | Authok.Core | Authok.ManagementApi.Models
EmailProviderCredentials | Authok.Core | Authok.ManagementApi.Models
EncryptionKey | Authok.Core | Authok.ManagementApi.Models
Identity | Authok.Core | Authok.ManagementApi.Models
Job | Authok.Core | Authok.ManagementApi.Models
JwtConfiguration | Authok.Core | Authok.ManagementApi.Models
LogEntry | Authok.Core | Authok.ManagementApi.Models
Mobile | Authok.Core | Authok.ManagementApi.Models
ResourceServer | Authok.Core | Authok.ManagementApi.Models
ResourceServerBase | Authok.Core | Authok.ManagementApi.Models
ResourceServerScope | Authok.Core | Authok.ManagementApi.Models
Rule | Authok.Core | Authok.ManagementApi.Models
RuleBase | Authok.Core | Authok.ManagementApi.Models
LoginRequest | Authok.Core.Rules | Authok.ManagementApi.Models.Rules
LoginRequestGeography | Authok.Core.Rules | Authok.ManagementApi.Models.Rules
LoginRequestQuery | Authok.Core.Rules | Authok.ManagementApi.Models.Rules
RulesContext | Authok.Core.Rules | Authok.ManagementApi.Models.Rules
RulesContextSsoConfiguration | Authok.Core.Rules | Authok.ManagementApi.Models.Rules
RulesContextStats | Authok.Core.Rules | Authok.ManagementApi.Models.Rules
RulesRequest | Authok.Core.Rules | Authok.ManagementApi.Models.Rules
ScopeEntry | Authok.Core | Authok.ManagementApi.Models
Scopes | Authok.Core | Authok.ManagementApi.Models
SigningAlgorithm | Authok.Core | Authok.ManagementApi.Models
SigningKey | Authok.Core | Authok.ManagementApi.Models
TenantErrorPage | Authok.Core | Authok.ManagementApi.Models
TenantSettings | Authok.Core | Authok.ManagementApi.Models
TenantSettingsBase | Authok.Core | Authok.ManagementApi.Models
Ticket | Authok.Core | Authok.ManagementApi.Models
TokenEndpointAuthMethod | Authok.Core | Authok.ManagementApi.Models
User | Authok.Core | Authok.ManagementApi.Models
UserBase | Authok.Core | Authok.ManagementApi.Models
UserBlock | Authok.Core | Authok.ManagementApi.Models
UserBlocks | Authok.Core | Authok.ManagementApi.Models
