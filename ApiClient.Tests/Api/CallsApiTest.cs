using System.Text;
using Infobip.Api.Client;
using Infobip.Api.Client.Api;
using Infobip.Api.Client.Client;
using Infobip.Api.Client.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ApiClient.Tests.Api;

[TestClass]
public class CallsApiTest : ApiTest
{
    protected const string GET_CALLS_ENDPOINT = "/calls/1/calls";
    protected const string CREATE_CALL_ENDPOINT = "/calls/1/calls";
    protected const string GET_CALL_ENDPOINT = "/calls/1/calls/{callId}";
    protected const string GET_CALLS_HISTORY_ENDPOINT = "/calls/1/calls/history";
    protected const string GET_CALL_HISTORY_ENDPOINT = "/calls/1/calls/{callId}/history";
    protected const string CONNECT_CALLS_ENDPOINT = "/calls/1/connect";
    protected const string CONNECT_WITH_NEW_CALL_ENDPOINT = "/calls/1/calls/{callId}/connect";
    protected const string SEND_RINGING_ENDPOINT = "/calls/1/calls/{callId}/send-ringing";
    protected const string PRE_ANSWER_CALL_ENDPOINT = "/calls/1/calls/{callId}/pre-answer";
    protected const string ANSWER_CALL_ENDPOINT = "/calls/1/calls/{callId}/answer";
    protected const string HANGUP_CALL_ENDPOINT = "/calls/1/calls/{callId}/hangup";
    protected const string CALL_PLAY_FILE_ENDPOINT = "/calls/1/calls/{callId}/play";
    protected const string CALL_STOP_PLAYING_FILE_ENDPOINT = "/calls/1/calls/{callId}/stop-play";
    protected const string CALL_SAY_TEXT_ENDPOINT = "/calls/1/calls/{callId}/say";
    protected const string CALL_SEND_DTMF_ENDPOINT = "/calls/1/calls/{callId}/send-dtmf";
    protected const string CALL_CAPTURE_DTMF_ENDPOINT = "/calls/1/calls/{callId}/capture/dtmf";
    protected const string CALL_CAPTURE_SPEECH_ENDPOINT = "/calls/1/calls/{callId}/capture/speech";
    protected const string CALL_START_TRANSCRIPTION_ENDPOINT = "/calls/1/calls/{callId}/start-transcription";
    protected const string CALL_STOP_TRANSCRIPTION_ENDPOINT = "/calls/1/calls/{callId}/stop-transcription";
    protected const string CALL_START_RECORDING_ENDPOINT = "/calls/1/calls/{callId}/start-recording";
    protected const string CALL_STOP_RECORDING_ENDPOINT = "/calls/1/calls/{callId}/stop-recording";
    protected const string START_MEDIA_STREAM_ENDPOINT = "/calls/1/calls/{callId}/start-media-stream";
    protected const string STOP_MEDIA_STREAM_ENDPOINT = "/calls/1/calls/{callId}/stop-media-stream";
    protected const string APPLICATION_TRANSFER = "/calls/1/calls/{callId}/application-transfer";

    protected const string APPLICATION_TRANSFER_ACCEPT =
        "/calls/1/calls/{callId}/application-transfer/{transferId}/accept";

    protected const string APPLICATION_TRANSFER_REJECT =
        "/calls/1/calls/{callId}/application-transfer/{transferId}/reject";

    protected const string GET_CONFERENCES = "/calls/1/conferences";
    protected const string CREATE_CONFERENCE = "/calls/1/conferences";
    protected const string GET_CONFERENCE = "/calls/1/conferences/{conferenceId}";
    protected const string UPDATE_CONFERENCE = "/calls/1/conferences/{conferenceId}";
    protected const string GET_CONFERENCES_HISTORY = "/calls/1/conferences/history";
    protected const string GET_CONFERENCE_HISTORY = "/calls/1/conferences/{conferenceId}/history";
    protected const string ADD_NEW_CONFERENCE_CALL = "/calls/1/conferences/{conferenceId}/call";
    protected const string ADD_EXISTING_CONFERENCE_CALL = "/calls/1/conferences/{conferenceId}/call/{callId}";
    protected const string UPDATE_CONFERENCE_CALL = "/calls/1/conferences/{conferenceId}/call/{callId}";
    protected const string REMOVE_CONFERENCE_CALL = "/calls/1/conferences/{conferenceId}/call/{callId}";
    protected const string HANGUP_CONFERENCE = "/calls/1/conferences/{conferenceId}/hangup";
    protected const string CONFERENCE_PLAY_FILE = "/calls/1/conferences/{conferenceId}/play";
    protected const string CONFERENCE_STOP_PLAYING_FILE = "/calls/1/conferences/{conferenceId}/stop-play";
    protected const string CONFERENCE_SAY_TEXT = "/calls/1/conferences/{conferenceId}/say";
    protected const string CONFERENCE_START_RECORDING = "/calls/1/conferences/{conferenceId}/start-recording";
    protected const string CONFERENCE_STOP_RECORDING = "/calls/1/conferences/{conferenceId}/stop-recording";

    protected const string CONFERENCE_BROADCAST_WEBRTC_TEXT =
        "/calls/1/conferences/{conferenceId}/broadcast-webrtc-text";

    protected const string GET_DIALOGS = "/calls/1/dialogs";
    protected const string CREATE_DIALOG = "/calls/1/dialogs";

    protected const string CREATE_DIALOG_WITH_EXISTING_CALLS =
        "/calls/1/dialogs/parent-call/{parentCallId}/child-call/{childCallId}";

    protected const string GET_DIALOG = "/calls/1/dialogs/{dialogId}";
    protected const string GET_DIALOGS_HISTORY = "/calls/1/dialogs/history";
    protected const string GET_DIALOG_HISTORY = "/calls/1/dialogs/{dialogId}/history";
    protected const string HANGUP_DIALOG = "/calls/1/dialogs/{dialogId}/hangup";
    protected const string DIALOG_PLAY_FILE = "/calls/1/dialogs/{dialogId}/play";
    protected const string DIALOG_STOP_PLAYING_FILE = "/calls/1/dialogs/{dialogId}/stop-play";
    protected const string DIALOG_SAY_TEXT = "/calls/1/dialogs/{dialogId}/say";
    protected const string DIALOG_START_RECORDING = "/calls/1/dialogs/{dialogId}/start-recording";
    protected const string DIALOG_STOP_RECORDING = "/calls/1/dialogs/{dialogId}/stop-recording";
    protected const string DIALOG_BROADCAST_WEBRTC_TEXT = "/calls/1/dialogs/{dialogId}/broadcast-webrtc-text";
    protected const string GET_SIP_TRUNKS = "/calls/1/sip-trunks";
    protected const string CREATE_SIP_TRUNK = "/calls/1/sip-trunks";
    protected const string GET_SIP_TRUNK = "/calls/1/sip-trunks/{sipTrunkId}";
    protected const string UPDATE_SIP_TRUNK = "/calls/1/sip-trunks/{sipTrunkId}";
    protected const string DELETE_SIP_TRUNK = "/calls/1/sip-trunks/{sipTrunkId}";
    protected const string RESET_SIP_TRUNK_PASSWORD = "/calls/1/sip-trunks/{sipTrunkId}/reset-password";
    protected const string GET_SIP_TRUNK_STATUS = "/calls/1/sip-trunks/{sipTrunkId}/status";
    protected const string SET_SIP_TRUNK_STATUS = "/calls/1/sip-trunks/{sipTrunkId}/status";
    protected const string CREATE_SIP_TRUNK_SERVICE_ADDRESS = "/calls/1/sip-trunks/service-addresses";
    protected const string GET_SIP_TRUNK_SERVICE_ADDRESSES = "/calls/1/sip-trunks/service-addresses";

    protected const string GET_SIP_TRUNK_SERVICE_ADDRESS =
        "/calls/1/sip-trunks/service-addresses/{sipTrunkServiceAddressId}";

    protected const string UPDATE_SIP_TRUNK_SERVICE_ADDRESS =
        "/calls/1/sip-trunks/service-addresses/{sipTrunkServiceAddressId}";

    protected const string DELETE_SIP_TRUNK_SERVICE_ADDRESS =
        "/calls/1/sip-trunks/service-addresses/{sipTrunkServiceAddressId}";

    protected const string GET_COUNTRIES = "/calls/1/sip-trunks/service-addresses/countries";
    protected const string GET_REGIONS = "/calls/1/sip-trunks/service-addresses/countries/regions";
    protected const string GET_CALLS_FILES = "/calls/1/files";
    protected const string UPLOAD_CALLS_AUDIO_FILE = "/calls/1/files";
    protected const string GET_CALLS_FILE = "/calls/1/files/{fileId}";
    protected const string DELETE_CALLS_FILE = "/calls/1/files/{fileId}";
    protected const string GET_CALLS_RECORDINGS = "/calls/1/recordings/calls";
    protected const string GET_CALL_RECORDINGS = "/calls/1/recordings/calls/{callId}";
    protected const string DELETE_CALL_RECORDINGS = "/calls/1/recordings/calls/{callId}";
    protected const string GET_CONFERENCES_RECORDINGS = "/calls/1/recordings/conferences";
    protected const string GET_CONFERENCE_RECORDINGS = "/calls/1/recordings/conferences/{conferenceId}";
    protected const string DELETE_CONFERENCE_RECORDINGS = "/calls/1/recordings/conferences/{conferenceId}";
    protected const string COMPOSE_CONFERENCE_RECORDING = "/calls/1/recordings/conferences/{conferenceId}/compose";
    protected const string GET_DIALOGS_RECORDINGS = "/calls/1/recordings/dialogs";
    protected const string GET_DIALOG_RECORDINGS = "/calls/1/recordings/dialogs/{dialogId}";
    protected const string DELETE_DIALOG_RECORDINGS = "/calls/1/recordings/dialogs/{dialogId}";
    protected const string COMPOSE_DIALOG_RECORDING = "/calls/1/recordings/dialogs/{dialogId}/compose";
    protected const string DOWNLOAD_RECORDING_FILE = "/calls/1/recordings/files/{fileId}";
    protected const string DELETE_RECORDING_FILE = "/calls/1/recordings/files/{fileId}";
    protected const string CREATE_MEDIA_STREAM_CONFIG = "/calls/1/media-stream-configs";
    protected const string GET_MEDIA_STREAM_CONFIGS = "/calls/1/media-stream-configs";
    protected const string GET_MEDIA_STREAM_CONFIG = "/calls/1/media-stream-configs/{mediaStreamConfigId}";
    protected const string DELETE_MEDIA_STREAM_CONFIG = "/calls/1/media-stream-configs/{mediaStreamConfigId}";
    protected const string UPDATE_MEDIA_STREAM_CONFIG = "/calls/1/media-stream-configs/{mediaStreamConfigId}";
    protected const string CREATE_BULK = "/calls/1/bulks";
    protected const string GET_BULK_STATUS = "/calls/1/bulks/{bulkId}";
    protected const string RESCHEDULE_BULK = "/calls/1/bulks/{bulkId}/reschedule";
    protected const string PAUSE_BULK = "/calls/1/bulks/{bulkId}/pause";
    protected const string RESUME_BULK = "/calls/1/bulks/{bulkId}/resume";
    protected const string CANCEL_BULK = "/calls/1/bulks/{bulkId}/cancel";
    protected const string CALLS_CONFIGURATIONS = "/calls/1/configurations";
    protected const string CALLS_CONFIGURATION = "/calls/1/configurations/{callsConfigurationId}";

    [TestMethod]
    public void ShouldGetCalls()
    {
        var givenType = CallEndpointType.Phone;
        var givenCallsConfigurationId = "dc5942707c704551a00cd2ea";
        var givenApplicationId = "61c060db2675060027d8c7a6";
        var givenFrom = "44790123456";
        var givenTo = "44790987654";
        var givenDirection = CallDirection.Outbound;
        var givenStatus = CallState.Finished;
        var givenStartTimeAfter = DateTime.Parse("2022-05-01T14:25:45.125+00:00");
        var givenConferenceId = "066675c6-0db6-0db9-b032-031964d09af4";
        var givenDialogId = "6c73cbdc-c956-4bf5-a026-318236559167";
        var givenBulkId = "bde6deaa-23af-4340-aac7-f3fa063c4215";
        var givenPage = 0;
        var givenSize = 10;

        var givenResponse = @"
        {
          ""results"": [
            {
              ""id"": ""d8d84155-3831-43fb-91c9-bb897149a79d"",
              ""endpoint"": {
                ""phoneNumber"": ""41792030000"",
                ""type"": ""PHONE""
              },
              ""from"": ""44790123456"",
              ""to"": ""44790987654"",
              ""direction"": ""INBOUND"",
              ""state"": ""CALLING"",
              ""media"": {
                ""audio"": {
                  ""muted"": true,
                  ""userMuted"": true,
                  ""deaf"": true
                },
                ""video"": {
                  ""camera"": true,
                  ""screenShare"": true
                }
              },
              ""startTime"": ""2024-09-18T13:36:22.000+00:00"",
              ""answerTime"": ""2024-09-18T13:36:22.000+00:00"",
              ""endTime"": ""2024-09-18T13:36:22.000+00:00"",
              ""parentCallId"": ""3ad8805e-d401-424e-9b03-e02a2016a5e2"",
              ""machineDetection"": {
                ""detectionResult"": ""HUMAN"",
                ""customData"": {
                  ""property1"": ""string"",
                  ""property2"": ""string""
                }
              },
              ""ringDuration"": 3,
              ""callsConfigurationId"": ""dc5942707c704551a00cd2ea"",
              ""platform"": {
                ""entityId"": ""string"",
                ""applicationId"": ""string""
              },
              ""conferenceId"": ""034e622a-cc7e-456d-8a10-0ba43b11aa5e"",
              ""customData"": {
                ""key1"": ""value1"",
                ""key2"": ""value2""
              },
              ""dialogId"": ""5aee53f4-72f8-484b-bfcc-10c5f5476f70""
            }
          ],
          ""paging"": {
            ""page"": 0,
            ""size"": 1,
            ""totalPages"": 0,
            ""totalResults"": 0
          }
        }";

        var givenParameters = new Dictionary<string, string>
        {
            { "type", GetEnumAttributeValue(givenType) },
            { "callsConfigurationId", givenCallsConfigurationId },
            { "applicationId", givenApplicationId },
            { "from", givenFrom },
            { "to", givenTo },
            { "direction", GetEnumAttributeValue(givenDirection) },
            { "status", GetEnumAttributeValue(givenStatus) },
            { "startTimeAfter", givenStartTimeAfter.ToString("o") },
            { "conferenceId", givenConferenceId },
            { "dialogId", givenDialogId },
            { "bulkId", givenBulkId },
            { "page", givenPage.ToString() },
            { "size", givenSize.ToString() }
        };

        SetUpGetRequest(GET_CALLS_ENDPOINT, 200, givenResponse, givenParameters);

        var callsApi = new CallsApi(configuration);

        var response = callsApi.GetCalls(givenType, givenCallsConfigurationId, givenApplicationId, givenFrom, givenTo,
            givenDirection, givenStatus, givenStartTimeAfter, givenConferenceId, givenDialogId, givenBulkId, givenPage,
            givenSize);

        var expectedResponse = new CallPage
        {
            Results = new List<Call>
            {
                new(
                    endpoint: new CallsPhoneEndpoint("41792030000"),
                    id: "d8d84155-3831-43fb-91c9-bb897149a79d",
                    from: "44790123456",
                    to: "44790987654",
                    direction: CallDirection.Inbound,
                    state: CallState.Calling,
                    media: new CallsMediaProperties
                    (
                        new CallsAudioMediaProperties(true, true, true),
                        new CallsVideoMediaProperties(true, true)
                    ),
                    startTime: DateTime.Parse("2024-09-18T13:36:22.000+00:00"),
                    answerTime: DateTime.Parse("2024-09-18T13:36:22.000+00:00"),
                    endTime: DateTime.Parse("2024-09-18T13:36:22.000+00:00"),
                    parentCallId: "3ad8805e-d401-424e-9b03-e02a2016a5e2",
                    machineDetection: new CallsMachineDetectionProperties
                    (
                        CallsDetectionResult.Human,
                        new Dictionary<string, string>
                        {
                            { "property1", "string" },
                            { "property2", "string" }
                        }
                    ),
                    ringDuration: 3,
                    callsConfigurationId: "dc5942707c704551a00cd2ea",
                    platform: new Platform("string", "string"),
                    conferenceId: "034e622a-cc7e-456d-8a10-0ba43b11aa5e",
                    customData: new Dictionary<string, string>
                    {
                        { "key1", "value1" },
                        { "key2", "value2" }
                    },
                    dialogId: "5aee53f4-72f8-484b-bfcc-10c5f5476f70"
                )
            },
            Paging = new PageInfo(0, 1)
        };

        Assert.AreEqual(expectedResponse, response);
    }

    [TestMethod]
    public void ShouldCreateCall()
    {
        var givenRequest = @"
        {
          ""endpoint"": {
            ""type"": ""WEBRTC"",
            ""identity"": ""Bob""
          },
          ""from"": ""Alice"",
          ""fromDisplayName"": ""Alice in Wonderland"",
          ""connectTimeout"": 30,
          ""recording"": {
            ""recordingType"": ""AUDIO_AND_VIDEO""
          },
          ""maxDuration"": 300,
          ""callsConfigurationId"": ""dc5942707c704551a00cd2ea"",
          ""platform"": {
            ""applicationId"": ""61c060db2675060027d8c7a6""
          }
        }";

        var givenResponse = @"
        {
          ""id"": ""d8d84155-3831-43fb-91c9-bb897149a79d"",
          ""endpoint"": {
            ""type"": ""WEBRTC"",
            ""identity"": ""Bob""
          },
          ""from"": ""Alice"",
          ""to"": ""Bob"",
          ""direction"": ""OUTBOUND"",
          ""state"": ""CALLING"",
          ""media"": {
            ""audio"": {
              ""muted"": false,
              ""deaf"": false
            },
            ""video"": {
              ""camera"": false,
              ""screenShare"": false
            }
          },
          ""startTime"": ""2022-01-01T00:00:00.100+00:00"",
          ""answerTime"": ""2022-01-01T00:00:02.100+00:00"",
          ""ringDuration"": 2,
          ""callsConfigurationId"": ""dc5942707c704551a00cd2ea"",
          ""platform"": {
            ""applicationId"": ""61c060db2675060027d8c7a6""
          },
          ""conferenceId"": ""034e622a-cc7e-456d-8a10-0ba43b11aa5e"",
          ""customData"": {
            ""key1"": ""value1"",
            ""key2"": ""value2""
          }
        }";

        SetUpPostRequest(CREATE_CALL_ENDPOINT, 200, givenRequest, givenResponse);

        var api = new CallsApi(configuration);

        var request = new CallRequest(
            new CallsWebRtcEndpoint("Bob"),
            callsConfigurationId: "dc5942707c704551a00cd2ea",
            from: "Alice",
            fromDisplayName: "Alice in Wonderland",
            connectTimeout: 30,
            recording: new CallRecordingRequest(CallsRecordingType.AudioAndVideo),
            maxDuration: 300,
            platform: new Platform(applicationId: "61c060db2675060027d8c7a6")
        );

        var response = api.CreateCall(request);

        var expectedResponse = new Call(
            endpoint: new CallsWebRtcEndpoint("Bob"),
            id: "d8d84155-3831-43fb-91c9-bb897149a79d",
            from: "Alice",
            to: "Bob",
            direction: CallDirection.Outbound,
            state: CallState.Calling,
            media: new CallsMediaProperties(
                new CallsAudioMediaProperties(),
                new CallsVideoMediaProperties()
            ),
            startTime: DateTime.Parse("2022-01-01T00:00:00.100+00:00"),
            answerTime: DateTime.Parse("2022-01-01T00:00:02.100+00:00"),
            ringDuration: 2,
            callsConfigurationId: "dc5942707c704551a00cd2ea",
            platform: new Platform(applicationId: "61c060db2675060027d8c7a6"),
            conferenceId: "034e622a-cc7e-456d-8a10-0ba43b11aa5e",
            customData: new Dictionary<string, string>
            {
                { "key1", "value1" },
                { "key2", "value2" }
            }
        );

        Assert.AreEqual(expectedResponse, response);
    }

    [TestMethod]
    public void ShouldCreateCallWithoutSpecifyingFromField()
    {
        var givenRequest = @"
        {
          ""endpoint"": {
            ""type"": ""WEBRTC"",
            ""identity"": ""Bob""
          },
          ""fromDisplayName"": ""Alice in Wonderland"",
          ""connectTimeout"": 30,
          ""recording"": {
            ""recordingType"": ""AUDIO_AND_VIDEO""
          },
          ""maxDuration"": 300,
          ""callsConfigurationId"": ""dc5942707c704551a00cd2ea"",
          ""platform"": {
            ""applicationId"": ""61c060db2675060027d8c7a6""
          }
        }";

        var givenResponse = @"
        {
          ""id"": ""d8d84155-3831-43fb-91c9-bb897149a79d"",
          ""endpoint"": {
            ""type"": ""WEBRTC"",
            ""identity"": ""Bob""
          },
          ""from"": ""Alice"",
          ""to"": ""Bob"",
          ""direction"": ""OUTBOUND"",
          ""state"": ""CALLING"",
          ""media"": {
            ""audio"": {
              ""muted"": false,
              ""deaf"": false
            },
            ""video"": {
              ""camera"": false,
              ""screenShare"": false
            }
          },
          ""startTime"": ""2022-01-01T00:00:00.100+00:00"",
          ""answerTime"": ""2022-01-01T00:00:02.100+00:00"",
          ""ringDuration"": 2,
          ""callsConfigurationId"": ""dc5942707c704551a00cd2ea"",
          ""platform"": {
            ""applicationId"": ""61c060db2675060027d8c7a6""
          },
          ""conferenceId"": ""034e622a-cc7e-456d-8a10-0ba43b11aa5e"",
          ""customData"": {
            ""key1"": ""value1"",
            ""key2"": ""value2""
          }
        }";

        SetUpPostRequest(CREATE_CALL_ENDPOINT, 200, givenRequest, givenResponse);

        var api = new CallsApi(configuration);

        var request = new CallRequest(
            new CallsWebRtcEndpoint("Bob"),
            callsConfigurationId: "dc5942707c704551a00cd2ea",
            fromDisplayName: "Alice in Wonderland",
            connectTimeout: 30,
            recording: new CallRecordingRequest(CallsRecordingType.AudioAndVideo),
            maxDuration: 300,
            platform: new Platform(applicationId: "61c060db2675060027d8c7a6")
        );

        var response = api.CreateCall(request);

        var expectedResponse = new Call(
            endpoint: new CallsWebRtcEndpoint("Bob"),
            id: "d8d84155-3831-43fb-91c9-bb897149a79d",
            from: "Alice",
            to: "Bob",
            direction: CallDirection.Outbound,
            state: CallState.Calling,
            media: new CallsMediaProperties(
                new CallsAudioMediaProperties(),
                new CallsVideoMediaProperties()
            ),
            startTime: DateTime.Parse("2022-01-01T00:00:00.100+00:00"),
            answerTime: DateTime.Parse("2022-01-01T00:00:02.100+00:00"),
            ringDuration: 2,
            callsConfigurationId: "dc5942707c704551a00cd2ea",
            platform: new Platform(applicationId: "61c060db2675060027d8c7a6"),
            conferenceId: "034e622a-cc7e-456d-8a10-0ba43b11aa5e",
            customData: new Dictionary<string, string>
            {
                { "key1", "value1" },
                { "key2", "value2" }
            }
        );

        Assert.AreEqual(expectedResponse, response);
    }

    [TestMethod]
    public void ShouldGetCall()
    {
        var givenCallId = "d8d84155-3831-43fb-91c9-bb897149a79d";

        var givenResponse = $@"
        {{
          ""id"": ""{givenCallId}"",
          ""endpoint"": {{
            ""type"": ""PHONE"",
            ""phoneNumber"": ""44790123456""
          }},
          ""from"": ""44790123456"",
          ""to"": ""44790123456"",
          ""direction"": ""OUTBOUND"",
          ""state"": ""CALLING"",
          ""media"": {{
            ""audio"": {{
              ""muted"": false,
              ""deaf"": false
            }},
            ""video"": {{
              ""camera"": false,
              ""screenShare"": false
            }}
          }},
          ""startTime"": ""2022-01-01T00:00:00.100+00:00"",
          ""answerTime"": ""2022-01-01T00:00:02.100+00:00"",
          ""ringDuration"": 2,
          ""callsConfigurationId"": ""dc5942707c704551a00cd2ea"",
          ""platform"": {{
            ""applicationId"": ""61c060db2675060027d8c7a6""
          }},
          ""conferenceId"": ""034e622a-cc7e-456d-8a10-0ba43b11aa5e"",
          ""customData"": {{
            ""key1"": ""value1"",
            ""key2"": ""value2""
          }}
        }}";

        SetUpGetRequest(GET_CALL_ENDPOINT.Replace("{callId}", givenCallId), 200, givenResponse);

        var api = new CallsApi(configuration);

        var response = api.GetCall(givenCallId);

        var expectedResponse = new Call(
            endpoint: new CallsPhoneEndpoint("44790123456"),
            id: givenCallId,
            from: "44790123456",
            to: "44790123456",
            direction: CallDirection.Outbound,
            state: CallState.Calling,
            media: new CallsMediaProperties(
                new CallsAudioMediaProperties(),
                new CallsVideoMediaProperties()
            ),
            startTime: DateTime.Parse("2022-01-01T00:00:00.100+00:00"),
            answerTime: DateTime.Parse("2022-01-01T00:00:02.100+00:00"),
            ringDuration: 2,
            callsConfigurationId: "dc5942707c704551a00cd2ea",
            platform: new Platform(applicationId: "61c060db2675060027d8c7a6"),
            conferenceId: "034e622a-cc7e-456d-8a10-0ba43b11aa5e",
            customData: new Dictionary<string, string>
            {
                { "key1", "value1" },
                { "key2", "value2" }
            }
        );

        Assert.AreEqual(expectedResponse, response);
    }

    [TestMethod]
    public void ShouldGetCallsHistory()
    {
        var givenType = CallEndpointType.Phone;
        var givenCallsConfigurationId = "dc5942707c704551a00cd2ea";
        var givenApplicationId = "61c060db2675060027d8c7a6";
        var givenFrom = "44790123456";
        var givenTo = "44790987654";
        var givenDirection = CallDirection.Outbound;
        var givenStatus = CallState.Finished;
        var givenStartTimeAfter = DateTime.Parse("2022-05-01T14:25:45.125+00:00");
        var givenEndTimeBefore = DateTime.Parse("2022-05-01T14:26:45.125+00:00");
        var givenConferenceId = "066675c6-0db6-0db9-b032-031964d09af4";
        var givenDialogId = "6c73cbdc-c956-4bf5-a026-318236559167";
        var givenBulkId = "bde6deaa-23af-4340-aac7-f3fa063c4215";
        var givenPage = 0;
        var givenSize = 10;

        var givenResponse = @"
        {
          ""results"": [
            {
              ""callId"": ""d8d84155-3831-43fb-91c9-bb897149a79d"",
              ""endpoint"": {
                ""phoneNumber"": ""41792030000"",
                ""type"": ""PHONE""
              },
              ""from"": ""44790123456"",
              ""to"": ""44790987654"",
              ""direction"": ""INBOUND"",
              ""state"": ""CALLING"",
              ""startTime"": ""2024-09-19T09:40:41.000+00:00"",
              ""answerTime"": ""2024-09-19T09:40:41.000+00:00"",
              ""endTime"": ""2024-09-19T09:40:41.000+00:00"",
              ""parentCallId"": ""3ad8805e-d401-424e-9b03-e02a2016a5e2"",
              ""machineDetection"": {
                ""detectionResult"": ""HUMAN"",
                ""customData"": {
                  ""property1"": ""string"",
                  ""property2"": ""string""
                }
              },
              ""ringDuration"": 3,
              ""callsConfigurationIds"": [
                ""a1b06592152e08646b08c057""
              ],
              ""platform"": {
                ""entityId"": ""string"",
                ""applicationId"": ""string""
              },
              ""conferenceIds"": [
                ""066675c6-0db6-0db9-b032-031964d09af4""
              ],
              ""duration"": 5,
              ""hasCameraVideo"": false,
              ""hasScreenshareVideo"": false,
              ""errorCode"": {
                ""id"": 10000,
                ""name"": ""NORMAL_HANGUP"",
                ""description"": ""The call has ended with hangup initiated by caller, callee or API""
              },
              ""customData"": {
                ""key1"": ""value1"",
                ""key2"": ""value2""
              },
              ""dialogId"": ""string"",
              ""sender"": ""string"",
              ""hangupSource"": ""ENDPOINT""
            }
          ],
          ""paging"": {
            ""page"": 0,
            ""size"": 1,
            ""totalPages"": 0,
            ""totalResults"": 0
          }
        }";

        var queryParameters = new Dictionary<string, string>
        {
            { "type", GetEnumAttributeValue(givenType) },
            { "callsConfigurationId", givenCallsConfigurationId },
            { "applicationId", givenApplicationId },
            { "from", givenFrom },
            { "to", givenTo },
            { "direction", GetEnumAttributeValue(givenDirection) },
            { "status", GetEnumAttributeValue(givenStatus) },
            { "startTimeAfter", givenStartTimeAfter.ToString("o") },
            { "endTimeBefore", givenEndTimeBefore.ToString("o") },
            { "conferenceId", givenConferenceId },
            { "dialogId", givenDialogId },
            { "bulkId", givenBulkId },
            { "page", givenPage.ToString() },
            { "size", givenSize.ToString() }
        };

        SetUpGetRequest(GET_CALLS_HISTORY_ENDPOINT, 200, givenResponse, queryParameters);

        var api = new CallsApi(configuration);

        var response = api.GetCallsHistory(givenType, givenCallsConfigurationId, givenApplicationId, givenFrom, givenTo,
            givenDirection, givenStatus, givenStartTimeAfter, givenEndTimeBefore, givenConferenceId, givenDialogId,
            givenBulkId, givenPage, givenSize);

        var expectedResponse = new CallLogPage
        {
            Results = new List<CallLog>
            {
                new(
                    endpoint: new CallsPhoneEndpoint("41792030000"),
                    callId: "d8d84155-3831-43fb-91c9-bb897149a79d",
                    from: "44790123456",
                    to: "44790987654",
                    direction: CallDirection.Inbound,
                    state: CallState.Calling,
                    startTime: DateTime.Parse("2024-09-19T09:40:41.000+00:00"),
                    answerTime: DateTime.Parse("2024-09-19T09:40:41.000+00:00"),
                    endTime: DateTime.Parse("2024-09-19T09:40:41.000+00:00"),
                    parentCallId: "3ad8805e-d401-424e-9b03-e02a2016a5e2",
                    machineDetection: new CallsMachineDetectionProperties
                    (
                        CallsDetectionResult.Human,
                        new Dictionary<string, string>
                        {
                            { "property1", "string" },
                            { "property2", "string" }
                        }
                    ),
                    ringDuration: 3,
                    callsConfigurationIds: new List<string> { "a1b06592152e08646b08c057" },
                    platform: new Platform("string", "string"),
                    conferenceIds: new List<string> { "066675c6-0db6-0db9-b032-031964d09af4" },
                    duration: 5,
                    hasCameraVideo: false,
                    hasScreenshareVideo: false,
                    errorCode: new CallsErrorCodeInfo
                    (
                        10000,
                        "NORMAL_HANGUP",
                        "The call has ended with hangup initiated by caller, callee or API"
                    ),
                    customData: new Dictionary<string, string>
                    {
                        { "key1", "value1" },
                        { "key2", "value2" }
                    },
                    dialogId: "string",
                    sender: "string",
                    hangupSource: CallsHangupSource.Endpoint
                )
            },
            Paging = new PageInfo
            (
                0,
                1
            )
        };

        Assert.AreEqual(expectedResponse, response);
    }

    [TestMethod]
    public void ShouldGetCallHistory()
    {
        var givenCallId = "d8d84155-3831-43fb-91c9-bb897149a79d";

        var givenResponse = $@"
        {{
          ""callId"": ""{givenCallId}"",
          ""endpoint"": {{
            ""type"": ""PHONE"",
            ""phoneNumber"": ""44790123456""
          }},
          ""from"": ""44790123456"",
          ""to"": ""44790123456"",
          ""direction"": ""OUTBOUND"",
          ""state"": ""FINISHED"",
          ""startTime"": ""2022-01-01T00:00:00.100+00:00"",
          ""answerTime"": ""2022-01-01T00:00:02.100+00:00"",
          ""endTime"": ""2022-01-01T00:00:06.100+00:00"",
          ""machineDetection"": {{
            ""detectionResult"": ""MACHINE""
          }},
          ""ringDuration"": 2,
          ""platform"": {{
            ""applicationId"": ""61c060db2675060027d8c7a6""
          }},
          ""conferenceIds"": [
            ""034e622a-cc7e-456d-8a10-0ba43b11aa5e""
          ],
          ""duration"": 4,
          ""hasCameraVideo"": true,
          ""hasScreenshareVideo"": false,
          ""errorCode"": {{
            ""id"": 10000,
            ""name"": ""NORMAL_HANGUP"",
            ""description"": ""The call has ended with hangup initiated by caller, callee or API""
          }},
          ""customData"": {{
            ""key1"": ""value1"",
            ""key2"": ""value2""
          }},
          ""hangupSource"": ""ENDPOINT""
        }}";

        SetUpGetRequest(GET_CALL_HISTORY_ENDPOINT.Replace("{callId}", givenCallId), 200, givenResponse);

        var api = new CallsApi(configuration);

        var response = api.GetCallHistory(givenCallId);

        var expectedResponse = new CallLog(
            endpoint: new CallsPhoneEndpoint("44790123456"),
            callId: givenCallId,
            from: "44790123456",
            to: "44790123456",
            direction: CallDirection.Outbound,
            state: CallState.Finished,
            startTime: DateTime.Parse("2022-01-01T00:00:00.100+00:00"),
            answerTime: DateTime.Parse("2022-01-01T00:00:02.100+00:00"),
            endTime: DateTime.Parse("2022-01-01T00:00:06.100+00:00"),
            machineDetection: new CallsMachineDetectionProperties(CallsDetectionResult.Machine),
            ringDuration: 2,
            platform: new Platform(applicationId: "61c060db2675060027d8c7a6"),
            conferenceIds: new List<string> { "034e622a-cc7e-456d-8a10-0ba43b11aa5e" },
            duration: 4,
            hasCameraVideo: true,
            hasScreenshareVideo: false,
            errorCode: new CallsErrorCodeInfo(10000, "NORMAL_HANGUP",
                "The call has ended with hangup initiated by caller, callee or API"),
            customData: new Dictionary<string, string> { { "key1", "value1" }, { "key2", "value2" } },
            hangupSource: CallsHangupSource.Endpoint
        );

        Assert.AreEqual(expectedResponse, response);
    }


