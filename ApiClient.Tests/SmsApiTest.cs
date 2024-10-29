using Infobip.Api.Client.Api;
using Infobip.Api.Client.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace ApiClient.Tests
{
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

        protected const string GIVEN_BULK_ID = "BULK-ID-123-xyz";
        protected const string GIVEN_BULK_STATUS_STRING = "PAUSED";
        protected const SmsBulkStatus GIVEN_BULK_STATUS = SmsBulkStatus.Paused;
        protected const string GIVEN_SEND_AT = "2021-02-22T17:42:05.390+0100";
        protected const string GIVEN_SEND_AT_WITH_COLON = "2021-02-22T17:42:05.390+01:00";

        [TestMethod]
        public void ShouldSendSimpleSms()
        {
            string givenDestination = "41793026727";
            string givenFrom = "InfoSMS";
            string givenText = "This is a sample message";
            string givenMessageId = "This is a sample message";
            string givenBulkId = "2034072219640523072";

            string expectedRequest = $@"
            {{
                ""messages"": [
                {{
                    ""destinations"": [
                        {{
                            ""to"": ""{givenDestination}""
                        }}
                      ],
                    ""flash"":false,
                    ""from"": ""{givenFrom}"",
                    ""intermediateReport"":false,
                    ""text"": ""{givenText}""
                }}
                ],
                ""includeSmsCountInResponse"":false
            }}";

            string expectedResponse = PreparePendingResponse(givenBulkId, givenDestination, givenMessageId);

            SetUpPostRequest(SMS_SEND_TEXT_ADVANCED_ENDPOINT, expectedRequest, expectedResponse, 200);

            var smsApi = new SmsApi(configuration);

            var destination = new SmsDestination(to: givenDestination);

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
                Assert.AreEqual(givenBulkId, smsResponse.BulkId);
                Assert.AreEqual(1, smsResponse.Messages.Count);
                Assert.AreEqual(givenMessageId, smsResponse.Messages[0].MessageId);
            }

            AssertResponse(smsApi.SendSmsMessage(smsRequest), SmsResponseAssertion);
            AssertResponse(smsApi.SendSmsMessageAsync(smsRequest).Result, SmsResponseAssertion);

            AssertResponseWithHttpInfo(smsApi.SendSmsMessageWithHttpInfo(smsRequest), SmsResponseAssertion);
            AssertResponseWithHttpInfo(smsApi.SendSmsMessageWithHttpInfoAsync(smsRequest).Result, SmsResponseAssertion);

            //Console.WriteLine(wireMockServer.LogEntries);
        }


        [TestMethod]
        public void ShouldSendFlashSms()
        {
            string givenDestination = "41793026727";
            string givenFrom = "InfoSMS";
            string givenText = "This is a sample message";
            string givenMessageId = "This is a sample message";
            string givenBulkId = "2034072219640523072";

            string expectedRequest = $@"
            {{
                ""messages"": [
                {{
                    ""destinations"": [
                        {{
                            ""to"": ""{givenDestination}""
                        }}
                      ],
                    ""flash"":true,
                    ""from"": ""{givenFrom}"",
                    ""intermediateReport"":false,
                    ""text"": ""{givenText}""
                }}
                ],
                ""includeSmsCountInResponse"": false
            }}";

            string expectedResponse = PreparePendingResponse(givenBulkId, givenDestination, givenMessageId);

            SetUpPostRequest(SMS_SEND_TEXT_ADVANCED_ENDPOINT, expectedRequest, expectedResponse, 200);

            var smsApi = new SmsApi(configuration);

            var destination = new SmsDestination(to: givenDestination);

            var smsMessage = new SmsTextualMessage(
                from: givenFrom,
                destinations: new List<SmsDestination> { destination },
                text: givenText,
                flash: true
            );

            var smsRequest = new SmsAdvancedTextualRequest(
                messages: new List<SmsTextualMessage> { smsMessage }
            );

            void SmsResponseAssertion(SmsResponse smsResponse)
            {
                Assert.IsNotNull(smsResponse);
                Assert.AreEqual(givenBulkId, smsResponse.BulkId);
                Assert.AreEqual(1, smsResponse.Messages.Count);
                Assert.AreEqual(givenMessageId, smsResponse.Messages[0].MessageId);
            }

            AssertResponse(smsApi.SendSmsMessage(smsRequest), SmsResponseAssertion);
            AssertResponse(smsApi.SendSmsMessageAsync(smsRequest).Result, SmsResponseAssertion);

            AssertResponseWithHttpInfo(smsApi.SendSmsMessageWithHttpInfo(smsRequest), SmsResponseAssertion);
            AssertResponseWithHttpInfo(smsApi.SendSmsMessageWithHttpInfoAsync(smsRequest).Result, SmsResponseAssertion);
        }

        [TestMethod]
        public void ShouldSendFullyFeaturedSmsMessage()
        {
            string givenFromMessage1 = "InfoSMS";
            string givenToMessage1 = "41793026727";
            string givenMessageIdMessage1 = "MESSAGE-ID-123-xyz";
            string givenAnotherToMessage1 = "41793026834";
            string givenTextMessage1 = "Artık Ulusal Dil Tanımlayıcısı ile Türkçe karakterli smslerinizi rahatlıkla iletebilirsiniz.";
            bool givenFlashMessage1 = false;
            string givenLanguageCodeMessage1 = "TR";
            string givenTransliterationMessage1 = "TURKISH";
            bool givenIntermediateReportMessage1 = true;
            string givenNotifyUrlMessage1 = "https://www.example.com/sms/advanced";
            string givenNotifyContentTypeMessage1 = "application/json";
            string givenCallbackDataMessage1 = "DLR callback data";
            long givenValidityPeriodMessage1 = 720L;

            string expectedMessage1 = $@"
            {{
                ""destinations"": [
                    {{
                        ""to"": ""{givenToMessage1}"",
                        ""messageId"": ""{givenMessageIdMessage1}""
                    }},
                    {{
                        ""to"": ""{givenAnotherToMessage1}""
                    }}
                  ],
                ""flash"": {givenFlashMessage1.ToString().ToLower()},
                ""from"": ""{givenFromMessage1}"",
                ""intermediateReport"": {givenIntermediateReportMessage1.ToString().ToLower()},
                ""text"": ""{givenTextMessage1}"",
                ""language"": {{
                    ""languageCode"": ""{givenLanguageCodeMessage1}""
                  }},
                ""transliteration"": ""{givenTransliterationMessage1}"",
                ""notifyUrl"": ""{givenNotifyUrlMessage1}"",
                ""notifyContentType"": ""{givenNotifyContentTypeMessage1}"",
                ""callbackData"": ""{givenCallbackDataMessage1}"",
                ""validityPeriod"": {givenValidityPeriodMessage1}
            }}";

            string givenFromMessage2 = "41793026700";
            string givenToMessage2 = "41793026700";
            string givenTextMessage2 = "A long time ago, in a galaxy far, far away...";
            string givenSendAtMessage2 = "2021-08-25T16:10:00.000+05:30";
            int givenDeliveryTimeFromHourMessage2 = 6;
            int givenDeliveryTimeFromMinuteMessage2 = 0;
            int givenDeliveryTimeToHourMessage2 = 15;
            int givenDeliveryTimeToMinuteMessage2 = 30;
            string givenContentTemplateIdMessage2 = "contentTemplateId";
            string givenPrincipalEntityIdMessage2 = "givenPrincipalEntityId";

            string expectedMessage2 = $@"
            {{
                ""destinations"": [
                    {{
                        ""to"": ""{givenToMessage2}""
                    }}
                  ],
                ""flash"": false,
                ""from"": ""{givenFromMessage2}"",
                ""intermediateReport"": false,
                ""text"": ""{givenTextMessage2}"",
                ""sendAt"": ""{givenSendAtMessage2}"",
                ""deliveryTimeWindow"": {{
                    ""from"": {{
                        ""hour"": {givenDeliveryTimeFromHourMessage2}
                      }},
                    ""to"": {{
                        ""hour"": {givenDeliveryTimeToHourMessage2},
                        ""minute"": {givenDeliveryTimeToMinuteMessage2}
                      }},
                    ""days"": [
                        ""MONDAY"",
                        ""TUESDAY"",
                        ""WEDNESDAY""
                      ]
                  }},
                ""regional"": {{
                    ""indiaDlt"": {{
                        ""contentTemplateId"": ""{givenContentTemplateIdMessage2}"",
                        ""principalEntityId"": ""{givenPrincipalEntityIdMessage2}""
                    }} 
                }}
            }}";

            // TODO check if we need to emit default values for deliveryTimeWindow
            //,
            //""minute"": { givenDeliveryTimeFromMinuteMessage2}

            string givenBulkId = "BULK-ID-123-xyz";
            string givenTracking = "SMS";
            string givenTrackingType = "MY_CAMPAIGN";
            int givenSendingSpeedLimitAmount = 10;
            string givenSendingSpeedLimitTimeUnitString = "HOUR";

            string expectedRequest = $@"
            {{
                ""messages"": [
                    {expectedMessage1},
                    {expectedMessage2}
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
                ""includeSmsCountInResponse"":false
            }}";

            string givenMessageIdMessage2 = "2033247207850523792";

            string expectedResponse = PreparePendingResponse(givenBulkId, givenToMessage1, givenMessageIdMessage1, givenToMessage2, givenMessageIdMessage2);
            SetUpPostRequest(SMS_SEND_TEXT_ADVANCED_ENDPOINT, expectedRequest, expectedResponse, 200);

            var smsApi = new SmsApi(configuration);

            var destination1 = new SmsDestination(messageId: givenMessageIdMessage1, to: givenToMessage1);
            var anotherDestination1 = new SmsDestination(to: givenAnotherToMessage1);

            var destination2 = new SmsDestination(to: givenToMessage2);

            var smsMessage1 = new SmsTextualMessage(
                from: givenFromMessage1,
                destinations: new List<SmsDestination> { destination1, anotherDestination1 },
                text: givenTextMessage1,
                flash: givenFlashMessage1,
                language: new SmsLanguage(givenLanguageCodeMessage1),
                transliteration: givenTransliterationMessage1,
                intermediateReport: givenIntermediateReportMessage1,
                notifyUrl: givenNotifyUrlMessage1,
                notifyContentType: givenNotifyContentTypeMessage1,
                callbackData: givenCallbackDataMessage1,
                validityPeriod: givenValidityPeriodMessage1
            );

            var smsMessage2 = new SmsTextualMessage(
                from: givenFromMessage2,
                destinations: new List<SmsDestination> { destination2 },
                text: givenTextMessage2,
                sendAt: DateTimeOffset.Parse(givenSendAtMessage2),
                deliveryTimeWindow: new SmsDeliveryTimeWindow(
                    days: new List<SmsDeliveryDay> { SmsDeliveryDay.Monday, SmsDeliveryDay.Tuesday, SmsDeliveryDay.Wednesday },
                    from: new SmsDeliveryTimeFrom(givenDeliveryTimeFromHourMessage2, givenDeliveryTimeFromMinuteMessage2),
                    to: new SmsDeliveryTimeTo(givenDeliveryTimeToHourMessage2, givenDeliveryTimeToMinuteMessage2)
                ),
                regional: new SmsRegionalOptions(
                    indiaDlt: new SmsIndiaDltOptions(givenContentTemplateIdMessage2, givenPrincipalEntityIdMessage2)
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
                    amount: givenSendingSpeedLimitAmount,
                    timeUnit: SmsSpeedLimitTimeUnit.Hour
                )
            );

            void SmsResponseAssertion(SmsResponse smsResponse)
            {
                Assert.IsNotNull(smsResponse);
                Assert.AreEqual(givenBulkId, smsResponse.BulkId);
                Assert.AreEqual(2, smsResponse.Messages.Count);

                Assert.AreEqual(givenMessageIdMessage1, smsResponse.Messages[0].MessageId);
                Assert.AreEqual(givenToMessage1, smsResponse.Messages[0].To);

                AssertPendingSmsResponse(smsResponse.Messages[0]);
            }

            try
            {
                AssertResponse(smsApi.SendSmsMessage(smsRequest), SmsResponseAssertion);
                AssertResponse(smsApi.SendSmsMessageAsync(smsRequest).Result, SmsResponseAssertion);

                AssertResponseWithHttpInfo(smsApi.SendSmsMessageWithHttpInfo(smsRequest), SmsResponseAssertion);
                AssertResponseWithHttpInfo(smsApi.SendSmsMessageWithHttpInfoAsync(smsRequest).Result, SmsResponseAssertion);
            }
            catch (Exception)
            {
                throw;
            }

        }

        [TestMethod]
        public void ShouldSendFullyFeaturedBinaryMessage()
        {
            string givenFromMessage1 = "InfoSMS";
            string givenToMessage1 = "41793026727";
            string givenMessageIdMessage1 = "MESSAGE-ID-123-xyz";
            string givenAnotherToMessage1 = "41793026834";
            string givenHexMessage1 = "54 65 73 74 20 6d 65 73 73 61 67 65 2e";
            int givenDataCodingMessage1 = 0;
            int givenEsmClassMessage1 = 0;
            bool givenIntermediateReportMessage1 = true;
            string givenNotifyUrlMessage1 = "https://www.example.com/sms/advanced";
            string givenNotifyContentTypeMessage1 = "application/json";
            string givenCallbackDataMessage1 = "DLR callback data";
            long givenValidityPeriodMessage1 = 720L;

            string expectedMessage1 = $@"
            {{
                ""destinations"": [
                    {{
                        ""to"": ""{givenToMessage1}"",
                        ""messageId"": ""{givenMessageIdMessage1}""
                    }},
                    {{
                        ""to"": ""{givenAnotherToMessage1}""
                    }}
                  ],
                ""flash"": false,
                ""from"": ""{givenFromMessage1}"",
                ""intermediateReport"": {givenIntermediateReportMessage1.ToString().ToLower()},
                ""binary"": {{
                    ""hex"": ""{givenHexMessage1}""
                  }},
                ""notifyUrl"": ""{givenNotifyUrlMessage1}"",
                ""notifyContentType"": ""{givenNotifyContentTypeMessage1}"",
                ""callbackData"": ""{givenCallbackDataMessage1}"",
                ""validityPeriod"": {givenValidityPeriodMessage1}
            }}";
            //,
            //        ""dataCoding"": { givenDataCodingMessage1},
            //        ""esmClass"": { givenEsmClassMessage1}
            string givenFromMessage2 = "41793026700";
            string givenToMessage2 = "41793026700";
            string givenHexMessage2 = "54 65 73 74 20 6d 65 73 73 61 67 65 2e";
            int givenDataCodingMessage2 = 0;
            int givenEsmClassMessage2 = 0;
            string givenSendAtMessage2 = "2021-08-25T16:10:00.000+05:00";
            int givenDeliveryTimeFromHourMessage2 = 6;
            int givenDeliveryTimeFromMinuteMessage2 = 0;
            int givenDeliveryTimeToHourMessage2 = 15;
            int givenDeliveryTimeToMinuteMessage2 = 30;
            string givenContentTemplateIdMessage2 = "contentTemplateId";
            string givenPrincipalEntityIdMessage2 = "givenPrincipalEntityId";

            string expectedMessage2 = $@"
            {{
                ""destinations"": [
                    {{
                        ""to"": ""{givenToMessage2}""
                    }}
                  ],
                ""flash"": false,
                ""from"": ""{givenFromMessage2}"",
                ""intermediateReport"": false,
                ""binary"": {{
                    ""hex"": ""{givenHexMessage2}""
                  }},                
                ""sendAt"": ""{givenSendAtMessage2}"",
                ""deliveryTimeWindow"": {{
                    ""from"": {{
                        ""hour"": {givenDeliveryTimeFromHourMessage2}
                      }},
                    ""to"": {{
                        ""hour"": {givenDeliveryTimeToHourMessage2},
                        ""minute"": {givenDeliveryTimeToMinuteMessage2}
                      }},
                    ""days"": [
                        ""MONDAY"",
                        ""TUESDAY"",
                        ""WEDNESDAY""
                      ]
                  }},
                ""regional"": {{
                    ""indiaDlt"": {{
                        ""contentTemplateId"": ""{givenContentTemplateIdMessage2}"",
                        ""principalEntityId"": ""{givenPrincipalEntityIdMessage2}""
                    }} 
                }}
            }}";

            //,
            //        ""dataCoding"": { givenDataCodingMessage2},
            //        ""esmClass"": { givenEsmClassMessage2}
            string givenBulkId = "BULK-ID-123-xyz";
            int givenSendingSpeedLimitAmount = 10;
            string givenSendingSpeedLimitTimeUnitString = "HOUR";

            string expectedRequest = $@"
            {{
                ""messages"": [
                    {expectedMessage1},
                    {expectedMessage2}
                ],
                ""bulkId"": ""{givenBulkId}"",
                ""sendingSpeedLimit"": {{
                    ""amount"": {givenSendingSpeedLimitAmount},
                    ""timeUnit"": ""{givenSendingSpeedLimitTimeUnitString}""
                }}
            }}";

            string givenMessageIdMessage2 = "2033247207850523792";

            string expectedResponse = PreparePendingResponse(givenBulkId, givenToMessage1, givenMessageIdMessage1, givenToMessage2, givenMessageIdMessage2);
            SetUpPostRequest(SMS_SEND_BINARY_ADVANCED_ENDPOINT, expectedRequest, expectedResponse, 200);

            var smsApi = new SmsApi(configuration);

            var destination1 = new SmsDestination(messageId: givenMessageIdMessage1, to: givenToMessage1);
            var anotherDestination1 = new SmsDestination(to: givenAnotherToMessage1);

            var destination2 = new SmsDestination(to: givenToMessage2);

            var smsMessage1 = new SmsBinaryMessage(
                from: givenFromMessage1,
                destinations: new List<SmsDestination> { destination1, anotherDestination1 },
                binary: new SmsBinaryContent
                (
                    hex: givenHexMessage1,
                    dataCoding: givenDataCodingMessage1,
                    esmClass: givenEsmClassMessage1
                ),
                intermediateReport: givenIntermediateReportMessage1,
                notifyUrl: givenNotifyUrlMessage1,
                notifyContentType: givenNotifyContentTypeMessage1,
                callbackData: givenCallbackDataMessage1,
                validityPeriod: givenValidityPeriodMessage1
            );

            var smsMessage2 = new SmsBinaryMessage(
                from: givenFromMessage2,
                destinations: new List<SmsDestination> { destination2 },
                binary: new SmsBinaryContent
                (
                    hex: givenHexMessage2,
                    dataCoding: givenDataCodingMessage2,
                    esmClass: givenEsmClassMessage2
                ),
                sendAt: DateTimeOffset.Parse(givenSendAtMessage2),
                deliveryTimeWindow: new SmsDeliveryTimeWindow(
                    days: new List<SmsDeliveryDay> { SmsDeliveryDay.Monday, SmsDeliveryDay.Tuesday, SmsDeliveryDay.Wednesday },
                    from: new SmsDeliveryTimeFrom(givenDeliveryTimeFromHourMessage2, givenDeliveryTimeFromMinuteMessage2),
                    to: new SmsDeliveryTimeTo(givenDeliveryTimeToHourMessage2, givenDeliveryTimeToMinuteMessage2)
                ),
                regional: new SmsRegionalOptions(
                    indiaDlt: new SmsIndiaDltOptions(givenContentTemplateIdMessage2, givenPrincipalEntityIdMessage2)
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

                Assert.AreEqual(givenMessageIdMessage1, smsResponse.Messages[0].MessageId);
                Assert.AreEqual(givenToMessage1, smsResponse.Messages[0].To);

                AssertPendingSmsResponse(smsResponse.Messages[0]);
            }

            try
            {
                AssertResponse(smsApi.SendBinarySmsMessage(smsRequest), SmsResponseAssertion);
                AssertResponse(smsApi.SendBinarySmsMessageAsync(smsRequest).Result, SmsResponseAssertion);

                AssertResponseWithHttpInfo(smsApi.SendBinarySmsMessageWithHttpInfo(smsRequest), SmsResponseAssertion);
                AssertResponseWithHttpInfo(smsApi.SendBinarySmsMessageWithHttpInfoAsync(smsRequest).Result, SmsResponseAssertion);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [TestMethod]
        public void ShouldSendFlashBinarySms()
        {
            string givenBulkId = "2034072219640523072";
            string givenTo = "41793026727";
            string givenMessageId = "2250be2d4219-3af1-78856-aabe-1362af1edfd2";

            string givenFrom = "InfoSMS";
            string givenHex = "0048 0065 006c 006c 006f 0020 0077 006f 0072 006c 0064 002c 0020 039a 03b1 03bb 03b7 03bc 03ad 03c1 03b1 0020 03ba 03cc 03c3 03bc 03b5 002c 0020 30b3 30f3 30cb 30c1 30cf";
            bool isFlash = true;

            string expectedMessage = $@"
            {{
                ""destinations"": [
                    {{
                        ""to"": ""{givenTo}""
                    }}
                  ],
                ""flash"": {isFlash.ToString().ToLower()},
                ""from"": ""{givenFrom}"",
                ""intermediateReport"": false,
                ""binary"": {{
                    ""hex"": ""{givenHex}""
                  }}
            }}";

            string expectedRequest = $@"
            {{
                ""messages"": [
                    {expectedMessage}
                ]
            }}";

            string expectedResponse = PreparePendingResponse(givenBulkId, givenTo, givenMessageId);
            SetUpPostRequest(SMS_SEND_BINARY_ADVANCED_ENDPOINT, expectedRequest, expectedResponse, 200);

            var smsApi = new SmsApi(configuration);

            var binaryMessage = new SmsBinaryMessage(
                from: givenFrom,
                destinations: new List<SmsDestination> { new SmsDestination(to: givenTo) },
                binary: new SmsBinaryContent(hex: givenHex),
                flash: isFlash
            );

            var smsRequest = new SmsAdvancedBinaryRequest
            (
                 messages: new List<SmsBinaryMessage> { binaryMessage }
            );

            void SmsResponseAssertion(SmsResponse smsResponse)
            {
                Assert.IsNotNull(smsResponse);
                Assert.AreEqual(givenBulkId, smsResponse.BulkId);
                Assert.AreEqual(1, smsResponse.Messages.Count);

                Assert.AreEqual(givenMessageId, smsResponse.Messages[0].MessageId);
                Assert.AreEqual(givenTo, smsResponse.Messages[0].To);

                AssertPendingSmsResponse(smsResponse.Messages[0]);
            }

            try
            {
                AssertResponse(smsApi.SendBinarySmsMessage(smsRequest), SmsResponseAssertion);
                AssertResponse(smsApi.SendBinarySmsMessageAsync(smsRequest).Result, SmsResponseAssertion);

                AssertResponseWithHttpInfo(smsApi.SendBinarySmsMessageWithHttpInfo(smsRequest), SmsResponseAssertion);
                AssertResponseWithHttpInfo(smsApi.SendBinarySmsMessageWithHttpInfoAsync(smsRequest).Result, SmsResponseAssertion);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [TestMethod]
        public void ShouldGetSmsLogs()
        {
            string givenBulkId = "BULK-ID-123-xyz";
            string givenMessageIdMessage1 = "MESSAGE-ID-123-xyz";
            string givenToMessage1 = "41793026727";
            string givenSendAtMessage1 = "2019-11-09T16:00:00.000+0530";
            string givenDoneAtMessage1 = "2019-11-09T16:00:00.000+0530";
            int givenSmsCountMessage1 = 1;
            string givenPricePerMessageMessage1 = "0.01";
            string givenCurrencyMessage1 = "EUR";

            string givenMessageIdMessage2 = "12db39c3-7822-4e72-a3ec-c87442c0ffc5";
            string givenToMessage2 = "41793026834";
            string givenSendAtMessage2 = "2019-11-09T17:00:00.000+0000";
            string givenDoneAtMessage2 = "2019-11-09T17:00:00.000+0000";
            int givenSmsCountMessage2 = 5;
            string givenPricePerMessageMessage2 = "0.05";
            string givenCurrencyMessage2 = "HRK";

            string givenResponse = $@"
            {{
                ""results"": [
                  {{
                     ""bulkId"": ""{givenBulkId}"",
                     ""messageId"": ""{givenMessageIdMessage1}"",
                     ""to"": ""{givenToMessage1}"",
                     ""sentAt"": ""{givenSendAtMessage1}"",
                     ""doneAt"": ""{givenDoneAtMessage1}"",
                     ""smsCount"": {givenSmsCountMessage1},
                     ""price"":
                     {{
                        ""pricePerMessage"": {givenPricePerMessageMessage1},
                        ""currency"": ""{givenCurrencyMessage1}""
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
                    ""bulkId"": ""{givenBulkId}"",
                     ""messageId"": ""{givenMessageIdMessage2}"",
                     ""to"": ""{givenToMessage2}"",
                     ""sentAt"": ""{givenSendAtMessage2}"",
                     ""doneAt"": ""{givenDoneAtMessage2}"",
                     ""smsCount"": {givenSmsCountMessage2},
                     ""price"":
                     {{
                        ""pricePerMessage"": {givenPricePerMessageMessage2},
                        ""currency"": ""{givenCurrencyMessage2}""
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

            string givenSentSinceString = "2015-02-22T17:42:05.390+0100";
            var searchParams = new Dictionary<string, string>
            {
                { "bulkId", givenBulkId },
                { "sentSince", givenSentSinceString }
            };

            SetUpGetRequest(SMS_LOGS_ENDPOINT, searchParams, givenResponse, 200);

            void LogsResponseAssertion(SmsLogsResponse logsResponse)
            {
                Assert.IsNotNull(logsResponse);
                List<SmsLog> results = logsResponse.Results;
                Assert.IsNotNull(results);
                Assert.AreEqual(2, results.Count);

                Assert.AreEqual(givenBulkId, results[0].BulkId);
                Assert.AreEqual(givenMessageIdMessage1, results[0].MessageId);
                Assert.AreEqual(givenToMessage1, results[0].To);
                Assert.AreEqual(DateTimeOffset.Parse(givenSendAtMessage1), results[0].SentAt);
                Assert.AreEqual(DateTimeOffset.Parse(givenDoneAtMessage1), results[0].DoneAt);
                Assert.IsNull(results[0].From);
                Assert.IsNull(results[0].Text);
                Assert.IsNull(results[0].MccMnc);
                Assert.AreEqual(decimal.Parse(givenPricePerMessageMessage1, System.Globalization.CultureInfo.InvariantCulture), results[0].Price.PricePerMessage);
                Assert.AreEqual(givenCurrencyMessage1, results[0].Price.Currency);
                AssertDeliveredSmsStatus(results[0].Status);
                AssertNoError(results[0].Error);

                Assert.AreEqual(givenBulkId, results[1].BulkId);
                Assert.AreEqual(givenMessageIdMessage2, results[1].MessageId);
                Assert.AreEqual(givenToMessage2, results[1].To);
                Assert.AreEqual(DateTimeOffset.Parse(givenSendAtMessage2), results[1].SentAt);
                Assert.AreEqual(DateTimeOffset.Parse(givenDoneAtMessage2), results[1].DoneAt);
                Assert.IsNull(results[1].From);
                Assert.IsNull(results[1].Text);
                Assert.IsNull(results[1].MccMnc);
                Assert.AreEqual(decimal.Parse(givenPricePerMessageMessage2, System.Globalization.CultureInfo.InvariantCulture), results[1].Price.PricePerMessage);
                Assert.AreEqual(givenCurrencyMessage2, results[1].Price.Currency);
                AssertDeliveredSmsStatus(results[1].Status);
                AssertNoError(results[1].Error);
            }
            SmsApi smsApi = new SmsApi(configuration);

            AssertResponse
            (
                smsApi.GetOutboundSmsMessageLogs
                (
                    sentSince: DateTimeOffset.Parse(givenSentSinceString),
                    bulkId: new List<string> { givenBulkId }
                ),
                LogsResponseAssertion
            );
            AssertResponse
            (
                smsApi.GetOutboundSmsMessageLogsAsync
                (
                    sentSince: DateTimeOffset.Parse(givenSentSinceString),
                    bulkId: new List<string> { givenBulkId }
                ).Result,
                LogsResponseAssertion
            );
            AssertResponseWithHttpInfo
            (
                smsApi.GetOutboundSmsMessageLogsWithHttpInfo
                (
                    sentSince: DateTimeOffset.Parse(givenSentSinceString),
                    bulkId: new List<string> { givenBulkId }
                ),
                LogsResponseAssertion
            );
            AssertResponseWithHttpInfo
            (
                smsApi.GetOutboundSmsMessageLogsWithHttpInfoAsync
                (
                    sentSince: DateTimeOffset.Parse(givenSentSinceString),
                    bulkId: new List<string> { givenBulkId }
                ).Result,
                LogsResponseAssertion
            );

        }

        [TestMethod]
        public void ShouldGetSmsReports()
        {
            string givenBulkId = "BULK-ID-123-xyz";
            string givenMessageId1 = "MESSAGE-ID-123-xyz";
            string givenTo1 = "41793026727";
            string givenSentAt1 = "2019-11-09T16:00:00.000+0000";
            string givenDoneAt1 = "2019-11-09T16:00:00.000+0000";
            int givenSmsCount = 1;
            string givenPricePerMessage = "0.01";
            string givenCurrency = "EUR";
            string givenEntityId = "promotional-traffic-entity";
            string givenApplicationId1 = "marketing-automation-application";

            string givenMessageId2 = "12db39c3-7822-4e72-a3ec-c87442c0ffc5";
            string givenTo2 = "41793026834";
            string givenSentAt2 = "2019-11-09T17:00:00.000+0000";
            string givenDoneAt2 = "2019-11-09T17:00:00.000+0000";
            string givenApplicationId2 = "default";

            int givenLimit = 100;

            string givenResponse = $@"
            {{
                ""results"": [
                    {{
                        ""bulkId"": ""{givenBulkId}"",
                        ""messageId"": ""{givenMessageId1}"",
                        ""to"": ""{givenTo1}"",
                        ""sentAt"": ""{givenSentAt1}"",
                        ""doneAt"": ""{givenDoneAt1}"",
                        ""smsCount"": {givenSmsCount},
                        ""price"": {{
                            ""pricePerMessage"": {givenPricePerMessage},
                            ""currency"": ""{givenCurrency}""
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
                        ""entityId"": ""{givenEntityId}"",
                        ""applicationId"": ""{givenApplicationId1}""
                    }},
                    {{
                        ""bulkId"": ""{givenBulkId}"",
                        ""messageId"": ""{givenMessageId2}"",
                        ""to"": ""{givenTo2}"",
                        ""sentAt"": ""{givenSentAt2}"",
                        ""doneAt"": ""{givenDoneAt2}"",
                        ""smsCount"": {givenSmsCount},
                        ""price"": {{
                            ""pricePerMessage"": {givenPricePerMessage},
                            ""currency"": ""{givenCurrency}""
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
                        ""applicationId"": ""{givenApplicationId2}""
                    }}
                ]
            }}";

            var expectedQueryParameters = new Dictionary<string, string> {
                { "bulkId", givenBulkId},
                { "limit", givenLimit.ToString()}
            };

            SetUpGetRequest(SMS_REPORTS_ENDPOINT, expectedQueryParameters, givenResponse, 200);

            var smsApi = new SmsApi(configuration);

            void AssertSmsDeliveryResult(SmsDeliveryResult smsDeliveryResult)
            {
                Assert.IsNotNull(smsDeliveryResult);

                Assert.IsNotNull(smsDeliveryResult.Results[0]);
                Assert.AreEqual(smsDeliveryResult.Results[0].BulkId, givenBulkId);
                Assert.AreEqual(smsDeliveryResult.Results[0].MessageId, givenMessageId1);
                Assert.AreEqual(smsDeliveryResult.Results[0].To, givenTo1);
                Assert.AreEqual(smsDeliveryResult.Results[0].SentAt, DateTimeOffset.Parse(givenSentAt1));
                Assert.AreEqual(smsDeliveryResult.Results[0].DoneAt, DateTimeOffset.Parse(givenDoneAt1));
                Assert.AreEqual(smsDeliveryResult.Results[0].SmsCount, givenSmsCount);
                Assert.AreEqual(smsDeliveryResult.Results[0].Price.PricePerMessage, decimal.Parse(givenPricePerMessage, System.Globalization.CultureInfo.InvariantCulture));
                Assert.AreEqual(smsDeliveryResult.Results[0].Price.Currency, givenCurrency);
                Assert.AreEqual(smsDeliveryResult.Results[0].Status.GroupId, DELIVERED_STATUS_GROUP_ID);
                Assert.AreEqual(smsDeliveryResult.Results[0].Status.GroupName, DELIVERED_STATUS_GROUP_NAME);
                Assert.AreEqual(smsDeliveryResult.Results[0].Status.Id, DELIVERED_STATUS_ID);
                Assert.AreEqual(smsDeliveryResult.Results[0].Status.Name, DELIVERED_STATUS_NAME);
                Assert.AreEqual(smsDeliveryResult.Results[0].Status.Description, DELIVERED_STATUS_DESCRIPTION);
                Assert.AreEqual(smsDeliveryResult.Results[0].Error.GroupId, NO_ERROR_GROUP_ID);
                Assert.AreEqual(smsDeliveryResult.Results[0].Error.GroupName, NO_ERROR_GROUP_NAME);
                Assert.AreEqual(smsDeliveryResult.Results[0].Error.Id, NO_ERROR_ID);
                Assert.AreEqual(smsDeliveryResult.Results[0].Error.Name, NO_ERROR_NAME);
                Assert.AreEqual(smsDeliveryResult.Results[0].Error.Description, NO_ERROR_DESCRIPTION);
                Assert.AreEqual(smsDeliveryResult.Results[0].Error.Permanent, NO_ERROR_IS_PERMANENT);
                Assert.AreEqual(smsDeliveryResult.Results[0].EntityId, givenEntityId);
                Assert.AreEqual(smsDeliveryResult.Results[0].ApplicationId, givenApplicationId1);

                Assert.IsNotNull(smsDeliveryResult.Results[1]);
                Assert.AreEqual(smsDeliveryResult.Results[1].BulkId, givenBulkId);
                Assert.AreEqual(smsDeliveryResult.Results[1].MessageId, givenMessageId2);
                Assert.AreEqual(smsDeliveryResult.Results[1].To, givenTo2);
                Assert.AreEqual(smsDeliveryResult.Results[1].SentAt, DateTimeOffset.Parse(givenSentAt2));
                Assert.AreEqual(smsDeliveryResult.Results[1].DoneAt, DateTimeOffset.Parse(givenDoneAt2));
                Assert.AreEqual(smsDeliveryResult.Results[1].SmsCount, givenSmsCount);
                Assert.AreEqual(smsDeliveryResult.Results[1].Price.PricePerMessage, decimal.Parse(givenPricePerMessage, System.Globalization.CultureInfo.InvariantCulture));
                Assert.AreEqual(smsDeliveryResult.Results[1].Price.Currency, givenCurrency);
                Assert.AreEqual(smsDeliveryResult.Results[1].Status.GroupId, DELIVERED_STATUS_GROUP_ID);
                Assert.AreEqual(smsDeliveryResult.Results[1].Status.GroupName, DELIVERED_STATUS_GROUP_NAME);
                Assert.AreEqual(smsDeliveryResult.Results[1].Status.Id, DELIVERED_STATUS_ID);
                Assert.AreEqual(smsDeliveryResult.Results[1].Status.Name, DELIVERED_STATUS_NAME);
                Assert.AreEqual(smsDeliveryResult.Results[1].Status.Description, DELIVERED_STATUS_DESCRIPTION);
                Assert.AreEqual(smsDeliveryResult.Results[1].Error.GroupId, NO_ERROR_GROUP_ID);
                Assert.AreEqual(smsDeliveryResult.Results[1].Error.GroupName, NO_ERROR_GROUP_NAME);
                Assert.AreEqual(smsDeliveryResult.Results[1].Error.Id, NO_ERROR_ID);
                Assert.AreEqual(smsDeliveryResult.Results[1].Error.Name, NO_ERROR_NAME);
                Assert.AreEqual(smsDeliveryResult.Results[1].Error.Description, NO_ERROR_DESCRIPTION);
                Assert.AreEqual(smsDeliveryResult.Results[1].Error.Permanent, NO_ERROR_IS_PERMANENT);
                Assert.AreEqual(smsDeliveryResult.Results[1].ApplicationId, givenApplicationId2);
            }

            AssertResponse(smsApi.GetOutboundSmsMessageDeliveryReports(bulkId: givenBulkId, limit: givenLimit), AssertSmsDeliveryResult);
            AssertResponse(smsApi.GetOutboundSmsMessageDeliveryReportsAsync(bulkId: givenBulkId, limit: givenLimit).Result, AssertSmsDeliveryResult);

            AssertResponseWithHttpInfo(smsApi.GetOutboundSmsMessageDeliveryReportsWithHttpInfo(bulkId: givenBulkId, limit: givenLimit), AssertSmsDeliveryResult);
            AssertResponseWithHttpInfo(smsApi.GetOutboundSmsMessageDeliveryReportsWithHttpInfoAsync(bulkId: givenBulkId, limit: givenLimit).Result, AssertSmsDeliveryResult);
        }

        [TestMethod]
        public void ShouldGetReceivedSmsMessages()
        {
            String givenMessageId = "817790313235066447";
            String givenFrom = "385916242493";
            String givenTo = "385921004026";
            String givenText = "QUIZ Correct answer is Paris";
            String givenCleanText = "Correct answer is Paris";
            String givenKeyword = "QUIZ";
            String givenReceivedAt = "2021-08-25T16:10:00.000+0500";
            int givenSmsCount = 1;
            decimal givenPricePerMessage = 0;
            String givenCurrency = "EUR";
            String givenCallbackData = "callbackData";
            int givenMessageCount = 1;
            int givenPendingMessageCount = 0;

            string givenResponse = $@"
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

            int givenLimit = 2;
            SetUpGetRequest(SMS_INBOX_REPORTS_ENDPOINT, new Dictionary<string, string> { { "limit", givenLimit.ToString() } }, givenResponse, 200);

            void ResultAssertions(SmsInboundMessageResult smsInboundResult)
            {
                Assert.IsNotNull(smsInboundResult);
                Assert.AreEqual(givenMessageCount, smsInboundResult.MessageCount);
                Assert.AreEqual(givenPendingMessageCount, smsInboundResult.PendingMessageCount);

                Assert.AreEqual(1, smsInboundResult.Results.Count);
                SmsInboundMessage message = smsInboundResult.Results[0];
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

            SmsApi receiveApi = new SmsApi(configuration);

            AssertResponse(receiveApi.GetInboundSmsMessages(givenLimit), ResultAssertions);
            AssertResponse(receiveApi.GetInboundSmsMessagesAsync(givenLimit).Result, ResultAssertions);

            AssertResponseWithHttpInfo(receiveApi.GetInboundSmsMessagesWithHttpInfo(givenLimit), ResultAssertions);
            AssertResponseWithHttpInfo(receiveApi.GetInboundSmsMessagesWithHttpInfoAsync(givenLimit).Result, ResultAssertions);
        }

        [TestMethod]
        public void ShouldSendSmsPreview()
        {
            string expectedPreviewText = "Let's see how many characters will remain unused in this message.";

            string expectedRequest = $@"
            {{
                ""text"": ""{expectedPreviewText}""
                
            }}";

            string givenOriginalText = "Let's see how many characters will remain unused in this message.";
            string givenTextPreview = "Let's see how many characters will remain unused in this message.";
            int givenMessageCount = 1;
            int givenCharactersRemaining = 95;

            string givenResponse = $@"
            {{
                ""originalText"": ""{givenOriginalText}"",
                ""previews"": [
                    {{
                        ""textPreview"": ""{givenTextPreview}"",
                        ""messageCount"": ""{givenMessageCount}"",
                        ""charactersRemaining"": {givenCharactersRemaining},
                        ""configuration"": {{ }}
                    }}
                ]
            }}";

            SetUpPostRequest(SMS_SEND_PREVIEW_ENDPOINT, expectedRequest, givenResponse, 200);

            void SmsPreviewAssertions(SmsPreviewResponse response)
            {
                Assert.IsNotNull(response);
                Assert.AreEqual(givenOriginalText, response.OriginalText);
                Assert.AreEqual(1, response.Previews.Count);
                SmsPreview preview = response.Previews[0];
                Assert.AreEqual(givenTextPreview, preview.TextPreview);
                Assert.AreEqual(givenMessageCount, preview.MessageCount);
                Assert.AreEqual(givenCharactersRemaining, preview.CharactersRemaining);
                Assert.AreEqual(givenOriginalText, response.OriginalText);
                SmsLanguageConfiguration smsLanguage = preview.VarConfiguration;
                Assert.IsNotNull(smsLanguage);
                Assert.IsNull(smsLanguage.Language);
                Assert.IsNull(smsLanguage.Transliteration);
            }

            SmsApi sendSmsApi = new SmsApi(configuration);
            SmsPreviewRequest request = new SmsPreviewRequest(text: givenTextPreview);

            AssertResponse(sendSmsApi.PreviewSmsMessage(request), SmsPreviewAssertions);
            AssertResponse(sendSmsApi.PreviewSmsMessageAsync(request).Result, SmsPreviewAssertions);
            AssertResponseWithHttpInfo(sendSmsApi.PreviewSmsMessageWithHttpInfo(request), SmsPreviewAssertions);
            AssertResponseWithHttpInfo(sendSmsApi.PreviewSmsMessageWithHttpInfoAsync(request).Result, SmsPreviewAssertions);
        }

        [TestMethod]
        public void ShouldGetScheduledSmsMessages()
        {
            string givenResponse = $@"
            {{
                ""bulkId"": ""{GIVEN_BULK_ID}"",
                ""sendAt"": ""{GIVEN_SEND_AT}""
            }}";

            SetUpGetRequest(SMS_BULKS_ENDPOINT, new Dictionary<string, string> { { "bulkId", GIVEN_BULK_ID } }, givenResponse, 200);

            void BulkResponseAssertions(SmsBulkResponse response)
            {
                Assert.IsNotNull(response);
                Assert.AreEqual(GIVEN_BULK_ID, response.BulkId);
                Assert.AreEqual(DateTimeOffset.Parse(GIVEN_SEND_AT), response.SendAt);
            }

            SmsApi scheduledSmsApi = new SmsApi(configuration);

            AssertResponse(scheduledSmsApi.GetScheduledSmsMessages(GIVEN_BULK_ID), BulkResponseAssertions);
            AssertResponse(scheduledSmsApi.GetScheduledSmsMessagesAsync(GIVEN_BULK_ID).Result, BulkResponseAssertions);
            AssertResponseWithHttpInfo(scheduledSmsApi.GetScheduledSmsMessagesWithHttpInfo(GIVEN_BULK_ID), BulkResponseAssertions);
            AssertResponseWithHttpInfo(scheduledSmsApi.GetScheduledSmsMessagesWithHttpInfoAsync(GIVEN_BULK_ID).Result, BulkResponseAssertions);
        }

        [TestMethod]
        public void ShouldRescheduleSmsMessages()
        {
            string expectedRequest = $@"
            {{
                ""sendAt"": ""{GIVEN_SEND_AT_WITH_COLON}""
                
            }}";

            string givenResponse = $@"
            {{
                ""bulkId"": ""{GIVEN_BULK_ID}"",
                ""sendAt"": ""{GIVEN_SEND_AT}""
            }}";

            SetUpPutRequest(SMS_BULKS_ENDPOINT, new Dictionary<string, string> { { "bulkId", GIVEN_BULK_ID } }, expectedRequest, givenResponse, 200);

            void BulkResponseAssertions(SmsBulkResponse response)
            {
                Assert.IsNotNull(response);
                Assert.AreEqual(GIVEN_BULK_ID, response.BulkId);
                Assert.AreEqual(DateTimeOffset.Parse(GIVEN_SEND_AT), response.SendAt);
            }

            SmsApi scheduledSmsApi = new SmsApi(configuration);
            SmsBulkRequest bulkRequest = new SmsBulkRequest(sendAt: DateTimeOffset.Parse(GIVEN_SEND_AT_WITH_COLON));

            AssertResponse(scheduledSmsApi.RescheduleSmsMessages(GIVEN_BULK_ID, bulkRequest), BulkResponseAssertions);
            AssertResponse(scheduledSmsApi.RescheduleSmsMessagesAsync(GIVEN_BULK_ID, bulkRequest).Result, BulkResponseAssertions);
            AssertResponseWithHttpInfo(scheduledSmsApi.RescheduleSmsMessagesWithHttpInfo(GIVEN_BULK_ID, bulkRequest), BulkResponseAssertions);
            AssertResponseWithHttpInfo(scheduledSmsApi.RescheduleSmsMessagesWithHttpInfoAsync(GIVEN_BULK_ID, bulkRequest).Result, BulkResponseAssertions);
        }

        [TestMethod]
        public void ShouldGetScheduledSmsMessagesStatus()
        {
            string givenResponse = $@"
            {{
                ""bulkId"": ""{GIVEN_BULK_ID}"",
                ""status"": ""{GIVEN_BULK_STATUS_STRING}""
            }}";

            SetUpGetRequest(SMS_BULKS_STATUS_ENDPOINT, new Dictionary<string, string> { { "bulkId", GIVEN_BULK_ID } }, givenResponse, 200);

            void BulkResponseAssertions(SmsBulkStatusResponse response)
            {
                Assert.IsNotNull(response);
                Assert.AreEqual(GIVEN_BULK_ID, response.BulkId);
                Assert.AreEqual(GIVEN_BULK_STATUS, response.Status);
            }

            SmsApi scheduledSmsApi = new SmsApi(configuration);

            AssertResponse(scheduledSmsApi.GetScheduledSmsMessagesStatus(GIVEN_BULK_ID), BulkResponseAssertions);
            AssertResponse(scheduledSmsApi.GetScheduledSmsMessagesStatusAsync(GIVEN_BULK_ID).Result, BulkResponseAssertions);
            AssertResponseWithHttpInfo(scheduledSmsApi.GetScheduledSmsMessagesStatusWithHttpInfo(GIVEN_BULK_ID), BulkResponseAssertions);
            AssertResponseWithHttpInfo(scheduledSmsApi.GetScheduledSmsMessagesStatusWithHttpInfoAsync(GIVEN_BULK_ID).Result, BulkResponseAssertions);

        }


        [TestMethod]
        public void ShouldUpdateScheduledSmsMessagesStatus()
        {
            string expectedRequest = $@"
            {{
                ""status"": ""{GIVEN_BULK_STATUS_STRING}""
                
            }}";

            string givenResponse = $@"
            {{
                ""bulkId"": ""{GIVEN_BULK_ID}"",
                ""status"": ""{GIVEN_BULK_STATUS_STRING}""
            }}";

            SetUpPutRequest(SMS_BULKS_STATUS_ENDPOINT, new Dictionary<string, string> { { "bulkId", GIVEN_BULK_ID } }, expectedRequest, givenResponse, 200);

            void BulkResponseAssertions(SmsBulkStatusResponse response)
            {
                Assert.IsNotNull(response);
                Assert.AreEqual(GIVEN_BULK_ID, response.BulkId);
                Assert.AreEqual(GIVEN_BULK_STATUS, response.Status);
            }

            SmsApi scheduledSmsApi = new SmsApi(configuration);
            var updateStatusRequest = new SmsUpdateStatusRequest(SmsBulkStatus.Paused);

            AssertResponse(scheduledSmsApi.UpdateScheduledSmsMessagesStatus(GIVEN_BULK_ID, updateStatusRequest), BulkResponseAssertions);
            AssertResponse(scheduledSmsApi.UpdateScheduledSmsMessagesStatusAsync(GIVEN_BULK_ID, updateStatusRequest).Result, BulkResponseAssertions);
            AssertResponseWithHttpInfo(scheduledSmsApi.UpdateScheduledSmsMessagesStatusWithHttpInfo(GIVEN_BULK_ID, updateStatusRequest), BulkResponseAssertions);
            AssertResponseWithHttpInfo(scheduledSmsApi.UpdateScheduledSmsMessagesStatusWithHttpInfoAsync(GIVEN_BULK_ID, updateStatusRequest).Result, BulkResponseAssertions);

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

        private string PreparePendingResponse(string givenBulkId, string givenDestination1, string givenMessageId1, string givenDestination2, string givenMessageId2)
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
}
