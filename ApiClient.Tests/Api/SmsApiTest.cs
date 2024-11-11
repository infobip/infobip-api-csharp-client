using System.Globalization;
using Infobip.Api.Client.Api;
using Infobip.Api.Client.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace ApiClient.Tests.Api;

[TestClass]
public class SmsApiTest : ApiTest
{
    protected const string SMS_SEND_TEXT_ADVANCED_ENDPOINT = "/sms/2/text/advanced";
    protected const string SMS_SEND_BINARY_ADVANCED_ENDPOINT = "/sms/2/binary/advanced";
    protected const string SMS_LOGS_ENDPOINT = "/sms/1/logs";
    protected const string SMS_REPORTS_ENDPOINT = "/sms/1/reports";
    protected const string SMS_INBOX_REPORTS_ENDPOINT = "/sms/1/inbox/reports";
    protected const string SMS_SEND_PREVIEW_ENDPOINT = "/sms/1/preview";
    protected const string SMS_BULKS_ENDPOINT = "/sms/1/bulks";
    protected const string SMS_BULKS_STATUS_ENDPOINT = "/sms/1/bulks/status";

    protected const int PENDING_STATUS_GROUP_ID = 1;
    protected const string PENDING_STATUS_GROUP_NAME = "PENDING";
    protected const int PENDING_STATUS_ID = 26;
    protected const string PENDING_STATUS_NAME = "MESSAGE_ACCEPTED";
    protected const string PENDING_STATUS_DESCRIPTION = "Message sent to next instance";

    protected const int DELIVERED_STATUS_GROUP_ID = 3;
    protected const string DELIVERED_STATUS_GROUP_NAME = "DELIVERED";
    protected const int DELIVERED_STATUS_ID = 5;
    protected const string DELIVERED_STATUS_NAME = "DELIVERED_TO_HANDSET";
    protected const string DELIVERED_STATUS_DESCRIPTION = "Message delivered to handset";

    protected const int NO_ERROR_GROUP_ID = 0;
    protected const string NO_ERROR_GROUP_NAME = "Ok";
    protected const int NO_ERROR_ID = 0;
    protected const string NO_ERROR_NAME = "NO_ERROR";
    protected const string NO_ERROR_DESCRIPTION = "No Error";
    protected const bool NO_ERROR_IS_PERMANENT = false;

    [TestMethod]
    public void ShouldSendSimpleSms()
    {
        var givenFlash = false;
        var givenFrom = "InfoSMS";
        var givenIntermediateReport = false;
        var givenText = "This is a sample message";
        var givenIncludeSmsCountInResponse = false;

        var expectedTo = "41793026727";
        var expectedMessageId = "This is a sample message";
        var expectedBulkId = "2034072219640523072";

        var givenRequest = $@"
            {{
                ""messages"": [
                {{
                    ""destinations"": [
                        {{
                            ""to"": ""{expectedTo}""
                        }}
                      ],
                    ""flash"":{givenFlash.ToString().ToLower()},
                    ""from"": ""{givenFrom}"",
                    ""intermediateReport"":{givenIntermediateReport.ToString().ToLower()},
                    ""text"": ""{givenText}""
                }}
                ],
                ""includeSmsCountInResponse"":{givenIncludeSmsCountInResponse.ToString().ToLower()}
            }}";

        var expectedResponse = PreparePendingResponse(expectedBulkId, expectedTo, expectedMessageId);

        SetUpPostRequest(SMS_SEND_TEXT_ADVANCED_ENDPOINT, givenRequest, expectedResponse, 200);

        var smsApi = new SmsApi(configuration);

        var destination = new SmsDestination(to: expectedTo);

        var smsMessage = new SmsTextualMessage(
            from: givenFrom,
            destinations: new List<SmsDestination> { destination },
            text: givenText
        );

        var smsRequest = new SmsAdvancedTextualRequest(
            messages: new List<SmsTextualMessage> { smsMessage }
        );

        void SmsResponseAssertion(SmsResponse smsResponse)
        {
            Assert.IsNotNull(smsResponse);
            Assert.AreEqual(expectedBulkId, smsResponse.BulkId);
            Assert.AreEqual(1, smsResponse.Messages.Count);
            Assert.AreEqual(expectedMessageId, smsResponse.Messages[0].MessageId);
            Assert.AreEqual(expectedTo, smsResponse.Messages[0].To);

            AssertPendingSmsResponse(smsResponse.Messages[0]);
        }

        AssertResponse(smsApi.SendSmsMessage(smsRequest), SmsResponseAssertion);
        AssertResponse(smsApi.SendSmsMessageAsync(smsRequest).Result, SmsResponseAssertion);

        AssertResponseWithHttpInfo(smsApi.SendSmsMessageWithHttpInfo(smsRequest), SmsResponseAssertion);
        AssertResponseWithHttpInfo(smsApi.SendSmsMessageWithHttpInfoAsync(smsRequest).Result, SmsResponseAssertion);
    }


    [TestMethod]
    public void ShouldSendFlashSms()
    {
        var givenFlash = false;
        var givenFrom = "InfoSMS";
        var givenIntermediateReport = false;
        var givenText = "This is a sample message";
        var givenIncludeSmsCountInResponse = false;

        var expectedTo = "41793026727";
        var expectedMessageId = "This is a sample message";
        var expectedBulkId = "2034072219640523072";

        var givenRequest = $@"
            {{
                ""messages"": [
                {{
                    ""destinations"": [
                        {{
                            ""to"": ""{expectedTo}""
                        }}
                      ],
                    ""flash"":{givenFlash.ToString().ToLower()},
                    ""from"": ""{givenFrom}"",
                    ""intermediateReport"":{givenIntermediateReport.ToString().ToLower()},
                    ""text"": ""{givenText}""
                }}
                ],
                ""includeSmsCountInResponse"": {givenIncludeSmsCountInResponse.ToString().ToLower()}
            }}";

        var expectedResponse = PreparePendingResponse(expectedBulkId, expectedTo, expectedMessageId);

        SetUpPostRequest(SMS_SEND_TEXT_ADVANCED_ENDPOINT, givenRequest, expectedResponse, 200);

        var smsApi = new SmsApi(configuration);

        var destination = new SmsDestination(to: expectedTo);

        var smsMessage = new SmsTextualMessage(
            from: givenFrom,
            destinations: new List<SmsDestination> { destination },
            text: givenText,
            flash: givenFlash
        );

        var smsRequest = new SmsAdvancedTextualRequest(
            messages: new List<SmsTextualMessage> { smsMessage }
        );

        void SmsResponseAssertion(SmsResponse smsResponse)
        {
            Assert.IsNotNull(smsResponse);
            Assert.AreEqual(expectedBulkId, smsResponse.BulkId);
            Assert.AreEqual(1, smsResponse.Messages.Count);
            Assert.AreEqual(expectedMessageId, smsResponse.Messages[0].MessageId);
            Assert.AreEqual(expectedTo, smsResponse.Messages[0].To);

            AssertPendingSmsResponse(smsResponse.Messages[0]);
        }

        AssertResponse(smsApi.SendSmsMessage(smsRequest), SmsResponseAssertion);
        AssertResponse(smsApi.SendSmsMessageAsync(smsRequest).Result, SmsResponseAssertion);

        AssertResponseWithHttpInfo(smsApi.SendSmsMessageWithHttpInfo(smsRequest), SmsResponseAssertion);
        AssertResponseWithHttpInfo(smsApi.SendSmsMessageWithHttpInfoAsync(smsRequest).Result, SmsResponseAssertion);
    }

