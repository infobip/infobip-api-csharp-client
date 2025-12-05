using Infobip.Api.Client.Api;
using Infobip.Api.Client.Model;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace ApiClient.Tests.Api;

[TestClass]
public class NumberMaskingApiTest : ApiTest
{
    protected const string NUMBER_MASKING_CONFIGURATIONS_ENDPOINT = "/voice/masking/2/config";
    protected const string NUMBER_MASKING_CONFIGURATION_ENDPOINT = "/voice/masking/2/config/{key}";
    protected const string NUMBER_MASKING_UPLOAD_ENDPOINT = "/voice/masking/1/upload";
    protected const string NUMBER_MASKING_CREDENTIALS_ENDPOINT = "/voice/masking/2/credentials";

    [TestMethod]
    public void ShouldGetNumberMaskingConfigurations()
    {
        var expectedKey = "3FC0C9CB4AFAEAC67E8FC6BA3B1E044A";
        var expectedName = "UniqueConfigurationName";
        var expectedCallbackUrl = "https://example.com/1/callback";
        var expectedStatusUrl = "https://example.com/1/status";
        var expectedBackupCallbackUrl = "https://example.com/2/callback";
        var expectedBackupStatusUrl = "https://example.com/2/status";
        var expectedDescription = "Unique configuration description";
        var expectedInsertDateTime = "2019-08-16T09:11:36.573";
        var expectedUpdateDateTime = "2019-08-16T09:11:37.573";

        var expectedResponse = $@"
            [
              {{
                ""key"": ""{expectedKey}"",
                ""name"": ""{expectedName}"",
                ""callbackUrl"": ""{expectedCallbackUrl}"",
                ""statusUrl"": ""{expectedStatusUrl}"",
                ""backupCallbackUrl"": ""{expectedBackupCallbackUrl}"",
                ""backupStatusUrl"": ""{expectedBackupStatusUrl}"",
                ""description"": ""{expectedDescription}"",
                ""insertDateTime"": ""{expectedInsertDateTime}"",
                ""updateDateTime"": ""{expectedUpdateDateTime}""
              }}
            ]";

        SetUpGetRequest(NUMBER_MASKING_CONFIGURATIONS_ENDPOINT, 200, expectedResponse);

        var numberMaskingApi = new NumberMaskingApi(Configuration);

        void AssertNumberMaskingSetupResponse(List<NumberMaskingSetupResponse> numberMaskingSetupResponses)
        {
            Assert.IsNotNull(numberMaskingSetupResponses);
            Assert.AreEqual(1, numberMaskingSetupResponses.Count);

            var numberMaskingSetupResponse = numberMaskingSetupResponses[0];
            Assert.IsNotNull(numberMaskingSetupResponse);
            Assert.AreEqual(expectedKey, numberMaskingSetupResponse.Key);
            Assert.AreEqual(expectedName, numberMaskingSetupResponse.Name);
            Assert.AreEqual(expectedCallbackUrl, numberMaskingSetupResponse.CallbackUrl);
            Assert.AreEqual(expectedStatusUrl, numberMaskingSetupResponse.StatusUrl);
            Assert.AreEqual(expectedBackupCallbackUrl, numberMaskingSetupResponse.BackupCallbackUrl);
            Assert.AreEqual(expectedBackupStatusUrl, numberMaskingSetupResponse.BackupStatusUrl);
            Assert.AreEqual(expectedDescription, numberMaskingSetupResponse.Description);
            Assert.AreEqual(new DateTimeOffset(DateTime.Parse(expectedInsertDateTime), TimeSpan.Zero),
                numberMaskingSetupResponse.InsertDateTime);
            Assert.AreEqual(new DateTimeOffset(DateTime.Parse(expectedUpdateDateTime), TimeSpan.Zero),
                numberMaskingSetupResponse.UpdateDateTime);
        }

        AssertResponse(numberMaskingApi.GetNumberMaskingConfigurations(), AssertNumberMaskingSetupResponse);
        AssertResponse(numberMaskingApi.GetNumberMaskingConfigurationsAsync().Result, AssertNumberMaskingSetupResponse);
        AssertResponseWithHttpInfo(numberMaskingApi.GetNumberMaskingConfigurationsWithHttpInfo(),
            AssertNumberMaskingSetupResponse, 200);
        AssertResponseWithHttpInfo(numberMaskingApi.GetNumberMaskingConfigurationsWithHttpInfoAsync().Result,
            AssertNumberMaskingSetupResponse, 200);
    }