    [TestMethod]
    public void ShouldConnectCalls()
    {
        var givenRequest = @"
        {
          ""callIds"": [
            ""d6d6058c-5077-49f9-a030-2fc40e8ca195"",
            ""6539fcb4-4b2a-4ac9-a43a-d60807af29b0"",
            ""d8d84155-3831-43fb-91c9-bb897149a79d""
          ],
          ""conferenceRequest"": {
            ""name"": ""Example conference"",
            ""recording"": {
              ""recordingType"": ""AUDIO"",
              ""conferenceComposition"": {
                ""enabled"": true
              }
            },
            ""maxDuration"": 600
          }
        }";

        var givenResponse = @"
        {
          ""id"": ""034e622a-cc7e-456d-8a10-0ba43b11aa5e"",
          ""name"": ""Example conference"",
          ""participants"": [
            {
              ""callId"": ""d8d84155-3831-43fb-91c9-bb897149a79d"",
              ""endpoint"": {
                ""type"": ""PHONE"",
                ""phoneNumber"": ""44790123456""
              },
              ""state"": ""JOINED"",
              ""joinTime"": ""2021-12-31T23:59:55.100+00:00"",
              ""media"": {
                ""audio"": {
                  ""muted"": false,
                  ""deaf"": false
                },
                ""video"": {
                  ""camera"": false,
                  ""screenShare"": false
                }
              }
            },
            {
              ""callId"": ""d8d84155-3831-43fb-91c9-bb897149a79d"",
              ""endpoint"": {
                ""type"": ""PHONE"",
                ""phoneNumber"": ""44790123456""
              },
              ""state"": ""JOINING"",
              ""media"": {
                ""audio"": {
                  ""muted"": false,
                  ""deaf"": false
                },
                ""video"": {
                  ""camera"": false,
                  ""screenShare"": false
                }
              }
            }
          ],
          ""callsConfigurationId"": ""dc5942707c704551a00cd2ea"",
          ""platform"": {
            ""applicationId"": ""61c060db2675060027d8c7a6""
          }
        }";

        var api = new CallsApi(configuration);

        var request = new CallsConnectRequest(
            new List<string>
            {
                "d6d6058c-5077-49f9-a030-2fc40e8ca195",
                "6539fcb4-4b2a-4ac9-a43a-d60807af29b0",
                "d8d84155-3831-43fb-91c9-bb897149a79d"
            },
            new CallsActionConferenceRequest(
                "Example conference",
                new CallsConferenceRecordingRequest(
                    CallsRecordingType.Audio,
                    new CallsConferenceComposition(true)
                ),
                600
            )
        );

        SetUpPostRequest(CONNECT_CALLS_ENDPOINT, 200, givenRequest, givenResponse);

        var response = api.ConnectCalls(request);

        var expectedResponse = new CallsConference(
            "034e622a-cc7e-456d-8a10-0ba43b11aa5e",
            "Example conference",
            new List<CallsParticipant>
            {
                new(
                    endpoint: new CallsPhoneEndpoint("44790123456"),
                    callId: "d8d84155-3831-43fb-91c9-bb897149a79d",
                    state: CallsParticipantState.Joined,
                    joinTime: DateTime.Parse("2021-12-31T23:59:55.100+00:00"),
                    media: new CallsMediaProperties(
                        new CallsAudioMediaProperties(),
                        new CallsVideoMediaProperties()
                    )
                ),
                new(
                    endpoint: new CallsPhoneEndpoint("44790123456"),
                    callId: "d8d84155-3831-43fb-91c9-bb897149a79d",
                    state: CallsParticipantState.Joining,
                    media: new CallsMediaProperties(
                        new CallsAudioMediaProperties(),
                        new CallsVideoMediaProperties()
                    )
                )
            },
            "dc5942707c704551a00cd2ea",
            new Platform(applicationId: "61c060db2675060027d8c7a6")
        );

        Assert.AreEqual(expectedResponse, response);
    }

    [TestMethod]
    public void ShouldConnectWithNewCall()
    {
        var givenCallId = "d8d84155-3831-43fb-91c9-bb897149a79d";

        var givenRequest = @"
        {
          ""callRequest"": {
            ""endpoint"": {
              ""type"": ""PHONE"",
              ""phoneNumber"": ""41792036727""
            },
            ""from"": ""41793026834"",
            ""maxDuration"": 300
          },
          ""connectOnEarlyMedia"": false,
          ""conferenceRequest"": {
            ""name"": ""Example conference"",
            ""recording"": {
              ""recordingType"": ""AUDIO"",
              ""conferenceComposition"": {
                ""enabled"": true
              }
            },
            ""maxDuration"": 600
          }
        }";

        var givenResponse = @"
        {
          ""conference"": {
            ""id"": ""034e622a-cc7e-456d-8a10-0ba43b11aa5e"",
            ""name"": ""Example conference"",
            ""participants"": [
              {
                ""callId"": ""d8d84155-3831-43fb-91c9-bb897149a79d"",
                ""endpoint"": {
                  ""type"": ""PHONE"",
                  ""phoneNumber"": ""44790123456""
                },
                ""state"": ""JOINED"",
                ""joinTime"": ""2021-12-31T23:59:55.100+00:00"",
                ""media"": {
                  ""audio"": {
                    ""muted"": false,
                    ""deaf"": false
                  },
                  ""video"": {
                    ""camera"": false,
                    ""screenShare"": false
                  }
                }
              },
              {
                ""callId"": ""d8d84155-3831-43fb-91c9-bb897149a79d"",
                ""endpoint"": {
                  ""type"": ""PHONE"",
                  ""phoneNumber"": ""44790123456""
                },
                ""state"": ""JOINING"",
                ""media"": {
                  ""audio"": {
                    ""muted"": false,
                    ""deaf"": false
                  },
                  ""video"": {
                    ""camera"": false,
                    ""screenShare"": false
                  }
                }
              }
            ],
            ""callsConfigurationId"": ""dc5942707c704551a00cd2ea"",
            ""platform"": {
              ""applicationId"": ""61c060db2675060027d8c7a6""
            }
          },
          ""call"": {
            ""id"": ""d8d84155-3831-43fb-91c9-bb897149a79d"",
            ""endpoint"": {
              ""type"": ""PHONE"",
              ""phoneNumber"": ""44790123456""
            },
            ""from"": ""44790123456"",
            ""to"": ""44790123456"",
            ""direction"": ""OUTBOUND"",
            ""state"": ""CALLING"",
            ""media"": {
              ""audio"": {
                ""muted"": false,
                ""deaf"": false
              },
              ""video"": {
                ""camera"": false,
                ""screenShare"": false
              }
            },
            ""startTime"": ""2022-01-01T00:00:00.100+00:00"",
            ""answerTime"": ""2022-01-01T00:00:02.100+00:00"",
            ""ringDuration"": 2,
            ""callsConfigurationId"": ""dc5942707c704551a00cd2ea"",
            ""platform"": {
              ""applicationId"": ""61c060db2675060027d8c7a6""
            },
            ""conferenceId"": ""034e622a-cc7e-456d-8a10-0ba43b11aa5e"",
            ""customData"": {
              ""key1"": ""value1"",
              ""key2"": ""value2""
            }
          }
        }";

        SetUpPostRequest(CONNECT_WITH_NEW_CALL_ENDPOINT.Replace("{callId}", givenCallId), 200, givenRequest,
            givenResponse);

        var api = new CallsApi(configuration);

        var request = new CallsConnectWithNewCallRequest(
            new CallsActionCallRequest(
                new CallsPhoneEndpoint(
                    "41792036727"
                ),
                "41793026834",
                maxDuration: 300
            ),
            conferenceRequest: new CallsActionConferenceRequest(
                "Example conference",
                new CallsConferenceRecordingRequest(
                    CallsRecordingType.Audio,
                    new CallsConferenceComposition(
                        true
                    )
                ),
                600
            )
        );

        var response = api.ConnectWithNewCall(givenCallId, request);

        var expectedResponse = new CallsConferenceAndCall(
            new CallsConference(
                "034e622a-cc7e-456d-8a10-0ba43b11aa5e",
                "Example conference",
                new List<CallsParticipant>
                {
                    new(
                        endpoint: new CallsPhoneEndpoint(
                            "44790123456"
                        ),
                        callId: "d8d84155-3831-43fb-91c9-bb897149a79d",
                        state: CallsParticipantState.Joined,
                        joinTime: DateTime.Parse("2021-12-31T23:59:55.100+00:00"),
                        media: new CallsMediaProperties(
                            new CallsAudioMediaProperties(),
                            new CallsVideoMediaProperties()
                        )
                    ),
                    new(
                        endpoint: new CallsPhoneEndpoint(
                            "44790123456"
                        ),
                        callId: "d8d84155-3831-43fb-91c9-bb897149a79d",
                        state: CallsParticipantState.Joining,
                        media: new CallsMediaProperties(
                            new CallsAudioMediaProperties(),
                            new CallsVideoMediaProperties()
                        )
                    )
                },
                "dc5942707c704551a00cd2ea",
                new Platform(
                    applicationId: "61c060db2675060027d8c7a6"
                )
            ),
            new Call(
                endpoint: new CallsPhoneEndpoint(
                    "44790123456"
                ),
                id: "d8d84155-3831-43fb-91c9-bb897149a79d",
                from: "44790123456",
                to: "44790123456",
                direction: CallDirection.Outbound,
                state: CallState.Calling,
                media: new CallsMediaProperties(
                    new CallsAudioMediaProperties(),
                    new CallsVideoMediaProperties()
                ),
                startTime: DateTime.Parse("2022-01-01T00:00:00.100+00:00"),
                answerTime: DateTime.Parse("2022-01-01T00:00:02.100+00:00"),
                ringDuration: 2,
                callsConfigurationId: "dc5942707c704551a00cd2ea",
                platform: new Platform(
                    applicationId: "61c060db2675060027d8c7a6"
                ),
                conferenceId: "034e622a-cc7e-456d-8a10-0ba43b11aa5e",
                customData: new Dictionary<string, string>
                {
                    { "key1", "value1" },
                    { "key2", "value2" }
                }
            )
        );

        Assert.AreEqual(expectedResponse, response);
    }

    [TestMethod]
    public void ShouldCallsSendRinging()
    {
        var givenCallId = "d8d84155-3831-43fb-91c9-bb897149a79d";

        var givenResponse = @"
        {
          ""status"": ""PENDING""
        }";

        SetUpPostRequest(SEND_RINGING_ENDPOINT.Replace("{callId}", givenCallId), 200, null, givenResponse);

        var api = new CallsApi(configuration);

        var response = api.SendRinging(givenCallId);

        var expectedResponse = new CallsActionResponse(CallsActionStatus.Pending);

        Assert.AreEqual(expectedResponse, response);
    }

    [TestMethod]
    public void ShouldCallsPreAnswerCall()
    {
        var givenCallId = "d8d84155-3831-43fb-91c9-bb897149a79d";

        var givenRequest = @"
        {
          ""ringing"": false,
          ""customData"": {
            ""property1"": ""string"",
            ""property2"": ""string""
          }
        }";

        var givenResponse = @"
        {
          ""status"": ""PENDING""
        }";

        SetUpPostRequest(PRE_ANSWER_CALL_ENDPOINT.Replace("{callId}", givenCallId), 200, givenRequest, givenResponse);

        var api = new CallsApi(configuration);

        var request = new CallsPreAnswerRequest(
            false,
            new Dictionary<string, string>
            {
                { "property1", "string" },
                { "property2", "string" }
            }
        );

        var response = api.PreAnswerCall(givenCallId, request);

        var expectedResponse = new CallsActionResponse(
            CallsActionStatus.Pending
        );

        Assert.AreEqual(expectedResponse, response);
    }

    [TestMethod]
    public void ShouldCallsAnswerCall()
    {
        var givenCallId = "d8d84155-3831-43fb-91c9-bb897149a79d";

        var givenRequest = @"
        {
          ""customData"": {
            ""property1"": ""string"",
            ""property2"": ""string""
          },
          ""recording"": {
            ""recordingType"": ""AUDIO"",
            ""customData"": {
              ""property1"": ""string"",
              ""property2"": ""string""
            },
            ""filePrefix"": ""string""
          }
        }";

        var givenResponse = @"
        {
          ""status"": ""PENDING""
        }";

        SetUpPostRequest(ANSWER_CALL_ENDPOINT.Replace("{callId}", givenCallId), 200, givenRequest, givenResponse);

        var api = new CallsApi(configuration);

        var request = new CallsAnswerRequest(
            new Dictionary<string, string>
            {
                { "property1", "string" },
                { "property2", "string" }
            },
            new CallRecordingRequest(
                CallsRecordingType.Audio,
                new Dictionary<string, string>
                {
                    { "property1", "string" },
                    { "property2", "string" }
                },
                "string"
            )
        );

        var response = api.AnswerCall(givenCallId, request);

        var expectedResponse = new CallsActionResponse(
            CallsActionStatus.Pending
        );

        Assert.AreEqual(expectedResponse, response);
    }

    [TestMethod]
    public void ShouldCallsHangupCall()
    {
        var givenCallId = "d8d84155-3831-43fb-91c9-bb897149a79d";

        var givenRequest = @"
        {
          ""errorCode"": ""NORMAL_HANGUP""
        }";

        var givenResponse = $@"
        {{
          ""id"": ""{givenCallId}"",
          ""endpoint"": {{
            ""type"": ""PHONE"",
            ""phoneNumber"": ""44790123456""
          }},
          ""from"": ""44790123456"",
          ""to"": ""44790123456"",
          ""direction"": ""OUTBOUND"",
          ""state"": ""CALLING"",
          ""media"": {{
            ""audio"": {{
              ""muted"": false,
              ""deaf"": false
            }},
            ""video"": {{
              ""camera"": false,
              ""screenShare"": false
            }}
          }},
          ""startTime"": ""2022-01-01T00:00:00.100+00:00"",
          ""answerTime"": ""2022-01-01T00:00:02.100+00:00"",
          ""ringDuration"": 2,
          ""callsConfigurationId"": ""dc5942707c704551a00cd2ea"",
          ""platform"": {{
            ""applicationId"": ""61c060db2675060027d8c7a6""
          }},
          ""conferenceId"": ""034e622a-cc7e-456d-8a10-0ba43b11aa5e"",
          ""customData"": {{
            ""key1"": ""value1"",
            ""key2"": ""value2""
          }}
        }}";

        SetUpPostRequest(HANGUP_CALL_ENDPOINT.Replace("{callId}", givenCallId), 200, givenRequest, givenResponse);

        var api = new CallsApi(configuration);

        var request = new CallsHangupRequest
        {
            ErrorCode = CallsErrorCode.NormalHangup
        };

        var response = api.HangupCall(givenCallId, request);

        var expectedResponse = new Call
        (
            endpoint: new CallsPhoneEndpoint
            (
                "44790123456"
            ),
            id: givenCallId,
            from: "44790123456",
            to: "44790123456",
            direction: CallDirection.Outbound,
            state: CallState.Calling,
            media: new CallsMediaProperties
            (
                new CallsAudioMediaProperties
                    (),
                new CallsVideoMediaProperties
                    ()
            ),
            startTime: DateTime.Parse("2022-01-01T00:00:00.100+00:00"),
            answerTime: DateTime.Parse("2022-01-01T00:00:02.100+00:00"),
            ringDuration: 2,
            callsConfigurationId: "dc5942707c704551a00cd2ea",
            platform: new Platform
            (
                applicationId: "61c060db2675060027d8c7a6"
            ),
            conferenceId: "034e622a-cc7e-456d-8a10-0ba43b11aa5e",
            customData: new Dictionary<string, string>
            {
                { "key1", "value1" },
                { "key2", "value2" }
            }
        );

        Assert.AreEqual(expectedResponse, response);
    }

    [TestMethod]
    public void ShouldCallsPlayFile()
    {
        var givenCallId = "d8d84155-3831-43fb-91c9-bb897149a79d";

        var givenRequest = @"
        {
          ""timeout"": 30000,
          ""offset"": 5000,
          ""content"": {
            ""fileId"": ""218eceba-c044-430d-9f26-8f1a7f0g2d03"",
            ""type"": ""FILE""
          }
        }";

        var givenResponse = @"
        {
          ""status"": ""PENDING""
        }";

        SetUpPostRequest(CALL_PLAY_FILE_ENDPOINT.Replace("{callId}", givenCallId), 200, givenRequest, givenResponse);

        var api = new CallsApi(configuration);

        var request = new CallsPlayRequest(
            content: new CallsFilePlayContent(
                "218eceba-c044-430d-9f26-8f1a7f0g2d03"
            ),
            timeout: 30000,
            offset: 5000
        );

        var response = api.CallPlayFile(givenCallId, request);

        var expectedResponse = new CallsActionResponse(
            CallsActionStatus.Pending
        );

        Assert.AreEqual(expectedResponse, response);
    }

    [TestMethod]
    public void ShouldCallsPlayFileProvidedByUrl()
    {
        var givenCallId = "d8d84155-3831-43fb-91c9-bb897149a79d";

        var givenRequest = @"
        {
          ""timeout"": 30000,
          ""offset"": 5000,
          ""content"": {
            ""fileUrl"": ""https://example.com/file.mp3"",
            ""type"": ""URL"",
            ""cacheDuration"": 1000
          }
        }";

        var givenResponse = @"
        {
          ""status"": ""PENDING""
        }";

        SetUpPostRequest(CALL_PLAY_FILE_ENDPOINT.Replace("{callId}", givenCallId), 200, givenRequest, givenResponse);

        var api = new CallsApi(configuration);

        var request = new CallsPlayRequest(
            content: new CallsUrlPlayContent(
                "https://example.com/file.mp3",
                1000
            ),
            timeout: 30000,
            offset: 5000
        );

        var response = api.CallPlayFile(givenCallId, request);

        var expectedResponse = new CallsActionResponse(
            CallsActionStatus.Pending
        );

        Assert.AreEqual(expectedResponse, response);
    }

    [TestMethod]
    public void ShouldCallsStopPlayingFile()
    {
        var givenCallId = "d8d84155-3831-43fb-91c9-bb897149a79d";

        var givenRequest = @"
        {
          ""customData"": {
            ""property1"": ""string"",
            ""property2"": ""string""
          }
        }";

        var givenResponse = @"
        {
          ""status"": ""PENDING""
        }";

        SetUpPostRequest(CALL_STOP_PLAYING_FILE_ENDPOINT.Replace("{callId}", givenCallId), 200, givenRequest,
            givenResponse);

        var api = new CallsApi(configuration);

        var request = new CallsStopPlayRequest(
            new Dictionary<string, string>
            {
                { "property1", "string" },
                { "property2", "string" }
            }
        );

        var response = api.CallStopPlayingFile(givenCallId, request);

        var expectedResponse = new CallsActionResponse(CallsActionStatus.Pending);

        Assert.AreEqual(expectedResponse, response);
    }

    [TestMethod]
    public void ShouldCallsSayText()
    {
        var givenCallId = "d8d84155-3831-43fb-91c9-bb897149a79d";

        var givenRequest = @"
        {
          ""text"": ""This is an advanced example of text to speech"",
          ""language"": ""en"",
          ""speechRate"": 1.5,
          ""loopCount"": 2,
          ""preferences"": {
            ""voiceGender"": ""MALE""
          },
          ""stopOn"": {
            ""terminator"": ""#"",
            ""type"": ""DTMF""
          }
        }";

        var givenResponse = @"
        {
          ""status"": ""PENDING""
        }";

        SetUpPostRequest(CALL_SAY_TEXT_ENDPOINT.Replace("{callId}", givenCallId), 200, givenRequest, givenResponse);

        var api = new CallsApi(configuration);

        var request = new CallsSayRequest(
            "This is an advanced example of text to speech",
            CallsLanguage.En,
            1.5,
            2,
            new CallsVoicePreferences(
                CallsGender.Male
            ),
            new CallsDtmfTermination(
                "#"
            )
        );

        var response = api.CallSayText(givenCallId, request);

        var expectedResponse = new CallsActionResponse(
            CallsActionStatus.Pending
        );

        Assert.AreEqual(expectedResponse, response);
    }

    [TestMethod]
    public void ShouldCallsSendDtmf()
    {
        var givenCallId = "d8d84155-3831-43fb-91c9-bb897149a79d";

        var givenRequest = @"
        {
          ""dtmf"": ""341#""
        }";

        var givenResponse = @"
        {
          ""status"": ""PENDING""
        }";

        SetUpPostRequest(CALL_SEND_DTMF_ENDPOINT.Replace("{callId}", givenCallId), 200, givenRequest, givenResponse);

        var api = new CallsApi(configuration);

        var request = new CallsDtmfSendRequest(dtmf: "341#");

        var response = api.CallSendDtmf(givenCallId, request);

        var expectedResponse = new CallsActionResponse(CallsActionStatus.Pending);

        Assert.AreEqual(expectedResponse, response);
    }

    [TestMethod]
    public void ShouldCallsCaptureDtmf()
    {
        var givenCallId = "d8d84155-3831-43fb-91c9-bb897149a79d";

        var givenRequest = @"
        {
          ""maxLength"": 4,
          ""timeout"": 5000,
          ""terminator"": ""#"",
          ""digitTimeout"": 3000
        }";

        var givenResponse = @"
        {
          ""status"": ""PENDING""
        }";

        SetUpPostRequest(CALL_CAPTURE_DTMF_ENDPOINT.Replace("{callId}", givenCallId), 200, givenRequest, givenResponse);

        var api = new CallsApi(configuration);

        var request = new CallsDtmfCaptureRequest(
            4,
            5000,
            "#",
            3000
        );

        var response = api.CallCaptureDtmf(givenCallId, request);

        var expectedResponse = new CallsActionResponse(
            CallsActionStatus.Pending
        );

        Assert.AreEqual(expectedResponse, response);
    }

    [TestMethod]
    public void ShouldCallsCaptureSpeech()
    {
        var givenCallId = "d8d84155-3831-43fb-91c9-bb897149a79d";

        var givenRequest = @"
        {
          ""language"": ""en-GB"",
          ""timeout"": 30,
          ""maxSilence"": 3,
          ""keyPhrases"": [
            ""phrase"",
            ""word""
          ]
        }";

        var givenResponse = @"
        {
          ""status"": ""PENDING""
        }";

        SetUpPostRequest(CALL_CAPTURE_SPEECH_ENDPOINT.Replace("{callId}", givenCallId), 200, givenRequest,
            givenResponse);

        var api = new CallsApi(configuration);

        var request = new CallsSpeechCaptureRequest(
            CallsLanguage.EnGb,
            30,
            3,
            new List<string> { "phrase", "word" }
        );

        var response = api.CallCaptureSpeech(givenCallId, request);

        var expectedResponse = new CallsActionResponse(
            CallsActionStatus.Pending
        );

        Assert.AreEqual(expectedResponse, response);
    }

    [TestMethod]
    public void ShouldCallsStartTranscription()
    {
        var givenCallId = "d8d84155-3831-43fb-91c9-bb897149a79d";

        var givenRequest = @"
        {
          ""transcription"": {
            ""language"": ""en-GB"",
            ""sendInterimResults"": false
          }
        }";

        var givenResponse = @"
        {
          ""status"": ""PENDING""
        }";

        SetUpPostRequest(CALL_START_TRANSCRIPTION_ENDPOINT.Replace("{callId}", givenCallId), 200, givenRequest,
            givenResponse);

        var api = new CallsApi(configuration);

        var request = new CallsStartTranscriptionRequest(
            new CallsTranscription(
                CallsLanguage.EnGb
            )
        );

        var response = api.CallStartTranscription(givenCallId, request);

        var expectedResponse = new CallsActionResponse(
            CallsActionStatus.Pending
        );

        Assert.AreEqual(expectedResponse, response);
    }

    [TestMethod]
    public void ShouldCallsStopTranscription()
    {
        var givenCallId = "d8d84155-3831-43fb-91c9-bb897149a79d";

        var givenResponse = @"
        {
          ""status"": ""PENDING""
        }";

        SetUpPostRequest(CALL_STOP_TRANSCRIPTION_ENDPOINT.Replace("{callId}", givenCallId), 200, null, givenResponse);

        var api = new CallsApi(configuration);

        var response = api.CallStopTranscription(givenCallId);

        var expectedResponse = new CallsActionResponse(CallsActionStatus.Pending);

        Assert.AreEqual(expectedResponse, response);
    }

    [TestMethod]
    public void ShouldCallsStartRecording()
    {
        var givenCallId = "d8d84155-3831-43fb-91c9-bb897149a79d";

        var givenRequest = @"
        {
          ""recording"": {
            ""recordingType"": ""AUDIO"",
            ""maxSilence"": 5,
            ""beep"": true,
            ""maxDuration"": 20,
            ""customData"": {
              ""key1"": ""value1"",
              ""key2"": ""value2""
            },
            ""filePrefix"": ""customFilename""
          }
        }";

        var givenResponse = @"
        {
          ""status"": ""PENDING""
        }";

        SetUpPostRequest(CALL_START_RECORDING_ENDPOINT.Replace("{callId}", givenCallId), 200, givenRequest,
            givenResponse);

        var api = new CallsApi(configuration);

        var request = new CallsRecordingStartRequest(
            new CallsRecordingRequest(
                CallsRecordingType.Audio,
                5,
                true,
                20,
                new Dictionary<string, string>
                {
                    { "key1", "value1" },
                    { "key2", "value2" }
                },
                "customFilename"
            )
        );

        var response = api.CallStartRecording(givenCallId, request);

        var expectedResponse = new CallsActionResponse(
            CallsActionStatus.Pending
        );

        Assert.AreEqual(expectedResponse, response);
    }

    [TestMethod]
    public void ShouldCallsStopRecording()
    {
        var givenCallId = "d8d84155-3831-43fb-91c9-bb897149a79d";

        var givenResponse = @"
        {
          ""status"": ""PENDING""
        }";

        SetUpPostRequest(CALL_STOP_RECORDING_ENDPOINT.Replace("{callId}", givenCallId), 200, null, givenResponse);

        var api = new CallsApi(configuration);

        var response = api.CallStopRecording(givenCallId);

        var expectedResponse = new CallsActionResponse(CallsActionStatus.Pending);

        Assert.AreEqual(expectedResponse, response);
    }

    [TestMethod]
    public void ShouldCallsStartStreamingMedia()
    {
        var givenCallId = "d8d84155-3831-43fb-91c9-bb897149a79d";

        var givenRequest = @"
        {
          ""mediaStream"": {
            ""audioProperties"": {
              ""mediaStreamConfigId"": ""63467c6e2885a5389ba11d80"",
              ""replaceMedia"": false
            }
          }
        }";

        var givenResponse = @"
        {
          ""status"": ""PENDING""
        }";

        SetUpPostRequest(START_MEDIA_STREAM_ENDPOINT.Replace("{callId}", givenCallId), 200, givenRequest,
            givenResponse);

        var api = new CallsApi(configuration);

        var request = new CallsStartMediaStreamRequest(
            new CallsMediaStream(
                new CallsMediaStreamAudioProperties(
                    "63467c6e2885a5389ba11d80"
                )
            )
        );

        var response = api.StartMediaStream(givenCallId, request);

        var expectedResponse = new CallsActionResponse(
            CallsActionStatus.Pending
        );

        Assert.AreEqual(expectedResponse, response);
    }

    [TestMethod]
    public void ShouldCallsStopStreamingMedia()
    {
        var givenCallId = "d8d84155-3831-43fb-91c9-bb897149a79d";

        var givenResponse = @"
        {
          ""status"": ""PENDING""
        }";

        SetUpPostRequest(STOP_MEDIA_STREAM_ENDPOINT.Replace("{callId}", givenCallId), 200, null, givenResponse);

        var api = new CallsApi(configuration);

        var response = api.StopMediaStream(givenCallId);

        var expectedResponse = new CallsActionResponse(
            CallsActionStatus.Pending
        );

        Assert.AreEqual(expectedResponse, response);
    }

    [TestMethod]
    public void ShouldCallsRequestApplicationTransfer()
    {
        var givenCallId = "d8d84155-3831-43fb-91c9-bb897149a79d";

        var givenRequest = @"
        {
          ""destinationCallsConfigurationId"": ""dc5942707c704551a00cd2ea"",
          ""timeout"": 20
        }";

        var givenResponse = @"
        {
          ""status"": ""PENDING""
        }";

        SetUpPostRequest(APPLICATION_TRANSFER.Replace("{callId}", givenCallId), 200, givenRequest, givenResponse);

        var api = new CallsApi(configuration);

        var request = new CallsApplicationTransferRequest(
            "dc5942707c704551a00cd2ea",
            timeout: 20
        );

        var response = api.ApplicationTransfer(givenCallId, request);

        var expectedResponse = new CallsActionResponse(
            CallsActionStatus.Pending
        );

        Assert.AreEqual(expectedResponse, response);
    }

    [TestMethod]
    public void ShouldCallsAcceptApplicationTransfer()
    {
        var givenCallId = "d8d84155-3831-43fb-91c9-bb897149a79d";
        var givenTransferId = "d8d84155-3831-43fb-91c9-bb897149a79d";

        var givenResponse = @"
        {
          ""status"": ""PENDING""
        }";

        SetUpPostRequest(
            APPLICATION_TRANSFER_ACCEPT.Replace("{callId}", givenCallId).Replace("{transferId}", givenTransferId), 200,
            null, givenResponse);

        var api = new CallsApi(configuration);

        var response = api.ApplicationTransferAccept(givenCallId, givenTransferId);

        Assert.AreEqual(new CallsActionResponse(CallsActionStatus.Pending), response);
    }

    [TestMethod]
    public void ShouldCallsRejectApplicationTransfer()
    {
        var givenCallId = "d8d84155-3831-43fb-91c9-bb897149a79d";
        var givenTransferId = "d8d84155-3831-43fb-91c9-bb897149a79d";

        var givenResponse = @"
        {
          ""status"": ""PENDING""
        }";

        SetUpPostRequest(
            APPLICATION_TRANSFER_REJECT.Replace("{callId}", givenCallId).Replace("{transferId}", givenTransferId), 200,
            null, givenResponse);

        var api = new CallsApi(configuration);

        var response = api.ApplicationTransferReject(givenCallId, givenTransferId);

        var expectedResponse = new CallsActionResponse(CallsActionStatus.Pending);

        Assert.AreEqual(expectedResponse, response);
    }

    [TestMethod]
    public void ShouldGetConferences()
    {
        var givenName = "Conference";
        var givenCallId = "066675c6-0db6-0db9-b032-031964d09af4";
        var givenCallsConfigurationId = "dc5942707c704551a00cd2ea";
        var givenApplicationId = "61c060db2675060027d8c7a6";
        var givenStartTimeAfter = DateTime.Parse("2022-05-01T14:25:45.125+00:00");
        var givenPage = 0;
        var givenSize = 10;

        var givenResponse = @"
        {
          ""results"": [
            {
              ""id"": ""034e622a-cc7e-456d-8a10-0ba43b11aa5e"",
              ""name"": ""Example conference"",
              ""participants"": [
                {
                  ""callId"": ""d8d84155-3831-43fb-91c9-bb897149a79d"",
                  ""endpoint"": {
                    ""type"": ""PHONE"",
                    ""phoneNumber"": ""44790123456""
                  },
                  ""state"": ""JOINED"",
                  ""joinTime"": ""2021-12-31T23:59:55.100+00:00"",
                  ""media"": {
                    ""audio"": {
                      ""muted"": false,
                      ""deaf"": false
                    },
                    ""video"": {
                      ""camera"": false,
                      ""screenShare"": false
                    }
                  }
                },
                {
                  ""callId"": ""d8d84155-3831-43fb-91c9-bb897149a79d"",
                  ""endpoint"": {
                    ""type"": ""PHONE"",
                    ""phoneNumber"": ""44790123456""
                  },
                  ""state"": ""JOINING"",
                  ""media"": {
                    ""audio"": {
                      ""muted"": false,
                      ""deaf"": false
                    },
                    ""video"": {
                      ""camera"": false,
                      ""screenShare"": false
                    }
                  }
                }
              ],
              ""callsConfigurationId"": ""dc5942707c704551a00cd2ea"",
              ""platform"": {
                ""applicationId"": ""61c060db2675060027d8c7a6""
              }
            }
          ],
          ""paging"": {
            ""page"": 0,
            ""size"": 1,
            ""totalPages"": 1,
            ""totalResults"": 1
          }
        }";

        SetUpGetRequest(GET_CONFERENCES, 200, givenResponse);

        var api = new CallsApi(configuration);

        var response = api.GetConferences(
            givenName,
            givenCallId,
            givenCallsConfigurationId,
            givenApplicationId,
            givenStartTimeAfter,
            givenPage,
            givenSize
        );

        var expectedResponse = new CallsConferencePage(
            new List<CallsConference>
            {
                new(
                    "034e622a-cc7e-456d-8a10-0ba43b11aa5e",
                    "Example conference",
                    new List<CallsParticipant>
                    {
                        new(
                            "d8d84155-3831-43fb-91c9-bb897149a79d",
                            new CallsPhoneEndpoint("44790123456"),
                            CallsParticipantState.Joined,
                            DateTime.Parse("2021-12-31T23:59:55.100+00:00"),
                            media: new CallsMediaProperties(
                                new CallsAudioMediaProperties(),
                                new CallsVideoMediaProperties()
                            )
                        ),
                        new(
                            "d8d84155-3831-43fb-91c9-bb897149a79d",
                            new CallsPhoneEndpoint("44790123456"),
                            CallsParticipantState.Joining,
                            media: new CallsMediaProperties(
                                new CallsAudioMediaProperties(),
                                new CallsVideoMediaProperties()
                            )
                        )
                    },
                    "dc5942707c704551a00cd2ea",
                    new Platform(applicationId: "61c060db2675060027d8c7a6")
                )
            },
            new PageInfo(0, 1, 1, 1)
        );

        Assert.AreEqual(expectedResponse, response);
    }

    [TestMethod]
    public void ShouldCreateConference()
    {
        var givenRequest = @"
        {
          ""name"": ""Example conference"",
          ""recording"": {
            ""recordingType"": ""AUDIO"",
            ""conferenceComposition"": {
              ""enabled"": true
            }
          },
          ""maxDuration"": 28800,
          ""callsConfigurationId"": ""dc5942707c704551a00cd2ea"",
          ""platform"": {
            ""applicationId"": ""61c060db2675060027d8c7a6""
          }
        }";

        var givenResponse = @"
        {
          ""id"": ""034e622a-cc7e-456d-8a10-0ba43b11aa5e"",
          ""name"": ""Example conference"",
          ""participants"": [
            {
              ""callId"": ""d8d84155-3831-43fb-91c9-bb897149a79d"",
              ""endpoint"": {
                ""type"": ""PHONE"",
                ""phoneNumber"": ""44790123456""
              },
              ""state"": ""JOINED"",
              ""joinTime"": ""2021-12-31T23:59:55.100+00:00"",
              ""media"": {
                ""audio"": {
                  ""muted"": false,
                  ""deaf"": false
                },
                ""video"": {
                  ""camera"": false,
                  ""screenShare"": false
                }
              }
            },
            {
              ""callId"": ""d8d84155-3831-43fb-91c9-bb897149a79d"",
              ""endpoint"": {
                ""type"": ""PHONE"",
                ""phoneNumber"": ""44790123456""
              },
              ""state"": ""JOINING"",
              ""media"": {
                ""audio"": {
                  ""muted"": false,
                  ""deaf"": false
                },
                ""video"": {
                  ""camera"": false,
                  ""screenShare"": false
                }
              }
            }
          ],
          ""callsConfigurationId"": ""dc5942707c704551a00cd2ea"",
          ""platform"": {
            ""applicationId"": ""61c060db2675060027d8c7a6""
          }
        }";

        SetUpPostRequest(CREATE_CONFERENCE, 200, givenRequest, givenResponse);

        var api = new CallsApi(configuration);

        var request = new CallsConferenceRequest(
            callsConfigurationId: "dc5942707c704551a00cd2ea",
            name: "Example conference",
            recording: new CallsConferenceRecordingRequest(
                CallsRecordingType.Audio,
                new CallsConferenceComposition(
                    true
                )
            ),
            platform: new Platform(
                applicationId: "61c060db2675060027d8c7a6"
            )
        );

        var expectedResponse = new CallsConference(
            "034e622a-cc7e-456d-8a10-0ba43b11aa5e",
            "Example conference",
            new List<CallsParticipant>
            {
                new(
                    "d8d84155-3831-43fb-91c9-bb897149a79d",
                    new CallsPhoneEndpoint("44790123456"),
                    CallsParticipantState.Joined,
                    DateTime.Parse("2021-12-31T23:59:55.100+00:00"),
                    media: new CallsMediaProperties(
                        new CallsAudioMediaProperties(),
                        new CallsVideoMediaProperties()
                    )
                ),
                new(
                    "d8d84155-3831-43fb-91c9-bb897149a79d",
                    new CallsPhoneEndpoint("44790123456"),
                    CallsParticipantState.Joining,
                    media: new CallsMediaProperties(
                        new CallsAudioMediaProperties(),
                        new CallsVideoMediaProperties()
                    )
                )
            },
            "dc5942707c704551a00cd2ea",
            new Platform(applicationId: "61c060db2675060027d8c7a6")
        );

        var response = api.CreateConference(request);

        Assert.AreEqual(expectedResponse, response);
    }