    [TestMethod]
    public void ShouldSendFullyFeaturedSmsMessage()
    {
        var expectedTo1 = "41793026727";
        var expectedMessageId1 = "MESSAGE-ID-123-xyz";
        var expectedAnotherTo1 = "41793026834";
        var givenFrom1 = "InfoSMS";
        var givenText1 =
            "Artık Ulusal Dil Tanımlayıcısı ile Türkçe karakterli smslerinizi rahatlıkla iletebilirsiniz.";
        var givenFlash1 = false;
        var givenLanguageCode1 = "TR";
        var givenTransliteration1 = "TURKISH";
        var givenIntermediateReport1 = true;
        var givenNotifyUrl1 = "https://www.example.com/sms/advanced";
        var givenNotifyContentType1 = "application/json";
        var givenCallbackData1 = "DLR callback data";
        var givenValidityPeriod1 = 720L;

        var givenMessage1 = $@"
            {{
                ""destinations"": [
                    {{
                        ""to"": ""{expectedTo1}"",
                        ""messageId"": ""{expectedMessageId1}""
                    }},
                    {{
                        ""to"": ""{expectedAnotherTo1}""
                    }}
                  ],
                ""flash"": {givenFlash1.ToString().ToLower()},
                ""from"": ""{givenFrom1}"",
                ""intermediateReport"": {givenIntermediateReport1.ToString().ToLower()},
                ""text"": ""{givenText1}"",
                ""language"": {{
                    ""languageCode"": ""{givenLanguageCode1}""
                  }},
                ""transliteration"": ""{givenTransliteration1}"",
                ""notifyUrl"": ""{givenNotifyUrl1}"",
                ""notifyContentType"": ""{givenNotifyContentType1}"",
                ""callbackData"": ""{givenCallbackData1}"",
                ""validityPeriod"": {givenValidityPeriod1}
            }}";

        var expectedTo2 = "41793026700";
        var expectedMessageId2 = "2033247207850523792";
        var givenFlash2 = false;
        var givenFrom2 = "41793026700";
        var givenIntermediateReport2 = false;
        var givenText2 = "A long time ago, in a galaxy far, far away...";
        var givenSendAt2 = "2021-08-25T16:10:00.000+05:30";
        var givenDeliveryTimeFromHour2 = 6;
        var givenDeliveryTimeFromMinute2 = 0;
        var givenDeliveryTimeToHour2 = 15;
        var givenDeliveryTimeToMinute2 = 30;
        var givenDay1 = "MONDAY";
        var givenDay2 = "TUESDAY";
        var givenDay3 = "WEDNESDAY";
        var givenContentTemplateId2 = "contentTemplateId";
        var givenPrincipalEntityId2 = "expectedPrincipalEntityId";

        var givenMessage2 = $@"
            {{
                ""destinations"": [
                    {{
                        ""to"": ""{expectedTo2}"",
                        ""messageId"": ""{expectedMessageId2}"",
                    }}
                  ],
                ""flash"": {givenFlash2.ToString().ToLower()},
                ""from"": ""{givenFrom2}"",
                ""intermediateReport"": {givenIntermediateReport2.ToString().ToLower()},
                ""text"": ""{givenText2}"",
                ""sendAt"": ""{givenSendAt2}"",
                ""deliveryTimeWindow"": {{
                    ""from"": {{
                        ""hour"": {givenDeliveryTimeFromHour2}
                      }},
                    ""to"": {{
                        ""hour"": {givenDeliveryTimeToHour2},
                        ""minute"": {givenDeliveryTimeToMinute2}
                      }},
                    ""days"": [
                        ""{givenDay1}"",
                        ""{givenDay2}"",
                        ""{givenDay3}""
                      ]
                  }},
                ""regional"": {{
                    ""indiaDlt"": {{
                        ""contentTemplateId"": ""{givenContentTemplateId2}"",
                        ""principalEntityId"": ""{givenPrincipalEntityId2}""
                    }} 
                }}
            }}";

        var givenBulkId = "BULK-ID-123-xyz";
        var givenTracking = "SMS";
        var givenTrackingType = "MY_CAMPAIGN";
        var givenSendingSpeedLimitAmount = 10;
        var givenSendingSpeedLimitTimeUnitString = "HOUR";
        var givenIncludeSmsCountInResponse = false;

        var givenRequest = $@"
            {{
                ""messages"": [
                    {givenMessage1},
                    {givenMessage2}
                ],
                ""bulkId"": ""{givenBulkId}"",
                ""tracking"": {{
                    ""track"": ""{givenTracking}"",
                    ""type"": ""{givenTrackingType}""
                }},
                ""sendingSpeedLimit"": {{
                    ""amount"": {givenSendingSpeedLimitAmount},
                    ""timeUnit"": ""{givenSendingSpeedLimitTimeUnitString}""
                }},
                ""includeSmsCountInResponse"":{givenIncludeSmsCountInResponse.ToString().ToLower()}
            }}";

        var expectedResponse = PreparePendingResponse(givenBulkId, expectedTo1, expectedMessageId1,
            expectedTo2, expectedMessageId2);
        SetUpPostRequest(SMS_SEND_TEXT_ADVANCED_ENDPOINT, givenRequest, expectedResponse, 200);

        var smsApi = new SmsApi(configuration);

        var destination1 = new SmsDestination(expectedMessageId1, expectedTo1);
        var anotherDestination1 = new SmsDestination(to: expectedAnotherTo1);

        var destination2 = new SmsDestination(expectedMessageId2, expectedTo2);

        var smsMessage1 = new SmsTextualMessage(
            from: givenFrom1,
            destinations: new List<SmsDestination> { destination1, anotherDestination1 },
            text: givenText1,
            flash: givenFlash1,
            language: new SmsLanguage(givenLanguageCode1),
            transliteration: givenTransliteration1,
            intermediateReport: givenIntermediateReport1,
            notifyUrl: givenNotifyUrl1,
            notifyContentType: givenNotifyContentType1,
            callbackData: givenCallbackData1,
            validityPeriod: givenValidityPeriod1
        );

        var smsMessage2 = new SmsTextualMessage(
            from: givenFrom2,
            destinations: new List<SmsDestination> { destination2 },
            text: givenText2,
            sendAt: DateTimeOffset.Parse(givenSendAt2),
            deliveryTimeWindow: new SmsDeliveryTimeWindow(
                new List<SmsDeliveryDay> { SmsDeliveryDay.Monday, SmsDeliveryDay.Tuesday, SmsDeliveryDay.Wednesday },
                new SmsDeliveryTimeFrom(givenDeliveryTimeFromHour2, givenDeliveryTimeFromMinute2),
                new SmsDeliveryTimeTo(givenDeliveryTimeToHour2, givenDeliveryTimeToMinute2)
            ),
            regional: new SmsRegionalOptions(
                new SmsIndiaDltOptions(givenContentTemplateId2, givenPrincipalEntityId2)
            )
        );

        var smsRequest = new SmsAdvancedTextualRequest(
            messages: new List<SmsTextualMessage> { smsMessage1, smsMessage2 },
            bulkId: givenBulkId,
            tracking: new SmsTracking(
                track: givenTracking,
                type: givenTrackingType
            ),
            sendingSpeedLimit: new SmsSendingSpeedLimit(
                givenSendingSpeedLimitAmount,
                SmsSpeedLimitTimeUnit.Hour
            )
        );

        void SmsResponseAssertion(SmsResponse smsResponse)
        {
            Assert.IsNotNull(smsResponse);
            Assert.AreEqual(givenBulkId, smsResponse.BulkId);
            Assert.AreEqual(2, smsResponse.Messages.Count);

            Assert.AreEqual(expectedMessageId1, smsResponse.Messages[0].MessageId);
            Assert.AreEqual(expectedTo1, smsResponse.Messages[0].To);

            Assert.AreEqual(expectedMessageId2, smsResponse.Messages[1].MessageId);
            Assert.AreEqual(expectedTo2, smsResponse.Messages[1].To);

            AssertPendingSmsResponse(smsResponse.Messages[0]);
            AssertPendingSmsResponse(smsResponse.Messages[1]);
        }

        AssertResponse(smsApi.SendSmsMessage(smsRequest), SmsResponseAssertion);
        AssertResponse(smsApi.SendSmsMessageAsync(smsRequest).Result, SmsResponseAssertion);

        AssertResponseWithHttpInfo(smsApi.SendSmsMessageWithHttpInfo(smsRequest), SmsResponseAssertion);
        AssertResponseWithHttpInfo(smsApi.SendSmsMessageWithHttpInfoAsync(smsRequest).Result, SmsResponseAssertion);
    }

