![.NET client for Authok Authentication and Management APIs](https://cdn.authok.cn/website/sdks/banners/authok-net-banner.png)

![Release](https://img.shields.io/github/v/release/authok/authok.net)
![Downloads](https://img.shields.io/nuget/dt/authok.core)
[![License](https://img.shields.io/:license-MIT-blue.svg?style=flat)](https://opensource.org/licenses/MIT)
![AzureDevOps](https://img.shields.io/azure-devops/build/AuthokSDK/Authok.Net/6)

:books: [Documentation](#documentation) - :rocket: [Getting Started](#getting-started) - :computer: [API Reference](https://authok.github.io/authok.net/) - :speech_balloon: [Feedback](#feedback)

## Documentation

- [Docs site](https://www.authok.cn/docs) - explore our docs site and learn more about Authok.

## Getting started

### Requirements
This library supports .NET Standard 2.0 and .NET Framework 4.5.2 as well as later versions of both.

### Management API

#### Installation

```powershell
Install-Package Authok.ManagementApi
```

#### Usage

Generate a token for the API calls you wish to make (see [Access Tokens for the Management API](https://authok.cn/docs/api/management/v2/tokens)). Create an instance of the `ManagementApiClient` class with the token and the API URL of your Authok instance:

```csharp
var client = new ManagementApiClient("your token", new Uri("https://YOUR_AUTHOK_DOMAIN/api/v2"));
```

The API calls are divided into groups which correlate to the [Management API documentation](https://authok.cn/docs/api/v2). For example all Connection related methods can be found under the `ManagementApiClient.Connections` property. So to get a list of all database (Authok) connections, you can make the following API call:

```csharp
await client.Connections.GetAllAsync("authok");
```

### Authentication API

#### Installation

```powershell
Install-Package Authok.AuthenticationApi
```

#### Usage

To use the Authentication API, create a new instance of the `AuthenticationApiClient` class, passing in the URL of your Authok instance, e.g.:

```csharp
var client = new AuthenticationApiClient(new Uri("https://YOUR_AUTHOK_DOMAIN"));
```

#### Authentication

This library contains [URL Builders](https://authok.github.io/authok.net/#using-url-builders) which will assist you with constructing an authentication URL, but does not actually handle the authentication/authorization flow for you. It is suggested that you refer to the [Quickstart tutorials](https://authok.cn/docs/quickstarts) for guidance on how to implement authentication for your specific platform.

**Important note on state validation**: If you choose to use the [AuthorizationUrlBuilder](https://authok.github.io/authok.net/api/Authok.AuthenticationApi.Builders.AuthorizationUrlBuilder.html) to construct the authorization URL and implement a login flow callback yourself, it is important to generate and store a state value (using [WithState](https://authok.github.io/authok.net/api/Authok.AuthenticationApi.Builders.AuthorizationUrlBuilder.html#Authok_AuthenticationApi_Builders_AuthorizationUrlBuilder_WithState_System_String_)) and validate it in your callback URL before exchanging the authorization code for the tokens.

## Feedback

### Contributing

We appreciate feedback and contribution to this repo! Before you get started, please see the following:

- [Authok's general contribution guidelines](https://github.com/authok/open-source-template/blob/master/GENERAL-CONTRIBUTING.md)
- [Authok's code of conduct guidelines](https://github.com/authok/open-source-template/blob/master/CODE-OF-CONDUCT.md)

### Raise an issue

To provide feedback or report a bug, please [raise an issue on our issue tracker](https://github.com/authok/authok.net/issues).

### Vulnerability Reporting

Please do not report security vulnerabilities on the public GitHub issue tracker. The [Responsible Disclosure Program](https://authok.cn/responsible-disclosure-policy) details the procedure for disclosing security issues.

---

<p align="center">
  <picture>
    <source media="(prefers-color-scheme: light)" srcset="https://cdn.authok.cn/website/sdks/logos/authok_light_mode.png"   width="150">
    <source media="(prefers-color-scheme: dark)" srcset="https://cdn.authok.cn/website/sdks/logos/authok_dark_mode.png" width="150">
    <img alt="Authok Logo" src="https://cdn.authok.cn/website/sdks/logos/authok_light_mode.png" width="150">
  </picture>
</p>
<p align="center">Authok is an easy to implement, adaptable authentication and authorization platform. To learn more checkout <a href="https://authok.cn/why-authok">Why Authok?</a></p>
<p align="center">
This project is licensed under the MIT license. See the <a href="./LICENSE"> LICENSE</a> file for more info.</p>