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
            string givenApplicationId1 = "0933F3BC087D2A617AC6DCB2EF5B8A61";
            string givenGetApplicationName1 = "Test application BASIC 1";
            int givenGetApplicationPinAttempts1 = 10;
            string givenAllowMultiplePinVerifications1 = "true";
            string givenGetApplicationPinTimeToLive1 = "2h";
            string givenGetApplicationVerifyPinLimit1 = "1/3s";
            string givenGetApplicationSendPinPerApplicationLimit1 = "10000/1d";
            string givenGetApplicationSendPinPerPhoneNumberLimit1 = "3/1d";
            string givenEnabled1 = "true";

            string givenApplicationId2 = "5F04FACFAA4978F62FCAEBA97B37E90F";
            string givenGetApplicationName2 = "Test application BASIC 2";
            int givenGetApplicationPinAttempts2 = 12;
            string givenAllowMultiplePinVerifications2 = "true";
            string givenGetApplicationPinTimeToLive2 = "10m";
            string givenGetApplicationVerifyPinLimit2 = "2/1s";
            string givenGetApplicationSendPinPerApplicationLimit2 = "10000/1d";
            string givenGetApplicationSendPinPerPhoneNumberLimit2 = "5/1h";
            string givenEnabled2 = "true";

            string givenApplicationId3 = "B450F966A8EF017180F148AF22C42642";
            string givenGetApplicationName3 = "Test application BASIC 3";
            int givenGetApplicationPinAttempts3 = 15;
            string givenAllowMultiplePinVerifications3 = "true";
            string givenGetApplicationPinTimeToLive3 = "1h";
            string givenGetApplicationVerifyPinLimit3 = "30/10s";
            string givenGetApplicationSendPinPerApplicationLimit3 = "10000/3d";
            string givenGetApplicationSendPinPerPhoneNumberLimit3 = "10/20m";
            string givenEnabled3 = "true";

            string expectedResponse = $@"
            [
                {{
                    ""applicationId"": ""{givenApplicationId1}"",
                    ""name"": ""{givenGetApplicationName1}"",
                    ""configuration"": {{
                        ""pinAttempts"": {givenGetApplicationPinAttempts1},
                        ""allowMultiplePinVerifications"": {givenAllowMultiplePinVerifications1},
                        ""pinTimeToLive"": ""{givenGetApplicationPinTimeToLive1}"",
                        ""verifyPinLimit"": ""{givenGetApplicationVerifyPinLimit1}"",
                        ""sendPinPerApplicationLimit"": ""{givenGetApplicationSendPinPerApplicationLimit1}"",
                        ""sendPinPerPhoneNumberLimit"": ""{givenGetApplicationSendPinPerPhoneNumberLimit1}""
                    }},
                    ""enabled"": {givenEnabled1}
                }},
                {{
                    ""applicationId"": ""{givenApplicationId2}"",
                    ""name"": ""{givenGetApplicationName2}"",
                    ""configuration"": {{
                        ""pinAttempts"": {givenGetApplicationPinAttempts2},
                        ""allowMultiplePinVerifications"": {givenAllowMultiplePinVerifications2},
                        ""pinTimeToLive"": ""{givenGetApplicationPinTimeToLive2}"",
                        ""verifyPinLimit"": ""{givenGetApplicationVerifyPinLimit2}"",
                        ""sendPinPerApplicationLimit"": ""{givenGetApplicationSendPinPerApplicationLimit2}"",
                        ""sendPinPerPhoneNumberLimit"": ""{givenGetApplicationSendPinPerPhoneNumberLimit2}""
                    }},
                    ""enabled"": {givenEnabled2}
                }},
                {{
                    ""applicationId"": ""{givenApplicationId3}"",
                    ""name"": ""{givenGetApplicationName3}"",
                    ""configuration"": {{
                        ""pinAttempts"": {givenGetApplicationPinAttempts3},
                        ""allowMultiplePinVerifications"": {givenAllowMultiplePinVerifications3},
                        ""pinTimeToLive"": ""{givenGetApplicationPinTimeToLive3}"",
                        ""verifyPinLimit"": ""{givenGetApplicationVerifyPinLimit3}"",
                        ""sendPinPerApplicationLimit"": ""{givenGetApplicationSendPinPerApplicationLimit3}"",
                        ""sendPinPerPhoneNumberLimit"": ""{givenGetApplicationSendPinPerPhoneNumberLimit3}""
                    }},
                    ""enabled"": {givenEnabled3}
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
                Assert.AreEqual(givenApplicationId1, tfaApplicationResponse1.ApplicationId);
                Assert.AreEqual(givenGetApplicationName1, tfaApplicationResponse1.Name);
                Assert.AreEqual(givenGetApplicationPinAttempts1, tfaApplicationResponse1.VarConfiguration.PinAttempts);
                Assert.AreEqual(bool.Parse(givenAllowMultiplePinVerifications1), tfaApplicationResponse1.VarConfiguration.AllowMultiplePinVerifications);
                Assert.AreEqual(givenGetApplicationPinTimeToLive1, tfaApplicationResponse1.VarConfiguration.PinTimeToLive);
                Assert.AreEqual(givenGetApplicationVerifyPinLimit1, tfaApplicationResponse1.VarConfiguration.VerifyPinLimit);
                Assert.AreEqual(givenGetApplicationSendPinPerApplicationLimit1, tfaApplicationResponse1.VarConfiguration.SendPinPerApplicationLimit);
                Assert.AreEqual(givenGetApplicationSendPinPerPhoneNumberLimit1, tfaApplicationResponse1.VarConfiguration.SendPinPerPhoneNumberLimit);

                var tfaApplicationResponse2 = tfaApplicationResponses[1];
                Assert.IsNotNull(tfaApplicationResponse2);
                Assert.AreEqual(givenApplicationId2, tfaApplicationResponse2.ApplicationId);
                Assert.AreEqual(givenGetApplicationName2, tfaApplicationResponse2.Name);
                Assert.AreEqual(givenGetApplicationPinAttempts2, tfaApplicationResponse2.VarConfiguration.PinAttempts);
                Assert.AreEqual(bool.Parse(givenAllowMultiplePinVerifications2), tfaApplicationResponse2.VarConfiguration.AllowMultiplePinVerifications);
                Assert.AreEqual(givenGetApplicationPinTimeToLive2, tfaApplicationResponse2.VarConfiguration.PinTimeToLive);
                Assert.AreEqual(givenGetApplicationVerifyPinLimit2, tfaApplicationResponse2.VarConfiguration.VerifyPinLimit);
                Assert.AreEqual(givenGetApplicationSendPinPerApplicationLimit2, tfaApplicationResponse2.VarConfiguration.SendPinPerApplicationLimit);
                Assert.AreEqual(givenGetApplicationSendPinPerPhoneNumberLimit2, tfaApplicationResponse2.VarConfiguration.SendPinPerPhoneNumberLimit);

                var tfaApplicationResponse3 = tfaApplicationResponses[2];
                Assert.IsNotNull(tfaApplicationResponse3);
                Assert.AreEqual(givenApplicationId3, tfaApplicationResponse3.ApplicationId);
                Assert.AreEqual(givenGetApplicationName3, tfaApplicationResponse3.Name);
                Assert.AreEqual(givenGetApplicationPinAttempts3, tfaApplicationResponse3.VarConfiguration.PinAttempts);
                Assert.AreEqual(bool.Parse(givenAllowMultiplePinVerifications3), tfaApplicationResponse3.VarConfiguration.AllowMultiplePinVerifications);
                Assert.AreEqual(givenGetApplicationPinTimeToLive3, tfaApplicationResponse3.VarConfiguration.PinTimeToLive);
                Assert.AreEqual(givenGetApplicationVerifyPinLimit3, tfaApplicationResponse3.VarConfiguration.VerifyPinLimit);
                Assert.AreEqual(givenGetApplicationSendPinPerApplicationLimit3, tfaApplicationResponse3.VarConfiguration.SendPinPerApplicationLimit);
                Assert.AreEqual(givenGetApplicationSendPinPerPhoneNumberLimit3, tfaApplicationResponse3.VarConfiguration.SendPinPerPhoneNumberLimit);
            }

            AssertResponse(tfaApi.GetTfaApplications(), AssertTfaGetApplicationsResponse);
            AssertResponse(tfaApi.GetTfaApplicationsAsync().Result, AssertTfaGetApplicationsResponse);

            AssertResponseWithHttpInfo(tfaApi.GetTfaApplicationsWithHttpInfo(), AssertTfaGetApplicationsResponse);
            AssertResponseWithHttpInfo(tfaApi.GetTfaApplicationsWithHttpInfoAsync().Result, AssertTfaGetApplicationsResponse);
        }

        [TestMethod]
        public void ShouldCreateTfaApplicationTest()
        {
            string givenApplicationId = "1234567";

            string givenCreateApplicationName = "2fa application name";
            int givenCreateApplicationPinAttempts = 5;
            string givenAllowMultiplePinVerifications = "true";
            string givenCreateApplicationPinTimeToLive = "10m";
            string givenCreateApplicationVerifyPinLimit = "2/4s";
            string givenCreateApplicationSendPinPerApplicationLimit = "5000/12h";
            string givenCreateApplicationSendPinPerPhoneNumberLimit = "2/1d";
            string givenEnabled = "true";

            string expectedRequest = $@"
            {{
                ""name"": ""{givenCreateApplicationName}"",
                ""enabled"": {givenEnabled},
                ""configuration"": {{
                    ""pinAttempts"": {givenCreateApplicationPinAttempts},
                    ""allowMultiplePinVerifications"": {givenAllowMultiplePinVerifications},
                    ""pinTimeToLive"": ""{givenCreateApplicationPinTimeToLive}"",
                    ""verifyPinLimit"": ""{givenCreateApplicationVerifyPinLimit}"",
                    ""sendPinPerApplicationLimit"": ""{givenCreateApplicationSendPinPerApplicationLimit}"",
                    ""sendPinPerPhoneNumberLimit"": ""{givenCreateApplicationSendPinPerPhoneNumberLimit}""
                }}
            }}";

            string expectedResponse = $@"
            {{
                ""applicationId"": ""{givenApplicationId}"",
                ""name"": ""{givenCreateApplicationName}"",
                ""configuration"": {{
                    ""pinAttempts"": {givenCreateApplicationPinAttempts},
                    ""allowMultiplePinVerifications"": {givenAllowMultiplePinVerifications},
                    ""pinTimeToLive"": ""{givenCreateApplicationPinTimeToLive}"",
                    ""verifyPinLimit"": ""{givenCreateApplicationVerifyPinLimit}"",
                    ""sendPinPerApplicationLimit"": ""{givenCreateApplicationSendPinPerApplicationLimit}"",
                    ""sendPinPerPhoneNumberLimit"": ""{givenCreateApplicationSendPinPerPhoneNumberLimit}""
                }},
                ""enabled"": {givenEnabled}
            }}";

            SetUpPostRequest(TFA_APPLICATIONS, expectedRequest, expectedResponse, 200);

            var tfaApi = new TfaApi(configuration);

            var tfaApplicationConfiguration = new TfaApplicationConfiguration()
            {
                PinAttempts = givenCreateApplicationPinAttempts,
                AllowMultiplePinVerifications = bool.Parse(givenAllowMultiplePinVerifications),
                PinTimeToLive = givenCreateApplicationPinTimeToLive,
                VerifyPinLimit = givenCreateApplicationVerifyPinLimit,
                SendPinPerApplicationLimit = givenCreateApplicationSendPinPerApplicationLimit,
                SendPinPerPhoneNumberLimit = givenCreateApplicationSendPinPerPhoneNumberLimit
            };

            var tfaApplicationRequest = new TfaApplicationRequest(
                varConfiguration: tfaApplicationConfiguration,
                enabled: bool.Parse(givenEnabled),
                name: givenCreateApplicationName
            );

            void AssertTfaCreateApplicationResponse(TfaApplicationResponse tfaApplicationResponse)
            {
                Assert.IsNotNull(tfaApplicationResponse);
                Assert.AreEqual(givenApplicationId, tfaApplicationResponse.ApplicationId);
                Assert.AreEqual(givenCreateApplicationName, tfaApplicationResponse.Name);
                Assert.AreEqual(tfaApplicationConfiguration, tfaApplicationResponse.VarConfiguration);
                Assert.AreEqual(bool.Parse(givenEnabled), tfaApplicationResponse.Enabled);
            }

            AssertResponse(tfaApi.CreateTfaApplication(tfaApplicationRequest), AssertTfaCreateApplicationResponse);
            AssertResponse(tfaApi.CreateTfaApplicationAsync(tfaApplicationRequest).Result, AssertTfaCreateApplicationResponse);

            AssertResponseWithHttpInfo(tfaApi.CreateTfaApplicationWithHttpInfo(tfaApplicationRequest), AssertTfaCreateApplicationResponse);
            AssertResponseWithHttpInfo(tfaApi.CreateTfaApplicationWithHttpInfoAsync(tfaApplicationRequest).Result, AssertTfaCreateApplicationResponse);
        }

        [TestMethod]
        public void ShouldGetTfaApplicationTest()
        {
            string givenApplicationId = "1234567";

            string givenGetApplicationName = "2fa application name";
            int givenGetApplicationPinAttempts = 5;
            string givenAllowMultiplePinVerifications = "true";
            string givenGetApplicationPinTimeToLive = "10m";
            string givenGetApplicationVerifyPinLimit = "2/4s";
            string givenGetApplicationSendPinPerApplicationLimit = "5000/12h";
            string givenGetApplicationSendPinPerPhoneNumberLimit = "2/1d";
            string givenEnabled = "true";

            string expectedResponse = $@"
            {{
                ""applicationId"": ""{givenApplicationId}"",
                ""name"": ""{givenGetApplicationName}"",
                ""configuration"": {{
                    ""pinAttempts"": {givenGetApplicationPinAttempts},
                    ""allowMultiplePinVerifications"": {givenAllowMultiplePinVerifications},
                    ""pinTimeToLive"": ""{givenGetApplicationPinTimeToLive}"",
                    ""verifyPinLimit"": ""{givenGetApplicationVerifyPinLimit}"",
                    ""sendPinPerApplicationLimit"": ""{givenGetApplicationSendPinPerApplicationLimit}"",
                    ""sendPinPerPhoneNumberLimit"": ""{givenGetApplicationSendPinPerPhoneNumberLimit}""
                }},
                ""enabled"": {givenEnabled}
            }}";

            SetUpGetRequest(TFA_APPLICATION.Replace("{appId}", givenApplicationId), expectedResponse, 200);

            var tfaApi = new TfaApi(configuration);

            void AssertTfaGetApplicationResponse(TfaApplicationResponse tfaApplicationResponse)
            {
                var givenApplicationConfiguration = new TfaApplicationConfiguration()
                {
                    PinAttempts = givenGetApplicationPinAttempts,
                    AllowMultiplePinVerifications = bool.Parse(givenAllowMultiplePinVerifications),
                    PinTimeToLive = givenGetApplicationPinTimeToLive,
                    VerifyPinLimit = givenGetApplicationVerifyPinLimit,
                    SendPinPerApplicationLimit = givenGetApplicationSendPinPerApplicationLimit,
                    SendPinPerPhoneNumberLimit = givenGetApplicationSendPinPerPhoneNumberLimit
                };

                Assert.IsNotNull(tfaApplicationResponse);
                Assert.AreEqual(givenApplicationId, tfaApplicationResponse.ApplicationId);
                Assert.AreEqual(givenGetApplicationName, tfaApplicationResponse.Name);
                Assert.AreEqual(givenApplicationConfiguration, tfaApplicationResponse.VarConfiguration);
                Assert.AreEqual(bool.Parse(givenEnabled), tfaApplicationResponse.Enabled);
            }

            AssertResponse(tfaApi.GetTfaApplication(givenApplicationId), AssertTfaGetApplicationResponse);
            AssertResponse(tfaApi.GetTfaApplicationAsync(givenApplicationId).Result, AssertTfaGetApplicationResponse);

            AssertResponseWithHttpInfo(tfaApi.GetTfaApplicationWithHttpInfo(givenApplicationId), AssertTfaGetApplicationResponse);
            AssertResponseWithHttpInfo(tfaApi.GetTfaApplicationWithHttpInfoAsync(givenApplicationId).Result, AssertTfaGetApplicationResponse);
        }

        [TestMethod]
        public void ShouldUpdateTfaApplicationTest()
        {
            string givenApplicationId = "1234567";

            string givenCreateApplicationName = "2fa application name";
            int givenCreateApplicationPinAttempts = 5;
            string givenAllowMultiplePinVerifications = "true";
            string givenCreateApplicationPinTimeToLive = "10m";
            string givenCreateApplicationVerifyPinLimit = "2/4s";
            string givenCreateApplicationSendPinPerApplicationLimit = "5000/12h";
            string givenCreateApplicationSendPinPerPhoneNumberLimit = "2/1d";
            string givenEnabled = "true";

            string expectedRequest = $@"
            {{
                ""name"": ""{givenCreateApplicationName}"",
                ""enabled"": {givenEnabled},
                ""configuration"": {{
                    ""pinAttempts"": {givenCreateApplicationPinAttempts},
                    ""allowMultiplePinVerifications"": {givenAllowMultiplePinVerifications},
                    ""pinTimeToLive"": ""{givenCreateApplicationPinTimeToLive}"",
                    ""verifyPinLimit"": ""{givenCreateApplicationVerifyPinLimit}"",
                    ""sendPinPerApplicationLimit"": ""{givenCreateApplicationSendPinPerApplicationLimit}"",
                    ""sendPinPerPhoneNumberLimit"": ""{givenCreateApplicationSendPinPerPhoneNumberLimit}""
                }}
            }}";

            string expectedResponse = $@"
            {{
                ""applicationId"": ""{givenApplicationId}"",
                ""name"": ""{givenCreateApplicationName}"",
                ""configuration"": {{
                    ""pinAttempts"": {givenCreateApplicationPinAttempts},
                    ""allowMultiplePinVerifications"": {givenAllowMultiplePinVerifications},
                    ""pinTimeToLive"": ""{givenCreateApplicationPinTimeToLive}"",
                    ""verifyPinLimit"": ""{givenCreateApplicationVerifyPinLimit}"",
                    ""sendPinPerApplicationLimit"": ""{givenCreateApplicationSendPinPerApplicationLimit}"",
                    ""sendPinPerPhoneNumberLimit"": ""{givenCreateApplicationSendPinPerPhoneNumberLimit}""
                }},
                ""enabled"": {givenEnabled}
            }}";

            SetUpPutRequest(TFA_APPLICATION.Replace("{appId}", givenApplicationId), expectedRequest, expectedResponse, 200);

            var tfaApi = new TfaApi(configuration);

            var tfaApplicationConfiguration = new TfaApplicationConfiguration()
            {
                PinAttempts = givenCreateApplicationPinAttempts,
                AllowMultiplePinVerifications = bool.Parse(givenAllowMultiplePinVerifications),
                PinTimeToLive = givenCreateApplicationPinTimeToLive,
                VerifyPinLimit = givenCreateApplicationVerifyPinLimit,
                SendPinPerApplicationLimit = givenCreateApplicationSendPinPerApplicationLimit,
                SendPinPerPhoneNumberLimit = givenCreateApplicationSendPinPerPhoneNumberLimit
            };

            var tfaApplicationRequest = new TfaApplicationRequest(
                varConfiguration: tfaApplicationConfiguration,
                enabled: bool.Parse(givenEnabled),
                name: givenCreateApplicationName
            );

            void AssertTfaUpdateApplicationResponse(TfaApplicationResponse tfaApplicationResponse)
            {
                Assert.IsNotNull(tfaApplicationResponse);
                Assert.AreEqual(givenApplicationId, tfaApplicationResponse.ApplicationId);
                Assert.AreEqual(givenCreateApplicationName, tfaApplicationResponse.Name);
                Assert.AreEqual(tfaApplicationConfiguration, tfaApplicationResponse.VarConfiguration);
                Assert.AreEqual(bool.Parse(givenEnabled), tfaApplicationResponse.Enabled);
            }

            AssertResponse(tfaApi.UpdateTfaApplication(givenApplicationId, tfaApplicationRequest), AssertTfaUpdateApplicationResponse);
            AssertResponse(tfaApi.UpdateTfaApplicationAsync(givenApplicationId, tfaApplicationRequest).Result, AssertTfaUpdateApplicationResponse);

            AssertResponseWithHttpInfo(tfaApi.UpdateTfaApplicationWithHttpInfo(givenApplicationId, tfaApplicationRequest), AssertTfaUpdateApplicationResponse);
            AssertResponseWithHttpInfo(tfaApi.UpdateTfaApplicationWithHttpInfoAsync(givenApplicationId, tfaApplicationRequest).Result, AssertTfaUpdateApplicationResponse);
        }

        [TestMethod]
        public void ShouldGetTfaMessageTemplatesTest()
        {
            string givenApplicationId = "HJ675435E3A6EA43432G5F37A635KJ8B";

            string givenPinPlaceholder = "{{pin}}";
            string givenMessageText = string.Format("Your PIN is {0}.", givenPinPlaceholder);
            int givenPinLength = 4;
            string givenPinType = "Alphanumeric";
            string givenLanguage = "En";
            string givenSenderId = "Infobip 2FA";
            string givenRepeatDtmf = "1#";
            double givenSpeechRate = 1;

            string expectedResponse = $@"
            [
                {{
                    ""pinPlaceholder"": ""{givenPinPlaceholder}"",
                    ""pinType"": ""{givenPinType}"",
                    ""messageText"": ""{givenMessageText}"",
                    ""pinLength"": {givenPinLength},
                    ""language"": ""{givenLanguage}"",
                    ""senderId"": ""{givenSenderId}"",
                    ""repeatDTMF"": ""{givenRepeatDtmf}"",
                    ""speechRate"": {givenSpeechRate}
                }}
            ]";

            SetUpGetRequest(TFA_TEMPLATES.Replace("{appId}", givenApplicationId), expectedResponse, 200);

            var tfaApi = new TfaApi(configuration);

            void AssertTfaGetTemplatesResponse(List<TfaMessage> tfaMessages)
            {
                Assert.IsNotNull(tfaMessages);
                var tfaMessage = tfaMessages[0];

                Assert.IsNotNull(tfaMessage);
                Assert.AreEqual(givenPinPlaceholder, tfaMessage.PinPlaceholder);
                Assert.AreEqual(givenMessageText, tfaMessage.MessageText);
                Assert.AreEqual(givenPinLength, tfaMessage.PinLength);
                Assert.AreEqual(Enum.Parse<TfaPinType>(givenPinType), tfaMessage.PinType);
                Assert.AreEqual(Enum.Parse<TfaLanguage>(givenLanguage), tfaMessage.Language);
                Assert.AreEqual(givenSenderId, tfaMessage.SenderId);
                Assert.AreEqual(givenRepeatDtmf, tfaMessage.RepeatDTMF);
                Assert.AreEqual(givenSpeechRate, tfaMessage.SpeechRate);
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

            string givenPinPlaceholder = "{{pin}}";
            string givenMessageText = string.Format("Your PIN is {0}.", givenPinPlaceholder);
            int givenPinLength = 4;
            string givenPinType = "Alphanumeric";
            string givenLanguage = "en";
            string givenSenderId = "Infobip 2FA";
            string givenRepeatDtmf = "1#";
            string givenSpeechRate = "1.0";

            string expectedRequest = $@"
            {{
                ""language"": ""{givenLanguage}"",
                ""pinType"": ""{givenPinType}"",
                ""messageText"": ""{givenMessageText}"",
                ""pinLength"": {givenPinLength},
                ""repeatDTMF"": ""{givenRepeatDtmf}"",
                ""senderId"": ""{givenSenderId}"",
                ""speechRate"": {givenSpeechRate}
            }}";

            string expectedResponse = $@"
            {{
                ""pinPlaceholder"": ""{givenPinPlaceholder}"",
                ""pinType"": ""{givenPinType}"",
                ""messageText"": ""{givenMessageText}"",
                ""pinLength"": {givenPinLength},
                ""language"": ""{givenLanguage}"",
                ""senderId"": ""{givenSenderId}"",
                ""repeatDTMF"": ""{givenRepeatDtmf}"",
                ""speechRate"": {givenSpeechRate}
            }}";

            SetUpPostRequest(TFA_TEMPLATES.Replace("{appId}", givenApplicationId), expectedRequest, expectedResponse, 200);

            var tfaApi = new TfaApi(configuration);

            var tfaCreateMessageRequest = new TfaCreateMessageRequest(
                language: Enum.Parse<TfaLanguage>(givenLanguage, true),
                messageText: givenMessageText,
                pinLength: givenPinLength,
                pinType: Enum.Parse<TfaPinType>(givenPinType, true),
                repeatDTMF: givenRepeatDtmf,
                senderId: givenSenderId,
                speechRate: double.Parse(givenSpeechRate, System.Globalization.CultureInfo.InvariantCulture)
            );

            void AssertTfaCreateTemplateResponse(TfaMessage tfaMessage)
            {
                Assert.IsNotNull(tfaMessage);
                Assert.AreEqual(givenPinPlaceholder, tfaMessage.PinPlaceholder);
                Assert.AreEqual(givenMessageText, tfaMessage.MessageText);
                Assert.AreEqual(givenPinLength, tfaMessage.PinLength);
                Assert.AreEqual(Enum.Parse<TfaPinType>(givenPinType, true), tfaMessage.PinType);
                Assert.AreEqual(Enum.Parse<TfaLanguage>(givenLanguage, true), tfaMessage.Language);
                Assert.AreEqual(givenSenderId, tfaMessage.SenderId);
                Assert.AreEqual(givenRepeatDtmf, tfaMessage.RepeatDTMF);
                Assert.AreEqual(double.Parse(givenSpeechRate, System.Globalization.CultureInfo.InvariantCulture), tfaMessage.SpeechRate);
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

            string givenPinPlaceholder = "{{pin}}";
            string givenMessageText = string.Format("Your PIN is {0}.", givenPinPlaceholder);
            int givenPinLength = 4;
            string givenPinType = "Alphanumeric";
            string givenLanguage = "En";
            string givenSenderId = "Infobip 2FA";
            string givenRepeatDtmf = "1#";
            double givenSpeechRate = 1.0;

            string expectedResponse = $@"
            {{
                ""pinPlaceholder"": ""{givenPinPlaceholder}"",
                ""pinType"": ""{givenPinType}"",
                ""messageText"": ""{givenMessageText}"",
                ""pinLength"": {givenPinLength},
                ""language"": ""{givenLanguage}"",
                ""senderId"": ""{givenSenderId}"",
                ""repeatDTMF"": ""{givenRepeatDtmf}"",
                ""speechRate"": {givenSpeechRate}
            }}";

            SetUpGetRequest(
                TFA_TEMPLATE.Replace("{appId}", givenApplicationId).Replace("{msgId}", givenMessageId),
                expectedResponse,
                200);

            var tfaApi = new TfaApi(configuration);

            void AssertTfaGetTemplateResponse(TfaMessage tfaMessage)
            {
                Assert.IsNotNull(tfaMessage);
                Assert.AreEqual(givenPinPlaceholder, tfaMessage.PinPlaceholder);
                Assert.AreEqual(givenMessageText, tfaMessage.MessageText);
                Assert.AreEqual(givenPinLength, tfaMessage.PinLength);
                Assert.AreEqual(Enum.Parse<TfaPinType>(givenPinType), tfaMessage.PinType);
                Assert.AreEqual(Enum.Parse<TfaLanguage>(givenLanguage), tfaMessage.Language);
                Assert.AreEqual(givenSenderId, tfaMessage.SenderId);
                Assert.AreEqual(givenRepeatDtmf, tfaMessage.RepeatDTMF);
                Assert.AreEqual(givenSpeechRate, tfaMessage.SpeechRate);
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

            string givenPinPlaceholder = "{{pin}}";
            string givenMessageText = string.Format("Your PIN is {0}.", givenPinPlaceholder);
            int givenPinLength = 4;
            string givenPinType = "Alphanumeric";
            string givenLanguage = "en";
            string givenSenderId = "Infobip 2FA";
            string givenRepeatDtmf = "1#";
            string givenSpeechRate = "1.0";

            string expectedRequest = $@"
            {{
                ""language"": ""{givenLanguage}"",
                ""pinType"": ""{givenPinType}"",
                ""messageText"": ""{givenMessageText}"",
                ""pinLength"": {givenPinLength},
                ""repeatDTMF"": ""{givenRepeatDtmf}"",
                ""senderId"": ""{givenSenderId}"",
                ""speechRate"": {givenSpeechRate}
            }}";


            string expectedResponse = $@"
            {{
                ""pinPlaceholder"": ""{givenPinPlaceholder}"",
                ""pinType"": ""{givenPinType}"",
                ""messageText"": ""{givenMessageText}"",
                ""pinLength"": {givenPinLength},
                ""language"": ""{givenLanguage}"",
                ""senderId"": ""{givenSenderId}"",
                ""repeatDTMF"": ""{givenRepeatDtmf}"",
                ""speechRate"": {givenSpeechRate}
            }}";

            SetUpPutRequest(
                TFA_TEMPLATE.Replace("{appId}", givenApplicationId).Replace("{msgId}", givenMessageId),
                expectedRequest,
                expectedResponse,
                200);

            var tfaApi = new TfaApi(configuration);

            var tfaUpdateMessageRequest = new TfaUpdateMessageRequest(
                language: Enum.Parse<TfaLanguage>(givenLanguage, true),
                messageText: givenMessageText,
                pinLength: givenPinLength,
                pinType: Enum.Parse<TfaPinType>(givenPinType, true),
                repeatDTMF: givenRepeatDtmf,
                senderId: givenSenderId,
                speechRate: double.Parse(givenSpeechRate, System.Globalization.CultureInfo.InvariantCulture)
            );

            void AssertTfaUpdateTemplateResponse(TfaMessage tfaMessage)
            {
                Assert.IsNotNull(tfaMessage);
                Assert.AreEqual(givenPinPlaceholder, tfaMessage.PinPlaceholder);
                Assert.AreEqual(givenMessageText, tfaMessage.MessageText);
                Assert.AreEqual(givenPinLength, tfaMessage.PinLength);
                Assert.AreEqual(Enum.Parse<TfaPinType>(givenPinType, true), tfaMessage.PinType);
                Assert.AreEqual(Enum.Parse<TfaLanguage>(givenLanguage, true), tfaMessage.Language);
                Assert.AreEqual(givenSenderId, tfaMessage.SenderId);
                Assert.AreEqual(givenRepeatDtmf, tfaMessage.RepeatDTMF);
                Assert.AreEqual(double.Parse(givenSpeechRate, System.Globalization.CultureInfo.InvariantCulture), tfaMessage.SpeechRate);
            }

            AssertResponse(tfaApi.UpdateTfaMessageTemplate(givenApplicationId, givenMessageId, tfaUpdateMessageRequest), AssertTfaUpdateTemplateResponse);
            AssertResponse(tfaApi.UpdateTfaMessageTemplateAsync(givenApplicationId, givenMessageId, tfaUpdateMessageRequest).Result, AssertTfaUpdateTemplateResponse);

            AssertResponseWithHttpInfo(tfaApi.UpdateTfaMessageTemplateWithHttpInfo(givenApplicationId, givenMessageId, tfaUpdateMessageRequest), AssertTfaUpdateTemplateResponse);
            AssertResponseWithHttpInfo(tfaApi.UpdateTfaMessageTemplateWithHttpInfoAsync(givenApplicationId, givenMessageId, tfaUpdateMessageRequest).Result, AssertTfaUpdateTemplateResponse);
        }

        [TestMethod]
        public void ShouldCreateTfaEmailMessageTemplateTest()
        {
            TfaPinType givenPinType = TfaPinType.Numeric;
            int givenPinLength = 4;
            string givenFrom = "company@example.com";
            int givenEmailTemplateId = 1234;

            string givenMessageId = "9C815F8AF3328";
            string givenApplicationId = "HJ675435E3A6EA43432G5F37A635KJ8B";

            string expectedRequest = $@"
            {{
                ""pinType"": ""{givenPinType}"",
                ""pinLength"": {givenPinLength},
                ""from"": ""{givenFrom}"",
                ""emailTemplateId"": {givenEmailTemplateId}
            }}";

            string expectedResponse = $@"
            {{
                ""messageId"": ""{givenMessageId}"",
                ""applicationId"": ""{givenApplicationId}"",
                ""pinLength"": {givenPinLength},
                ""pinType"": ""{givenPinType}"",
                ""from"": ""{givenFrom}"",
                ""emailTemplateId"": {givenEmailTemplateId}
            }}";

            SetUpPostRequest(TFA_EMAIL_TEMPLATES.Replace("{appId}", givenApplicationId), expectedRequest, expectedResponse, 200);

            var tfaApi = new TfaApi(configuration);

            var tfaCreateEmailMessageRequest = new TfaCreateEmailMessageRequest(
                    pinType: givenPinType,
                    pinLength: givenPinLength,
                    from: givenFrom,
                    emailTemplateId: givenEmailTemplateId
                );

            void AssertTfaCreateEmailMessageResponse(TfaEmailMessage tfaEmailMessage) {
                Assert.IsNotNull(tfaEmailMessage);
                Assert.AreEqual(tfaEmailMessage.MessageId, givenMessageId);
                Assert.AreEqual(tfaEmailMessage.ApplicationId, givenApplicationId);
                Assert.AreEqual(tfaEmailMessage.PinLength, givenPinLength);
                Assert.AreEqual(tfaEmailMessage.PinType, givenPinType);
                Assert.AreEqual(tfaEmailMessage.From, givenFrom);
                Assert.AreEqual(tfaEmailMessage.EmailTemplateId, givenEmailTemplateId);
            }

            AssertResponse(tfaApi.CreateTfaEmailMessageTemplate(givenApplicationId, tfaCreateEmailMessageRequest), AssertTfaCreateEmailMessageResponse);
            AssertResponse(tfaApi.CreateTfaEmailMessageTemplateAsync(givenApplicationId, tfaCreateEmailMessageRequest).Result, AssertTfaCreateEmailMessageResponse);

            AssertResponseWithHttpInfo(tfaApi.CreateTfaEmailMessageTemplateWithHttpInfo(givenApplicationId, tfaCreateEmailMessageRequest), AssertTfaCreateEmailMessageResponse);
            AssertResponseWithHttpInfo(tfaApi.CreateTfaEmailMessageTemplateWithHttpInfoAsync(givenApplicationId, tfaCreateEmailMessageRequest).Result, AssertTfaCreateEmailMessageResponse);

        }

        [TestMethod]
        public void ShouldUpdateTfaEmailMessageTemplateTest()
        {
            TfaPinType givenPinType = TfaPinType.Numeric;
            int givenPinLength = 4;
            string givenFrom = "company@example.com";
            int givenEmailTemplateId = 1234;

            string givenMessageId = "9C815F8AF3328";
            string givenApplicationId = "HJ675435E3A6EA43432G5F37A635KJ8B";

            string expectedRequest = $@"
            {{
                ""pinType"": ""{givenPinType}"",
                ""pinLength"": {givenPinLength},
                ""from"": ""{givenFrom}"",
                ""emailTemplateId"": {givenEmailTemplateId}
            }}";

            string expectedResponse = $@"
            {{
                ""messageId"": ""{givenMessageId}"",
                ""applicationId"": ""{givenApplicationId}"",
                ""pinLength"": {givenPinLength},
                ""pinType"": ""{givenPinType}"",
                ""from"": ""{givenFrom}"",
                ""emailTemplateId"": {givenEmailTemplateId}
            }}";

            SetUpPutRequest(TFA_EMAIL_TEMPLATE.Replace("{appId}", givenApplicationId).Replace("{msgId}", givenMessageId), expectedRequest, expectedResponse, 200);

            var tfaApi = new TfaApi(configuration);

            var tfaUpdateEmailMessageRequest = new TfaUpdateEmailMessageRequest(
                    pinType: givenPinType,
                    pinLength: givenPinLength,
                    from: givenFrom,
                    emailTemplateId: givenEmailTemplateId
                );

            void AssertTfaUpdateEmailMessageResponse(TfaEmailMessage tfaEmailMessage)
            {
                Assert.IsNotNull(tfaEmailMessage);
                Assert.AreEqual(tfaEmailMessage.MessageId, givenMessageId);
                Assert.AreEqual(tfaEmailMessage.ApplicationId, givenApplicationId);
                Assert.AreEqual(tfaEmailMessage.PinLength, givenPinLength);
                Assert.AreEqual(tfaEmailMessage.PinType, givenPinType);
                Assert.AreEqual(tfaEmailMessage.From, givenFrom);
                Assert.AreEqual(tfaEmailMessage.EmailTemplateId, givenEmailTemplateId);
            }

            AssertResponse(tfaApi.UpdateTfaEmailMessageTemplate(givenApplicationId, givenMessageId, tfaUpdateEmailMessageRequest), AssertTfaUpdateEmailMessageResponse);
            AssertResponse(tfaApi.UpdateTfaEmailMessageTemplateAsync(givenApplicationId, givenMessageId, tfaUpdateEmailMessageRequest).Result, AssertTfaUpdateEmailMessageResponse);

            AssertResponseWithHttpInfo(tfaApi.UpdateTfaEmailMessageTemplateWithHttpInfo(givenApplicationId, givenMessageId, tfaUpdateEmailMessageRequest), AssertTfaUpdateEmailMessageResponse);
            AssertResponseWithHttpInfo(tfaApi.UpdateTfaEmailMessageTemplateWithHttpInfoAsync(givenApplicationId, givenMessageId, tfaUpdateEmailMessageRequest).Result, AssertTfaUpdateEmailMessageResponse);
        }

        [TestMethod]
        public void ShouldSendTfaPinCodeViaSmsTest()
        {
            string givenApplicationId = "1234567";
            string givenMessageId = "7654321";
            string givenFrom = "Sender 1";
            string givenFirstName = "John";

            string givenPinId = "9C817C6F8AF3D48F9FE553282AFA2B67";
            string givenTo = "41793026727";
            string givenNcStatus = "NC_DESTINATION_REACHABLE";
            string givenSmsStatus = "MESSAGE_SENT";

            string expectedRequest = $@"
            {{
                ""applicationId"": ""{givenApplicationId}"",
                ""messageId"": ""{givenMessageId}"",
                ""from"": ""{givenFrom}"",
                ""to"": ""{givenTo}"",
                ""placeholders"": {{
                    ""firstName"": ""{givenFirstName}""
                }}
            }}";

            string expectedResponse = $@"
            {{
                ""pinId"": ""{givenPinId}"",
                ""to"": ""{givenTo}"",
                ""ncStatus"": ""{givenNcStatus}"",
                ""smsStatus"": ""{givenSmsStatus}""
            }}";

            SetUpPostRequest(TFA_SEND_PIN, expectedRequest, expectedResponse, 200);

            var tfaApi = new TfaApi(configuration);

            var givenPlaceholders = new Dictionary<string, string> { { "firstName", givenFirstName } };
            var tfaStartAuthenticationRequest = new TfaStartAuthenticationRequest(
                applicationId: givenApplicationId,
                from: givenFrom,
                messageId: givenMessageId,
                placeholders: givenPlaceholders,
                to: givenTo
            );

            void AssertTfaStartAuthenticationResponse(TfaStartAuthenticationResponse tfaStartAuthenticationResponse)
            {
                Assert.IsNotNull(tfaStartAuthenticationResponse);
                Assert.AreEqual(givenPinId, tfaStartAuthenticationResponse.PinId);
                Assert.AreEqual(givenTo, tfaStartAuthenticationResponse.To);
                Assert.AreEqual(givenNcStatus, tfaStartAuthenticationResponse.NcStatus);
                Assert.AreEqual(givenSmsStatus, tfaStartAuthenticationResponse.SmsStatus);
            }

            AssertResponse(tfaApi.SendTfaPinCodeOverSms(ncNeeded: null, tfaStartAuthenticationRequest: tfaStartAuthenticationRequest), AssertTfaStartAuthenticationResponse);
            AssertResponse(tfaApi.SendTfaPinCodeOverSmsAsync(ncNeeded: null, tfaStartAuthenticationRequest: tfaStartAuthenticationRequest).Result, AssertTfaStartAuthenticationResponse);

            AssertResponseWithHttpInfo(tfaApi.SendTfaPinCodeOverSmsWithHttpInfo(ncNeeded: null, tfaStartAuthenticationRequest: tfaStartAuthenticationRequest), AssertTfaStartAuthenticationResponse);
            AssertResponseWithHttpInfo(tfaApi.SendTfaPinCodeOverSmsWithHttpInfoAsync(ncNeeded: null, tfaStartAuthenticationRequest: tfaStartAuthenticationRequest).Result, AssertTfaStartAuthenticationResponse);
        }

        [TestMethod]
        public void ShouldResendTfaPinCodeViaSmsTest()
        {
            string givenFirstName = "John";

            string givenPinId = "9C817C6F8AF3D48F9FE553282AFA2B67";
            string givenTo = "41793026727";
            string givenNcStatus = "NC_DESTINATION_REACHABLE";
            string givenSmsStatus = "MESSAGE_SENT";

            string expectedRequest = $@"
            {{
                ""placeholders"": {{
                    ""firstName"": ""{givenFirstName}""
                }}
            }}";

            string expectedResponse = $@"
            {{
                ""pinId"": ""{givenPinId}"",
                ""to"": ""{givenTo}"",
                ""ncStatus"": ""{givenNcStatus}"",
                ""smsStatus"": ""{givenSmsStatus}""
            }}";

            SetUpPostRequest(TFA_RESEND_PIN.Replace("{pinId}", givenPinId), expectedRequest, expectedResponse, 200);

            var tfaApi = new TfaApi(configuration);

            var tfaResendPinRequest = new TfaResendPinRequest()
            {
                Placeholders = new Dictionary<string, string> { { "firstName", givenFirstName } }
            };

            void AssertTfaStartAuthenticationResponse(TfaStartAuthenticationResponse tfaStartAuthenticationResponse)
            {
                Assert.IsNotNull(tfaStartAuthenticationResponse);
                Assert.AreEqual(givenPinId, tfaStartAuthenticationResponse.PinId);
                Assert.AreEqual(givenTo, tfaStartAuthenticationResponse.To);
                Assert.AreEqual(givenNcStatus, tfaStartAuthenticationResponse.NcStatus);
                Assert.AreEqual(givenSmsStatus, tfaStartAuthenticationResponse.SmsStatus);
            }

            AssertResponse(tfaApi.ResendTfaPinCodeOverSms(givenPinId, tfaResendPinRequest), AssertTfaStartAuthenticationResponse);
            AssertResponse(tfaApi.ResendTfaPinCodeOverSmsAsync(givenPinId, tfaResendPinRequest).Result, AssertTfaStartAuthenticationResponse);

            AssertResponseWithHttpInfo(tfaApi.ResendTfaPinCodeOverSmsWithHttpInfo(givenPinId, tfaResendPinRequest), AssertTfaStartAuthenticationResponse);
            AssertResponseWithHttpInfo(tfaApi.ResendTfaPinCodeOverSmsWithHttpInfoAsync(givenPinId, tfaResendPinRequest).Result, AssertTfaStartAuthenticationResponse);
        }

        [TestMethod]
        public void ShouldSendTfaPinCodeViaVoiceTest()
        {
            string givenApplicationId = "1234567";
            string givenMessageId = "7654321";
            string givenFrom = "Sender 1";
            string givenFirstName = "John";

            string givenPinId = "9C817C6F8AF3D48F9FE553282AFA2B67";
            string givenTo = "41793026727";
            string givenCallStatus = "PENDING_ACCEPTED";

            string expectedRequest = $@"
            {{
                ""applicationId"": ""{givenApplicationId}"",
                ""messageId"": ""{givenMessageId}"",
                ""from"": ""{givenFrom}"",
                ""to"": ""{givenTo}"",
                ""placeholders"": {{
                    ""firstName"": ""{givenFirstName}""
                }}
            }}";

            string expectedResponse = $@"
            {{
                ""pinId"": ""{givenPinId}"",
                ""to"": ""{givenTo}"",
                ""callStatus"": ""{givenCallStatus}""
            }}";

            SetUpPostRequest(TFA_SEND_PIN_VOICE, expectedRequest, expectedResponse, 200);

            var tfaApi = new TfaApi(configuration);

            var givenPlaceholders = new Dictionary<string, string> { { "firstName", givenFirstName } };
            var tfaStartAuthenticationRequest = new TfaStartAuthenticationRequest(
                applicationId: givenApplicationId,
                from: givenFrom,
                messageId: givenMessageId,
                placeholders: givenPlaceholders,
                to: givenTo
            );

            void AssertTfaStartAuthenticationResponse(TfaStartAuthenticationResponse tfaStartAuthenticationResponse)
            {
                Assert.IsNotNull(tfaStartAuthenticationResponse);
                Assert.AreEqual(givenPinId, tfaStartAuthenticationResponse.PinId);
                Assert.AreEqual(givenTo, tfaStartAuthenticationResponse.To);
                Assert.AreEqual(givenCallStatus, tfaStartAuthenticationResponse.CallStatus);
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

            string givenPinId = "9C817C6F8AF3D48F9FE553282AFA2B67";
            string givenTo = "41793026727";
            string givenCallStatus = "MESSAGE_SENT";

            string expectedRequest = $@"
            {{
                ""placeholders"": {{
                    ""firstName"": ""{givenFirstName}""
                }}
            }}";

            string expectedResponse = $@"
            {{
                ""pinId"": ""{givenPinId}"",
                ""to"": {givenTo},
                ""callStatus"": ""{givenCallStatus}""
            }}";

            SetUpPostRequest(TFA_RESEND_PIN_VOICE.Replace("{pinId}", givenPinId), expectedRequest, expectedResponse, 200);

            var tfaApi = new TfaApi(configuration);

            var tfaResendPinRequest = new TfaResendPinRequest()
            {
                Placeholders = new Dictionary<string, string> { { "firstName", givenFirstName } }
            };

            void AssertTfaStartAuthenticationResponse(TfaStartAuthenticationResponse tfaStartAuthenticationResponse)
            {
                Assert.IsNotNull(tfaStartAuthenticationResponse);
                Assert.AreEqual(givenPinId, tfaStartAuthenticationResponse.PinId);
                Assert.AreEqual(givenTo, tfaStartAuthenticationResponse.To);
                Assert.AreEqual(givenCallStatus, tfaStartAuthenticationResponse.CallStatus);
            }

            AssertResponse(tfaApi.ResendTfaPinCodeOverVoice(givenPinId, tfaResendPinRequest), AssertTfaStartAuthenticationResponse); ;
            AssertResponse(tfaApi.ResendTfaPinCodeOverVoiceAsync(givenPinId, tfaResendPinRequest).Result, AssertTfaStartAuthenticationResponse);

            AssertResponseWithHttpInfo(tfaApi.ResendTfaPinCodeOverVoiceWithHttpInfo(givenPinId, tfaResendPinRequest), AssertTfaStartAuthenticationResponse);
            AssertResponseWithHttpInfo(tfaApi.ResendTfaPinCodeOverVoiceWithHttpInfoAsync(givenPinId, tfaResendPinRequest).Result, AssertTfaStartAuthenticationResponse);
        }

        [TestMethod]
        public void ShouldSendTfaPinCodeViaEmailTest()
        {
            string givenApplicationId = "1234567";
            string givenMessageId = "7654321";
            string givenTo = "john.smith@example.com";
            string givenFirstName = "John";

            string givenPinId = "9C817C6F8AF3D48F9FE553282AFA2B67";
            string givenEmailStatusName = "PENDING_ACCEPTED";
            string givenEmailStatusDescription = "Message accepted, pending for delivery.";
            

            string expectedRequest = $@"
            {{
                ""applicationId"": ""{givenApplicationId}"",
                ""messageId"": ""{givenMessageId}"",
                ""to"": ""{givenTo}"",
                ""placeholders"": {{
                    ""firstName"": ""{givenFirstName}""
                }}
            }}";

            string expectedResponse = $@"
            {{
                ""pinId"": ""{givenPinId}"",
                ""to"": ""{givenTo}"",
                ""emailStatus"": {{
                    ""name"": ""{givenEmailStatusName}"",
                    ""description"": ""{givenEmailStatusDescription}""
                }}
            }}";

            SetUpPostRequest(TFA_SEND_PIN_EMAIL, expectedRequest, expectedResponse, 200);

            var tfaApi = new TfaApi(configuration);

            var givenPlaceholders = new Dictionary<string, string> { { "firstName", givenFirstName } };

            var tfaStartEmailAuthenticationRequest = new TfaStartEmailAuthenticationRequest(
                    applicationId: givenApplicationId,
                    messageId: givenMessageId,
                    to: givenTo,
                    placeholders: givenPlaceholders
                );

            void AssertTfaStartEmailAuthenticationResponse(TfaStartEmailAuthenticationResponse tfaStartEmailAuthenticationResponse)
            {
                Assert.IsNotNull(tfaStartEmailAuthenticationRequest);
                Assert.AreEqual(givenPinId, tfaStartEmailAuthenticationResponse.PinId);
                Assert.AreEqual(givenTo, tfaStartEmailAuthenticationResponse.To);
                Assert.AreEqual(givenEmailStatusName, tfaStartEmailAuthenticationResponse.EmailStatus.Name);
                Assert.AreEqual(givenEmailStatusDescription, tfaStartEmailAuthenticationResponse.EmailStatus.Description);
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

            string givenPinId = "9C817C6F8AF3D48F9FE553282AFA2B67";
            string givenTo = "john.smith@example.com";
            string givenEmailStatusName = "PENDING_ACCEPTED";
            string givenEmailStatusDescription = "Message accepted, pending for delivery.";

            string expectedRequest = $@"
            {{
                ""placeholders"": {{
                    ""firstName"": ""{givenFirstName}""
                }}
            }}";

            string expectedResponse = $@"
            {{
                ""pinId"": ""{givenPinId}"",
                ""to"": ""{givenTo}"",
                ""emailStatus"": {{
                    ""name"": ""{givenEmailStatusName}"",
                    ""description"": ""{givenEmailStatusDescription}""
                }}
            }}";

            SetUpPostRequest(TFA_RESEND_PIN_EMAIL.Replace("{pinId}", givenPinId), expectedRequest, expectedResponse, 200);

            var tfaApi = new TfaApi(configuration);

            var tfaResendPinRequest = new TfaResendPinRequest()
            {
                Placeholders = new Dictionary<string, string> { { "firstName", givenFirstName } }
            };

            void AssertTfaStartAuthenticationResponse(TfaStartEmailAuthenticationResponse tfaStartEmailAuthenticationResponse)
            {
                Assert.IsNotNull(tfaStartEmailAuthenticationResponse);
                Assert.AreEqual(givenPinId, tfaStartEmailAuthenticationResponse.PinId);
                Assert.AreEqual(givenTo, tfaStartEmailAuthenticationResponse.To);
                Assert.AreEqual(givenEmailStatusName, tfaStartEmailAuthenticationResponse.EmailStatus.Name);
                Assert.AreEqual(givenEmailStatusDescription, tfaStartEmailAuthenticationResponse.EmailStatus.Description);
            }

            AssertResponse(tfaApi.Resend2faPinCodeOverEmail(givenPinId, tfaResendPinRequest), AssertTfaStartAuthenticationResponse); ;
            AssertResponse(tfaApi.Resend2faPinCodeOverEmailAsync(givenPinId, tfaResendPinRequest).Result, AssertTfaStartAuthenticationResponse);

            AssertResponseWithHttpInfo(tfaApi.Resend2faPinCodeOverEmailWithHttpInfo(givenPinId, tfaResendPinRequest), AssertTfaStartAuthenticationResponse);
            AssertResponseWithHttpInfo(tfaApi.Resend2faPinCodeOverEmailWithHttpInfoAsync(givenPinId, tfaResendPinRequest).Result, AssertTfaStartAuthenticationResponse);
        }

        [TestMethod]
        public void ShouldVerifyTfaCallTest()
        {
            string givenPin = "1598";

            string givenPinId = "9C817C6F8AF3D48F9FE553282AFA2B68";
            string givenMsisdn = "41793026726";
            string givenVerified = "true";
            int givenAttemptsRemaining = 0;

            string expectedRequest = $@"
            {{
                ""pin"": ""{givenPin}""
            }}";

            string expectedResponse = $@"
            {{
                ""pinId"": ""{givenPinId}"",
                ""msisdn"": ""{givenMsisdn}"",
                ""verified"": {givenVerified},
                ""attemptsRemaining"": {givenAttemptsRemaining}
            }}";

            SetUpPostRequest(TFA_VERIFY_PIN.Replace("{pinId}", givenPinId), expectedRequest, expectedResponse, 200);

            var tfaApi = new TfaApi(configuration);

            var tfaVerifyPinRequest = new TfaVerifyPinRequest(givenPin);

            void AssertTfaVerifyPinResponse(TfaVerifyPinResponse tfaVerifyPinResponse)
            {
                Assert.IsNotNull(tfaVerifyPinResponse);
                Assert.AreEqual(givenPinId, tfaVerifyPinResponse.PinId);
                Assert.AreEqual(givenMsisdn, tfaVerifyPinResponse.Msisdn);
                Assert.AreEqual(bool.Parse(givenVerified), tfaVerifyPinResponse.Verified);
                Assert.AreEqual(givenAttemptsRemaining, tfaVerifyPinResponse.AttemptsRemaining);
            }

            AssertResponse(tfaApi.VerifyTfaPhoneNumber(givenPinId, tfaVerifyPinRequest), AssertTfaVerifyPinResponse); ;
            AssertResponse(tfaApi.VerifyTfaPhoneNumberAsync(givenPinId, tfaVerifyPinRequest).Result, AssertTfaVerifyPinResponse);

            AssertResponseWithHttpInfo(tfaApi.VerifyTfaPhoneNumberWithHttpInfo(givenPinId, tfaVerifyPinRequest), AssertTfaVerifyPinResponse);
            AssertResponseWithHttpInfo(tfaApi.VerifyTfaPhoneNumberWithHttpInfoAsync(givenPinId, tfaVerifyPinRequest).Result, AssertTfaVerifyPinResponse);
        }

        [TestMethod]
        public void ShouldGetTfaVerificationStatusTest()
        {
            string givenApplicationId = "16A8B5FE2BCD6CA716A2D780CB3F3390";
            string givenMsisdn = "41793026726";

            string givenVerified1 = "true";
            long givenVerifiedAt1 = 1418364366L;
            long givenSentAt1 = 1418364246L;

            string givenVerified2 = "false";
            long givenVerifiedAt2 = 1418364226L;
            long givenSentAt2 = 1418333246L;

            string expectedResponse = $@"
            {{
                ""verifications"": [
                    {{
                        ""msisdn"": ""{givenMsisdn}"",
                        ""verified"": {givenVerified1},
                        ""verifiedAt"": {givenVerifiedAt1},
                        ""sentAt"": {givenSentAt1}
                    }},
                    {{
                        ""msisdn"": ""{givenMsisdn}"",
                        ""verified"": {givenVerified2},
                        ""verifiedAt"": {givenVerifiedAt2},
                        ""sentAt"": {givenSentAt2}
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
                Assert.AreEqual(givenMsisdn, tfaVerification1.Msisdn);
                Assert.AreEqual(bool.Parse(givenVerified1), tfaVerification1.Verified);
                Assert.AreEqual(givenVerifiedAt1, tfaVerification1.VerifiedAt);
                Assert.AreEqual(givenSentAt1, tfaVerification1.SentAt);

                var tfaVerification2 = tfaVerificationResponse.Verifications[1];
                Assert.AreEqual(givenMsisdn, tfaVerification2.Msisdn);
                Assert.AreEqual(bool.Parse(givenVerified2), tfaVerification2.Verified);
                Assert.AreEqual(givenVerifiedAt2, tfaVerification2.VerifiedAt);
                Assert.AreEqual(givenSentAt2, tfaVerification2.SentAt);
            }

            AssertResponse(tfaApi.GetTfaVerificationStatus(givenMsisdn, givenApplicationId), AssertTfaVerificationResponse); ;
            AssertResponse(tfaApi.GetTfaVerificationStatusAsync(givenMsisdn, givenApplicationId).Result, AssertTfaVerificationResponse);

            AssertResponseWithHttpInfo(tfaApi.GetTfaVerificationStatusWithHttpInfo(givenMsisdn, givenApplicationId), AssertTfaVerificationResponse);
            AssertResponseWithHttpInfo(tfaApi.GetTfaVerificationStatusWithHttpInfoAsync(givenMsisdn, givenApplicationId).Result, AssertTfaVerificationResponse);
        }
    }
}