    [TestMethod]
    public void ShouldSendFullyFeaturedBinaryMessage()
    {
        var expectedTo1 = "41793026727";
        var expectedMessageId1 = "MESSAGE-ID-123-xyz";
        var expectedAnotherTo1 = "41793026834";
        var givenFlash1 = false;
        var givenFrom1 = "InfoSMS";
        var givenIntermediateReport1 = true;
        var givenHex1 = "54 65 73 74 20 6d 65 73 73 61 67 65 2e";
        var givenDataCoding1 = 0;
        var givenEsmClass1 = 0;
        var givenNotifyUrl1 = "https://www.example.com/sms/advanced";
        var givenNotifyContentType1 = "application/json";
        var givenCallbackData1 = "DLR callback data";
        var givenValidityPeriod1 = 720L;

        var givenMessage1 = $@"
            {{
                ""destinations"": [
                    {{
                        ""to"": ""{expectedTo1}"",
                        ""messageId"": ""{expectedMessageId1}""
                    }},
                    {{
                        ""to"": ""{expectedAnotherTo1}""
                    }}
                  ],
                ""flash"": {givenFlash1.ToString().ToLower()},
                ""from"": ""{givenFrom1}"",
                ""intermediateReport"": {givenIntermediateReport1.ToString().ToLower()},
                ""binary"": {{
                    ""hex"": ""{givenHex1}""
                  }},
                ""notifyUrl"": ""{givenNotifyUrl1}"",
                ""notifyContentType"": ""{givenNotifyContentType1}"",
                ""callbackData"": ""{givenCallbackData1}"",
                ""validityPeriod"": {givenValidityPeriod1}
            }}";

        var expectedTo2 = "41793026700";
        var expectedMessageId2 = "2033247207850523792";
        var givenFlash2 = false;
        var givenFrom2 = "41793026700";
        var givenIntermediateReport2 = false;
        var givenHex2 = "54 65 73 74 20 6d 65 73 73 61 67 65 2e";
        var givenDataCoding2 = 0;
        var givenEsmClass2 = 0;
        var givenSendAt2 = "2021-08-25T16:10:00.000+05:00";
        var givenDeliveryTimeFromHour2 = 6;
        var givenDeliveryTimeFromMinute2 = 0;
        var givenDeliveryTimeToHour2 = 15;
        var givenDeliveryTimeToMinute2 = 30;
        var givenDay1 = "MONDAY";
        var givenDay2 = "TUESDAY";
        var givenDay3 = "WEDNESDAY";
        var givenContentTemplateId2 = "contentTemplateId";
        var givenPrincipalEntityId2 = "givenPrincipalEntityId";

        var givenMessage2 = $@"
            {{
                ""destinations"": [
                    {{
                        ""to"": ""{expectedTo2}"",
                        ""messageId"": ""{expectedMessageId2}""
                    }}
                  ],
                ""flash"": {givenFlash2.ToString().ToLower()},
                ""from"": ""{givenFrom2}"",
                ""intermediateReport"": {givenIntermediateReport2.ToString().ToLower()},
                ""binary"": {{
                    ""hex"": ""{givenHex2}""
                  }},                
                ""sendAt"": ""{givenSendAt2}"",
                ""deliveryTimeWindow"": {{
                    ""from"": {{
                        ""hour"": {givenDeliveryTimeFromHour2}
                      }},
                    ""to"": {{
                        ""hour"": {givenDeliveryTimeToHour2},
                        ""minute"": {givenDeliveryTimeToMinute2}
                      }},
                    ""days"": [
                        ""{givenDay1}"",
                        ""{givenDay2}"",
                        ""{givenDay3}""
                      ]
                  }},
                ""regional"": {{
                    ""indiaDlt"": {{
                        ""contentTemplateId"": ""{givenContentTemplateId2}"",
                        ""principalEntityId"": ""{givenPrincipalEntityId2}""
                    }} 
                }}
            }}";

        var givenBulkId = "BULK-ID-123-xyz";
        var givenSendingSpeedLimitAmount = 10;
        var givenSendingSpeedLimitTimeUnitString = "HOUR";

        var givenRequest = $@"
            {{
                ""messages"": [
                    {givenMessage1},
                    {givenMessage2}
                ],
                ""bulkId"": ""{givenBulkId}"",
                ""sendingSpeedLimit"": {{
                    ""amount"": {givenSendingSpeedLimitAmount},
                    ""timeUnit"": ""{givenSendingSpeedLimitTimeUnitString}""
                }}
            }}";

        var expectedResponse = PreparePendingResponse(givenBulkId, expectedTo1, expectedMessageId1,
            expectedTo2, expectedMessageId2);
        SetUpPostRequest(SMS_SEND_BINARY_ADVANCED_ENDPOINT, givenRequest, expectedResponse, 200);

        var smsApi = new SmsApi(configuration);

        var destination1 = new SmsDestination(expectedMessageId1, expectedTo1);
        var anotherDestination1 = new SmsDestination(to: expectedAnotherTo1);

        var destination2 = new SmsDestination(expectedMessageId2, expectedTo2);

        var smsMessage1 = new SmsBinaryMessage(
            from: givenFrom1,
            destinations: new List<SmsDestination> { destination1, anotherDestination1 },
            binary: new SmsBinaryContent
            (
                hex: givenHex1,
                dataCoding: givenDataCoding1,
                esmClass: givenEsmClass1
            ),
            intermediateReport: givenIntermediateReport1,
            notifyUrl: givenNotifyUrl1,
            notifyContentType: givenNotifyContentType1,
            callbackData: givenCallbackData1,
            validityPeriod: givenValidityPeriod1
        );

        var smsMessage2 = new SmsBinaryMessage(
            from: givenFrom2,
            destinations: new List<SmsDestination> { destination2 },
            binary: new SmsBinaryContent
            (
                hex: givenHex2,
                dataCoding: givenDataCoding2,
                esmClass: givenEsmClass2
            ),
            sendAt: DateTimeOffset.Parse(givenSendAt2),
            deliveryTimeWindow: new SmsDeliveryTimeWindow(
                new List<SmsDeliveryDay> { SmsDeliveryDay.Monday, SmsDeliveryDay.Tuesday, SmsDeliveryDay.Wednesday },
                new SmsDeliveryTimeFrom(givenDeliveryTimeFromHour2, givenDeliveryTimeFromMinute2),
                new SmsDeliveryTimeTo(givenDeliveryTimeToHour2, givenDeliveryTimeToMinute2)
            ),
            regional: new SmsRegionalOptions(
                new SmsIndiaDltOptions(givenContentTemplateId2, givenPrincipalEntityId2)
            )
        );

        var smsRequest = new SmsAdvancedBinaryRequest
        (
            messages: new List<SmsBinaryMessage> { smsMessage1, smsMessage2 },
            bulkId: givenBulkId,
            sendingSpeedLimit: new SmsSendingSpeedLimit
            {
                Amount = givenSendingSpeedLimitAmount,
                TimeUnit = SmsSpeedLimitTimeUnit.Hour
            }
        );

        void SmsResponseAssertion(SmsResponse smsResponse)
        {
            Assert.IsNotNull(smsResponse);
            Assert.AreEqual(givenBulkId, smsResponse.BulkId);
            Assert.AreEqual(2, smsResponse.Messages.Count);

            Assert.AreEqual(expectedMessageId1, smsResponse.Messages[0].MessageId);
            Assert.AreEqual(expectedTo1, smsResponse.Messages[0].To);

            Assert.AreEqual(expectedMessageId2, smsResponse.Messages[1].MessageId);
            Assert.AreEqual(expectedTo2, smsResponse.Messages[1].To);

            AssertPendingSmsResponse(smsResponse.Messages[0]);
            AssertPendingSmsResponse(smsResponse.Messages[1]);
        }

        AssertResponse(smsApi.SendBinarySmsMessage(smsRequest), SmsResponseAssertion);
        AssertResponse(smsApi.SendBinarySmsMessageAsync(smsRequest).Result, SmsResponseAssertion);

        AssertResponseWithHttpInfo(smsApi.SendBinarySmsMessageWithHttpInfo(smsRequest), SmsResponseAssertion);
        AssertResponseWithHttpInfo(smsApi.SendBinarySmsMessageWithHttpInfoAsync(smsRequest).Result,
            SmsResponseAssertion);
    }