    [TestMethod]
    public void ShouldGetConference()
    {
        var givenConferenceId = "034e622a-cc7e-456d-8a10-0ba43b11aa5e";

        var givenResponse = @"
        {
          ""id"": ""034e622a-cc7e-456d-8a10-0ba43b11aa5e"",
          ""name"": ""Example conference"",
          ""participants"": [
            {
              ""callId"": ""d8d84155-3831-43fb-91c9-bb897149a79d"",
              ""endpoint"": {
                ""type"": ""PHONE"",
                ""phoneNumber"": ""44790123456""
              },
              ""state"": ""JOINED"",
              ""joinTime"": ""2021-12-31T23:59:55.100+00:00"",
              ""media"": {
                ""audio"": {
                  ""muted"": false,
                  ""deaf"": false
                },
                ""video"": {
                  ""camera"": false,
                  ""screenShare"": false
                }
              }
            },
            {
              ""callId"": ""d8d84155-3831-43fb-91c9-bb897149a79d"",
              ""endpoint"": {
                ""type"": ""PHONE"",
                ""phoneNumber"": ""44790123456""
              },
              ""state"": ""JOINING"",
              ""media"": {
                ""audio"": {
                  ""muted"": false,
                  ""deaf"": false
                },
                ""video"": {
                  ""camera"": false,
                  ""screenShare"": false
                }
              }
            }
          ],
          ""callsConfigurationId"": ""dc5942707c704551a00cd2ea"",
          ""platform"": {
            ""applicationId"": ""61c060db2675060027d8c7a6""
          }
        }";

        SetUpGetRequest(GET_CONFERENCE.Replace("{conferenceId}", givenConferenceId), 200, givenResponse);

        var api = new CallsApi(configuration);

        var response = api.GetConference(givenConferenceId);

        var expectedResponse = new CallsConference(
            "034e622a-cc7e-456d-8a10-0ba43b11aa5e",
            "Example conference",
            new List<CallsParticipant>
            {
                new(
                    endpoint: new CallsPhoneEndpoint(
                        "44790123456"
                    ),
                    callId: "d8d84155-3831-43fb-91c9-bb897149a79d",
                    state: CallsParticipantState.Joined,
                    joinTime: DateTime.Parse("2021-12-31T23:59:55.100+00:00"),
                    media: new CallsMediaProperties(
                        new CallsAudioMediaProperties(),
                        new CallsVideoMediaProperties()
                    )
                ),
                new(
                    endpoint: new CallsPhoneEndpoint(
                        "44790123456"
                    ),
                    callId: "d8d84155-3831-43fb-91c9-bb897149a79d",
                    state: CallsParticipantState.Joining,
                    media: new CallsMediaProperties(
                        new CallsAudioMediaProperties(),
                        new CallsVideoMediaProperties()
                    )
                )
            },
            "dc5942707c704551a00cd2ea",
            new Platform(
                applicationId: "61c060db2675060027d8c7a6"
            )
        );

        Assert.AreEqual(expectedResponse, response);
    }

    [TestMethod]
    public void ShouldUpdateAllCalls()
    {
        var givenConferenceId = "034e622a-cc7e-456d-8a10-0ba43b11aa5e";

        var givenRequest = @"
        {
          ""muted"": false,
          ""deaf"": true
        }";

        var givenResponse = @"
        {
          ""status"": ""PENDING""
        }";

        SetUpPatchRequest(UPDATE_CONFERENCE.Replace("{conferenceId}", givenConferenceId), 200, givenRequest,
            givenResponse);

        var api = new CallsApi(configuration);

        var request = new CallsUpdateRequest(
            false,
            true
        );

        var response = api.UpdateConference(givenConferenceId, request);

        var expectedResponse = new CallsActionResponse(
            CallsActionStatus.Pending
        );

        Assert.AreEqual(expectedResponse, response);
    }

    [TestMethod]
    public void ShouldGetConferencesHistory()
    {
        var givenName = "Conference";
        var givenCallId = "066675c6-0db6-0db9-b032-031964d09af4";
        var givenCallsConfigurationId = "dc5942707c704551a00cd2ea";
        var givenApplicationId = "61c060db2675060027d8c7a6";
        var givenStartTimeAfter = DateTimeOffset.Parse("2022-05-01T14:25:45.125+0000");
        var givenEndTimeBefore = DateTimeOffset.Parse("2022-05-01T14:26:45.125+0000");
        var givenPage = 0;
        var givenSize = 20;
        var givenQueryParameters = new Dictionary<string, string>
        {
            { "name", givenName },
            { "callId", givenCallId },
            { "callsConfigurationId", givenCallsConfigurationId },
            { "applicationId", givenApplicationId },
            { "startTimeAfter", givenStartTimeAfter.ToString() },
            { "endTimeBefore", givenEndTimeBefore.ToString() },
            { "page", givenPage.ToString() },
            { "size", givenSize.ToString() }
        };

        var givenResponse = @"
            {
              ""results"": [
                {
                  ""conferenceId"": ""034e622a-cc7e-456d-8a10-0ba43b11aa5e"",
                  ""name"": ""Example conference"",
                  ""platform"": {
                    ""applicationId"": ""61c060db2675060027d8c7a6""
                  },
                  ""startTime"": ""2021-12-31T23:57:30.100+0000"",
                  ""endTime"": ""2021-12-31T23:59:20.100+0000"",
                  ""duration"": 110,
                  ""sessions"": [
                    {
                      ""callId"": ""d8d84155-3831-43fb-91c9-bb897149a79d"",
                      ""joinTime"": ""2021-12-31T23:58:00.100+0000"",
                      ""leaveTime"": ""2021-12-31T23:59:00.100+0000""
                    },
                    {
                      ""callId"": ""3ad8805e-d401-424e-9b03-e02a2016a5e2"",
                      ""joinTime"": ""2021-12-31T23:57:30.100+0000"",
                      ""leaveTime"": ""2021-12-31T23:59:20.100+0000""
                    }
                  ],
                  ""recording"": {
                    ""composedFiles"": [
                      {
                        ""id"": ""b72cde3c-7d9c-4a5c-8e48-5a947244c013"",
                        ""name"": ""d8d84155-3831-43fb-91c9-bb897149a79d_41792030001_1652725357412_recording.wav"",
                        ""fileFormat"": ""WAV"",
                        ""size"": 67564,
                        ""creationTime"": ""2022-01-01T00:00:00.100+0000"",
                        ""duration"": 10,
                        ""startTime"": ""2021-12-31T23:57:30.100+0000"",
                        ""endTime"": ""2021-12-31T23:59:20.100+0000"",
                        ""location"": ""HOSTED""
                      }
                    ],
                    ""callRecordings"": [
                      {
                        ""callId"": ""d8d84155-3831-43fb-91c9-bb897149a79d"",
                        ""endpoint"": {
                          ""type"": ""PHONE"",
                          ""phoneNumber"": ""44790123456""
                        },
                        ""direction"": ""INBOUND"",
                        ""files"": [
                          {
                            ""id"": ""d8d84155-3831-43fb-91c9-bb897149a79d"",
                            ""name"": ""d8d84155-3831-43fb-91c9-bb897149a79d_1652725357412.wav"",
                            ""fileFormat"": ""WAV"",
                            ""size"": 67564,
                            ""creationTime"": ""2022-01-01T00:00:00.250+0000"",
                            ""duration"": 10,
                            ""startTime"": ""2021-12-31T23:59:50.100+0000"",
                            ""endTime"": ""2022-01-01T00:00:00.100+0000"",
                            ""location"": ""HOSTED"",
                            ""customData"": {
                              ""key1"": ""value1"",
                              ""key2"": ""value2""
                            }
                          }
                        ],
                        ""status"": ""SUCCESSFUL""
                      },
                      {
                        ""callId"": ""3ad8805e-d401-424e-9b03-e02a2016a5e2"",
                        ""endpoint"": {
                          ""type"": ""PHONE"",
                          ""phoneNumber"": ""44790123456""
                        },
                        ""direction"": ""INBOUND"",
                        ""files"": [
                          {
                            ""id"": ""d8d84155-3831-43fb-91c9-bb897149a79d"",
                            ""name"": ""d8d84155-3831-43fb-91c9-bb897149a79d_1652725357412.wav"",
                            ""fileFormat"": ""WAV"",
                            ""size"": 67564,
                            ""creationTime"": ""2022-01-01T00:00:00.250+0000"",
                            ""duration"": 10,
                            ""startTime"": ""2021-12-31T23:59:50.100+0000"",
                            ""endTime"": ""2022-01-01T00:00:00.100+0000"",
                            ""location"": ""HOSTED"",
                            ""customData"": {
                              ""key1"": ""value1"",
                              ""key2"": ""value2""
                            }
                          }
                        ],
                        ""status"": ""SUCCESSFUL""
                      }
                    ]
                  },
                  ""errorCode"": {
                    ""id"": 10000,
                    ""name"": ""NORMAL_HANGUP"",
                    ""description"": ""The call has ended with hangup initiated by caller, callee or API""
                  }
                }
              ],
              ""paging"": {
                ""page"": 0,
                ""size"": 1,
                ""totalPages"": 1,
                ""totalResults"": 1
              }
            }";

        SetUpGetRequest(GET_CONFERENCES_HISTORY, 200, givenResponse, givenQueryParameters);

        var api = new CallsApi(configuration);

        var expectedResponse = new CallsConferenceLogPage(
            new List<CallsConferenceLog>
            {
                new(
                    "034e622a-cc7e-456d-8a10-0ba43b11aa5e",
                    "Example conference",
                    new Platform(
                        applicationId: "61c060db2675060027d8c7a6"
                    ),
                    DateTimeOffset.Parse("2021-12-31T23:57:30.100+0000"),
                    DateTimeOffset.Parse("2021-12-31T23:59:20.100+0000"),
                    110,
                    new List<CallsParticipantSession>
                    {
                        new(
                            "d8d84155-3831-43fb-91c9-bb897149a79d",
                            DateTimeOffset.Parse("2021-12-31T23:58:00.100+0000"),
                            DateTimeOffset.Parse("2021-12-31T23:59:00.100+0000")
                        ),
                        new(
                            "3ad8805e-d401-424e-9b03-e02a2016a5e2",
                            DateTimeOffset.Parse("2021-12-31T23:57:30.100+0000"),
                            DateTimeOffset.Parse("2021-12-31T23:59:20.100+0000")
                        )
                    },
                    new CallsConferenceRecordingLog(
                        new List<CallsRecordingFile>
                        {
                            new(
                                "b72cde3c-7d9c-4a5c-8e48-5a947244c013",
                                "d8d84155-3831-43fb-91c9-bb897149a79d_41792030001_1652725357412_recording.wav",
                                CallsFileFormat.Wav,
                                67564,
                                DateTimeOffset.Parse("2022-01-01T00:00:00.100+0000"),
                                10,
                                DateTimeOffset.Parse("2021-12-31T23:57:30.100+0000"),
                                DateTimeOffset.Parse("2021-12-31T23:59:20.100+0000"),
                                CallsRecordingFileLocation.Hosted
                            )
                        },
                        new List<CallRecording>
                        {
                            new(
                                "d8d84155-3831-43fb-91c9-bb897149a79d",
                                new CallsPhoneEndpoint(
                                    "44790123456"
                                ),
                                CallDirection.Inbound,
                                new List<CallsRecordingFile>
                                {
                                    new(
                                        "d8d84155-3831-43fb-91c9-bb897149a79d",
                                        "d8d84155-3831-43fb-91c9-bb897149a79d_1652725357412.wav",
                                        CallsFileFormat.Wav,
                                        67564,
                                        DateTimeOffset.Parse("2022-01-01T00:00:00.250+0000"),
                                        10,
                                        DateTimeOffset.Parse("2021-12-31T23:59:50.100+0000"),
                                        DateTimeOffset.Parse("2022-01-01T00:00:00.100+0000"),
                                        CallsRecordingFileLocation.Hosted,
                                        customData: new Dictionary<string, string>
                                        {
                                            { "key1", "value1" },
                                            { "key2", "value2" }
                                        }
                                    )
                                },
                                CallsRecordingStatus.Successful
                            ),
                            new(
                                "3ad8805e-d401-424e-9b03-e02a2016a5e2",
                                new CallsPhoneEndpoint(
                                    "44790123456"
                                ),
                                CallDirection.Inbound,
                                new List<CallsRecordingFile>
                                {
                                    new(
                                        "d8d84155-3831-43fb-91c9-bb897149a79d",
                                        "d8d84155-3831-43fb-91c9-bb897149a79d_1652725357412.wav",
                                        CallsFileFormat.Wav,
                                        67564,
                                        DateTimeOffset.Parse("2022-01-01T00:00:00.250+0000"),
                                        10,
                                        DateTimeOffset.Parse("2021-12-31T23:59:50.100+0000"),
                                        DateTimeOffset.Parse("2022-01-01T00:00:00.100+0000"),
                                        CallsRecordingFileLocation.Hosted,
                                        customData: new Dictionary<string, string>
                                        {
                                            { "key1", "value1" },
                                            { "key2", "value2" }
                                        }
                                    )
                                },
                                CallsRecordingStatus.Successful
                            )
                        }
                    ),
                    new CallsErrorCodeInfo(
                        10000,
                        "NORMAL_HANGUP",
                        "The call has ended with hangup initiated by caller, callee or API"
                    )
                )
            },
            new PageInfo(
                0,
                1,
                1,
                1
            )
        );
        ;

        var response = api.GetConferencesHistory(givenName, givenCallId, givenCallsConfigurationId, givenApplicationId,
            givenStartTimeAfter, givenEndTimeBefore, givenPage, givenSize);

        Assert.AreEqual(expectedResponse, response);
    }

    [TestMethod]
    public void ShouldGetConferenceHistory()
    {
        var givenConferenceId = "034e622a-cc7e-456d-8a10-0ba43b11aa5e";

        var givenResponse = @"
            {
              ""conferenceId"": ""034e622a-cc7e-456d-8a10-0ba43b11aa5e"",
              ""name"": ""Example conference"",
              ""platform"": {
                ""applicationId"": ""61c060db2675060027d8c7a6""
              },
              ""startTime"": ""2021-12-31T23:57:30.100+0000"",
              ""endTime"": ""2021-12-31T23:59:20.100+0000"",
              ""duration"": 110,
              ""sessions"": [
                {
                  ""callId"": ""d8d84155-3831-43fb-91c9-bb897149a79d"",
                  ""joinTime"": ""2021-12-31T23:58:00.100+0000"",
                  ""leaveTime"": ""2021-12-31T23:59:00.100+0000""
                },
                {
                  ""callId"": ""3ad8805e-d401-424e-9b03-e02a2016a5e2"",
                  ""joinTime"": ""2021-12-31T23:57:30.100+0000"",
                  ""leaveTime"": ""2021-12-31T23:59:20.100+0000""
                }
              ],
              ""recording"": {
                ""composedFiles"": [
                  {
                    ""id"": ""b72cde3c-7d9c-4a5c-8e48-5a947244c013"",
                    ""name"": ""d8d84155-3831-43fb-91c9-bb897149a79d_41792030001_1652725357412_recording.wav"",
                    ""fileFormat"": ""WAV"",
                    ""size"": 67564,
                    ""creationTime"": ""2022-01-01T00:00:00.100+0000"",
                    ""duration"": 10,
                    ""startTime"": ""2021-12-31T23:57:30.100+0000"",
                    ""endTime"": ""2021-12-31T23:59:20.100+0000"",
                    ""location"": ""HOSTED""
                  }
                ],
                ""callRecordings"": [
                  {
                    ""callId"": ""d8d84155-3831-43fb-91c9-bb897149a79d"",
                    ""endpoint"": {
                      ""type"": ""PHONE"",
                      ""phoneNumber"": ""44790123456""
                    },
                    ""direction"": ""INBOUND"",
                    ""files"": [
                      {
                        ""id"": ""d8d84155-3831-43fb-91c9-bb897149a79d"",
                        ""name"": ""d8d84155-3831-43fb-91c9-bb897149a79d_1652725357412.wav"",
                        ""fileFormat"": ""WAV"",
                        ""size"": 67564,
                        ""creationTime"": ""2022-01-01T00:00:00.250+0000"",
                        ""duration"": 10,
                        ""startTime"": ""2021-12-31T23:59:50.100+0000"",
                        ""endTime"": ""2022-01-01T00:00:00.100+0000"",
                        ""location"": ""HOSTED"",
                        ""customData"": {
                          ""key1"": ""value1"",
                          ""key2"": ""value2""
                        }
                      }
                    ],
                    ""status"": ""SUCCESSFUL""
                  },
                  {
                    ""callId"": ""3ad8805e-d401-424e-9b03-e02a2016a5e2"",
                    ""endpoint"": {
                      ""type"": ""PHONE"",
                      ""phoneNumber"": ""44790123456""
                    },
                    ""direction"": ""INBOUND"",
                    ""files"": [
                      {
                        ""id"": ""d8d84155-3831-43fb-91c9-bb897149a79d"",
                        ""name"": ""d8d84155-3831-43fb-91c9-bb897149a79d_1652725357412.wav"",
                        ""fileFormat"": ""WAV"",
                        ""size"": 67564,
                        ""creationTime"": ""2022-01-01T00:00:00.250+0000"",
                        ""duration"": 10,
                        ""startTime"": ""2021-12-31T23:59:50.100+0000"",
                        ""endTime"": ""2022-01-01T00:00:00.100+0000"",
                        ""location"": ""HOSTED"",
                        ""customData"": {
                          ""key1"": ""value1"",
                          ""key2"": ""value2""
                        }
                      }
                    ],
                    ""status"": ""SUCCESSFUL""
                  }
                ]
              },
              ""errorCode"": {
                ""id"": 10000,
                ""name"": ""NORMAL_HANGUP"",
                ""description"": ""The call has ended with hangup initiated by caller, callee or API""
              }
            }";

        SetUpGetRequest(GET_CONFERENCE_HISTORY.Replace("{conferenceId}", givenConferenceId), 200, givenResponse);

        var api = new CallsApi(configuration);

        var expectedResponse = new CallsConferenceLog(
            "034e622a-cc7e-456d-8a10-0ba43b11aa5e",
            "Example conference",
            new Platform(
                applicationId: "61c060db2675060027d8c7a6"
            ),
            DateTimeOffset.Parse("2021-12-31T23:57:30.100+0000"),
            DateTimeOffset.Parse("2021-12-31T23:59:20.100+0000"),
            110,
            new List<CallsParticipantSession>
            {
                new(
                    "d8d84155-3831-43fb-91c9-bb897149a79d",
                    DateTimeOffset.Parse("2021-12-31T23:58:00.100+0000"),
                    DateTimeOffset.Parse("2021-12-31T23:59:00.100+0000")
                ),
                new(
                    "3ad8805e-d401-424e-9b03-e02a2016a5e2",
                    DateTimeOffset.Parse("2021-12-31T23:57:30.100+0000"),
                    DateTimeOffset.Parse("2021-12-31T23:59:20.100+0000")
                )
            },
            new CallsConferenceRecordingLog(
                new List<CallsRecordingFile>
                {
                    new(
                        "b72cde3c-7d9c-4a5c-8e48-5a947244c013",
                        "d8d84155-3831-43fb-91c9-bb897149a79d_41792030001_1652725357412_recording.wav",
                        CallsFileFormat.Wav,
                        67564,
                        DateTimeOffset.Parse("2022-01-01T00:00:00.100+0000"),
                        10,
                        DateTimeOffset.Parse("2021-12-31T23:57:30.100+0000"),
                        DateTimeOffset.Parse("2021-12-31T23:59:20.100+0000"),
                        CallsRecordingFileLocation.Hosted
                    )
                },
                new List<CallRecording>
                {
                    new(
                        "d8d84155-3831-43fb-91c9-bb897149a79d",
                        new CallsPhoneEndpoint(
                            "44790123456"
                        ),
                        CallDirection.Inbound,
                        new List<CallsRecordingFile>
                        {
                            new(
                                "d8d84155-3831-43fb-91c9-bb897149a79d",
                                "d8d84155-3831-43fb-91c9-bb897149a79d_1652725357412.wav",
                                CallsFileFormat.Wav,
                                67564,
                                DateTimeOffset.Parse("2022-01-01T00:00:00.250+0000"),
                                10,
                                DateTimeOffset.Parse("2021-12-31T23:59:50.100+0000"),
                                DateTimeOffset.Parse("2022-01-01T00:00:00.100+0000"),
                                CallsRecordingFileLocation.Hosted,
                                customData: new Dictionary<string, string>
                                {
                                    { "key1", "value1" },
                                    { "key2", "value2" }
                                }
                            )
                        },
                        CallsRecordingStatus.Successful
                    ),
                    new(
                        "3ad8805e-d401-424e-9b03-e02a2016a5e2",
                        new CallsPhoneEndpoint(
                            "44790123456"
                        ),
                        CallDirection.Inbound,
                        new List<CallsRecordingFile>
                        {
                            new(
                                "d8d84155-3831-43fb-91c9-bb897149a79d",
                                "d8d84155-3831-43fb-91c9-bb897149a79d_1652725357412.wav",
                                CallsFileFormat.Wav,
                                67564,
                                DateTimeOffset.Parse("2022-01-01T00:00:00.250+0000"),
                                10,
                                DateTimeOffset.Parse("2021-12-31T23:59:50.100+0000"),
                                DateTimeOffset.Parse("2022-01-01T00:00:00.100+0000"),
                                CallsRecordingFileLocation.Hosted,
                                customData: new Dictionary<string, string>
                                {
                                    { "key1", "value1" },
                                    { "key2", "value2" }
                                }
                            )
                        },
                        CallsRecordingStatus.Successful
                    )
                }
            ),
            new CallsErrorCodeInfo(
                10000,
                "NORMAL_HANGUP",
                "The call has ended with hangup initiated by caller, callee or API"
            )
        );

        var response = api.GetConferenceHistory(givenConferenceId);

        Assert.AreEqual(expectedResponse, response);
    }

    [TestMethod]
    public void ShouldAddNewCall()
    {
        var givenConferenceId = "034e622a-cc7e-456d-8a10-0ba43b11aa5e";

        var givenRequest = @"
        {
          ""callRequest"": {
            ""endpoint"": {
              ""type"": ""PHONE"",
              ""phoneNumber"": ""41792036727""
            },
            ""from"": ""41793026834"",
            ""maxDuration"": 28800
          },
          ""connectOnEarlyMedia"": false
        }";

        var givenResponse = @"
        {
          ""conference"": {
            ""id"": ""034e622a-cc7e-456d-8a10-0ba43b11aa5e"",
            ""name"": ""Example conference"",
            ""participants"": [
              {
                ""callId"": ""d8d84155-3831-43fb-91c9-bb897149a79d"",
                ""endpoint"": {
                  ""type"": ""PHONE"",
                  ""phoneNumber"": ""44790123456""
                },
                ""state"": ""JOINED"",
                ""joinTime"": ""2021-12-31T23:59:55.100+00:00"",
                ""media"": {
                  ""audio"": {
                    ""muted"": false,
                    ""deaf"": false
                  },
                  ""video"": {
                    ""camera"": false,
                    ""screenShare"": false
                  }
                }
              },
              {
                ""callId"": ""d8d84155-3831-43fb-91c9-bb897149a79d"",
                ""endpoint"": {
                  ""type"": ""PHONE"",
                  ""phoneNumber"": ""44790123456""
                },
                ""state"": ""JOINING"",
                ""media"": {
                  ""audio"": {
                    ""muted"": false,
                    ""deaf"": false
                  },
                  ""video"": {
                    ""camera"": false,
                    ""screenShare"": false
                  }
                }
              }
            ],
            ""callsConfigurationId"": ""dc5942707c704551a00cd2ea"",
            ""platform"": {
              ""applicationId"": ""61c060db2675060027d8c7a6""
            }
          },
          ""call"": {
            ""id"": ""d8d84155-3831-43fb-91c9-bb897149a79d"",
            ""endpoint"": {
              ""type"": ""PHONE"",
              ""phoneNumber"": ""44790123456""
            },
            ""from"": ""44790123456"",
            ""to"": ""44790123456"",
            ""direction"": ""OUTBOUND"",
            ""state"": ""CALLING"",
            ""media"": {
              ""audio"": {
                ""muted"": false,
                ""deaf"": false
              },
              ""video"": {
                ""camera"": false,
                ""screenShare"": false
              }
            },
            ""startTime"": ""2022-01-01T00:00:00.100+0000"",
            ""answerTime"": ""2022-01-01T00:00:02.100+0000"",
            ""ringDuration"": 2,
            ""callsConfigurationId"": ""dc5942707c704551a00cd2ea"",
            ""platform"": {
              ""applicationId"": ""61c060db2675060027d8c7a6""
            },
            ""conferenceId"": ""034e622a-cc7e-456d-8a10-0ba43b11aa5e"",
            ""customData"": {
              ""key1"": ""value1"",
              ""key2"": ""value2""
            }
          }
        }";

        SetUpPostRequest(ADD_NEW_CONFERENCE_CALL.Replace("{conferenceId}", givenConferenceId), 200, givenRequest,
            givenResponse);

        var api = new CallsApi(configuration);

        var request = new CallsAddNewCallRequest(
            new CallsActionCallRequest(
                new CallsPhoneEndpoint("41792036727"),
                "41793026834"
            )
        );

        var expectedResponse = new CallsConferenceAndCall(
            new CallsConference(
                "034e622a-cc7e-456d-8a10-0ba43b11aa5e",
                "Example conference",
                new List<CallsParticipant>
                {
                    new(
                        endpoint: new CallsPhoneEndpoint("44790123456"),
                        callId: "d8d84155-3831-43fb-91c9-bb897149a79d",
                        state: CallsParticipantState.Joined,
                        joinTime: DateTimeOffset.Parse("2021-12-31T23:59:55.100+0000"),
                        media: new CallsMediaProperties(
                            new CallsAudioMediaProperties(),
                            new CallsVideoMediaProperties()
                        )
                    ),
                    new(
                        endpoint: new CallsPhoneEndpoint("44790123456"),
                        callId: "d8d84155-3831-43fb-91c9-bb897149a79d",
                        state: CallsParticipantState.Joining,
                        media: new CallsMediaProperties(
                            new CallsAudioMediaProperties(),
                            new CallsVideoMediaProperties()
                        )
                    )
                },
                "dc5942707c704551a00cd2ea",
                new Platform(applicationId: "61c060db2675060027d8c7a6")
            ),
            new Call(
                endpoint: new CallsPhoneEndpoint("44790123456"),
                id: "d8d84155-3831-43fb-91c9-bb897149a79d",
                from: "44790123456",
                to: "44790123456",
                direction: CallDirection.Outbound,
                state: CallState.Calling,
                media: new CallsMediaProperties(
                    new CallsAudioMediaProperties(),
                    new CallsVideoMediaProperties()
                ),
                startTime: DateTimeOffset.Parse("2022-01-01T00:00:00.100+0000"),
                answerTime: DateTimeOffset.Parse("2022-01-01T00:00:02.100+0000"),
                ringDuration: 2,
                callsConfigurationId: "dc5942707c704551a00cd2ea",
                platform: new Platform(applicationId: "61c060db2675060027d8c7a6"),
                conferenceId: "034e622a-cc7e-456d-8a10-0ba43b11aa5e",
                customData: new Dictionary<string, string>
                {
                    { "key1", "value1" },
                    { "key2", "value2" }
                }
            )
        );

        var response = api.AddNewConferenceCall(givenConferenceId, request);

        Assert.AreEqual(expectedResponse, response);
    }

    [TestMethod]
    public void ShouldAddExistingCall()
    {
        var givenConferenceId = "034e622a-cc7e-456d-8a10-0ba43b11aa5e";
        var givenCallId = "d8d84155-3831-43fb-91c9-bb897149a79d";

        var givenRequest = @"
            {
              ""connectOnEarlyMedia"": false,
              ""ringbackGeneration"": {
                ""enabled"": false
              }
            }";

        var givenResponse = @"
            {
              ""id"": ""034e622a-cc7e-456d-8a10-0ba43b11aa5e"",
              ""name"": ""Example conference"",
              ""participants"": [
                {
                  ""callId"": ""d8d84155-3831-43fb-91c9-bb897149a79d"",
                  ""endpoint"": {
                    ""type"": ""PHONE"",
                    ""phoneNumber"": ""44790123456""
                  },
                  ""state"": ""JOINED"",
                  ""joinTime"": ""2021-12-31T23:59:55.100+0000"",
                  ""media"": {
                    ""audio"": {
                      ""muted"": false,
                      ""deaf"": false
                    },
                    ""video"": {
                      ""camera"": false,
                      ""screenShare"": false
                    }
                  }
                },
                {
                  ""callId"": ""d8d84155-3831-43fb-91c9-bb897149a79d"",
                  ""endpoint"": {
                    ""type"": ""PHONE"",
                    ""phoneNumber"": ""44790123456""
                  },
                  ""state"": ""JOINING"",
                  ""media"": {
                    ""audio"": {
                      ""muted"": false,
                      ""deaf"": false
                    },
                    ""video"": {
                      ""camera"": false,
                      ""screenShare"": false
                    }
                  }
                }
              ],
              ""callsConfigurationId"": ""dc5942707c704551a00cd2ea"",
              ""platform"": {
                ""applicationId"": ""61c060db2675060027d8c7a6""
              }
            }";

        SetUpPutRequest(
            ADD_EXISTING_CONFERENCE_CALL.Replace("{conferenceId}", givenConferenceId).Replace("{callId}", givenCallId),
            200, givenRequest, givenResponse);

        var api = new CallsApi(configuration);

        var request = new CallsAddExistingCallRequest(
            false,
            new RingbackGeneration()
        );

        var expectedResponse = new CallsConference(
            "034e622a-cc7e-456d-8a10-0ba43b11aa5e",
            "Example conference",
            new List<CallsParticipant>
            {
                new(
                    "d8d84155-3831-43fb-91c9-bb897149a79d",
                    new CallsPhoneEndpoint("44790123456"),
                    CallsParticipantState.Joined,
                    DateTimeOffset.Parse("2021-12-31T23:59:55.100+0000"),
                    media: new CallsMediaProperties(
                        new CallsAudioMediaProperties(),
                        new CallsVideoMediaProperties()
                    )
                ),
                new(
                    "d8d84155-3831-43fb-91c9-bb897149a79d",
                    new CallsPhoneEndpoint("44790123456"),
                    CallsParticipantState.Joining,
                    media: new CallsMediaProperties(
                        new CallsAudioMediaProperties(),
                        new CallsVideoMediaProperties()
                    )
                )
            },
            "dc5942707c704551a00cd2ea",
            new Platform(applicationId: "61c060db2675060027d8c7a6")
        );

        var response = api.AddExistingConferenceCall(givenConferenceId, givenCallId, request);

        Assert.AreEqual(expectedResponse, response);
    }

    [TestMethod]
    public void ShouldRemoveCall()
    {
        var givenConferenceId = "034e622a-cc7e-456d-8a10-0ba43b11aa5e";
        var givenCallId = "d8d84155-3831-43fb-91c9-bb897149a79d";

        var givenResponse = @"
            {
              ""status"": ""PENDING""
            }";

        SetUpDeleteRequest(
            REMOVE_CONFERENCE_CALL.Replace("{conferenceId}", givenConferenceId).Replace("{callId}", givenCallId), 200,
            expectedResponse: givenResponse);

        var api = new CallsApi(configuration);

        var expectedResponse = new CallsActionResponse(
            CallsActionStatus.Pending
        );

        var response = api.RemoveConferenceCall(givenConferenceId, givenCallId);

        Assert.AreEqual(expectedResponse, response);
    }

    [TestMethod]
    public void ShouldUpdateCall()
    {
        var givenConferenceId = "034e622a-cc7e-456d-8a10-0ba43b11aa5e";
        var givenCallId = "d8d84155-3831-43fb-91c9-bb897149a79d";

        var givenRequest = @"
            {
              ""muted"": false,
              ""deaf"": true
            }";

        var givenResponse = @"
            {
              ""status"": ""PENDING""
            }";

        SetUpPatchRequest(
            UPDATE_CONFERENCE_CALL.Replace("{conferenceId}", givenConferenceId).Replace("{callId}", givenCallId), 200,
            givenRequest, givenResponse);

        var api = new CallsApi(configuration);

        var request = new CallsUpdateRequest(
            false,
            true
        );

        var expectedResponse = new CallsActionResponse(
            CallsActionStatus.Pending
        );

        var response = api.UpdateConferenceCall(givenConferenceId, givenCallId, request);

        Assert.AreEqual(expectedResponse, response);
    }

    [TestMethod]
    public void ShouldHangupConference()
    {
        var givenConferenceId = "034e622a-cc7e-456d-8a10-0ba43b11aa5e";

        var givenResponse = @"
            {
              ""id"": ""034e622a-cc7e-456d-8a10-0ba43b11aa5e"",
              ""name"": ""Example conference"",
              ""participants"": [
                {
                  ""callId"": ""d8d84155-3831-43fb-91c9-bb897149a79d"",
                  ""endpoint"": {
                    ""type"": ""PHONE"",
                    ""phoneNumber"": ""44790123456""
                  },
                  ""state"": ""JOINED"",
                  ""joinTime"": ""2021-12-31T23:59:55.100+0000"",
                  ""media"": {
                    ""audio"": {
                      ""muted"": false,
                      ""deaf"": false
                    },
                    ""video"": {
                      ""camera"": false,
                      ""screenShare"": false
                    }
                  }
                },
                {
                  ""callId"": ""d8d84155-3831-43fb-91c9-bb897149a79d"",
                  ""endpoint"": {
                    ""type"": ""PHONE"",
                    ""phoneNumber"": ""44790123456""
                  },
                  ""state"": ""JOINING"",
                  ""media"": {
                    ""audio"": {
                      ""muted"": false,
                      ""deaf"": false
                    },
                    ""video"": {
                      ""camera"": false,
                      ""screenShare"": false
                    }
                  }
                }
              ],
              ""callsConfigurationId"": ""dc5942707c704551a00cd2ea"",
              ""platform"": {
                ""applicationId"": ""61c060db2675060027d8c7a6""
              }
            }";

        SetUpPostRequest(HANGUP_CONFERENCE.Replace("{conferenceId}", givenConferenceId), 200,
            expectedResponse: givenResponse);

        var api = new CallsApi(configuration);

        var expectedResponse = new CallsConference(
            "034e622a-cc7e-456d-8a10-0ba43b11aa5e",
            "Example conference",
            new List<CallsParticipant>
            {
                new(
                    endpoint: new CallsPhoneEndpoint(
                        "44790123456"
                    ),
                    callId: "d8d84155-3831-43fb-91c9-bb897149a79d",
                    state: CallsParticipantState.Joined,
                    joinTime: DateTime.Parse("2021-12-31T23:59:55.100+00:00"),
                    media: new CallsMediaProperties(
                        new CallsAudioMediaProperties(),
                        new CallsVideoMediaProperties()
                    )
                ),
                new(
                    endpoint: new CallsPhoneEndpoint(
                        "44790123456"
                    ),
                    callId: "d8d84155-3831-43fb-91c9-bb897149a79d",
                    state: CallsParticipantState.Joining,
                    media: new CallsMediaProperties(
                        new CallsAudioMediaProperties(),
                        new CallsVideoMediaProperties()
                    )
                )
            },
            "dc5942707c704551a00cd2ea",
            new Platform(
                applicationId: "61c060db2675060027d8c7a6"
            )
        );

        var response = api.HangupConference(givenConferenceId);

        Assert.AreEqual(expectedResponse, response);
    }

    [TestMethod]
    public void ShouldConferencesPlayFile()
    {
        var givenConferenceId = "034e622a-cc7e-456d-8a10-0ba43b11aa5e";

        var givenRequest = @"
            {
              ""content"": {
                ""type"": ""FILE"",
                ""fileId"": ""b72cde3c-7d9c-4a5c-8e48-5a947244c013""
              }
            }";

        var givenResponse = @"
            {
              ""status"": ""PENDING""
            }";

        SetUpPostRequest(CONFERENCE_PLAY_FILE.Replace("{conferenceId}", givenConferenceId), 200, givenRequest,
            givenResponse);

        var api = new CallsApi(configuration);

        var request = new CallsConferencePlayRequest(
            content: new CallsFilePlayContent(
                "b72cde3c-7d9c-4a5c-8e48-5a947244c013"
            )
        );

        var expectedResponse = new CallsActionResponse(
            CallsActionStatus.Pending
        );

        var response = api.ConferencePlayFile(givenConferenceId, request);

        Assert.AreEqual(expectedResponse, response);
    }

    [TestMethod]
    public void ShouldConferencesStopPlayingFile()
    {
        var givenConferenceId = "034e622a-cc7e-456d-8a10-0ba43b11aa5e";

        var givenResponse = @"
            {
              ""status"": ""PENDING""
            }";

        SetUpPostRequest(CONFERENCE_STOP_PLAYING_FILE.Replace("{conferenceId}", givenConferenceId), 200,
            expectedResponse: givenResponse);

        var api = new CallsApi(configuration);

        var expectedResponse = new CallsActionResponse(
            CallsActionStatus.Pending
        );

        var response = api.ConferenceStopPlayingFile(givenConferenceId);

        Assert.AreEqual(expectedResponse, response);
    }