    [TestMethod]
    public void ShouldCreateNumberMaskingConfiguration()
    {
        var expectedKey = "3FC0C9CB4AFAEAC67E8FC6BA3B1E044A";
        var expectedName = "UniqueConfigurationName";
        var expectedCallbackUrl = "https://example.com/1/callback";
        var expectedStatusUrl = "https://example.com/1/status";
        var expectedInsertDateTime = "2019-08-16T09:11:36.573";
        var expectedUpdateDateTime = "2019-08-16T09:11:37.573";

        var expectedResponse = $@"
            {{
              ""key"": ""{expectedKey}"",
              ""name"": ""{expectedName}"",
              ""callbackUrl"": ""{expectedCallbackUrl}"",
              ""statusUrl"": ""{expectedStatusUrl}"",
              ""insertDateTime"": ""{expectedInsertDateTime}"",
              ""updateDateTime"": ""{expectedUpdateDateTime}""
            }}";

        var givenName = "UniqueConfigurationName";
        var givenCallbackUrl = "https://example.com/1/callback";
        var givenStatusUrl = "https://example.com/1/status";

        var givenRequest = $@"
            {{
              ""name"": ""{givenName}"",
              ""callbackUrl"": ""{givenCallbackUrl}"",
              ""statusUrl"": ""{givenStatusUrl}""
            }}";

        SetUpPostRequest(NUMBER_MASKING_CONFIGURATIONS_ENDPOINT, 200, givenRequest, expectedResponse);

        var numberMaskingApi = new NumberMaskingApi(Configuration);

        var numberMaskingSetupBody = new NumberMaskingSetupBody(
            givenName,
            givenCallbackUrl,
            givenStatusUrl
        );

        void AssertNumberMaskingSetupResponse(NumberMaskingSetupResponse numberMaskingSetupResponse)
        {
            Assert.IsNotNull(numberMaskingSetupResponse);
            Assert.AreEqual(expectedKey, numberMaskingSetupResponse.Key);
            Assert.AreEqual(expectedName, numberMaskingSetupResponse.Name);
            Assert.AreEqual(expectedCallbackUrl, numberMaskingSetupResponse.CallbackUrl);
            Assert.AreEqual(expectedStatusUrl, numberMaskingSetupResponse.StatusUrl);
            Assert.AreEqual(new DateTimeOffset(DateTime.Parse(expectedInsertDateTime), TimeSpan.Zero),
                numberMaskingSetupResponse.InsertDateTime);
            Assert.AreEqual(new DateTimeOffset(DateTime.Parse(expectedUpdateDateTime), TimeSpan.Zero),
                numberMaskingSetupResponse.UpdateDateTime);
        }

        AssertResponse(numberMaskingApi.CreateNumberMaskingConfiguration(numberMaskingSetupBody),
            AssertNumberMaskingSetupResponse);
        AssertResponse(numberMaskingApi.CreateNumberMaskingConfigurationAsync(numberMaskingSetupBody).Result,
            AssertNumberMaskingSetupResponse);
        AssertResponseWithHttpInfo(
            numberMaskingApi.CreateNumberMaskingConfigurationWithHttpInfo(numberMaskingSetupBody),
            AssertNumberMaskingSetupResponse, 200);
        AssertResponseWithHttpInfo(
            numberMaskingApi.CreateNumberMaskingConfigurationWithHttpInfoAsync(numberMaskingSetupBody).Result,
            AssertNumberMaskingSetupResponse, 200);
    }