    [TestMethod]
    public void ShouldSendFlashBinarySms()
    {
        var expectedBulkId = "2034072219640523072";
        var expectedMessageId = "2250be2d4219-3af1-78856-aabe-1362af1edfd2";
        var expectedTo = "41793026727";

        var givenFrom = "InfoSMS";
        var givenIntermediateReport = false;
        var givenHex =
            "0048 0065 006c 006c 006f 0020 0077 006f 0072 006c 0064 002c 0020 039a 03b1 03bb 03b7 03bc 03ad 03c1 03b1 0020 03ba 03cc 03c3 03bc 03b5 002c 0020 30b3 30f3 30cb 30c1 30cf";
        var givenFlash = true;

        var givenRequest = $@"
            {{
                ""messages"": [
                        {{
                    ""destinations"": [
                        {{
                            ""to"": ""{expectedTo}""
                        }}
                      ],
                    ""flash"": {givenFlash.ToString().ToLower()},
                    ""from"": ""{givenFrom}"",
                    ""intermediateReport"": {givenIntermediateReport.ToString().ToLower()},
                    ""binary"": {{
                        ""hex"": ""{givenHex}""
                      }}
                }}
                ]
            }}";

        var expectedResponse = PreparePendingResponse(expectedBulkId, expectedTo, expectedMessageId);
        SetUpPostRequest(SMS_SEND_BINARY_ADVANCED_ENDPOINT, givenRequest, expectedResponse, 200);

        var smsApi = new SmsApi(configuration);

        var binaryMessage = new SmsBinaryMessage(
            from: givenFrom,
            destinations: new List<SmsDestination> { new(to: expectedTo) },
            binary: new SmsBinaryContent(hex: givenHex),
            flash: givenFlash
        );

        var smsRequest = new SmsAdvancedBinaryRequest
        (
            messages: new List<SmsBinaryMessage> { binaryMessage }
        );

        void SmsResponseAssertion(SmsResponse smsResponse)
        {
            Assert.IsNotNull(smsResponse);
            Assert.AreEqual(expectedBulkId, smsResponse.BulkId);
            Assert.AreEqual(1, smsResponse.Messages.Count);

            Assert.AreEqual(expectedMessageId, smsResponse.Messages[0].MessageId);
            Assert.AreEqual(expectedTo, smsResponse.Messages[0].To);

            AssertPendingSmsResponse(smsResponse.Messages[0]);
        }

        AssertResponse(smsApi.SendBinarySmsMessage(smsRequest), SmsResponseAssertion);
        AssertResponse(smsApi.SendBinarySmsMessageAsync(smsRequest).Result, SmsResponseAssertion);

        AssertResponseWithHttpInfo(smsApi.SendBinarySmsMessageWithHttpInfo(smsRequest), SmsResponseAssertion);
        AssertResponseWithHttpInfo(smsApi.SendBinarySmsMessageWithHttpInfoAsync(smsRequest).Result,
            SmsResponseAssertion);
    }

