![SendGrid Logo](https://github.com/sendgrid/sendgrid-python/raw/master/twilio_sendgrid_logo.png)

[![Travis Badge](https://travis-ci.org/sendgrid/csharp-http-client.svg?branch=master)](https://travis-ci.org/sendgrid/csharp-http-client)
[![NuGet](https://img.shields.io/nuget/v/SendGrid.CSharp.Http.Client.svg)](https://www.nuget.org/packages/SendGrid.CSharp.HTTP.Client)
[![MIT licensed](https://img.shields.io/badge/license-MIT-blue.svg)](./LICENSE.md)
[![Twitter Follow](https://img.shields.io/twitter/follow/sendgrid.svg?style=social&label=Follow)](https://twitter.com/sendgrid)
[![GitHub contributors](https://img.shields.io/github/contributors/sendgrid/csharp-http-client.svg)](https://github.com/sendgrid/csharp-http-client/graphs/contributors)

**Quickly and easily access any RESTful or RESTful-like API.**

If you are looking for the Twilio SendGrid API client library, please see [this repo](https://github.com/sendgrid/sendgrid-csharp).

# Table of Contents

* [Announcements](#announcements)
* [Installation](#installation)
* [Quick Start](#quick-start)
* [Library Usage Documentation](USAGE.md)
* [Use Cases](#use-cases)
* [Roadmap](#roadmap)
* [How to Contribute](#contribute)
* [Thanks](#thanks)
* [About](#about)
* [License](#license)

<a name="announcements"></a>
# Announcements

All updates to this project are documented in our [CHANGELOG](https://github.com/sendgrid/csharp-http-client/blob/master/CHANGELOG.md).

<a name="installation"></a>
# Installation

## Prerequisites

- .NET version 4.5.2

## Install Package

To use CSharp.HTTP.Client in your C# project, you can either <a href="https://github.com/sendgrid/csharp-http-client.git">download the Twilio SendGrid C# .NET libraries directly from our Github repository</a> or, if you have the NuGet package manager installed, you can grab them automatically.

```
PM> Install-Package SendGrid.CSharp.Http.Client
```

Once you have the library properly referenced in your project, you can include calls to them in your code.
For a sample implementation, check the [Example](https://github.com/sendgrid/csharp-http-client/tree/master/Example) folder.

Add the following namespace to use the library:
```csharp
using SendGrid.CSharp.HTTP.Client;
```

<a name="quick-start"></a>
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
requestHeaders.Add("X-Test", "test");
string requestBody = @"{'some': 1, 'awesome': 2, 'data': 3}";
Object json = JsonConvert.DeserializeObject<Object>(requestBody);
var response = await client.your.api._(param).call.post(requestBody: json.ToString(),
                                                  queryParams: queryParams,
                                                  requestHeaders: requestHeaders)
Console.WriteLine(response.StatusCode);
Console.WriteLine(response.Body.ReadAsStringAsync().Result);
Console.WriteLine(response.Headers.ToString());
```

<a name="use-cases"></a>
# Use Cases

You can find a selection of use cases for this library in our [Use Cases](/UseCases/README.md) directory.

<a name="roadmap"></a>
# Roadmap

If you are interested in the future direction of this project, please take a look at our [milestones](https://github.com/sendgrid/csharp-http-client/milestones). We would love to hear your feedback.

<a name="contribute"></a>
# How to Contribute

We encourage contribution to our projects, please see our [CONTRIBUTING](https://github.com/sendgrid/csharp-http-client/blob/master/CONTRIBUTING.md) guide for details.

Quick links:

- [Feature Request](https://github.com/sendgrid/csharp-http-client/blob/master/CONTRIBUTING.md#feature-request)
- [Bug Reports](https://github.com/sendgrid/csharp-http-client/blob/master/CONTRIBUTING.md#submit-a-bug-report)
- [Improvements to the Codebase](https://github.com/sendgrid/csharp-http-client/blob/master/CONTRIBUTING.md#improvements-to-the-codebase)

<a name="thanks"></a>
# Thanks

We were inspired by the work done on [birdy](https://github.com/inueni/birdy) and [universalclient](https://github.com/dgreisen/universalclient).

<a name="about"></a>
# About

csharp-http-client is maintained and funded by Twilio SendGrid, Inc. The names and logos for csharp-http-client are trademarks of Twilio SendGrid, Inc.

If you need help installing or using the library, please check the [Twilio SendGrid Support Help Center](https://support.sendgrid.com).

If you've instead found a bug in the library or would like new features added, go ahead and open issues or pull requests against this repo!

# License
[The MIT License (MIT)](LICENSE.md)