    [TestMethod]
    public void ShouldConferencesSayText()
    {
        var givenConferenceId = "034e622a-cc7e-456d-8a10-0ba43b11aa5e";

        var givenRequest = @"
            {
              ""text"": ""string"",
              ""language"": ""ar"",
              ""speechRate"": 0.5,
              ""preferences"": {
                ""voiceGender"": ""FEMALE"",
                ""voiceName"": ""Zeina""
              }
            }";

        var givenResponse = @"
            {
              ""status"": ""PENDING""
            }";

        SetUpPostRequest(CONFERENCE_SAY_TEXT.Replace("{conferenceId}", givenConferenceId), 200, givenRequest,
            givenResponse);

        var api = new CallsApi(configuration);

        var request = new CallsSayRequest(
            "string",
            CallsLanguage.Ar,
            0.5,
            preferences: new CallsVoicePreferences(
                CallsGender.Female,
                CallVoice.Zeina
            )
        );

        var expectedResponse = new CallsActionResponse(
            CallsActionStatus.Pending
        );

        var response = api.ConferenceSayText(givenConferenceId, request);

        Assert.AreEqual(expectedResponse, response);
    }

    [TestMethod]
    public void ShouldConferencesStartRecording()
    {
        var givenConferenceId = "034e622a-cc7e-456d-8a10-0ba43b11aa5e";

        var givenRequest = @"
            {
              ""recordingType"": ""AUDIO"",
              ""conferenceComposition"": {
                ""enabled"": true
              }
            }";

        var givenResponse = @"
            {
              ""status"": ""PENDING""
            }";

        SetUpPostRequest(CONFERENCE_START_RECORDING.Replace("{conferenceId}", givenConferenceId), 200, givenRequest,
            givenResponse);

        var api = new CallsApi(configuration);

        var request = new CallsConferenceRecordingRequest(
            CallsRecordingType.Audio,
            new CallsConferenceComposition(
                true
            )
        );

        var expectedResponse = new CallsActionResponse(
            CallsActionStatus.Pending
        );

        var response = api.ConferenceStartRecording(givenConferenceId, request);

        Assert.AreEqual(expectedResponse, response);
    }

    [TestMethod]
    public void ShouldConferencesStopRecording()
    {
        var givenConferenceId = "034e622a-cc7e-456d-8a10-0ba43b11aa5e";

        var givenResponse = @"
            {
              ""status"": ""PENDING""
            }";

        SetUpPostRequest(CONFERENCE_STOP_RECORDING.Replace("{conferenceId}", givenConferenceId), 200,
            expectedResponse: givenResponse);

        var api = new CallsApi(configuration);

        var expectedResponse = new CallsActionResponse(
            CallsActionStatus.Pending
        );

        var response = api.ConferenceStopRecording(givenConferenceId);

        Assert.AreEqual(expectedResponse, response);
    }

    [TestMethod]
    public void ShouldConferencesBroadcastText()
    {
        var givenConferenceId = "034e622a-cc7e-456d-8a10-0ba43b11aa5e";

        var givenRequest = @"
            {
              ""text"": ""This meeting will end in 5 minutes.""
            }";

        var givenResponse = @"
            {
              ""status"": ""PENDING""
            }";

        SetUpPostRequest(CONFERENCE_BROADCAST_WEBRTC_TEXT.Replace("{conferenceId}", givenConferenceId), 200,
            givenRequest, givenResponse);

        var api = new CallsApi(configuration);

        var request = new CallsConferenceBroadcastWebrtcTextRequest(
            "This meeting will end in 5 minutes."
        );

        var expectedResponse = new CallsActionResponse(
            CallsActionStatus.Pending
        );

        var response = api.ConferenceBroadcastWebrtcText(givenConferenceId, request);

        Assert.AreEqual(expectedResponse, response);
    }

    [TestMethod]
    public void ShouldGetDialogs()
    {
        var givenCallsConfigurationId = "dc5942707c704551a00cd2ea";
        var givenApplicationId = "61c060db2675060027d8c7a6";
        var givenState = CallsDialogState.Established;
        var givenParentCallId = "066675c6-0db6-0db9-b032-031964d09af4";
        var givenChildCallId = "072675c6-3db6-0fb9-b632-031264d09ck2";
        var givenStartTimeAfter = DateTimeOffset.Parse("2022-05-01T14:25:45.125+0000");
        var givenPage = 0;
        var givenSize = 20;
        var givenQueryParameters = new Dictionary<string, string>
        {
            { "callsConfigurationId", givenCallsConfigurationId },
            { "applicationId", givenApplicationId },
            { "state", givenState.ToString() },
            { "parentCallId", givenParentCallId },
            { "childCallId", givenChildCallId },
            { "startTimeAfter", givenStartTimeAfter.ToString() },
            { "page", givenPage.ToString() },
            { "size", givenSize.ToString() }
        };

        var givenResponse = @"
            {
              ""results"": [
                {
                  ""id"": ""034e622a-cc7e-456d-8a10-0ba43b11aa5e"",
                  ""platform"": {
                    ""applicationId"": ""61c060db2675060027d8c7a6""
                  },
                  ""state"": ""ESTABLISHED"",
                  ""startTime"": ""2022-01-01T00:00:00.100+0000"",
                  ""establishTime"": ""2022-01-01T00:00:02.100+0000"",
                  ""endTime"": ""2022-01-01T00:01:00.100+0000"",
                  ""parentCall"": {
                    ""id"": ""d8d84155-3831-43fb-91c9-bb897149a79d"",
                    ""endpoint"": {
                      ""type"": ""PHONE"",
                      ""phoneNumber"": ""44790123456""
                    },
                    ""direction"": ""INBOUND"",
                    ""state"": ""ESTABLISHED"",
                    ""media"": {
                      ""audio"": {
                        ""muted"": false,
                        ""deaf"": false
                      },
                      ""video"": {
                        ""camera"": false,
                        ""screenShare"": false
                      }
                    },
                    ""startTime"": ""2022-01-01T00:00:00.100+0000"",
                    ""answerTime"": ""2022-01-01T00:00:02.100+0000"",
                    ""endTime"": ""2022-01-01T00:01:00.100+0000"",
                    ""ringDuration"": 2,
                    ""platform"": {
                      ""applicationId"": ""61c060db2675060027d8c7a6""
                    },
                    ""dialogId"": ""034e622a-cc7e-456d-8a10-0ba43b11aa5e""
                  },
                  ""childCall"": {
                    ""id"": ""3ad8805e-d401-424e-9b03-e02a2016a5e2"",
                    ""endpoint"": {
                      ""type"": ""PHONE"",
                      ""phoneNumber"": ""44790987654""
                    },
                    ""direction"": ""OUTBOUND"",
                    ""state"": ""ESTABLISHED"",
                    ""media"": {
                      ""audio"": {
                        ""muted"": false,
                        ""deaf"": false
                      },
                      ""video"": {
                        ""camera"": false,
                        ""screenShare"": false
                      }
                    },
                    ""startTime"": ""2022-01-01T00:00:00.100+0000"",
                    ""answerTime"": ""2022-01-01T00:00:02.100+0000"",
                    ""endTime"": ""2022-01-01T00:01:00.100+0000"",
                    ""ringDuration"": 2,
                    ""platform"": {
                      ""applicationId"": ""61c060db2675060027d8c7a6""
                    },
                    ""dialogId"": ""034e622a-cc7e-456d-8a10-0ba43b11aa5e""
                  }
                }
              ],
              ""paging"": {
                ""page"": 0,
                ""size"": 1,
                ""totalPages"": 1,
                ""totalResults"": 1
              }
            }";

        SetUpGetRequest(GET_DIALOGS, 200, givenResponse, givenQueryParameters);

        var api = new CallsApi(configuration);

        var expectedResponse = new CallsDialogPage(
            new List<CallsDialogResponse>
            {
                new(
                    "034e622a-cc7e-456d-8a10-0ba43b11aa5e",
                    platform: new Platform(
                        applicationId: "61c060db2675060027d8c7a6"
                    ),
                    state: CallsDialogState.Established,
                    startTime: DateTimeOffset.Parse("2022-01-01T00:00:00.100+0000"),
                    establishTime: DateTimeOffset.Parse("2022-01-01T00:00:02.100+0000"),
                    endTime: DateTimeOffset.Parse("2022-01-01T00:01:00.100+0000"),
                    parentCall: new Call(
                        "d8d84155-3831-43fb-91c9-bb897149a79d",
                        new CallsPhoneEndpoint(
                            "44790123456"
                        ),
                        direction: CallDirection.Inbound,
                        state: CallState.Established,
                        media: new CallsMediaProperties(
                            new CallsAudioMediaProperties(),
                            new CallsVideoMediaProperties()
                        ),
                        startTime: DateTimeOffset.Parse("2022-01-01T00:00:00.100+0000"),
                        answerTime: DateTimeOffset.Parse("2022-01-01T00:00:02.100+0000"),
                        endTime: DateTimeOffset.Parse("2022-01-01T00:01:00.100+0000"),
                        ringDuration: 2,
                        platform: new Platform(
                            applicationId: "61c060db2675060027d8c7a6"
                        ),
                        dialogId: "034e622a-cc7e-456d-8a10-0ba43b11aa5e"
                    ),
                    childCall: new Call(
                        "3ad8805e-d401-424e-9b03-e02a2016a5e2",
                        new CallsPhoneEndpoint(
                            "44790987654"
                        ),
                        direction: CallDirection.Outbound,
                        state: CallState.Established,
                        media: new CallsMediaProperties(
                            new CallsAudioMediaProperties(),
                            new CallsVideoMediaProperties()
                        ),
                        startTime: DateTimeOffset.Parse("2022-01-01T00:00:00.100+0000"),
                        answerTime: DateTimeOffset.Parse("2022-01-01T00:00:02.100+0000"),
                        endTime: DateTimeOffset.Parse("2022-01-01T00:01:00.100+0000"),
                        ringDuration: 2,
                        platform: new Platform(
                            applicationId: "61c060db2675060027d8c7a6"
                        ),
                        dialogId: "034e622a-cc7e-456d-8a10-0ba43b11aa5e"
                    )
                )
            },
            new PageInfo(
                0,
                1,
                1,
                1
            )
        );

        var response = api.GetDialogs(givenCallsConfigurationId, givenApplicationId, givenState, givenParentCallId,
            givenChildCallId, givenStartTimeAfter, givenPage, givenSize);

        Assert.AreEqual(expectedResponse, response);
    }

    [TestMethod]
    public void ShouldCreateDialog()
    {
        var givenRequest = @"
            {
              ""parentCallId"": ""d8d84155-3831-43fb-91c9-bb897149a79d"",
              ""childCallRequest"": {
                ""endpoint"": {
                  ""type"": ""PHONE"",
                  ""phoneNumber"": ""44790987654""
                },
                ""from"": ""44790123456"",
                ""connectTimeout"": 60,
                ""machineDetection"": {
                  ""enabled"": true
                },
                ""customData"": {
                  ""key1"": ""value1"",
                  ""key2"": ""value2""
                }
              },
              ""recording"": {
                ""recordingType"": ""AUDIO"",
                ""dialogComposition"": {
                  ""enabled"": false
                }
              },
              ""maxDuration"": 3600,
              ""propagationOptions"": {
                ""childCallHangup"": false,
                ""childCallRinging"": false
              }
            }";

        var givenResponse = @"
            {
              ""id"": ""034e622a-cc7e-456d-8a10-0ba43b11aa5e"",
              ""platform"": {
                ""applicationId"": ""61c060db2675060027d8c7a6""
              },
              ""state"": ""ESTABLISHED"",
              ""startTime"": ""2022-01-01T00:00:00.100+0000"",
              ""establishTime"": ""2022-01-01T00:00:02.100+0000"",
              ""endTime"": ""2022-01-01T00:01:00.100+0000"",
              ""parentCall"": {
                ""id"": ""d8d84155-3831-43fb-91c9-bb897149a79d"",
                ""endpoint"": {
                  ""type"": ""PHONE"",
                  ""phoneNumber"": ""44790123456""
                },
                ""direction"": ""INBOUND"",
                ""state"": ""ESTABLISHED"",
                ""media"": {
                  ""audio"": {
                    ""muted"": false,
                    ""deaf"": false
                  },
                  ""video"": {
                    ""camera"": false,
                    ""screenShare"": false
                  }
                },
                ""startTime"": ""2022-01-01T00:00:00.100+0000"",
                ""answerTime"": ""2022-01-01T00:00:02.100+0000"",
                ""endTime"": ""2022-01-01T00:01:00.100+0000"",
                ""ringDuration"": 2,
                ""platform"": {
                  ""applicationId"": ""61c060db2675060027d8c7a6""
                },
                ""dialogId"": ""034e622a-cc7e-456d-8a10-0ba43b11aa5e""
              },
              ""childCall"": {
                ""id"": ""3ad8805e-d401-424e-9b03-e02a2016a5e2"",
                ""endpoint"": {
                  ""type"": ""PHONE"",
                  ""phoneNumber"": ""44790987654""
                },
                ""direction"": ""OUTBOUND"",
                ""state"": ""ESTABLISHED"",
                ""media"": {
                  ""audio"": {
                    ""muted"": false,
                    ""deaf"": false
                  },
                  ""video"": {
                    ""camera"": false,
                    ""screenShare"": false
                  }
                },
                ""startTime"": ""2022-01-01T00:00:00.100+0000"",
                ""answerTime"": ""2022-01-01T00:00:02.100+0000"",
                ""endTime"": ""2022-01-01T00:01:00.100+0000"",
                ""ringDuration"": 2,
                ""platform"": {
                  ""applicationId"": ""61c060db2675060027d8c7a6""
                },
                ""dialogId"": ""034e622a-cc7e-456d-8a10-0ba43b11aa5e""
              }
            }";

        SetUpPostRequest(CREATE_DIALOG, 201, givenRequest, givenResponse);

        var api = new CallsApi(configuration);

        var request = new CallsDialogRequest(
            "d8d84155-3831-43fb-91c9-bb897149a79d",
            new CallsDialogCallRequest(
                new CallsPhoneEndpoint(
                    "44790987654"
                ),
                "44790123456",
                connectTimeout: 60,
                machineDetection: new CallsMachineDetectionRequest(
                    true
                ),
                customData: new Dictionary<string, string>
                {
                    { "key1", "value1" },
                    { "key2", "value2" }
                }
            ),
            new CallsDialogRecordingRequest(
                CallsRecordingType.Audio,
                new CallsDialogRecordingComposition()
            ),
            3600,
            new CallsDialogPropagationOptions(
                false
            )
        );

        var expectedResponse = new CallsDialogResponse(
            "034e622a-cc7e-456d-8a10-0ba43b11aa5e",
            platform: new Platform(
                applicationId: "61c060db2675060027d8c7a6"
            ),
            state: CallsDialogState.Established,
            startTime: DateTimeOffset.Parse("2022-01-01T00:00:00.100+0000"),
            establishTime: DateTimeOffset.Parse("2022-01-01T00:00:02.100+0000"),
            endTime: DateTimeOffset.Parse("2022-01-01T00:01:00.100+0000"),
            parentCall: new Call(
                "d8d84155-3831-43fb-91c9-bb897149a79d",
                new CallsPhoneEndpoint(
                    "44790123456"
                ),
                direction: CallDirection.Inbound,
                state: CallState.Established,
                media: new CallsMediaProperties(
                    new CallsAudioMediaProperties(),
                    new CallsVideoMediaProperties()
                ),
                startTime: DateTimeOffset.Parse("2022-01-01T00:00:00.100+0000"),
                answerTime: DateTimeOffset.Parse("2022-01-01T00:00:02.100+0000"),
                endTime: DateTimeOffset.Parse("2022-01-01T00:01:00.100+0000"),
                ringDuration: 2,
                platform: new Platform(
                    applicationId: "61c060db2675060027d8c7a6"
                ),
                dialogId: "034e622a-cc7e-456d-8a10-0ba43b11aa5e"
            ),
            childCall: new Call(
                "3ad8805e-d401-424e-9b03-e02a2016a5e2",
                new CallsPhoneEndpoint(
                    "44790987654"
                ),
                direction: CallDirection.Outbound,
                state: CallState.Established,
                media: new CallsMediaProperties(
                    new CallsAudioMediaProperties(),
                    new CallsVideoMediaProperties()
                ),
                startTime: DateTimeOffset.Parse("2022-01-01T00:00:00.100+0000"),
                answerTime: DateTimeOffset.Parse("2022-01-01T00:00:02.100+0000"),
                endTime: DateTimeOffset.Parse("2022-01-01T00:01:00.100+0000"),
                ringDuration: 2,
                platform: new Platform(
                    applicationId: "61c060db2675060027d8c7a6"
                ),
                dialogId: "034e622a-cc7e-456d-8a10-0ba43b11aa5e"
            )
        );

        var response = api.CreateDialog(request);

        Assert.AreEqual(expectedResponse, response);
    }

    [TestMethod]
    public void ShouldCreateDialogWithExistingCalls()
    {
        var givenParentCallId = "126f327b-dd4e-456d-8a10-1cb78a23bc8a";
        var givenChildCallId = "034e622a-cc7e-456d-8a10-0ba43b11aa5e";

        var givenRequest = @"
            {
              ""recording"": {
                ""recordingType"": ""AUDIO"",
                ""dialogComposition"": {
                  ""enabled"": false
                },
                ""customData"": {
                  ""property1"": ""string"",
                  ""property2"": ""string""
                },
                ""filePrefix"": ""string""
              },
              ""maxDuration"": 28800,
              ""propagationOptions"": {
                ""childCallHangup"": true,
                ""childCallRinging"": false,
                ""ringbackGeneration"": {
                  ""enabled"": false
                }
              }
            }";

        var givenResponse = @"
            {
              ""id"": ""034e622a-cc7e-456d-8a10-0ba43b11aa5e"",
              ""platform"": {
                ""applicationId"": ""61c060db2675060027d8c7a6""
              },
              ""state"": ""ESTABLISHED"",
              ""startTime"": ""2022-01-01T00:00:00.100+0000"",
              ""establishTime"": ""2022-01-01T00:00:02.100+0000"",
              ""endTime"": ""2022-01-01T00:01:00.100+0000"",
              ""parentCall"": {
                ""id"": ""d8d84155-3831-43fb-91c9-bb897149a79d"",
                ""endpoint"": {
                  ""type"": ""PHONE"",
                  ""phoneNumber"": ""44790123456""
                },
                ""direction"": ""INBOUND"",
                ""state"": ""ESTABLISHED"",
                ""media"": {
                  ""audio"": {
                    ""muted"": false,
                    ""deaf"": false
                  },
                  ""video"": {
                    ""camera"": false,
                    ""screenShare"": false
                  }
                },
                ""startTime"": ""2022-01-01T00:00:00.100+0000"",
                ""answerTime"": ""2022-01-01T00:00:02.100+0000"",
                ""endTime"": ""2022-01-01T00:01:00.100+0000"",
                ""ringDuration"": 2,
                ""platform"": {
                  ""applicationId"": ""61c060db2675060027d8c7a6""
                },
                ""dialogId"": ""034e622a-cc7e-456d-8a10-0ba43b11aa5e""
              },
              ""childCall"": {
                ""id"": ""3ad8805e-d401-424e-9b03-e02a2016a5e2"",
                ""endpoint"": {
                  ""type"": ""PHONE"",
                  ""phoneNumber"": ""44790987654""
                },
                ""direction"": ""OUTBOUND"",
                ""state"": ""ESTABLISHED"",
                ""media"": {
                  ""audio"": {
                    ""muted"": false,
                    ""deaf"": false
                  },
                  ""video"": {
                    ""camera"": false,
                    ""screenShare"": false
                  }
                },
                ""startTime"": ""2022-01-01T00:00:00.100+0000"",
                ""answerTime"": ""2022-01-01T00:00:02.100+0000"",
                ""endTime"": ""2022-01-01T00:01:00.100+0000"",
                ""ringDuration"": 2,
                ""platform"": {
                  ""applicationId"": ""61c060db2675060027d8c7a6""
                },
                ""dialogId"": ""034e622a-cc7e-456d-8a10-0ba43b11aa5e""
              }
            }";

        SetUpPostRequest(
            CREATE_DIALOG_WITH_EXISTING_CALLS.Replace("{parentCallId}", givenParentCallId)
                .Replace("{childCallId}", givenChildCallId), 201, givenRequest, givenResponse);

        var api = new CallsApi(configuration);

        var request = new CallsDialogWithExistingCallRequest(
            new CallsDialogRecordingRequest(
                CallsRecordingType.Audio,
                new CallsDialogRecordingComposition(),
                new Dictionary<string, string>
                {
                    { "property1", "string" },
                    { "property2", "string" }
                },
                "string"
            ),
            28800,
            new CallsDialogPropagationOptions(
                true,
                false,
                new RingbackGeneration()
            )
        );

        var expectedResponse = new CallsDialogResponse(
            "034e622a-cc7e-456d-8a10-0ba43b11aa5e",
            platform: new Platform(
                applicationId: "61c060db2675060027d8c7a6"
            ),
            state: CallsDialogState.Established,
            startTime: DateTimeOffset.Parse("2022-01-01T00:00:00.100+0000"),
            establishTime: DateTimeOffset.Parse("2022-01-01T00:00:02.100+0000"),
            endTime: DateTimeOffset.Parse("2022-01-01T00:01:00.100+0000"),
            parentCall: new Call(
                "d8d84155-3831-43fb-91c9-bb897149a79d",
                new CallsPhoneEndpoint(
                    "44790123456"
                ),
                direction: CallDirection.Inbound,
                state: CallState.Established,
                media: new CallsMediaProperties(
                    new CallsAudioMediaProperties(),
                    new CallsVideoMediaProperties()
                ),
                startTime: DateTimeOffset.Parse("2022-01-01T00:00:00.100+0000"),
                answerTime: DateTimeOffset.Parse("2022-01-01T00:00:02.100+0000"),
                endTime: DateTimeOffset.Parse("2022-01-01T00:01:00.100+0000"),
                ringDuration: 2,
                platform: new Platform(
                    applicationId: "61c060db2675060027d8c7a6"
                ),
                dialogId: "034e622a-cc7e-456d-8a10-0ba43b11aa5e"
            ),
            childCall: new Call(
                "3ad8805e-d401-424e-9b03-e02a2016a5e2",
                new CallsPhoneEndpoint(
                    "44790987654"
                ),
                direction: CallDirection.Outbound,
                state: CallState.Established,
                media: new CallsMediaProperties(
                    new CallsAudioMediaProperties(),
                    new CallsVideoMediaProperties()
                ),
                startTime: DateTimeOffset.Parse("2022-01-01T00:00:00.100+0000"),
                answerTime: DateTimeOffset.Parse("2022-01-01T00:00:02.100+0000"),
                endTime: DateTimeOffset.Parse("2022-01-01T00:01:00.100+0000"),
                ringDuration: 2,
                platform: new Platform(
                    applicationId: "61c060db2675060027d8c7a6"
                ),
                dialogId: "034e622a-cc7e-456d-8a10-0ba43b11aa5e"
            )
        );

        var response = api.CreateDialogWithExistingCalls(givenParentCallId, givenChildCallId, request);

        Assert.AreEqual(expectedResponse, response);
    }

    [TestMethod]
    public void ShouldGetDialog()
    {
        var givenDialogId = "034e622a-cc7e-456d-8a10-0ba43b11aa5e";

        var givenResponse = @"
            {
              ""id"": ""034e622a-cc7e-456d-8a10-0ba43b11aa5e"",
              ""platform"": {
                ""applicationId"": ""61c060db2675060027d8c7a6""
              },
              ""state"": ""ESTABLISHED"",
              ""startTime"": ""2022-01-01T00:00:00.100+0000"",
              ""establishTime"": ""2022-01-01T00:00:02.100+0000"",
              ""endTime"": ""2022-01-01T00:01:00.100+0000"",
              ""parentCall"": {
                ""id"": ""d8d84155-3831-43fb-91c9-bb897149a79d"",
                ""endpoint"": {
                  ""type"": ""PHONE"",
                  ""phoneNumber"": ""44790123456""
                },
                ""direction"": ""INBOUND"",
                ""state"": ""ESTABLISHED"",
                ""media"": {
                  ""audio"": {
                    ""muted"": false,
                    ""deaf"": false
                  },
                  ""video"": {
                    ""camera"": false,
                    ""screenShare"": false
                  }
                },
                ""startTime"": ""2022-01-01T00:00:00.100+0000"",
                ""answerTime"": ""2022-01-01T00:00:02.100+0000"",
                ""endTime"": ""2022-01-01T00:01:00.100+0000"",
                ""ringDuration"": 2,
                ""platform"": {
                  ""applicationId"": ""61c060db2675060027d8c7a6""
                },
                ""dialogId"": ""034e622a-cc7e-456d-8a10-0ba43b11aa5e""
              },
              ""childCall"": {
                ""id"": ""3ad8805e-d401-424e-9b03-e02a2016a5e2"",
                ""endpoint"": {
                  ""type"": ""PHONE"",
                  ""phoneNumber"": ""44790987654""
                },
                ""direction"": ""OUTBOUND"",
                ""state"": ""ESTABLISHED"",
                ""media"": {
                  ""audio"": {
                    ""muted"": false,
                    ""deaf"": false
                  },
                  ""video"": {
                    ""camera"": false,
                    ""screenShare"": false
                  }
                },
                ""startTime"": ""2022-01-01T00:00:00.100+0000"",
                ""answerTime"": ""2022-01-01T00:00:02.100+0000"",
                ""endTime"": ""2022-01-01T00:01:00.100+0000"",
                ""ringDuration"": 2,
                ""platform"": {
                  ""applicationId"": ""61c060db2675060027d8c7a6""
                },
                ""dialogId"": ""034e622a-cc7e-456d-8a10-0ba43b11aa5e""
              }
            }";

        SetUpGetRequest(GET_DIALOG.Replace("{dialogId}", givenDialogId), 200, givenResponse);

        var api = new CallsApi(configuration);

        var expectedResponse = new CallsDialogResponse(
            "034e622a-cc7e-456d-8a10-0ba43b11aa5e",
            platform: new Platform(
                applicationId: "61c060db2675060027d8c7a6"
            ),
            state: CallsDialogState.Established,
            startTime: DateTimeOffset.Parse("2022-01-01T00:00:00.100+0000"),
            establishTime: DateTimeOffset.Parse("2022-01-01T00:00:02.100+0000"),
            endTime: DateTimeOffset.Parse("2022-01-01T00:01:00.100+0000"),
            parentCall: new Call(
                "d8d84155-3831-43fb-91c9-bb897149a79d",
                new CallsPhoneEndpoint(
                    "44790123456"
                ),
                direction: CallDirection.Inbound,
                state: CallState.Established,
                media: new CallsMediaProperties(
                    new CallsAudioMediaProperties(),
                    new CallsVideoMediaProperties()
                ),
                startTime: DateTimeOffset.Parse("2022-01-01T00:00:00.100+0000"),
                answerTime: DateTimeOffset.Parse("2022-01-01T00:00:02.100+0000"),
                endTime: DateTimeOffset.Parse("2022-01-01T00:01:00.100+0000"),
                ringDuration: 2,
                platform: new Platform(
                    applicationId: "61c060db2675060027d8c7a6"
                ),
                dialogId: "034e622a-cc7e-456d-8a10-0ba43b11aa5e"
            ),
            childCall: new Call(
                "3ad8805e-d401-424e-9b03-e02a2016a5e2",
                new CallsPhoneEndpoint(
                    "44790987654"
                ),
                direction: CallDirection.Outbound,
                state: CallState.Established,
                media: new CallsMediaProperties(
                    new CallsAudioMediaProperties(),
                    new CallsVideoMediaProperties()
                ),
                startTime: DateTimeOffset.Parse("2022-01-01T00:00:00.100+0000"),
                answerTime: DateTimeOffset.Parse("2022-01-01T00:00:02.100+0000"),
                endTime: DateTimeOffset.Parse("2022-01-01T00:01:00.100+0000"),
                ringDuration: 2,
                platform: new Platform(
                    applicationId: "61c060db2675060027d8c7a6"
                ),
                dialogId: "034e622a-cc7e-456d-8a10-0ba43b11aa5e"
            )
        );

        var response = api.GetDialog(givenDialogId);

        Assert.AreEqual(expectedResponse, response);
    }

    [TestMethod]
    public void ShouldGetDialogsHistory()
    {
        var givenCallsConfigurationId = "dc5942707c704551a00cd2ea";
        var givenApplicationId = "61c060db2675060027d8c7a6";
        var givenState = CallsDialogState.Established;
        var givenParentCallId = "066675c6-0db6-0db9-b032-031964d09af4";
        var givenChildCallId = "072675c6-3db6-0fb9-b632-031264d09ck2";
        var givenStartTimeAfter = DateTimeOffset.Parse("2022-05-01T14:25:45.125+0000");
        var givenEndTimeBefore = DateTimeOffset.Parse("2022-05-01T14:26:45.125+0000");
        var givenPage = 0;
        var givenSize = 20;
        var givenQueryParameters = new Dictionary<string, string>
        {
            { "callsConfigurationId", givenCallsConfigurationId },
            { "applicationId", givenApplicationId },
            { "state", givenState.ToString() },
            { "parentCallId", givenParentCallId },
            { "childCallId", givenChildCallId },
            { "startTimeAfter", givenStartTimeAfter.ToString() },
            { "endTimeBefore", givenEndTimeBefore.ToString() },
            { "page", givenPage.ToString() },
            { "size", givenSize.ToString() }
        };

        var givenResponse = @"
            {
              ""results"": [
                {
                  ""dialogId"": ""034e622a-cc7e-456d-8a10-0ba43b11aa5e"",
                  ""platform"": {
                    ""applicationId"": ""61c060db2675060027d8c7a6""
                  },
                  ""state"": ""ESTABLISHED"",
                  ""startTime"": ""2022-01-01T00:00:00.100+0000"",
                  ""establishTime"": ""2022-01-01T00:00:02.100+0000"",
                  ""endTime"": ""2022-01-01T00:01:00.100+0000"",
                  ""parentCallId"": ""d8d84155-3831-43fb-91c9-bb897149a79d"",
                  ""childCallId"": ""3ad8805e-d401-424e-9b03-e02a2016a5e2"",
                  ""duration"": 60,
                  ""recording"": {
                    ""composedFiles"": [
                      {
                        ""id"": ""b72cde3c-7d9c-4a5c-8e48-5a947244c013"",
                        ""name"": ""d8d84155-3831-43fb-91c9-bb897149a79d_41792030001_1652725357412_recording.wav"",
                        ""fileFormat"": ""WAV"",
                        ""size"": 67564,
                        ""creationTime"": ""2022-01-01T00:00:00.100+0000"",
                        ""duration"": 10,
                        ""startTime"": ""2021-12-31T23:57:30.100+0000"",
                        ""endTime"": ""2021-12-31T23:59:20.100+0000"",
                        ""location"": ""SFTP"",
                        ""sftpUploadStatus"": ""UPLOADED""
                      }
                    ],
                    ""callRecordings"": [
                      {
                        ""callId"": ""d8d84155-3831-43fb-91c9-bb897149a79d"",
                        ""endpoint"": {
                          ""type"": ""PHONE"",
                          ""phoneNumber"": ""44790123456""
                        },
                        ""direction"": ""INBOUND"",
                        ""files"": [
                          {
                            ""id"": ""d8d84155-3831-43fb-91c9-bb897149a79d"",
                            ""name"": ""d8d84155-3831-43fb-91c9-bb897149a79d_1652725357412.wav"",
                            ""fileFormat"": ""WAV"",
                            ""size"": 67564,
                            ""creationTime"": ""2022-01-01T00:00:00.250+0000"",
                            ""duration"": 10,
                            ""startTime"": ""2021-12-31T23:59:50.100+0000"",
                            ""endTime"": ""2022-01-01T00:00:00.100+0000"",
                            ""location"": ""HOSTED"",
                            ""customData"": {
                              ""key1"": ""value1"",
                              ""key2"": ""value2""
                            }
                          }
                        ],
                        ""status"": ""SUCCESSFUL""
                      },
                      {
                        ""callId"": ""3ad8805e-d401-424e-9b03-e02a2016a5e2"",
                        ""endpoint"": {
                          ""type"": ""PHONE"",
                          ""phoneNumber"": ""44790123456""
                        },
                        ""direction"": ""INBOUND"",
                        ""files"": [
                          {
                            ""id"": ""d8d84155-3831-43fb-91c9-bb897149a79d"",
                            ""name"": ""d8d84155-3831-43fb-91c9-bb897149a79d_1652725357412.wav"",
                            ""fileFormat"": ""WAV"",
                            ""size"": 67564,
                            ""creationTime"": ""2022-01-01T00:00:00.250+0000"",
                            ""duration"": 10,
                            ""startTime"": ""2021-12-31T23:59:50.100+0000"",
                            ""endTime"": ""2022-01-01T00:00:00.100+0000"",
                            ""location"": ""HOSTED"",
                            ""customData"": {
                              ""key1"": ""value1"",
                              ""key2"": ""value2""
                            }
                          }
                        ],
                        ""status"": ""SUCCESSFUL""
                      }
                    ]
                  },
                  ""errorCode"": {
                    ""id"": 10000,
                    ""name"": ""NORMAL_HANGUP"",
                    ""description"": ""The call has ended with hangup initiated by caller, callee or API""
                  }
                }
              ],
              ""paging"": {
                ""page"": 0,
                ""size"": 1,
                ""totalPages"": 1,
                ""totalResults"": 1
              }
            }";

        SetUpGetRequest(GET_DIALOGS_HISTORY, 200, givenResponse, givenQueryParameters);

        var api = new CallsApi(configuration);

        var expectedResponse = new CallsDialogLogPage(
            new List<CallsDialogLogResponse>
            {
                new(
                    "034e622a-cc7e-456d-8a10-0ba43b11aa5e",
                    platform: new Platform(
                        applicationId: "61c060db2675060027d8c7a6"
                    ),
                    state: CallsDialogState.Established,
                    startTime: DateTimeOffset.Parse("2022-01-01T00:00:00.100+0000"),
                    establishTime: DateTimeOffset.Parse("2022-01-01T00:00:02.100+0000"),
                    endTime: DateTimeOffset.Parse("2022-01-01T00:01:00.100+0000"),
                    parentCallId: "d8d84155-3831-43fb-91c9-bb897149a79d",
                    childCallId: "3ad8805e-d401-424e-9b03-e02a2016a5e2",
                    duration: 60,
                    recording: new CallsDialogRecordingLog(
                        new List<CallsRecordingFile>
                        {
                            new(
                                "b72cde3c-7d9c-4a5c-8e48-5a947244c013",
                                "d8d84155-3831-43fb-91c9-bb897149a79d_41792030001_1652725357412_recording.wav",
                                CallsFileFormat.Wav,
                                67564,
                                DateTimeOffset.Parse("2022-01-01T00:00:00.100+0000"),
                                10,
                                DateTimeOffset.Parse("2021-12-31T23:57:30.100+0000"),
                                DateTimeOffset.Parse("2021-12-31T23:59:20.100+0000"),
                                CallsRecordingFileLocation.Sftp,
                                CallsSftpUploadStatus.Uploaded
                            )
                        },
                        new List<CallRecording>
                        {
                            new(
                                "d8d84155-3831-43fb-91c9-bb897149a79d",
                                new CallsPhoneEndpoint(
                                    "44790123456"
                                ),
                                CallDirection.Inbound,
                                new List<CallsRecordingFile>
                                {
                                    new(
                                        "d8d84155-3831-43fb-91c9-bb897149a79d",
                                        "d8d84155-3831-43fb-91c9-bb897149a79d_1652725357412.wav",
                                        CallsFileFormat.Wav,
                                        67564,
                                        DateTimeOffset.Parse("2022-01-01T00:00:00.250+0000"),
                                        10,
                                        DateTimeOffset.Parse("2021-12-31T23:59:50.100+0000"),
                                        DateTimeOffset.Parse("2022-01-01T00:00:00.100+0000"),
                                        CallsRecordingFileLocation.Hosted,
                                        customData: new Dictionary<string, string>
                                        {
                                            { "key1", "value1" },
                                            { "key2", "value2" }
                                        }
                                    )
                                },
                                CallsRecordingStatus.Successful
                            ),
                            new(
                                "3ad8805e-d401-424e-9b03-e02a2016a5e2",
                                new CallsPhoneEndpoint(
                                    "44790123456"
                                ),
                                CallDirection.Inbound,
                                new List<CallsRecordingFile>
                                {
                                    new(
                                        "d8d84155-3831-43fb-91c9-bb897149a79d",
                                        "d8d84155-3831-43fb-91c9-bb897149a79d_1652725357412.wav",
                                        CallsFileFormat.Wav,
                                        67564,
                                        DateTimeOffset.Parse("2022-01-01T00:00:00.250+0000"),
                                        10,
                                        DateTimeOffset.Parse("2021-12-31T23:59:50.100+0000"),
                                        DateTimeOffset.Parse("2022-01-01T00:00:00.100+0000"),
                                        CallsRecordingFileLocation.Hosted,
                                        customData: new Dictionary<string, string>
                                        {
                                            { "key1", "value1" },
                                            { "key2", "value2" }
                                        }
                                    )
                                },
                                CallsRecordingStatus.Successful
                            )
                        }
                    ),
                    errorCode: new CallsErrorCodeInfo(
                        10000,
                        "NORMAL_HANGUP",
                        "The call has ended with hangup initiated by caller, callee or API"
                    )
                )
            },
            new PageInfo(
                0,
                1,
                1,
                1
            )
        );

        var response = api.GetDialogsHistory(givenCallsConfigurationId, givenApplicationId, givenState,
            givenParentCallId, givenChildCallId, givenStartTimeAfter, givenEndTimeBefore, givenPage, givenSize);

        Assert.AreEqual(expectedResponse, response);
    }