    [TestMethod]
    public void ShouldGetSmsLogs()
    {
        var expectedBulkId = "BULK-ID-123-xyz";
        var expectedMessageIdMessage1 = "MESSAGE-ID-123-xyz";
        var expectedToMessage1 = "41793026727";
        var expectedSendAtMessage1 = "2019-11-09T16:00:00.000+0530";
        var expectedDoneAtMessage1 = "2019-11-09T16:00:00.000+0530";
        var expectedSmsCountMessage1 = 1;
        var expectedPricePerMessageMessage1 = "0.01";
        var expectedCurrencyMessage1 = "EUR";

        var expectedMessageIdMessage2 = "12db39c3-7822-4e72-a3ec-c87442c0ffc5";
        var expectedToMessage2 = "41793026834";
        var expectedSendAtMessage2 = "2019-11-09T17:00:00.000+0000";
        var expectedDoneAtMessage2 = "2019-11-09T17:00:00.000+0000";
        var expectedSmsCountMessage2 = 5;
        var expectedPricePerMessageMessage2 = "0.05";
        var expectedCurrencyMessage2 = "HRK";

        var expectedResponse = $@"
            {{
                ""results"": [
                  {{
                     ""bulkId"": ""{expectedBulkId}"",
                     ""messageId"": ""{expectedMessageIdMessage1}"",
                     ""to"": ""{expectedToMessage1}"",
                     ""sentAt"": ""{expectedSendAtMessage1}"",
                     ""doneAt"": ""{expectedDoneAtMessage1}"",
                     ""smsCount"": {expectedSmsCountMessage1},
                     ""price"":
                     {{
                        ""pricePerMessage"": {expectedPricePerMessageMessage1},
                        ""currency"": ""{expectedCurrencyMessage1}""
                     }},
                     ""status"":
                     {{
                        ""groupId"": {DELIVERED_STATUS_GROUP_ID},
                        ""groupName"": ""{DELIVERED_STATUS_GROUP_NAME}"",
                        ""id"": {DELIVERED_STATUS_ID},
                        ""name"": ""{DELIVERED_STATUS_NAME}"",
                        ""description"": ""{DELIVERED_STATUS_DESCRIPTION}""
   
                     }},
                     ""error"":
                     {{
                        ""groupId"": {NO_ERROR_GROUP_ID},
                        ""groupName"": ""{NO_ERROR_GROUP_NAME}"",
                        ""id"": {NO_ERROR_ID},
                        ""name"": ""{NO_ERROR_NAME}"",
                        ""description"": ""{NO_ERROR_DESCRIPTION}"",
                        ""permanent"": {NO_ERROR_IS_PERMANENT.ToString().ToLower()}
                     }}
                  }},
                  {{
                    ""bulkId"": ""{expectedBulkId}"",
                     ""messageId"": ""{expectedMessageIdMessage2}"",
                     ""to"": ""{expectedToMessage2}"",
                     ""sentAt"": ""{expectedSendAtMessage2}"",
                     ""doneAt"": ""{expectedDoneAtMessage2}"",
                     ""smsCount"": {expectedSmsCountMessage2},
                     ""price"":
                     {{
                        ""pricePerMessage"": {expectedPricePerMessageMessage2},
                        ""currency"": ""{expectedCurrencyMessage2}""
                     }},
                     ""status"":
                     {{
                        ""groupId"": {DELIVERED_STATUS_GROUP_ID},
                        ""groupName"": ""{DELIVERED_STATUS_GROUP_NAME}"",
                        ""id"": {DELIVERED_STATUS_ID},
                        ""name"": ""{DELIVERED_STATUS_NAME}"",
                        ""description"": ""{DELIVERED_STATUS_DESCRIPTION}""
   
                     }},
                     ""error"":
                     {{
                        ""groupId"": {NO_ERROR_GROUP_ID},
                        ""groupName"": ""{NO_ERROR_GROUP_NAME}"",
                        ""id"": {NO_ERROR_ID},
                        ""name"": ""{NO_ERROR_NAME}"",
                        ""description"": ""{NO_ERROR_DESCRIPTION}"",
                        ""permanent"": {NO_ERROR_IS_PERMANENT.ToString().ToLower()}
                     }}
                  }}
                ]
            }}";

        var givenSentSinceString = "2015-02-22T17:42:05.390+0100";
        var searchParams = new Dictionary<string, string>
        {
            { "bulkId", expectedBulkId },
            { "sentSince", givenSentSinceString }
        };

        SetUpGetRequest(SMS_LOGS_ENDPOINT, searchParams, expectedResponse, 200);

        void LogsResponseAssertion(SmsLogsResponse logsResponse)
        {
            Assert.IsNotNull(logsResponse);
            List<SmsLog> results = logsResponse.Results;
            Assert.IsNotNull(results);
            Assert.AreEqual(2, results.Count);

            Assert.AreEqual(expectedBulkId, results[0].BulkId);
            Assert.AreEqual(expectedMessageIdMessage1, results[0].MessageId);
            Assert.AreEqual(expectedToMessage1, results[0].To);
            Assert.AreEqual(DateTimeOffset.Parse(expectedSendAtMessage1), results[0].SentAt);
            Assert.AreEqual(DateTimeOffset.Parse(expectedDoneAtMessage1), results[0].DoneAt);
            Assert.IsNull(results[0].From);
            Assert.IsNull(results[0].Text);
            Assert.IsNull(results[0].MccMnc);
            Assert.AreEqual(decimal.Parse(expectedPricePerMessageMessage1, CultureInfo.InvariantCulture),
                results[0].Price.PricePerMessage);
            Assert.AreEqual(expectedCurrencyMessage1, results[0].Price.Currency);
            AssertDeliveredSmsStatus(results[0].Status);
            AssertNoError(results[0].Error);

            Assert.AreEqual(expectedBulkId, results[1].BulkId);
            Assert.AreEqual(expectedMessageIdMessage2, results[1].MessageId);
            Assert.AreEqual(expectedToMessage2, results[1].To);
            Assert.AreEqual(DateTimeOffset.Parse(expectedSendAtMessage2), results[1].SentAt);
            Assert.AreEqual(DateTimeOffset.Parse(expectedDoneAtMessage2), results[1].DoneAt);
            Assert.IsNull(results[1].From);
            Assert.IsNull(results[1].Text);
            Assert.IsNull(results[1].MccMnc);
            Assert.AreEqual(decimal.Parse(expectedPricePerMessageMessage2, CultureInfo.InvariantCulture),
                results[1].Price.PricePerMessage);
            Assert.AreEqual(expectedCurrencyMessage2, results[1].Price.Currency);
            AssertDeliveredSmsStatus(results[1].Status);
            AssertNoError(results[1].Error);
        }

        var smsApi = new SmsApi(configuration);

        AssertResponse
        (
            smsApi.GetOutboundSmsMessageLogs
            (
                sentSince: DateTimeOffset.Parse(givenSentSinceString),
                bulkId: new List<string> { expectedBulkId }
            ),
            LogsResponseAssertion
        );
        AssertResponse
        (
            smsApi.GetOutboundSmsMessageLogsAsync
            (
                sentSince: DateTimeOffset.Parse(givenSentSinceString),
                bulkId: new List<string> { expectedBulkId }
            ).Result,
            LogsResponseAssertion
        );
        AssertResponseWithHttpInfo
        (
            smsApi.GetOutboundSmsMessageLogsWithHttpInfo
            (
                sentSince: DateTimeOffset.Parse(givenSentSinceString),
                bulkId: new List<string> { expectedBulkId }
            ),
            LogsResponseAssertion
        );
        AssertResponseWithHttpInfo
        (
            smsApi.GetOutboundSmsMessageLogsWithHttpInfoAsync
            (
                sentSince: DateTimeOffset.Parse(givenSentSinceString),
                bulkId: new List<string> { expectedBulkId }
            ).Result,
            LogsResponseAssertion
        );
    }