    [TestMethod]
    public void ShouldGetNumberMaskingConfiguration()
    {
        var expectedKey = "3FC0C9CB4AFAEAC67E8FC6BA3B1E044A";
        var expectedName = "UniqueConfigurationName";
        var expectedCallbackUrl = "https://example.com/1/callback";
        var expectedStatusUrl = "https://example.com/1/status";
        var expectedInsertDateTime = "2019-08-16T09:11:36.573";
        var expectedUpdateDateTime = "2019-08-16T09:11:37.573";

        var expectedResponse = $@"
            {{
              ""key"": ""{expectedKey}"",
              ""name"": ""{expectedName}"",
              ""callbackUrl"": ""{expectedCallbackUrl}"",
              ""statusUrl"": ""{expectedStatusUrl}"",
              ""insertDateTime"": ""{expectedInsertDateTime}"",
              ""updateDateTime"": ""{expectedUpdateDateTime}""
            }}";

        var givenKey = "3FC0C9CB4AFAEAC67E8FC6BA3B1E044A";

        SetUpGetRequest(NUMBER_MASKING_CONFIGURATION_ENDPOINT.Replace("{key}", givenKey), 200, expectedResponse);

        var numberMaskingApi = new NumberMaskingApi(Configuration);

        void AssertNumberMaskingSetupResponse(NumberMaskingSetupResponse numberMaskingSetupResponse)
        {
            Assert.IsNotNull(numberMaskingSetupResponse);
            Assert.AreEqual(expectedKey, numberMaskingSetupResponse.Key);
            Assert.AreEqual(expectedName, numberMaskingSetupResponse.Name);
            Assert.AreEqual(expectedCallbackUrl, numberMaskingSetupResponse.CallbackUrl);
            Assert.AreEqual(expectedStatusUrl, numberMaskingSetupResponse.StatusUrl);
            Assert.AreEqual(new DateTimeOffset(DateTime.Parse(expectedInsertDateTime), TimeSpan.Zero),
                numberMaskingSetupResponse.InsertDateTime);
            Assert.AreEqual(new DateTimeOffset(DateTime.Parse(expectedUpdateDateTime), TimeSpan.Zero),
                numberMaskingSetupResponse.UpdateDateTime);
        }

        AssertResponse(numberMaskingApi.GetNumberMaskingConfiguration(givenKey), AssertNumberMaskingSetupResponse);
        AssertResponse(numberMaskingApi.GetNumberMaskingConfigurationAsync(givenKey).Result,
            AssertNumberMaskingSetupResponse);
        AssertResponseWithHttpInfo(numberMaskingApi.GetNumberMaskingConfigurationWithHttpInfo(givenKey),
            AssertNumberMaskingSetupResponse, 200);
        AssertResponseWithHttpInfo(numberMaskingApi.GetNumberMaskingConfigurationWithHttpInfoAsync(givenKey).Result,
            AssertNumberMaskingSetupResponse, 200);
    }

