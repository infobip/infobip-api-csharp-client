using Infobip.Api.Client.Api;
using Infobip.Api.Client.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace ApiClient.Tests.Api;

[TestClass]
public class SmsApiTest : ApiTest
{
    protected const string SMS_SEND_MESSAGE_ENDPOINT = "/sms/3/messages";
    protected const string SMS_SEND_TEXT_ADVANCED_ENDPOINT = "/sms/2/text/advanced";
    protected const string SMS_SEND_BINARY_ADVANCED_ENDPOINT = "/sms/2/binary/advanced";
    protected const string SMS_LOGS_ENDPOINT = "/sms/3/logs";
    protected const string SMS_REPORTS_ENDPOINT = "/sms/3/reports";
    protected const string SMS_INBOX_REPORTS_ENDPOINT = "/sms/1/inbox/reports";
    protected const string SMS_SEND_PREVIEW_ENDPOINT = "/sms/1/preview";
    protected const string SMS_BULKS_ENDPOINT = "/sms/1/bulks";
    protected const string SMS_BULKS_STATUS_ENDPOINT = "/sms/1/bulks/status";

    protected const string DATE_FORMAT = "yyyy-MM-ddTHH:mm:ss.fffzzz";

    [TestMethod]
    public void ShouldSendSimpleSms()
    {
        var givenBulkId = "2034072219640523072";
        var givenTo = "41793026727";
        var givenMessageId = "2250be2d4219-3af1-78856-aabe-1362af1edfd2";
        var givenFrom = "InfoSMS";
        var givenText = "This is a sample message";
        var givenGroupId = 1;
        var givenGroupName = MessageGeneralStatus.Pending;
        var givenStatusId = 26;
        var givenStatusName = "MESSAGE_ACCEPTED";
        var givenStatusDescription = "Message sent to next instance";
        var givenApplicationId = "given_application_id";
        var givenFlash = false;
        var givenEntityId = "given_entity_id";
        var givenMessageCount = 1;

        var givenRequest = $@"{{
            ""messages"" : [ {{
                ""sender"" : ""{givenFrom}"",
                ""destinations"" : [ {{
                  ""to"" : ""{givenTo}""
                }} ],
                ""content"" : {{
                  ""text"" : ""{givenText}""
                }},
                ""options"" : {{
                  ""platform"" : {{
                    ""entityId"" : ""{givenEntityId}"",
                    ""applicationId"" : ""{givenApplicationId}""
                  }},
                  ""flash"" : {GetBooleanValueAsLowerString(givenFlash)}
                }}
              }} ]
            }}";

        var givenResponse = $@"{{
          ""bulkId"" : ""{givenBulkId}"",
          ""messages"" : [ {{
            ""messageId"" : ""{givenMessageId}"",
            ""status"" : {{
              ""groupId"" : {givenGroupId},
              ""groupName"" : ""{givenGroupName}"",
              ""id"" : {givenStatusId},
              ""name"" : ""{givenStatusName}"",
              ""description"" : ""{givenStatusDescription}""
            }},
            ""destination"" : ""{givenTo}"",
            ""details"" : {{
              ""messageCount"" : {givenMessageCount}
            }}
          }} ]
        }}";

        SetUpPostRequest(
            SMS_SEND_MESSAGE_ENDPOINT,
            200,
            givenRequest,
            givenResponse
        );

        var request = new SmsRequest(new List<SmsMessage>
        {
            new(
                givenFrom,
                new List<SmsDestination>
                {
                    new(givenTo)
                },
                new SmsMessageContent(new SmsTextContent(givenText)),
                new SmsMessageOptions(new Platform(givenEntityId, givenApplicationId))
            )
        });

        var sendSmsApi = new SmsApi(configuration);

        var response = sendSmsApi.SendSmsMessages(request);

        var expectedResponse = new SmsResponse(
            givenBulkId, new List<SmsResponseDetails>
            {
                new(
                    givenMessageId,
                    new SmsMessageStatus(
                        givenGroupId,
                        givenGroupName,
                        givenStatusId,
                        givenStatusName,
                        givenStatusDescription),
                    givenTo,
                    new SmsMessageResponseDetails(givenMessageCount)
                )
            });

        Assert.AreEqual(expectedResponse, response);
    }


    [TestMethod]
    public void ShouldSendFlashSms()
    {
        var givenBulkId = "2034072219640523072";
        var givenTo = "41793026727";
        var givenMessageId = "2250be2d4219-3af1-78856-aabe-1362af1edfd2";
        var givenFrom = "InfoSMS";
        var givenText = "This is a sample message";
        var givenGroupId = 1;
        var givenGroupName = MessageGeneralStatus.Pending;
        var givenStatusId = 26;
        var givenStatusName = "MESSAGE_ACCEPTED";
        var givenStatusDescription = "Message sent to next instance";
        var givenApplicationId = "given_application_id";
        var givenFlash = true;
        var givenEntityId = "given_entity_id";
        var givenMessageCount = 1;

        var givenRequest = $@"{{
            ""messages"" : [ {{
                ""sender"" : ""{givenFrom}"",
                ""destinations"" : [ {{
                  ""to"" : ""{givenTo}""
                }} ],
                ""content"" : {{
                  ""text"" : ""{givenText}""
                }},
                ""options"" : {{
                  ""platform"" : {{
                    ""entityId"" : ""{givenEntityId}"",
                    ""applicationId"" : ""{givenApplicationId}""
                  }},
                  ""flash"" : {GetBooleanValueAsLowerString(givenFlash)}
                }}
              }} ]
            }}";

        var givenResponse = $@"{{
          ""bulkId"" : ""{givenBulkId}"",
          ""messages"" : [ {{
            ""messageId"" : ""{givenMessageId}"",
            ""status"" : {{
              ""groupId"" : {givenGroupId},
              ""groupName"" : ""{givenGroupName}"",
              ""id"" : {givenStatusId},
              ""name"" : ""{givenStatusName}"",
              ""description"" : ""{givenStatusDescription}""
            }},
            ""destination"" : ""{givenTo}"",
            ""details"" : {{
              ""messageCount"" : {givenMessageCount}
            }}
          }} ]
        }}";

        SetUpPostRequest(
            SMS_SEND_MESSAGE_ENDPOINT,
            200,
            givenRequest,
            givenResponse
        );

        var request = new SmsRequest(new List<SmsMessage>
        {
            new(
                givenFrom,
                new List<SmsDestination>
                {
                    new(givenTo)
                },
                new SmsMessageContent(new SmsTextContent(givenText)),
                new SmsMessageOptions(new Platform(givenEntityId, givenApplicationId), flash: givenFlash)
            )
        });

        var sendSmsApi = new SmsApi(configuration);

        var response = sendSmsApi.SendSmsMessages(request);

        var expectedResponse = new SmsResponse(
            givenBulkId, new List<SmsResponseDetails>
            {
                new(
                    givenMessageId,
                    new SmsMessageStatus(
                        givenGroupId,
                        givenGroupName,
                        givenStatusId,
                        givenStatusName,
                        givenStatusDescription),
                    givenTo,
                    new SmsMessageResponseDetails(givenMessageCount)
                )
            });

        Assert.AreEqual(expectedResponse, response);
    }

    [TestMethod]
    public void ShouldSendFullyFeaturedSmsMessage()
    {
        var sender1 = "InfoSMS";
        var sender2 = "41793026700";
        var destination1 = "41793026727";
        var destination2 = "41793026834";
        var destination3 = "41793026700";
        var messageId1 = "MESSAGE-ID-123-xyz";
        var text1 = "Artık Ulusal Dil Tanımlayıcısı ile Türkçe karakterli smslerinizi rahatlıkla iletebilirsiniz.";
        var text2 =
            "A long time ago, in a galaxy far, far away... It is a period of civil war. Rebel spaceships, striking from a hidden base, have won their first victory against the evil Galactic Empire.";
        var transliteration = SmsTransliterationCode.Turkish;
        var validityPeriodAmount = 720;
        var validityPeriodUnit = ValidityPeriodTimeUnit.Hours;
        var campaignReferenceId = "summersale";
        var deliveryUrl = "https://www.example.com/sms/advanced";
        var intermediateReport = true;
        var contentType = "application/json";
        var callbackData = "DLR callback data";
        var givenFlash = false;
        var givenNotify = false;
        var deliveryDays = new List<DeliveryDay>
        {
            DeliveryDay.Monday,
            DeliveryDay.Tuesday,
            DeliveryDay.Wednesday,
            DeliveryDay.Thursday,
            DeliveryDay.Friday,
            DeliveryDay.Saturday,
            DeliveryDay.Sunday
        };
        var deliveryFromHour = 6;
        var deliveryFromMinute = 0;
        var deliveryToHour = 15;
        var deliveryToMinute = 30;
        var bulkId = "BULK-ID-123-xyz";

        var sendAtOffset = new DateTimeOffset(2023, 8, 1, 16, 10, 0, new TimeSpan(5, 30, 0));
        var shortenUrl = true;
        var trackClicks = true;
        var trackingUrl = "https://example.com/click-report";
        var removeProtocol = true;
        var customDomain = "example.com";
        var includeSmsCountInResponse = true;
        var useConversionTracking = true;
        var conversionTrackingName = "MY_CAMPAIGN";

        var bulkIdResponse = "2034072219640523072";
        var messageIdResponse1 = "2250be2d4219-3af1-78856-aabe-1362af1edfd2";
        var messageIdResponse2 = "3350be2d4219-3af1-23343-bbbb-1362af1edfd3";
        var statusGroupId = 1;
        var statusGroupName = MessageGeneralStatus.Pending;
        var statusId = 26;
        var statusName = "PENDING_ACCEPTED";
        var statusDescription = "Message sent to next instance";
        var messageCount = 1;

        var givenRequest = $@"
        {{
          ""messages"": [
            {{
              ""sender"": ""{sender1}"",
              ""destinations"": [
                {{
                  ""to"": ""{destination1}"",
                  ""messageId"": ""{messageId1}""
                }},
                {{
                  ""to"": ""{destination2}""
                }}
              ],
              ""content"": {{
                ""text"": ""{text1}"",
                ""transliteration"": ""{GetEnumAttributeValue(transliteration)}""
              }},
              ""options"": {{
                ""validityPeriod"": {{
                  ""amount"": {validityPeriodAmount},
                  ""timeUnit"": ""{GetEnumAttributeValue(validityPeriodUnit)}""
                }},
                ""campaignReferenceId"": ""{campaignReferenceId}"",
                ""flash"": {GetBooleanValueAsLowerString(givenFlash)}
              }},
              ""webhooks"": {{
                ""delivery"": {{
                  ""url"": ""{deliveryUrl}"",
                  ""intermediateReport"": {GetBooleanValueAsLowerString(intermediateReport)},
                  ""notify"": {GetBooleanValueAsLowerString(givenNotify)}
                }},
                ""contentType"": ""{contentType}"",
                ""callbackData"": ""{callbackData}""
              }}
            }},
            {{
              ""sender"": ""{sender2}"",
              ""destinations"": [
                {{
                  ""to"": ""{destination3}""
                }}
              ],
              ""content"": {{
                ""text"": ""{text2}""
              }},
              ""options"": {{
                ""deliveryTimeWindow"": {{
                  ""days"": [
                    {deliveryDays.Select(day => $"\"{GetEnumAttributeValue(day)}\"").Aggregate((a, b) => $"{a}, {b}")}
                  ],
                  ""from"": {{
                    ""hour"": {deliveryFromHour},
                    ""minute"": {deliveryFromMinute}
                  }},
                  ""to"": {{
                    ""hour"": {deliveryToHour},
                    ""minute"": {deliveryToMinute}
                  }}
                }},
                ""flash"": {GetBooleanValueAsLowerString(givenFlash)}
              }}
            }}
          ],
          ""options"": {{
            ""schedule"": {{
              ""bulkId"": ""{bulkId}"",
              ""sendAt"": ""{sendAtOffset.ToString(DATE_FORMAT)}""
            }},
            ""tracking"": {{
              ""shortenUrl"": {GetBooleanValueAsLowerString(shortenUrl)},
              ""trackClicks"": {GetBooleanValueAsLowerString(trackClicks)},
              ""trackingUrl"": ""{trackingUrl}"",
              ""removeProtocol"": {GetBooleanValueAsLowerString(removeProtocol)},
              ""customDomain"": ""{customDomain}""
            }},
            ""includeSmsCountInResponse"": {GetBooleanValueAsLowerString(includeSmsCountInResponse)},
            ""conversionTracking"": {{
              ""useConversionTracking"": {GetBooleanValueAsLowerString(useConversionTracking)},
              ""conversionTrackingName"": ""{conversionTrackingName}""
            }}
          }}
        }}";

        var givenResponse = $@"
        {{
          ""bulkId"": ""{bulkIdResponse}"",
          ""messages"": [
            {{
              ""messageId"": ""{messageIdResponse1}"",
              ""status"": {{
                ""groupId"": {statusGroupId},
                ""groupName"": ""{statusGroupName}"",
                ""id"": {statusId},
                ""name"": ""{statusName}"",
                ""description"": ""{statusDescription}""
              }},
              ""destination"": ""{destination1}"",
              ""details"": {{
                ""messageCount"": {messageCount}
              }}
            }},
            {{
              ""messageId"": ""{messageIdResponse2}"",
              ""status"": {{
                ""groupId"": {statusGroupId},
                ""groupName"": ""{statusGroupName}"",
                ""id"": {statusId},
                ""name"": ""{statusName}"",
                ""description"": ""{statusDescription}""
              }},
              ""destination"": ""{destination2}"",
              ""details"": {{
                ""messageCount"": {messageCount}
              }}
            }}
          ]
        }}";

        SetUpPostRequest(SMS_SEND_MESSAGE_ENDPOINT, 200, givenRequest, givenResponse);

        var request = new SmsRequest(new List<SmsMessage>
        {
            new(
                sender1,
                new List<SmsDestination>
                {
                    new(destination1, messageId1),
                    new(destination2)
                },
                new SmsMessageContent(new SmsTextContent(text1, transliteration)),
                new SmsMessageOptions(
                    validityPeriod: new ValidityPeriod(validityPeriodAmount, validityPeriodUnit),
                    campaignReferenceId: campaignReferenceId),
                new SmsWebhooks(new SmsMessageDeliveryReporting(deliveryUrl, intermediateReport), contentType,
                    callbackData)),
            new(
                sender2,
                new List<SmsDestination>
                {
                    new(destination3)
                },
                new SmsMessageContent(new SmsTextContent(text2)),
                new SmsMessageOptions(deliveryTimeWindow: new DeliveryTimeWindow(deliveryDays,
                    new DeliveryTime(deliveryFromHour, deliveryFromMinute),
                    new DeliveryTime(deliveryToHour, deliveryToMinute))))
        }, new SmsMessageRequestOptions(
            new SmsRequestSchedulingSettings(bulkId, sendAtOffset),
            new UrlOptions(shortenUrl, trackClicks, trackingUrl, removeProtocol, customDomain),
            includeSmsCountInResponse, new SmsTracking(useConversionTracking, conversionTrackingName)));

        var smsApi = new SmsApi(configuration);
        var response = smsApi.SendSmsMessages(request);

        var expectedResponse = new SmsResponse(
            bulkIdResponse,
            new List<SmsResponseDetails>
            {
                new(
                    messageIdResponse1,
                    new SmsMessageStatus(
                        statusGroupId,
                        statusGroupName,
                        statusId,
                        statusName,
                        statusDescription),
                    destination1,
                    new SmsMessageResponseDetails(messageCount)
                ),
                new(
                    messageIdResponse2,
                    new SmsMessageStatus
                    (
                        statusGroupId,
                        statusGroupName,
                        statusId,
                        statusName,
                        statusDescription
                    ),
                    destination2,
                    new SmsMessageResponseDetails(messageCount)
                )
            });

        Assert.AreEqual(expectedResponse, response);
    }

    [TestMethod]
    public void ShouldSendFullyFeaturedBinarySms()
    {
        var sender1 = "InfoSMS";
        var sender2 = "41793026700";
        var destination1 = "41793026727";
        var destination2 = "41793026834";
        var destination3 = "41793026700";
        var messageId1 = "MESSAGE-ID-123-xyz";
        var validityPeriodAmount = 720;
        var validityPeriodUnit = ValidityPeriodTimeUnit.Hours;
        var campaignReferenceId = "summersale";
        var givenFlash = false;
        var deliveryUrl = "https://www.example.com/sms/advanced";
        var intermediateReport = true;
        var givenNotify = false;
        var contentType = "application/json";
        var callbackData = "DLR callback data";
        var deliveryDays = new List<DeliveryDay>
        {
            DeliveryDay.Monday,
            DeliveryDay.Tuesday,
            DeliveryDay.Wednesday,
            DeliveryDay.Thursday,
            DeliveryDay.Friday,
            DeliveryDay.Saturday,
            DeliveryDay.Sunday
        };
        var deliveryFromHour = 6;
        var deliveryFromMinute = 0;
        var deliveryToHour = 15;
        var deliveryToMinute = 30;
        var bulkId = "BULK-ID-123-xyz";
        var dataCoding = 0;
        var esmClass = 0;
        var givenHex = "41 20 6C 6F 6E 67 20 74 …20 45 6D 70 69 72 65 2E";

        var sendAtOffset = new DateTimeOffset(2021, 8, 23, 14, 0, 0, new TimeSpan(5, 30, 0));
        var shortenUrl = true;
        var trackClicks = true;
        var trackingUrl = "https://example.com/click-report";
        var removeProtocol = true;
        var customDomain = "example.com";
        var includeSmsCountInResponse = true;
        var useConversionTracking = true;
        var conversionTrackingName = "MY_CAMPAIGN";

        var bulkIdResponse = "2034072219640523072";
        var messageIdResponse1 = "2250be2d4219-3af1-78856-aabe-1362af1edfd2";
        var messageIdResponse2 = "3350be2d4219-3af1-23343-bbbb-1362af1edfd3";
        var statusGroupId = 1;
        var statusGroupName = MessageGeneralStatus.Pending;
        var statusId = 26;
        var statusName = "PENDING_ACCEPTED";
        var statusDescription = "Message sent to next instance";
        var messageCount = 1;

        var givenRequest = $@"
        {{
            ""messages"": [
                {{
                    ""sender"": ""{sender1}"",
                    ""destinations"": [
                        {{ ""to"": ""{destination1}"", ""messageId"": ""{messageId1}"" }},
                        {{ ""to"": ""{destination2}"" }}
                    ],
                    ""content"": {{
                        ""hex"": ""{givenHex}""
                    }},
                    ""options"": {{
                        ""validityPeriod"": {{
                            ""amount"": {validityPeriodAmount},
                            ""timeUnit"": ""{GetEnumAttributeValue(validityPeriodUnit)}""
                        }},
                        ""campaignReferenceId"": ""{campaignReferenceId}"",
                        ""flash"": {GetBooleanValueAsLowerString(givenFlash)}
                    }},
                    ""webhooks"": {{
                        ""delivery"": {{
                            ""url"": ""{deliveryUrl}"",
                            ""intermediateReport"": {GetBooleanValueAsLowerString(intermediateReport)},
                            ""notify"": {GetBooleanValueAsLowerString(givenNotify)}
                        }},
                        ""contentType"": ""{contentType}"",
                        ""callbackData"": ""{callbackData}""
                    }}
                }},
                {{
                    ""sender"": ""{sender2}"",
                    ""destinations"": [
                        {{ ""to"": ""{destination3}"" }}
                    ],
                    ""content"": {{
                        ""hex"": ""{givenHex}""
                    }},
                    ""options"": {{
                        ""deliveryTimeWindow"": {{
                            ""days"": [
                                {deliveryDays.Select(day => $"\"{GetEnumAttributeValue(day)}\"").Aggregate((a, b) => $"{a}, {b}")}
                            ],
                            ""from"": {{
                                ""hour"": {deliveryFromHour},
                                ""minute"": {deliveryFromMinute}
                            }},
                            ""to"": {{
                                ""hour"": {deliveryToHour},
                                ""minute"": {deliveryToMinute}
                            }}
                        }},
                        ""flash"": {GetBooleanValueAsLowerString(givenFlash)}
                    }}
                }}
            ],
            ""options"": {{
                ""schedule"": {{
                    ""bulkId"": ""{bulkId}"",
                    ""sendAt"": ""{sendAtOffset.ToString(DATE_FORMAT)}""
                }},
                ""tracking"": {{
                    ""shortenUrl"": {GetBooleanValueAsLowerString(shortenUrl)},
                    ""trackClicks"": {GetBooleanValueAsLowerString(trackClicks)},
                    ""trackingUrl"": ""{trackingUrl}"",
                    ""removeProtocol"": {GetBooleanValueAsLowerString(removeProtocol)},
                    ""customDomain"": ""{customDomain}""
                }},
                ""includeSmsCountInResponse"": {GetBooleanValueAsLowerString(includeSmsCountInResponse)},
                ""conversionTracking"": {{
                    ""useConversionTracking"": {GetBooleanValueAsLowerString(useConversionTracking)},
                    ""conversionTrackingName"": ""{conversionTrackingName}""
                }}
            }}
        }}";

        var givenResponse = $@"
        {{
            ""bulkId"": ""{bulkIdResponse}"",
            ""messages"": [
                {{
                    ""messageId"": ""{messageIdResponse1}"",
                    ""status"": {{
                        ""groupId"": {statusGroupId},
                        ""groupName"": ""{statusGroupName}"",
                        ""id"": {statusId},
                        ""name"": ""{statusName}"",
                        ""description"": ""{statusDescription}""
                    }},
                    ""destination"": ""{destination1}"",
                    ""details"": {{
                        ""messageCount"": {messageCount}
                    }}
                }},
                {{
                    ""messageId"": ""{messageIdResponse2}"",
                    ""status"": {{
                        ""groupId"": {statusGroupId},
                        ""groupName"": ""{statusGroupName}"",
                        ""id"": {statusId},
                        ""name"": ""{statusName}"",
                        ""description"": ""{statusDescription}""
                    }},
                    ""destination"": ""{destination2}"",
                    ""details"": {{
                        ""messageCount"": {messageCount}
                    }}
                }}
            ]
        }}";

        SetUpPostRequest(SMS_SEND_MESSAGE_ENDPOINT, 200, givenRequest, givenResponse);

        var request = new SmsRequest(new List<SmsMessage>
        {
            new(
                sender1,
                new List<SmsDestination>
                {
                    new(destination1, messageId1),
                    new(destination2)
                },
                new SmsMessageContent(new SmsBinaryContent(esmClass, dataCoding, givenHex)),
                new SmsMessageOptions(
                    validityPeriod: new ValidityPeriod(validityPeriodAmount, validityPeriodUnit),
                    campaignReferenceId: campaignReferenceId),
                new SmsWebhooks(new SmsMessageDeliveryReporting(deliveryUrl, intermediateReport), contentType,
                    callbackData)),
            new(
                sender2,
                new List<SmsDestination>
                {
                    new(destination3)
                },
                new SmsMessageContent(new SmsBinaryContent(esmClass, dataCoding, givenHex)),
                new SmsMessageOptions(deliveryTimeWindow: new DeliveryTimeWindow(deliveryDays,
                    new DeliveryTime(deliveryFromHour, deliveryFromMinute),
                    new DeliveryTime(deliveryToHour, deliveryToMinute))))
        }, new SmsMessageRequestOptions(
            new SmsRequestSchedulingSettings(bulkId, sendAtOffset),
            new UrlOptions(shortenUrl, trackClicks, trackingUrl, removeProtocol, customDomain),
            includeSmsCountInResponse, new SmsTracking(useConversionTracking, conversionTrackingName)));

        var smsApi = new SmsApi(configuration);
        var response = smsApi.SendSmsMessages(request);

        var expectedResponse = new SmsResponse(
            bulkIdResponse,
            new List<SmsResponseDetails>
            {
                new(
                    messageIdResponse1,
                    new SmsMessageStatus(
                        statusGroupId,
                        statusGroupName,
                        statusId,
                        statusName,
                        statusDescription),
                    destination1,
                    new SmsMessageResponseDetails(messageCount)
                ),
                new(
                    messageIdResponse2,
                    new SmsMessageStatus(
                        statusGroupId,
                        statusGroupName,
                        statusId,
                        statusName,
                        statusDescription),
                    destination2,
                    new SmsMessageResponseDetails(messageCount)
                )
            });

        Assert.AreEqual(expectedResponse, response);
    }

    [TestMethod]
    public void ShouldSendFlashBinarySms()
    {
        var sender1 = "InfoSMS";
        var sender2 = "41793026700";
        var destination1 = "41793026727";
        var destination2 = "41793026834";
        var destination3 = "41793026700";
        var messageId1 = "MESSAGE-ID-123-xyz";
        var validityPeriodAmount = 720;
        var validityPeriodUnit = ValidityPeriodTimeUnit.Hours;
        var campaignReferenceId = "summersale";
        var givenFlash = true;
        var deliveryUrl = "https://www.example.com/sms/advanced";
        var intermediateReport = true;
        var givenNotify = false;
        var contentType = "application/json";
        var callbackData = "DLR callback data";
        var deliveryDays = new List<DeliveryDay>
        {
            DeliveryDay.Monday,
            DeliveryDay.Tuesday,
            DeliveryDay.Wednesday,
            DeliveryDay.Thursday,
            DeliveryDay.Friday,
            DeliveryDay.Saturday,
            DeliveryDay.Sunday
        };
        var deliveryFromHour = 6;
        var deliveryFromMinute = 15;
        var deliveryToHour = 15;
        var deliveryToMinute = 30;
        var bulkId = "BULK-ID-123-xyz";
        var dataCoding = 0;
        var esmClass = 0;
        var givenHex = "41 20 6C 6F 6E 67 20 74 …20 45 6D 70 69 72 65 2E";

        var sendAtOffset = new DateTimeOffset(2023, 8, 1, 16, 10, 0, new TimeSpan(5, 30, 0));
        var shortenUrl = true;
        var trackClicks = true;
        var trackingUrl = "https://example.com/click-report";
        var removeProtocol = true;
        var customDomain = "example.com";
        var includeSmsCountInResponse = true;
        var useConversionTracking = true;
        var conversionTrackingName = "MY_CAMPAIGN";

        var bulkIdResponse = "2034072219640523072";
        var messageIdResponse1 = "2250be2d4219-3af1-78856-aabe-1362af1edfd2";
        var messageIdResponse2 = "3350be2d4219-3af1-23343-bbbb-1362af1edfd3";
        var statusGroupId = 1;
        var statusGroupName = MessageGeneralStatus.Pending;
        var statusId = 26;
        var statusName = "PENDING_ACCEPTED";
        var statusDescription = "Message sent to next instance";
        var messageCount = 1;

        var givenRequest = $@"
        {{
            ""messages"": [
                {{
                    ""sender"": ""{sender1}"",
                    ""destinations"": [
                        {{ ""to"": ""{destination1}"", ""messageId"": ""{messageId1}"" }},
                        {{ ""to"": ""{destination2}"" }}
                    ],
                    ""content"": {{
                        ""hex"": ""{givenHex}""
                    }},
                    ""options"": {{
                        ""validityPeriod"": {{
                            ""amount"": {validityPeriodAmount},
                            ""timeUnit"": ""{GetEnumAttributeValue(validityPeriodUnit)}""
                        }},
                        ""campaignReferenceId"": ""{campaignReferenceId}"",
                        ""flash"": {GetBooleanValueAsLowerString(givenFlash)}
                    }},
                    ""webhooks"": {{
                        ""delivery"": {{
                            ""url"": ""{deliveryUrl}"",
                            ""intermediateReport"": {GetBooleanValueAsLowerString(intermediateReport)},
                            ""notify"": {GetBooleanValueAsLowerString(givenNotify)}
                        }},
                        ""contentType"": ""{contentType}"",
                        ""callbackData"": ""{callbackData}""
                    }}
                }},
                {{
                    ""sender"": ""{sender2}"",
                    ""destinations"": [
                        {{ ""to"": ""{destination3}"" }}
                    ],
                    ""content"": {{
                        ""hex"": ""{givenHex}""
                    }},
                    ""options"": {{
                        ""deliveryTimeWindow"": {{
                            ""days"": [
                                {deliveryDays.Select(day => $"\"{GetEnumAttributeValue(day)}\"").Aggregate((a, b) => $"{a}, {b}")}
                            ],
                            ""from"": {{
                                ""hour"": {deliveryFromHour},
                                ""minute"": {deliveryFromMinute}
                            }},
                            ""to"": {{
                                ""hour"": {deliveryToHour},
                                ""minute"": {deliveryToMinute}
                            }}
                        }},
                        ""flash"": {GetBooleanValueAsLowerString(givenFlash)}
                    }}
                }}
            ],
            ""options"": {{
                ""schedule"": {{
                    ""bulkId"": ""{bulkId}"",
                    ""sendAt"": ""{sendAtOffset.ToString(DATE_FORMAT)}""
                }},
                ""tracking"": {{
                    ""shortenUrl"": {GetBooleanValueAsLowerString(shortenUrl)},
                    ""trackClicks"": {GetBooleanValueAsLowerString(trackClicks)},
                    ""trackingUrl"": ""{trackingUrl}"",
                    ""removeProtocol"": {GetBooleanValueAsLowerString(removeProtocol)},
                    ""customDomain"": ""{customDomain}""
                }},
                ""includeSmsCountInResponse"": {GetBooleanValueAsLowerString(includeSmsCountInResponse)},
                ""conversionTracking"": {{
                    ""useConversionTracking"": {GetBooleanValueAsLowerString(useConversionTracking)},
                    ""conversionTrackingName"": ""{conversionTrackingName}""
                }}
            }}
        }}";

        var givenResponse = $@"
        {{
            ""bulkId"": ""{bulkIdResponse}"",
            ""messages"": [
                {{
                    ""messageId"": ""{messageIdResponse1}"",
                    ""status"": {{
                        ""groupId"": {statusGroupId},
                        ""groupName"": ""{statusGroupName}"",
                        ""id"": {statusId},
                        ""name"": ""{statusName}"",
                        ""description"": ""{statusDescription}""
                    }},
                    ""destination"": ""{destination1}"",
                    ""details"": {{
                        ""messageCount"": {messageCount}
                    }}
                }},
                {{
                    ""messageId"": ""{messageIdResponse2}"",
                    ""status"": {{
                        ""groupId"": {statusGroupId},
                        ""groupName"": ""{statusGroupName}"",
                        ""id"": {statusId},
                        ""name"": ""{statusName}"",
                        ""description"": ""{statusDescription}""
                    }},
                    ""destination"": ""{destination2}"",
                    ""details"": {{
                        ""messageCount"": {messageCount}
                    }}
                }}
            ]
        }}";

        SetUpPostRequest(SMS_SEND_MESSAGE_ENDPOINT, 200, givenRequest, givenResponse);

        var request = new SmsRequest(new List<SmsMessage>
        {
            new(
                sender1,
                new List<SmsDestination>
                {
                    new(destination1, messageId1),
                    new(destination2)
                },
                new SmsMessageContent(new SmsBinaryContent(esmClass, dataCoding, givenHex)),
                new SmsMessageOptions(
                    validityPeriod: new ValidityPeriod(validityPeriodAmount, validityPeriodUnit),
                    campaignReferenceId: campaignReferenceId, flash: givenFlash),
                new SmsWebhooks(new SmsMessageDeliveryReporting(deliveryUrl, intermediateReport), contentType,
                    callbackData)),
            new(
                sender2,
                new List<SmsDestination>
                {
                    new(destination3)
                },
                new SmsMessageContent(new SmsBinaryContent(esmClass, dataCoding, givenHex)),
                new SmsMessageOptions(deliveryTimeWindow: new DeliveryTimeWindow(deliveryDays,
                        new DeliveryTime(deliveryFromHour, deliveryFromMinute),
                        new DeliveryTime(deliveryToHour, deliveryToMinute)),
                    flash: givenFlash))
        }, new SmsMessageRequestOptions(
            new SmsRequestSchedulingSettings(bulkId, sendAtOffset),
            new UrlOptions(shortenUrl, trackClicks, trackingUrl, removeProtocol, customDomain),
            includeSmsCountInResponse, new SmsTracking(useConversionTracking, conversionTrackingName)));

        var smsApi = new SmsApi(configuration);
        var response = smsApi.SendSmsMessages(request);

        var expectedResponse = new SmsResponse(
            bulkIdResponse,
            new List<SmsResponseDetails>
            {
                new(
                    messageIdResponse1,
                    new SmsMessageStatus(
                        statusGroupId,
                        statusGroupName,
                        statusId,
                        statusName,
                        statusDescription),
                    destination1,
                    new SmsMessageResponseDetails(messageCount)
                ),
                new(
                    messageIdResponse2,
                    new SmsMessageStatus(
                        statusGroupId,
                        statusGroupName,
                        statusId,
                        statusName,
                        statusDescription),
                    destination2,
                    new SmsMessageResponseDetails(messageCount)
                )
            });

        Assert.AreEqual(expectedResponse, response);
    }

    [TestMethod]
    public void ShouldGetOutboundLogs()
    {
        var bulkId = "BULK-ID-123-xyz";
        var messageId1 = "MESSAGE-ID-123-xyz";
        var messageId2 = "12db39c3-7822-4e72-a3ec-c87442c0ffc5";
        var destination1 = "41793026727";
        var destination2 = "41793026834";
        var sentAt = "2023-08-01T16:10:00+05:30";
        var doneAt = "2023-08-01T16:10:00+05:30";

        var sentAtOffset = new DateTimeOffset(2023, 8, 1, 16, 10, 0, new TimeSpan(5, 30, 0));
        var doneAtOffset = new DateTimeOffset(2023, 8, 1, 16, 10, 0, new TimeSpan(5, 30, 0));
        var smsCount = 1;
        var pricePerMessage = 0.01m;
        var currency = "EUR";
        var applicationId = "marketing-automation-application";
        var entityId = "promotional-traffic-entity";
        var mccMnc = "22801";
        var text = "This is a sample message";

        var statusGroupId = 3;
        var statusGroupName = MessageGeneralStatus.Delivered;
        var statusId = 5;
        var statusName = "DELIVERED_TO_HANDSET";
        var statusDescription = "Message delivered to handset";

        var errorGroupId = 0;
        var errorGroupName = MessageErrorGroup.Ok;
        var errorId = 0;
        var errorName = "NO_ERROR";
        var errorDescription = "No Error";
        var errorPermanent = false;

        var expectedResponse = $@"
        {{
            ""results"": [
                {{
                    ""destination"": ""{destination1}"",
                    ""bulkId"": ""{bulkId}"",
                    ""messageId"": ""{messageId1}"",
                    ""sentAt"": ""{sentAt}"",
                    ""doneAt"": ""{doneAt}"",
                    ""messageCount"": {smsCount},
                    ""price"": {{ ""pricePerMessage"": {pricePerMessage}, ""currency"": ""{currency}"" }},
                    ""status"": {{
                        ""groupId"": {statusGroupId},
                        ""groupName"": ""{statusGroupName}"",
                        ""id"": {statusId},
                        ""name"": ""{statusName}"",
                        ""description"": ""{statusDescription}""
                    }},
                    ""error"": {{
                        ""groupId"": {errorGroupId},
                        ""groupName"": ""{errorGroupName}"",
                        ""id"": {errorId},
                        ""name"": ""{errorName}"",
                        ""description"": ""{errorDescription}"",
                        ""permanent"": {GetBooleanValueAsLowerString(errorPermanent)}
                    }},
                    ""platform"": {{ ""entityId"": ""{entityId}"", ""applicationId"": ""{applicationId}"" }},
                    ""content"": {{ ""text"": ""{text}"" }},
                    ""mccMnc"": ""{mccMnc}""
                }},
                {{
                    ""destination"": ""{destination2}"",
                    ""bulkId"": ""{bulkId}"",
                    ""messageId"": ""{messageId2}"",
                    ""sentAt"": ""{sentAt}"",
                    ""doneAt"": ""{doneAt}"",
                    ""messageCount"": {smsCount},
                    ""price"": {{ ""pricePerMessage"": {pricePerMessage}, ""currency"": ""{currency}"" }},
                    ""status"": {{
                        ""groupId"": {statusGroupId},
                        ""groupName"": ""{statusGroupName}"",
                        ""id"": {statusId},
                        ""name"": ""{statusName}"",
                        ""description"": ""{statusDescription}""
                    }},
                    ""error"": {{
                        ""groupId"": {errorGroupId},
                        ""groupName"": ""{errorGroupName}"",
                        ""id"": {errorId},
                        ""name"": ""{errorName}"",
                        ""description"": ""{errorDescription}"",
                        ""permanent"": {GetBooleanValueAsLowerString(errorPermanent)}
                    }},
                    ""platform"": {{ ""entityId"": ""{entityId}"", ""applicationId"": ""{applicationId}"" }},
                    ""content"": {{ ""text"": ""{text}"" }},
                    ""mccMnc"": ""{mccMnc}""
                }}
            ]
        }}";

        SetUpGetRequest(SMS_LOGS_ENDPOINT, 200, expectedResponse,
            new Dictionary<string, string> { { "bulkId", bulkId } });

        var smsApiClient = new SmsApi(configuration);
        var actualResponse = smsApiClient.GetOutboundSmsMessageLogs(bulkId: new List<string> { bulkId });

        var expectedDeserializedLogs = new SmsLogsResponse(new List<SmsLog>
        {
            new(
                null,
                destination1,
                bulkId,
                messageId1,
                sentAtOffset,
                doneAtOffset,
                smsCount,
                new MessagePrice(pricePerMessage, currency),
                new SmsMessageStatus(statusGroupId, statusGroupName, statusId, statusName, statusDescription),
                new SmsMessageError(errorGroupId, errorGroupName, errorId, errorName, errorDescription, errorPermanent),
                new Platform(entityId, applicationId),
                new SmsMessageContent(new SmsTextContent(text)),
                mccMnc: mccMnc
            ),
            new(
                null,
                destination2,
                bulkId,
                messageId2,
                sentAtOffset,
                doneAtOffset,
                smsCount,
                new MessagePrice(pricePerMessage, currency),
                new SmsMessageStatus(statusGroupId, statusGroupName, statusId, statusName, statusDescription),
                new SmsMessageError(errorGroupId, errorGroupName, errorId, errorName, errorDescription, errorPermanent),
                new Platform(entityId, applicationId),
                new SmsMessageContent(new SmsTextContent(text)),
                mccMnc: mccMnc
            )
        });

        Assert.AreEqual(expectedDeserializedLogs, actualResponse);
    }

    [TestMethod]
    public void ShouldGetOutboundDeliveryReports()
    {
        var bulkId = "BULK-ID-123-xyz";
        var messageId1 = "MESSAGE-ID-123-xyz";
        var messageId2 = "12db39c3-7822-4e72-a3ec-c87442c0ffc5";
        var to1 = "41793026727";
        var to2 = "41793026834";
        var sender = "InfoSMS";
        var sentAt = "2023-08-01T16:10:00+05:30";
        var doneAt = "2023-08-01T16:10:00+05:30";

        var sentAtOffset = new DateTimeOffset(2023, 8, 1, 16, 10, 0, new TimeSpan(5, 30, 0));
        var doneAtOffset = new DateTimeOffset(2023, 8, 1, 16, 10, 0, new TimeSpan(5, 30, 0));
        var smsCount = 1;
        var pricePerMessage = 0.01m;
        var currency = "EUR";
        var applicationId = "marketing-automation-application";
        var entityId = "promotional-traffic-entity";

        var statusGroupId = 3;
        var statusGroupName = MessageGeneralStatus.Delivered;
        var statusId = 5;
        var statusName = "DELIVERED_TO_HANDSET";
        var statusDescription = "Message delivered to handset";

        var errorGroupId = 0;
        var errorGroupName = MessageErrorGroup.Ok;
        var errorId = 0;
        var errorName = "NO_ERROR";
        var errorDescription = "No Error";
        var errorPermanent = false;

        var expectedResponse = $@"
        {{
            ""results"": [
                {{
                    ""bulkId"": ""{bulkId}"",
                    ""price"": {{ ""pricePerMessage"": {pricePerMessage}, ""currency"": ""{currency}"" }},
                    ""status"": {{
                        ""groupId"": {statusGroupId},
                        ""groupName"": ""{statusGroupName}"",
                        ""id"": {statusId},
                        ""name"": ""{statusName}"",
                        ""description"": ""{statusDescription}""
                    }},
                    ""error"": {{
                        ""groupId"": {errorGroupId},
                        ""groupName"": ""{errorGroupName}"",
                        ""id"": {errorId},
                        ""name"": ""{errorName}"",
                        ""description"": ""{errorDescription}"",
                        ""permanent"": {errorPermanent.ToString().ToLower()}
                    }},
                    ""messageId"": ""{messageId1}"",
                    ""to"": ""{to1}"",
                    ""sender"": ""{sender}"",
                    ""sentAt"": ""{sentAt}"",
                    ""doneAt"": ""{doneAt}"",
                    ""messageCount"": {smsCount},
                    ""platform"": {{ ""entityId"": ""{entityId}"", ""applicationId"": ""{applicationId}"" }}
                }},
                {{
                    ""bulkId"": ""{bulkId}"",
                    ""price"": {{ ""pricePerMessage"": {pricePerMessage}, ""currency"": ""{currency}"" }},
                    ""status"": {{
                        ""groupId"": {statusGroupId},
                        ""groupName"": ""{statusGroupName}"",
                        ""id"": {statusId},
                        ""name"": ""{statusName}"",
                        ""description"": ""{statusDescription}""
                    }},
                    ""error"": {{
                        ""groupId"": {errorGroupId},
                        ""groupName"": ""{errorGroupName}"",
                        ""id"": {errorId},
                        ""name"": ""{errorName}"",
                        ""description"": ""{errorDescription}"",
                        ""permanent"": {errorPermanent.ToString().ToLower()}
                    }},
                    ""messageId"": ""{messageId2}"",
                    ""to"": ""{to2}"",
                    ""sender"": ""{sender}"",
                    ""sentAt"": ""{sentAt}"",
                    ""doneAt"": ""{doneAt}"",
                    ""messageCount"": {smsCount},
                    ""platform"": {{ ""entityId"": ""{entityId}"", ""applicationId"": ""{applicationId}"" }}
                }}
            ]
        }}";

        SetUpGetRequest(SMS_REPORTS_ENDPOINT, 200, expectedResponse,
            new Dictionary<string, string> { { "bulkId", bulkId } });

        var smsApiClient = new SmsApi(configuration);
        var actualResponse = smsApiClient.GetOutboundSmsMessageDeliveryReports(bulkId);

        var expectedDeserializedReport = new SmsDeliveryResult(new List<SmsDeliveryReport>
        {
            new(
                bulkId,
                new MessagePrice(pricePerMessage, currency),
                new SmsMessageStatus(statusGroupId, statusGroupName, statusId, statusName, statusDescription),
                new SmsMessageError(errorGroupId, errorGroupName, errorId, errorName, errorDescription, errorPermanent),
                messageId1,
                to1,
                sender,
                sentAtOffset,
                doneAtOffset,
                smsCount,
                platform: new Platform(entityId, applicationId)
            ),
            new(
                bulkId,
                new MessagePrice(pricePerMessage, currency),
                new SmsMessageStatus(statusGroupId, statusGroupName, statusId, statusName, statusDescription),
                new SmsMessageError(errorGroupId, errorGroupName, errorId, errorName, errorDescription, errorPermanent),
                messageId2,
                to2,
                sender,
                sentAtOffset,
                doneAtOffset,
                smsCount,
                platform: new Platform(entityId, applicationId)
            )
        });

        Assert.AreEqual(expectedDeserializedReport, actualResponse);
    }

    [TestMethod]
    public void ShouldGetReceivedSmsMessages()
    {
        var expectedMessageId = "817790313235066447";
        var expectedFrom = "385916242493";
        var expectedTo = "385921004026";
        var expectedText = "QUIZ Correct answer is Paris";
        var expectedCleanText = "Correct answer is Paris";
        var expectedKeyword = "QUIZ";
        var expectedReceivedAt = "2021-08-25T16:10:00.000+0500";
        var expectedSmsCount = 1;
        decimal expectedPricePerMessage = 0;
        var expectedCurrency = "EUR";
        var expectedCallbackData = "callbackData";
        var expectedMessageCount = 1;
        var expectedPendingMessageCount = 0;

        var expectedResponse = $@"
            {{
                ""results"": [
                 {{
                    ""messageId"": ""{expectedMessageId}"",
                    ""from"": ""{expectedFrom}"",
                    ""to"": ""{expectedTo}"",
                    ""text"": ""{expectedText}"",
                    ""cleanText"": ""{expectedCleanText}"",
                    ""keyword"": ""{expectedKeyword}"",
                    ""receivedAt"": ""{expectedReceivedAt}"",
                    ""smsCount"": {expectedSmsCount},
                    ""price"": {{
                        ""pricePerMessage"": {expectedPricePerMessage},
                        ""currency"": ""{expectedCurrency}""
                    }},
                    ""callbackData"": ""{expectedCallbackData}""
                 }}
                ],
                ""messageCount"": {expectedMessageCount},
                ""pendingMessageCount"": {expectedPendingMessageCount}
            }}";

        var givenLimit = 2;
        SetUpGetRequest(SMS_INBOX_REPORTS_ENDPOINT,
            200, expectedResponse, new Dictionary<string, string> { { "limit", givenLimit.ToString() } });

        void ResultAssertions(SmsInboundMessageResult smsInboundResult)
        {
            Assert.IsNotNull(smsInboundResult);
            Assert.AreEqual(expectedMessageCount, smsInboundResult.MessageCount);
            Assert.AreEqual(expectedPendingMessageCount, smsInboundResult.PendingMessageCount);

            Assert.AreEqual(1, smsInboundResult.Results.Count);
            var message = smsInboundResult.Results[0];
            Assert.AreEqual(expectedMessageId, message.MessageId);
            Assert.AreEqual(expectedFrom, message.From);
            Assert.AreEqual(expectedTo, message.To);
            Assert.AreEqual(expectedText, message.Text);
            Assert.AreEqual(expectedCleanText, message.CleanText);
            Assert.AreEqual(expectedKeyword, message.Keyword);
            Assert.AreEqual(DateTimeOffset.Parse(expectedReceivedAt), message.ReceivedAt);
            Assert.AreEqual(expectedSmsCount, message.SmsCount);
            Assert.AreEqual(expectedPricePerMessage, message.Price.PricePerMessage);
            Assert.AreEqual(expectedCurrency, message.Price.Currency);
            Assert.AreEqual(expectedCallbackData, message.CallbackData);
        }

        var receiveApi = new SmsApi(configuration);

        AssertResponse(receiveApi.GetInboundSmsMessages(givenLimit), ResultAssertions);
        AssertResponse(receiveApi.GetInboundSmsMessagesAsync(givenLimit).Result, ResultAssertions);

        AssertResponseWithHttpInfo(receiveApi.GetInboundSmsMessagesWithHttpInfo(givenLimit), ResultAssertions, 200);
        AssertResponseWithHttpInfo(receiveApi.GetInboundSmsMessagesWithHttpInfoAsync(givenLimit).Result,
            ResultAssertions, 200);
    }

    [TestMethod]
    public void ShouldSendSmsPreview()
    {
        var givenPreviewText = "Let's see how many characters will remain unused in this message.";

        var givenRequest = $@"
            {{
                ""text"": ""{givenPreviewText}""
                
            }}";

        var expectedOriginalText = "Let's see how many characters will remain unused in this message.";
        var expectedTextPreview = "Let's see how many characters will remain unused in this message.";
        var expectedMessageCount = 1;
        var expectedCharactersRemaining = 95;

        var expectedResponse = $@"
            {{
                ""originalText"": ""{expectedOriginalText}"",
                ""previews"": [
                    {{
                        ""textPreview"": ""{expectedTextPreview}"",
                        ""messageCount"": ""{expectedMessageCount}"",
                        ""charactersRemaining"": {expectedCharactersRemaining},
                        ""configuration"": {{ }}
                    }}
                ]
            }}";

        SetUpPostRequest(SMS_SEND_PREVIEW_ENDPOINT, 200, givenRequest, expectedResponse);

        void SmsPreviewAssertions(SmsPreviewResponse response)
        {
            Assert.IsNotNull(response);
            Assert.AreEqual(expectedOriginalText, response.OriginalText);
            Assert.AreEqual(1, response.Previews.Count);
            var preview = response.Previews[0];
            Assert.AreEqual(expectedTextPreview, preview.TextPreview);
            Assert.AreEqual(expectedMessageCount, preview.MessageCount);
            Assert.AreEqual(expectedCharactersRemaining, preview.CharactersRemaining);
            Assert.AreEqual(expectedOriginalText, response.OriginalText);
            var smsLanguage = preview.VarConfiguration;
            Assert.IsNotNull(smsLanguage);
            Assert.IsNull(smsLanguage.Language);
            Assert.IsNull(smsLanguage.Transliteration);
        }

        var sendSmsApi = new SmsApi(configuration);
        var request = new SmsPreviewRequest(expectedTextPreview);

        AssertResponse(sendSmsApi.PreviewSmsMessage(request), SmsPreviewAssertions);
        AssertResponse(sendSmsApi.PreviewSmsMessageAsync(request).Result, SmsPreviewAssertions);
        AssertResponseWithHttpInfo(sendSmsApi.PreviewSmsMessageWithHttpInfo(request), SmsPreviewAssertions, 200);
        AssertResponseWithHttpInfo(sendSmsApi.PreviewSmsMessageWithHttpInfoAsync(request).Result, SmsPreviewAssertions,
            200);
    }

    [TestMethod]
    public void ShouldGetScheduledSmsMessages()
    {
        var expectedBulkId = "BULK-ID-123-xyz";
        var expectedSendAt = "2021-02-22T17:42:05.390+0100";

        var expectedResponse = $@"
            {{
                ""bulkId"": ""{expectedBulkId}"",
                ""sendAt"": ""{expectedSendAt}""
            }}";

        SetUpGetRequest(SMS_BULKS_ENDPOINT, 200, expectedResponse,
            new Dictionary<string, string> { { "bulkId", expectedBulkId } });

        void BulkResponseAssertions(SmsBulkResponse response)
        {
            Assert.IsNotNull(response);
            Assert.AreEqual(expectedBulkId, response.BulkId);
            Assert.AreEqual(DateTimeOffset.Parse(expectedSendAt), response.SendAt);
        }

        var scheduledSmsApi = new SmsApi(configuration);

        AssertResponse(scheduledSmsApi.GetScheduledSmsMessages(expectedBulkId), BulkResponseAssertions);
        AssertResponse(scheduledSmsApi.GetScheduledSmsMessagesAsync(expectedBulkId).Result, BulkResponseAssertions);
        AssertResponseWithHttpInfo(scheduledSmsApi.GetScheduledSmsMessagesWithHttpInfo(expectedBulkId),
            BulkResponseAssertions, 200);
        AssertResponseWithHttpInfo(scheduledSmsApi.GetScheduledSmsMessagesWithHttpInfoAsync(expectedBulkId).Result,
            BulkResponseAssertions, 200);
    }

    [TestMethod]
    public void ShouldRescheduleSmsMessages()
    {
        var expectedBulkId = "BULK-ID-123-xyz";
        var expectedSendAt = "2021-02-22T17:42:05.390+0100";
        var givenSendAtWithColon = "2021-02-22T17:42:05.390+01:00";

        var givenRequest = $@"
            {{
                ""sendAt"": ""{givenSendAtWithColon}""
                
            }}";

        var expectedResponse = $@"
            {{
                ""bulkId"": ""{expectedBulkId}"",
                ""sendAt"": ""{expectedSendAt}""
            }}";

        SetUpPutRequest(SMS_BULKS_ENDPOINT, 200, givenRequest, expectedResponse,
            new Dictionary<string, string> { { "bulkId", expectedBulkId } });

        void BulkResponseAssertions(SmsBulkResponse response)
        {
            Assert.IsNotNull(response);
            Assert.AreEqual(expectedBulkId, response.BulkId);
            Assert.AreEqual(DateTimeOffset.Parse(expectedSendAt), response.SendAt);
        }

        var scheduledSmsApi = new SmsApi(configuration);
        var bulkRequest = new SmsBulkRequest(DateTimeOffset.Parse(givenSendAtWithColon));

        AssertResponse(scheduledSmsApi.RescheduleSmsMessages(expectedBulkId, bulkRequest), BulkResponseAssertions);
        AssertResponse(scheduledSmsApi.RescheduleSmsMessagesAsync(expectedBulkId, bulkRequest).Result,
            BulkResponseAssertions);
        AssertResponseWithHttpInfo(scheduledSmsApi.RescheduleSmsMessagesWithHttpInfo(expectedBulkId, bulkRequest),
            BulkResponseAssertions, 200);
        AssertResponseWithHttpInfo(
            scheduledSmsApi.RescheduleSmsMessagesWithHttpInfoAsync(expectedBulkId, bulkRequest).Result,
            BulkResponseAssertions, 200);
    }

    [TestMethod]
    public void ShouldGetScheduledSmsMessagesStatus()
    {
        var expectedBulkId = "BULK-ID-123-xyz";
        var expectedBulkStatusString = "PAUSED";
        var expectedBulkStatus = SmsBulkStatus.Paused;

        var expectedResponse = $@"
            {{
                ""bulkId"": ""{expectedBulkId}"",
                ""status"": ""{expectedBulkStatusString}""
            }}";

        SetUpGetRequest(SMS_BULKS_STATUS_ENDPOINT, 200, expectedResponse,
            new Dictionary<string, string> { { "bulkId", expectedBulkId } });

        void BulkResponseAssertions(SmsBulkStatusResponse response)
        {
            Assert.IsNotNull(response);
            Assert.AreEqual(expectedBulkId, response.BulkId);
            Assert.AreEqual(expectedBulkStatus, response.Status);
        }

        var scheduledSmsApi = new SmsApi(configuration);

        AssertResponse(scheduledSmsApi.GetScheduledSmsMessagesStatus(expectedBulkId), BulkResponseAssertions);
        AssertResponse(scheduledSmsApi.GetScheduledSmsMessagesStatusAsync(expectedBulkId).Result,
            BulkResponseAssertions);
        AssertResponseWithHttpInfo(scheduledSmsApi.GetScheduledSmsMessagesStatusWithHttpInfo(expectedBulkId),
            BulkResponseAssertions, 200);
        AssertResponseWithHttpInfo(
            scheduledSmsApi.GetScheduledSmsMessagesStatusWithHttpInfoAsync(expectedBulkId).Result,
            BulkResponseAssertions, 200);
    }


    [TestMethod]
    public void ShouldUpdateScheduledSmsMessagesStatus()
    {
        var expectedBulkId = "BULK-ID-123-xyz";
        var expectedBulkStatusString = "PAUSED";
        var expectedBulkStatus = SmsBulkStatus.Paused;

        var givenRequest = $@"
            {{
                ""status"": ""{expectedBulkStatusString}""
                
            }}";

        var expectedResponse = $@"
            {{
                ""bulkId"": ""{expectedBulkId}"",
                ""status"": ""{expectedBulkStatusString}""
            }}";

        SetUpPutRequest(SMS_BULKS_STATUS_ENDPOINT, 200, givenRequest, expectedResponse,
            new Dictionary<string, string> { { "bulkId", expectedBulkId } });

        void BulkResponseAssertions(SmsBulkStatusResponse response)
        {
            Assert.IsNotNull(response);
            Assert.AreEqual(expectedBulkId, response.BulkId);
            Assert.AreEqual(expectedBulkStatus, response.Status);
        }

        var scheduledSmsApi = new SmsApi(configuration);
        var updateStatusRequest = new SmsUpdateStatusRequest(SmsBulkStatus.Paused);

        AssertResponse(scheduledSmsApi.UpdateScheduledSmsMessagesStatus(expectedBulkId, updateStatusRequest),
            BulkResponseAssertions);
        AssertResponse(
            scheduledSmsApi.UpdateScheduledSmsMessagesStatusAsync(expectedBulkId, updateStatusRequest).Result,
            BulkResponseAssertions);
        AssertResponseWithHttpInfo(
            scheduledSmsApi.UpdateScheduledSmsMessagesStatusWithHttpInfo(expectedBulkId, updateStatusRequest),
            BulkResponseAssertions, 200);
        AssertResponseWithHttpInfo(
            scheduledSmsApi.UpdateScheduledSmsMessagesStatusWithHttpInfoAsync(expectedBulkId, updateStatusRequest)
                .Result, BulkResponseAssertions, 200);
    }

    [TestMethod]
    public void ShouldReceiveInboundMessages()
    {
        var givenMessageId = "817790313235066447";
        var givenFrom = "385916242493";
        var givenTo = "385921004026";
        var givenText = "QUIZ Correct answer is Paris";
        var givenCleanText = "Correct answer is Paris";
        var givenKeyword = "QUIZ";
        var givenReceivedAt = "2021-08-25T16:10:00.000+0500";
        var givenSmsCount = 1;
        decimal givenPricePerMessage = 0;
        var givenCurrency = "EUR";
        var givenCallbackData = "callbackData";
        var givenMessageCount = 1;
        var givenPendingMessageCount = 0;

        var givenResponse = $@"
            {{
                ""results"": [
                 {{
                    ""messageId"": ""{givenMessageId}"",
                    ""from"": ""{givenFrom}"",
                    ""to"": ""{givenTo}"",
                    ""text"": ""{givenText}"",
                    ""cleanText"": ""{givenCleanText}"",
                    ""keyword"": ""{givenKeyword}"",
                    ""receivedAt"": ""{givenReceivedAt}"",
                    ""smsCount"": {givenSmsCount},
                    ""price"": {{
                        ""pricePerMessage"": {givenPricePerMessage},
                        ""currency"": ""{givenCurrency}""
                    }},
                    ""callbackData"": ""{givenCallbackData}""
                 }}
                ],
                ""messageCount"": {givenMessageCount},
                ""pendingMessageCount"": {givenPendingMessageCount}
            }}";

        var smsInboundResult = JsonConvert.DeserializeObject<SmsInboundMessageResult>(givenResponse);
        AssertSmsInboundMessageResult(smsInboundResult!);

        var smsInboundResultSystemTextJson = JsonSerializer.Deserialize<SmsInboundMessageResult>(givenResponse);
        AssertSmsInboundMessageResult(smsInboundResultSystemTextJson!);

        void AssertSmsInboundMessageResult(SmsInboundMessageResult smsInboundResult)
        {
            Assert.IsNotNull(smsInboundResult);
            Assert.AreEqual(givenMessageCount, smsInboundResult.MessageCount);
            Assert.AreEqual(givenPendingMessageCount, smsInboundResult.PendingMessageCount);

            Assert.AreEqual(1, smsInboundResult.Results.Count);
            var message = smsInboundResult.Results[0];
            Assert.AreEqual(givenMessageId, message.MessageId);
            Assert.AreEqual(givenFrom, message.From);
            Assert.AreEqual(givenTo, message.To);
            Assert.AreEqual(givenText, message.Text);
            Assert.AreEqual(givenCleanText, message.CleanText);
            Assert.AreEqual(givenKeyword, message.Keyword);
            Assert.AreEqual(DateTimeOffset.Parse(givenReceivedAt), message.ReceivedAt);
            Assert.AreEqual(givenSmsCount, message.SmsCount);
            Assert.AreEqual(givenPricePerMessage, message.Price.PricePerMessage);
            Assert.AreEqual(givenCurrency, message.Price.Currency);
            Assert.AreEqual(givenCallbackData, message.CallbackData);
        }
    }

    [TestMethod]
    public void ShouldReceiveOutBoundSmsMessageReport()
    {
        var givenBulkId = "BULK-ID-123-xyz";
        var givenPricePerMessage = 0.01m;
        var givenCurrency = "EUR";
        var givenStatusGroupId = 3;
        var givenStatusGroupName = MessageGeneralStatus.Delivered;
        var givenStatusId = 5;
        var givenStatusName = "DELIVERED_TO_HANDSET";
        var givenStatusDescription = "Message delivered to handset";
        var givenErrorGroupId = 0;
        var givenErrorGroupName = MessageErrorGroup.Ok;
        var givenErrorId = 0;
        var givenErrorName = "NO_ERROR";
        var givenErrorDescription = "No Error";
        var givenErrorPermanent = false;
        var givenMessageId = "MESSAGE-ID-123-xyz";
        var givenTo = "41793026727";
        var givenSender = "InfoSMS";
        var givenSentAt = "2019-11-09T16:00:00.000+0100";
        var givenDoneAt = "2019-11-09T16:00:00.000+0100";
        var givenMessageCount = 1;
        var givenCallbackData = "callbackData";
        var givenApplicationId = "marketing-automation-application";
        var givenEntityId = "promotional-traffic-entity";

        var givenSecondBulkId = "BULK-ID-123-xyz";
        var givenSecondPricePerMessage = 0.01m;
        var givenSecondCurrency = "EUR";
        var givenSecondStatusGroupId = 3;
        var givenSecondStatusGroupName = MessageGeneralStatus.Delivered;
        var givenSecondStatusId = 5;
        var givenSecondStatusName = "DELIVERED_TO_HANDSET";
        var givenSecondStatusDescription = "Message delivered to handset";
        var givenSecondErrorGroupId = 0;
        var givenSecondErrorGroupName = MessageErrorGroup.Ok;
        var givenSecondErrorId = 0;
        var givenSecondErrorName = "NO_ERROR";
        var givenSecondErrorDescription = "No Error";
        var givenSecondErrorPermanent = false;
        var givenSecondMessageId = "12db39c3-7822-4e72-a3ec-c87442c0ffc5";
        var givenSecondTo = "41793026834";
        var givenSecondSender = "InfoSMS";
        var givenSecondSentAt = "2019-11-09T17:00:00.000+0100";
        var givenSecondDoneAt = "2019-11-09T17:00:00.000+0100";
        var givenSecondMessageCount = 1;
        var givenSecondApplicationId = "marketing-automation-application";
        var givenSecondEntityId = "promotional-traffic-entity";

        var givenResponse = $@"
        {{
            ""results"": [
                {{
                    ""bulkId"": ""{givenBulkId}"",
                    ""price"": {{ 
                        ""pricePerMessage"": {givenPricePerMessage},
                        ""currency"": ""{givenCurrency}""
                    }},
                    ""status"": {{
                        ""groupId"": {givenStatusGroupId},
                        ""groupName"": ""{givenStatusGroupName}"",
                        ""id"": {givenStatusId},
                        ""name"": ""{givenStatusName}"",
                        ""description"": ""{givenStatusDescription}""
                    }},
                    ""error"": {{
                        ""groupId"": {givenErrorGroupId},
                        ""groupName"": ""{givenErrorGroupName}"",
                        ""id"": {givenErrorId},
                        ""name"": ""{givenErrorName}"",
                        ""description"": ""{givenErrorDescription}"",
                        ""permanent"": {givenErrorPermanent.ToString().ToLower()}
                    }},
                    ""messageId"": ""{givenMessageId}"",
                    ""to"": ""{givenTo}"",
                    ""sender"": ""{givenSender}"",
                    ""sentAt"": ""{givenSentAt}"",
                    ""doneAt"": ""{givenDoneAt}"",
                    ""messageCount"": {givenMessageCount},
                    ""callbackData"": ""{givenCallbackData}"",
                    ""platform"": {{
                        ""entityId"": ""{givenEntityId}"",
                        ""applicationId"": ""{givenApplicationId}""
                    }}
                }},
                {{
                    ""bulkId"": ""{givenSecondBulkId}"",
                    ""price"": {{
                        ""pricePerMessage"": {givenSecondPricePerMessage},
                        ""currency"": ""{givenSecondCurrency}""
                    }},
                    ""status"": {{
                        ""groupId"": {givenSecondStatusGroupId},
                        ""groupName"": ""{givenSecondStatusGroupName}"",
                        ""id"": {givenSecondStatusId},
                        ""name"": ""{givenSecondStatusName}"",
                        ""description"": ""{givenSecondStatusDescription}""
                    }},
                    ""error"": {{
                        ""groupId"": {givenSecondErrorGroupId},
                        ""groupName"": ""{givenSecondErrorGroupName}"",
                        ""id"": {givenSecondErrorId},
                        ""name"": ""{givenSecondErrorName}"",
                        ""description"": ""{givenSecondErrorDescription}"",
                        ""permanent"": {givenSecondErrorPermanent.ToString().ToLower()}
                    }},
                    ""messageId"": ""{givenSecondMessageId}"",
                    ""to"": ""{givenSecondTo}"",
                    ""sender"": ""{givenSecondSender}"",
                    ""sentAt"": ""{givenSecondSentAt}"",
                    ""doneAt"": ""{givenSecondDoneAt}"",
                    ""messageCount"": {givenSecondMessageCount},
                    ""platform"": {{
                        ""entityId"": ""{givenSecondEntityId}"",
                        ""applicationId"": ""{givenSecondApplicationId}""
                    }}
                }}
            ]
        }}";

        var smsDeliveryResult = JsonConvert.DeserializeObject<SmsDeliveryResult>(givenResponse);
        AssertSmsDeliveryResult(smsDeliveryResult!);

        var smsDeliveryResultSystemTextJson = JsonSerializer.Deserialize<SmsDeliveryResult>(givenResponse);
        AssertSmsDeliveryResult(smsDeliveryResultSystemTextJson!);

        void AssertSmsDeliveryResult(SmsDeliveryResult smsDeliveryResult)
        {
            Assert.IsNotNull(smsDeliveryResult);
            Assert.IsNotNull(smsDeliveryResult.Results);
            Assert.AreEqual(2, smsDeliveryResult.Results.Count);

            var smsDeliveryReport = smsDeliveryResult.Results[0];
            Assert.AreEqual(givenBulkId, smsDeliveryReport.BulkId);

            Assert.AreEqual(givenPricePerMessage, smsDeliveryReport.Price.PricePerMessage);
            Assert.AreEqual(givenCurrency, smsDeliveryReport.Price.Currency);

            Assert.AreEqual(givenStatusGroupId, smsDeliveryReport.Status.GroupId);
            Assert.AreEqual(givenStatusGroupName, smsDeliveryReport.Status.GroupName);
            Assert.AreEqual(givenStatusId, smsDeliveryReport.Status.Id);
            Assert.AreEqual(givenStatusName, smsDeliveryReport.Status.Name);
            Assert.AreEqual(givenStatusDescription, smsDeliveryReport.Status.Description);

            Assert.AreEqual(givenErrorGroupId, smsDeliveryReport.Error.GroupId);
            Assert.AreEqual(givenErrorGroupName, smsDeliveryReport.Error.GroupName);
            Assert.AreEqual(givenErrorId, smsDeliveryReport.Error.Id);
            Assert.AreEqual(givenErrorName, smsDeliveryReport.Error.Name);
            Assert.AreEqual(givenErrorDescription, smsDeliveryReport.Error.Description);

            Assert.AreEqual(givenMessageId, smsDeliveryReport.MessageId);
            Assert.AreEqual(givenTo, smsDeliveryReport.To);
            Assert.AreEqual(givenSender, smsDeliveryReport.Sender);
            Assert.AreEqual(DateTimeOffset.Parse(givenSentAt), smsDeliveryReport.SentAt);
            Assert.AreEqual(DateTimeOffset.Parse(givenDoneAt), smsDeliveryReport.DoneAt);
            Assert.AreEqual(givenMessageCount, smsDeliveryReport.MessageCount);
            Assert.AreEqual(givenCallbackData, smsDeliveryReport.CallbackData);

            Assert.AreEqual(givenEntityId, smsDeliveryReport.Platform.EntityId);
            Assert.AreEqual(givenApplicationId, smsDeliveryReport.Platform.ApplicationId);

            var smsSecondDeliveryReport = smsDeliveryResult.Results[1];
            Assert.AreEqual(givenSecondBulkId, smsSecondDeliveryReport.BulkId);

            Assert.AreEqual(givenSecondPricePerMessage, smsSecondDeliveryReport.Price.PricePerMessage);
            Assert.AreEqual(givenSecondCurrency, smsSecondDeliveryReport.Price.Currency);

            Assert.AreEqual(givenSecondStatusGroupId, smsSecondDeliveryReport.Status.GroupId);
            Assert.AreEqual(givenSecondStatusGroupName, smsSecondDeliveryReport.Status.GroupName);
            Assert.AreEqual(givenSecondStatusId, smsSecondDeliveryReport.Status.Id);
            Assert.AreEqual(givenSecondStatusName, smsSecondDeliveryReport.Status.Name);
            Assert.AreEqual(givenSecondStatusDescription, smsSecondDeliveryReport.Status.Description);

            Assert.AreEqual(givenSecondErrorGroupId, smsSecondDeliveryReport.Error.GroupId);
            Assert.AreEqual(givenSecondErrorGroupName, smsSecondDeliveryReport.Error.GroupName);
            Assert.AreEqual(givenSecondErrorId, smsSecondDeliveryReport.Error.Id);
            Assert.AreEqual(givenSecondErrorName, smsSecondDeliveryReport.Error.Name);
            Assert.AreEqual(givenSecondErrorDescription, smsSecondDeliveryReport.Error.Description);

            Assert.AreEqual(givenSecondMessageId, smsSecondDeliveryReport.MessageId);
            Assert.AreEqual(givenSecondTo, smsSecondDeliveryReport.To);
            Assert.AreEqual(givenSecondSender, smsSecondDeliveryReport.Sender);
            Assert.AreEqual(DateTimeOffset.Parse(givenSecondSentAt), smsSecondDeliveryReport.SentAt);
            Assert.AreEqual(DateTimeOffset.Parse(givenSecondDoneAt), smsSecondDeliveryReport.DoneAt);
            Assert.AreEqual(givenSecondMessageCount, smsSecondDeliveryReport.MessageCount);

            Assert.AreEqual(givenSecondEntityId, smsSecondDeliveryReport.Platform.EntityId);
            Assert.AreEqual(givenSecondApplicationId, smsSecondDeliveryReport.Platform.ApplicationId);
        }
    }
}