    [TestMethod]
    public void ShouldGetDialogHistory()
    {
        var givenDialogId = "034e622a-cc7e-456d-8a10-0ba43b11aa5e";

        var givenResponse = @"
            {
              ""dialogId"": ""034e622a-cc7e-456d-8a10-0ba43b11aa5e"",
              ""platform"": {
                ""applicationId"": ""61c060db2675060027d8c7a6""
              },
              ""state"": ""ESTABLISHED"",
              ""startTime"": ""2022-01-01T00:00:00.100+0000"",
              ""establishTime"": ""2022-01-01T00:00:02.100+0000"",
              ""endTime"": ""2022-01-01T00:01:00.100+0000"",
              ""parentCallId"": ""d8d84155-3831-43fb-91c9-bb897149a79d"",
              ""childCallId"": ""3ad8805e-d401-424e-9b03-e02a2016a5e2"",
              ""duration"": 60,
              ""recording"": {
                ""composedFiles"": [
                  {
                    ""id"": ""b72cde3c-7d9c-4a5c-8e48-5a947244c013"",
                    ""name"": ""d8d84155-3831-43fb-91c9-bb897149a79d_41792030001_1652725357412_recording.wav"",
                    ""fileFormat"": ""WAV"",
                    ""size"": 67564,
                    ""creationTime"": ""2022-01-01T00:00:00.100+0000"",
                    ""duration"": 10,
                    ""startTime"": ""2021-12-31T23:57:30.100+0000"",
                    ""endTime"": ""2021-12-31T23:59:20.100+0000"",
                    ""location"": ""SFTP"",
                    ""sftpUploadStatus"": ""UPLOADED""
                  }
                ],
                ""callRecordings"": [
                  {
                    ""callId"": ""d8d84155-3831-43fb-91c9-bb897149a79d"",
                    ""endpoint"": {
                      ""type"": ""PHONE"",
                      ""phoneNumber"": ""44790123456""
                    },
                    ""direction"": ""INBOUND"",
                    ""files"": [
                      {
                        ""id"": ""d8d84155-3831-43fb-91c9-bb897149a79d"",
                        ""name"": ""d8d84155-3831-43fb-91c9-bb897149a79d_1652725357412.wav"",
                        ""fileFormat"": ""WAV"",
                        ""size"": 67564,
                        ""creationTime"": ""2022-01-01T00:00:00.250+0000"",
                        ""duration"": 10,
                        ""startTime"": ""2021-12-31T23:59:50.100+0000"",
                        ""endTime"": ""2022-01-01T00:00:00.100+0000"",
                        ""location"": ""HOSTED"",
                        ""customData"": {
                          ""key1"": ""value1"",
                          ""key2"": ""value2""
                        }
                      }
                    ],
                    ""status"": ""SUCCESSFUL""
                  },
                  {
                    ""callId"": ""3ad8805e-d401-424e-9b03-e02a2016a5e2"",
                    ""endpoint"": {
                      ""type"": ""PHONE"",
                      ""phoneNumber"": ""44790123456""
                    },
                    ""direction"": ""INBOUND"",
                    ""files"": [
                      {
                        ""id"": ""d8d84155-3831-43fb-91c9-bb897149a79d"",
                        ""name"": ""d8d84155-3831-43fb-91c9-bb897149a79d_1652725357412.wav"",
                        ""fileFormat"": ""WAV"",
                        ""size"": 67564,
                        ""creationTime"": ""2022-01-01T00:00:00.250+0000"",
                        ""duration"": 10,
                        ""startTime"": ""2021-12-31T23:59:50.100+0000"",
                        ""endTime"": ""2022-01-01T00:00:00.100+0000"",
                        ""location"": ""HOSTED"",
                        ""customData"": {
                          ""key1"": ""value1"",
                          ""key2"": ""value2""
                        }
                      }
                    ],
                    ""status"": ""SUCCESSFUL""
                  }
                ]
              },
              ""errorCode"": {
                ""id"": 10000,
                ""name"": ""NORMAL_HANGUP"",
                ""description"": ""The call has ended with hangup initiated by caller, callee or API""
              }
            }";

        SetUpGetRequest(GET_DIALOG_HISTORY.Replace("{dialogId}", givenDialogId), 200, givenResponse);

        var api = new CallsApi(configuration);

        var expectedResponse = new CallsDialogLogResponse(
            "034e622a-cc7e-456d-8a10-0ba43b11aa5e",
            platform: new Platform(
                applicationId: "61c060db2675060027d8c7a6"
            ),
            state: CallsDialogState.Established,
            startTime: DateTimeOffset.Parse("2022-01-01T00:00:00.100+0000"),
            establishTime: DateTimeOffset.Parse("2022-01-01T00:00:02.100+0000"),
            endTime: DateTimeOffset.Parse("2022-01-01T00:01:00.100+0000"),
            parentCallId: "d8d84155-3831-43fb-91c9-bb897149a79d",
            childCallId: "3ad8805e-d401-424e-9b03-e02a2016a5e2",
            duration: 60,
            recording: new CallsDialogRecordingLog(
                new List<CallsRecordingFile>
                {
                    new(
                        "b72cde3c-7d9c-4a5c-8e48-5a947244c013",
                        "d8d84155-3831-43fb-91c9-bb897149a79d_41792030001_1652725357412_recording.wav",
                        CallsFileFormat.Wav,
                        67564,
                        DateTimeOffset.Parse("2022-01-01T00:00:00.100+0000"),
                        10,
                        DateTimeOffset.Parse("2021-12-31T23:57:30.100+0000"),
                        DateTimeOffset.Parse("2021-12-31T23:59:20.100+0000"),
                        CallsRecordingFileLocation.Sftp,
                        CallsSftpUploadStatus.Uploaded
                    )
                },
                new List<CallRecording>
                {
                    new(
                        "d8d84155-3831-43fb-91c9-bb897149a79d",
                        new CallsPhoneEndpoint(
                            "44790123456"
                        ),
                        CallDirection.Inbound,
                        new List<CallsRecordingFile>
                        {
                            new(
                                "d8d84155-3831-43fb-91c9-bb897149a79d",
                                "d8d84155-3831-43fb-91c9-bb897149a79d_1652725357412.wav",
                                CallsFileFormat.Wav,
                                67564,
                                DateTimeOffset.Parse("2022-01-01T00:00:00.250+0000"),
                                10,
                                DateTimeOffset.Parse("2021-12-31T23:59:50.100+0000"),
                                DateTimeOffset.Parse("2022-01-01T00:00:00.100+0000"),
                                CallsRecordingFileLocation.Hosted,
                                customData: new Dictionary<string, string>
                                {
                                    { "key1", "value1" },
                                    { "key2", "value2" }
                                }
                            )
                        },
                        CallsRecordingStatus.Successful
                    ),
                    new(
                        "3ad8805e-d401-424e-9b03-e02a2016a5e2",
                        new CallsPhoneEndpoint(
                            "44790123456"
                        ),
                        CallDirection.Inbound,
                        new List<CallsRecordingFile>
                        {
                            new(
                                "d8d84155-3831-43fb-91c9-bb897149a79d",
                                "d8d84155-3831-43fb-91c9-bb897149a79d_1652725357412.wav",
                                CallsFileFormat.Wav,
                                67564,
                                DateTimeOffset.Parse("2022-01-01T00:00:00.250+0000"),
                                10,
                                DateTimeOffset.Parse("2021-12-31T23:59:50.100+0000"),
                                DateTimeOffset.Parse("2022-01-01T00:00:00.100+0000"),
                                CallsRecordingFileLocation.Hosted,
                                customData: new Dictionary<string, string>
                                {
                                    { "key1", "value1" },
                                    { "key2", "value2" }
                                }
                            )
                        },
                        CallsRecordingStatus.Successful
                    )
                }
            ),
            errorCode: new CallsErrorCodeInfo(
                10000,
                "NORMAL_HANGUP",
                "The call has ended with hangup initiated by caller, callee or API"
            )
        );

        var response = api.GetDialogHistory(givenDialogId);

        Assert.AreEqual(expectedResponse, response);
    }

    [TestMethod]
    public void ShouldHangupDialog()
    {
        var givenDialogId = "034e622a-cc7e-456d-8a10-0ba43b11aa5e";

        var givenResponse = @"
            {
              ""id"": ""034e622a-cc7e-456d-8a10-0ba43b11aa5e"",
              ""platform"": {
                ""applicationId"": ""61c060db2675060027d8c7a6""
              },
              ""state"": ""ESTABLISHED"",
              ""startTime"": ""2022-01-01T00:00:00.100+0000"",
              ""establishTime"": ""2022-01-01T00:00:02.100+0000"",
              ""endTime"": ""2022-01-01T00:01:00.100+0000"",
              ""parentCall"": {
                ""id"": ""d8d84155-3831-43fb-91c9-bb897149a79d"",
                ""endpoint"": {
                  ""type"": ""PHONE"",
                  ""phoneNumber"": ""44790123456""
                },
                ""direction"": ""INBOUND"",
                ""state"": ""ESTABLISHED"",
                ""media"": {
                  ""audio"": {
                    ""muted"": false,
                    ""deaf"": false
                  },
                  ""video"": {
                    ""camera"": false,
                    ""screenShare"": false
                  }
                },
                ""startTime"": ""2022-01-01T00:00:00.100+0000"",
                ""answerTime"": ""2022-01-01T00:00:02.100+0000"",
                ""endTime"": ""2022-01-01T00:01:00.100+0000"",
                ""ringDuration"": 2,
                ""platform"": {
                  ""applicationId"": ""61c060db2675060027d8c7a6""
                },
                ""dialogId"": ""034e622a-cc7e-456d-8a10-0ba43b11aa5e""
              },
              ""childCall"": {
                ""id"": ""3ad8805e-d401-424e-9b03-e02a2016a5e2"",
                ""endpoint"": {
                  ""type"": ""PHONE"",
                  ""phoneNumber"": ""44790987654""
                },
                ""direction"": ""OUTBOUND"",
                ""state"": ""ESTABLISHED"",
                ""media"": {
                  ""audio"": {
                    ""muted"": false,
                    ""deaf"": false
                  },
                  ""video"": {
                    ""camera"": false,
                    ""screenShare"": false
                  }
                },
                ""startTime"": ""2022-01-01T00:00:00.100+0000"",
                ""answerTime"": ""2022-01-01T00:00:02.100+0000"",
                ""endTime"": ""2022-01-01T00:01:00.100+0000"",
                ""ringDuration"": 2,
                ""platform"": {
                  ""applicationId"": ""61c060db2675060027d8c7a6""
                },
                ""dialogId"": ""034e622a-cc7e-456d-8a10-0ba43b11aa5e""
              }
            }";

        SetUpPostRequest(HANGUP_DIALOG.Replace("{dialogId}", givenDialogId), 200, expectedResponse: givenResponse);

        var api = new CallsApi(configuration);

        var expectedResponse = new CallsDialogResponse(
            "034e622a-cc7e-456d-8a10-0ba43b11aa5e",
            platform: new Platform(
                applicationId: "61c060db2675060027d8c7a6"
            ),
            state: CallsDialogState.Established,
            startTime: DateTimeOffset.Parse("2022-01-01T00:00:00.100+0000"),
            establishTime: DateTimeOffset.Parse("2022-01-01T00:00:02.100+0000"),
            endTime: DateTimeOffset.Parse("2022-01-01T00:01:00.100+0000"),
            parentCall: new Call(
                "d8d84155-3831-43fb-91c9-bb897149a79d",
                new CallsPhoneEndpoint(
                    "44790123456"
                ),
                direction: CallDirection.Inbound,
                state: CallState.Established,
                media: new CallsMediaProperties(
                    new CallsAudioMediaProperties(),
                    new CallsVideoMediaProperties()
                ),
                startTime: DateTimeOffset.Parse("2022-01-01T00:00:00.100+0000"),
                answerTime: DateTimeOffset.Parse("2022-01-01T00:00:02.100+0000"),
                endTime: DateTimeOffset.Parse("2022-01-01T00:01:00.100+0000"),
                ringDuration: 2,
                platform: new Platform(
                    applicationId: "61c060db2675060027d8c7a6"
                ),
                dialogId: "034e622a-cc7e-456d-8a10-0ba43b11aa5e"
            ),
            childCall: new Call(
                "3ad8805e-d401-424e-9b03-e02a2016a5e2",
                new CallsPhoneEndpoint(
                    "44790987654"
                ),
                direction: CallDirection.Outbound,
                state: CallState.Established,
                media: new CallsMediaProperties(
                    new CallsAudioMediaProperties(),
                    new CallsVideoMediaProperties()
                ),
                startTime: DateTimeOffset.Parse("2022-01-01T00:00:00.100+0000"),
                answerTime: DateTimeOffset.Parse("2022-01-01T00:00:02.100+0000"),
                endTime: DateTimeOffset.Parse("2022-01-01T00:01:00.100+0000"),
                ringDuration: 2,
                platform: new Platform(
                    applicationId: "61c060db2675060027d8c7a6"
                ),
                dialogId: "034e622a-cc7e-456d-8a10-0ba43b11aa5e"
            )
        );

        var response = api.HangupDialog(givenDialogId);

        Assert.AreEqual(expectedResponse, response);
    }

    [TestMethod]
    public void ShouldDialogsPlayFile()
    {
        var givenDialogId = "034e622a-cc7e-456d-8a10-0ba43b11aa5e";

        var givenRequest = @"
            {
              ""loopCount"": 3,
              ""content"": {
                ""fileUrl"": ""https://www.example.com/file.wav"",
                ""type"": ""URL""
              }
            }";

        var givenResponse = @"
            {
              ""status"": ""PENDING""
            }";

        SetUpPostRequest(DIALOG_PLAY_FILE.Replace("{dialogId}", givenDialogId), 200, givenRequest, givenResponse);

        var api = new CallsApi(configuration);

        var request = new CallsDialogPlayRequest(
            3,
            new CallsUrlPlayContent(
                "https://www.example.com/file.wav"
            )
        );

        var expectedResponse = new CallsActionResponse(
            CallsActionStatus.Pending
        );

        var response = api.DialogPlayFile(givenDialogId, request);

        Assert.AreEqual(expectedResponse, response);
    }

    [TestMethod]
    public void ShouldDialogsSayText()
    {
        var givenDialogId = "034e622a-cc7e-456d-8a10-0ba43b11aa5e";

        var givenRequest = @"
            {
              ""text"": ""Hello world"",
              ""language"": ""en"",
              ""speechRate"": 1.2,
              ""loopCount"": 3,
              ""preferences"": {
                ""voiceGender"": ""FEMALE"",
                ""voiceName"": ""Joanna""
              }
            }";

        var givenResponse = @"
            {
              ""status"": ""PENDING""
            }";

        SetUpPostRequest(DIALOG_SAY_TEXT.Replace("{dialogId}", givenDialogId), 200, givenRequest, givenResponse);

        var api = new CallsApi(configuration);

        var request = new CallsDialogSayRequest(
            "Hello world",
            CallsLanguage.En,
            1.2,
            3,
            new CallsVoicePreferences(
                CallsGender.Female,
                CallVoice.Joanna
            )
        );

        var expectedResponse = new CallsActionResponse(
            CallsActionStatus.Pending
        );

        var response = api.DialogSayText(givenDialogId, request);

        Assert.AreEqual(expectedResponse, response);
    }

    [TestMethod]
    public void ShouldDialogsStopPlayingFile()
    {
        var givenDialogId = "034e622a-cc7e-456d-8a10-0ba43b11aa5e";

        var givenResponse = @"
            {
              ""status"": ""PENDING""
            }";

        SetUpPostRequest(DIALOG_STOP_PLAYING_FILE.Replace("{dialogId}", givenDialogId), 200,
            expectedResponse: givenResponse);

        var api = new CallsApi(configuration);

        var expectedResponse = new CallsActionResponse(
            CallsActionStatus.Pending
        );

        var response = api.DialogStopPlayingFile(givenDialogId);

        Assert.AreEqual(expectedResponse, response);
    }

    [TestMethod]
    public void ShouldDialogsStartRecording()
    {
        var givenDialogId = "034e622a-cc7e-456d-8a10-0ba43b11aa5e";

        var givenRequest = @"
            {
              ""recordingType"": ""AUDIO_AND_VIDEO"",
              ""dialogComposition"": {
                ""enabled"": true
              },
              ""customData"": {
                ""key1"": ""value1"",
                ""key2"": ""value2""
              },
              ""filePrefix"": ""customFilename""
            }";

        var givenResponse = @"
            {
              ""status"": ""PENDING""
            }";

        SetUpPostRequest(DIALOG_START_RECORDING.Replace("{dialogId}", givenDialogId), 200, givenRequest, givenResponse);

        var api = new CallsApi(configuration);

        var request = new CallsDialogRecordingRequest(
            CallsRecordingType.AudioAndVideo,
            new CallsDialogRecordingComposition(
                true
            ),
            new Dictionary<string, string>
            {
                { "key1", "value1" },
                { "key2", "value2" }
            },
            "customFilename"
        );

        var expectedResponse = new CallsActionResponse(
            CallsActionStatus.Pending
        );

        var response = api.DialogStartRecording(givenDialogId, request);

        Assert.AreEqual(expectedResponse, response);
    }

    [TestMethod]
    public void ShouldDialogsStopRecording()
    {
        var givenDialogId = "034e622a-cc7e-456d-8a10-0ba43b11aa5e";

        var givenResponse = @"
            {
              ""status"": ""PENDING""
            }";

        SetUpPostRequest(DIALOG_STOP_RECORDING.Replace("{dialogId}", givenDialogId), 200,
            expectedResponse: givenResponse);

        var api = new CallsApi(configuration);

        var expectedResponse = new CallsActionResponse(
            CallsActionStatus.Pending
        );

        var response = api.DialogStopRecording(givenDialogId);

        Assert.AreEqual(expectedResponse, response);
    }

    [TestMethod]
    public void ShouldDialogsBroadcastText()
    {
        var givenDialogId = "034e622a-cc7e-456d-8a10-0ba43b11aa5e";

        var givenRequest = @"
            {
              ""text"": ""This dialog will end in 5 minutes.""
            }";

        var givenResponse = @"
            {
              ""status"": ""PENDING""
            }";

        SetUpPostRequest(DIALOG_BROADCAST_WEBRTC_TEXT.Replace("{dialogId}", givenDialogId), 200, givenRequest,
            givenResponse);

        var api = new CallsApi(configuration);

        var request = new CallsDialogBroadcastWebrtcTextRequest(
            "This dialog will end in 5 minutes."
        );

        var expectedResponse = new CallsActionResponse(
            CallsActionStatus.Pending
        );

        var response = api.DialogBroadcastWebrtcText(givenDialogId, request);

        Assert.AreEqual(expectedResponse, response);
    }

    [TestMethod]
    public void ShouldGetSipTrunks()
    {
        var givenName = "My SIP trunk";
        var givenPage = 0;
        var givenSize = 20;
        var givenQueryParameters = new Dictionary<string, string>
        {
            { "name", givenName },
            { "page", givenPage.ToString() },
            { "size", givenSize.ToString() }
        };

        var givenResponse = @"
            {
              ""results"": [
                {
                  ""id"": ""a8cbf843-12b9-4ad6-be1e-d186fe63963d"",
                  ""type"": ""STATIC"",
                  ""name"": ""Static SIP Trunk"",
                  ""location"": ""NEW_YORK"",
                  ""tls"": false,
                  ""codecs"": [
                    ""PCMU"",
                    ""PCMA""
                  ],
                  ""dtmf"": ""INBAND"",
                  ""fax"": ""T38"",
                  ""numberFormat"": ""US_NATIONAL"",
                  ""internationalCallsAllowed"": false,
                  ""channelLimit"": 10,
                  ""anonymization"": ""REMOTE_PARTY_ID"",
                  ""billingPackage"": {
                    ""packageType"": ""UNLIMITED"",
                    ""countryCode"": ""USA"",
                    ""addressId"": ""562949953421333""
                  },
                  ""sbcHosts"": {
                    ""primary"": [
                      ""111.111.111.111:5060""
                    ],
                    ""backup"": [
                      ""222.222.222.222:5060""
                    ]
                  },
                  ""sipOptions"": {
                    ""enabled"": false
                  },
                  ""sourceHosts"": [
                    ""10.10.10.10""
                  ],
                  ""destinationHosts"": [
                    ""100.100.100.100:5060"",
                    ""my.destination.com"",
                    ""my.destination.com:5060""
                  ],
                  ""strategy"": ""ROUND_ROBIN""
                },
                {
                  ""id"": ""a8cbf843-12b9-4ad6-be1e-d186fe63963d"",
                  ""type"": ""REGISTERED"",
                  ""name"": ""Registered SIP Trunk"",
                  ""location"": ""SAO_PAULO"",
                  ""tls"": true,
                  ""codecs"": [
                    ""G729""
                  ],
                  ""dtmf"": ""RFC2833"",
                  ""fax"": ""NONE"",
                  ""numberFormat"": ""E164"",
                  ""internationalCallsAllowed"": true,
                  ""channelLimit"": 999,
                  ""anonymization"": ""PREFERRED_IDENTITY"",
                  ""billingPackage"": {
                    ""packageType"": ""METERED""
                  },
                  ""sbcHosts"": {
                    ""primary"": [
                      ""111.111.111.111:5061""
                    ],
                    ""backup"": [
                      ""222.222.222.222:5061""
                    ]
                  },
                  ""username"": ""426c8402-691c-11ee-8c99-0242ac120002"",
                  ""inviteAuthentication"": true
                }
              ],
              ""paging"": {
                ""page"": 0,
                ""size"": 2,
                ""totalPages"": 1,
                ""totalResults"": 2
              }
            }";

        SetUpGetRequest(GET_SIP_TRUNKS, 200, givenResponse, givenQueryParameters);

        var api = new CallsApi(configuration);

        var expectedResponse = new CallsSipTrunkPage(
            new List<CallsSipTrunkResponse>
            {
                new CallsStaticSipTrunkResponse(
                    id: "a8cbf843-12b9-4ad6-be1e-d186fe63963d",
                    name: "Static SIP Trunk",
                    location: "NEW_YORK",
                    tls: false,
                    codecs: new List<CallsAudioCodec>
                    {
                        CallsAudioCodec.Pcmu,
                        CallsAudioCodec.Pcma
                    },
                    dtmf: CallsDtmfType.Inband,
                    fax: CallsFaxType.T38,
                    numberFormat: CallsNumberPresentationFormat.UsNational,
                    internationalCallsAllowed: false,
                    channelLimit: 10,
                    anonymization: CallsAnonymizationType.RemotePartyId,
                    billingPackage: new CallsBillingPackage(
                        CallsBillingPackageType.Unlimited,
                        "USA",
                        "562949953421333"
                    ),
                    sbcHosts: new CallsSbcHosts(
                        new List<string>
                        {
                            "111.111.111.111:5060"
                        },
                        new List<string>
                        {
                            "222.222.222.222:5060"
                        }
                    ),
                    sipOptions: new CallsSipOptions(),
                    sourceHosts: new List<string>
                    {
                        "10.10.10.10"
                    },
                    destinationHosts: new List<string>
                    {
                        "100.100.100.100:5060",
                        "my.destination.com",
                        "my.destination.com:5060"
                    },
                    strategy: CallsSelectionStrategy.RoundRobin
                ),
                new CallsRegisteredSipTrunkResponse(
                    id: "a8cbf843-12b9-4ad6-be1e-d186fe63963d",
                    name: "Registered SIP Trunk",
                    location: "SAO_PAULO",
                    tls: true,
                    codecs: new List<CallsAudioCodec>
                    {
                        CallsAudioCodec.G729
                    },
                    dtmf: CallsDtmfType.RFC2833,
                    fax: CallsFaxType.None,
                    numberFormat: CallsNumberPresentationFormat.E164,
                    internationalCallsAllowed: true,
                    channelLimit: 999,
                    anonymization: CallsAnonymizationType.PreferredIdentity,
                    billingPackage: new CallsBillingPackage(
                        CallsBillingPackageType.Metered
                    ),
                    sbcHosts: new CallsSbcHosts(
                        new List<string>
                        {
                            "111.111.111.111:5061"
                        },
                        new List<string>
                        {
                            "222.222.222.222:5061"
                        }
                    ),
                    username: "426c8402-691c-11ee-8c99-0242ac120002",
                    inviteAuthentication: true
                )
            },
            new PageInfo(
                0,
                2,
                1,
                2
            )
        );

        var response = api.GetSipTrunks(givenName, givenPage, givenSize);

        Assert.AreEqual(expectedResponse, response);
    }

    [TestMethod]
    public void ShouldCreateSipTrunk()
    {
        var givenRequest = @"
            {
              ""type"": ""STATIC"",
              ""name"": ""Static SIP trunk"",
              ""location"": ""NEW_YORK"",
              ""tls"": false,
              ""internationalCallsAllowed"": false,
              ""channelLimit"": 10,
              ""billingPackage"": {
                ""packageType"": ""UNLIMITED"",
                ""countryCode"": ""USA"",
                ""addressId"": ""562949953421333""
              },
              ""codecs"": [
                ""PCMU"",
                ""PCMA""
              ],
              ""dtmf"": ""INBAND"",
              ""fax"": ""T38"",
              ""numberFormat"": ""US_NATIONAL"",
              ""anonymization"": ""REMOTE_PARTY_ID"",
              ""sourceHosts"": [
                ""10.10.10.10""
              ],
              ""destinationHosts"": [
                ""100.100.100.101:5060"",
                ""my.destination.com"",
                ""my.destination.com:5060""
              ],
              ""strategy"": ""ROUND_ROBIN"",
              ""sipOptions"": {
                ""enabled"": false
              }
            }";

        var givenResponse = @"
            {
              ""id"": ""a8cbf843-12b9-4ad6-be1e-d186fe63963d"",
              ""type"": ""STATIC"",
              ""name"": ""Static SIP Trunk"",
              ""location"": ""NEW_YORK"",
              ""internationalCallsAllowed"": false,
              ""channelLimit"": 10,
              ""billingPackage"": {
                ""packageType"": ""UNLIMITED"",
                ""countryCode"": ""USA"",
                ""addressId"": ""562949953421333""
              },
              ""sbcHosts"": {
                ""primary"": [
                  ""111.111.111.111:5060""
                ],
                ""backup"": [
                  ""222.222.222.222:5060""
                ]
              },
              ""tls"": false,
              ""codecs"": [
                ""PCMU"",
                ""PCMA""
              ],
              ""dtmf"": ""INBAND"",
              ""fax"": ""T38"",
              ""numberFormat"": ""US_NATIONAL"",
              ""anonymization"": ""REMOTE_PARTY_ID"",
              ""sourceHosts"": [
                ""10.10.10.10""
              ],
              ""destinationHosts"": [
                ""100.100.100.100:5060"",
                ""my.destination.com"",
                ""my.destination.com:5060""
              ],
              ""strategy"": ""ROUND_ROBIN"",
              ""sipOptions"": {
                ""enabled"": false
              }
            }";

        SetUpPostRequest(CREATE_SIP_TRUNK, 202, givenRequest, givenResponse);

        var api = new CallsApi(configuration);

        var request = new CallsStaticSipTrunkRequest(
            name: "Static SIP trunk",
            location: "NEW_YORK",
            tls: false,
            internationalCallsAllowed: false,
            channelLimit: 10,
            billingPackage: new CallsBillingPackage(
                CallsBillingPackageType.Unlimited,
                "USA",
                "562949953421333"
            ),
            codecs: new List<CallsAudioCodec>
            {
                CallsAudioCodec.Pcmu,
                CallsAudioCodec.Pcma
            },
            dtmf: CallsDtmfType.Inband,
            fax: CallsFaxType.T38,
            numberFormat: CallsNumberPresentationFormat.UsNational,
            anonymization: CallsAnonymizationType.RemotePartyId,
            sourceHosts: new List<string>
            {
                "10.10.10.10"
            },
            destinationHosts: new List<string>
            {
                "100.100.100.101:5060",
                "my.destination.com",
                "my.destination.com:5060"
            },
            strategy: CallsSelectionStrategy.RoundRobin,
            sipOptions: new CallsSipOptions()
        );

        var expectedResponse = new CallsCreateStaticSipTrunkResponse(
            id: "a8cbf843-12b9-4ad6-be1e-d186fe63963d",
            name: "Static SIP Trunk",
            location: "NEW_YORK",
            internationalCallsAllowed: false,
            channelLimit: 10,
            billingPackage: new CallsBillingPackage(
                CallsBillingPackageType.Unlimited,
                "USA",
                "562949953421333"
            ),
            sbcHosts: new CallsSbcHosts(
                new List<string>
                {
                    "111.111.111.111:5060"
                },
                new List<string>
                {
                    "222.222.222.222:5060"
                }
            ),
            tls: false,
            codecs: new List<CallsAudioCodec>
            {
                CallsAudioCodec.Pcmu,
                CallsAudioCodec.Pcma
            },
            dtmf: CallsDtmfType.Inband,
            fax: CallsFaxType.T38,
            numberFormat: CallsNumberPresentationFormat.UsNational,
            anonymization: CallsAnonymizationType.RemotePartyId,
            sourceHosts: new List<string>
            {
                "10.10.10.10"
            },
            destinationHosts: new List<string>
            {
                "100.100.100.100:5060",
                "my.destination.com",
                "my.destination.com:5060"
            },
            strategy: CallsSelectionStrategy.RoundRobin,
            sipOptions: new CallsSipOptions()
        );

        var response = api.CreateSipTrunk(request);

        Assert.AreEqual(expectedResponse, response);
    }

    [TestMethod]
    public void ShouldGetSipTrunk()
    {
        var givenSipTrunkId = "a8cbf843-12b9-4ad6-be1e-d186fe63963d";

        var givenResponse = @"
            {
              ""id"": ""a8cbf843-12b9-4ad6-be1e-d186fe63963d"",
              ""type"": ""STATIC"",
              ""name"": ""Static SIP Trunk"",
              ""location"": ""NEW_YORK"",
              ""tls"": false,
              ""codecs"": [
                ""PCMU"",
                ""PCMA""
              ],
              ""dtmf"": ""INBAND"",
              ""fax"": ""T38"",
              ""numberFormat"": ""US_NATIONAL"",
              ""internationalCallsAllowed"": false,
              ""channelLimit"": 10,
              ""anonymization"": ""REMOTE_PARTY_ID"",
              ""billingPackage"": {
                ""packageType"": ""UNLIMITED"",
                ""countryCode"": ""USA"",
                ""addressId"": ""562949953421333""
              },
              ""sbcHosts"": {
                ""primary"": [
                  ""111.111.111.111:5060""
                ],
                ""backup"": [
                  ""222.222.222.222:5060""
                ]
              },
              ""sipOptions"": {
                ""enabled"": false
              },
              ""sourceHosts"": [
                ""10.10.10.10""
              ],
              ""destinationHosts"": [
                ""100.100.100.100:5060"",
                ""my.destination.com"",
                ""my.destination.com:5060""
              ],
              ""strategy"": ""ROUND_ROBIN""
            }";

        SetUpGetRequest(GET_SIP_TRUNK.Replace("{sipTrunkId}", givenSipTrunkId), 200, givenResponse);

        var api = new CallsApi(configuration);

        var expectedResponse = new CallsStaticSipTrunkResponse(
            id: "a8cbf843-12b9-4ad6-be1e-d186fe63963d",
            name: "Static SIP Trunk",
            location: "NEW_YORK",
            tls: false,
            codecs: new List<CallsAudioCodec>
            {
                CallsAudioCodec.Pcmu,
                CallsAudioCodec.Pcma
            },
            dtmf: CallsDtmfType.Inband,
            fax: CallsFaxType.T38,
            numberFormat: CallsNumberPresentationFormat.UsNational,
            internationalCallsAllowed: false,
            channelLimit: 10,
            anonymization: CallsAnonymizationType.RemotePartyId,
            billingPackage: new CallsBillingPackage(
                CallsBillingPackageType.Unlimited,
                "USA",
                "562949953421333"
            ),
            sbcHosts: new CallsSbcHosts(
                new List<string>
                {
                    "111.111.111.111:5060"
                },
                new List<string>
                {
                    "222.222.222.222:5060"
                }
            ),
            sipOptions: new CallsSipOptions(),
            sourceHosts: new List<string>
            {
                "10.10.10.10"
            },
            destinationHosts: new List<string>
            {
                "100.100.100.100:5060",
                "my.destination.com",
                "my.destination.com:5060"
            },
            strategy: CallsSelectionStrategy.RoundRobin
        );

        var response = api.GetSipTrunk(givenSipTrunkId);

        Assert.AreEqual(expectedResponse, response);
    }

    [TestMethod]
    public void ShouldUpdateSipTrunk()
    {
        var givenSipTrunkId = "a8cbf843-12b9-4ad6-be1e-d186fe63963d";

        var givenRequest = @"
            {
              ""type"": ""STATIC"",
              ""name"": ""Static SIP trunk"",
              ""internationalCallsAllowed"": false,
              ""channelLimit"": 10,
              ""sourceHosts"": [
                ""10.10.10.10""
              ],
              ""destinationHosts"": [
                ""100.100.100.101:5060"",
                ""my.destination.com"",
                ""my.destination.com:5060""
              ],
              ""codecs"": [
                ""PCMA"",
                ""PCMU""
              ],
              ""dtmf"": ""INBAND"",
              ""fax"": ""T38"",
              ""anonymization"": ""REMOTE_PARTY_ID"",
              ""numberFormat"": ""US_NATIONAL"",
              ""sipOptions"": {
                ""enabled"": false
              }
            }";

        var givenResponse = @"
            {
              ""id"": ""a8cbf843-12b9-4ad6-be1e-d186fe63963d"",
              ""type"": ""STATIC"",
              ""name"": ""Static SIP Trunk"",
              ""location"": ""NEW_YORK"",
              ""tls"": false,
              ""codecs"": [
                ""PCMU"",
                ""PCMA""
              ],
              ""dtmf"": ""INBAND"",
              ""fax"": ""T38"",
              ""numberFormat"": ""US_NATIONAL"",
              ""internationalCallsAllowed"": false,
              ""channelLimit"": 10,
              ""anonymization"": ""REMOTE_PARTY_ID"",
              ""billingPackage"": {
                ""packageType"": ""UNLIMITED"",
                ""countryCode"": ""USA"",
                ""addressId"": ""562949953421333""
              },
              ""sbcHosts"": {
                ""primary"": [
                  ""111.111.111.111:5060""
                ],
                ""backup"": [
                  ""222.222.222.222:5060""
                ]
              },
              ""sipOptions"": {
                ""enabled"": false
              },
              ""sourceHosts"": [
                ""10.10.10.10""
              ],
              ""destinationHosts"": [
                ""100.100.100.100:5060"",
                ""my.destination.com"",
                ""my.destination.com:5060""
              ],
              ""strategy"": ""ROUND_ROBIN""
            }";

        SetUpPutRequest(UPDATE_SIP_TRUNK.Replace("{sipTrunkId}", givenSipTrunkId), 202, givenRequest, givenResponse);

        var api = new CallsApi(configuration);

        var request = new CallsStaticSipTrunkUpdateRequest(
            name: "Static SIP trunk",
            internationalCallsAllowed: false,
            channelLimit: 10,
            sourceHosts: new List<string>
            {
                "10.10.10.10"
            },
            destinationHosts: new List<string>
            {
                "100.100.100.101:5060",
                "my.destination.com",
                "my.destination.com:5060"
            },
            codecs: new List<CallsAudioCodec>
            {
                CallsAudioCodec.Pcma,
                CallsAudioCodec.Pcmu
            },
            dtmf: CallsDtmfType.Inband,
            fax: CallsFaxType.T38,
            anonymization: CallsAnonymizationType.RemotePartyId,
            numberFormat: CallsNumberPresentationFormat.UsNational,
            sipOptions: new CallsSipOptions()
        );

        var expectedResponse = new CallsStaticSipTrunkResponse(
            id: "a8cbf843-12b9-4ad6-be1e-d186fe63963d",
            name: "Static SIP Trunk",
            location: "NEW_YORK",
            tls: false,
            codecs: new List<CallsAudioCodec>
            {
                CallsAudioCodec.Pcmu,
                CallsAudioCodec.Pcma
            },
            dtmf: CallsDtmfType.Inband,
            fax: CallsFaxType.T38,
            numberFormat: CallsNumberPresentationFormat.UsNational,
            internationalCallsAllowed: false,
            channelLimit: 10,
            anonymization: CallsAnonymizationType.RemotePartyId,
            billingPackage: new CallsBillingPackage(
                CallsBillingPackageType.Unlimited,
                "USA",
                "562949953421333"
            ),
            sbcHosts: new CallsSbcHosts(
                new List<string>
                {
                    "111.111.111.111:5060"
                },
                new List<string>
                {
                    "222.222.222.222:5060"
                }
            ),
            sipOptions: new CallsSipOptions(),
            sourceHosts: new List<string>
            {
                "10.10.10.10"
            },
            destinationHosts: new List<string>
            {
                "100.100.100.100:5060",
                "my.destination.com",
                "my.destination.com:5060"
            },
            strategy: CallsSelectionStrategy.RoundRobin
        );

        var response = api.UpdateSipTrunk(givenSipTrunkId, request);

        Assert.AreEqual(expectedResponse, response);
    }