    [TestMethod]
    public void ShouldUpdateNumberMaskingConfiguration()
    {
        var expectedKey = "3FC0C9CB4AFAEAC67E8FC6BA3B1E044A";
        var expectedName = "UniqueConfigurationName";
        var expectedCallbackUrl = "https://example.com/1/callback";
        var expectedStatusUrl = "https://example.com/1/status";
        var expectedInsertDateTime = "2019-08-16T09:11:36.573";
        var expectedUpdateDateTime = "2019-08-16T09:11:37.573";

        var expectedResponse = $@"
            {{
              ""key"": ""{expectedKey}"",
              ""name"": ""{expectedName}"",
              ""callbackUrl"": ""{expectedCallbackUrl}"",
              ""statusUrl"": ""{expectedStatusUrl}"",
              ""insertDateTime"": ""{expectedInsertDateTime}"",
              ""updateDateTime"": ""{expectedUpdateDateTime}""
            }}";

        var givenName = "UniqueConfigurationName";
        var givenCallbackUrl = "https://example.com/1/callback";
        var givenStatusUrl = "https://example.com/1/status";

        var givenRequest = $@"
            {{
              ""name"": ""{givenName}"",
              ""callbackUrl"": ""{givenCallbackUrl}"",
              ""statusUrl"": ""{givenStatusUrl}""
            }}";

        var givenKey = "3FC0C9CB4AFAEAC67E8FC6BA3B1E044A";

        SetUpPutRequest(NUMBER_MASKING_CONFIGURATION_ENDPOINT.Replace("{key}", givenKey), 200, givenRequest,
            expectedResponse);

        var numberMaskingApi = new NumberMaskingApi(Configuration);

        var numberMaskingSetupBody = new NumberMaskingSetupBody(
            givenName,
            givenCallbackUrl,
            givenStatusUrl
        );

        void AssertNumberMaskingSetupResponse(NumberMaskingSetupResponse numberMaskingSetupResponse)
        {
            Assert.IsNotNull(numberMaskingSetupResponse);
            Assert.AreEqual(expectedKey, numberMaskingSetupResponse.Key);
            Assert.AreEqual(expectedName, numberMaskingSetupResponse.Name);
            Assert.AreEqual(expectedCallbackUrl, numberMaskingSetupResponse.CallbackUrl);
            Assert.AreEqual(expectedStatusUrl, numberMaskingSetupResponse.StatusUrl);
            Assert.AreEqual(new DateTimeOffset(DateTime.Parse(expectedInsertDateTime), TimeSpan.Zero),
                numberMaskingSetupResponse.InsertDateTime);
            Assert.AreEqual(new DateTimeOffset(DateTime.Parse(expectedUpdateDateTime), TimeSpan.Zero),
                numberMaskingSetupResponse.UpdateDateTime);
        }

        AssertResponse(numberMaskingApi.UpdateNumberMaskingConfiguration(givenKey, numberMaskingSetupBody),
            AssertNumberMaskingSetupResponse);
        AssertResponse(numberMaskingApi.UpdateNumberMaskingConfigurationAsync(givenKey, numberMaskingSetupBody).Result,
            AssertNumberMaskingSetupResponse);
        AssertResponseWithHttpInfo(
            numberMaskingApi.UpdateNumberMaskingConfigurationWithHttpInfo(givenKey, numberMaskingSetupBody),
            AssertNumberMaskingSetupResponse, 200);
        AssertResponseWithHttpInfo(
            numberMaskingApi.UpdateNumberMaskingConfigurationWithHttpInfoAsync(givenKey, numberMaskingSetupBody).Result,
            AssertNumberMaskingSetupResponse, 200);
    }

    [TestMethod]
    public void ShouldDeleteNumberMaskingConfiguration()
    {
        var givenKey = "3FC0C9CB4AFAEAC67E8FC6BA3B1E044A";

        SetUpDeleteRequest(NUMBER_MASKING_CONFIGURATION_ENDPOINT.Replace("{key}", givenKey), 200);

        var numberMaskingApi = new NumberMaskingApi(Configuration);

        AssertNoBodyResponseWithHttpInfo(numberMaskingApi.DeleteNumberMaskingConfigurationWithHttpInfo(givenKey), 200);
        AssertNoBodyResponseWithHttpInfo(
            numberMaskingApi.DeleteNumberMaskingConfigurationWithHttpInfoAsync(givenKey).Result, 200);
    }

    [TestMethod]
    public void ShouldUploadAudioFiles()
    {
        var expectedFileId = "cb702ae4-f356-4efd-b2dd-7a667b570af5";

        var expectedResponse = $@"
            {{
              ""fileId"": ""{expectedFileId}""
            }}";

        var givenUrl = "https://example.com/audio.mp3";

        var givenRequest = $@"
            {{
              ""url"": ""{givenUrl}""
            }}";

        SetUpPostRequest(NUMBER_MASKING_UPLOAD_ENDPOINT, 200, givenRequest, expectedResponse);

        var numberMaskingApi = new NumberMaskingApi(Configuration);

        var numberMaskingUploadBody = new NumberMaskingUploadBody(
            givenUrl
        );

        void AssertNumberMaskingUploadResponse(NumberMaskingUploadResponse numberMaskingUploadResponse)
        {
            Assert.IsNotNull(numberMaskingUploadResponse);
            Assert.AreEqual(expectedFileId, numberMaskingUploadResponse.FileId);
        }

        AssertResponse(numberMaskingApi.UploadAudioFiles(numberMaskingUploadBody), AssertNumberMaskingUploadResponse);
        AssertResponse(numberMaskingApi.UploadAudioFilesAsync(numberMaskingUploadBody).Result,
            AssertNumberMaskingUploadResponse);
        AssertResponseWithHttpInfo(numberMaskingApi.UploadAudioFilesWithHttpInfo(numberMaskingUploadBody),
            AssertNumberMaskingUploadResponse, 200);
        AssertResponseWithHttpInfo(numberMaskingApi.UploadAudioFilesWithHttpInfoAsync(numberMaskingUploadBody).Result,
            AssertNumberMaskingUploadResponse, 200);
    }

