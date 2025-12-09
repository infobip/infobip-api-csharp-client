using System.Globalization;
using Infobip.Api.Client.Api;
using Infobip.Api.Client.Model;

namespace ApiClient.Tests.Api;

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
        var expectedApplicationId1 = "0933F3BC087D2A617AC6DCB2EF5B8A61";
        var expectedGetApplicationName1 = "Test application BASIC 1";
        var expectedGetApplicationPinAttempts1 = 10;
        var expectedAllowMultiplePinVerifications1 = "true";
        var expectedGetApplicationPinTimeToLive1 = "2h";
        var expectedGetApplicationVerifyPinLimit1 = "1/3s";
        var expectedGetApplicationSendPinPerApplicationLimit1 = "10000/1d";
        var expectedGetApplicationSendPinPerPhoneNumberLimit1 = "3/1d";
        var expectedEnabled1 = "true";

        var expectedApplicationId2 = "5F04FACFAA4978F62FCAEBA97B37E90F";
        var expectedGetApplicationName2 = "Test application BASIC 2";
        var expectedGetApplicationPinAttempts2 = 12;
        var expectedAllowMultiplePinVerifications2 = "true";
        var expectedGetApplicationPinTimeToLive2 = "10m";
        var expectedGetApplicationVerifyPinLimit2 = "2/1s";
        var expectedGetApplicationSendPinPerApplicationLimit2 = "10000/1d";
        var expectedGetApplicationSendPinPerPhoneNumberLimit2 = "5/1h";
        var expectedEnabled2 = "true";

        var expectedApplicationId3 = "B450F966A8EF017180F148AF22C42642";
        var expectedGetApplicationName3 = "Test application BASIC 3";
        var expectedGetApplicationPinAttempts3 = 15;
        var expectedAllowMultiplePinVerifications3 = "true";
        var expectedGetApplicationPinTimeToLive3 = "1h";
        var expectedGetApplicationVerifyPinLimit3 = "30/10s";
        var expectedGetApplicationSendPinPerApplicationLimit3 = "10000/3d";
        var expectedGetApplicationSendPinPerPhoneNumberLimit3 = "10/20m";
        var expectedEnabled3 = "true";

        var expectedResponse = $@"
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

        SetUpGetRequest(TFA_APPLICATIONS, 200, expectedResponse);

        var tfaApi = new TfaApi(Configuration);

        void AssertTfaGetApplicationsResponse(List<TfaApplicationResponse> tfaApplicationResponses)
        {
            Assert.IsNotNull(tfaApplicationResponses);
            Assert.IsTrue(tfaApplicationResponses.Count.Equals(3));

            var tfaApplicationResponse1 = tfaApplicationResponses[0];
            Assert.IsNotNull(tfaApplicationResponse1);
            Assert.AreEqual(expectedApplicationId1, tfaApplicationResponse1.ApplicationId);
            Assert.AreEqual(expectedGetApplicationName1, tfaApplicationResponse1.Name);
            Assert.AreEqual(expectedGetApplicationPinAttempts1, tfaApplicationResponse1.VarConfiguration.PinAttempts);
            Assert.AreEqual(bool.Parse(expectedAllowMultiplePinVerifications1),
                tfaApplicationResponse1.VarConfiguration.AllowMultiplePinVerifications);
            Assert.AreEqual(expectedGetApplicationPinTimeToLive1,
                tfaApplicationResponse1.VarConfiguration.PinTimeToLive);
            Assert.AreEqual(expectedGetApplicationVerifyPinLimit1,
                tfaApplicationResponse1.VarConfiguration.VerifyPinLimit);
            Assert.AreEqual(expectedGetApplicationSendPinPerApplicationLimit1,
                tfaApplicationResponse1.VarConfiguration.SendPinPerApplicationLimit);
            Assert.AreEqual(expectedGetApplicationSendPinPerPhoneNumberLimit1,
                tfaApplicationResponse1.VarConfiguration.SendPinPerPhoneNumberLimit);

            var tfaApplicationResponse2 = tfaApplicationResponses[1];
            Assert.IsNotNull(tfaApplicationResponse2);
            Assert.AreEqual(expectedApplicationId2, tfaApplicationResponse2.ApplicationId);
            Assert.AreEqual(expectedGetApplicationName2, tfaApplicationResponse2.Name);
            Assert.AreEqual(expectedGetApplicationPinAttempts2, tfaApplicationResponse2.VarConfiguration.PinAttempts);
            Assert.AreEqual(bool.Parse(expectedAllowMultiplePinVerifications2),
                tfaApplicationResponse2.VarConfiguration.AllowMultiplePinVerifications);
            Assert.AreEqual(expectedGetApplicationPinTimeToLive2,
                tfaApplicationResponse2.VarConfiguration.PinTimeToLive);
            Assert.AreEqual(expectedGetApplicationVerifyPinLimit2,
                tfaApplicationResponse2.VarConfiguration.VerifyPinLimit);
            Assert.AreEqual(expectedGetApplicationSendPinPerApplicationLimit2,
                tfaApplicationResponse2.VarConfiguration.SendPinPerApplicationLimit);
            Assert.AreEqual(expectedGetApplicationSendPinPerPhoneNumberLimit2,
                tfaApplicationResponse2.VarConfiguration.SendPinPerPhoneNumberLimit);

            var tfaApplicationResponse3 = tfaApplicationResponses[2];
            Assert.IsNotNull(tfaApplicationResponse3);
            Assert.AreEqual(expectedApplicationId3, tfaApplicationResponse3.ApplicationId);
            Assert.AreEqual(expectedGetApplicationName3, tfaApplicationResponse3.Name);
            Assert.AreEqual(expectedGetApplicationPinAttempts3, tfaApplicationResponse3.VarConfiguration.PinAttempts);
            Assert.AreEqual(bool.Parse(expectedAllowMultiplePinVerifications3),
                tfaApplicationResponse3.VarConfiguration.AllowMultiplePinVerifications);
            Assert.AreEqual(expectedGetApplicationPinTimeToLive3,
                tfaApplicationResponse3.VarConfiguration.PinTimeToLive);
            Assert.AreEqual(expectedGetApplicationVerifyPinLimit3,
                tfaApplicationResponse3.VarConfiguration.VerifyPinLimit);
            Assert.AreEqual(expectedGetApplicationSendPinPerApplicationLimit3,
                tfaApplicationResponse3.VarConfiguration.SendPinPerApplicationLimit);
            Assert.AreEqual(expectedGetApplicationSendPinPerPhoneNumberLimit3,
                tfaApplicationResponse3.VarConfiguration.SendPinPerPhoneNumberLimit);
        }

        AssertResponse(tfaApi.GetTfaApplications(), AssertTfaGetApplicationsResponse);
        AssertResponse(tfaApi.GetTfaApplicationsAsync().Result, AssertTfaGetApplicationsResponse);

        AssertResponseWithHttpInfo(tfaApi.GetTfaApplicationsWithHttpInfo(), AssertTfaGetApplicationsResponse, 200);
        AssertResponseWithHttpInfo(tfaApi.GetTfaApplicationsWithHttpInfoAsync().Result,
            AssertTfaGetApplicationsResponse, 200);
    }

    [TestMethod]
    public void ShouldCreateTfaApplicationTest()
    {
        var expectedApplicationId = "1234567";
        var expectedCreateApplicationName = "2fa application name";
        var expectedCreateApplicationPinAttempts = 5;
        var expectedAllowMultiplePinVerifications = "true";
        var expectedCreateApplicationPinTimeToLive = "10m";
        var expectedCreateApplicationVerifyPinLimit = "2/4s";
        var expectedCreateApplicationSendPinPerApplicationLimit = "5000/12h";
        var expectedCreateApplicationSendPinPerPhoneNumberLimit = "2/1d";
        var expectedEnabled = "true";

        var givenRequest = $@"
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

        var expectedResponse = $@"
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

        SetUpPostRequest(TFA_APPLICATIONS, 200, givenRequest, expectedResponse);

        var tfaApi = new TfaApi(Configuration);

        var tfaApplicationConfiguration = new TfaApplicationConfiguration
        {
            PinAttempts = expectedCreateApplicationPinAttempts,
            AllowMultiplePinVerifications = bool.Parse(expectedAllowMultiplePinVerifications),
            PinTimeToLive = expectedCreateApplicationPinTimeToLive,
            VerifyPinLimit = expectedCreateApplicationVerifyPinLimit,
            SendPinPerApplicationLimit = expectedCreateApplicationSendPinPerApplicationLimit,
            SendPinPerPhoneNumberLimit = expectedCreateApplicationSendPinPerPhoneNumberLimit
        };

        var tfaApplicationRequest = new TfaApplicationRequest(
            tfaApplicationConfiguration,
            bool.Parse(expectedEnabled),
            expectedCreateApplicationName
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
        AssertResponse(tfaApi.CreateTfaApplicationAsync(tfaApplicationRequest).Result,
            AssertTfaCreateApplicationResponse);

        AssertResponseWithHttpInfo(tfaApi.CreateTfaApplicationWithHttpInfo(tfaApplicationRequest),
            AssertTfaCreateApplicationResponse, 200);
        AssertResponseWithHttpInfo(tfaApi.CreateTfaApplicationWithHttpInfoAsync(tfaApplicationRequest).Result,
            AssertTfaCreateApplicationResponse, 200);
    }

    [TestMethod]
    public void ShouldGetTfaApplicationTest()
    {
        var expectedApplicationId = "1234567";
        var expectedGetApplicationName = "2fa application name";
        var expectedGetApplicationPinAttempts = 5;
        var expectedAllowMultiplePinVerifications = "true";
        var expectedGetApplicationPinTimeToLive = "10m";
        var expectedGetApplicationVerifyPinLimit = "2/4s";
        var expectedGetApplicationSendPinPerApplicationLimit = "5000/12h";
        var expectedGetApplicationSendPinPerPhoneNumberLimit = "2/1d";
        var expectedEnabled = "true";

        var expectedResponse = $@"
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

        SetUpGetRequest(TFA_APPLICATION.Replace("{appId}", expectedApplicationId), 200, expectedResponse);

        var tfaApi = new TfaApi(Configuration);

        void AssertTfaGetApplicationResponse(TfaApplicationResponse tfaApplicationResponse)
        {
            var expectedApplicationConfiguration = new TfaApplicationConfiguration
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

        AssertResponseWithHttpInfo(tfaApi.GetTfaApplicationWithHttpInfo(expectedApplicationId),
            AssertTfaGetApplicationResponse, 200);
        AssertResponseWithHttpInfo(tfaApi.GetTfaApplicationWithHttpInfoAsync(expectedApplicationId).Result,
            AssertTfaGetApplicationResponse, 200);
    }

    [TestMethod]
    public void ShouldUpdateTfaApplicationTest()
    {
        var expectedApplicationId = "1234567";
        var expectedCreateApplicationName = "2fa application name";
        var expectedCreateApplicationPinAttempts = 5;
        var expectedAllowMultiplePinVerifications = "true";
        var expectedCreateApplicationPinTimeToLive = "10m";
        var expectedCreateApplicationVerifyPinLimit = "2/4s";
        var expectedCreateApplicationSendPinPerApplicationLimit = "5000/12h";
        var expectedCreateApplicationSendPinPerPhoneNumberLimit = "2/1d";
        var expectedEnabled = "true";

        var givenRequest = $@"
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

        var expectedResponse = $@"
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

        SetUpPutRequest(TFA_APPLICATION.Replace("{appId}", expectedApplicationId), 200, givenRequest, expectedResponse);

        var tfaApi = new TfaApi(Configuration);

        var tfaApplicationConfiguration = new TfaApplicationConfiguration
        {
            PinAttempts = expectedCreateApplicationPinAttempts,
            AllowMultiplePinVerifications = bool.Parse(expectedAllowMultiplePinVerifications),
            PinTimeToLive = expectedCreateApplicationPinTimeToLive,
            VerifyPinLimit = expectedCreateApplicationVerifyPinLimit,
            SendPinPerApplicationLimit = expectedCreateApplicationSendPinPerApplicationLimit,
            SendPinPerPhoneNumberLimit = expectedCreateApplicationSendPinPerPhoneNumberLimit
        };

        var tfaApplicationRequest = new TfaApplicationRequest(
            tfaApplicationConfiguration,
            bool.Parse(expectedEnabled),
            expectedCreateApplicationName
        );

        void AssertTfaUpdateApplicationResponse(TfaApplicationResponse tfaApplicationResponse)
        {
            Assert.IsNotNull(tfaApplicationResponse);
            Assert.AreEqual(expectedApplicationId, tfaApplicationResponse.ApplicationId);
            Assert.AreEqual(expectedCreateApplicationName, tfaApplicationResponse.Name);
            Assert.AreEqual(tfaApplicationConfiguration, tfaApplicationResponse.VarConfiguration);
            Assert.AreEqual(bool.Parse(expectedEnabled), tfaApplicationResponse.Enabled);
        }

        AssertResponse(tfaApi.UpdateTfaApplication(expectedApplicationId, tfaApplicationRequest),
            AssertTfaUpdateApplicationResponse);
        AssertResponse(tfaApi.UpdateTfaApplicationAsync(expectedApplicationId, tfaApplicationRequest).Result,
            AssertTfaUpdateApplicationResponse);

        AssertResponseWithHttpInfo(
            tfaApi.UpdateTfaApplicationWithHttpInfo(expectedApplicationId, tfaApplicationRequest),
            AssertTfaUpdateApplicationResponse, 200);
        AssertResponseWithHttpInfo(
            tfaApi.UpdateTfaApplicationWithHttpInfoAsync(expectedApplicationId, tfaApplicationRequest).Result,
            AssertTfaUpdateApplicationResponse, 200);
    }

    [TestMethod]
    public void ShouldGetTfaMessageTemplatesTest()
    {
        var givenApplicationId = "HJ675435E3A6EA43432G5F37A635KJ8B";

        var expectedPinPlaceholder = "{{pin}}";
        var expectedMessageText = string.Format("Your PIN is {0}.", expectedPinPlaceholder);
        var expectedPinLength = 4;
        var expectedPinType = "Alphanumeric";
        var expectedLanguage = "En";
        var expectedSenderId = "Infobip 2FA";
        var expectedRepeatDtmf = "1#";
        double expectedSpeechRate = 1;

        var expectedResponse = $@"
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

        SetUpGetRequest(TFA_TEMPLATES.Replace("{appId}", givenApplicationId), 200, expectedResponse);

        var tfaApi = new TfaApi(Configuration);

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

        AssertResponseWithHttpInfo(tfaApi.GetTfaMessageTemplatesWithHttpInfo(givenApplicationId),
            AssertTfaGetTemplatesResponse, 200);
        AssertResponseWithHttpInfo(tfaApi.GetTfaMessageTemplatesWithHttpInfoAsync(givenApplicationId).Result,
            AssertTfaGetTemplatesResponse, 200);
    }

    [TestMethod]
    public void ShouldCreateTfaMessageTemplateTest()
    {
        var givenApplicationId = "HJ675435E3A6EA43432G5F37A635KJ8B";

        var expectedPinPlaceholder = "{{pin}}";
        var expectedMessageText = string.Format("Your PIN is {0}.", expectedPinPlaceholder);
        var expectedPinLength = 4;
        var expectedPinType = "Alphanumeric";
        var expectedLanguage = "en";
        var expectedSenderId = "Infobip 2FA";
        var expectedRepeatDtmf = "1#";
        var expectedSpeechRate = "1.0";

        var givenRequest = $@"
            {{
                ""language"": ""{expectedLanguage}"",
                ""pinType"": ""{expectedPinType}"",
                ""messageText"": ""{expectedMessageText}"",
                ""pinLength"": {expectedPinLength},
                ""repeatDTMF"": ""{expectedRepeatDtmf}"",
                ""senderId"": ""{expectedSenderId}"",
                ""speechRate"": {expectedSpeechRate}
            }}";

        var expectedResponse = $@"
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

        SetUpPostRequest(TFA_TEMPLATES.Replace("{appId}", givenApplicationId), 200, givenRequest, expectedResponse);

        var tfaApi = new TfaApi(Configuration);

        var tfaCreateMessageRequest = new TfaCreateMessageRequest(
            Enum.Parse<TfaLanguage>(expectedLanguage, true),
            expectedMessageText,
            expectedPinLength,
            Enum.Parse<TfaPinType>(expectedPinType, true),
            repeatDTMF: expectedRepeatDtmf,
            senderId: expectedSenderId,
            speechRate: double.Parse(expectedSpeechRate, CultureInfo.InvariantCulture)
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
            Assert.AreEqual(double.Parse(expectedSpeechRate, CultureInfo.InvariantCulture), tfaMessage.SpeechRate);
        }

        AssertResponse(tfaApi.CreateTfaMessageTemplate(givenApplicationId, tfaCreateMessageRequest),
            AssertTfaCreateTemplateResponse);
        AssertResponse(tfaApi.CreateTfaMessageTemplateAsync(givenApplicationId, tfaCreateMessageRequest).Result,
            AssertTfaCreateTemplateResponse);

        AssertResponseWithHttpInfo(
            tfaApi.CreateTfaMessageTemplateWithHttpInfo(givenApplicationId, tfaCreateMessageRequest),
            AssertTfaCreateTemplateResponse, 200);
        AssertResponseWithHttpInfo(
            tfaApi.CreateTfaMessageTemplateWithHttpInfoAsync(givenApplicationId, tfaCreateMessageRequest).Result,
            AssertTfaCreateTemplateResponse, 200);
    }

    [TestMethod]
    public void ShouldGetTfaMessageTemplateTest()
    {
        var givenApplicationId = "HJ675435E3A6EA43432G5F37A635KJ8B";
        var givenMessageId = "9C815F8AF3328";

        var expectedPinPlaceholder = "{{pin}}";
        var expectedMessageText = string.Format("Your PIN is {0}.", expectedPinPlaceholder);
        var expectedPinLength = 4;
        var expectedPinType = "Alphanumeric";
        var expectedLanguage = "En";
        var expectedSenderId = "Infobip 2FA";
        var expectedRepeatDtmf = "1#";
        var expectedSpeechRate = 1.0;

        var expectedResponse = $@"
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

        SetUpGetRequest(TFA_TEMPLATE.Replace("{appId}", givenApplicationId).Replace("{msgId}", givenMessageId),
            200, expectedResponse);

        var tfaApi = new TfaApi(Configuration);

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
        AssertResponse(tfaApi.GetTfaMessageTemplateAsync(givenApplicationId, givenMessageId).Result,
            AssertTfaGetTemplateResponse);

        AssertResponseWithHttpInfo(tfaApi.GetTfaMessageTemplateWithHttpInfo(givenApplicationId, givenMessageId),
            AssertTfaGetTemplateResponse, 200);
        AssertResponseWithHttpInfo(
            tfaApi.GetTfaMessageTemplateWithHttpInfoAsync(givenApplicationId, givenMessageId).Result,
            AssertTfaGetTemplateResponse, 200);
    }

    [TestMethod]
    public void ShouldUpdateTfaMessageTemplateTest()
    {
        var givenApplicationId = "HJ675435E3A6EA43432G5F37A635KJ8B";
        var givenMessageId = "5E3A6EA43432G5F3";

        var expectedPinPlaceholder = "{{pin}}";
        var expectedMessageText = string.Format("Your PIN is {0}.", expectedPinPlaceholder);
        var expectedPinLength = 4;
        var expectedPinType = "Alphanumeric";
        var expectedLanguage = "en";
        var expectedSenderId = "Infobip 2FA";
        var expectedRepeatDtmf = "1#";
        var expectedSpeechRate = "1.0";

        var givenRequest = $@"
            {{
                ""language"": ""{expectedLanguage}"",
                ""pinType"": ""{expectedPinType}"",
                ""messageText"": ""{expectedMessageText}"",
                ""pinLength"": {expectedPinLength},
                ""repeatDTMF"": ""{expectedRepeatDtmf}"",
                ""senderId"": ""{expectedSenderId}"",
                ""speechRate"": {expectedSpeechRate}
            }}";


        var expectedResponse = $@"
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

        SetUpPutRequest(TFA_TEMPLATE.Replace("{appId}", givenApplicationId).Replace("{msgId}", givenMessageId), 200,
            givenRequest, expectedResponse);

        var tfaApi = new TfaApi(Configuration);

        var tfaUpdateMessageRequest = new TfaUpdateMessageRequest(
            Enum.Parse<TfaLanguage>(expectedLanguage, true),
            expectedMessageText,
            expectedPinLength,
            Enum.Parse<TfaPinType>(expectedPinType, true),
            repeatDTMF: expectedRepeatDtmf,
            senderId: expectedSenderId,
            speechRate: double.Parse(expectedSpeechRate, CultureInfo.InvariantCulture)
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
            Assert.AreEqual(double.Parse(expectedSpeechRate, CultureInfo.InvariantCulture), tfaMessage.SpeechRate);
        }

        AssertResponse(tfaApi.UpdateTfaMessageTemplate(givenApplicationId, givenMessageId, tfaUpdateMessageRequest),
            AssertTfaUpdateTemplateResponse);
        AssertResponse(
            tfaApi.UpdateTfaMessageTemplateAsync(givenApplicationId, givenMessageId, tfaUpdateMessageRequest).Result,
            AssertTfaUpdateTemplateResponse);

        AssertResponseWithHttpInfo(
            tfaApi.UpdateTfaMessageTemplateWithHttpInfo(givenApplicationId, givenMessageId, tfaUpdateMessageRequest),
            AssertTfaUpdateTemplateResponse, 200);
        AssertResponseWithHttpInfo(
            tfaApi.UpdateTfaMessageTemplateWithHttpInfoAsync(givenApplicationId, givenMessageId,
                tfaUpdateMessageRequest).Result, AssertTfaUpdateTemplateResponse, 200);
    }

    [TestMethod]
    public void ShouldCreateTfaEmailMessageTemplateTest()
    {
        var expectedPinType = TfaPinType.Numeric;
        var expectedPinLength = 4;
        var expectedFrom = "company@example.com";
        var expectedEmailTemplateId = 1234;
        var expectedMessageId = "9C815F8AF3328";
        var expectedApplicationId = "HJ675435E3A6EA43432G5F37A635KJ8B";

        var givenRequest = $@"
            {{
                ""pinType"": ""{expectedPinType}"",
                ""pinLength"": {expectedPinLength},
                ""from"": ""{expectedFrom}"",
                ""emailTemplateId"": {expectedEmailTemplateId}
            }}";

        var expectedResponse = $@"
            {{
                ""messageId"": ""{expectedMessageId}"",
                ""applicationId"": ""{expectedApplicationId}"",
                ""pinLength"": {expectedPinLength},
                ""pinType"": ""{expectedPinType}"",
                ""from"": ""{expectedFrom}"",
                ""emailTemplateId"": {expectedEmailTemplateId}
            }}";

        SetUpPostRequest(TFA_EMAIL_TEMPLATES.Replace("{appId}", expectedApplicationId), 200, givenRequest,
            expectedResponse);

        var tfaApi = new TfaApi(Configuration);

        var tfaCreateEmailMessageRequest = new TfaCreateEmailMessageRequest(
            pinType: expectedPinType,
            pinLength: expectedPinLength,
            from: expectedFrom,
            emailTemplateId: expectedEmailTemplateId
        );

        void AssertTfaCreateEmailMessageResponse(TfaEmailMessage tfaEmailMessage)
        {
            Assert.IsNotNull(tfaEmailMessage);
            Assert.AreEqual(expectedMessageId, tfaEmailMessage.MessageId);
            Assert.AreEqual(expectedApplicationId, tfaEmailMessage.ApplicationId);
            Assert.AreEqual(expectedPinLength, tfaEmailMessage.PinLength);
            Assert.AreEqual(expectedPinType, tfaEmailMessage.PinType);
            Assert.AreEqual(expectedFrom, tfaEmailMessage.From);
            Assert.AreEqual(expectedEmailTemplateId, tfaEmailMessage.EmailTemplateId);
        }

        AssertResponse(tfaApi.CreateTfaEmailMessageTemplate(expectedApplicationId, tfaCreateEmailMessageRequest),
            AssertTfaCreateEmailMessageResponse);
        AssertResponse(
            tfaApi.CreateTfaEmailMessageTemplateAsync(expectedApplicationId, tfaCreateEmailMessageRequest).Result,
            AssertTfaCreateEmailMessageResponse);

        AssertResponseWithHttpInfo(
            tfaApi.CreateTfaEmailMessageTemplateWithHttpInfo(expectedApplicationId, tfaCreateEmailMessageRequest),
            AssertTfaCreateEmailMessageResponse, 200);
        AssertResponseWithHttpInfo(
            tfaApi.CreateTfaEmailMessageTemplateWithHttpInfoAsync(expectedApplicationId, tfaCreateEmailMessageRequest)
                .Result, AssertTfaCreateEmailMessageResponse, 200);
    }

    [TestMethod]
    public void ShouldUpdateTfaEmailMessageTemplateTest()
    {
        var expectedPinType = TfaPinType.Numeric;
        var expectedPinLength = 4;
        var expectedFrom = "company@example.com";
        var expectedEmailTemplateId = 1234;
        var expectedMessageId = "9C815F8AF3328";
        var expectedApplicationId = "HJ675435E3A6EA43432G5F37A635KJ8B";

        var givenRequest = $@"
            {{
                ""pinType"": ""{expectedPinType}"",
                ""pinLength"": {expectedPinLength},
                ""from"": ""{expectedFrom}"",
                ""emailTemplateId"": {expectedEmailTemplateId}
            }}";

        var expectedResponse = $@"
            {{
                ""messageId"": ""{expectedMessageId}"",
                ""applicationId"": ""{expectedApplicationId}"",
                ""pinLength"": {expectedPinLength},
                ""pinType"": ""{expectedPinType}"",
                ""from"": ""{expectedFrom}"",
                ""emailTemplateId"": {expectedEmailTemplateId}
            }}";

        SetUpPutRequest(
            TFA_EMAIL_TEMPLATE.Replace("{appId}", expectedApplicationId).Replace("{msgId}", expectedMessageId),
            200, givenRequest, expectedResponse);

        var tfaApi = new TfaApi(Configuration);

        var tfaUpdateEmailMessageRequest = new TfaUpdateEmailMessageRequest(
            pinType: expectedPinType,
            pinLength: expectedPinLength,
            from: expectedFrom,
            emailTemplateId: expectedEmailTemplateId
        );

        void AssertTfaUpdateEmailMessageResponse(TfaEmailMessage tfaEmailMessage)
        {
            Assert.IsNotNull(tfaEmailMessage);
            Assert.AreEqual(expectedMessageId, tfaEmailMessage.MessageId);
            Assert.AreEqual(expectedApplicationId, tfaEmailMessage.ApplicationId);
            Assert.AreEqual(expectedPinLength, tfaEmailMessage.PinLength);
            Assert.AreEqual(expectedPinType, tfaEmailMessage.PinType);
            Assert.AreEqual(expectedFrom, tfaEmailMessage.From);
            Assert.AreEqual(expectedEmailTemplateId, tfaEmailMessage.EmailTemplateId);
        }

        AssertResponse(
            tfaApi.UpdateTfaEmailMessageTemplate(expectedApplicationId, expectedMessageId,
                tfaUpdateEmailMessageRequest), AssertTfaUpdateEmailMessageResponse);
        AssertResponse(
            tfaApi.UpdateTfaEmailMessageTemplateAsync(expectedApplicationId, expectedMessageId,
                tfaUpdateEmailMessageRequest).Result, AssertTfaUpdateEmailMessageResponse);

        AssertResponseWithHttpInfo(
            tfaApi.UpdateTfaEmailMessageTemplateWithHttpInfo(expectedApplicationId, expectedMessageId,
                tfaUpdateEmailMessageRequest), AssertTfaUpdateEmailMessageResponse, 200);
        AssertResponseWithHttpInfo(
            tfaApi.UpdateTfaEmailMessageTemplateWithHttpInfoAsync(expectedApplicationId, expectedMessageId,
                tfaUpdateEmailMessageRequest).Result, AssertTfaUpdateEmailMessageResponse, 200);
    }

    [TestMethod]
    public void ShouldSendTfaPinCodeViaSmsTest()
    {
        var givenApplicationId = "1234567";
        var givenMessageId = "7654321";
        var givenFrom = "Sender 1";
        var givenFirstName = "John";

        var expectedPinId = "9C817C6F8AF3D48F9FE553282AFA2B67";
        var expectedTo = "41793026727";
        var expectedNcStatus = "NC_DESTINATION_REACHABLE";
        var expectedSmsStatus = "MESSAGE_SENT";

        var givenRequest = $@"
            {{
                ""applicationId"": ""{givenApplicationId}"",
                ""messageId"": ""{givenMessageId}"",
                ""from"": ""{givenFrom}"",
                ""to"": ""{expectedTo}"",
                ""placeholders"": {{
                    ""firstName"": ""{givenFirstName}""
                }}
            }}";

        var expectedResponse = $@"
            {{
                ""pinId"": ""{expectedPinId}"",
                ""to"": ""{expectedTo}"",
                ""ncStatus"": ""{expectedNcStatus}"",
                ""smsStatus"": ""{expectedSmsStatus}""
            }}";

        SetUpPostRequest(TFA_SEND_PIN, 200, givenRequest, expectedResponse);

        var tfaApi = new TfaApi(Configuration);

        var givenPlaceholders = new Dictionary<string, string> { { "firstName", givenFirstName } };
        var tfaStartAuthenticationRequest = new TfaStartAuthenticationRequest(
            givenApplicationId,
            givenFrom,
            givenMessageId,
            givenPlaceholders,
            expectedTo
        );

        void AssertTfaStartAuthenticationResponse(TfaStartAuthenticationResponse tfaStartAuthenticationResponse)
        {
            Assert.IsNotNull(tfaStartAuthenticationResponse);
            Assert.AreEqual(expectedPinId, tfaStartAuthenticationResponse.PinId);
            Assert.AreEqual(expectedTo, tfaStartAuthenticationResponse.To);
            Assert.AreEqual(expectedNcStatus, tfaStartAuthenticationResponse.NcStatus);
            Assert.AreEqual(expectedSmsStatus, tfaStartAuthenticationResponse.SmsStatus);
        }

        AssertResponse(tfaApi.SendTfaPinCodeOverSms(tfaStartAuthenticationRequest),
            AssertTfaStartAuthenticationResponse);
        AssertResponse(tfaApi.SendTfaPinCodeOverSmsAsync(tfaStartAuthenticationRequest).Result,
            AssertTfaStartAuthenticationResponse);

        AssertResponseWithHttpInfo(tfaApi.SendTfaPinCodeOverSmsWithHttpInfo(tfaStartAuthenticationRequest),
            AssertTfaStartAuthenticationResponse, 200);
        AssertResponseWithHttpInfo(tfaApi.SendTfaPinCodeOverSmsWithHttpInfoAsync(tfaStartAuthenticationRequest).Result,
            AssertTfaStartAuthenticationResponse, 200);
    }

    [TestMethod]
    public void ShouldResendTfaPinCodeViaSmsTest()
    {
        var givenFirstName = "John";

        var expectedPinId = "9C817C6F8AF3D48F9FE553282AFA2B67";
        var expectedTo = "41793026727";
        var expectedNcStatus = "NC_DESTINATION_REACHABLE";
        var expectedSmsStatus = "MESSAGE_SENT";

        var givenRequest = $@"
            {{
                ""placeholders"": {{
                    ""firstName"": ""{givenFirstName}""
                }}
            }}";

        var expectedResponse = $@"
            {{
                ""pinId"": ""{expectedPinId}"",
                ""to"": ""{expectedTo}"",
                ""ncStatus"": ""{expectedNcStatus}"",
                ""smsStatus"": ""{expectedSmsStatus}""
            }}";

        SetUpPostRequest(TFA_RESEND_PIN.Replace("{pinId}", expectedPinId), 200, givenRequest, expectedResponse);

        var tfaApi = new TfaApi(Configuration);

        var tfaResendPinRequest = new TfaResendPinRequest
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

        AssertResponse(tfaApi.ResendTfaPinCodeOverSms(expectedPinId, tfaResendPinRequest),
            AssertTfaStartAuthenticationResponse);
        AssertResponse(tfaApi.ResendTfaPinCodeOverSmsAsync(expectedPinId, tfaResendPinRequest).Result,
            AssertTfaStartAuthenticationResponse);

        AssertResponseWithHttpInfo(tfaApi.ResendTfaPinCodeOverSmsWithHttpInfo(expectedPinId, tfaResendPinRequest),
            AssertTfaStartAuthenticationResponse, 200);
        AssertResponseWithHttpInfo(
            tfaApi.ResendTfaPinCodeOverSmsWithHttpInfoAsync(expectedPinId, tfaResendPinRequest).Result,
            AssertTfaStartAuthenticationResponse, 200);
    }

    [TestMethod]
    public void ShouldSendTfaPinCodeViaVoiceTest()
    {
        var givenApplicationId = "1234567";
        var givenMessageId = "7654321";
        var givenFrom = "Sender 1";
        var givenFirstName = "John";

        var expectedPinId = "9C817C6F8AF3D48F9FE553282AFA2B67";
        var expectedTo = "41793026727";
        var expectedCallStatus = "PENDING_ACCEPTED";

        var givenRequest = $@"
            {{
                ""applicationId"": ""{givenApplicationId}"",
                ""messageId"": ""{givenMessageId}"",
                ""from"": ""{givenFrom}"",
                ""to"": ""{expectedTo}"",
                ""placeholders"": {{
                    ""firstName"": ""{givenFirstName}""
                }}
            }}";

        var expectedResponse = $@"
            {{
                ""pinId"": ""{expectedPinId}"",
                ""to"": ""{expectedTo}"",
                ""callStatus"": ""{expectedCallStatus}""
            }}";

        SetUpPostRequest(TFA_SEND_PIN_VOICE, 200, givenRequest, expectedResponse);

        var tfaApi = new TfaApi(Configuration);

        var givenPlaceholders = new Dictionary<string, string> { { "firstName", givenFirstName } };
        var tfaStartAuthenticationRequest = new TfaStartAuthenticationRequest(
            givenApplicationId,
            givenFrom,
            givenMessageId,
            givenPlaceholders,
            expectedTo
        );

        void AssertTfaStartAuthenticationResponse(TfaStartAuthenticationResponse tfaStartAuthenticationResponse)
        {
            Assert.IsNotNull(tfaStartAuthenticationResponse);
            Assert.AreEqual(expectedPinId, tfaStartAuthenticationResponse.PinId);
            Assert.AreEqual(expectedTo, tfaStartAuthenticationResponse.To);
            Assert.AreEqual(expectedCallStatus, tfaStartAuthenticationResponse.CallStatus);
        }

        AssertResponse(tfaApi.SendTfaPinCodeOverVoice(tfaStartAuthenticationRequest),
            AssertTfaStartAuthenticationResponse);
        AssertResponse(tfaApi.SendTfaPinCodeOverVoiceAsync(tfaStartAuthenticationRequest).Result,
            AssertTfaStartAuthenticationResponse);

        AssertResponseWithHttpInfo(tfaApi.SendTfaPinCodeOverVoiceWithHttpInfo(tfaStartAuthenticationRequest),
            AssertTfaStartAuthenticationResponse, 200);
        AssertResponseWithHttpInfo(
            tfaApi.SendTfaPinCodeOverVoiceWithHttpInfoAsync(tfaStartAuthenticationRequest).Result,
            AssertTfaStartAuthenticationResponse, 200);
    }

    [TestMethod]
    public void ShouldResendTfaPinCodeViaVoiceTest()
    {
        var givenFirstName = "John";

        var expectedPinId = "9C817C6F8AF3D48F9FE553282AFA2B67";
        var expectedTo = "41793026727";
        var expectedCallStatus = "MESSAGE_SENT";

        var givenRequest = $@"
            {{
                ""placeholders"": {{
                    ""firstName"": ""{givenFirstName}""
                }}
            }}";

        var expectedResponse = $@"
            {{
                ""pinId"": ""{expectedPinId}"",
                ""to"": {expectedTo},
                ""callStatus"": ""{expectedCallStatus}""
            }}";

        SetUpPostRequest(TFA_RESEND_PIN_VOICE.Replace("{pinId}", expectedPinId), 200, givenRequest, expectedResponse);

        var tfaApi = new TfaApi(Configuration);

        var tfaResendPinRequest = new TfaResendPinRequest
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

        AssertResponse(tfaApi.ResendTfaPinCodeOverVoice(expectedPinId, tfaResendPinRequest),
            AssertTfaStartAuthenticationResponse);
        
        AssertResponse(tfaApi.ResendTfaPinCodeOverVoiceAsync(expectedPinId, tfaResendPinRequest).Result,
            AssertTfaStartAuthenticationResponse);

        AssertResponseWithHttpInfo(tfaApi.ResendTfaPinCodeOverVoiceWithHttpInfo(expectedPinId, tfaResendPinRequest),
            AssertTfaStartAuthenticationResponse, 200);
        AssertResponseWithHttpInfo(
            tfaApi.ResendTfaPinCodeOverVoiceWithHttpInfoAsync(expectedPinId, tfaResendPinRequest).Result,
            AssertTfaStartAuthenticationResponse, 200);
    }

    [TestMethod]
    public void ShouldSendTfaPinCodeViaEmailTest()
    {
        var givenApplicationId = "1234567";
        var givenMessageId = "7654321";
        var givenFirstName = "John";

        var expectedTo = "john.smith@example.com";
        var expectedPinId = "9C817C6F8AF3D48F9FE553282AFA2B67";
        var expectedEmailStatusName = "PENDING_ACCEPTED";
        var expectedEmailStatusDescription = "Message accepted, pending for delivery.";


        var givenRequest = $@"
            {{
                ""applicationId"": ""{givenApplicationId}"",
                ""messageId"": ""{givenMessageId}"",
                ""to"": ""{expectedTo}"",
                ""placeholders"": {{
                    ""firstName"": ""{givenFirstName}""
                }}
            }}";

        var expectedResponse = $@"
            {{
                ""pinId"": ""{expectedPinId}"",
                ""to"": ""{expectedTo}"",
                ""emailStatus"": {{
                    ""name"": ""{expectedEmailStatusName}"",
                    ""description"": ""{expectedEmailStatusDescription}""
                }}
            }}";

        SetUpPostRequest(TFA_SEND_PIN_EMAIL, 200, givenRequest, expectedResponse);

        var tfaApi = new TfaApi(Configuration);

        var givenPlaceholders = new Dictionary<string, string> { { "firstName", givenFirstName } };

        var tfaStartEmailAuthenticationRequest = new TfaStartEmailAuthenticationRequest(
            givenApplicationId,
            messageId: givenMessageId,
            to: expectedTo,
            placeholders: givenPlaceholders
        );

        void AssertTfaStartEmailAuthenticationResponse(
            TfaStartEmailAuthenticationResponse tfaStartEmailAuthenticationResponse)
        {
            Assert.IsNotNull(tfaStartEmailAuthenticationRequest);
            Assert.AreEqual(expectedPinId, tfaStartEmailAuthenticationResponse.PinId);
            Assert.AreEqual(expectedTo, tfaStartEmailAuthenticationResponse.To);
            Assert.AreEqual(expectedEmailStatusName, tfaStartEmailAuthenticationResponse.EmailStatus.Name);
            Assert.AreEqual(expectedEmailStatusDescription,
                tfaStartEmailAuthenticationResponse.EmailStatus.Description);
        }

        AssertResponse(tfaApi.Send2faPinCodeOverEmail(tfaStartEmailAuthenticationRequest),
            AssertTfaStartEmailAuthenticationResponse);
        AssertResponse(tfaApi.Send2faPinCodeOverEmailAsync(tfaStartEmailAuthenticationRequest).Result,
            AssertTfaStartEmailAuthenticationResponse);

        AssertResponseWithHttpInfo(tfaApi.Send2faPinCodeOverEmailWithHttpInfo(tfaStartEmailAuthenticationRequest),
            AssertTfaStartEmailAuthenticationResponse, 200);
        AssertResponseWithHttpInfo(
            tfaApi.Send2faPinCodeOverEmailWithHttpInfoAsync(tfaStartEmailAuthenticationRequest).Result,
            AssertTfaStartEmailAuthenticationResponse, 200);
    }

    [TestMethod]
    public void ShouldResendTfaPinCodeViaEmailTest()
    {
        var givenFirstName = "John";

        var expectedPinId = "9C817C6F8AF3D48F9FE553282AFA2B67";
        var expectedTo = "john.smith@example.com";
        var expectedEmailStatusName = "PENDING_ACCEPTED";
        var expectedEmailStatusDescription = "Message accepted, pending for delivery.";

        var givenRequest = $@"
            {{
                ""placeholders"": {{
                    ""firstName"": ""{givenFirstName}""
                }}
            }}";

        var expectedResponse = $@"
            {{
                ""pinId"": ""{expectedPinId}"",
                ""to"": ""{expectedTo}"",
                ""emailStatus"": {{
                    ""name"": ""{expectedEmailStatusName}"",
                    ""description"": ""{expectedEmailStatusDescription}""
                }}
            }}";

        SetUpPostRequest(TFA_RESEND_PIN_EMAIL.Replace("{pinId}", expectedPinId), 200, givenRequest, expectedResponse);

        var tfaApi = new TfaApi(Configuration);

        var tfaResendPinRequest = new TfaResendPinRequest
        {
            Placeholders = new Dictionary<string, string> { { "firstName", givenFirstName } }
        };

        void AssertTfaStartAuthenticationResponse(
            TfaStartEmailAuthenticationResponse tfaStartEmailAuthenticationResponse)
        {
            Assert.IsNotNull(tfaStartEmailAuthenticationResponse);
            Assert.AreEqual(expectedPinId, tfaStartEmailAuthenticationResponse.PinId);
            Assert.AreEqual(expectedTo, tfaStartEmailAuthenticationResponse.To);
            Assert.AreEqual(expectedEmailStatusName, tfaStartEmailAuthenticationResponse.EmailStatus.Name);
            Assert.AreEqual(expectedEmailStatusDescription,
                tfaStartEmailAuthenticationResponse.EmailStatus.Description);
        }

        AssertResponse(tfaApi.Resend2faPinCodeOverEmail(expectedPinId, tfaResendPinRequest),
            AssertTfaStartAuthenticationResponse);
        
        AssertResponse(tfaApi.Resend2faPinCodeOverEmailAsync(expectedPinId, tfaResendPinRequest).Result,
            AssertTfaStartAuthenticationResponse);

        AssertResponseWithHttpInfo(tfaApi.Resend2faPinCodeOverEmailWithHttpInfo(expectedPinId, tfaResendPinRequest),
            AssertTfaStartAuthenticationResponse, 200);
        AssertResponseWithHttpInfo(
            tfaApi.Resend2faPinCodeOverEmailWithHttpInfoAsync(expectedPinId, tfaResendPinRequest).Result,
            AssertTfaStartAuthenticationResponse, 200);
    }

    [TestMethod]
    public void ShouldVerifyTfaCallTest()
    {
        var givenPin = "1598";

        var expectedPinId = "9C817C6F8AF3D48F9FE553282AFA2B68";
        var expectedMsisdn = "41793026726";
        var expectedVerified = "true";
        var expectedAttemptsRemaining = 0;

        var givenRequest = $@"
            {{
                ""pin"": ""{givenPin}""
            }}";

        var expectedResponse = $@"
            {{
                ""pinId"": ""{expectedPinId}"",
                ""msisdn"": ""{expectedMsisdn}"",
                ""verified"": {expectedVerified},
                ""attemptsRemaining"": {expectedAttemptsRemaining}
            }}";

        SetUpPostRequest(TFA_VERIFY_PIN.Replace("{pinId}", expectedPinId), 200, givenRequest, expectedResponse);

        var tfaApi = new TfaApi(Configuration);

        var tfaVerifyPinRequest = new TfaVerifyPinRequest(givenPin);

        void AssertTfaVerifyPinResponse(TfaVerifyPinResponse tfaVerifyPinResponse)
        {
            Assert.IsNotNull(tfaVerifyPinResponse);
            Assert.AreEqual(expectedPinId, tfaVerifyPinResponse.PinId);
            Assert.AreEqual(expectedMsisdn, tfaVerifyPinResponse.Msisdn);
            Assert.AreEqual(bool.Parse(expectedVerified), tfaVerifyPinResponse.Verified);
            Assert.AreEqual(expectedAttemptsRemaining, tfaVerifyPinResponse.AttemptsRemaining);
        }

        AssertResponse(tfaApi.VerifyTfaPhoneNumber(expectedPinId, tfaVerifyPinRequest), AssertTfaVerifyPinResponse);
        
        AssertResponse(tfaApi.VerifyTfaPhoneNumberAsync(expectedPinId, tfaVerifyPinRequest).Result,
            AssertTfaVerifyPinResponse);

        AssertResponseWithHttpInfo(tfaApi.VerifyTfaPhoneNumberWithHttpInfo(expectedPinId, tfaVerifyPinRequest),
            AssertTfaVerifyPinResponse, 200);
        AssertResponseWithHttpInfo(
            tfaApi.VerifyTfaPhoneNumberWithHttpInfoAsync(expectedPinId, tfaVerifyPinRequest).Result,
            AssertTfaVerifyPinResponse, 200);
    }

    [TestMethod]
    public void ShouldGetTfaVerificationStatusTest()
    {
        var givenApplicationId = "16A8B5FE2BCD6CA716A2D780CB3F3390";

        var expectedMsisdn = "41793026726";
        var expectedVerified1 = "true";
        var expectedVerifiedAt1 = 1418364366L;
        var expectedSentAt1 = 1418364246L;
        var expectedVerified2 = "false";
        var expectedVerifiedAt2 = 1418364226L;
        var expectedSentAt2 = 1418333246L;

        var expectedResponse = $@"
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

        SetUpGetRequest(TFA_VERIFICATION_STATUS.Replace("{appId}", givenApplicationId), 200, expectedResponse);

        var tfaApi = new TfaApi(Configuration);

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

        AssertResponse(tfaApi.GetTfaVerificationStatus(expectedMsisdn, givenApplicationId),
            AssertTfaVerificationResponse);
        
        AssertResponse(tfaApi.GetTfaVerificationStatusAsync(expectedMsisdn, givenApplicationId).Result,
            AssertTfaVerificationResponse);

        AssertResponseWithHttpInfo(tfaApi.GetTfaVerificationStatusWithHttpInfo(expectedMsisdn, givenApplicationId),
            AssertTfaVerificationResponse, 200);
        AssertResponseWithHttpInfo(
            tfaApi.GetTfaVerificationStatusWithHttpInfoAsync(expectedMsisdn, givenApplicationId).Result,
            AssertTfaVerificationResponse, 200);
    }
}