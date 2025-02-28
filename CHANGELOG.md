# Change Log of `Infobip.Api.Client`

All notable changes to the library will be documented in this file.

The format of the file is based on [Keep a Changelog](http://keepachangelog.com/)
and this library adheres to [Semantic Versioning](http://semver.org/) as mentioned in [README.md][readme] file.

## [ [4.0.0](https://github.com/infobip/infobip-api-csharp-client/releases/tag/v4.0.0) ] - 2025-02-28

🎉 **NEW Major Version of `Infobip.Api.Client`.**

⚠️ **IMPORTANT NOTE:** This release contains breaking changes.
All changes, including breaking changes, are addressed and explained in the list below.
If you find out that something was not addressed properly, please submit an issue.

### Added
- Support for [Infobip Moments](https://www.infobip.com/docs/api/customer-engagement/moments).
- Support for [Infobip Voice API](https://www.infobip.com/docs/api/channels/voice).
- Most recent [Infobip SMS API](https://www.infobip.com/docs/api/channels/sms) feature set.
  - Introduced `/sms/3/messages (V3)`  replacing the `/sms/2/text/advanced (V2)` and `/sms/2/binary/advanced (V2)` endpoints.
  - Introduced `/sms/3/reports (V3)` replacing `/sms/1/reports (V1)` endpoint.
  - Introduced `/sms/3/logs (V3)` replacing `/sms/1/logs (V1)` endpoint.
- Most recent [Infobip Email API](https://www.infobip.com/docs/api/channels/email) feature set.
  - Added `Email IP management` endpoints.
  - Removed `Email IP` and `Email Domain IPs` endpoints as they are now deprecated and are no longer supported.
- Added `[JsonObject]` and `[JsonProperty]` annotations to models for improved JSON Serialization/Deserialization for Newtonsoft.Json based consumers.
- Added System.Text.Json support for consumers using .NET Core 3.0 or later.
- Added `IDisposable` for all `IApiAccessor` implementations.

### Changed
⚠️ In addition to the changes listed below some products might also contain breaking changes as some of the API endpoints have changed since last major release.
If you have issues when migrating the existing implementation, please check the official API documentation or submit an issue.
- Introduced unified `DeliveryTimeWindow` class which replaces `SmsDeliveryTimeWindow` as it is now used in multiple APIs.
- Introduced unified `DeliveryTime` class which replaces `SmsDeliveryTime` as it is now used in multiple APIs.
- Introduced unified `DeliverDay` class which replaces `SmsDeliveryDay` as it is now used in multiple APIs.
- Renamed `SmsReport` to `SmsDeliveryReport` in order to improve naming consistency with `SmsDeliveryResult`.
- Introduced unified `SpeedLimitTimeUnit` class which replaces `SmsSpeedLimitTimeUnit`.
- Introduced unified `TurkeyIysOptions` class which replaces `SmsTurkeyIysOptions`.
- Introduced unified `IysRecipientType` class which replaces `SmsIysRecipientType`.
- Introduced unified `UrlOptions` class which replaces `SmsUrlOptions`.
- `ErrorContent` and `Headers` fields in `ApiException` now have private setters.
- Bumped `Polly` dependency to version `7.2.4`
- Bumped `RestSharp` dependency to version `106.12.0`

### Fixed
- bug: 400 error when receiving forwarding SMS message (https://github.com/infobip/infobip-api-csharp-client/issues/44)
- Add support for System.Text.Json (https://github.com/infobip/infobip-api-csharp-client/issues/31)

### Removed
- Unused model classes.
- API methods for calling APIs that were deprecated.

## [ [3.0.1](https://github.com/infobip/infobip-api-csharp-client/releases/tag/v3.0.1) ] - 2024-08-28

### Fixed
- Cannot have multiple recipient in a single email (https://github.com/infobip/infobip-api-csharp-client/issues/18)
- Multiple attachments support (https://github.com/infobip/infobip-api-csharp-client/issues/24)
- Zip Email attachment - not working (https://github.com/infobip/infobip-api-csharp-client/issues/34)

## [ [3.0.0](https://github.com/infobip/infobip-api-csharp-client/releases/tag/v3.0.0) ] - 2024-07-31

🎉 **NEW Major Version of `Infobip.Api.Client`.**

⚠️ **IMPORTANT NOTE:** This release contains breaking changes.
All changes, including breaking changes, are addressed and explained in the list below.
If you find out that something was not addressed properly, please submit an issue.

### Added
- Most recent [Infobip SMS API](https://www.infobip.com/docs/api/channels/sms) feature set.
- Most recent [Infobip Email API](https://www.infobip.com/docs/api/channels/email) feature set.
- Most recent [Infobip 2FA API](https://www.infobip.com/docs/api/platform/2fa) feature set.
- [FileParameter](https://github.com/infobip/infobip-api-csharp-client/blob/master/src/Infobip.Api.Client/Client/FileParameter.cs) class that represents a File passed to the API as a Parameter, allows using different backends for files.
- Added dependency JsonSubTypes 2.0.1

### Changed
- Some products contain a few breaking changes as some API endpoints have changed since last major release. If you have issues when migrating the existing implementation, please check the official API documentation or submit an issue.
- `SendSmsApi`, `ScheduledSmsApi` and `ReceiveSmsApi` classes have been unified into [SmsApi](https://github.com/infobip/infobip-api-csharp-client/blob/master/src/Infobip.Api.Client/Api/SmsApi.cs) class.
- `SendEmailApi`, `ScheduledEmailApi` and `EmailValidationApi` classes have been unified into [EmailApi](https://github.com/infobip/infobip-api-csharp-client/blob/master/src/Infobip.Api.Client/Api/EmailApi.cs) class.
- `EmailStatus` and `SmsStatus` have been unified into [MessageStatus](https://github.com/infobip/infobip-api-csharp-client/blob/master/src/Infobip.Api.Client/Model/MessageStatus.cs) class.
- `EmailPrice` and `SmsPrice` have been unified into [MessagePrice](https://github.com/infobip/infobip-api-csharp-client/blob/master/src/Infobip.Api.Client/Model/MessagePrice.cs) class.
- `EmailReportError` and `SmsError` have been unified into [MessageError](https://github.com/infobip/infobip-api-csharp-client/blob/master/src/Infobip.Api.Client/Model/MessageError.cs) class.
- API key authentication enforced
- DeserializeAsync method in [ApiClient](https://github.com/infobip/infobip-api-csharp-client/blob/master/src/Infobip.Api.Client/Client/ApiClient.cs) class is no longer publicly accessible
- Newtonsoft.Json updated to version 13.0.3

### Removed
- [Basic](https://www.infobip.com/docs/essentials/api-essentials/api-authentication#basic), [IBSSO Token Header](https://www.infobip.com/docs/essentials/api-essentials/api-authentication#ibsso-token-header) and client credentials grant type [OAuth2](https://www.infobip.com/docs/essentials/api-essentials/api-authentication#oauth-20) authentication methods. Use [API Key Header](https://www.infobip.com/docs/essentials/api-essentials/api-authentication#api-key-header) authentication method instead. Example of its usage can be found in the [README](https://github.com/infobip/infobip-api-csharp-client/blob/master/README.md#Quickstart).
- `GlobalConfiguration` utility class. Having static default configuration is error-prone and provides an unnecessary overhead. An ApiClient instance should always be injected in the given API class.
- Unused model classes.

## [ [2.1.3](https://github.com/infobip/infobip-api-csharp-client/releases/tag/v2.1.3) ] - 2023-12-28

### Fixed
- Template id being too large to store in integer (https://github.com/infobip/infobip-api-csharp-client/issues/28)

## [ [2.1.2](https://github.com/infobip/infobip-api-csharp-client/releases/tag/v2.1.2) ] - 2023-02-20

### Fixed
- README example (https://github.com/infobip/infobip-api-csharp-client/pull/13)

## [ [2.1.1](https://github.com/infobip/infobip-api-csharp-client/releases/tag/v2.1.1) ] - 2022-12-29

### Changed
- Newtonsoft.Json updated to 13.0.2
- Polly updated to 7.2.3

### Fixed
- Memory leak caused by not disposing CancellationTokenSource fixed

## [ [2.1.0](https://github.com/infobip/infobip-api-csharp-client/releases/tag/v2.1.0) ] - 2021-10-25

### Added
- Support for [Infobip Email API](https://www.infobip.com/docs/api#channels/email)


## [ [2.0.0](https://github.com/infobip/infobip-api-csharp-client/releases/tag/v2.0.0) ] - 2021-05-11

🎉 **NEW Major Version of `Infobip.Api.Client`.**

⚠ **IMPORTANT NOTE:** This release contains breaking changes!

In this release the Infobip.Api.Client library is updated and modernized. It is auto-generated and completely different from the previous version.

### Added
- Support for [Infobip Two-factor Authentication API](https://www.infobip.com/docs/api#channels/sms/send-2fa-pin-code-over-sms)
- Retry policy using Polly library
- `CONTRIBUTING.md` which contains guidelines for creating GitHub issues

### Changed
- Targeting .NET Standard 2.0
- Models, structure, examples, etc. for [Infobip SMS API](https://www.infobip.com/docs/api#channels/sms)
- Library dependencies
- `README.md` which contains necessary data and examples for quickstart as well as some other important pieces of information on versioning, licensing, etc.

### Removed
- Support for [Infobip Omni API](https://www.infobip.com/docs/api#channels/omni-failover) (to be included back in one of the next releases)
- Support for [Infobip Account API](https://www.infobip.com/docs/api#platform-&-connectivity/account-management) `getAccountBalance` method (to be included back in one of the next releases)
- Support for [Infobip Number Context API](https://www.infobip.com/docs/api#platform-&-connectivity/number-lookup) methods (to be included back in one of the next releases)
- Support for [Infobip SMS Tracking API](https://www.infobip.com/docs/sms/tracking) methods (to be included back in one of the next releases)

[readme]: README.md