    [TestMethod]
    public void ShouldNumberMaskingCallbackApi()
    {
        var expectedPhoneNumber = "41792212112121";
        var expectedCallerId = "41793026731";
        var expectedFileUrl = "http://www.audioFileUrl.mp3";
        var expectedFileId = "f9850667-86c8-48d3-a9b2-9a6a372f5d00";
        var expectedEnabled = true;
        var expectedRecordCalleeAnnouncement = true;
        var expectedClientReferenceId = "7e8d64c0-6c72-4922-aa96-48728753c660";

        var expectedResponse = $@"
            {{
              ""phoneNumber"": ""{expectedPhoneNumber}"",
              ""callerId"": ""{expectedCallerId}"",
              ""announcements"": {{
                ""caller"": {{
                  ""fileUrl"": ""{expectedFileUrl}""
                }},
                ""callee"": {{
                  ""fileId"": ""{expectedFileId}""
                }}
              }},
              ""recording"": {{
                ""enabled"": {expectedEnabled.ToString().ToLower()},
                ""recordCalleeAnnouncement"": {expectedRecordCalleeAnnouncement.ToString().ToLower()}
              }},
              ""clientReferenceId"": ""{expectedClientReferenceId}""
            }}";

        var callsDialCallbackResponse = JsonConvert.DeserializeObject<CallsDialCallbackResponse>(expectedResponse);
        AssertCallsDialCallbackResponse(callsDialCallbackResponse!);

        var callsDialCallbackResponseSystemTextJson =
            JsonSerializer.Deserialize<CallsDialCallbackResponse>(expectedResponse);
        AssertCallsDialCallbackResponse(callsDialCallbackResponseSystemTextJson!);

        var givenFrom = "41793026727";
        var givenTo = "41793026731";
        var givenCorrelationId = "0f754338-1aff-4e09-a933-7d205ca7aed4";
        var givenNmCorrelationId = "7cb72e4b-cf9f-40b6-9fc4-79588d18a666";

        var givenRequest = $@"
            {{
              ""from"": ""{givenFrom}"",
              ""to"": ""{givenTo}"",
              ""correlationId"": ""{givenCorrelationId}"",
              ""nmCorrelationId"": ""{givenNmCorrelationId}""
            }}";

        var numberMaskingCallbackRequest = JsonConvert.DeserializeObject<NumberMaskingCallbackRequest>(givenRequest);
        AssertNumberMaskingCallbackRequest(numberMaskingCallbackRequest!);

        var numberMaskingCallbackRequestSystemTextJson =
            JsonSerializer.Deserialize<NumberMaskingCallbackRequest>(givenRequest);
        AssertNumberMaskingCallbackRequest(numberMaskingCallbackRequestSystemTextJson!);

        void AssertCallsDialCallbackResponse(CallsDialCallbackResponse callsDialCallbackResponse)
        {
            Assert.IsNotNull(callsDialCallbackResponse);
            Assert.AreEqual(expectedPhoneNumber, callsDialCallbackResponse.PhoneNumber);
            Assert.AreEqual(expectedCallerId, callsDialCallbackResponse.CallerId);
            Assert.AreEqual(expectedFileUrl, callsDialCallbackResponse.Announcements.Caller.FileUrl);
            Assert.AreEqual(expectedFileId, callsDialCallbackResponse.Announcements.Callee.FileId);
            Assert.AreEqual(expectedEnabled, callsDialCallbackResponse.Recording.Enabled);
            Assert.AreEqual(expectedRecordCalleeAnnouncement,
                callsDialCallbackResponse.Recording.RecordCalleeAnnouncement);
            Assert.AreEqual(expectedClientReferenceId, callsDialCallbackResponse.ClientReferenceId);
        }

        void AssertNumberMaskingCallbackRequest(NumberMaskingCallbackRequest numberMaskingCallbackRequest)
        {
            Assert.IsNotNull(numberMaskingCallbackRequest);
            Assert.AreEqual(givenFrom, numberMaskingCallbackRequest.From);
            Assert.AreEqual(givenTo, numberMaskingCallbackRequest.To);
            Assert.AreEqual(givenCorrelationId, numberMaskingCallbackRequest.CorrelationId);
            Assert.AreEqual(givenNmCorrelationId, numberMaskingCallbackRequest.NmCorrelationId);
        }
    }

