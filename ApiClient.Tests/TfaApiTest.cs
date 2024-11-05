using Infobip.Api.Client.Api;
using Infobip.Api.Client.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace ApiClient.Tests
{
    [TestClass]
    public class TfaApiTest : ApiTest
    {
        protected const string TFA_APPLICATIONS = "/2fa/2/applications";
        protected const string TFA_APPLICATION = "/2fa/2/applications/{appId}";
        protected const string TFA_TEMPLATES = "/2fa/2/applications/{appId}/messages";
        protected const string TFA_TEMPLATE = "/2fa/2/applications/{appId}/messages/{msgId}";
        protected const string TFA_EMAIL_TEMPLATES = "/2fa/2/applications/{appId}/email/messages";
        protected const string TFA_EMAIL_TEMPLATE = "/2fa/2/applications/{appId}/email/messages/{msgId}";

        protected const string TFA_SEND_PIN = "/2fa/2/pin";
        protected const string TFA_RESEND_PIN = "/2fa/2/pin/{pinId}/resend";
        protected const string TFA_SEND_PIN_VOICE = "/2fa/2/pin/voice";
        protected const string TFA_RESEND_PIN_VOICE = "/2fa/2/pin/{pinId}/resend/voice";
        protected const string TFA_SEND_PIN_EMAIL = "/2fa/2/pin/email";
        protected const string TFA_RESEND_PIN_EMAIL = "/2fa/2/pin/{pinId}/resend/email";
        protected const string TFA_VERIFY_PIN = "/2fa/2/pin/{pinId}/verify";
        protected const string TFA_VERIFICATION_STATUS = "/2fa/2/applications/{appId}/verifications";

        [TestMethod]
        public void ShouldGetTfaApplicationsTest()
        {
            string expectedApplicationId1 = "0933F3BC087D2A617AC6DCB2EF5B8A61";
            string expectedGetApplicationName1 = "Test application BASIC 1";
            int expectedGetApplicationPinAttempts1 = 10;
            string expectedAllowMultiplePinVerifications1 = "true";
            string expectedGetApplicationPinTimeToLive1 = "2h";
            string expectedGetApplicationVerifyPinLimit1 = "1/3s";
            string expectedGetApplicationSendPinPerApplicationLimit1 = "10000/1d";
            string expectedGetApplicationSendPinPerPhoneNumberLimit1 = "3/1d";
            string expectedEnabled1 = "true";

            string expectedApplicationId2 = "5F04FACFAA4978F62FCAEBA97B37E90F";
            string expectedGetApplicationName2 = "Test application BASIC 2";
            int expectedGetApplicationPinAttempts2 = 12;
            string expectedAllowMultiplePinVerifications2 = "true";
            string expectedGetApplicationPinTimeToLive2 = "10m";
            string expectedGetApplicationVerifyPinLimit2 = "2/1s";
            string expectedGetApplicationSendPinPerApplicationLimit2 = "10000/1d";
            string expectedGetApplicationSendPinPerPhoneNumberLimit2 = "5/1h";
            string expectedEnabled2 = "true";

            string expectedApplicationId3 = "B450F966A8EF017180F148AF22C42642";
            string expectedGetApplicationName3 = "Test application BASIC 3";
            int expectedGetApplicationPinAttempts3 = 15;
            string expectedAllowMultiplePinVerifications3 = "true";
            string expectedGetApplicationPinTimeToLive3 = "1h";
            string expectedGetApplicationVerifyPinLimit3 = "30/10s";
            string expectedGetApplicationSendPinPerApplicationLimit3 = "10000/3d";
            string expectedGetApplicationSendPinPerPhoneNumberLimit3 = "10/20m";
            string expectedEnabled3 = "true";

            string expectedResponse = $@"
            [
                {{
                    ""applicationId"": ""{expectedApplicationId1}"",
                    ""name"": ""{expectedGetApplicationName1}"",
                    ""configuration"": {{
                        ""pinAttempts"": {expectedGetApplicationPinAttempts1},
                        ""allowMultiplePinVerifications"": {expectedAllowMultiplePinVerifications1},
                        ""pinTimeToLive"": ""{expectedGetApplicationPinTimeToLive1}"",
                        ""verifyPinLimit"": ""{expectedGetApplicationVerifyPinLimit1}"",
                        ""sendPinPerApplicationLimit"": ""{expectedGetApplicationSendPinPerApplicationLimit1}"",
                        ""sendPinPerPhoneNumberLimit"": ""{expectedGetApplicationSendPinPerPhoneNumberLimit1}""
                    }},
                    ""enabled"": {expectedEnabled1}
                }},
                {{
                    ""applicationId"": ""{expectedApplicationId2}"",
                    ""name"": ""{expectedGetApplicationName2}"",
                    ""configuration"": {{
                        ""pinAttempts"": {expectedGetApplicationPinAttempts2},
                        ""allowMultiplePinVerifications"": {expectedAllowMultiplePinVerifications2},
                        ""pinTimeToLive"": ""{expectedGetApplicationPinTimeToLive2}"",
                        ""verifyPinLimit"": ""{expectedGetApplicationVerifyPinLimit2}"",
                        ""sendPinPerApplicationLimit"": ""{expectedGetApplicationSendPinPerApplicationLimit2}"",
                        ""sendPinPerPhoneNumberLimit"": ""{expectedGetApplicationSendPinPerPhoneNumberLimit2}""
                    }},
                    ""enabled"": {expectedEnabled2}
                }},
                {{
                    ""applicationId"": ""{expectedApplicationId3}"",
                    ""name"": ""{expectedGetApplicationName3}"",
                    ""configuration"": {{
                        ""pinAttempts"": {expectedGetApplicationPinAttempts3},
                        ""allowMultiplePinVerifications"": {expectedAllowMultiplePinVerifications3},
                        ""pinTimeToLive"": ""{expectedGetApplicationPinTimeToLive3}"",
                        ""verifyPinLimit"": ""{expectedGetApplicationVerifyPinLimit3}"",
                        ""sendPinPerApplicationLimit"": ""{expectedGetApplicationSendPinPerApplicationLimit3}"",
                        ""sendPinPerPhoneNumberLimit"": ""{expectedGetApplicationSendPinPerPhoneNumberLimit3}""
                    }},
                    ""enabled"": {expectedEnabled3}
                }}
            ]";

            SetUpGetRequest(TFA_APPLICATIONS, expectedResponse, 200);

            var tfaApi = new TfaApi(configuration);

            void AssertTfaGetApplicationsResponse(List<TfaApplicationResponse> tfaApplicationResponses)
            {
                Assert.IsNotNull(tfaApplicationResponses);
                Assert.IsTrue(tfaApplicationResponses.Count.Equals(3));

                var tfaApplicationResponse1 = tfaApplicationResponses[0];
                Assert.IsNotNull(tfaApplicationResponse1);
                Assert.AreEqual(expectedApplicationId1, tfaApplicationResponse1.ApplicationId);
                Assert.AreEqual(expectedGetApplicationName1, tfaApplicationResponse1.Name);
                Assert.AreEqual(expectedGetApplicationPinAttempts1, tfaApplicationResponse1.VarConfiguration.PinAttempts);
                Assert.AreEqual(bool.Parse(expectedAllowMultiplePinVerifications1), tfaApplicationResponse1.VarConfiguration.AllowMultiplePinVerifications);
                Assert.AreEqual(expectedGetApplicationPinTimeToLive1, tfaApplicationResponse1.VarConfiguration.PinTimeToLive);
                Assert.AreEqual(expectedGetApplicationVerifyPinLimit1, tfaApplicationResponse1.VarConfiguration.VerifyPinLimit);
                Assert.AreEqual(expectedGetApplicationSendPinPerApplicationLimit1, tfaApplicationResponse1.VarConfiguration.SendPinPerApplicationLimit);
                Assert.AreEqual(expectedGetApplicationSendPinPerPhoneNumberLimit1, tfaApplicationResponse1.VarConfiguration.SendPinPerPhoneNumberLimit);

                var tfaApplicationResponse2 = tfaApplicationResponses[1];
                Assert.IsNotNull(tfaApplicationResponse2);
                Assert.AreEqual(expectedApplicationId2, tfaApplicationResponse2.ApplicationId);
                Assert.AreEqual(expectedGetApplicationName2, tfaApplicationResponse2.Name);
                Assert.AreEqual(expectedGetApplicationPinAttempts2, tfaApplicationResponse2.VarConfiguration.PinAttempts);
                Assert.AreEqual(bool.Parse(expectedAllowMultiplePinVerifications2), tfaApplicationResponse2.VarConfiguration.AllowMultiplePinVerifications);
                Assert.AreEqual(expectedGetApplicationPinTimeToLive2, tfaApplicationResponse2.VarConfiguration.PinTimeToLive);
                Assert.AreEqual(expectedGetApplicationVerifyPinLimit2, tfaApplicationResponse2.VarConfiguration.VerifyPinLimit);
                Assert.AreEqual(expectedGetApplicationSendPinPerApplicationLimit2, tfaApplicationResponse2.VarConfiguration.SendPinPerApplicationLimit);
                Assert.AreEqual(expectedGetApplicationSendPinPerPhoneNumberLimit2, tfaApplicationResponse2.VarConfiguration.SendPinPerPhoneNumberLimit);

                var tfaApplicationResponse3 = tfaApplicationResponses[2];
                Assert.IsNotNull(tfaApplicationResponse3);
                Assert.AreEqual(expectedApplicationId3, tfaApplicationResponse3.ApplicationId);
                Assert.AreEqual(expectedGetApplicationName3, tfaApplicationResponse3.Name);
                Assert.AreEqual(expectedGetApplicationPinAttempts3, tfaApplicationResponse3.VarConfiguration.PinAttempts);
                Assert.AreEqual(bool.Parse(expectedAllowMultiplePinVerifications3), tfaApplicationResponse3.VarConfiguration.AllowMultiplePinVerifications);
                Assert.AreEqual(expectedGetApplicationPinTimeToLive3, tfaApplicationResponse3.VarConfiguration.PinTimeToLive);
                Assert.AreEqual(expectedGetApplicationVerifyPinLimit3, tfaApplicationResponse3.VarConfiguration.VerifyPinLimit);
                Assert.AreEqual(expectedGetApplicationSendPinPerApplicationLimit3, tfaApplicationResponse3.VarConfiguration.SendPinPerApplicationLimit);
                Assert.AreEqual(expectedGetApplicationSendPinPerPhoneNumberLimit3, tfaApplicationResponse3.VarConfiguration.SendPinPerPhoneNumberLimit);
            }

            AssertResponse(tfaApi.GetTfaApplications(), AssertTfaGetApplicationsResponse);
            AssertResponse(tfaApi.GetTfaApplicationsAsync().Result, AssertTfaGetApplicationsResponse);

            AssertResponseWithHttpInfo(tfaApi.GetTfaApplicationsWithHttpInfo(), AssertTfaGetApplicationsResponse);
            AssertResponseWithHttpInfo(tfaApi.GetTfaApplicationsWithHttpInfoAsync().Result, AssertTfaGetApplicationsResponse);
        }

        [TestMethod]
        public void ShouldCreateTfaApplicationTest()
        {
            string expectedApplicationId = "1234567";
            string expectedCreateApplicationName = "2fa application name";
            int expectedCreateApplicationPinAttempts = 5;
            string expectedAllowMultiplePinVerifications = "true";
            string expectedCreateApplicationPinTimeToLive = "10m";
            string expectedCreateApplicationVerifyPinLimit = "2/4s";
            string expectedCreateApplicationSendPinPerApplicationLimit = "5000/12h";
            string expectedCreateApplicationSendPinPerPhoneNumberLimit = "2/1d";
            string expectedEnabled = "true";

            string givenRequest = $@"
            {{
                ""name"": ""{expectedCreateApplicationName}"",
                ""enabled"": {expectedEnabled},
                ""configuration"": {{
                    ""pinAttempts"": {expectedCreateApplicationPinAttempts},
                    ""allowMultiplePinVerifications"": {expectedAllowMultiplePinVerifications},
                    ""pinTimeToLive"": ""{expectedCreateApplicationPinTimeToLive}"",
                    ""verifyPinLimit"": ""{expectedCreateApplicationVerifyPinLimit}"",
                    ""sendPinPerApplicationLimit"": ""{expectedCreateApplicationSendPinPerApplicationLimit}"",
                    ""sendPinPerPhoneNumberLimit"": ""{expectedCreateApplicationSendPinPerPhoneNumberLimit}""
                }}
            }}";

            string expectedResponse = $@"
            {{
                ""applicationId"": ""{expectedApplicationId}"",
                ""name"": ""{expectedCreateApplicationName}"",
                ""configuration"": {{
                    ""pinAttempts"": {expectedCreateApplicationPinAttempts},
                    ""allowMultiplePinVerifications"": {expectedAllowMultiplePinVerifications},
                    ""pinTimeToLive"": ""{expectedCreateApplicationPinTimeToLive}"",
                    ""verifyPinLimit"": ""{expectedCreateApplicationVerifyPinLimit}"",
                    ""sendPinPerApplicationLimit"": ""{expectedCreateApplicationSendPinPerApplicationLimit}"",
                    ""sendPinPerPhoneNumberLimit"": ""{expectedCreateApplicationSendPinPerPhoneNumberLimit}""
                }},
                ""enabled"": {expectedEnabled}
            }}";

            SetUpPostRequest(TFA_APPLICATIONS, givenRequest, expectedResponse, 200);

            var tfaApi = new TfaApi(configuration);

            var tfaApplicationConfiguration = new TfaApplicationConfiguration()
            {
                PinAttempts = expectedCreateApplicationPinAttempts,
                AllowMultiplePinVerifications = bool.Parse(expectedAllowMultiplePinVerifications),
                PinTimeToLive = expectedCreateApplicationPinTimeToLive,
                VerifyPinLimit = expectedCreateApplicationVerifyPinLimit,
                SendPinPerApplicationLimit = expectedCreateApplicationSendPinPerApplicationLimit,
                SendPinPerPhoneNumberLimit = expectedCreateApplicationSendPinPerPhoneNumberLimit
            };

            var tfaApplicationRequest = new TfaApplicationRequest(
                varConfiguration: tfaApplicationConfiguration,
                enabled: bool.Parse(expectedEnabled),
                name: expectedCreateApplicationName
            );

            void AssertTfaCreateApplicationResponse(TfaApplicationResponse tfaApplicationResponse)
            {
                Assert.IsNotNull(tfaApplicationResponse);
                Assert.AreEqual(expectedApplicationId, tfaApplicationResponse.ApplicationId);
                Assert.AreEqual(expectedCreateApplicationName, tfaApplicationResponse.Name);
                Assert.AreEqual(tfaApplicationConfiguration, tfaApplicationResponse.VarConfiguration);
                Assert.AreEqual(bool.Parse(expectedEnabled), tfaApplicationResponse.Enabled);
            }

            AssertResponse(tfaApi.CreateTfaApplication(tfaApplicationRequest), AssertTfaCreateApplicationResponse);
            AssertResponse(tfaApi.CreateTfaApplicationAsync(tfaApplicationRequest).Result, AssertTfaCreateApplicationResponse);

            AssertResponseWithHttpInfo(tfaApi.CreateTfaApplicationWithHttpInfo(tfaApplicationRequest), AssertTfaCreateApplicationResponse);
            AssertResponseWithHttpInfo(tfaApi.CreateTfaApplicationWithHttpInfoAsync(tfaApplicationRequest).Result, AssertTfaCreateApplicationResponse);
        }

        [TestMethod]
        public void ShouldGetTfaApplicationTest()
        {
            string expectedApplicationId = "1234567";
            string expectedGetApplicationName = "2fa application name";
            int expectedGetApplicationPinAttempts = 5;
            string expectedAllowMultiplePinVerifications = "true";
            string expectedGetApplicationPinTimeToLive = "10m";
            string expectedGetApplicationVerifyPinLimit = "2/4s";
            string expectedGetApplicationSendPinPerApplicationLimit = "5000/12h";
            string expectedGetApplicationSendPinPerPhoneNumberLimit = "2/1d";
            string expectedEnabled = "true";

            string expectedResponse = $@"
            {{
                ""applicationId"": ""{expectedApplicationId}"",
                ""name"": ""{expectedGetApplicationName}"",
                ""configuration"": {{
                    ""pinAttempts"": {expectedGetApplicationPinAttempts},
                    ""allowMultiplePinVerifications"": {expectedAllowMultiplePinVerifications},
                    ""pinTimeToLive"": ""{expectedGetApplicationPinTimeToLive}"",
                    ""verifyPinLimit"": ""{expectedGetApplicationVerifyPinLimit}"",
                    ""sendPinPerApplicationLimit"": ""{expectedGetApplicationSendPinPerApplicationLimit}"",
                    ""sendPinPerPhoneNumberLimit"": ""{expectedGetApplicationSendPinPerPhoneNumberLimit}""
                }},
                ""enabled"": {expectedEnabled}
            }}";

            SetUpGetRequest(TFA_APPLICATION.Replace("{appId}", expectedApplicationId), expectedResponse, 200);

            var tfaApi = new TfaApi(configuration);

            void AssertTfaGetApplicationResponse(TfaApplicationResponse tfaApplicationResponse)
            {
                var expectedApplicationConfiguration = new TfaApplicationConfiguration()
                {
                    PinAttempts = expectedGetApplicationPinAttempts,
                    AllowMultiplePinVerifications = bool.Parse(expectedAllowMultiplePinVerifications),
                    PinTimeToLive = expectedGetApplicationPinTimeToLive,
                    VerifyPinLimit = expectedGetApplicationVerifyPinLimit,
                    SendPinPerApplicationLimit = expectedGetApplicationSendPinPerApplicationLimit,
                    SendPinPerPhoneNumberLimit = expectedGetApplicationSendPinPerPhoneNumberLimit
                };

                Assert.IsNotNull(tfaApplicationResponse);
                Assert.AreEqual(expectedApplicationId, tfaApplicationResponse.ApplicationId);
                Assert.AreEqual(expectedGetApplicationName, tfaApplicationResponse.Name);
                Assert.AreEqual(expectedApplicationConfiguration, tfaApplicationResponse.VarConfiguration);
                Assert.AreEqual(bool.Parse(expectedEnabled), tfaApplicationResponse.Enabled);
            }

            AssertResponse(tfaApi.GetTfaApplication(expectedApplicationId), AssertTfaGetApplicationResponse);
            AssertResponse(tfaApi.GetTfaApplicationAsync(expectedApplicationId).Result, AssertTfaGetApplicationResponse);

            AssertResponseWithHttpInfo(tfaApi.GetTfaApplicationWithHttpInfo(expectedApplicationId), AssertTfaGetApplicationResponse);
            AssertResponseWithHttpInfo(tfaApi.GetTfaApplicationWithHttpInfoAsync(expectedApplicationId).Result, AssertTfaGetApplicationResponse);
        }

        [TestMethod]
        public void ShouldUpdateTfaApplicationTest()
        {
            string expectedApplicationId = "1234567";
            string expectedCreateApplicationName = "2fa application name";
            int expectedCreateApplicationPinAttempts = 5;
            string expectedAllowMultiplePinVerifications = "true";
            string expectedCreateApplicationPinTimeToLive = "10m";
            string expectedCreateApplicationVerifyPinLimit = "2/4s";
            string expectedCreateApplicationSendPinPerApplicationLimit = "5000/12h";
            string expectedCreateApplicationSendPinPerPhoneNumberLimit = "2/1d";
            string expectedEnabled = "true";

            string givenRequest = $@"
            {{
                ""name"": ""{expectedCreateApplicationName}"",
                ""enabled"": {expectedEnabled},
                ""configuration"": {{
                    ""pinAttempts"": {expectedCreateApplicationPinAttempts},
                    ""allowMultiplePinVerifications"": {expectedAllowMultiplePinVerifications},
                    ""pinTimeToLive"": ""{expectedCreateApplicationPinTimeToLive}"",
                    ""verifyPinLimit"": ""{expectedCreateApplicationVerifyPinLimit}"",
                    ""sendPinPerApplicationLimit"": ""{expectedCreateApplicationSendPinPerApplicationLimit}"",
                    ""sendPinPerPhoneNumberLimit"": ""{expectedCreateApplicationSendPinPerPhoneNumberLimit}""
                }}
            }}";

            string expectedResponse = $@"
            {{
                ""applicationId"": ""{expectedApplicationId}"",
                ""name"": ""{expectedCreateApplicationName}"",
                ""configuration"": {{
                    ""pinAttempts"": {expectedCreateApplicationPinAttempts},
                    ""allowMultiplePinVerifications"": {expectedAllowMultiplePinVerifications},
                    ""pinTimeToLive"": ""{expectedCreateApplicationPinTimeToLive}"",
                    ""verifyPinLimit"": ""{expectedCreateApplicationVerifyPinLimit}"",
                    ""sendPinPerApplicationLimit"": ""{expectedCreateApplicationSendPinPerApplicationLimit}"",
                    ""sendPinPerPhoneNumberLimit"": ""{expectedCreateApplicationSendPinPerPhoneNumberLimit}""
                }},
                ""enabled"": {expectedEnabled}
            }}";

            SetUpPutRequest(TFA_APPLICATION.Replace("{appId}", expectedApplicationId), givenRequest, expectedResponse, 200);

            var tfaApi = new TfaApi(configuration);

            var tfaApplicationConfiguration = new TfaApplicationConfiguration()
            {
                PinAttempts = expectedCreateApplicationPinAttempts,
                AllowMultiplePinVerifications = bool.Parse(expectedAllowMultiplePinVerifications),
                PinTimeToLive = expectedCreateApplicationPinTimeToLive,
                VerifyPinLimit = expectedCreateApplicationVerifyPinLimit,
                SendPinPerApplicationLimit = expectedCreateApplicationSendPinPerApplicationLimit,
                SendPinPerPhoneNumberLimit = expectedCreateApplicationSendPinPerPhoneNumberLimit
            };

            var tfaApplicationRequest = new TfaApplicationRequest(
                varConfiguration: tfaApplicationConfiguration,
                enabled: bool.Parse(expectedEnabled),
                name: expectedCreateApplicationName
            );

            void AssertTfaUpdateApplicationResponse(TfaApplicationResponse tfaApplicationResponse)
            {
                Assert.IsNotNull(tfaApplicationResponse);
                Assert.AreEqual(expectedApplicationId, tfaApplicationResponse.ApplicationId);
                Assert.AreEqual(expectedCreateApplicationName, tfaApplicationResponse.Name);
                Assert.AreEqual(tfaApplicationConfiguration, tfaApplicationResponse.VarConfiguration);
                Assert.AreEqual(bool.Parse(expectedEnabled), tfaApplicationResponse.Enabled);
            }

            AssertResponse(tfaApi.UpdateTfaApplication(expectedApplicationId, tfaApplicationRequest), AssertTfaUpdateApplicationResponse);
            AssertResponse(tfaApi.UpdateTfaApplicationAsync(expectedApplicationId, tfaApplicationRequest).Result, AssertTfaUpdateApplicationResponse);

            AssertResponseWithHttpInfo(tfaApi.UpdateTfaApplicationWithHttpInfo(expectedApplicationId, tfaApplicationRequest), AssertTfaUpdateApplicationResponse);
            AssertResponseWithHttpInfo(tfaApi.UpdateTfaApplicationWithHttpInfoAsync(expectedApplicationId, tfaApplicationRequest).Result, AssertTfaUpdateApplicationResponse);
        }

        [TestMethod]
        public void ShouldGetTfaMessageTemplatesTest()
        {
            string givenApplicationId = "HJ675435E3A6EA43432G5F37A635KJ8B";

            string expectedPinPlaceholder = "{{pin}}";
            string expectedMessageText = string.Format("Your PIN is {0}.", expectedPinPlaceholder);
            int expectedPinLength = 4;
            string expectedPinType = "Alphanumeric";
            string expectedLanguage = "En";
            string expectedSenderId = "Infobip 2FA";
            string expectedRepeatDtmf = "1#";
            double expectedSpeechRate = 1;

            string expectedResponse = $@"
            [
                {{
                    ""pinPlaceholder"": ""{expectedPinPlaceholder}"",
                    ""pinType"": ""{expectedPinType}"",
                    ""messageText"": ""{expectedMessageText}"",
                    ""pinLength"": {expectedPinLength},
                    ""language"": ""{expectedLanguage}"",
                    ""senderId"": ""{expectedSenderId}"",
                    ""repeatDTMF"": ""{expectedRepeatDtmf}"",
                    ""speechRate"": {expectedSpeechRate}
                }}
            ]";

            SetUpGetRequest(TFA_TEMPLATES.Replace("{appId}", givenApplicationId), expectedResponse, 200);

            var tfaApi = new TfaApi(configuration);

            void AssertTfaGetTemplatesResponse(List<TfaMessage> tfaMessages)
            {
                Assert.IsNotNull(tfaMessages);
                var tfaMessage = tfaMessages[0];

                Assert.IsNotNull(tfaMessage);
                Assert.AreEqual(expectedPinPlaceholder, tfaMessage.PinPlaceholder);
                Assert.AreEqual(expectedMessageText, tfaMessage.MessageText);
                Assert.AreEqual(expectedPinLength, tfaMessage.PinLength);
                Assert.AreEqual(Enum.Parse<TfaPinType>(expectedPinType), tfaMessage.PinType);
                Assert.AreEqual(Enum.Parse<TfaLanguage>(expectedLanguage), tfaMessage.Language);
                Assert.AreEqual(expectedSenderId, tfaMessage.SenderId);
                Assert.AreEqual(expectedRepeatDtmf, tfaMessage.RepeatDTMF);
                Assert.AreEqual(expectedSpeechRate, tfaMessage.SpeechRate);
            }

            AssertResponse(tfaApi.GetTfaMessageTemplates(givenApplicationId), AssertTfaGetTemplatesResponse);
            AssertResponse(tfaApi.GetTfaMessageTemplatesAsync(givenApplicationId).Result, AssertTfaGetTemplatesResponse);

            AssertResponseWithHttpInfo(tfaApi.GetTfaMessageTemplatesWithHttpInfo(givenApplicationId), AssertTfaGetTemplatesResponse);
            AssertResponseWithHttpInfo(tfaApi.GetTfaMessageTemplatesWithHttpInfoAsync(givenApplicationId).Result, AssertTfaGetTemplatesResponse);
        }

        [TestMethod]
        public void ShouldCreateTfaMessageTemplateTest()
        {
            string givenApplicationId = "HJ675435E3A6EA43432G5F37A635KJ8B";

            string expectedPinPlaceholder = "{{pin}}";
            string expectedMessageText = string.Format("Your PIN is {0}.", expectedPinPlaceholder);
            int expectedPinLength = 4;
            string expectedPinType = "Alphanumeric";
            string expectedLanguage = "en";
            string expectedSenderId = "Infobip 2FA";
            string expectedRepeatDtmf = "1#";
            string expectedSpeechRate = "1.0";

            string givenRequest = $@"
            {{
                ""language"": ""{expectedLanguage}"",
                ""pinType"": ""{expectedPinType}"",
                ""messageText"": ""{expectedMessageText}"",
                ""pinLength"": {expectedPinLength},
                ""repeatDTMF"": ""{expectedRepeatDtmf}"",
                ""senderId"": ""{expectedSenderId}"",
                ""speechRate"": {expectedSpeechRate}
            }}";

            string expectedResponse = $@"
            {{
                ""pinPlaceholder"": ""{expectedPinPlaceholder}"",
                ""pinType"": ""{expectedPinType}"",
                ""messageText"": ""{expectedMessageText}"",
                ""pinLength"": {expectedPinLength},
                ""language"": ""{expectedLanguage}"",
                ""senderId"": ""{expectedSenderId}"",
                ""repeatDTMF"": ""{expectedRepeatDtmf}"",
                ""speechRate"": {expectedSpeechRate}
            }}";

            SetUpPostRequest(TFA_TEMPLATES.Replace("{appId}", givenApplicationId), givenRequest, expectedResponse, 200);

            var tfaApi = new TfaApi(configuration);

            var tfaCreateMessageRequest = new TfaCreateMessageRequest(
                language: Enum.Parse<TfaLanguage>(expectedLanguage, true),
                messageText: expectedMessageText,
                pinLength: expectedPinLength,
                pinType: Enum.Parse<TfaPinType>(expectedPinType, true),
                repeatDTMF: expectedRepeatDtmf,
                senderId: expectedSenderId,
                speechRate: double.Parse(expectedSpeechRate, System.Globalization.CultureInfo.InvariantCulture)
            );

            void AssertTfaCreateTemplateResponse(TfaMessage tfaMessage)
            {
                Assert.IsNotNull(tfaMessage);
                Assert.AreEqual(expectedPinPlaceholder, tfaMessage.PinPlaceholder);
                Assert.AreEqual(expectedMessageText, tfaMessage.MessageText);
                Assert.AreEqual(expectedPinLength, tfaMessage.PinLength);
                Assert.AreEqual(Enum.Parse<TfaPinType>(expectedPinType, true), tfaMessage.PinType);
                Assert.AreEqual(Enum.Parse<TfaLanguage>(expectedLanguage, true), tfaMessage.Language);
                Assert.AreEqual(expectedSenderId, tfaMessage.SenderId);
                Assert.AreEqual(expectedRepeatDtmf, tfaMessage.RepeatDTMF);
                Assert.AreEqual(double.Parse(expectedSpeechRate, System.Globalization.CultureInfo.InvariantCulture), tfaMessage.SpeechRate);
            }

            AssertResponse(tfaApi.CreateTfaMessageTemplate(givenApplicationId, tfaCreateMessageRequest), AssertTfaCreateTemplateResponse);
            AssertResponse(tfaApi.CreateTfaMessageTemplateAsync(givenApplicationId, tfaCreateMessageRequest).Result, AssertTfaCreateTemplateResponse);

            AssertResponseWithHttpInfo(tfaApi.CreateTfaMessageTemplateWithHttpInfo(givenApplicationId, tfaCreateMessageRequest), AssertTfaCreateTemplateResponse);
            AssertResponseWithHttpInfo(tfaApi.CreateTfaMessageTemplateWithHttpInfoAsync(givenApplicationId, tfaCreateMessageRequest).Result, AssertTfaCreateTemplateResponse);
        }

        [TestMethod]
        public void ShouldGetTfaMessageTemplateTest()
        {
            string givenApplicationId = "HJ675435E3A6EA43432G5F37A635KJ8B";
            string givenMessageId = "9C815F8AF3328";

            string expectedPinPlaceholder = "{{pin}}";
            string expectedMessageText = string.Format("Your PIN is {0}.", expectedPinPlaceholder);
            int expectedPinLength = 4;
            string expectedPinType = "Alphanumeric";
            string expectedLanguage = "En";
            string expectedSenderId = "Infobip 2FA";
            string expectedRepeatDtmf = "1#";
            double expectedSpeechRate = 1.0;

            string expectedResponse = $@"
            {{
                ""pinPlaceholder"": ""{expectedPinPlaceholder}"",
                ""pinType"": ""{expectedPinType}"",
                ""messageText"": ""{expectedMessageText}"",
                ""pinLength"": {expectedPinLength},
                ""language"": ""{expectedLanguage}"",
                ""senderId"": ""{expectedSenderId}"",
                ""repeatDTMF"": ""{expectedRepeatDtmf}"",
                ""speechRate"": {expectedSpeechRate}
            }}";

            SetUpGetRequest(TFA_TEMPLATE.Replace("{appId}", givenApplicationId).Replace("{msgId}", givenMessageId), expectedResponse, 200);

            var tfaApi = new TfaApi(configuration);

            void AssertTfaGetTemplateResponse(TfaMessage tfaMessage)
            {
                Assert.IsNotNull(tfaMessage);
                Assert.AreEqual(expectedPinPlaceholder, tfaMessage.PinPlaceholder);
                Assert.AreEqual(expectedMessageText, tfaMessage.MessageText);
                Assert.AreEqual(expectedPinLength, tfaMessage.PinLength);
                Assert.AreEqual(Enum.Parse<TfaPinType>(expectedPinType), tfaMessage.PinType);
                Assert.AreEqual(Enum.Parse<TfaLanguage>(expectedLanguage), tfaMessage.Language);
                Assert.AreEqual(expectedSenderId, tfaMessage.SenderId);
                Assert.AreEqual(expectedRepeatDtmf, tfaMessage.RepeatDTMF);
                Assert.AreEqual(expectedSpeechRate, tfaMessage.SpeechRate);
            }

            AssertResponse(tfaApi.GetTfaMessageTemplate(givenApplicationId, givenMessageId), AssertTfaGetTemplateResponse);
            AssertResponse(tfaApi.GetTfaMessageTemplateAsync(givenApplicationId, givenMessageId).Result, AssertTfaGetTemplateResponse);

            AssertResponseWithHttpInfo(tfaApi.GetTfaMessageTemplateWithHttpInfo(givenApplicationId, givenMessageId), AssertTfaGetTemplateResponse);
            AssertResponseWithHttpInfo(tfaApi.GetTfaMessageTemplateWithHttpInfoAsync(givenApplicationId, givenMessageId).Result, AssertTfaGetTemplateResponse);
        }

        [TestMethod]
        public void ShouldUpdateTfaMessageTemplateTest()
        {
            string givenApplicationId = "HJ675435E3A6EA43432G5F37A635KJ8B";
            string givenMessageId = "5E3A6EA43432G5F3";

            string expectedPinPlaceholder = "{{pin}}";
            string expectedMessageText = string.Format("Your PIN is {0}.", expectedPinPlaceholder);
            int expectedPinLength = 4;
            string expectedPinType = "Alphanumeric";
            string expectedLanguage = "en";
            string expectedSenderId = "Infobip 2FA";
            string expectedRepeatDtmf = "1#";
            string expectedSpeechRate = "1.0";

            string givenRequest = $@"
            {{
                ""language"": ""{expectedLanguage}"",
                ""pinType"": ""{expectedPinType}"",
                ""messageText"": ""{expectedMessageText}"",
                ""pinLength"": {expectedPinLength},
                ""repeatDTMF"": ""{expectedRepeatDtmf}"",
                ""senderId"": ""{expectedSenderId}"",
                ""speechRate"": {expectedSpeechRate}
            }}";


            string expectedResponse = $@"
            {{
                ""pinPlaceholder"": ""{expectedPinPlaceholder}"",
                ""pinType"": ""{expectedPinType}"",
                ""messageText"": ""{expectedMessageText}"",
                ""pinLength"": {expectedPinLength},
                ""language"": ""{expectedLanguage}"",
                ""senderId"": ""{expectedSenderId}"",
                ""repeatDTMF"": ""{expectedRepeatDtmf}"",
                ""speechRate"": {expectedSpeechRate}
            }}";

            SetUpPutRequest(TFA_TEMPLATE.Replace("{appId}", givenApplicationId).Replace("{msgId}", givenMessageId), givenRequest, expectedResponse, 200);

            var tfaApi = new TfaApi(configuration);

            var tfaUpdateMessageRequest = new TfaUpdateMessageRequest(
                language: Enum.Parse<TfaLanguage>(expectedLanguage, true),
                messageText: expectedMessageText,
                pinLength: expectedPinLength,
                pinType: Enum.Parse<TfaPinType>(expectedPinType, true),
                repeatDTMF: expectedRepeatDtmf,
                senderId: expectedSenderId,
                speechRate: double.Parse(expectedSpeechRate, System.Globalization.CultureInfo.InvariantCulture)
            );

            void AssertTfaUpdateTemplateResponse(TfaMessage tfaMessage)
            {
                Assert.IsNotNull(tfaMessage);
                Assert.AreEqual(expectedPinPlaceholder, tfaMessage.PinPlaceholder);
                Assert.AreEqual(expectedMessageText, tfaMessage.MessageText);
                Assert.AreEqual(expectedPinLength, tfaMessage.PinLength);
                Assert.AreEqual(Enum.Parse<TfaPinType>(expectedPinType, true), tfaMessage.PinType);
                Assert.AreEqual(Enum.Parse<TfaLanguage>(expectedLanguage, true), tfaMessage.Language);
                Assert.AreEqual(expectedSenderId, tfaMessage.SenderId);
                Assert.AreEqual(expectedRepeatDtmf, tfaMessage.RepeatDTMF);
                Assert.AreEqual(double.Parse(expectedSpeechRate, System.Globalization.CultureInfo.InvariantCulture), tfaMessage.SpeechRate);
            }

            AssertResponse(tfaApi.UpdateTfaMessageTemplate(givenApplicationId, givenMessageId, tfaUpdateMessageRequest), AssertTfaUpdateTemplateResponse);
            AssertResponse(tfaApi.UpdateTfaMessageTemplateAsync(givenApplicationId, givenMessageId, tfaUpdateMessageRequest).Result, AssertTfaUpdateTemplateResponse);

            AssertResponseWithHttpInfo(tfaApi.UpdateTfaMessageTemplateWithHttpInfo(givenApplicationId, givenMessageId, tfaUpdateMessageRequest), AssertTfaUpdateTemplateResponse);
            AssertResponseWithHttpInfo(tfaApi.UpdateTfaMessageTemplateWithHttpInfoAsync(givenApplicationId, givenMessageId, tfaUpdateMessageRequest).Result, AssertTfaUpdateTemplateResponse);
        }

        [TestMethod]
        public void ShouldCreateTfaEmailMessageTemplateTest()
        {
            TfaPinType expectedPinType = TfaPinType.Numeric;
            int expectedPinLength = 4;
            string expectedFrom = "company@example.com";
            int expectedEmailTemplateId = 1234;
            string expectedMessageId = "9C815F8AF3328";
            string expectedApplicationId = "HJ675435E3A6EA43432G5F37A635KJ8B";

            string givenRequest = $@"
            {{
                ""pinType"": ""{expectedPinType}"",
                ""pinLength"": {expectedPinLength},
                ""from"": ""{expectedFrom}"",
                ""emailTemplateId"": {expectedEmailTemplateId}
            }}";

            string expectedResponse = $@"
            {{
                ""messageId"": ""{expectedMessageId}"",
                ""applicationId"": ""{expectedApplicationId}"",
                ""pinLength"": {expectedPinLength},
                ""pinType"": ""{expectedPinType}"",
                ""from"": ""{expectedFrom}"",
                ""emailTemplateId"": {expectedEmailTemplateId}
            }}";

            SetUpPostRequest(TFA_EMAIL_TEMPLATES.Replace("{appId}", expectedApplicationId), givenRequest, expectedResponse, 200);

            var tfaApi = new TfaApi(configuration);

            var tfaCreateEmailMessageRequest = new TfaCreateEmailMessageRequest(
                    pinType: expectedPinType,
                    pinLength: expectedPinLength,
                    from: expectedFrom,
                    emailTemplateId: expectedEmailTemplateId
                );

            void AssertTfaCreateEmailMessageResponse(TfaEmailMessage tfaEmailMessage) {
                Assert.IsNotNull(tfaEmailMessage);
                Assert.AreEqual(tfaEmailMessage.MessageId, expectedMessageId);
                Assert.AreEqual(tfaEmailMessage.ApplicationId, expectedApplicationId);
                Assert.AreEqual(tfaEmailMessage.PinLength, expectedPinLength);
                Assert.AreEqual(tfaEmailMessage.PinType, expectedPinType);
                Assert.AreEqual(tfaEmailMessage.From, expectedFrom);
                Assert.AreEqual(tfaEmailMessage.EmailTemplateId, expectedEmailTemplateId);
            }

            AssertResponse(tfaApi.CreateTfaEmailMessageTemplate(expectedApplicationId, tfaCreateEmailMessageRequest), AssertTfaCreateEmailMessageResponse);
            AssertResponse(tfaApi.CreateTfaEmailMessageTemplateAsync(expectedApplicationId, tfaCreateEmailMessageRequest).Result, AssertTfaCreateEmailMessageResponse);

            AssertResponseWithHttpInfo(tfaApi.CreateTfaEmailMessageTemplateWithHttpInfo(expectedApplicationId, tfaCreateEmailMessageRequest), AssertTfaCreateEmailMessageResponse);
            AssertResponseWithHttpInfo(tfaApi.CreateTfaEmailMessageTemplateWithHttpInfoAsync(expectedApplicationId, tfaCreateEmailMessageRequest).Result, AssertTfaCreateEmailMessageResponse);

        }

        [TestMethod]
        public void ShouldUpdateTfaEmailMessageTemplateTest()
        {
            TfaPinType expectedPinType = TfaPinType.Numeric;
            int expectedPinLength = 4;
            string expectedFrom = "company@example.com";
            int expectedEmailTemplateId = 1234;
            string expectedMessageId = "9C815F8AF3328";
            string expectedApplicationId = "HJ675435E3A6EA43432G5F37A635KJ8B";

            string givenRequest = $@"
            {{
                ""pinType"": ""{expectedPinType}"",
                ""pinLength"": {expectedPinLength},
                ""from"": ""{expectedFrom}"",
                ""emailTemplateId"": {expectedEmailTemplateId}
            }}";

            string expectedResponse = $@"
            {{
                ""messageId"": ""{expectedMessageId}"",
                ""applicationId"": ""{expectedApplicationId}"",
                ""pinLength"": {expectedPinLength},
                ""pinType"": ""{expectedPinType}"",
                ""from"": ""{expectedFrom}"",
                ""emailTemplateId"": {expectedEmailTemplateId}
            }}";

            SetUpPutRequest(TFA_EMAIL_TEMPLATE.Replace("{appId}", expectedApplicationId).Replace("{msgId}", expectedMessageId), givenRequest, expectedResponse, 200);

            var tfaApi = new TfaApi(configuration);

            var tfaUpdateEmailMessageRequest = new TfaUpdateEmailMessageRequest(
                    pinType: expectedPinType,
                    pinLength: expectedPinLength,
                    from: expectedFrom,
                    emailTemplateId: expectedEmailTemplateId
                );

            void AssertTfaUpdateEmailMessageResponse(TfaEmailMessage tfaEmailMessage)
            {
                Assert.IsNotNull(tfaEmailMessage);
                Assert.AreEqual(tfaEmailMessage.MessageId, expectedMessageId);
                Assert.AreEqual(tfaEmailMessage.ApplicationId, expectedApplicationId);
                Assert.AreEqual(tfaEmailMessage.PinLength, expectedPinLength);
                Assert.AreEqual(tfaEmailMessage.PinType, expectedPinType);
                Assert.AreEqual(tfaEmailMessage.From, expectedFrom);
                Assert.AreEqual(tfaEmailMessage.EmailTemplateId, expectedEmailTemplateId);
            }

            AssertResponse(tfaApi.UpdateTfaEmailMessageTemplate(expectedApplicationId, expectedMessageId, tfaUpdateEmailMessageRequest), AssertTfaUpdateEmailMessageResponse);
            AssertResponse(tfaApi.UpdateTfaEmailMessageTemplateAsync(expectedApplicationId, expectedMessageId, tfaUpdateEmailMessageRequest).Result, AssertTfaUpdateEmailMessageResponse);

            AssertResponseWithHttpInfo(tfaApi.UpdateTfaEmailMessageTemplateWithHttpInfo(expectedApplicationId, expectedMessageId, tfaUpdateEmailMessageRequest), AssertTfaUpdateEmailMessageResponse);
            AssertResponseWithHttpInfo(tfaApi.UpdateTfaEmailMessageTemplateWithHttpInfoAsync(expectedApplicationId, expectedMessageId, tfaUpdateEmailMessageRequest).Result, AssertTfaUpdateEmailMessageResponse);
        }

        [TestMethod]
        public void ShouldSendTfaPinCodeViaSmsTest()
        {
            string givenApplicationId = "1234567";
            string givenMessageId = "7654321";
            string givenFrom = "Sender 1";
            string givenFirstName = "John";

            string expectedPinId = "9C817C6F8AF3D48F9FE553282AFA2B67";
            string expectedTo = "41793026727";
            string expectedNcStatus = "NC_DESTINATION_REACHABLE";
            string expectedSmsStatus = "MESSAGE_SENT";

            string givenRequest = $@"
            {{
                ""applicationId"": ""{givenApplicationId}"",
                ""messageId"": ""{givenMessageId}"",
                ""from"": ""{givenFrom}"",
                ""to"": ""{expectedTo}"",
                ""placeholders"": {{
                    ""firstName"": ""{givenFirstName}""
                }}
            }}";

            string expectedResponse = $@"
            {{
                ""pinId"": ""{expectedPinId}"",
                ""to"": ""{expectedTo}"",
                ""ncStatus"": ""{expectedNcStatus}"",
                ""smsStatus"": ""{expectedSmsStatus}""
            }}";

            SetUpPostRequest(TFA_SEND_PIN, givenRequest, expectedResponse, 200);

            var tfaApi = new TfaApi(configuration);

            var givenPlaceholders = new Dictionary<string, string> { { "firstName", givenFirstName } };
            var tfaStartAuthenticationRequest = new TfaStartAuthenticationRequest(
                applicationId: givenApplicationId,
                from: givenFrom,
                messageId: givenMessageId,
                placeholders: givenPlaceholders,
                to: expectedTo
            );

            void AssertTfaStartAuthenticationResponse(TfaStartAuthenticationResponse tfaStartAuthenticationResponse)
            {
                Assert.IsNotNull(tfaStartAuthenticationResponse);
                Assert.AreEqual(expectedPinId, tfaStartAuthenticationResponse.PinId);
                Assert.AreEqual(expectedTo, tfaStartAuthenticationResponse.To);
                Assert.AreEqual(expectedNcStatus, tfaStartAuthenticationResponse.NcStatus);
                Assert.AreEqual(expectedSmsStatus, tfaStartAuthenticationResponse.SmsStatus);
            }

            AssertResponse(tfaApi.SendTfaPinCodeOverSms(tfaStartAuthenticationRequest: tfaStartAuthenticationRequest), AssertTfaStartAuthenticationResponse);
            AssertResponse(tfaApi.SendTfaPinCodeOverSmsAsync(tfaStartAuthenticationRequest: tfaStartAuthenticationRequest).Result, AssertTfaStartAuthenticationResponse);

            AssertResponseWithHttpInfo(tfaApi.SendTfaPinCodeOverSmsWithHttpInfo(tfaStartAuthenticationRequest: tfaStartAuthenticationRequest), AssertTfaStartAuthenticationResponse);
            AssertResponseWithHttpInfo(tfaApi.SendTfaPinCodeOverSmsWithHttpInfoAsync(tfaStartAuthenticationRequest: tfaStartAuthenticationRequest).Result, AssertTfaStartAuthenticationResponse);
        }

        [TestMethod]
        public void ShouldResendTfaPinCodeViaSmsTest()
        {
            string givenFirstName = "John";

            string expectedPinId = "9C817C6F8AF3D48F9FE553282AFA2B67";
            string expectedTo = "41793026727";
            string expectedNcStatus = "NC_DESTINATION_REACHABLE";
            string expectedSmsStatus = "MESSAGE_SENT";

            string givenRequest = $@"
            {{
                ""placeholders"": {{
                    ""firstName"": ""{givenFirstName}""
                }}
            }}";

            string expectedResponse = $@"
            {{
                ""pinId"": ""{expectedPinId}"",
                ""to"": ""{expectedTo}"",
                ""ncStatus"": ""{expectedNcStatus}"",
                ""smsStatus"": ""{expectedSmsStatus}""
            }}";

            SetUpPostRequest(TFA_RESEND_PIN.Replace("{pinId}", expectedPinId), givenRequest, expectedResponse, 200);

            var tfaApi = new TfaApi(configuration);

            var tfaResendPinRequest = new TfaResendPinRequest()
            {
                Placeholders = new Dictionary<string, string> { { "firstName", givenFirstName } }
            };

            void AssertTfaStartAuthenticationResponse(TfaStartAuthenticationResponse tfaStartAuthenticationResponse)
            {
                Assert.IsNotNull(tfaStartAuthenticationResponse);
                Assert.AreEqual(expectedPinId, tfaStartAuthenticationResponse.PinId);
                Assert.AreEqual(expectedTo, tfaStartAuthenticationResponse.To);
                Assert.AreEqual(expectedNcStatus, tfaStartAuthenticationResponse.NcStatus);
                Assert.AreEqual(expectedSmsStatus, tfaStartAuthenticationResponse.SmsStatus);
            }

            AssertResponse(tfaApi.ResendTfaPinCodeOverSms(expectedPinId, tfaResendPinRequest), AssertTfaStartAuthenticationResponse);
            AssertResponse(tfaApi.ResendTfaPinCodeOverSmsAsync(expectedPinId, tfaResendPinRequest).Result, AssertTfaStartAuthenticationResponse);

            AssertResponseWithHttpInfo(tfaApi.ResendTfaPinCodeOverSmsWithHttpInfo(expectedPinId, tfaResendPinRequest), AssertTfaStartAuthenticationResponse);
            AssertResponseWithHttpInfo(tfaApi.ResendTfaPinCodeOverSmsWithHttpInfoAsync(expectedPinId, tfaResendPinRequest).Result, AssertTfaStartAuthenticationResponse);
        }

        [TestMethod]
        public void ShouldSendTfaPinCodeViaVoiceTest()
        {
            string givenApplicationId = "1234567";
            string givenMessageId = "7654321";
            string givenFrom = "Sender 1";
            string givenFirstName = "John";

            string expectedPinId = "9C817C6F8AF3D48F9FE553282AFA2B67";
            string expectedTo = "41793026727";
            string expectedCallStatus = "PENDING_ACCEPTED";

            string givenRequest = $@"
            {{
                ""applicationId"": ""{givenApplicationId}"",
                ""messageId"": ""{givenMessageId}"",
                ""from"": ""{givenFrom}"",
                ""to"": ""{expectedTo}"",
                ""placeholders"": {{
                    ""firstName"": ""{givenFirstName}""
                }}
            }}";

            string expectedResponse = $@"
            {{
                ""pinId"": ""{expectedPinId}"",
                ""to"": ""{expectedTo}"",
                ""callStatus"": ""{expectedCallStatus}""
            }}";

            SetUpPostRequest(TFA_SEND_PIN_VOICE, givenRequest, expectedResponse, 200);

            var tfaApi = new TfaApi(configuration);

            var givenPlaceholders = new Dictionary<string, string> { { "firstName", givenFirstName } };
            var tfaStartAuthenticationRequest = new TfaStartAuthenticationRequest(
                applicationId: givenApplicationId,
                from: givenFrom,
                messageId: givenMessageId,
                placeholders: givenPlaceholders,
                to: expectedTo
            );

            void AssertTfaStartAuthenticationResponse(TfaStartAuthenticationResponse tfaStartAuthenticationResponse)
            {
                Assert.IsNotNull(tfaStartAuthenticationResponse);
                Assert.AreEqual(expectedPinId, tfaStartAuthenticationResponse.PinId);
                Assert.AreEqual(expectedTo, tfaStartAuthenticationResponse.To);
                Assert.AreEqual(expectedCallStatus, tfaStartAuthenticationResponse.CallStatus);
            }

            AssertResponse(tfaApi.SendTfaPinCodeOverVoice(tfaStartAuthenticationRequest), AssertTfaStartAuthenticationResponse);
            AssertResponse(tfaApi.SendTfaPinCodeOverVoiceAsync(tfaStartAuthenticationRequest).Result, AssertTfaStartAuthenticationResponse);

            AssertResponseWithHttpInfo(tfaApi.SendTfaPinCodeOverVoiceWithHttpInfo(tfaStartAuthenticationRequest), AssertTfaStartAuthenticationResponse);
            AssertResponseWithHttpInfo(tfaApi.SendTfaPinCodeOverVoiceWithHttpInfoAsync(tfaStartAuthenticationRequest).Result, AssertTfaStartAuthenticationResponse);
        }

        [TestMethod]
        public void ShouldResendTfaPinCodeViaVoiceTest()
        {
            string givenFirstName = "John";

            string expectedPinId = "9C817C6F8AF3D48F9FE553282AFA2B67";
            string expectedTo = "41793026727";
            string expectedCallStatus = "MESSAGE_SENT";

            string givenRequest = $@"
            {{
                ""placeholders"": {{
                    ""firstName"": ""{givenFirstName}""
                }}
            }}";

            string expectedResponse = $@"
            {{
                ""pinId"": ""{expectedPinId}"",
                ""to"": {expectedTo},
                ""callStatus"": ""{expectedCallStatus}""
            }}";

            SetUpPostRequest(TFA_RESEND_PIN_VOICE.Replace("{pinId}", expectedPinId), givenRequest, expectedResponse, 200);

            var tfaApi = new TfaApi(configuration);

            var tfaResendPinRequest = new TfaResendPinRequest()
            {
                Placeholders = new Dictionary<string, string> { { "firstName", givenFirstName } }
            };

            void AssertTfaStartAuthenticationResponse(TfaStartAuthenticationResponse tfaStartAuthenticationResponse)
            {
                Assert.IsNotNull(tfaStartAuthenticationResponse);
                Assert.AreEqual(expectedPinId, tfaStartAuthenticationResponse.PinId);
                Assert.AreEqual(expectedTo, tfaStartAuthenticationResponse.To);
                Assert.AreEqual(expectedCallStatus, tfaStartAuthenticationResponse.CallStatus);
            }

            AssertResponse(tfaApi.ResendTfaPinCodeOverVoice(expectedPinId, tfaResendPinRequest), AssertTfaStartAuthenticationResponse); ;
            AssertResponse(tfaApi.ResendTfaPinCodeOverVoiceAsync(expectedPinId, tfaResendPinRequest).Result, AssertTfaStartAuthenticationResponse);

            AssertResponseWithHttpInfo(tfaApi.ResendTfaPinCodeOverVoiceWithHttpInfo(expectedPinId, tfaResendPinRequest), AssertTfaStartAuthenticationResponse);
            AssertResponseWithHttpInfo(tfaApi.ResendTfaPinCodeOverVoiceWithHttpInfoAsync(expectedPinId, tfaResendPinRequest).Result, AssertTfaStartAuthenticationResponse);
        }

        [TestMethod]
        public void ShouldSendTfaPinCodeViaEmailTest()
        {
            string givenApplicationId = "1234567";
            string givenMessageId = "7654321";
            string givenFirstName = "John";

            string expectedTo = "john.smith@example.com";
            string expectedPinId = "9C817C6F8AF3D48F9FE553282AFA2B67";
            string expectedEmailStatusName = "PENDING_ACCEPTED";
            string expectedEmailStatusDescription = "Message accepted, pending for delivery.";
            

            string givenRequest = $@"
            {{
                ""applicationId"": ""{givenApplicationId}"",
                ""messageId"": ""{givenMessageId}"",
                ""to"": ""{expectedTo}"",
                ""placeholders"": {{
                    ""firstName"": ""{givenFirstName}""
                }}
            }}";

            string expectedResponse = $@"
            {{
                ""pinId"": ""{expectedPinId}"",
                ""to"": ""{expectedTo}"",
                ""emailStatus"": {{
                    ""name"": ""{expectedEmailStatusName}"",
                    ""description"": ""{expectedEmailStatusDescription}""
                }}
            }}";

            SetUpPostRequest(TFA_SEND_PIN_EMAIL, givenRequest, expectedResponse, 200);

            var tfaApi = new TfaApi(configuration);

            var givenPlaceholders = new Dictionary<string, string> { { "firstName", givenFirstName } };

            var tfaStartEmailAuthenticationRequest = new TfaStartEmailAuthenticationRequest(
                    applicationId: givenApplicationId,
                    messageId: givenMessageId,
                    to: expectedTo,
                    placeholders: givenPlaceholders
                );

            void AssertTfaStartEmailAuthenticationResponse(TfaStartEmailAuthenticationResponse tfaStartEmailAuthenticationResponse)
            {
                Assert.IsNotNull(tfaStartEmailAuthenticationRequest);
                Assert.AreEqual(expectedPinId, tfaStartEmailAuthenticationResponse.PinId);
                Assert.AreEqual(expectedTo, tfaStartEmailAuthenticationResponse.To);
                Assert.AreEqual(expectedEmailStatusName, tfaStartEmailAuthenticationResponse.EmailStatus.Name);
                Assert.AreEqual(expectedEmailStatusDescription, tfaStartEmailAuthenticationResponse.EmailStatus.Description);
            }

            AssertResponse(tfaApi.Send2faPinCodeOverEmail(tfaStartEmailAuthenticationRequest), AssertTfaStartEmailAuthenticationResponse);
            AssertResponse(tfaApi.Send2faPinCodeOverEmailAsync(tfaStartEmailAuthenticationRequest).Result, AssertTfaStartEmailAuthenticationResponse);

            AssertResponseWithHttpInfo(tfaApi.Send2faPinCodeOverEmailWithHttpInfo(tfaStartEmailAuthenticationRequest), AssertTfaStartEmailAuthenticationResponse);
            AssertResponseWithHttpInfo(tfaApi.Send2faPinCodeOverEmailWithHttpInfoAsync(tfaStartEmailAuthenticationRequest).Result, AssertTfaStartEmailAuthenticationResponse);
        }

        [TestMethod]
        public void ShouldResendTfaPinCodeViaEmailTest()
        {
            string givenFirstName = "John";

            string expectedPinId = "9C817C6F8AF3D48F9FE553282AFA2B67";
            string expectedTo = "john.smith@example.com";
            string expectedEmailStatusName = "PENDING_ACCEPTED";
            string expectedEmailStatusDescription = "Message accepted, pending for delivery.";

            string givenRequest = $@"
            {{
                ""placeholders"": {{
                    ""firstName"": ""{givenFirstName}""
                }}
            }}";

            string expectedResponse = $@"
            {{
                ""pinId"": ""{expectedPinId}"",
                ""to"": ""{expectedTo}"",
                ""emailStatus"": {{
                    ""name"": ""{expectedEmailStatusName}"",
                    ""description"": ""{expectedEmailStatusDescription}""
                }}
            }}";

            SetUpPostRequest(TFA_RESEND_PIN_EMAIL.Replace("{pinId}", expectedPinId), givenRequest, expectedResponse, 200);

            var tfaApi = new TfaApi(configuration);

            var tfaResendPinRequest = new TfaResendPinRequest()
            {
                Placeholders = new Dictionary<string, string> { { "firstName", givenFirstName } }
            };

            void AssertTfaStartAuthenticationResponse(TfaStartEmailAuthenticationResponse tfaStartEmailAuthenticationResponse)
            {
                Assert.IsNotNull(tfaStartEmailAuthenticationResponse);
                Assert.AreEqual(expectedPinId, tfaStartEmailAuthenticationResponse.PinId);
                Assert.AreEqual(expectedTo, tfaStartEmailAuthenticationResponse.To);
                Assert.AreEqual(expectedEmailStatusName, tfaStartEmailAuthenticationResponse.EmailStatus.Name);
                Assert.AreEqual(expectedEmailStatusDescription, tfaStartEmailAuthenticationResponse.EmailStatus.Description);
            }

            AssertResponse(tfaApi.Resend2faPinCodeOverEmail(expectedPinId, tfaResendPinRequest), AssertTfaStartAuthenticationResponse); ;
            AssertResponse(tfaApi.Resend2faPinCodeOverEmailAsync(expectedPinId, tfaResendPinRequest).Result, AssertTfaStartAuthenticationResponse);

            AssertResponseWithHttpInfo(tfaApi.Resend2faPinCodeOverEmailWithHttpInfo(expectedPinId, tfaResendPinRequest), AssertTfaStartAuthenticationResponse);
            AssertResponseWithHttpInfo(tfaApi.Resend2faPinCodeOverEmailWithHttpInfoAsync(expectedPinId, tfaResendPinRequest).Result, AssertTfaStartAuthenticationResponse);
        }

        [TestMethod]
        public void ShouldVerifyTfaCallTest()
        {
            string givenPin = "1598";

            string expectedPinId = "9C817C6F8AF3D48F9FE553282AFA2B68";
            string expectedMsisdn = "41793026726";
            string expectedVerified = "true";
            int expectedAttemptsRemaining = 0;

            string givenRequest = $@"
            {{
                ""pin"": ""{givenPin}""
            }}";

            string expectedResponse = $@"
            {{
                ""pinId"": ""{expectedPinId}"",
                ""msisdn"": ""{expectedMsisdn}"",
                ""verified"": {expectedVerified},
                ""attemptsRemaining"": {expectedAttemptsRemaining}
            }}";

            SetUpPostRequest(TFA_VERIFY_PIN.Replace("{pinId}", expectedPinId), givenRequest, expectedResponse, 200);

            var tfaApi = new TfaApi(configuration);

            var tfaVerifyPinRequest = new TfaVerifyPinRequest(givenPin);

            void AssertTfaVerifyPinResponse(TfaVerifyPinResponse tfaVerifyPinResponse)
            {
                Assert.IsNotNull(tfaVerifyPinResponse);
                Assert.AreEqual(expectedPinId, tfaVerifyPinResponse.PinId);
                Assert.AreEqual(expectedMsisdn, tfaVerifyPinResponse.Msisdn);
                Assert.AreEqual(bool.Parse(expectedVerified), tfaVerifyPinResponse.Verified);
                Assert.AreEqual(expectedAttemptsRemaining, tfaVerifyPinResponse.AttemptsRemaining);
            }

            AssertResponse(tfaApi.VerifyTfaPhoneNumber(expectedPinId, tfaVerifyPinRequest), AssertTfaVerifyPinResponse); ;
            AssertResponse(tfaApi.VerifyTfaPhoneNumberAsync(expectedPinId, tfaVerifyPinRequest).Result, AssertTfaVerifyPinResponse);

            AssertResponseWithHttpInfo(tfaApi.VerifyTfaPhoneNumberWithHttpInfo(expectedPinId, tfaVerifyPinRequest), AssertTfaVerifyPinResponse);
            AssertResponseWithHttpInfo(tfaApi.VerifyTfaPhoneNumberWithHttpInfoAsync(expectedPinId, tfaVerifyPinRequest).Result, AssertTfaVerifyPinResponse);
        }

        [TestMethod]
        public void ShouldGetTfaVerificationStatusTest()
        {
            string givenApplicationId = "16A8B5FE2BCD6CA716A2D780CB3F3390";

            string expectedMsisdn = "41793026726";
            string expectedVerified1 = "true";
            long expectedVerifiedAt1 = 1418364366L;
            long expectedSentAt1 = 1418364246L;
            string expectedVerified2 = "false";
            long expectedVerifiedAt2 = 1418364226L;
            long expectedSentAt2 = 1418333246L;

            string expectedResponse = $@"
            {{
                ""verifications"": [
                    {{
                        ""msisdn"": ""{expectedMsisdn}"",
                        ""verified"": {expectedVerified1},
                        ""verifiedAt"": {expectedVerifiedAt1},
                        ""sentAt"": {expectedSentAt1}
                    }},
                    {{
                        ""msisdn"": ""{expectedMsisdn}"",
                        ""verified"": {expectedVerified2},
                        ""verifiedAt"": {expectedVerifiedAt2},
                        ""sentAt"": {expectedSentAt2}
                    }}
                ]
            }}";

            SetUpGetRequest(TFA_VERIFICATION_STATUS.Replace("{appId}", givenApplicationId), expectedResponse, 200);

            var tfaApi = new TfaApi(configuration);

            void AssertTfaVerificationResponse(TfaVerificationResponse tfaVerificationResponse)
            {
                Assert.IsNotNull(tfaVerificationResponse);
                Assert.IsNotNull(tfaVerificationResponse.Verifications);
                Assert.IsTrue(tfaVerificationResponse.Verifications.Count.Equals(2));

                var tfaVerification1 = tfaVerificationResponse.Verifications[0];
                Assert.AreEqual(expectedMsisdn, tfaVerification1.Msisdn);
                Assert.AreEqual(bool.Parse(expectedVerified1), tfaVerification1.Verified);
                Assert.AreEqual(expectedVerifiedAt1, tfaVerification1.VerifiedAt);
                Assert.AreEqual(expectedSentAt1, tfaVerification1.SentAt);

                var tfaVerification2 = tfaVerificationResponse.Verifications[1];
                Assert.AreEqual(expectedMsisdn, tfaVerification2.Msisdn);
                Assert.AreEqual(bool.Parse(expectedVerified2), tfaVerification2.Verified);
                Assert.AreEqual(expectedVerifiedAt2, tfaVerification2.VerifiedAt);
                Assert.AreEqual(expectedSentAt2, tfaVerification2.SentAt);
            }

            AssertResponse(tfaApi.GetTfaVerificationStatus(expectedMsisdn, givenApplicationId), AssertTfaVerificationResponse); ;
            AssertResponse(tfaApi.GetTfaVerificationStatusAsync(expectedMsisdn, givenApplicationId).Result, AssertTfaVerificationResponse);

            AssertResponseWithHttpInfo(tfaApi.GetTfaVerificationStatusWithHttpInfo(expectedMsisdn, givenApplicationId), AssertTfaVerificationResponse);
            AssertResponseWithHttpInfo(tfaApi.GetTfaVerificationStatusWithHttpInfoAsync(expectedMsisdn, givenApplicationId).Result, AssertTfaVerificationResponse);
        }
    }
}