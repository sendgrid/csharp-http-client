[![Travis Badge](https://travis-ci.org/sendgrid/csharp-http-client.svg?branch=master)](https://travis-ci.org/sendgrid/csharp-http-client)

**Quickly and easily access any RESTful or RESTful-like API.**

If you are looking for the SendGrid API client library, please see [this repo](https://github.com/sendgrid/sendgrid-csharp).

# Announcements

All updates to this project is documented in our [CHANGELOG](https://github.com/sendgrid/csharp-http-client/blob/master/CHANGELOG.md).

# Installation

To use CSharp.HTTP.Client in your C# project, you can either <a href="https://github.com/sendgrid/csharp-http-client.git">download the SendGrid C# .NET libraries directly from our Github repository</a> or, if you have the NuGet package manager installed, you can grab them automatically.

```
PM> Install-Package SendGrid.CSharp.Http.Client
```

Once you have the library properly referenced in your project, you can include calls to them in your code.
For a sample implementation, check the [Example](https://github.com/sendgrid/csharp-http-client/tree/master/Example) folder.

Add the following namespace to use the library:
```csharp
using SendGrid.CSharp.HTTP.Client;
```

# Quick Start

Here is a quick example:

`GET /your/api/{param}/call`

```csharp
using SendGrid.CSharp.HTTP.Client;
globalRequestHeaders.Add("Authorization", "Bearer XXXXXXX");
dynamic client = new Client(host: baseUrl, requestHeaders: globalRequestHeaders);
client.your.api._(param).call.get()
Console.WriteLine(response.StatusCode);
Console.WriteLine(response.Body.ReadAsStringAsync().Result);
Console.WriteLine(response.Headers.ToString());
```

`POST /your/api/{param}/call` with headers, query parameters and a request body with versioning.

```csharp
using SendGrid.CSharp.HTTP.Client;
globalRequestHeaders.Add("Authorization", "Bearer XXXXXXX");
dynamic client = new Client(host: baseUrl, requestHeaders: globalRequestHeaders);
string queryParams = "{'Hello': 0, 'World': 1}";
requestHeaders.Add("X-Test", "test");
string requestBody = "{'some': 1, 'awesome': 2, 'data': 3}";
var response = client.your.api._(param).call.post(requestBody: requestBody,
                                                  queryParams: queryParams,
                                                  requestHeaders: requestHeaders)
Console.WriteLine(response.StatusCode);
Console.WriteLine(response.Body.ReadAsStringAsync().Result);
Console.WriteLine(response.Headers.ToString());
```

# Usage

- [Example Code](https://github.com/sendgrid/csharp-http-client/blob/master/Example/Example.cs)

## Roadmap

If you are intersted in the future direction of this project, please take a look at our [milestones](https://github.com/sendgrid/csharp-http-client/milestones). We would love to hear your feedback.

## How to Contribute

We encourage contribution to our projects, please see our [CONTRIBUTING](https://github.com/sendgrid/csharp-http-client/blob/master/CONTRIBUTING.md) guide for details.

Quick links:

- [Feature Request](https://github.com/sendgrid/csharp-http-client/blob/master/CONTRIBUTING.mdCONTRIBUTING.md#feature_request)
- [Bug Reports](https://github.com/sendgrid/csharp-http-client/blob/master/CONTRIBUTING.md#submit_a_bug_report)
- [Sign the CLA to Create a Pull Request](https://github.com/sendgrid/csharp-http-client/blob/master/CONTRIBUTING.md#cla)
- [Improvements to the Codebase](https://github.com/sendgrid/csharp-http-client/blob/master/CONTRIBUTING.md#improvements_to_the_codebase)

# Thanks

We were inspired by the work done on [birdy](https://github.com/inueni/birdy) and [universalclient](https://github.com/dgreisen/universalclient).

# About

csharp-http-client is guided and supported by the SendGrid [Developer Experience Team](mailto:dx@sendgrid.com).

csharp-http-client is maintained and funded by SendGrid, Inc. The names and logos for csharp-http-client are trademarks of SendGrid, Inc.

![SendGrid Logo]
(https://uiux.s3.amazonaws.com/2016-logos/email-logo%402x.png)