    [TestMethod]
    public void ShouldNumberMaskingStatusApi()
    {
        var givenAction = "dial";
        var givenFrom = "41793026727";
        var givenTo = "41793026731";
        var givenTransferTo = "41793026785";
        var givenDuration = 15;
        var givenStatus = "answered";
        var givenNmCorrelationId = "7cb72e4b-cf9f-40b6-9fc4-79588d18a666";
        var givenRingingTime = "2018-01-01 12:00:00";
        var givenAnsweredTime = "2018-01-01 12:00:10";
        var givenCorrelationId = "0f754338-1aff-4e09-a933-7d205ca7aed4";
        var givenInboundDuration = 30;
        var givenCalculatedDuration = 15;
        var givenPricePerSecond = 0.01;
        var givenCurrency = "7e8d64c0-6c72-4922-aa96-48728753c660";
        var givenRecordingFileId = "EUR";
        var givenRecordingCalleeAnnouncement = true;
        var givenRecordingStatus = NumberMaskingRecordingStatus.Sftp;
        var givenClientReferenceId = "7e8d64c0-6c72-4922-aa96-48728753c660";

        var givenRequest = $@"
            {{
              ""action"": ""{givenAction}"",
              ""from"": ""{givenFrom}"",
              ""to"": ""{givenTo}"",
              ""transferTo"": ""{givenTransferTo}"",
              ""duration"": {givenDuration},
              ""status"": ""{givenStatus}"",
              ""nmCorrelationId"": ""{givenNmCorrelationId}"",
              ""ringingTime"": ""{givenRingingTime}"",
              ""answeredTime"": ""{givenAnsweredTime}"",
              ""correlationId"": ""{givenCorrelationId}"",
              ""inboundDuration"": {givenInboundDuration},
              ""calculatedDuration"": {givenCalculatedDuration},
              ""pricePerSecond"": {givenPricePerSecond},
              ""currency"": ""{givenCurrency}"",
              ""recordingFileId"": ""{givenRecordingFileId}"",
              ""recordCalleeAnnouncement"": {givenRecordingCalleeAnnouncement.ToString().ToLower()},
              ""recordingStatus"": ""{givenRecordingStatus}"",
              ""clientReferenceId"": ""{givenClientReferenceId}""
            }}";

        var numberMaskingStatusRequest = JsonConvert.DeserializeObject<NumberMaskingStatusRequest>(givenRequest);
        AssertNumberMaskingStatusRequest(numberMaskingStatusRequest!);

        var numberMaskingStatusRequestSystemTextJson =
            JsonSerializer.Deserialize<NumberMaskingStatusRequest>(givenRequest);
        AssertNumberMaskingStatusRequest(numberMaskingStatusRequestSystemTextJson!);

        void AssertNumberMaskingStatusRequest(NumberMaskingStatusRequest numberMaskingStatusRequest)
        {
            Assert.IsNotNull(numberMaskingStatusRequest);
            Assert.AreEqual(givenAction, numberMaskingStatusRequest.Action);
            Assert.AreEqual(givenFrom, numberMaskingStatusRequest.From);
            Assert.AreEqual(givenTo, numberMaskingStatusRequest.To);
            Assert.AreEqual(givenTransferTo, numberMaskingStatusRequest.TransferTo);
            Assert.AreEqual(givenDuration, numberMaskingStatusRequest.Duration);
            Assert.AreEqual(givenStatus, numberMaskingStatusRequest.Status);
            Assert.AreEqual(givenNmCorrelationId, numberMaskingStatusRequest.NmCorrelationId);
            Assert.AreEqual(givenRingingTime, numberMaskingStatusRequest.RingingTime);
            Assert.AreEqual(givenAnsweredTime, numberMaskingStatusRequest.AnsweredTime);
            Assert.AreEqual(givenCorrelationId, numberMaskingStatusRequest.CorrelationId);
            Assert.AreEqual(givenInboundDuration, numberMaskingStatusRequest.InboundDuration);
            Assert.AreEqual(givenCalculatedDuration, numberMaskingStatusRequest.CalculatedDuration);
            Assert.AreEqual(givenPricePerSecond, numberMaskingStatusRequest.PricePerSecond);
            Assert.AreEqual(givenCurrency, numberMaskingStatusRequest.Currency);
            Assert.AreEqual(givenRecordingFileId, numberMaskingStatusRequest.RecordingFileId);
            Assert.AreEqual(givenRecordingCalleeAnnouncement, numberMaskingStatusRequest.RecordCalleeAnnouncement);
            Assert.AreEqual(givenRecordingStatus, numberMaskingStatusRequest.RecordingStatus);
            Assert.AreEqual(givenClientReferenceId, numberMaskingStatusRequest.ClientReferenceId);
        }
    }

