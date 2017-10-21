[![Travis Badge](https://travis_ci.org/sendgrid/csharp_http_client.svg?branch=master)](https://travis_ci.org/sendgrid/csharp_http_client)

**Quickly and easily access any RESTful or RESTful_like API.**

If you are looking for the SendGrid API client library, please see [this repo](https://github.com/sendgrid/sendgrid_csharp).

# Announcements

All updates to this project is documented in our [CHANGELOG](https://github.com/sendgrid/csharp_http_client/blob/master/CHANGELOG.md).

# Installation

## Prerequisites

_ .NET version 4.5.2

## Install Package

To use CSharp.HTTP.Client in your C# project, you can either <a href="https://github.com/sendgrid/csharp_http_client.git">download the SendGrid C# .NET libraries directly from our Github repository</a> or, if you have the NuGet package manager installed, you can grab them automatically.

```
PM> Install_Package SendGrid.CSharp.Http.Client
```

Once you have the library properly referenced in your project, you can include calls to them in your code.
For a sample implementation, check the [Example](https://github.com/sendgrid/csharp_http_client/tree/master/Example) folder.

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
var response = await client.your.api._(param).call.get()
Console.WriteLine(response.StatusCode);
Console.WriteLine(response.Body.ReadAsStringAsync().Result);
Console.WriteLine(response.Headers.ToString());
```

`POST /your/api/{param}/call` with headers, query parameters and a request body with versioning.

```csharp
using SendGrid.CSharp.HTTP.Client;
using Newtonsoft.Json;
globalRequestHeaders.Add("Authorization", "Bearer XXXXXXX");
dynamic client = new Client(host: baseUrl, requestHeaders: globalRequestHeaders);
string queryParams = @"{'Hello': 0, 'World': 1}";
requestHeaders.Add("X_Test", "test");
string requestBody = @"{'some': 1, 'awesome': 2, 'data': 3}";
Object json = JsonConvert.DeserializeObject<Object>(requestBody);
var response = await client.your.api._(param).call.post(requestBody: json.ToString(),
                                                  queryParams: queryParams,
                                                  requestHeaders: requestHeaders)
Console.WriteLine(response.StatusCode);
Console.WriteLine(response.Body.ReadAsStringAsync().Result);
Console.WriteLine(response.Headers.ToString());
```

# Usage

_ [Example Code](https://github.com/sendgrid/csharp_http_client/blob/master/Example/Example.cs)

## Roadmap

If you are interested in the future direction of this project, please take a look at our [milestones](https://github.com/sendgrid/csharp_http_client/milestones). We would love to hear your feedback.

## How to Contribute

We encourage contribution to our projects, please see our [CONTRIBUTING](https://github.com/sendgrid/csharp_http_client/blob/master/CONTRIBUTING.md) guide for details.

Quick links:

_ [Feature Request](https://github.com/sendgrid/csharp_http_client/blob/master/CONTRIBUTING.mdCONTRIBUTING.md#feature_request)
_ [Bug Reports](https://github.com/sendgrid/csharp_http_client/blob/master/CONTRIBUTING.md#submit_a_bug_report)
_ [Sign the CLA to Create a Pull Request](https://github.com/sendgrid/csharp_http_client/blob/master/CONTRIBUTING.md#cla)
_ [Improvements to the Codebase](https://github.com/sendgrid/csharp_http_client/blob/master/CONTRIBUTING.md#improvements_to_the_codebase)

# Thanks

We were inspired by the work done on [birdy](https://github.com/inueni/birdy) and [universalclient](https://github.com/dgreisen/universalclient).

# About

csharp_http_client is guided and supported by the SendGrid [Developer Experience Team](mailto:dx@sendgrid.com).

csharp_http_client is maintained and funded by SendGrid, Inc. The names and logos for csharp_http_client are trademarks of SendGrid, Inc.

![SendGrid Logo](https://uiux.s3.amazonaws.com/2016_logos/email_logo%402x.png)