    [TestMethod]
    public void ShouldDeleteSipTrunk()
    {
        var givenSipTrunkId = "a8cbf843-12b9-4ad6-be1e-d186fe63963d";

        var givenResponse = @"
            {
              ""id"": ""a8cbf843-12b9-4ad6-be1e-d186fe63963d"",
              ""type"": ""STATIC"",
              ""name"": ""Static SIP Trunk"",
              ""location"": ""NEW_YORK"",
              ""tls"": false,
              ""codecs"": [
                ""PCMU"",
                ""PCMA""
              ],
              ""dtmf"": ""INBAND"",
              ""fax"": ""T38"",
              ""numberFormat"": ""US_NATIONAL"",
              ""internationalCallsAllowed"": false,
              ""channelLimit"": 10,
              ""anonymization"": ""REMOTE_PARTY_ID"",
              ""billingPackage"": {
                ""packageType"": ""UNLIMITED"",
                ""countryCode"": ""USA"",
                ""addressId"": ""562949953421333""
              },
              ""sbcHosts"": {
                ""primary"": [
                  ""111.111.111.111:5060""
                ],
                ""backup"": [
                  ""222.222.222.222:5060""
                ]
              },
              ""sipOptions"": {
                ""enabled"": false
              },
              ""sourceHosts"": [
                ""10.10.10.10""
              ],
              ""destinationHosts"": [
                ""100.100.100.100:5060"",
                ""my.destination.com"",
                ""my.destination.com:5060""
              ],
              ""strategy"": ""ROUND_ROBIN""
            }";

        SetUpDeleteRequest(DELETE_SIP_TRUNK.Replace("{sipTrunkId}", givenSipTrunkId), 202,
            expectedResponse: givenResponse);

        var api = new CallsApi(configuration);

        var expectedResponse = new CallsStaticSipTrunkResponse(
            id: "a8cbf843-12b9-4ad6-be1e-d186fe63963d",
            name: "Static SIP Trunk",
            location: "NEW_YORK",
            tls: false,
            codecs: new List<CallsAudioCodec>
            {
                CallsAudioCodec.Pcmu,
                CallsAudioCodec.Pcma
            },
            dtmf: CallsDtmfType.Inband,
            fax: CallsFaxType.T38,
            numberFormat: CallsNumberPresentationFormat.UsNational,
            internationalCallsAllowed: false,
            channelLimit: 10,
            anonymization: CallsAnonymizationType.RemotePartyId,
            billingPackage: new CallsBillingPackage(
                CallsBillingPackageType.Unlimited,
                "USA",
                "562949953421333"
            ),
            sbcHosts: new CallsSbcHosts(
                new List<string>
                {
                    "111.111.111.111:5060"
                },
                new List<string>
                {
                    "222.222.222.222:5060"
                }
            ),
            sipOptions: new CallsSipOptions(),
            sourceHosts: new List<string>
            {
                "10.10.10.10"
            },
            destinationHosts: new List<string>
            {
                "100.100.100.100:5060",
                "my.destination.com",
                "my.destination.com:5060"
            },
            strategy: CallsSelectionStrategy.RoundRobin
        );

        var response = api.DeleteSipTrunk(givenSipTrunkId);

        Assert.AreEqual(expectedResponse, response);
    }

    [TestMethod]
    public void ShouldResetRegisteredSipTrunkPassword()
    {
        var givenSipTrunkId = "a8cbf843-12b9-4ad6-be1e-d186fe63963d";

        var givenResponse = @"
            {
              ""username"": ""426c8402-691c-11ee-8c99-0242ac120002"",
              ""password"": ""fkZ1921tM87""
            }";

        SetUpPostRequest(RESET_SIP_TRUNK_PASSWORD.Replace("{sipTrunkId}", givenSipTrunkId), 200,
            expectedResponse: givenResponse);

        var api = new CallsApi(configuration);

        var expectedResponse = new CallsSipTrunkRegistrationCredentials(
            "426c8402-691c-11ee-8c99-0242ac120002",
            "fkZ1921tM87"
        );

        var response = api.ResetSipTrunkPassword(givenSipTrunkId);

        Assert.AreEqual(expectedResponse, response);
    }

    [TestMethod]
    public void ShouldGetSipTrunkStatus()
    {
        var givenSipTrunkId = "a8cbf843-12b9-4ad6-be1e-d186fe63963d";

        var givenResponse = @"
            {
              ""adminStatus"": ""DISABLED"",
              ""actionStatus"": {
                ""status"": ""RESET"",
                ""reason"": ""Not enough credits.""
              },
              ""registrationStatus"": ""UNREGISTERED"",
              ""activeCalls"": 0
            }";

        SetUpGetRequest(GET_SIP_TRUNK_STATUS.Replace("{sipTrunkId}", givenSipTrunkId), 200, givenResponse);

        var api = new CallsApi(configuration);

        var expectedResponse = new CallsExtendedSipTrunkStatusResponse(
            CallsSipTrunkAdminStatus.Disabled,
            new CallsSipTrunkActionStatusResponse(
                CallsSipTrunkActionStatus.Reset,
                "Not enough credits."
            ),
            CallsSipTrunkRegistrationStatus.Unregistered
        );

        var response = api.GetSipTrunkStatus(givenSipTrunkId);

        Assert.AreEqual(expectedResponse, response);
    }

    [TestMethod]
    public void ShouldSetSipTrunkStatus()
    {
        var givenSipTrunkId = "a8cbf843-12b9-4ad6-be1e-d186fe63963d";

        var givenRequest = @"
            {
              ""adminStatus"": ""ENABLED""
            }";

        var givenResponse = @"
            {
              ""adminStatus"": ""ENABLED""
            }";

        SetUpPostRequest(SET_SIP_TRUNK_STATUS.Replace("{sipTrunkId}", givenSipTrunkId), 200, givenRequest,
            givenResponse);

        var api = new CallsApi(configuration);

        var request = new CallsSipTrunkStatusRequest(
            CallsSipTrunkAdminStatus.Enabled
        );

        var expectedResponse = new CallsSipTrunkStatusResponse(
            CallsSipTrunkAdminStatus.Enabled
        );

        var response = api.SetSipTrunkStatus(givenSipTrunkId, request);

        Assert.AreEqual(expectedResponse, response);
    }

    [TestMethod]
    public void ShouldGetSipTrunkServiceAddresses()
    {
        var givenPage = 0;
        var givenSize = 20;
        var givenQueryParameters = new Dictionary<string, string>
        {
            { "page", givenPage.ToString() },
            { "size", givenSize.ToString() }
        };

        var givenResponse = @"
            {
              ""results"": [
                {
                  ""id"": ""abc-def-ghi"",
                  ""name"": ""Location address name"",
                  ""street"": ""Location address street"",
                  ""city"": ""My city"",
                  ""postCode"": ""71000"",
                  ""suite"": ""1030"",
                  ""country"": {
                    ""name"": ""Croatia"",
                    ""code"": ""HRV""
                  },
                  ""region"": {
                    ""name"": ""Zagreb County"",
                    ""code"": ""HR-01""
                  },
                  ""connectedSipTrunks"": [
                    {
                      ""sipTrunkId"": ""123e4567-e89b-12d3-a456-426614174000"",
                      ""sipTrunkName"": ""Example SIP Trunk""
                    }
                  ]
                }
              ],
              ""paging"": {
                ""page"": 0,
                ""size"": 20,
                ""totalPages"": 1,
                ""totalResults"": 1
              }
            }";

        SetUpGetRequest(GET_SIP_TRUNK_SERVICE_ADDRESSES, 200, givenResponse, givenQueryParameters);

        var api = new CallsApi(configuration);

        var expectedResponse = new CallsSipTrunkServiceAddressPage(
            new List<CallsPublicSipTrunkServiceAddress>
            {
                new(
                    "abc-def-ghi",
                    "Location address name",
                    "Location address street",
                    "My city",
                    "71000",
                    "1030",
                    new CallsPublicCountry(
                        "Croatia",
                        "HRV"
                    ),
                    new CallsPublicRegion(
                        "Zagreb County",
                        "HR-01"
                    )
                )
            },
            new PageInfo(
                0,
                20,
                1,
                1
            )
        );

        var response = api.GetSipTrunkServiceAddresses(givenPage, givenSize);

        Assert.AreEqual(expectedResponse, response);
    }

    [TestMethod]
    public void ShouldCreateSipTrunkServiceAddresses()
    {
        var givenRequest = @"
            {
              ""name"": ""Location address name"",
              ""street"": ""Location address street"",
              ""city"": ""My city"",
              ""postCode"": ""71000"",
              ""suite"": ""1030"",
              ""countryCode"": ""HRV"",
              ""countryRegionCode"": ""HR-01""
            }";

        var givenResponse = @"
            {
              ""id"": ""abc-def-ghi"",
              ""name"": ""Location address name"",
              ""street"": ""Location address street"",
              ""city"": ""My city"",
              ""postCode"": ""71000"",
              ""suite"": ""1030"",
              ""country"": {
                ""name"": ""Croatia"",
                ""code"": ""HRV""
              },
              ""region"": {
                ""name"": ""Zagreb County"",
                ""code"": ""HR-01""
              }
            }";

        SetUpPostRequest(CREATE_SIP_TRUNK_SERVICE_ADDRESS, 200, givenRequest, givenResponse);

        var api = new CallsApi(configuration);

        var request = new CallsPublicSipTrunkServiceAddressRequest(
            "Location address name",
            "Location address street",
            "My city",
            "71000",
            "1030",
            "HRV",
            "HR-01"
        );

        var expectedResponse = new CallsPublicSipTrunkServiceAddress(
            "abc-def-ghi",
            "Location address name",
            "Location address street",
            "My city",
            "71000",
            "1030",
            new CallsPublicCountry(
                "Croatia",
                "HRV"
            ),
            new CallsPublicRegion(
                "Zagreb County",
                "HR-01"
            )
        );

        var response = api.CreateSipTrunkServiceAddress(request);

        Assert.AreEqual(expectedResponse, response);
    }

    [TestMethod]
    public void ShouldGetSipTrunkServiceAddress()
    {
        var givenSipTrunkServiceAddressId = "abc-def-ghi";

        var givenResponse = @"
            {
              ""id"": ""abc-def-ghi"",
              ""name"": ""Location address name"",
              ""street"": ""Location address street"",
              ""city"": ""My city"",
              ""postCode"": ""71000"",
              ""suite"": ""1030"",
              ""country"": {
                ""name"": ""Croatia"",
                ""code"": ""HRV""
              },
              ""region"": {
                ""name"": ""Zagreb County"",
                ""code"": ""HR-01""
              }
            }";

        SetUpGetRequest(
            GET_SIP_TRUNK_SERVICE_ADDRESS.Replace("{sipTrunkServiceAddressId}", givenSipTrunkServiceAddressId), 200,
            givenResponse);

        var api = new CallsApi(configuration);

        var expectedResponse = new CallsPublicSipTrunkServiceAddress(
            "abc-def-ghi",
            "Location address name",
            "Location address street",
            "My city",
            "71000",
            "1030",
            new CallsPublicCountry(
                "Croatia",
                "HRV"
            ),
            new CallsPublicRegion(
                "Zagreb County",
                "HR-01"
            )
        );

        var response = api.GetSipTrunkServiceAddress(givenSipTrunkServiceAddressId);

        Assert.AreEqual(expectedResponse, response);
    }

    [TestMethod]
    public void ShouldUpdateSipTrunkServiceAddress()
    {
        var givenSipTrunkServiceAddressId = "abc-def-ghi";

        var givenRequest = @"
            {
              ""name"": ""Location address name"",
              ""street"": ""Location address street"",
              ""city"": ""My city"",
              ""postCode"": ""71000"",
              ""suite"": ""1030"",
              ""countryCode"": ""HRV"",
              ""countryRegionCode"": ""HR-01""
            }";

        var givenResponse = @"
            {
              ""id"": ""abc-def-ghi"",
              ""name"": ""Location address name"",
              ""street"": ""Location address street"",
              ""city"": ""My city"",
              ""postCode"": ""71000"",
              ""suite"": ""1030"",
              ""country"": {
                ""name"": ""Croatia"",
                ""code"": ""HRV""
              },
              ""region"": {
                ""name"": ""Zagreb County"",
                ""code"": ""HR-01""
              }
            }";

        SetUpPutRequest(
            UPDATE_SIP_TRUNK_SERVICE_ADDRESS.Replace("{sipTrunkServiceAddressId}", givenSipTrunkServiceAddressId), 200,
            givenRequest, givenResponse);

        var api = new CallsApi(configuration);

        var request = new CallsPublicSipTrunkServiceAddressRequest(
            "Location address name",
            "Location address street",
            "My city",
            "71000",
            "1030",
            "HRV",
            "HR-01"
        );

        var expectedResponse = new CallsPublicSipTrunkServiceAddress(
            "abc-def-ghi",
            "Location address name",
            "Location address street",
            "My city",
            "71000",
            "1030",
            new CallsPublicCountry(
                "Croatia",
                "HRV"
            ),
            new CallsPublicRegion(
                "Zagreb County",
                "HR-01"
            )
        );

        var response = api.UpdateSipTrunkServiceAddress(givenSipTrunkServiceAddressId, request);

        Assert.AreEqual(expectedResponse, response);
    }

    [TestMethod]
    public void ShouldDeleteSipTrunkServiceAddress()
    {
        var givenSipTrunkServiceAddressId = "abc-def-ghi";

        var givenResponse = @"
            {
              ""id"": ""abc-def-ghi"",
              ""name"": ""Location address name"",
              ""street"": ""Location address street"",
              ""city"": ""My city"",
              ""postCode"": ""71000"",
              ""suite"": ""1030"",
              ""country"": {
                ""name"": ""Croatia"",
                ""code"": ""HRV""
              },
              ""region"": {
                ""name"": ""Zagreb County"",
                ""code"": ""HR-01""
              }
            }";

        SetUpDeleteRequest(
            DELETE_SIP_TRUNK_SERVICE_ADDRESS.Replace("{sipTrunkServiceAddressId}", givenSipTrunkServiceAddressId), 200,
            expectedResponse: givenResponse);

        var api = new CallsApi(configuration);

        var expectedResponse = new CallsPublicSipTrunkServiceAddress(
            "abc-def-ghi",
            "Location address name",
            "Location address street",
            "My city",
            "71000",
            "1030",
            new CallsPublicCountry(
                "Croatia",
                "HRV"
            ),
            new CallsPublicRegion(
                "Zagreb County",
                "HR-01"
            )
        );

        var response = api.DeleteSipTrunkServiceAddress(givenSipTrunkServiceAddressId);

        Assert.AreEqual(expectedResponse, response);
    }

    [TestMethod]
    public void ShouldGetCountries()
    {
        var givenResponse = @"
            [
              {
                ""name"": ""New Zealand"",
                ""code"": ""NZL""
              },
              {
                ""name"": ""Fiji"",
                ""code"": ""FJI""
              },
              {
                ""name"": ""Guadeloupe"",
                ""code"": ""GLP""
              }
            ]";

        SetUpGetRequest(GET_COUNTRIES, 200, givenResponse);

        var api = new CallsApi(configuration);

        var expectedResponse = new List<CallsPublicCountry>
        {
            new(
                "New Zealand",
                "NZL"
            ),
            new(
                "Fiji",
                "FJI"
            ),
            new(
                "Guadeloupe",
                "GLP"
            )
        };

        var response = api.GetCountries();

        CollectionAssert.AreEqual(expectedResponse, response);
    }

    [TestMethod]
    public void ShouldGetRegions()
    {
        var givenCountryCode = "HRV";
        var givenQueryParameters = new Dictionary<string, string>
        {
            { "countryCode", givenCountryCode }
        };

        var givenResponse = @"
            [
              {
                ""name"": ""Dubrovnik-Neretva County"",
                ""code"": ""HR-19"",
                ""countryCode"": ""HRV""
              },
              {
                ""name"": ""Međimurje County"",
                ""code"": ""HR-20"",
                ""countryCode"": ""HRV""
              },
              {
                ""name"": ""City of Zagreb"",
                ""code"": ""HR-21"",
                ""countryCode"": ""HRV""
              }
            ]";

        SetUpGetRequest(GET_REGIONS, 200, givenResponse, givenQueryParameters);

        var api = new CallsApi(configuration);

        var expectedResponse = new List<CallsPublicRegion>
        {
            new(
                "Dubrovnik-Neretva County",
                "HR-19",
                "HRV"
            ),
            new(
                "Međimurje County",
                "HR-20",
                "HRV"
            ),
            new(
                "City of Zagreb",
                "HR-21",
                "HRV"
            )
        };

        var response = api.GetRegions(givenCountryCode);

        CollectionAssert.AreEqual(expectedResponse, response);
    }

    [TestMethod]
    public void ShouldGetFiles()
    {
        var givenPage = 0;
        var givenSize = 20;
        var givenQueryParameters = new Dictionary<string, string>
        {
            { "page", givenPage.ToString() },
            { "size", givenSize.ToString() }
        };

        var givenResponse = @"
            {
              ""results"": [
                {
                  ""id"": ""218eceba-c044-430d-9f26-8f1a7f0g2d03"",
                  ""name"": ""Example file"",
                  ""fileFormat"": ""WAV"",
                  ""size"": 292190,
                  ""creationMethod"": ""RECORDED"",
                  ""creationTime"": ""2025-02-19T14:09:12Z"",
                  ""expirationTime"": ""2025-02-19T14:09:12Z"",
                  ""duration"": 3
                }
              ],
              ""paging"": {
                ""page"": 0,
                ""size"": 1,
                ""totalPages"": 0,
                ""totalResults"": 0
              }
            }";

        SetUpGetRequest(GET_CALLS_FILES, 200, givenResponse, givenQueryParameters);

        var api = new CallsApi(configuration);

        var expectedResponse = new CallsFilePage(
            new List<CallsFile>
            {
                new(
                    "218eceba-c044-430d-9f26-8f1a7f0g2d03",
                    "Example file",
                    CallsFileFormat.Wav,
                    292190,
                    CallsCreationMethod.Recorded,
                    DateTimeOffset.Parse("2025-02-19T14:09:12Z"),
                    DateTimeOffset.Parse("2025-02-19T14:09:12Z"),
                    3
                )
            },
            new PageInfo(
                0,
                1
            )
        );

        var response = api.GetCallsFiles(givenPage, givenSize);

        Assert.AreEqual(expectedResponse, response);
    }

    [TestMethod]
    public void ShouldUploadAudioFile()
    {
        var audioFileContent = "Test file text";
        var memoryStream = new MemoryStream(Encoding.UTF8.GetBytes(audioFileContent));
        var file = new FileParameter(memoryStream);
        var parts = new Multimap<string, string>
        {
            { "file", audioFileContent }
        };

        var givenResponse = @"
            {
              ""id"": ""218eceba-c044-430d-9f26-8f1a7f0g2d03"",
              ""name"": ""Example file"",
              ""fileFormat"": ""WAV"",
              ""size"": 292190,
              ""creationMethod"": ""RECORDED"",
              ""creationTime"": ""2025-02-19T12:17:27Z"",
              ""expirationTime"": ""2025-02-19T12:17:27Z"",
              ""duration"": 3
            }
        ";

        SetUpMultipartFormRequest(UPLOAD_CALLS_AUDIO_FILE, parts, givenResponse);

        var api = new CallsApi(configuration);

        var expectedResponse = new CallsFile(
            "218eceba-c044-430d-9f26-8f1a7f0g2d03",
            "Example file",
            CallsFileFormat.Wav,
            292190,
            CallsCreationMethod.Recorded,
            DateTimeOffset.Parse("2025-02-19T12:17:27Z"),
            DateTimeOffset.Parse("2025-02-19T12:17:27Z"),
            3
        );

        var response = api.UploadCallsAudioFile(file);

        Assert.AreEqual(expectedResponse, response);
    }

    [TestMethod]
    public void ShouldGetFile()
    {
        var givenFileId = "218eceba-c044-430d-9f26-8f1a7f0g2d03";

        var givenResponse = @"
            {
              ""id"": ""218eceba-c044-430d-9f26-8f1a7f0g2d03"",
              ""name"": ""Example file"",
              ""fileFormat"": ""WAV"",
              ""size"": 292190,
              ""creationMethod"": ""RECORDED"",
              ""creationTime"": ""2025-02-19T14:09:14Z"",
              ""expirationTime"": ""2025-02-19T14:09:14Z"",
              ""duration"": 3
            }";

        SetUpGetRequest(GET_CALLS_FILE.Replace("{fileId}", givenFileId), 200, givenResponse);

        var api = new CallsApi(configuration);

        var expectedResponse = new CallsFile(
            "218eceba-c044-430d-9f26-8f1a7f0g2d03",
            "Example file",
            CallsFileFormat.Wav,
            292190,
            CallsCreationMethod.Recorded,
            DateTimeOffset.Parse("2025-02-19T14:09:14Z"),
            DateTimeOffset.Parse("2025-02-19T14:09:14Z"),
            3
        );

        var response = api.GetCallsFile(givenFileId);

        Assert.AreEqual(expectedResponse, response);
    }

    [TestMethod]
    public void ShouldDeleteFile()
    {
        var givenFileId = "218eceba-c044-430d-9f26-8f1a7f0g2d03";

        var givenResponse = @"
            {
              ""id"": ""218eceba-c044-430d-9f26-8f1a7f0g2d03"",
              ""name"": ""Example file"",
              ""fileFormat"": ""WAV"",
              ""size"": 292190,
              ""creationMethod"": ""RECORDED"",
              ""creationTime"": ""2025-02-20T01:35:41Z"",
              ""expirationTime"": ""2025-02-20T01:35:41Z"",
              ""duration"": 3
            }";

        SetUpDeleteRequest(DELETE_CALLS_FILE.Replace("{fileId}", givenFileId), 200, expectedResponse: givenResponse);

        var api = new CallsApi(configuration);

        var expectedResponse = new CallsFile(
            "218eceba-c044-430d-9f26-8f1a7f0g2d03",
            "Example file",
            CallsFileFormat.Wav,
            292190,
            CallsCreationMethod.Recorded,
            DateTimeOffset.Parse("2025-02-20T01:35:41Z"),
            DateTimeOffset.Parse("2025-02-20T01:35:41Z"),
            3
        );

        var response = api.DeleteCallsFile(givenFileId);

        Assert.AreEqual(expectedResponse, response);
    }

    [TestMethod]
    public void ShouldGetCallsRecordings()
    {
        var givenCallId = "64d214c5-70b7-4ea6-b2a6-8334d1f34fb4";
        var givenCallsConfigurationId = "dc5942707c704551a00cd2ea";
        var givenApplicationId = "61c060db2675060027d8c7a6";
        var givenEntityId = "64d214c5-70b7-4ea6-b2a6-8334d1f34fb4";
        var givenEndpointIdentifier = "44790123456";
        var givenStartTimeAfter = DateTimeOffset.Parse("2022-05-01T14:25:45.134+0000");
        var givenEndTimeBefore = DateTimeOffset.Parse("2022-05-01T14:35:45.154+0000");
        var givenDirection = CallDirection.Outbound;
        var givenEndpointType = CallEndpointType.Webrtc;
        var givenLocation = CallsRecordingLocation.Frankfurt;
        var givenPage = 0;
        var givenSize = 20;
        var givenQueryParameters = new Dictionary<string, string>
        {
            { "callId", givenCallId },
            { "callsConfigurationId", givenCallsConfigurationId },
            { "applicationId", givenApplicationId },
            { "entityId", givenEntityId },
            { "endpointIdentifier", givenEndpointIdentifier },
            { "startTimeAfter", givenStartTimeAfter.ToString() },
            { "endTimeBefore", givenEndTimeBefore.ToString() },
            { "direction", givenDirection.ToString() },
            { "endpointType", givenEndpointType.ToString() },
            { "location", givenLocation.ToString() },
            { "page", givenPage.ToString() },
            { "size", givenSize.ToString() }
        };

        var givenResponse = @"
            {
              ""results"": [
                {
                  ""callId"": ""d8d84155-3831-43fb-91c9-bb897149a79d"",
                  ""endpoint"": {
                    ""type"": ""PHONE"",
                    ""phoneNumber"": ""44790123456""
                  },
                  ""direction"": ""INBOUND"",
                  ""files"": [
                    {
                      ""id"": ""d8d84155-3831-43fb-91c9-bb897149a79d"",
                      ""name"": ""d8d84155-3831-43fb-91c9-bb897149a79d_1652725357412.wav"",
                      ""fileFormat"": ""WAV"",
                      ""size"": 67564,
                      ""creationTime"": ""2022-01-01T00:00:00.250+0000"",
                      ""duration"": 10,
                      ""startTime"": ""2021-12-31T23:59:50.100+0000"",
                      ""endTime"": ""2022-01-01T00:00:00.100+0000"",
                      ""location"": ""HOSTED"",
                      ""customData"": {
                        ""key1"": ""value1"",
                        ""key2"": ""value2""
                      }
                    }
                  ],
                  ""status"": ""SUCCESSFUL""
                },
                {
                  ""callId"": ""3ad8805e-d401-424e-9b03-e02a2016a5e2"",
                  ""endpoint"": {
                    ""type"": ""PHONE"",
                    ""phoneNumber"": ""44790123456""
                  },
                  ""direction"": ""INBOUND"",
                  ""files"": [
                    {
                      ""id"": ""d8d84155-3831-43fb-91c9-bb897149a79d"",
                      ""name"": ""d8d84155-3831-43fb-91c9-bb897149a79d_1652725357412.wav"",
                      ""fileFormat"": ""WAV"",
                      ""size"": 67564,
                      ""creationTime"": ""2022-01-01T00:00:00.250+0000"",
                      ""duration"": 10,
                      ""startTime"": ""2021-12-31T23:59:50.100+0000"",
                      ""endTime"": ""2022-01-01T00:00:00.100+0000"",
                      ""location"": ""HOSTED"",
                      ""customData"": {
                        ""key1"": ""value1"",
                        ""key2"": ""value2""
                      }
                    }
                  ],
                  ""status"": ""PARTIALLY_FAILED"",
                  ""reason"": ""Recording postprocessing failed""
                }
              ],
              ""paging"": {
                ""page"": 0,
                ""size"": 2,
                ""totalPages"": 1,
                ""totalResults"": 2
              }
            }";

        SetUpGetRequest(GET_CALLS_RECORDINGS, 200, givenResponse, givenQueryParameters);

        var api = new CallsApi(configuration);

        var expectedResponse = new CallRecordingPage(
            new List<CallRecording>
            {
                new(
                    "d8d84155-3831-43fb-91c9-bb897149a79d",
                    new CallsPhoneEndpoint(
                        "44790123456"
                    ),
                    CallDirection.Inbound,
                    new List<CallsRecordingFile>
                    {
                        new(
                            "d8d84155-3831-43fb-91c9-bb897149a79d",
                            "d8d84155-3831-43fb-91c9-bb897149a79d_1652725357412.wav",
                            CallsFileFormat.Wav,
                            67564,
                            DateTimeOffset.Parse("2022-01-01T00:00:00.250+0000"),
                            10,
                            DateTimeOffset.Parse("2021-12-31T23:59:50.100+0000"),
                            DateTimeOffset.Parse("2022-01-01T00:00:00.100+0000"),
                            CallsRecordingFileLocation.Hosted,
                            customData: new Dictionary<string, string>
                            {
                                { "key1", "value1" },
                                { "key2", "value2" }
                            }
                        )
                    },
                    CallsRecordingStatus.Successful
                ),
                new(
                    "3ad8805e-d401-424e-9b03-e02a2016a5e2",
                    new CallsPhoneEndpoint(
                        "44790123456"
                    ),
                    CallDirection.Inbound,
                    new List<CallsRecordingFile>
                    {
                        new(
                            "d8d84155-3831-43fb-91c9-bb897149a79d",
                            "d8d84155-3831-43fb-91c9-bb897149a79d_1652725357412.wav",
                            CallsFileFormat.Wav,
                            67564,
                            DateTimeOffset.Parse("2022-01-01T00:00:00.250+0000"),
                            10,
                            DateTimeOffset.Parse("2021-12-31T23:59:50.100+0000"),
                            DateTimeOffset.Parse("2022-01-01T00:00:00.100+0000"),
                            CallsRecordingFileLocation.Hosted,
                            customData: new Dictionary<string, string>
                            {
                                { "key1", "value1" },
                                { "key2", "value2" }
                            }
                        )
                    },
                    CallsRecordingStatus.PartiallyFailed,
                    "Recording postprocessing failed"
                )
            },
            new PageInfo(
                0,
                2,
                1,
                2
            )
        );

        var response = api.GetCallsRecordings(givenCallId, givenCallsConfigurationId, givenApplicationId, givenEntityId,
            givenEndpointIdentifier, givenStartTimeAfter, givenEndTimeBefore, givenDirection, givenEndpointType,
            givenLocation, givenPage, givenSize);

        Assert.AreEqual(expectedResponse, response);
    }

    [TestMethod]
    public void ShouldGetCallRecordings()
    {
        var givenCallId = "d8d84155-3831-43fb-91c9-bb897149a79d";
        var givenLocation = CallsRecordingLocation.Frankfurt;
        var givenQueryParameters = new Dictionary<string, string>
        {
            { "location", givenLocation.ToString() }
        };

        var givenResponse = @"
            {
              ""callId"": ""d8d84155-3831-43fb-91c9-bb897149a79d"",
              ""endpoint"": {
                ""type"": ""PHONE"",
                ""phoneNumber"": ""44790123456""
              },
              ""direction"": ""INBOUND"",
              ""files"": [
                {
                  ""id"": ""d8d84155-3831-43fb-91c9-bb897149a79d"",
                  ""name"": ""d8d84155-3831-43fb-91c9-bb897149a79d_1652725357412.wav"",
                  ""fileFormat"": ""WAV"",
                  ""size"": 67564,
                  ""creationTime"": ""2022-01-01T00:00:00.250+0000"",
                  ""duration"": 10,
                  ""startTime"": ""2021-12-31T23:59:50.100+0000"",
                  ""endTime"": ""2022-01-01T00:00:00.100+0000"",
                  ""location"": ""HOSTED"",
                  ""customData"": {
                    ""key1"": ""value1"",
                    ""key2"": ""value2""
                  }
                }
              ],
              ""status"": ""SUCCESSFUL""
            }";

        SetUpGetRequest(GET_CALL_RECORDINGS.Replace("{callId}", givenCallId), 200, givenResponse, givenQueryParameters);

        var api = new CallsApi(configuration);

        var expectedResponse = new CallRecording(
            "d8d84155-3831-43fb-91c9-bb897149a79d",
            new CallsPhoneEndpoint(
                "44790123456"
            ),
            CallDirection.Inbound,
            new List<CallsRecordingFile>
            {
                new(
                    "d8d84155-3831-43fb-91c9-bb897149a79d",
                    "d8d84155-3831-43fb-91c9-bb897149a79d_1652725357412.wav",
                    CallsFileFormat.Wav,
                    67564,
                    DateTimeOffset.Parse("2022-01-01T00:00:00.250+0000"),
                    10,
                    DateTimeOffset.Parse("2021-12-31T23:59:50.100+0000"),
                    DateTimeOffset.Parse("2022-01-01T00:00:00.100+0000"),
                    CallsRecordingFileLocation.Hosted,
                    customData: new Dictionary<string, string>
                    {
                        { "key1", "value1" },
                        { "key2", "value2" }
                    }
                )
            },
            CallsRecordingStatus.Successful
        );

        var response = api.GetCallRecordings(givenCallId, givenLocation);

        Assert.AreEqual(expectedResponse, response);
    }

    [TestMethod]
    public void ShouldDeleteCallRecordings()
    {
        var givenCallId = "d8d84155-3831-43fb-91c9-bb897149a79d";
        var givenLocation = CallsRecordingLocation.Frankfurt;
        var givenQueryParameters = new Dictionary<string, string>
        {
            { "location", givenLocation.ToString() }
        };

        var givenResponse = @"
            {
              ""callId"": ""d8d84155-3831-43fb-91c9-bb897149a79d"",
              ""endpoint"": {
                ""type"": ""PHONE"",
                ""phoneNumber"": ""44790123456""
              },
              ""direction"": ""INBOUND"",
              ""files"": [
                {
                  ""id"": ""d8d84155-3831-43fb-91c9-bb897149a79d"",
                  ""name"": ""d8d84155-3831-43fb-91c9-bb897149a79d_1652725357412.wav"",
                  ""fileFormat"": ""WAV"",
                  ""size"": 67564,
                  ""creationTime"": ""2022-01-01T00:00:00.250+0000"",
                  ""duration"": 10,
                  ""startTime"": ""2021-12-31T23:59:50.100+0000"",
                  ""endTime"": ""2022-01-01T00:00:00.100+0000"",
                  ""location"": ""HOSTED"",
                  ""customData"": {
                    ""key1"": ""value1"",
                    ""key2"": ""value2""
                  }
                }
              ],
              ""status"": ""SUCCESSFUL""
            }";

        SetUpDeleteRequest(DELETE_CALL_RECORDINGS.Replace("{callId}", givenCallId), 200,
            expectedResponse: givenResponse, givenParameters: givenQueryParameters);

        var api = new CallsApi(configuration);

        var expectedResponse = new CallRecording(
            "d8d84155-3831-43fb-91c9-bb897149a79d",
            new CallsPhoneEndpoint(
                "44790123456"
            ),
            CallDirection.Inbound,
            new List<CallsRecordingFile>
            {
                new(
                    "d8d84155-3831-43fb-91c9-bb897149a79d",
                    "d8d84155-3831-43fb-91c9-bb897149a79d_1652725357412.wav",
                    CallsFileFormat.Wav,
                    67564,
                    DateTimeOffset.Parse("2022-01-01T00:00:00.250+0000"),
                    10,
                    DateTimeOffset.Parse("2021-12-31T23:59:50.100+0000"),
                    DateTimeOffset.Parse("2022-01-01T00:00:00.100+0000"),
                    CallsRecordingFileLocation.Hosted,
                    customData: new Dictionary<string, string>
                    {
                        { "key1", "value1" },
                        { "key2", "value2" }
                    }
                )
            },
            CallsRecordingStatus.Successful
        );

        var response = api.DeleteCallRecordings(givenCallId, givenLocation);

        Assert.AreEqual(expectedResponse, response);
    }