    [TestMethod]
    public void ShouldGetNumberMaskingCredentials()
    {
        var expectedApiId = "55ddccad2df62a4b615b7e3c472b2ab6";
        var expectedKey = "5da086b6a8e4424993646b8699c333ca";

        var expectedResponse = $@"
            {{
              ""apiId"": ""{expectedApiId}"",
              ""key"": ""{expectedKey}""
            }}";

        SetUpGetRequest(NUMBER_MASKING_CREDENTIALS_ENDPOINT, 200, expectedResponse);

        var numberMaskingApi = new NumberMaskingApi(Configuration);

        void AssertNumberMaskingCredentialsResponse(NumberMaskingCredentialsResponse numberMaskingCredentialsResponse)
        {
            Assert.IsNotNull(numberMaskingCredentialsResponse);
            Assert.AreEqual(expectedApiId, numberMaskingCredentialsResponse.ApiId);
            Assert.AreEqual(expectedKey, numberMaskingCredentialsResponse.Key);
        }

        AssertResponse(numberMaskingApi.GetNumberMaskingCredentials(), AssertNumberMaskingCredentialsResponse);
        AssertResponse(numberMaskingApi.GetNumberMaskingCredentialsAsync().Result,
            AssertNumberMaskingCredentialsResponse);
        AssertResponseWithHttpInfo(numberMaskingApi.GetNumberMaskingCredentialsWithHttpInfo(),
            AssertNumberMaskingCredentialsResponse, 200);
        AssertResponseWithHttpInfo(numberMaskingApi.GetNumberMaskingCredentialsWithHttpInfoAsync().Result,
            AssertNumberMaskingCredentialsResponse, 200);
    }

