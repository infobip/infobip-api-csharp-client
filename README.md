# Infobip API C# Client

[![NuGet](https://badgen.net/nuget/v/Infobip.Api.Client?icon=nuget)](https://www.nuget.org/packages/Infobip.Api.Client)
[![MIT License](https://badgen.net/github/license/infobip/infobip-api-csharp-client)](https://opensource.org/licenses/MIT)

This is a C# Client for [Infobip API][apidocs] and you can use it as a dependency in your application.
To use this library you'll need an Infobip account. You can create a [free trial][freetrial] account [here][signup].

The library is built on top of [OpenAPI Specification](https://swagger.io/specification/) and powered by [OpenAPI Generator](https://openapi-generator.tech/).

<img src="https://udesigncss.com/wp-content/uploads/2020/01/Infobip-logo-transparent.png" height="48px" alt="Infobip" />

#### Table of contents:
* [Documentation](#documentation)
* [General Info](#general-info)
* [Installation](#installation)
* [Quickstart](#quickstart)
* [Ask for help](#ask-for-help)

## Documentation

Infobip API Documentation can be found [here][apidocs].

## General Info
For `Infobip.Api.Client` versioning we use [Semantic Versioning][semver] scheme.

Published under [MIT License][license].

[.NET Standard 2.0](https://dotnet.microsoft.com/en-us/platform/dotnet-standard#versions) is targeted for usage of this library.

## Installation
Recommended way of library usage is to install it via [NuGet Package Manager](https://www.nuget.org/downloads).

#### Package Manager UI
Within Visual Studio, use the Package Manager UI to browse for `Infobip.Api.Client` package and install the latest version to your project.

#### Package Manager Console
Alternatively, also within Visual Studio, use the Package Manager Console command:

    Install-Package Infobip.Api.Client -Version 2.1.0

#### .NET CLI
If you are used to .NET CLI, the following command is going to be sufficient for you:

    dotnet add package Infobip.Api.Client --version 2.1.0

### Package reference
Including the package directly into project file is also valid option.

    <PackageReference Include="Infobip.Api.Client" Version="2.1.0" />

## Quickstart

#### Initialize the Client

Before initializing client we have to prepare `Configuration` object for handling authentication.
We support multiple authentication methods, e.g. you can use [API Key Header][authentication-apikey].
In this case value for `ApiKeyPrefix` in example below will be `App`.
To see your base URL, log in to the [Infobip API Resource][apidocs] hub with your Infobip account.

```csharp
    var configuration = new Configuration()
    {
        BasePath = "<put your base URL here>",
        ApiKeyPrefix = "<put API key prefix here (App/Basic/IBSSO/Bearer)>",
        ApiKey = "<put your API key here>"
    };
```

Next step is to initialize the API client. In this case we're instantiating the SMS API client.
```csharp
var sendSmsApi = new SendSmsApi(configuration);
```

Since library is utilizing the `HttpClient` behind the scene for handling the HTTP calls you can provide your own instance of `HttpClient` to `SendSmsApi` constructor and have a control over its lifecycle.
```csharp
    var sendSmsApi = new SendSmsApi(myHttpClientInstance, configuration);
```

#### Send an SMS
Here's a simple example for sending an SMS message. First prepare the message by creating an instance of `SmsAdvancedTextualRequest` and its nested objects.

```csharp
    var smsMessage = new SmsTextualMessage()
    {
        From = "InfoSMS",
        Destinations = new List<SmsDestination>()
        {
            new SmsDestination(to: "41793026727")
        },
        Text = "This is a dummy SMS message sent using Infobip.Api.Client"
    };

    var smsRequest = new SmsAdvancedTextualRequest()
    {
        Messages = new List<SmsTextualMessage>() { smsMessage }
    };
```

Now we can send the message using client instantiated before and inspect the `ApiException` for more information in case of failure.
You can get the HTTP status code from `ErrorCode` property, and more details about error from `ErrorContent` property.

```csharp
    try
    {
        var smsResponse = sendSmsApi.SendSmsMessage(smsRequest);

        System.Diagnostics.Debug.WriteLine($"Status: {smsResponse.Messages.First().Status}");
    }
    catch (ApiException apiException)
    {
        var errorCode = apiException.ErrorCode;
        var errorHeaders = apiException.Headers;
        var errorContent = apiException.ErrorContent;
    }
```

Additionally, from the successful response (`SmsResponse` object) you can pull out the `bulkId` and `messageId`(s) and use them to fetch a delivery report for given message or bulk.
Bulk ID will be received only when you send a message to more than one destination address or multiple messages in a single request.

```csharp
    string bulkId = smsResponse.BulkId;
    string messageId = smsResponse.Messages.First().MessageId;
```

#### Receive sent SMS report
For each SMS that you send out, we can send you a message delivery report in real time. All you need to do is specify your endpoint when sending SMS in `notifyUrl` field of `SmsTextualMessage`, or subscribe for reports by contacting our support team.
e.g. `https://{yourDomain}/delivery-reports`

You can use data models from the library and the pre-configured `Newtonsoft.Json` serializer (version 12.0.3).

Example of webhook implementation:

```csharp
    [HttpPost("api/sms/delivery-reports")]
    public IActionResult ReceiveDeliveryReport([FromBody] SmsDeliveryResult deliveryResult)
    {
        foreach (var result in deliveryResult.Results)
        {
            System.Diagnostics.Debug.WriteLine($"{result.MessageId} - {result.Status.Name}");
        }
        return Ok();
    }
```
If you prefer to use your own serializer, please pay attention to the supported [date format][datetimeformat].
Library is using custom date format string `yyyy-MM-ddTHH:mm:ss.fffzzzz` when serializing dates. This format does not exactly match the format from our documentation above, but it is the closest possible. This format produces the time zone offset value with `:` as time separator, but our backend services will deserialize it correctly.

#### Fetching delivery reports
If you are for any reason unable to receive real time delivery reports on your endpoint, you can use `messageId` or `bulkId` to fetch them.
Each request will return a batch of delivery reports - only once.

```csharp
    int numberOfReportsLimit = 10;
    var smsDeliveryResult = sendSmsApi.GetOutboundSmsMessageDeliveryReports(bulkId, messageId, numberOfReportsLimit);
    foreach (var smsReport in smsDeliveryResult.Results)
    {
        Console.WriteLine($"{smsReport.MessageId} - {smsReport.Status.Name}")
    }
```

#### Unicode & SMS preview
Infobip API supports Unicode characters and automatically detects encoding. Unicode and non-standard GSM characters use additional space, avoid unpleasant surprises and check how different message configurations will affect your message text, number of characters and message parts.
Use the preview SMS message functionality to verify those details as demonstrated below.

```csharp
    var smsPreviewRequest = new SmsPreviewRequest()
    {
        Text = "Let's see how many characters will remain unused in this message."
    };

    var smsPreviewResponse = sendSmsApi.PreviewSmsMessage(smsPreviewRequest);
```

#### Receive incoming SMS
If you want to receive SMS messages from your subscribers we can have them delivered to you in real time.
When you buy and configure a number capable of receiving SMS, specify your endpoint as explained [here][receive-inbound-sms] e.g. `https://{yourDomain}/incoming-sms`.

Example of webhook implementation:

```csharp
    [HttpPost("api/sms/incoming-sms")]
    public IActionResult ReceiveSms([FromBody] SmsInboundMessageResult smsInboundMessageResult)
    {
        foreach (var result in smsInboundMessageResult.Results)
        {
            System.Diagnostics.Debug.WriteLine($"{result.From} - {result.CleanText}");
        }
        return Ok();
    }
```
#### Two-Factor Authentication (2FA)
For 2FA quick start guide please check [these examples](two-factor-authentication.md).

#### Send email
For send email quick start guide please check [these examples](email.md).

## Ask for help

Feel free to open issues on the repository for any issue or feature request. 
Check the `CONTRIBUTING` [file][contributing] for details about contributions - in short, we will not merge any pull requests since this code is auto-generated.

However, if you find something that requires our imminent attention feel free to contact us @ [support@infobip.com](mailto:support@infobip.com).

[apidocs]: https://www.infobip.com/docs/api
[freetrial]: https://www.infobip.com/docs/essentials/free-trial
[signup]: https://www.infobip.com/signup
[semver]: https://semver.org
[license]: LICENSE
[contributing]: CONTRIBUTING.md
[authentication-apikey]: https://www.infobip.com/docs/essentials/api-authentication#api-key-header
[datetimeformat]: https://www.infobip.com/docs/essentials/integration-best-practices#date-formats
[receive-inbound-sms]: https://www.infobip.com/docs/api#channels/sms/receive-inbound-sms-messages