    [TestMethod]
    public void ShouldGetConferencesRecordings()
    {
        var givenConferenceId = "034e622a-cc7e-456d-8a10-0ba43b11aa5e";
        var givenCallsConfigurationId = "dc5942707c704551a00cd2ea";
        var givenApplicationId = "61c060db2675060027d8c7a6";
        var givenEntityId = "64d214c5-70b7-4ea6-b2a6-8334d1f34fb4";
        var givenConferenceName = "Conference";
        var givenCallId = "64d214c5-70b7-4ea6-b2a6-8334d1f34fb4";
        var givenCallEndpointType = CallEndpointType.Webrtc;
        var givenCallEndpointIdentifier = "44790123456";
        var givenStartTimeAfter = DateTimeOffset.Parse("2022-05-01T14:25:45.134+0000");
        var givenEndTimeBefore = DateTimeOffset.Parse("2022-05-01T14:35:45.154+0000");
        var givenComposition = true;
        var givenLocation = CallsRecordingLocation.Frankfurt;
        var givenPage = 0;
        var givenSize = 20;
        var givenQueryParameters = new Dictionary<string, string>
        {
            { "conferenceId", givenConferenceId },
            { "callsConfigurationId", givenCallsConfigurationId },
            { "applicationId", givenApplicationId },
            { "entityId", givenEntityId },
            { "conferenceName", givenConferenceName },
            { "callId", givenCallId },
            { "callEndpointType", givenCallEndpointType.ToString() },
            { "callEndpointIdentifier", givenCallEndpointIdentifier },
            { "startTimeAfter", givenStartTimeAfter.ToString() },
            { "endTimeBefore", givenEndTimeBefore.ToString() },
            { "composition", GetBooleanValueAsLowerString(givenComposition) },
            { "location", givenLocation.ToString() },
            { "page", givenPage.ToString() },
            { "size", givenSize.ToString() }
        };

        var givenResponse = @"
            {
              ""results"": [
                {
                  ""conferenceId"": ""034e622a-cc7e-456d-8a10-0ba43b11aa5e"",
                  ""conferenceName"": ""Example conference"",
                  ""platform"": {
                    ""applicationId"": ""61c060db2675060027d8c7a6""
                  },
                  ""composedFiles"": [
                    {
                      ""id"": ""b72cde3c-7d9c-4a5c-8e48-5a947244c013"",
                      ""name"": ""d8d84155-3831-43fb-91c9-bb897149a79d_41792030001_1652725357412_recording.wav"",
                      ""fileFormat"": ""WAV"",
                      ""size"": 67564,
                      ""creationTime"": ""2022-01-01T00:00:00.250+0000"",
                      ""duration"": 10,
                      ""startTime"": ""2021-12-31T23:59:50.100+0000"",
                      ""endTime"": ""2022-01-01T00:00:00.100+0000"",
                      ""location"": ""SFTP"",
                      ""sftpUploadStatus"": ""UPLOADED"",
                      ""customData"": {
                        ""key1"": ""value1"",
                        ""key2"": ""value2""
                      }
                    }
                  ],
                  ""callRecordings"": [
                    {
                      ""callId"": ""d8d84155-3831-43fb-91c9-bb897149a79d"",
                      ""endpoint"": {
                        ""type"": ""PHONE"",
                        ""phoneNumber"": ""44790123456""
                      },
                      ""direction"": ""INBOUND"",
                      ""files"": [
                        {
                          ""id"": ""d8d84155-3831-43fb-91c9-bb897149a79d"",
                          ""name"": ""d8d84155-3831-43fb-91c9-bb897149a79d_1652725357412.wav"",
                          ""fileFormat"": ""WAV"",
                          ""size"": 67564,
                          ""creationTime"": ""2022-01-01T00:00:00.250+0000"",
                          ""duration"": 10,
                          ""startTime"": ""2021-12-31T23:59:50.100+0000"",
                          ""endTime"": ""2022-01-01T00:00:00.100+0000"",
                          ""location"": ""HOSTED"",
                          ""customData"": {
                            ""key1"": ""value1"",
                            ""key2"": ""value2""
                          }
                        }
                      ],
                      ""status"": ""SUCCESSFUL""
                    },
                    {
                      ""callId"": ""3ad8805e-d401-424e-9b03-e02a2016a5e2"",
                      ""endpoint"": {
                        ""type"": ""PHONE"",
                        ""phoneNumber"": ""44790123456""
                      },
                      ""direction"": ""INBOUND"",
                      ""files"": [
                        {
                          ""id"": ""d8d84155-3831-43fb-91c9-bb897149a79d"",
                          ""name"": ""d8d84155-3831-43fb-91c9-bb897149a79d_1652725357412.wav"",
                          ""fileFormat"": ""WAV"",
                          ""size"": 67564,
                          ""creationTime"": ""2022-01-01T00:00:00.250+0000"",
                          ""duration"": 10,
                          ""startTime"": ""2021-12-31T23:59:50.100+0000"",
                          ""endTime"": ""2022-01-01T00:00:00.100+0000"",
                          ""location"": ""HOSTED"",
                          ""customData"": {
                            ""key1"": ""value1"",
                            ""key2"": ""value2""
                          }
                        }
                      ],
                      ""status"": ""SUCCESSFUL""
                    }
                  ]
                }
              ],
              ""paging"": {
                ""page"": 0,
                ""size"": 1,
                ""totalPages"": 1,
                ""totalResults"": 1
              }
            }";

        SetUpGetRequest(GET_CONFERENCES_RECORDINGS, 200, givenResponse, givenQueryParameters);

        var api = new CallsApi(configuration);

        var expectedResponse = new CallsConferenceRecordingPage(
            new List<CallsConferenceRecording>
            {
                new(
                    "034e622a-cc7e-456d-8a10-0ba43b11aa5e",
                    "Example conference",
                    platform: new Platform(
                        applicationId: "61c060db2675060027d8c7a6"
                    ),
                    composedFiles: new List<CallsRecordingFile>
                    {
                        new(
                            "b72cde3c-7d9c-4a5c-8e48-5a947244c013",
                            "d8d84155-3831-43fb-91c9-bb897149a79d_41792030001_1652725357412_recording.wav",
                            CallsFileFormat.Wav,
                            67564,
                            DateTimeOffset.Parse("2022-01-01T00:00:00.250+0000"),
                            10,
                            DateTimeOffset.Parse("2021-12-31T23:59:50.100+0000"),
                            DateTimeOffset.Parse("2022-01-01T00:00:00.100+0000"),
                            CallsRecordingFileLocation.Sftp,
                            CallsSftpUploadStatus.Uploaded,
                            new Dictionary<string, string>
                            {
                                { "key1", "value1" },
                                { "key2", "value2" }
                            }
                        )
                    },
                    callRecordings: new List<CallRecording>
                    {
                        new(
                            "d8d84155-3831-43fb-91c9-bb897149a79d",
                            new CallsPhoneEndpoint(
                                "44790123456"
                            ),
                            CallDirection.Inbound,
                            new List<CallsRecordingFile>
                            {
                                new(
                                    "d8d84155-3831-43fb-91c9-bb897149a79d",
                                    "d8d84155-3831-43fb-91c9-bb897149a79d_1652725357412.wav",
                                    CallsFileFormat.Wav,
                                    67564,
                                    DateTimeOffset.Parse("2022-01-01T00:00:00.250+0000"),
                                    10,
                                    DateTimeOffset.Parse("2021-12-31T23:59:50.100+0000"),
                                    DateTimeOffset.Parse("2022-01-01T00:00:00.100+0000"),
                                    CallsRecordingFileLocation.Hosted,
                                    customData: new Dictionary<string, string>
                                    {
                                        { "key1", "value1" },
                                        { "key2", "value2" }
                                    }
                                )
                            },
                            CallsRecordingStatus.Successful
                        ),
                        new(
                            "3ad8805e-d401-424e-9b03-e02a2016a5e2",
                            new CallsPhoneEndpoint(
                                "44790123456"
                            ),
                            CallDirection.Inbound,
                            new List<CallsRecordingFile>
                            {
                                new(
                                    "d8d84155-3831-43fb-91c9-bb897149a79d",
                                    "d8d84155-3831-43fb-91c9-bb897149a79d_1652725357412.wav",
                                    CallsFileFormat.Wav,
                                    67564,
                                    DateTimeOffset.Parse("2022-01-01T00:00:00.250+0000"),
                                    10,
                                    DateTimeOffset.Parse("2021-12-31T23:59:50.100+0000"),
                                    DateTimeOffset.Parse("2022-01-01T00:00:00.100+0000"),
                                    CallsRecordingFileLocation.Hosted,
                                    customData: new Dictionary<string, string>
                                    {
                                        { "key1", "value1" },
                                        { "key2", "value2" }
                                    }
                                )
                            },
                            CallsRecordingStatus.Successful
                        )
                    }
                )
            },
            new PageInfo(
                0,
                1,
                1,
                1
            )
        );

        var response = api.GetConferencesRecordings(givenConferenceId, givenCallsConfigurationId, givenApplicationId,
            givenEntityId, givenConferenceName, givenCallId, givenCallEndpointType, givenCallEndpointIdentifier,
            givenStartTimeAfter, givenEndTimeBefore, givenComposition, givenLocation, givenPage, givenSize);

        Assert.AreEqual(expectedResponse, response);
    }

    [TestMethod]
    public void ShouldGetConferenceRecordings()
    {
        var givenConferenceId = "034e622a-cc7e-456d-8a10-0ba43b11aa5e";
        var givenLocation = CallsRecordingLocation.Frankfurt;
        var givenQueryParameters = new Dictionary<string, string>
        {
            { "location", givenLocation.ToString() }
        };

        var givenResponse = @"
            {
              ""conferenceId"": ""034e622a-cc7e-456d-8a10-0ba43b11aa5e"",
              ""conferenceName"": ""Example conference"",
              ""platform"": {
                ""applicationId"": ""61c060db2675060027d8c7a6""
              },
              ""composedFiles"": [
                {
                  ""id"": ""b72cde3c-7d9c-4a5c-8e48-5a947244c013"",
                  ""name"": ""d8d84155-3831-43fb-91c9-bb897149a79d_41792030001_1652725357412_recording.wav"",
                  ""fileFormat"": ""WAV"",
                  ""size"": 67564,
                  ""creationTime"": ""2022-01-01T00:00:00.250+0000"",
                  ""duration"": 10,
                  ""startTime"": ""2021-12-31T23:59:50.100+0000"",
                  ""endTime"": ""2022-01-01T00:00:00.100+0000"",
                  ""location"": ""SFTP"",
                  ""sftpUploadStatus"": ""UPLOADED"",
                  ""customData"": {
                    ""key1"": ""value1"",
                    ""key2"": ""value2""
                  }
                }
              ],
              ""callRecordings"": [
                {
                  ""callId"": ""d8d84155-3831-43fb-91c9-bb897149a79d"",
                  ""endpoint"": {
                    ""type"": ""PHONE"",
                    ""phoneNumber"": ""44790123456""
                  },
                  ""direction"": ""INBOUND"",
                  ""files"": [
                    {
                      ""id"": ""d8d84155-3831-43fb-91c9-bb897149a79d"",
                      ""name"": ""d8d84155-3831-43fb-91c9-bb897149a79d_1652725357412.wav"",
                      ""fileFormat"": ""WAV"",
                      ""size"": 67564,
                      ""creationTime"": ""2022-01-01T00:00:00.250+0000"",
                      ""duration"": 10,
                      ""startTime"": ""2021-12-31T23:59:50.100+0000"",
                      ""endTime"": ""2022-01-01T00:00:00.100+0000"",
                      ""location"": ""HOSTED"",
                      ""customData"": {
                        ""key1"": ""value1"",
                        ""key2"": ""value2""
                      }
                    }
                  ],
                  ""status"": ""SUCCESSFUL""
                },
                {
                  ""callId"": ""3ad8805e-d401-424e-9b03-e02a2016a5e2"",
                  ""endpoint"": {
                    ""type"": ""PHONE"",
                    ""phoneNumber"": ""44790123456""
                  },
                  ""direction"": ""INBOUND"",
                  ""files"": [
                    {
                      ""id"": ""d8d84155-3831-43fb-91c9-bb897149a79d"",
                      ""name"": ""d8d84155-3831-43fb-91c9-bb897149a79d_1652725357412.wav"",
                      ""fileFormat"": ""WAV"",
                      ""size"": 67564,
                      ""creationTime"": ""2022-01-01T00:00:00.250+0000"",
                      ""duration"": 10,
                      ""startTime"": ""2021-12-31T23:59:50.100+0000"",
                      ""endTime"": ""2022-01-01T00:00:00.100+0000"",
                      ""location"": ""HOSTED"",
                      ""customData"": {
                        ""key1"": ""value1"",
                        ""key2"": ""value2""
                      }
                    }
                  ],
                  ""status"": ""SUCCESSFUL""
                }
              ]
            }";

        SetUpGetRequest(GET_CONFERENCE_RECORDINGS.Replace("{conferenceId}", givenConferenceId), 200, givenResponse,
            givenQueryParameters);

        var api = new CallsApi(configuration);

        var expectedResponse = new CallsConferenceRecording(
            "034e622a-cc7e-456d-8a10-0ba43b11aa5e",
            "Example conference",
            platform: new Platform(
                applicationId: "61c060db2675060027d8c7a6"
            ),
            composedFiles: new List<CallsRecordingFile>
            {
                new(
                    "b72cde3c-7d9c-4a5c-8e48-5a947244c013",
                    "d8d84155-3831-43fb-91c9-bb897149a79d_41792030001_1652725357412_recording.wav",
                    CallsFileFormat.Wav,
                    67564,
                    DateTimeOffset.Parse("2022-01-01T00:00:00.250+0000"),
                    10,
                    DateTimeOffset.Parse("2021-12-31T23:59:50.100+0000"),
                    DateTimeOffset.Parse("2022-01-01T00:00:00.100+0000"),
                    CallsRecordingFileLocation.Sftp,
                    CallsSftpUploadStatus.Uploaded,
                    new Dictionary<string, string>
                    {
                        { "key1", "value1" },
                        { "key2", "value2" }
                    }
                )
            },
            callRecordings: new List<CallRecording>
            {
                new(
                    "d8d84155-3831-43fb-91c9-bb897149a79d",
                    new CallsPhoneEndpoint(
                        "44790123456"
                    ),
                    CallDirection.Inbound,
                    new List<CallsRecordingFile>
                    {
                        new(
                            "d8d84155-3831-43fb-91c9-bb897149a79d",
                            "d8d84155-3831-43fb-91c9-bb897149a79d_1652725357412.wav",
                            CallsFileFormat.Wav,
                            67564,
                            DateTimeOffset.Parse("2022-01-01T00:00:00.250+0000"),
                            10,
                            DateTimeOffset.Parse("2021-12-31T23:59:50.100+0000"),
                            DateTimeOffset.Parse("2022-01-01T00:00:00.100+0000"),
                            CallsRecordingFileLocation.Hosted,
                            customData: new Dictionary<string, string>
                            {
                                { "key1", "value1" },
                                { "key2", "value2" }
                            }
                        )
                    },
                    CallsRecordingStatus.Successful
                ),
                new(
                    "3ad8805e-d401-424e-9b03-e02a2016a5e2",
                    new CallsPhoneEndpoint(
                        "44790123456"
                    ),
                    CallDirection.Inbound,
                    new List<CallsRecordingFile>
                    {
                        new(
                            "d8d84155-3831-43fb-91c9-bb897149a79d",
                            "d8d84155-3831-43fb-91c9-bb897149a79d_1652725357412.wav",
                            CallsFileFormat.Wav,
                            67564,
                            DateTimeOffset.Parse("2022-01-01T00:00:00.250+0000"),
                            10,
                            DateTimeOffset.Parse("2021-12-31T23:59:50.100+0000"),
                            DateTimeOffset.Parse("2022-01-01T00:00:00.100+0000"),
                            CallsRecordingFileLocation.Hosted,
                            customData: new Dictionary<string, string>
                            {
                                { "key1", "value1" },
                                { "key2", "value2" }
                            }
                        )
                    },
                    CallsRecordingStatus.Successful
                )
            }
        );

        var response = api.GetConferenceRecordings(givenConferenceId, givenLocation);

        Assert.AreEqual(expectedResponse, response);
    }

    [TestMethod]
    public void ShouldDeleteConferenceRecording()
    {
        var givenConferenceId = "034e622a-cc7e-456d-8a10-0ba43b11aa5e";
        var givenLocation = CallsRecordingLocation.Frankfurt;
        var givenQueryParameters = new Dictionary<string, string>
        {
            { "location", givenLocation.ToString() }
        };

        var givenResponse = @"
            {
              ""conferenceId"": ""034e622a-cc7e-456d-8a10-0ba43b11aa5e"",
              ""conferenceName"": ""Example conference"",
              ""platform"": {
                ""applicationId"": ""61c060db2675060027d8c7a6""
              },
              ""composedFiles"": [
                {
                  ""id"": ""b72cde3c-7d9c-4a5c-8e48-5a947244c013"",
                  ""name"": ""d8d84155-3831-43fb-91c9-bb897149a79d_41792030001_1652725357412_recording.wav"",
                  ""fileFormat"": ""WAV"",
                  ""size"": 67564,
                  ""creationTime"": ""2022-01-01T00:00:00.250+0000"",
                  ""duration"": 10,
                  ""startTime"": ""2021-12-31T23:59:50.100+0000"",
                  ""endTime"": ""2022-01-01T00:00:00.100+0000"",
                  ""location"": ""SFTP"",
                  ""sftpUploadStatus"": ""UPLOADED"",
                  ""customData"": {
                    ""key1"": ""value1"",
                    ""key2"": ""value2""
                  }
                }
              ],
              ""callRecordings"": [
                {
                  ""callId"": ""d8d84155-3831-43fb-91c9-bb897149a79d"",
                  ""endpoint"": {
                    ""type"": ""PHONE"",
                    ""phoneNumber"": ""44790123456""
                  },
                  ""direction"": ""INBOUND"",
                  ""files"": [
                    {
                      ""id"": ""d8d84155-3831-43fb-91c9-bb897149a79d"",
                      ""name"": ""d8d84155-3831-43fb-91c9-bb897149a79d_1652725357412.wav"",
                      ""fileFormat"": ""WAV"",
                      ""size"": 67564,
                      ""creationTime"": ""2022-01-01T00:00:00.250+0000"",
                      ""duration"": 10,
                      ""startTime"": ""2021-12-31T23:59:50.100+0000"",
                      ""endTime"": ""2022-01-01T00:00:00.100+0000"",
                      ""location"": ""HOSTED"",
                      ""customData"": {
                        ""key1"": ""value1"",
                        ""key2"": ""value2""
                      }
                    }
                  ],
                  ""status"": ""SUCCESSFUL""
                },
                {
                  ""callId"": ""3ad8805e-d401-424e-9b03-e02a2016a5e2"",
                  ""endpoint"": {
                    ""type"": ""PHONE"",
                    ""phoneNumber"": ""44790123456""
                  },
                  ""direction"": ""INBOUND"",
                  ""files"": [
                    {
                      ""id"": ""d8d84155-3831-43fb-91c9-bb897149a79d"",
                      ""name"": ""d8d84155-3831-43fb-91c9-bb897149a79d_1652725357412.wav"",
                      ""fileFormat"": ""WAV"",
                      ""size"": 67564,
                      ""creationTime"": ""2022-01-01T00:00:00.250+0000"",
                      ""duration"": 10,
                      ""startTime"": ""2021-12-31T23:59:50.100+0000"",
                      ""endTime"": ""2022-01-01T00:00:00.100+0000"",
                      ""location"": ""HOSTED"",
                      ""customData"": {
                        ""key1"": ""value1"",
                        ""key2"": ""value2""
                      }
                    }
                  ],
                  ""status"": ""SUCCESSFUL""
                }
              ]
            }";

        SetUpDeleteRequest(DELETE_CONFERENCE_RECORDINGS.Replace("{conferenceId}", givenConferenceId), 200,
            expectedResponse: givenResponse, givenParameters: givenQueryParameters);

        var api = new CallsApi(configuration);

        var expectedResponse = new CallsConferenceRecording(
            "034e622a-cc7e-456d-8a10-0ba43b11aa5e",
            "Example conference",
            platform: new Platform(
                applicationId: "61c060db2675060027d8c7a6"
            ),
            composedFiles: new List<CallsRecordingFile>
            {
                new(
                    "b72cde3c-7d9c-4a5c-8e48-5a947244c013",
                    "d8d84155-3831-43fb-91c9-bb897149a79d_41792030001_1652725357412_recording.wav",
                    CallsFileFormat.Wav,
                    67564,
                    DateTimeOffset.Parse("2022-01-01T00:00:00.250+0000"),
                    10,
                    DateTimeOffset.Parse("2021-12-31T23:59:50.100+0000"),
                    DateTimeOffset.Parse("2022-01-01T00:00:00.100+0000"),
                    CallsRecordingFileLocation.Sftp,
                    CallsSftpUploadStatus.Uploaded,
                    new Dictionary<string, string>
                    {
                        { "key1", "value1" },
                        { "key2", "value2" }
                    }
                )
            },
            callRecordings: new List<CallRecording>
            {
                new(
                    "d8d84155-3831-43fb-91c9-bb897149a79d",
                    new CallsPhoneEndpoint(
                        "44790123456"
                    ),
                    CallDirection.Inbound,
                    new List<CallsRecordingFile>
                    {
                        new(
                            "d8d84155-3831-43fb-91c9-bb897149a79d",
                            "d8d84155-3831-43fb-91c9-bb897149a79d_1652725357412.wav",
                            CallsFileFormat.Wav,
                            67564,
                            DateTimeOffset.Parse("2022-01-01T00:00:00.250+0000"),
                            10,
                            DateTimeOffset.Parse("2021-12-31T23:59:50.100+0000"),
                            DateTimeOffset.Parse("2022-01-01T00:00:00.100+0000"),
                            CallsRecordingFileLocation.Hosted,
                            customData: new Dictionary<string, string>
                            {
                                { "key1", "value1" },
                                { "key2", "value2" }
                            }
                        )
                    },
                    CallsRecordingStatus.Successful
                ),
                new(
                    "3ad8805e-d401-424e-9b03-e02a2016a5e2",
                    new CallsPhoneEndpoint(
                        "44790123456"
                    ),
                    CallDirection.Inbound,
                    new List<CallsRecordingFile>
                    {
                        new(
                            "d8d84155-3831-43fb-91c9-bb897149a79d",
                            "d8d84155-3831-43fb-91c9-bb897149a79d_1652725357412.wav",
                            CallsFileFormat.Wav,
                            67564,
                            DateTimeOffset.Parse("2022-01-01T00:00:00.250+0000"),
                            10,
                            DateTimeOffset.Parse("2021-12-31T23:59:50.100+0000"),
                            DateTimeOffset.Parse("2022-01-01T00:00:00.100+0000"),
                            CallsRecordingFileLocation.Hosted,
                            customData: new Dictionary<string, string>
                            {
                                { "key1", "value1" },
                                { "key2", "value2" }
                            }
                        )
                    },
                    CallsRecordingStatus.Successful
                )
            }
        );

        var response = api.DeleteConferenceRecordings(givenConferenceId, givenLocation);

        Assert.AreEqual(expectedResponse, response);
    }

    [TestMethod]
    public void ShouldComposeConferenceRecordingOnCalls()
    {
        var givenConferenceId = "034e622a-cc7e-456d-8a10-0ba43b11aa5e";
        var givenLocation = CallsRecordingLocation.Frankfurt;
        var givenQueryParameters = new Dictionary<string, string>
        {
            { "location", givenLocation.ToString() }
        };

        var givenRequest = @"
            {
              ""deleteCallRecordings"": true,
              ""multiChannel"": {
                ""enabled"": true
              }
            }";

        var givenResponse = @"
            {
              ""status"": ""PENDING""
            }";

        SetUpPostRequest(COMPOSE_CONFERENCE_RECORDING.Replace("{conferenceId}", givenConferenceId), 200, givenRequest,
            givenResponse, givenQueryParameters);

        var api = new CallsApi(configuration);

        var request = new CallsOnDemandComposition(
            true,
            new CallsMultiChannel(
                true
            )
        );

        var expectedResponse = new CallsActionResponse(
            CallsActionStatus.Pending
        );

        var response = api.ComposeConferenceRecording(givenConferenceId, request, givenLocation);

        Assert.AreEqual(expectedResponse, response);
    }

    [TestMethod]
    public void ShouldGetDialogsRecordings()
    {
        var givenDialogId = "64d214c5-70b7-4ea6-b2a6-8334d1f34fb4";
        var givenCallsConfigurationId = "dc5942707c704551a00cd2ea";
        var givenApplicationId = "61c060db2675060027d8c7a6";
        var givenEntityId = "64d214c5-70b7-4ea6-b2a6-8334d1f34fb4";
        var givenCallId = "64d214c5-70b7-4ea6-b2a6-8334d1f34fb4";
        var givenCallEndpointType = CallEndpointType.Webrtc;
        var givenCallEndpointIdentifier = "44790123456";
        var givenStartTimeAfter = DateTimeOffset.Parse("2022-05-01T14:25:45.134+0000");
        var givenEndTimeBefore = DateTimeOffset.Parse("2022-05-01T14:35:45.154+0000");
        var givenComposition = true;
        var givenLocation = CallsRecordingLocation.Frankfurt;
        var givenPage = 0;
        var givenSize = 20;
        var givenQueryParameters = new Dictionary<string, string>
        {
            { "dialogId", givenDialogId },
            { "callsConfigurationId", givenCallsConfigurationId },
            { "applicationId", givenApplicationId },
            { "entityId", givenEntityId },
            { "callId", givenCallId },
            { "callEndpointType", givenCallEndpointType.ToString() },
            { "callEndpointIdentifier", givenCallEndpointIdentifier },
            { "startTimeAfter", givenStartTimeAfter.ToString() },
            { "endTimeBefore", givenEndTimeBefore.ToString() },
            { "composition", GetBooleanValueAsLowerString(givenComposition) },
            { "location", givenLocation.ToString() },
            { "page", givenPage.ToString() },
            { "size", givenSize.ToString() }
        };

        var givenResponse = @"
            {
              ""results"": [
                {
                  ""dialogId"": ""034e622a-cc7e-456d-8a10-0ba43b11aa5e"",
                  ""platform"": {
                    ""applicationId"": ""61c060db2675060027d8c7a6""
                  },
                  ""composedFiles"": [
                    {
                      ""id"": ""b72cde3c-7d9c-4a5c-8e48-5a947244c013"",
                      ""name"": ""d8d84155-3831-43fb-91c9-bb897149a79d_41792030001_1652725357412_recording.wav"",
                      ""fileFormat"": ""WAV"",
                      ""size"": 67564,
                      ""creationTime"": ""2022-01-01T00:00:00.250+0000"",
                      ""duration"": 10,
                      ""startTime"": ""2021-12-31T23:59:50.100+0000"",
                      ""endTime"": ""2022-01-01T00:00:00.100+0000"",
                      ""location"": ""HOSTED"",
                      ""customData"": {
                        ""key1"": ""value1"",
                        ""key2"": ""value2""
                      }
                    }
                  ],
                  ""callRecordings"": [
                    {
                      ""callId"": ""d8d84155-3831-43fb-91c9-bb897149a79d"",
                      ""endpoint"": {
                        ""type"": ""PHONE"",
                        ""phoneNumber"": ""44790123456""
                      },
                      ""direction"": ""INBOUND"",
                      ""files"": [
                        {
                          ""id"": ""d8d84155-3831-43fb-91c9-bb897149a79d"",
                          ""name"": ""d8d84155-3831-43fb-91c9-bb897149a79d_1652725357412.wav"",
                          ""fileFormat"": ""WAV"",
                          ""size"": 67564,
                          ""creationTime"": ""2022-01-01T00:00:00.250+0000"",
                          ""duration"": 10,
                          ""startTime"": ""2021-12-31T23:59:50.100+0000"",
                          ""endTime"": ""2022-01-01T00:00:00.100+0000"",
                          ""location"": ""HOSTED"",
                          ""customData"": {
                            ""key1"": ""value1"",
                            ""key2"": ""value2""
                          }
                        }
                      ],
                      ""status"": ""SUCCESSFUL""
                    },
                    {
                      ""callId"": ""3ad8805e-d401-424e-9b03-e02a2016a5e2"",
                      ""endpoint"": {
                        ""type"": ""PHONE"",
                        ""phoneNumber"": ""44790123456""
                      },
                      ""direction"": ""INBOUND"",
                      ""files"": [
                        {
                          ""id"": ""d8d84155-3831-43fb-91c9-bb897149a79d"",
                          ""name"": ""d8d84155-3831-43fb-91c9-bb897149a79d_1652725357412.wav"",
                          ""fileFormat"": ""WAV"",
                          ""size"": 67564,
                          ""creationTime"": ""2022-01-01T00:00:00.250+0000"",
                          ""duration"": 10,
                          ""startTime"": ""2021-12-31T23:59:50.100+0000"",
                          ""endTime"": ""2022-01-01T00:00:00.100+0000"",
                          ""location"": ""HOSTED"",
                          ""customData"": {
                            ""key1"": ""value1"",
                            ""key2"": ""value2""
                          }
                        }
                      ],
                      ""status"": ""SUCCESSFUL""
                    }
                  ]
                }
              ],
              ""paging"": {
                ""page"": 0,
                ""size"": 1,
                ""totalPages"": 1,
                ""totalResults"": 1
              }
            }";

        SetUpGetRequest(GET_DIALOGS_RECORDINGS, 200, givenResponse, givenQueryParameters);

        var api = new CallsApi(configuration);

        var expectedResponse = new CallsDialogRecordingPage(
            new List<CallsDialogRecordingResponse>
            {
                new(
                    "034e622a-cc7e-456d-8a10-0ba43b11aa5e",
                    platform: new Platform(
                        applicationId: "61c060db2675060027d8c7a6"
                    ),
                    composedFiles: new List<CallsRecordingFile>
                    {
                        new(
                            "b72cde3c-7d9c-4a5c-8e48-5a947244c013",
                            "d8d84155-3831-43fb-91c9-bb897149a79d_41792030001_1652725357412_recording.wav",
                            CallsFileFormat.Wav,
                            67564,
                            DateTimeOffset.Parse("2022-01-01T00:00:00.250+0000"),
                            10,
                            DateTimeOffset.Parse("2021-12-31T23:59:50.100+0000"),
                            DateTimeOffset.Parse("2022-01-01T00:00:00.100+0000"),
                            CallsRecordingFileLocation.Hosted,
                            customData: new Dictionary<string, string>
                            {
                                { "key1", "value1" },
                                { "key2", "value2" }
                            }
                        )
                    },
                    callRecordings: new List<CallRecording>
                    {
                        new(
                            "d8d84155-3831-43fb-91c9-bb897149a79d",
                            new CallsPhoneEndpoint(
                                "44790123456"
                            ),
                            CallDirection.Inbound,
                            new List<CallsRecordingFile>
                            {
                                new(
                                    "d8d84155-3831-43fb-91c9-bb897149a79d",
                                    "d8d84155-3831-43fb-91c9-bb897149a79d_1652725357412.wav",
                                    CallsFileFormat.Wav,
                                    67564,
                                    DateTimeOffset.Parse("2022-01-01T00:00:00.250+0000"),
                                    10,
                                    DateTimeOffset.Parse("2021-12-31T23:59:50.100+0000"),
                                    DateTimeOffset.Parse("2022-01-01T00:00:00.100+0000"),
                                    CallsRecordingFileLocation.Hosted,
                                    customData: new Dictionary<string, string>
                                    {
                                        { "key1", "value1" },
                                        { "key2", "value2" }
                                    }
                                )
                            },
                            CallsRecordingStatus.Successful
                        ),
                        new(
                            "3ad8805e-d401-424e-9b03-e02a2016a5e2",
                            new CallsPhoneEndpoint(
                                "44790123456"
                            ),
                            CallDirection.Inbound,
                            new List<CallsRecordingFile>
                            {
                                new(
                                    "d8d84155-3831-43fb-91c9-bb897149a79d",
                                    "d8d84155-3831-43fb-91c9-bb897149a79d_1652725357412.wav",
                                    CallsFileFormat.Wav,
                                    67564,
                                    DateTimeOffset.Parse("2022-01-01T00:00:00.250+0000"),
                                    10,
                                    DateTimeOffset.Parse("2021-12-31T23:59:50.100+0000"),
                                    DateTimeOffset.Parse("2022-01-01T00:00:00.100+0000"),
                                    CallsRecordingFileLocation.Hosted,
                                    customData: new Dictionary<string, string>
                                    {
                                        { "key1", "value1" },
                                        { "key2", "value2" }
                                    }
                                )
                            },
                            CallsRecordingStatus.Successful
                        )
                    }
                )
            },
            new PageInfo(
                0,
                1,
                1,
                1
            )
        );

        var response = api.GetDialogsRecordings(givenDialogId, givenCallsConfigurationId, givenApplicationId,
            givenEntityId, givenCallId, givenCallEndpointType, givenCallEndpointIdentifier, givenStartTimeAfter,
            givenEndTimeBefore, givenComposition, givenLocation, givenPage, givenSize);

        Assert.AreEqual(expectedResponse, response);
    }

    [TestMethod]
    public void ShouldGetDialogRecordings()
    {
        var givenDialogId = "034e622a-cc7e-456d-8a10-0ba43b11aa5e";
        var givenLocation = CallsRecordingLocation.Frankfurt;
        var givenQueryParameters = new Dictionary<string, string>
        {
            { "location", givenLocation.ToString() }
        };

        var givenResponse = @"
            {
              ""dialogId"": ""034e622a-cc7e-456d-8a10-0ba43b11aa5e"",
              ""platform"": {
                ""applicationId"": ""61c060db2675060027d8c7a6""
              },
              ""composedFiles"": [
                {
                  ""id"": ""b72cde3c-7d9c-4a5c-8e48-5a947244c013"",
                  ""name"": ""d8d84155-3831-43fb-91c9-bb897149a79d_41792030001_1652725357412_recording.wav"",
                  ""fileFormat"": ""WAV"",
                  ""size"": 67564,
                  ""creationTime"": ""2022-01-01T00:00:00.250+0000"",
                  ""duration"": 10,
                  ""startTime"": ""2021-12-31T23:59:50.100+0000"",
                  ""endTime"": ""2022-01-01T00:00:00.100+0000"",
                  ""location"": ""HOSTED"",
                  ""customData"": {
                    ""key1"": ""value1"",
                    ""key2"": ""value2""
                  }
                }
              ],
              ""callRecordings"": [
                {
                  ""callId"": ""d8d84155-3831-43fb-91c9-bb897149a79d"",
                  ""endpoint"": {
                    ""type"": ""PHONE"",
                    ""phoneNumber"": ""44790123456""
                  },
                  ""direction"": ""INBOUND"",
                  ""files"": [
                    {
                      ""id"": ""d8d84155-3831-43fb-91c9-bb897149a79d"",
                      ""name"": ""d8d84155-3831-43fb-91c9-bb897149a79d_1652725357412.wav"",
                      ""fileFormat"": ""WAV"",
                      ""size"": 67564,
                      ""creationTime"": ""2022-01-01T00:00:00.250+0000"",
                      ""duration"": 10,
                      ""startTime"": ""2021-12-31T23:59:50.100+0000"",
                      ""endTime"": ""2022-01-01T00:00:00.100+0000"",
                      ""location"": ""HOSTED"",
                      ""customData"": {
                        ""key1"": ""value1"",
                        ""key2"": ""value2""
                      }
                    }
                  ],
                  ""status"": ""SUCCESSFUL""
                },
                {
                  ""callId"": ""3ad8805e-d401-424e-9b03-e02a2016a5e2"",
                  ""endpoint"": {
                    ""type"": ""PHONE"",
                    ""phoneNumber"": ""44790123456""
                  },
                  ""direction"": ""INBOUND"",
                  ""files"": [
                    {
                      ""id"": ""d8d84155-3831-43fb-91c9-bb897149a79d"",
                      ""name"": ""d8d84155-3831-43fb-91c9-bb897149a79d_1652725357412.wav"",
                      ""fileFormat"": ""WAV"",
                      ""size"": 67564,
                      ""creationTime"": ""2022-01-01T00:00:00.250+0000"",
                      ""duration"": 10,
                      ""startTime"": ""2021-12-31T23:59:50.100+0000"",
                      ""endTime"": ""2022-01-01T00:00:00.100+0000"",
                      ""location"": ""HOSTED"",
                      ""customData"": {
                        ""key1"": ""value1"",
                        ""key2"": ""value2""
                      }
                    }
                  ],
                  ""status"": ""SUCCESSFUL""
                }
              ]
            }";

        SetUpGetRequest(GET_DIALOG_RECORDINGS.Replace("{dialogId}", givenDialogId), 200, givenResponse,
            givenQueryParameters);

        var api = new CallsApi(configuration);

        var expectedResponse = new CallsDialogRecordingResponse(
            "034e622a-cc7e-456d-8a10-0ba43b11aa5e",
            platform: new Platform(
                applicationId: "61c060db2675060027d8c7a6"
            ),
            composedFiles: new List<CallsRecordingFile>
            {
                new(
                    "b72cde3c-7d9c-4a5c-8e48-5a947244c013",
                    "d8d84155-3831-43fb-91c9-bb897149a79d_41792030001_1652725357412_recording.wav",
                    CallsFileFormat.Wav,
                    67564,
                    DateTimeOffset.Parse("2022-01-01T00:00:00.250+0000"),
                    10,
                    DateTimeOffset.Parse("2021-12-31T23:59:50.100+0000"),
                    DateTimeOffset.Parse("2022-01-01T00:00:00.100+0000"),
                    CallsRecordingFileLocation.Hosted,
                    customData: new Dictionary<string, string>
                    {
                        { "key1", "value1" },
                        { "key2", "value2" }
                    }
                )
            },
            callRecordings: new List<CallRecording>
            {
                new(
                    "d8d84155-3831-43fb-91c9-bb897149a79d",
                    new CallsPhoneEndpoint(
                        "44790123456"
                    ),
                    CallDirection.Inbound,
                    new List<CallsRecordingFile>
                    {
                        new(
                            "d8d84155-3831-43fb-91c9-bb897149a79d",
                            "d8d84155-3831-43fb-91c9-bb897149a79d_1652725357412.wav",
                            CallsFileFormat.Wav,
                            67564,
                            DateTimeOffset.Parse("2022-01-01T00:00:00.250+0000"),
                            10,
                            DateTimeOffset.Parse("2021-12-31T23:59:50.100+0000"),
                            DateTimeOffset.Parse("2022-01-01T00:00:00.100+0000"),
                            CallsRecordingFileLocation.Hosted,
                            customData: new Dictionary<string, string>
                            {
                                { "key1", "value1" },
                                { "key2", "value2" }
                            }
                        )
                    },
                    CallsRecordingStatus.Successful
                ),
                new(
                    "3ad8805e-d401-424e-9b03-e02a2016a5e2",
                    new CallsPhoneEndpoint(
                        "44790123456"
                    ),
                    CallDirection.Inbound,
                    new List<CallsRecordingFile>
                    {
                        new(
                            "d8d84155-3831-43fb-91c9-bb897149a79d",
                            "d8d84155-3831-43fb-91c9-bb897149a79d_1652725357412.wav",
                            CallsFileFormat.Wav,
                            67564,
                            DateTimeOffset.Parse("2022-01-01T00:00:00.250+0000"),
                            10,
                            DateTimeOffset.Parse("2021-12-31T23:59:50.100+0000"),
                            DateTimeOffset.Parse("2022-01-01T00:00:00.100+0000"),
                            CallsRecordingFileLocation.Hosted,
                            customData: new Dictionary<string, string>
                            {
                                { "key1", "value1" },
                                { "key2", "value2" }
                            }
                        )
                    },
                    CallsRecordingStatus.Successful
                )
            }
        );

        var response = api.GetDialogRecordings(givenDialogId, givenLocation);

        Assert.AreEqual(expectedResponse, response);
    }