    [TestMethod]
    public void ShouldUpdateNumberMaskingCredentials()
    {
        var expectedApiId = "55ddccad2df62a4b615b7e3c472b2ab6";
        var expectedKey = "5da086b6a8e4424993646b8699c333ca";

        var expectedResponse = $@"
            {{
              ""apiId"": ""{expectedApiId}"",
              ""key"": ""{expectedKey}""
            }}";

        var givenApiId = "55ddccad2df62a4b615b7e3c472b2ab6";
        var givenKey = "5da086b6a8e4424993646b8699c333ca";

        var givenRequest = $@"
            {{
              ""apiId"": ""{givenApiId}"",
              ""key"": ""{givenKey}""
            }}";

        SetUpPutRequest(NUMBER_MASKING_CREDENTIALS_ENDPOINT, 200, givenRequest, expectedResponse);

        var numberMaskingApi = new NumberMaskingApi(Configuration);

        var numberMaskingCredentialsBody = new NumberMaskingCredentialsBody(
            givenApiId,
            givenKey
        );

        void AssertNumberMaskingCredentialsResponse(NumberMaskingCredentialsResponse numberMaskingCredentialsResponse)
        {
            Assert.IsNotNull(numberMaskingCredentialsResponse);
            Assert.AreEqual(expectedApiId, numberMaskingCredentialsResponse.ApiId);
            Assert.AreEqual(expectedKey, numberMaskingCredentialsResponse.Key);
        }

        AssertResponse(numberMaskingApi.UpdateNumberMaskingCredentials(numberMaskingCredentialsBody),
            AssertNumberMaskingCredentialsResponse);
        AssertResponse(numberMaskingApi.UpdateNumberMaskingCredentialsAsync(numberMaskingCredentialsBody).Result,
            AssertNumberMaskingCredentialsResponse);
        AssertResponseWithHttpInfo(
            numberMaskingApi.UpdateNumberMaskingCredentialsWithHttpInfo(numberMaskingCredentialsBody),
            AssertNumberMaskingCredentialsResponse, 200);
        AssertResponseWithHttpInfo(
            numberMaskingApi.UpdateNumberMaskingCredentialsWithHttpInfoAsync(numberMaskingCredentialsBody).Result,
            AssertNumberMaskingCredentialsResponse, 200);
    }

    [TestMethod]
    public void ShouldCreateNumberMaskingCredentials()
    {
        var expectedApiId = "55ddccad2df62a4b615b7e3c472b2ab6";
        var expectedKey = "5da086b6a8e4424993646b8699c333ca";

        var expectedResponse = $@"
            {{
              ""apiId"": ""{expectedApiId}"",
              ""key"": ""{expectedKey}""
            }}";

        var givenApiId = "55ddccad2df62a4b615b7e3c472b2ab6";
        var givenKey = "5da086b6a8e4424993646b8699c333ca";

        var givenRequest = $@"
            {{
              ""apiId"": ""{givenApiId}"",
              ""key"": ""{givenKey}""
            }}";

        SetUpPostRequest(NUMBER_MASKING_CREDENTIALS_ENDPOINT, 200, givenRequest, expectedResponse);

        var numberMaskingApi = new NumberMaskingApi(Configuration);

        var numberMaskingCredentialsBody = new NumberMaskingCredentialsBody(
            givenApiId,
            givenKey
        );

        void AssertNumberMaskingCredentialsResponse(NumberMaskingCredentialsResponse numberMaskingCredentialsResponse)
        {
            Assert.IsNotNull(numberMaskingCredentialsResponse);
            Assert.AreEqual(expectedApiId, numberMaskingCredentialsResponse.ApiId);
            Assert.AreEqual(expectedKey, numberMaskingCredentialsResponse.Key);
        }

        AssertResponse(numberMaskingApi.CreateNumberMaskingCredentials(numberMaskingCredentialsBody),
            AssertNumberMaskingCredentialsResponse);
        AssertResponse(numberMaskingApi.CreateNumberMaskingCredentialsAsync(numberMaskingCredentialsBody).Result,
            AssertNumberMaskingCredentialsResponse);
        AssertResponseWithHttpInfo(
            numberMaskingApi.CreateNumberMaskingCredentialsWithHttpInfo(numberMaskingCredentialsBody),
            AssertNumberMaskingCredentialsResponse, 200);
        AssertResponseWithHttpInfo(
            numberMaskingApi.CreateNumberMaskingCredentialsWithHttpInfoAsync(numberMaskingCredentialsBody).Result,
            AssertNumberMaskingCredentialsResponse, 200);
    }

    [TestMethod]
    public void ShouldDeleteNumberMaskingCredentials()
    {
        SetUpDeleteRequest(NUMBER_MASKING_CREDENTIALS_ENDPOINT, 204);

        var numberMaskingApi = new NumberMaskingApi(Configuration);

        AssertNoBodyResponseWithHttpInfo(numberMaskingApi.DeleteNumberMaskingCredentialsWithHttpInfo(), 204);
        AssertNoBodyResponseWithHttpInfo(numberMaskingApi.DeleteNumberMaskingCredentialsWithHttpInfoAsync().Result,
            204);
    }
}