    [TestMethod]
    public void ShouldGetSmsReports()
    {
        var expectedBulkId = "BULK-ID-123-xyz";
        var expectedMessageId1 = "MESSAGE-ID-123-xyz";
        var expectedTo1 = "41793026727";
        var expectedSentAt1 = "2019-11-09T16:00:00.000+0000";
        var expectedDoneAt1 = "2019-11-09T16:00:00.000+0000";
        var expectedSmsCount = 1;
        var expectedPricePerMessage = "0.01";
        var expectedCurrency = "EUR";
        var expectedEntityId = "promotional-traffic-entity";
        var expectedApplicationId1 = "marketing-automation-application";

        var expectedMessageId2 = "12db39c3-7822-4e72-a3ec-c87442c0ffc5";
        var expectedTo2 = "41793026834";
        var expectedSentAt2 = "2019-11-09T17:00:00.000+0000";
        var expectedDoneAt2 = "2019-11-09T17:00:00.000+0000";
        var expectedApplicationId2 = "default";

        var expectedResponse = $@"
            {{
                ""results"": [
                    {{
                        ""bulkId"": ""{expectedBulkId}"",
                        ""messageId"": ""{expectedMessageId1}"",
                        ""to"": ""{expectedTo1}"",
                        ""sentAt"": ""{expectedSentAt1}"",
                        ""doneAt"": ""{expectedDoneAt1}"",
                        ""smsCount"": {expectedSmsCount},
                        ""price"": {{
                            ""pricePerMessage"": {expectedPricePerMessage},
                            ""currency"": ""{expectedCurrency}""
                        }},
                        ""status"": {{
                            ""groupId"": {DELIVERED_STATUS_GROUP_ID},
                            ""groupName"": ""{DELIVERED_STATUS_GROUP_NAME}"",
                            ""id"": {DELIVERED_STATUS_ID},
                            ""name"": ""{DELIVERED_STATUS_NAME}"",
                            ""description"": ""{DELIVERED_STATUS_DESCRIPTION}""
                        }},
                        ""error"": {{
                            ""groupId"": {NO_ERROR_GROUP_ID},
                            ""groupName"": ""{NO_ERROR_GROUP_NAME}"",
                            ""id"": {NO_ERROR_ID},
                            ""name"": ""{NO_ERROR_NAME}"",
                            ""description"": ""{NO_ERROR_DESCRIPTION}"",
                            ""permanent"": {NO_ERROR_IS_PERMANENT.ToString().ToLower()}
                        }},
                        ""entityId"": ""{expectedEntityId}"",
                        ""applicationId"": ""{expectedApplicationId1}""
                    }},
                    {{
                        ""bulkId"": ""{expectedBulkId}"",
                        ""messageId"": ""{expectedMessageId2}"",
                        ""to"": ""{expectedTo2}"",
                        ""sentAt"": ""{expectedSentAt2}"",
                        ""doneAt"": ""{expectedDoneAt2}"",
                        ""smsCount"": {expectedSmsCount},
                        ""price"": {{
                            ""pricePerMessage"": {expectedPricePerMessage},
                            ""currency"": ""{expectedCurrency}""
                        }},
                        ""status"": {{
                             ""groupId"": {DELIVERED_STATUS_GROUP_ID},
                             ""groupName"": ""{DELIVERED_STATUS_GROUP_NAME}"",
                             ""id"": {DELIVERED_STATUS_ID},
                             ""name"": ""{DELIVERED_STATUS_NAME}"",
                             ""description"": ""{DELIVERED_STATUS_DESCRIPTION}""
                        }},
                        ""error"": {{
                            ""groupId"": {NO_ERROR_GROUP_ID},
                            ""groupName"": ""{NO_ERROR_GROUP_NAME}"",
                            ""id"": {NO_ERROR_ID},
                            ""name"": ""{NO_ERROR_NAME}"",
                            ""description"": ""{NO_ERROR_DESCRIPTION}"",
                            ""permanent"": {NO_ERROR_IS_PERMANENT.ToString().ToLower()}
                        }},
                        ""applicationId"": ""{expectedApplicationId2}""
                    }}
                ]
            }}";

        var givenLimit = 100;

        var givenQueryParameters = new Dictionary<string, string>
        {
            { "bulkId", expectedBulkId },
            { "limit", givenLimit.ToString() }
        };

        SetUpGetRequest(SMS_REPORTS_ENDPOINT, givenQueryParameters, expectedResponse, 200);

        var smsApi = new SmsApi(configuration);

        void AssertSmsDeliveryResult(SmsDeliveryResult smsDeliveryResult)
        {
            Assert.IsNotNull(smsDeliveryResult);

            Assert.IsNotNull(smsDeliveryResult.Results[0]);
            Assert.AreEqual(expectedBulkId, smsDeliveryResult.Results[0].BulkId);
            Assert.AreEqual(expectedMessageId1, smsDeliveryResult.Results[0].MessageId);
            Assert.AreEqual(expectedTo1, smsDeliveryResult.Results[0].To);
            Assert.AreEqual(DateTimeOffset.Parse(expectedSentAt1), smsDeliveryResult.Results[0].SentAt);
            Assert.AreEqual(DateTimeOffset.Parse(expectedDoneAt1), smsDeliveryResult.Results[0].DoneAt);
            Assert.AreEqual(expectedSmsCount, smsDeliveryResult.Results[0].SmsCount);
            Assert.AreEqual(decimal.Parse(expectedPricePerMessage, CultureInfo.InvariantCulture),
                smsDeliveryResult.Results[0].Price.PricePerMessage);
            Assert.AreEqual(expectedCurrency, smsDeliveryResult.Results[0].Price.Currency);
            Assert.AreEqual(DELIVERED_STATUS_GROUP_ID, smsDeliveryResult.Results[0].Status.GroupId);
            Assert.AreEqual(DELIVERED_STATUS_GROUP_NAME, smsDeliveryResult.Results[0].Status.GroupName);
            Assert.AreEqual(DELIVERED_STATUS_ID, smsDeliveryResult.Results[0].Status.Id);
            Assert.AreEqual(DELIVERED_STATUS_NAME, smsDeliveryResult.Results[0].Status.Name);
            Assert.AreEqual(DELIVERED_STATUS_DESCRIPTION, smsDeliveryResult.Results[0].Status.Description);
            Assert.AreEqual(NO_ERROR_GROUP_ID, smsDeliveryResult.Results[0].Error.GroupId);
            Assert.AreEqual(NO_ERROR_GROUP_NAME, smsDeliveryResult.Results[0].Error.GroupName);
            Assert.AreEqual(NO_ERROR_ID, smsDeliveryResult.Results[0].Error.Id);
            Assert.AreEqual(NO_ERROR_NAME, smsDeliveryResult.Results[0].Error.Name);
            Assert.AreEqual(NO_ERROR_DESCRIPTION, smsDeliveryResult.Results[0].Error.Description);
            Assert.AreEqual(NO_ERROR_IS_PERMANENT, smsDeliveryResult.Results[0].Error.Permanent);
            Assert.AreEqual(expectedEntityId, smsDeliveryResult.Results[0].EntityId);
            Assert.AreEqual(expectedApplicationId1, smsDeliveryResult.Results[0].ApplicationId);

            Assert.IsNotNull(smsDeliveryResult.Results[1]);
            Assert.AreEqual(expectedBulkId, smsDeliveryResult.Results[1].BulkId);
            Assert.AreEqual(expectedMessageId2, smsDeliveryResult.Results[1].MessageId);
            Assert.AreEqual(expectedTo2, smsDeliveryResult.Results[1].To);
            Assert.AreEqual(smsDeliveryResult.Results[1].SentAt, DateTimeOffset.Parse(expectedSentAt2));
            Assert.AreEqual(smsDeliveryResult.Results[1].DoneAt, DateTimeOffset.Parse(expectedDoneAt2));
            Assert.AreEqual(expectedSmsCount, smsDeliveryResult.Results[1].SmsCount);
            Assert.AreEqual(decimal.Parse(expectedPricePerMessage, CultureInfo.InvariantCulture),
                smsDeliveryResult.Results[1].Price.PricePerMessage);
            Assert.AreEqual(expectedCurrency, smsDeliveryResult.Results[1].Price.Currency);
            Assert.AreEqual(DELIVERED_STATUS_GROUP_ID, smsDeliveryResult.Results[1].Status.GroupId);
            Assert.AreEqual(DELIVERED_STATUS_GROUP_NAME, smsDeliveryResult.Results[1].Status.GroupName);
            Assert.AreEqual(DELIVERED_STATUS_ID, smsDeliveryResult.Results[1].Status.Id);
            Assert.AreEqual(DELIVERED_STATUS_NAME, smsDeliveryResult.Results[1].Status.Name);
            Assert.AreEqual(DELIVERED_STATUS_DESCRIPTION, smsDeliveryResult.Results[1].Status.Description);
            Assert.AreEqual(NO_ERROR_GROUP_ID, smsDeliveryResult.Results[1].Error.GroupId);
            Assert.AreEqual(NO_ERROR_GROUP_NAME, smsDeliveryResult.Results[1].Error.GroupName);
            Assert.AreEqual(NO_ERROR_ID, smsDeliveryResult.Results[1].Error.Id);
            Assert.AreEqual(NO_ERROR_NAME, smsDeliveryResult.Results[1].Error.Name);
            Assert.AreEqual(NO_ERROR_DESCRIPTION, smsDeliveryResult.Results[1].Error.Description);
            Assert.AreEqual(NO_ERROR_IS_PERMANENT, smsDeliveryResult.Results[1].Error.Permanent);
            Assert.AreEqual(expectedApplicationId2, smsDeliveryResult.Results[1].ApplicationId);
        }

        AssertResponse(smsApi.GetOutboundSmsMessageDeliveryReports(expectedBulkId, limit: givenLimit),
            AssertSmsDeliveryResult);
        AssertResponse(smsApi.GetOutboundSmsMessageDeliveryReportsAsync(expectedBulkId, limit: givenLimit).Result,
            AssertSmsDeliveryResult);

        AssertResponseWithHttpInfo(
            smsApi.GetOutboundSmsMessageDeliveryReportsWithHttpInfo(expectedBulkId, limit: givenLimit),
            AssertSmsDeliveryResult);
        AssertResponseWithHttpInfo(
            smsApi.GetOutboundSmsMessageDeliveryReportsWithHttpInfoAsync(expectedBulkId, limit: givenLimit).Result,
            AssertSmsDeliveryResult);
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
            new Dictionary<string, string> { { "limit", givenLimit.ToString() } }, expectedResponse, 200);

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