    [TestMethod]
    public void ShouldDeleteDialogRecordings()
    {
        var givenDialogId = "034e622a-cc7e-456d-8a10-0ba43b11aa5e";
        var givenLocation = CallsRecordingLocation.Frankfurt;
        var givenQueryParameters = new Dictionary<string, string>
        {
            { "location", givenLocation.ToString() }
        };

        var givenResponse = @"
            {
              ""dialogId"": ""034e622a-cc7e-456d-8a10-0ba43b11aa5e"",
              ""platform"": {
                ""applicationId"": ""61c060db2675060027d8c7a6""
              },
              ""composedFiles"": [
                {
                  ""id"": ""b72cde3c-7d9c-4a5c-8e48-5a947244c013"",
                  ""name"": ""d8d84155-3831-43fb-91c9-bb897149a79d_41792030001_1652725357412_recording.wav"",
                  ""fileFormat"": ""WAV"",
                  ""size"": 67564,
                  ""creationTime"": ""2022-01-01T00:00:00.250+0000"",
                  ""duration"": 10,
                  ""startTime"": ""2021-12-31T23:59:50.100+0000"",
                  ""endTime"": ""2022-01-01T00:00:00.100+0000"",
                  ""location"": ""HOSTED"",
                  ""customData"": {
                    ""key1"": ""value1"",
                    ""key2"": ""value2""
                  }
                }
              ],
              ""callRecordings"": [
                {
                  ""callId"": ""d8d84155-3831-43fb-91c9-bb897149a79d"",
                  ""endpoint"": {
                    ""type"": ""PHONE"",
                    ""phoneNumber"": ""44790123456""
                  },
                  ""direction"": ""INBOUND"",
                  ""files"": [
                    {
                      ""id"": ""d8d84155-3831-43fb-91c9-bb897149a79d"",
                      ""name"": ""d8d84155-3831-43fb-91c9-bb897149a79d_1652725357412.wav"",
                      ""fileFormat"": ""WAV"",
                      ""size"": 67564,
                      ""creationTime"": ""2022-01-01T00:00:00.250+0000"",
                      ""duration"": 10,
                      ""startTime"": ""2021-12-31T23:59:50.100+0000"",
                      ""endTime"": ""2022-01-01T00:00:00.100+0000"",
                      ""location"": ""HOSTED"",
                      ""customData"": {
                        ""key1"": ""value1"",
                        ""key2"": ""value2""
                      }
                    }
                  ],
                  ""status"": ""SUCCESSFUL""
                },
                {
                  ""callId"": ""3ad8805e-d401-424e-9b03-e02a2016a5e2"",
                  ""endpoint"": {
                    ""type"": ""PHONE"",
                    ""phoneNumber"": ""44790123456""
                  },
                  ""direction"": ""INBOUND"",
                  ""files"": [
                    {
                      ""id"": ""d8d84155-3831-43fb-91c9-bb897149a79d"",
                      ""name"": ""d8d84155-3831-43fb-91c9-bb897149a79d_1652725357412.wav"",
                      ""fileFormat"": ""WAV"",
                      ""size"": 67564,
                      ""creationTime"": ""2022-01-01T00:00:00.250+0000"",
                      ""duration"": 10,
                      ""startTime"": ""2021-12-31T23:59:50.100+0000"",
                      ""endTime"": ""2022-01-01T00:00:00.100+0000"",
                      ""location"": ""HOSTED"",
                      ""customData"": {
                        ""key1"": ""value1"",
                        ""key2"": ""value2""
                      }
                    }
                  ],
                  ""status"": ""SUCCESSFUL""
                }
              ]
            }";

        SetUpDeleteRequest(DELETE_DIALOG_RECORDINGS.Replace("{dialogId}", givenDialogId), 200,
            expectedResponse: givenResponse, givenParameters: givenQueryParameters);

        var api = new CallsApi(configuration);

        var expectedResponse = new CallsDialogRecordingResponse(
            "034e622a-cc7e-456d-8a10-0ba43b11aa5e",
            platform: new Platform(
                applicationId: "61c060db2675060027d8c7a6"
            ),
            composedFiles: new List<CallsRecordingFile>
            {
                new(
                    "b72cde3c-7d9c-4a5c-8e48-5a947244c013",
                    "d8d84155-3831-43fb-91c9-bb897149a79d_41792030001_1652725357412_recording.wav",
                    CallsFileFormat.Wav,
                    67564,
                    DateTimeOffset.Parse("2022-01-01T00:00:00.250+0000"),
                    10,
                    DateTimeOffset.Parse("2021-12-31T23:59:50.100+0000"),
                    DateTimeOffset.Parse("2022-01-01T00:00:00.100+0000"),
                    CallsRecordingFileLocation.Hosted,
                    customData: new Dictionary<string, string>
                    {
                        { "key1", "value1" },
                        { "key2", "value2" }
                    }
                )
            },
            callRecordings: new List<CallRecording>
            {
                new(
                    "d8d84155-3831-43fb-91c9-bb897149a79d",
                    new CallsPhoneEndpoint(
                        "44790123456"
                    ),
                    CallDirection.Inbound,
                    new List<CallsRecordingFile>
                    {
                        new(
                            "d8d84155-3831-43fb-91c9-bb897149a79d",
                            "d8d84155-3831-43fb-91c9-bb897149a79d_1652725357412.wav",
                            CallsFileFormat.Wav,
                            67564,
                            DateTimeOffset.Parse("2022-01-01T00:00:00.250+0000"),
                            10,
                            DateTimeOffset.Parse("2021-12-31T23:59:50.100+0000"),
                            DateTimeOffset.Parse("2022-01-01T00:00:00.100+0000"),
                            CallsRecordingFileLocation.Hosted,
                            customData: new Dictionary<string, string>
                            {
                                { "key1", "value1" },
                                { "key2", "value2" }
                            }
                        )
                    },
                    CallsRecordingStatus.Successful
                ),
                new(
                    "3ad8805e-d401-424e-9b03-e02a2016a5e2",
                    new CallsPhoneEndpoint(
                        "44790123456"
                    ),
                    CallDirection.Inbound,
                    new List<CallsRecordingFile>
                    {
                        new(
                            "d8d84155-3831-43fb-91c9-bb897149a79d",
                            "d8d84155-3831-43fb-91c9-bb897149a79d_1652725357412.wav",
                            CallsFileFormat.Wav,
                            67564,
                            DateTimeOffset.Parse("2022-01-01T00:00:00.250+0000"),
                            10,
                            DateTimeOffset.Parse("2021-12-31T23:59:50.100+0000"),
                            DateTimeOffset.Parse("2022-01-01T00:00:00.100+0000"),
                            CallsRecordingFileLocation.Hosted,
                            customData: new Dictionary<string, string>
                            {
                                { "key1", "value1" },
                                { "key2", "value2" }
                            }
                        )
                    },
                    CallsRecordingStatus.Successful
                )
            }
        );

        var response = api.DeleteDialogRecordings(givenDialogId, givenLocation);

        Assert.AreEqual(expectedResponse, response);
    }

    [TestMethod]
    public void ShouldComposeDialogRecordingOnCalls()
    {
        var givenDialogId = "034e622a-cc7e-456d-8a10-0ba43b11aa5e";
        var givenLocation = CallsRecordingLocation.Frankfurt;
        var givenQueryParameters = new Dictionary<string, string>
        {
            { "location", givenLocation.ToString() }
        };

        var givenRequest = @"
            {
              ""deleteCallRecordings"": true,
              ""multiChannel"": {
                ""enabled"": true
              }
            }";

        var givenResponse = @"
            {
              ""status"": ""PENDING""
            }";

        SetUpPostRequest(COMPOSE_DIALOG_RECORDING.Replace("{dialogId}", givenDialogId), 200, givenRequest,
            givenResponse, givenQueryParameters);

        var api = new CallsApi(configuration);

        var request = new CallsOnDemandComposition(
            true,
            new CallsMultiChannel(
                true
            )
        );

        var expectedResponse = new CallsActionResponse(
            CallsActionStatus.Pending
        );

        var response = api.ComposeDialogRecording(givenDialogId, request, givenLocation);

        Assert.AreEqual(expectedResponse, response);
    }

    [TestMethod]
    public void ShouldDeleteRecordingFile()
    {
        var givenFileId = "b72cde3c-7d9c-4a5c-8e48-5a947244c013";
        var givenLocation = CallsRecordingLocation.Frankfurt;
        var givenQueryParameters = new Dictionary<string, string>
        {
            { "location", givenLocation.ToString() }
        };

        var givenResponse = @"
            {
              ""id"": ""b72cde3c-7d9c-4a5c-8e48-5a947244c013"",
              ""name"": ""b72cde3c-7d9c-4a5c-8e48-5a947244c013_1652725357412.wav"",
              ""fileFormat"": ""WAV"",
              ""size"": 67564,
              ""creationTime"": ""2022-01-01T00:00:00.250+0000"",
              ""duration"": 10,
              ""startTime"": ""2021-12-31T23:59:50.100+0000"",
              ""endTime"": ""2022-01-01T00:00:00.100+0000"",
              ""location"": ""HOSTED"",
              ""customData"": {
                ""key1"": ""value1"",
                ""key2"": ""value2""
              }
            }";

        SetUpDeleteRequest(DELETE_RECORDING_FILE.Replace("{fileId}", givenFileId), 200, expectedResponse: givenResponse,
            givenParameters: givenQueryParameters);

        var api = new CallsApi(configuration);

        var expectedResponse = new CallsRecordingFile(
            "b72cde3c-7d9c-4a5c-8e48-5a947244c013",
            "b72cde3c-7d9c-4a5c-8e48-5a947244c013_1652725357412.wav",
            CallsFileFormat.Wav,
            67564,
            DateTimeOffset.Parse("2022-01-01T00:00:00.250+0000"),
            10,
            DateTimeOffset.Parse("2021-12-31T23:59:50.100+0000"),
            DateTimeOffset.Parse("2022-01-01T00:00:00.100+0000"),
            CallsRecordingFileLocation.Hosted,
            customData: new Dictionary<string, string>
            {
                { "key1", "value1" },
                { "key2", "value2" }
            }
        );

        var response = api.DeleteRecordingFile(givenFileId, givenLocation);

        Assert.AreEqual(expectedResponse, response);
    }

    [TestMethod]
    public void ShouldGetMediaStreamConfigs()
    {
        var givenPage = 0;
        var givenSize = 2;
        var givenQueryParameters = new Dictionary<string, string>
        {
            { "page", givenPage.ToString() },
            { "size", givenSize.ToString() }
        };

        var givenResponse = @"
            {
              ""results"": [
                {
                  ""id"": ""63467c6e2885a5389ba11d80"",
                  ""type"": ""MEDIA_STREAMING"",
                  ""name"": ""Media-stream config"",
                  ""url"": ""ws://example-web-socket.com:3001""
                },
                {
                  ""id"": ""63467c6e2885a5389ba11d81"",
                  ""type"": ""WEBSOCKET_ENDPOINT"",
                  ""name"": ""Media-stream config"",
                  ""url"": ""ws://example-web-socket.com:3001"",
                  ""sampleRate"": ""8000""
                }
              ],
              ""paging"": {
                ""page"": 0,
                ""size"": 2,
                ""totalPages"": 1,
                ""totalResults"": 2
              }
            }";

        SetUpGetRequest(GET_MEDIA_STREAM_CONFIGS, 200, givenResponse, givenQueryParameters);

        var api = new CallsApi(configuration);

        var expectedResponse = new CallsMediaStreamConfigPage(
            new List<CallsMediaStreamConfigResponse>
            {
                new CallsMediaStreamingConfigResponse(
                    "63467c6e2885a5389ba11d80",
                    name: "Media-stream config",
                    url: "ws://example-web-socket.com:3001"
                ),
                new CallsWebsocketEndpointConfigResponse(
                    id: "63467c6e2885a5389ba11d81",
                    name: "Media-stream config",
                    url: "ws://example-web-socket.com:3001",
                    sampleRate: "8000"
                )
            },
            new PageInfo(
                0,
                2,
                1,
                2
            )
        );

        var response = api.GetMediaStreamConfigs(0, 2);

        Assert.AreEqual(expectedResponse, response);
    }

    [TestMethod]
    public void ShouldCreateMediaStreamConfiguration()
    {
        var givenRequest = @"
            {
              ""type"": ""MEDIA_STREAMING"",
              ""name"": ""Media-stream config"",
              ""url"": ""ws://example-web-socket.com:3001"",
              ""securityConfig"": {
                ""username"": ""my-username"",
                ""password"": ""my-password"",
                ""type"": ""BASIC""
              }
            }";

        var givenResponse = @"
            {
              ""id"": ""63467c6e2885a5389ba11d80"",
              ""type"": ""MEDIA_STREAMING"",
              ""name"": ""Media-stream config"",
              ""url"": ""ws://example-web-socket.com:3001""
            }";

        SetUpPostRequest(CREATE_MEDIA_STREAM_CONFIG, 201, givenRequest, givenResponse);

        var api = new CallsApi(configuration);

        var request = new CallsMediaStreamingConfigRequest(
            name: "Media-stream config",
            url: "ws://example-web-socket.com:3001",
            securityConfig: new BasicSecurityConfig(
                "my-username",
                "my-password"
            )
        );

        var expectedResponse = new CallsMediaStreamConfigResponse(
            "63467c6e2885a5389ba11d80",
            CallsResponseMediaStreamConfigType.MediaStreaming,
            "Media-stream config",
            "ws://example-web-socket.com:3001"
        );

        var response = api.CreateMediaStreamConfig(request);

        Assert.AreEqual(expectedResponse, response);
    }

    [TestMethod]
    public void ShouldGetMediaStreamConfiguration()
    {
        var givenMediaStreamConfigId = "63467c6e2885a5389ba11d80";

        var givenResponse = @"
            {
              ""id"": ""63467c6e2885a5389ba11d80"",
              ""type"": ""MEDIA_STREAMING"",
              ""name"": ""Media-stream config"",
              ""url"": ""ws://example-web-socket.com:3001""
            }";

        SetUpGetRequest(GET_MEDIA_STREAM_CONFIG.Replace("{mediaStreamConfigId}", givenMediaStreamConfigId), 200,
            givenResponse);

        var api = new CallsApi(configuration);

        var expectedResponse = new CallsMediaStreamConfigResponse(
            "63467c6e2885a5389ba11d80",
            CallsResponseMediaStreamConfigType.MediaStreaming,
            "Media-stream config",
            "ws://example-web-socket.com:3001"
        );

        var response = api.GetMediaStreamConfig(givenMediaStreamConfigId);

        Assert.AreEqual(expectedResponse, response);
    }

    [TestMethod]
    public void ShouldUpdateMediaStreamConfiguration()
    {
        var givenMediaStreamConfigId = "63467c6e2885a5389ba11d80";

        var givenRequest = @"
            {
              ""type"": ""MEDIA_STREAMING"",
              ""name"": ""Media-stream config"",
              ""url"": ""ws://example-web-socket.com:3001"",
              ""securityConfig"": {
                ""username"": ""my-username"",
                ""password"": ""my-password"",
                ""type"": ""BASIC""
              }
            }";

        var givenResponse = @"
            {
              ""id"": ""63467c6e2885a5389ba11d80"",
              ""type"": ""MEDIA_STREAMING"",
              ""name"": ""Media-stream config"",
              ""url"": ""ws://example-web-socket.com:3001""
            }";

        SetUpPutRequest(UPDATE_MEDIA_STREAM_CONFIG.Replace("{mediaStreamConfigId}", givenMediaStreamConfigId), 200,
            givenRequest, givenResponse);

        var api = new CallsApi(configuration);

        var request = new CallsMediaStreamingConfigRequest(
            name: "Media-stream config",
            url: "ws://example-web-socket.com:3001",
            securityConfig: new BasicSecurityConfig(
                "my-username",
                "my-password"
            )
        );

        var expectedResponse = new CallsMediaStreamConfigResponse(
            "63467c6e2885a5389ba11d80",
            CallsResponseMediaStreamConfigType.MediaStreaming,
            "Media-stream config",
            "ws://example-web-socket.com:3001"
        );

        var response = api.UpdateMediaStreamConfig(givenMediaStreamConfigId, request);

        Assert.AreEqual(expectedResponse, response);
    }

    [TestMethod]
    public void ShouldDeleteMediaStreamConfiguration()
    {
        var givenMediaStreamConfigId = "63467c6e2885a5389ba11d80";

        var givenResponse = @"
            {
              ""id"": ""63467c6e2885a5389ba11d80"",
              ""type"": ""MEDIA_STREAMING"",
              ""name"": ""Media-stream config"",
              ""url"": ""ws://example-web-socket.com:3001""
            }";

        SetUpDeleteRequest(DELETE_MEDIA_STREAM_CONFIG.Replace("{mediaStreamConfigId}", givenMediaStreamConfigId), 200,
            expectedResponse: givenResponse);

        var api = new CallsApi(configuration);

        var expectedResponse = new CallsMediaStreamConfigResponse(
            "63467c6e2885a5389ba11d80",
            CallsResponseMediaStreamConfigType.MediaStreaming,
            "Media-stream config",
            "ws://example-web-socket.com:3001"
        );

        var response = api.DeleteMediaStreamConfig(givenMediaStreamConfigId);

        Assert.AreEqual(expectedResponse, response);
    }

    [TestMethod]
    public void ShouldCreateBulkCalls()
    {
        var givenRequest = @"
            {
              ""bulkId"": ""46ab0413-448f-4153-ada9-b68b14242dc3"",
              ""callsConfigurationId"": ""dc5942707c704551a00cd2ea"",
              ""platform"": {
                ""applicationId"": ""61c060db2675060027d8c7a6""
              },
              ""items"": [
                {
                  ""from"": ""41793026834"",
                  ""callRequests"": [
                    {
                      ""externalId"": ""your-external-id-1"",
                      ""endpoint"": {
                        ""phoneNumber"": ""41792036727"",
                        ""type"": ""PHONE""
                      }
                    },
                    {
                      ""externalId"": ""your-external-id-2"",
                      ""endpoint"": {
                        ""phoneNumber"": ""41792036728"",
                        ""type"": ""PHONE""
                      }
                    },
                    {
                      ""externalId"": ""your-external-id-3"",
                      ""endpoint"": {
                        ""phoneNumber"": ""41792036729"",
                        ""type"": ""PHONE""
                      }
                    }
                  ],
                  ""recording"": {
                    ""recordingType"": ""AUDIO""
                  },
                  ""machineDetection"": {
                    ""enabled"": true
                  },
                  ""maxDuration"": 28000,
                  ""connectTimeout"": 20000,
                  ""callRate"": {
                    ""maxCalls"": 10,
                    ""timeUnit"": ""MINUTES""
                  },
                  ""validityPeriod"": 60,
                  ""retryOptions"": {
                    ""minWaitPeriod"": 5,
                    ""maxWaitPeriod"": 10,
                    ""maxAttempts"": 5
                  },
                  ""schedulingOptions"": {
                    ""startTime"": ""2022-01-01T00:00:00.100+00:00"",
                    ""callingTimeWindow"": {
                      ""from"": {
                        ""hour"": 9,
                        ""minute"": 0
                      },
                      ""to"": {
                        ""hour"": 17,
                        ""minute"": 0
                      },
                      ""days"": [
                        ""MONDAY"",
                        ""TUESDAY"",
                        ""WEDNESDAY"",
                        ""THURSDAY"",
                        ""FRIDAY""
                      ]
                    }
                  }
                }
              ]
            }";

        var givenResponse = @"
            {
              ""bulkId"": ""46ab0413-448f-4153-ada9-b68b14242dc3"",
              ""calls"": [
                {
                  ""callsConfigurationId"": ""dc5942707c704551a00cd2ea"",
                  ""platform"": {
                    ""applicationId"": ""61c060db2675060027d8c7a6""
                  },
                  ""callId"": ""266f8375-33d3-482f-a258-51e86b5ae9ac"",
                  ""externalId"": ""your-external-id-1"",
                  ""from"": ""41793026834"",
                  ""endpoint"": {
                    ""phoneNumber"": ""41792036727"",
                    ""type"": ""PHONE""
                  },
                  ""status"": ""PENDING""
                },
                {
                  ""callsConfigurationId"": ""dc5942707c704551a00cd2ea"",
                  ""platform"": {
                    ""applicationId"": ""61c060db2675060027d8c7a6""
                  },
                  ""callId"": ""366f8375-33d3-482f-a258-51e86b5ae9ad"",
                  ""externalId"": ""your-external-id-2"",
                  ""from"": ""41793026834"",
                  ""endpoint"": {
                    ""phoneNumber"": ""41792036728"",
                    ""type"": ""PHONE""
                  },
                  ""status"": ""PENDING""
                },
                {
                  ""callsConfigurationId"": ""dc5942707c704551a00cd2ea"",
                  ""platform"": {
                    ""applicationId"": ""61c060db2675060027d8c7a6""
                  },
                  ""callId"": ""466f8375-33d3-482f-a258-51e86b5ae9ae"",
                  ""externalId"": ""your-external-id-3"",
                  ""from"": ""41793026834"",
                  ""endpoint"": {
                    ""phoneNumber"": ""41792036729"",
                    ""type"": ""PHONE""
                  },
                  ""status"": ""PENDING""
                }
              ]
            }";

        SetUpPostRequest(CREATE_BULK, 201, givenRequest, givenResponse);

        var api = new CallsApi(configuration);

        var request = new CallBulkRequest(
            "46ab0413-448f-4153-ada9-b68b14242dc3",
            "dc5942707c704551a00cd2ea",
            new Platform(
                applicationId: "61c060db2675060027d8c7a6"
            ),
            new List<CallsBulkItem>
            {
                new(
                    "41793026834",
                    new List<CallsBulkCallRequest>
                    {
                        new(
                            "your-external-id-1",
                            new CallsBulkPhoneEndpoint(
                                "41792036727"
                            )
                        ),
                        new(
                            "your-external-id-2",
                            new CallsBulkPhoneEndpoint(
                                "41792036728"
                            )
                        ),
                        new(
                            "your-external-id-3",
                            new CallsBulkPhoneEndpoint(
                                "41792036729"
                            )
                        )
                    },
                    new CallRecordingRequest(
                        CallsRecordingType.Audio
                    ),
                    new CallsMachineDetectionRequest(
                        true
                    ),
                    28000,
                    20000,
                    new CallRate(
                        10,
                        CallsTimeUnit.Minutes
                    ),
                    60,
                    new CallsRetryOptions(
                        5,
                        10,
                        5
                    ),
                    new CallsSchedulingOptions(
                        DateTimeOffset.Parse("2022-01-01T00:00:00.100+00:00"),
                        new DeliveryTimeWindow(
                            from: new DeliveryTime(
                                9
                            ),
                            to: new DeliveryTime(
                                17
                            ),
                            days: new List<DeliveryDay>
                            {
                                DeliveryDay.Monday,
                                DeliveryDay.Tuesday,
                                DeliveryDay.Wednesday,
                                DeliveryDay.Thursday,
                                DeliveryDay.Friday
                            }
                        )
                    )
                )
            }
        );

        var expectedResponse = new CallBulkResponse(
            "46ab0413-448f-4153-ada9-b68b14242dc3",
            new List<CallsBulkCall>
            {
                new(
                    "dc5942707c704551a00cd2ea",
                    new Platform(
                        applicationId: "61c060db2675060027d8c7a6"
                    ),
                    "266f8375-33d3-482f-a258-51e86b5ae9ac",
                    "your-external-id-1",
                    "41793026834",
                    new CallsBulkPhoneEndpoint(
                        "41792036727"
                    ),
                    CallsActionStatus.Pending
                ),
                new(
                    "dc5942707c704551a00cd2ea",
                    new Platform(
                        applicationId: "61c060db2675060027d8c7a6"
                    ),
                    "366f8375-33d3-482f-a258-51e86b5ae9ad",
                    "your-external-id-2",
                    "41793026834",
                    new CallsBulkPhoneEndpoint(
                        "41792036728"
                    ),
                    CallsActionStatus.Pending
                ),
                new(
                    "dc5942707c704551a00cd2ea",
                    new Platform(
                        applicationId: "61c060db2675060027d8c7a6"
                    ),
                    "466f8375-33d3-482f-a258-51e86b5ae9ae",
                    "your-external-id-3",
                    "41793026834",
                    new CallsBulkPhoneEndpoint(
                        "41792036729"
                    ),
                    CallsActionStatus.Pending
                )
            }
        );

        var response = api.CreateBulk(request);

        Assert.AreEqual(expectedResponse, response);
    }

    [TestMethod]
    public void ShouldGetBulkStatus()
    {
        var givenBulkId = "46ab0413-448f-4153-ada9-b68b14242dc3";

        var givenResponse = @"
            {
              ""bulkId"": ""46ab0413-448f-4153-ada9-b68b14242dc3"",
              ""startTime"": ""2025-02-19T13:31:29Z"",
              ""status"": ""PENDING""
            }";

        SetUpGetRequest(GET_BULK_STATUS.Replace("{bulkId}", givenBulkId), 200, givenResponse);

        var api = new CallsApi(configuration);

        var expectedResponse = new CallBulkStatus(
            "46ab0413-448f-4153-ada9-b68b14242dc3",
            DateTimeOffset.Parse("2025-02-19T13:31:29Z"),
            CallsStatus.Pending
        );

        var response = api.GetBulkStatus(givenBulkId);

        Assert.AreEqual(expectedResponse, response);
    }

    [TestMethod]
    public void ShouldRescheduleBulk()
    {
        var givenBulkId = "46ab0413-448f-4153-ada9-b68b14242dc3";

        var givenRequest = @"
            {
              ""startTime"": ""2025-02-19T12:44:30.000+00:00""
            }";

        var givenResponse = @"
            {
              ""bulkId"": ""46ab0413-448f-4153-ada9-b68b14242dc3"",
              ""startTime"": ""2025-02-19T12:44:30Z"",
              ""status"": ""PENDING""
            }";

        SetUpPostRequest(RESCHEDULE_BULK.Replace("{bulkId}", givenBulkId), 200, givenRequest, givenResponse);

        var api = new CallsApi(configuration);

        var request = new CallsRescheduleRequest(
            DateTimeOffset.Parse("2025-02-19T12:44:30Z")
        );

        var expectedResponse = new CallBulkStatus(
            "46ab0413-448f-4153-ada9-b68b14242dc3",
            DateTimeOffset.Parse("2025-02-19T12:44:30Z"),
            CallsStatus.Pending
        );

        var response = api.RescheduleBulk(givenBulkId, request);

        Assert.AreEqual(expectedResponse, response);
    }

    [TestMethod]
    public void ShouldPauseBulk()
    {
        var givenBulkId = "46ab0413-448f-4153-ada9-b68b14242dc3";

        var givenResponse = @"
            {
              ""bulkId"": ""46ab0413-448f-4153-ada9-b68b14242dc3"",
              ""startTime"": ""2025-02-19T12:37:15Z"",
              ""status"": ""PENDING""
            }";

        SetUpPostRequest(PAUSE_BULK.Replace("{bulkId}", givenBulkId), 200, expectedResponse: givenResponse);

        var api = new CallsApi(configuration);

        var expectedResponse = new CallBulkStatus(
            "46ab0413-448f-4153-ada9-b68b14242dc3",
            DateTimeOffset.Parse("2025-02-19T12:37:15Z"),
            CallsStatus.Pending
        );

        var response = api.PauseBulk(givenBulkId);

        Assert.AreEqual(expectedResponse, response);
    }

    [TestMethod]
    public void ShouldResumeBulk()
    {
        var givenBulkId = "46ab0413-448f-4153-ada9-b68b14242dc3";

        var givenResponse = @"
            {
              ""bulkId"": ""46ab0413-448f-4153-ada9-b68b14242dc3"",
              ""startTime"": ""2025-02-19T12:57:56Z"",
              ""status"": ""PENDING""
            }";

        SetUpPostRequest(RESUME_BULK.Replace("{bulkId}", givenBulkId), 200, expectedResponse: givenResponse);

        var api = new CallsApi(configuration);

        var expectedResponse = new CallBulkStatus(
            "46ab0413-448f-4153-ada9-b68b14242dc3",
            DateTimeOffset.Parse("2025-02-19T12:57:56Z"),
            CallsStatus.Pending
        );

        var response = api.ResumeBulk(givenBulkId);

        Assert.AreEqual(expectedResponse, response);
    }

    [TestMethod]
    public void ShouldCancelBulk()
    {
        var givenBulkId = "46ab0413-448f-4153-ada9-b68b14242dc3";

        var givenResponse = @"
            {
              ""bulkId"": ""46ab0413-448f-4153-ada9-b68b14242dc3"",
              ""startTime"": ""2025-02-19T12:38:13Z"",
              ""status"": ""PENDING""
            }";

        SetUpPostRequest(CANCEL_BULK.Replace("{bulkId}", givenBulkId), 200, expectedResponse: givenResponse);

        var api = new CallsApi(configuration);

        var expectedResponse = new CallBulkStatus(
            "46ab0413-448f-4153-ada9-b68b14242dc3",
            DateTimeOffset.Parse("2025-02-19T12:38:13Z"),
            CallsStatus.Pending
        );

        var response = api.CancelBulk(givenBulkId);

        Assert.AreEqual(expectedResponse, response);
    }

    [TestMethod]
    public void ShouldGetCallsConfigurations()
    {
        var givenPage = 0;
        var givenSize = 1;
        var givenQueryParameters = new Dictionary<string, string>
        {
            { "page", givenPage.ToString() },
            { "size", givenSize.ToString() }
        };

        var givenResponse = @"
            {
              ""results"": [
                {
                  ""id"": ""63467c6e2885a5389ba11d80"",
                  ""name"": ""Calls configuration""
                }
              ],
              ""paging"": {
                ""page"": 0,
                ""size"": 1,
                ""totalPages"": 1,
                ""totalResults"": 1
              }
            }";

        SetUpGetRequest(CALLS_CONFIGURATIONS, 200, givenResponse, givenQueryParameters);

        var api = new CallsApi(configuration);

        var expectedResponse = new CallsConfigurationPage(
            new List<CallsConfigurationResponse>
            {
                new(
                    "63467c6e2885a5389ba11d80",
                    "Calls configuration"
                )
            },
            new PageInfo(
                0,
                1,
                1,
                1
            )
        );

        var response = api.GetCallsConfigurations(givenPage, givenSize);

        Assert.AreEqual(expectedResponse, response);
    }

    [TestMethod]
    public void ShouldCreateCallsConfiguration()
    {
        var givenRequest = @"
            {
              ""id"": ""63467c6e2885a5389ba11d80"",
              ""name"": ""Calls configuration""
            }";

        var givenResponse = @"
            {
              ""id"": ""63467c6e2885a5389ba11d80"",
              ""name"": ""Calls configuration""
            }";

        SetUpPostRequest(CALLS_CONFIGURATIONS, 201, givenRequest, givenResponse);

        var api = new CallsApi(configuration);

        var request = new CallsConfigurationCreateRequest(
            "63467c6e2885a5389ba11d80",
            "Calls configuration"
        );

        var expectedResponse = new CallsConfigurationResponse(
            "63467c6e2885a5389ba11d80",
            "Calls configuration"
        );

        var response = api.CreateCallsConfiguration(request);

        Assert.AreEqual(expectedResponse, response);
    }

    [TestMethod]
    public void ShouldGetCallsConfiguration()
    {
        var givenCallsConfigurationId = "63467c6e2885a5389ba11d80";

        var givenResponse = @"
            {
              ""id"": ""63467c6e2885a5389ba11d80"",
              ""name"": ""Calls configuration""
            }";

        SetUpGetRequest(CALLS_CONFIGURATION.Replace("{callsConfigurationId}", givenCallsConfigurationId), 200,
            givenResponse);

        var api = new CallsApi(configuration);

        var expectedResponse = new CallsConfigurationResponse(
            "63467c6e2885a5389ba11d80",
            "Calls configuration"
        );

        var response = api.GetCallsConfiguration(givenCallsConfigurationId);

        Assert.AreEqual(expectedResponse, response);
    }

    [TestMethod]
    public void ShouldUpdateCallsConfiguration()
    {
        var givenCallsConfigurationId = "63467c6e2885a5389ba11d80";

        var givenRequest = @"
            {
              ""name"": ""Calls configuration""
            }";

        var givenResponse = @"
            {
              ""id"": ""63467c6e2885a5389ba11d80"",
              ""name"": ""Calls configuration""
            }";

        SetUpPutRequest(CALLS_CONFIGURATION.Replace("{callsConfigurationId}", givenCallsConfigurationId), 200,
            givenRequest, givenResponse);

        var api = new CallsApi(configuration);

        var request = new CallsConfigurationUpdateRequest(
            "Calls configuration"
        );

        var expectedResponse = new CallsConfigurationResponse(
            "63467c6e2885a5389ba11d80",
            "Calls configuration"
        );

        var response = api.UpdateCallsConfiguration(givenCallsConfigurationId, request);

        Assert.AreEqual(expectedResponse, response);
    }

    [TestMethod]
    public void ShouldDeleteCallsConfiguration()
    {
        var givenCallsConfigurationId = "63467c6e2885a5389ba11d80";

        var givenResponse = @"
            {
              ""id"": ""63467c6e2885a5389ba11d80"",
              ""name"": ""Calls configuration""
            }";

        SetUpDeleteRequest(CALLS_CONFIGURATION.Replace("{callsConfigurationId}", givenCallsConfigurationId), 200,
            expectedResponse: givenResponse);

        var api = new CallsApi(configuration);

        var expectedResponse = new CallsConfigurationResponse(
            "63467c6e2885a5389ba11d80",
            "Calls configuration"
        );

        var response = api.DeleteCallsConfiguration(givenCallsConfigurationId);

        Assert.AreEqual(expectedResponse, response);
    }
}