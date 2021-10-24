# Change Log of `Infobip.Api.Client`

All notable changes to the library will be documented in this file.

The format of the file is based on [Keep a Changelog](http://keepachangelog.com/)
and this library adheres to [Semantic Versioning](http://semver.org/) as mentioned in [README.md][readme] file.

## [ [2.1.0](https://github.com/infobip/infobip-api-csharp-client/releases/tag/2.1.0) ] - 2021-10-25

### Added
- Support for [Infobip Email API](https://www.infobip.com/docs/api#channels/email)


## [ [2.0.0](https://github.com/infobip/infobip-api-csharp-client/releases/tag/2.0.0) ] - 2021-05-11

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