        AssertResponseWithHttpInfo(receiveApi.GetInboundSmsMessagesWithHttpInfo(givenLimit), ResultAssertions);
        AssertResponseWithHttpInfo(receiveApi.GetInboundSmsMessagesWithHttpInfoAsync(givenLimit).Result,
            ResultAssertions);
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

        SetUpPostRequest(SMS_SEND_PREVIEW_ENDPOINT, givenRequest, expectedResponse, 200);

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
        AssertResponseWithHttpInfo(sendSmsApi.PreviewSmsMessageWithHttpInfo(request), SmsPreviewAssertions);
        AssertResponseWithHttpInfo(sendSmsApi.PreviewSmsMessageWithHttpInfoAsync(request).Result, SmsPreviewAssertions);
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

        SetUpGetRequest(SMS_BULKS_ENDPOINT, new Dictionary<string, string> { { "bulkId", expectedBulkId } },
            expectedResponse, 200);

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
            BulkResponseAssertions);
        AssertResponseWithHttpInfo(scheduledSmsApi.GetScheduledSmsMessagesWithHttpInfoAsync(expectedBulkId).Result,
            BulkResponseAssertions);
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

        SetUpPutRequest(SMS_BULKS_ENDPOINT, new Dictionary<string, string> { { "bulkId", expectedBulkId } },
            givenRequest, expectedResponse, 200);

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
            BulkResponseAssertions);
        AssertResponseWithHttpInfo(
            scheduledSmsApi.RescheduleSmsMessagesWithHttpInfoAsync(expectedBulkId, bulkRequest).Result,
            BulkResponseAssertions);
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

        SetUpGetRequest(SMS_BULKS_STATUS_ENDPOINT, new Dictionary<string, string> { { "bulkId", expectedBulkId } },
            expectedResponse, 200);

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
            BulkResponseAssertions);
        AssertResponseWithHttpInfo(
            scheduledSmsApi.GetScheduledSmsMessagesStatusWithHttpInfoAsync(expectedBulkId).Result,
            BulkResponseAssertions);
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

        SetUpPutRequest(SMS_BULKS_STATUS_ENDPOINT, new Dictionary<string, string> { { "bulkId", expectedBulkId } },
            givenRequest, expectedResponse, 200);

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
            BulkResponseAssertions);
        AssertResponseWithHttpInfo(
            scheduledSmsApi.UpdateScheduledSmsMessagesStatusWithHttpInfoAsync(expectedBulkId, updateStatusRequest)
                .Result, BulkResponseAssertions);
    }

    private void AssertDeliveredSmsStatus(MessageStatus status)
    {
        Assert.AreEqual(DELIVERED_STATUS_GROUP_ID, status.GroupId);
        Assert.AreEqual(DELIVERED_STATUS_GROUP_NAME, status.GroupName);
        Assert.AreEqual(DELIVERED_STATUS_ID, status.Id);
        Assert.AreEqual(DELIVERED_STATUS_NAME, status.Name);
        Assert.AreEqual(DELIVERED_STATUS_DESCRIPTION, status.Description);
        Assert.IsNull(status.Action);
    }

    private void AssertNoError(MessageError error)
    {
        Assert.AreEqual(NO_ERROR_GROUP_ID, error.GroupId);
        Assert.AreEqual(NO_ERROR_GROUP_NAME, error.GroupName);
        Assert.AreEqual(NO_ERROR_ID, error.Id);
        Assert.AreEqual(NO_ERROR_NAME, error.Name);
        Assert.AreEqual(NO_ERROR_DESCRIPTION, error.Description);
        Assert.AreEqual(NO_ERROR_IS_PERMANENT, error.Permanent);
    }

    private void AssertPendingSmsResponse(SmsResponseDetails responseDetails)
    {
        Assert.AreEqual(PENDING_STATUS_GROUP_ID, responseDetails.Status.GroupId);
        Assert.AreEqual(PENDING_STATUS_GROUP_NAME, responseDetails.Status.GroupName);
        Assert.AreEqual(PENDING_STATUS_ID, responseDetails.Status.Id);
        Assert.AreEqual(PENDING_STATUS_NAME, responseDetails.Status.Name);
        Assert.AreEqual(PENDING_STATUS_DESCRIPTION, responseDetails.Status.Description);
        Assert.IsNull(responseDetails.Status.Action);
    }


    private string PreparePendingResponse(string givenBulkId, string givenDestination, string givenMessageId)
    {
        return $@"
            {{
              ""bulkId"": ""{givenBulkId}"",
              ""messages"": [
                {PreparePendingResponseDetails(givenDestination, givenMessageId)}
              ]
            }}";
    }

    private string PreparePendingResponse(string givenBulkId, string givenDestination1, string givenMessageId1,
        string givenDestination2, string givenMessageId2)
    {
        return $@"
            {{
              ""bulkId"": ""{givenBulkId}"",
              ""messages"": [
                {PreparePendingResponseDetails(givenDestination1, givenMessageId1)},
                {PreparePendingResponseDetails(givenDestination2, givenMessageId2)}
              ]
            }}";
    }

    private string PreparePendingResponseDetails(string givenDestination, string givenMessageId)
    {
        return $@"
            {{
                ""to"": ""{givenDestination}"",
                ""status"": {{
                    ""groupId"": 1,
                    ""groupName"": ""PENDING"",
                    ""id"": 26,
                    ""name"": ""MESSAGE_ACCEPTED"",
                    ""description"": ""Message sent to next instance""
                }},
                ""messageId"": ""{givenMessageId}""
            }}";
    }
}