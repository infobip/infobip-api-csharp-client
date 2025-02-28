using System.Text;
using Infobip.Api.Client.Api;
using Infobip.Api.Client.Client;
using Infobip.Api.Client.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace ApiClient.Tests.Api;

[TestClass]
public class VoiceApiTest : ApiTest
{
    protected const string VOICE_SINGLE_ENDPOINT = "/tts/3/single";
    protected const string VOICE_MULTI_ENDPOINT = "/tts/3/multi";
    protected const string VOICE_ADVANCED_ENDPOINT = "/tts/3/advanced";
    protected const string VOICE_LANGUAGE_ENDPOINT = "/tts/3/voices/{language}";
    protected const string VOICE_BULKS_ENDPOINT = "/tts/3/bulks";
    protected const string VOICE_BULKS_STATUS_ENDPOINT = "/tts/3/bulks/status";
    protected const string VOICE_REPORTS_ENDPOINT = "/voice/1/reports";
    protected const string VOICE_LOGS_ENDPOINT = "/tts/3/logs";
    protected const string VOICE_IVR_SCENARIOS_ENDPOINT = "/voice/ivr/1/scenarios";
    protected const string VOICE_IVR_SCENARIO_ENDPOINT = "/voice/ivr/1/scenarios/{id}";
    protected const string VOICE_IVR_MESSAGE_ENDPOINT = "/voice/ivr/1/messages";
    protected const string VOICE_IVR_FILES_ENDPOINT = "/voice/ivr/1/files";
    protected const string VOICE_IVR_FILE_ENDPOINT = "/voice/ivr/1/files/{id}";

    protected const string DATE_FORMAT = "yyyy-MM-ddTHH:mm:ss.fffzzz";


    [TestMethod]
    public void ShouldSendSingeVoiceMessage()
    {
        var expectedBulkId = "4fda521a-c680-470d-b134-83d468f7ac80";
        var expectedTo = "41793026727";
        var expectedGroupId = 1;
        var expectedGroupName = "PENDING";
        var expectedId = 26;
        var expectedName = "PENDING_ACCEPTED";
        var expectedDescription = "Message accepted, pending for delivery.";
        var expectedMessageId = "2250be2d4219-3af1-78856-aabe-1362af1edfd2";

        var expectedResponse = $@"
            {{
              ""bulkId"": ""{expectedBulkId}"",
              ""messages"": [
                {{
                  ""to"": ""{expectedTo}"",
                  ""status"": {{
                    ""groupId"": {expectedGroupId},
                    ""groupName"": ""{expectedGroupName}"",
                    ""id"": {expectedId},
                    ""name"": ""{expectedName}"",
                    ""description"": ""{expectedDescription}""
                  }},
                  ""messageId"": ""{expectedMessageId}""
                }}
              ]
            }}";

        var givenText = "Test Voice message.";
        var givenLanguage = "en";
        var givenName = "Joanna";
        var givenGender = "female";
        var givenFrom = "442032864231";
        var givenTo = "41793026727";

        var givenRequest = $@"
            {{
              ""text"": ""{givenText}"",
              ""language"": ""{givenLanguage}"",
              ""voice"": {{
                ""name"": ""{givenName}"",
                ""gender"": ""{givenGender}""
              }},
              ""from"": ""{givenFrom}"",
              ""to"": ""{givenTo}""
            }}";

        SetUpPostRequest(VOICE_SINGLE_ENDPOINT, 200, givenRequest, expectedResponse);

        var voiceApi = new VoiceApi(configuration);

        var callsSingleBody = new CallsSingleBody(
            text: givenText,
            language: givenLanguage,
            voice: new CallsVoice(
                name: givenName,
                gender: givenGender
            ),
            from: givenFrom,
            to: givenTo
        );
        ;

        void AssertCallsVoiceResponse(CallsVoiceResponse callsVoiceResponse)
        {
            Assert.IsNotNull(callsVoiceResponse);
            Assert.AreEqual(expectedBulkId, callsVoiceResponse.BulkId);

            Assert.IsNotNull(callsVoiceResponse.Messages);
            var messages = callsVoiceResponse.Messages;
            Assert.AreEqual(1, messages.Count);

            Assert.AreEqual(expectedTo, messages[0].To);
            Assert.AreEqual(expectedGroupId, messages[0].Status.GroupId);
            Assert.AreEqual(expectedGroupName, messages[0].Status.GroupName);
            Assert.AreEqual(expectedId, messages[0].Status.Id);
            Assert.AreEqual(expectedName, messages[0].Status.Name);
            Assert.AreEqual(expectedDescription, messages[0].Status.Description);
            Assert.AreEqual(expectedMessageId, messages[0].MessageId);
        }

        AssertResponse(voiceApi.SendSingleVoiceTts(callsSingleBody), AssertCallsVoiceResponse);
        AssertResponse(voiceApi.SendSingleVoiceTtsAsync(callsSingleBody).Result, AssertCallsVoiceResponse);
        AssertResponseWithHttpInfo(voiceApi.SendSingleVoiceTtsWithHttpInfo(callsSingleBody), AssertCallsVoiceResponse,
            200);
        AssertResponseWithHttpInfo(voiceApi.SendSingleVoiceTtsWithHttpInfoAsync(callsSingleBody).Result,
            AssertCallsVoiceResponse, 200);
    }

    [TestMethod]
    public void ShouldSendMultipleVoiceMessages()
    {
        var expectedBulkId = "5028e2d42f19-42f1-4656-351e-a42c191e5fd2";
        var expectedTo = "41793026727";
        var expectedGroupId = 1;
        var expectedGroupName = "PENDING";
        var expectedId = 26;
        var expectedName = "PENDING_ACCEPTED";
        var expectedDescription = "Message accepted, pending for delivery.";
        var expectedMessageId = "4242f196ba50-a356-2f91-831c4aa55f351ed2";
        var expectedSecondTo = "41793026731";
        var expectedSecondGroupId = 1;
        var expectedSecondGroupName = "PENDING";
        var expectedSecondId = 26;
        var expectedSecondName = "PENDING_ACCEPTED";
        var expectedSecondDescription = "Message accepted, pending for delivery.";
        var expectedSecondMessageId = "5f35f896ba50-a356-43a4-91cd81b85f8c689";

        var expectedResponse = $@"
            {{
              ""bulkId"": ""{expectedBulkId}"",
              ""messages"": [
                {{
                  ""to"": ""{expectedTo}"",
                  ""status"": {{
                    ""groupId"": {expectedGroupId},
                    ""groupName"": ""{expectedGroupName}"",
                    ""id"": {expectedId},
                    ""name"": ""{expectedName}"",
                    ""description"": ""{expectedDescription}""
                  }},
                  ""messageId"": ""{expectedMessageId}""
                }},
                {{
                  ""to"": ""{expectedSecondTo}"",
                  ""status"": {{
                    ""groupId"": {expectedSecondGroupId},
                    ""groupName"": ""{expectedSecondGroupName}"",
                    ""id"": {expectedSecondId},
                    ""name"": ""{expectedSecondName}"",
                    ""description"": ""{expectedSecondDescription}""
                  }},
                  ""messageId"": ""{expectedSecondMessageId}""
                }}
              ]
            }}";

        var givenAudioFileUrl = "https://www.example.com/media.mp3";
        var givenFrom = "41793026700";
        var givenTo = "41793026727";
        var givenText = "Hello world!";
        var givenLanguage = "en";
        var givenName = "Joanna";
        var givenGender = "female";
        var givenSecondFrom = "41793026800";
        var givenSecondTo = "41793026731";

        var givenRequest = $@"
            {{
              ""messages"": [
                {{
                  ""audioFileUrl"": ""{givenAudioFileUrl}"",
                  ""from"": ""{givenFrom}"",
                  ""to"": [
                    ""{givenTo}""
                  ]
                }},
                {{
                  ""text"": ""{givenText}"",
                  ""language"": ""{givenLanguage}"",
                  ""voice"": {{
                    ""name"": ""{givenName}"",
                    ""gender"": ""{givenGender}""
                  }},
                  ""from"": ""{givenSecondFrom}"",
                  ""to"": [
                    ""{givenSecondTo}""
                  ]
                }}
              ]
            }}";

        SetUpPostRequest(VOICE_MULTI_ENDPOINT, 200, givenRequest, expectedResponse);

        var voiceApi = new VoiceApi(configuration);

        var callsMultiBody = new CallsMultiBody(
            new List<CallsMultiMessage>
            {
                new(
                    givenAudioFileUrl,
                    givenFrom,
                    to: new List<string>
                    {
                        givenTo
                    }
                ),
                new(
                    text: givenText,
                    language: givenLanguage,
                    voice: new CallsVoice(
                        name: givenName,
                        gender: givenGender
                    ),
                    from: givenSecondFrom,
                    to: new List<string>
                    {
                        givenSecondTo
                    }
                )
            }
        );


        void AssertCallsVoiceResponse(CallsVoiceResponse callsVoiceResponse)
        {
            Assert.IsNotNull(callsVoiceResponse);
            Assert.AreEqual(expectedBulkId, callsVoiceResponse.BulkId);

            Assert.IsNotNull(callsVoiceResponse.Messages);
            var messages = callsVoiceResponse.Messages;
            Assert.AreEqual(2, messages.Count);

            Assert.AreEqual(expectedTo, messages[0].To);
            Assert.AreEqual(expectedGroupId, messages[0].Status.GroupId);
            Assert.AreEqual(expectedGroupName, messages[0].Status.GroupName);
            Assert.AreEqual(expectedId, messages[0].Status.Id);
            Assert.AreEqual(expectedName, messages[0].Status.Name);
            Assert.AreEqual(expectedDescription, messages[0].Status.Description);
            Assert.AreEqual(expectedMessageId, messages[0].MessageId);

            Assert.AreEqual(expectedSecondTo, messages[1].To);
            Assert.AreEqual(expectedSecondGroupId, messages[1].Status.GroupId);
            Assert.AreEqual(expectedSecondGroupName, messages[1].Status.GroupName);
            Assert.AreEqual(expectedSecondId, messages[1].Status.Id);
            Assert.AreEqual(expectedSecondName, messages[1].Status.Name);
            Assert.AreEqual(expectedSecondDescription, messages[1].Status.Description);
            Assert.AreEqual(expectedSecondMessageId, messages[1].MessageId);
        }

        AssertResponse(voiceApi.SendMultipleVoiceTts(callsMultiBody), AssertCallsVoiceResponse);
        AssertResponse(voiceApi.SendMultipleVoiceTtsAsync(callsMultiBody).Result, AssertCallsVoiceResponse);
        AssertResponseWithHttpInfo(voiceApi.SendMultipleVoiceTtsWithHttpInfo(callsMultiBody), AssertCallsVoiceResponse,
            200);
        AssertResponseWithHttpInfo(voiceApi.SendMultipleVoiceTtsWithHttpInfoAsync(callsMultiBody).Result,
            AssertCallsVoiceResponse, 200);
    }

    [TestMethod]
    public void ShouldSendAdvancedMessage()
    {
        var expectedBulkId = "5028e2d42f19-42f1-4656-351e-a42c191e5fd2";
        var expectedTo = "41793026727";
        var expectedGroupId = 1;
        var expectedGroupName = "PENDING";
        var expectedId = 26;
        var expectedName = "PENDING_ACCEPTED";
        var expectedDescription = "Message accepted, pending for delivery.";
        var expectedMessageId = "4242f196ba50-a356-2f91-831c4aa55f351ed2";
        var expectedSecondTo = "41793026731";
        var expectedSecondGroupId = 1;
        var expectedSecondGroupName = "PENDING";
        var expectedSecondId = 26;
        var expectedSecondName = "PENDING_ACCEPTED";
        var expectedSecondDescription = "Message accepted, pending for delivery.";
        var expectedSecondMessageId = "5f35f896ba50-a356-43a4-91cd81b85f8c689";

        var expectedResponse = $@"
            {{
              ""bulkId"": ""{expectedBulkId}"",
              ""messages"": [
                {{
                  ""to"": ""{expectedTo}"",
                  ""status"": {{
                    ""groupId"": {expectedGroupId},
                    ""groupName"": ""{expectedGroupName}"",
                    ""id"": {expectedId},
                    ""name"": ""{expectedName}"",
                    ""description"": ""{expectedDescription}""
                  }},
                  ""messageId"": ""{expectedMessageId}""
                }},
                {{
                  ""to"": ""{expectedSecondTo}"",
                  ""status"": {{
                    ""groupId"": {expectedSecondGroupId},
                    ""groupName"": ""{expectedSecondGroupName}"",
                    ""id"": {expectedSecondId},
                    ""name"": ""{expectedSecondName}"",
                    ""description"": ""{expectedSecondDescription}""
                  }},
                  ""messageId"": ""{expectedSecondMessageId}""
                }}
              ]
            }}";

        var givenBulkId = "BULK-ID-123-xyz";
        var givenFrom = "41793026700";
        var givenTo = "41793026727";
        var givenMessageId = "MESSAGE-ID-123-xyz";
        var givenSecondTo = "41793026731";
        var givenText = "Test Voice message.";
        var givenLanguage = "en";
        var givenName = "Joanna";
        var givenGender = "female";
        var givenSpeechRate = 1.0;
        var givenNotifyUrl = "https://www.example.com/voice/clicktocall";
        var givenNotifyContentType = "application/json";
        var givenValidityPeriod = 720;
        var givenSendAt = new DateTimeOffset(2023, 8, 10, 7, 36, 42, 005, TimeSpan.FromHours(0));
        var givenRepeatDtmf = "123";
        var givenMaxDtmf = 1;
        var givenRingTimeout = 45;
        var givenDtmfTimeout = 10;
        var givenCallTimeout = 130;
        var givenCallbackData = "DLR callback data";
        var givenEquals = "2";
        var givenTransferTo = "41793026700";
        var givenCallTransferMaxDuration = 45;
        var givenIf = "DTMF";
        var givenSecondTransferTo = "41793026701";
        var givenSecondCallTransferMaxDuration = 45;
        var givenSecondIf = "anyDtmf";
        var givenPause = 3;
        var givenMinPeriod = 1;
        var givenMaxPeriod = 5;
        var givenMaxCount = 5;
        var givenSpeed = 5;
        var givenTimeUnit = "minute";
        var givenMachineDetection = "continue";
        var givenFromHour = 6;
        var givenFromMinute = 15;
        var givenToHour = 15;
        var givenToMinute = 30;
        var givenFirstDay = "MONDAY";
        var givenSecondDay = "TUESDAY";
        var givenThirdDay = "WEDNESDAY";
        var givenFourthDay = "THURSDAY";
        var givenFifthDay = "FRIDAY";
        var givenSixthDay = "SATURDAY";
        var givenSeventhDay = "SUNDAY";

        var givenRequest = $@"
            {{
              ""bulkId"": ""{givenBulkId}"",
              ""messages"": [
                {{
                  ""from"": ""{givenFrom}"",
                  ""destinations"": [
                    {{
                      ""to"": ""{givenTo}"",
                      ""messageId"": ""{givenMessageId}""
                    }},
                    {{
                      ""to"": ""{givenSecondTo}""
                    }}
                  ],
                  ""text"": ""{givenText}"",
                  ""language"": ""{givenLanguage}"",
                  ""voice"": {{
                    ""name"": ""{givenName}"",
                    ""gender"": ""{givenGender}""
                  }},
                  ""speechRate"": {givenSpeechRate.ToString("F1")},
                  ""notifyUrl"": ""{givenNotifyUrl}"",
                  ""notifyContentType"": ""{givenNotifyContentType}"",
                  ""validityPeriod"": {givenValidityPeriod},
                  ""sendAt"": ""{givenSendAt.ToUniversalTime().ToString(DATE_FORMAT)}"",
                  ""repeatDtmf"": ""{givenRepeatDtmf}"",
                  ""maxDtmf"": {givenMaxDtmf},
                  ""ringTimeout"": {givenRingTimeout},
                  ""dtmfTimeout"": {givenDtmfTimeout},
                  ""callTimeout"": {givenCallTimeout},
                  ""callTransfers"": [
                    {{
                      ""equals"": ""{givenEquals}"",
                      ""transferTo"": ""{givenTransferTo}"",
                      ""callTransferMaxDuration"": {givenCallTransferMaxDuration},
                      ""if"": ""{givenIf}""
                    }},
                    {{
                      ""transferTo"": ""{givenSecondTransferTo}"",
                      ""callTransferMaxDuration"": {givenSecondCallTransferMaxDuration},
                      ""if"": ""{givenSecondIf}""
                    }}
                  ],
                  ""callbackData"": ""{givenCallbackData}"",
                  ""pause"": {givenPause},
                  ""retry"": {{
                    ""minPeriod"": {givenMinPeriod},
                    ""maxPeriod"": {givenMaxPeriod},
                    ""maxCount"": {givenMaxCount}
                  }},
                  ""sendingSpeed"": {{
                    ""speed"": {givenSpeed},
                    ""timeUnit"": ""{givenTimeUnit}""
                  }},
                  ""machineDetection"": ""{givenMachineDetection}"",
                  ""deliveryTimeWindow"": {{
                    ""from"": {{
                      ""hour"": {givenFromHour},
                      ""minute"": {givenFromMinute}
                    }},
                    ""to"": {{
                      ""hour"": {givenToHour},
                      ""minute"": {givenToMinute}
                    }},
                    ""days"": [
                      ""{givenFirstDay}"",
                      ""{givenSecondDay}"",
                      ""{givenThirdDay}"",
                      ""{givenFourthDay}"",
                      ""{givenFifthDay}"",
                      ""{givenSixthDay}"",
                      ""{givenSeventhDay}""
                    ]
                  }}
                }}
              ]
            }}";

        SetUpPostRequest(VOICE_ADVANCED_ENDPOINT, 200, givenRequest, expectedResponse);

        var voiceApi = new VoiceApi(configuration);

        var callsAdvancedBody = new CallsAdvancedBody(
            givenBulkId,
            new List<CallsAdvancedMessage>
            {
                new(
                    from: givenFrom,
                    destinations: new List<CallsDestination>
                    {
                        new(
                            to: givenTo,
                            messageId: givenMessageId
                        ),
                        new(
                            to: givenSecondTo
                        )
                    },
                    text: givenText,
                    language: givenLanguage,
                    voice: new CallsVoice(
                        name: givenName,
                        gender: givenGender
                    ),
                    speechRate: givenSpeechRate,
                    notifyUrl: givenNotifyUrl,
                    notifyContentType: givenNotifyContentType,
                    validityPeriod: givenValidityPeriod,
                    sendAt: givenSendAt,
                    repeatDtmf: givenRepeatDtmf,
                    maxDtmf: givenMaxDtmf,
                    ringTimeout: givenRingTimeout,
                    dtmfTimeout: givenDtmfTimeout,
                    callTimeout: givenCallTimeout,
                    callTransfers: new List<CallTransfer>
                    {
                        new(
                            propertyEquals: givenEquals,
                            transferTo: givenTransferTo,
                            callTransferMaxDuration: givenCallTransferMaxDuration,
                            varIf: givenIf
                        ),
                        new(
                            transferTo: givenSecondTransferTo,
                            callTransferMaxDuration: givenSecondCallTransferMaxDuration,
                            varIf: givenSecondIf
                        )
                    },
                    callbackData: givenCallbackData,
                    pause: givenPause,
                    retry: new CallsRetry(
                        minPeriod: givenMinPeriod,
                        maxPeriod: givenMaxPeriod,
                        maxCount: givenMaxCount
                    ),
                    sendingSpeed: new CallsSendingSpeed(
                        givenSpeed,
                        givenTimeUnit
                    ),
                    machineDetection: givenMachineDetection,
                    deliveryTimeWindow: new DeliveryTimeWindow(
                        from: new DeliveryTime(
                            givenFromHour,
                            givenFromMinute
                        ),
                        to: new DeliveryTime(
                            givenToHour,
                            givenToMinute
                        ),
                        days: new List<DeliveryDay>
                        {
                            DeliveryDay.Monday,
                            DeliveryDay.Tuesday,
                            DeliveryDay.Wednesday,
                            DeliveryDay.Thursday,
                            DeliveryDay.Friday,
                            DeliveryDay.Saturday,
                            DeliveryDay.Sunday
                        }
                    )
                )
            }
        );

        void AssertCallsVoiceResponse(CallsVoiceResponse callsVoiceResponse)
        {
            Assert.IsNotNull(callsVoiceResponse);
            Assert.AreEqual(expectedBulkId, callsVoiceResponse.BulkId);

            Assert.IsNotNull(callsVoiceResponse.Messages);
            var messages = callsVoiceResponse.Messages;
            Assert.AreEqual(2, messages.Count);

            Assert.AreEqual(expectedTo, messages[0].To);
            Assert.AreEqual(expectedGroupId, messages[0].Status.GroupId);
            Assert.AreEqual(expectedGroupName, messages[0].Status.GroupName);
            Assert.AreEqual(expectedId, messages[0].Status.Id);
            Assert.AreEqual(expectedName, messages[0].Status.Name);
            Assert.AreEqual(expectedDescription, messages[0].Status.Description);
            Assert.AreEqual(expectedMessageId, messages[0].MessageId);

            Assert.AreEqual(expectedSecondTo, messages[1].To);
            Assert.AreEqual(expectedSecondGroupId, messages[1].Status.GroupId);
            Assert.AreEqual(expectedSecondGroupName, messages[1].Status.GroupName);
            Assert.AreEqual(expectedSecondId, messages[1].Status.Id);
            Assert.AreEqual(expectedSecondName, messages[1].Status.Name);
            Assert.AreEqual(expectedSecondDescription, messages[1].Status.Description);
            Assert.AreEqual(expectedSecondMessageId, messages[1].MessageId);
        }

        AssertResponse(voiceApi.SendAdvancedVoiceTts(callsAdvancedBody), AssertCallsVoiceResponse);
        AssertResponse(voiceApi.SendAdvancedVoiceTtsAsync(callsAdvancedBody).Result, AssertCallsVoiceResponse);
        AssertResponseWithHttpInfo(voiceApi.SendAdvancedVoiceTtsWithHttpInfo(callsAdvancedBody),
            AssertCallsVoiceResponse, 200);
        AssertResponseWithHttpInfo(voiceApi.SendAdvancedVoiceTtsWithHttpInfoAsync(callsAdvancedBody).Result,
            AssertCallsVoiceResponse, 200);
    }

    [TestMethod]
    public void ShouldGetVoices()
    {
        var expectedFirstName = "Benjamin";
        var expectedFirstGender = "male";
        var expectedFirstSupplier = "Microsoft";
        var expectedFirstSsmlSupported = false;
        var expectedFirstIsDefault = false;
        var expectedFirstIsNeural = false;
        var expectedSecondName = "Ivy";
        var expectedSecondGender = "female";
        var expectedSecondSupplier = "Amazon";
        var expectedSecondSsmlSupported = true;
        var expectedSecondIsDefault = false;
        var expectedSecondIsNeural = false;
        var expectedThirdName = "Joanna";
        var expectedThirdGender = "female";
        var expectedThirdSupplier = "Amazon";
        var expectedThirdSsmlSupported = true;
        var expectedThirdIsDefault = true;
        var expectedThirdIsNeural = false;
        var expectedFourthName = "Joey";
        var expectedFourthGender = "male";
        var expectedFourthSupplier = "Amazon";
        var expectedFourthSsmlSupported = true;
        var expectedFourthIsDefault = false;
        var expectedFourthIsNeural = false;

        var expectedResponse = $@"
            {{
              ""voices"": [
                {{
                  ""name"": ""{expectedFirstName}"",
                  ""gender"": ""{expectedFirstGender}"",
                  ""supplier"": ""{expectedFirstSupplier}"",
                  ""ssmlSupported"": {expectedFirstSsmlSupported.ToString().ToLower()},
                  ""isDefault"": {expectedFirstIsDefault.ToString().ToLower()},
                  ""isNeural"": {expectedFirstIsNeural.ToString().ToLower()}
                }},
                {{
                  ""name"": ""{expectedSecondName}"",
                  ""gender"": ""{expectedSecondGender}"",
                  ""supplier"": ""{expectedSecondSupplier}"",
                  ""ssmlSupported"": {expectedSecondSsmlSupported.ToString().ToLower()},
                  ""isDefault"": {expectedSecondIsDefault.ToString().ToLower()},
                  ""isNeural"": {expectedSecondIsNeural.ToString().ToLower()}
                }},
                {{
                  ""name"": ""{expectedThirdName}"",
                  ""gender"": ""{expectedThirdGender}"",
                  ""supplier"": ""{expectedThirdSupplier}"",
                  ""ssmlSupported"": {expectedThirdSsmlSupported.ToString().ToLower()},
                  ""isDefault"": {expectedThirdIsDefault.ToString().ToLower()},
                  ""isNeural"": {expectedThirdIsNeural.ToString().ToLower()}
                }},
                {{
                  ""name"": ""{expectedFourthName}"",
                  ""gender"": ""{expectedFourthGender}"",
                  ""supplier"": ""{expectedFourthSupplier}"",
                  ""ssmlSupported"": {expectedFourthSsmlSupported.ToString().ToLower()},
                  ""isDefault"": {expectedFourthIsDefault.ToString().ToLower()},
                  ""isNeural"": {expectedFourthIsNeural.ToString().ToLower()}
                }}
              ]
            }}";

        var givenLanguage = "en";
        var givenIncludeNeural = false;
        var givenQueryParamters = new Dictionary<string, string>
        {
            { "includeNeural", givenIncludeNeural.ToString().ToLower() }
        };

        SetUpGetRequest(VOICE_LANGUAGE_ENDPOINT.Replace("{language}", givenLanguage), 200,
            expectedResponse, givenQueryParamters);

        var voiceApi = new VoiceApi(configuration);

        void AssertCallsGetVoicesResponse(CallsGetVoicesResponse callsGetVoicesResponse)
        {
            Assert.IsNotNull(callsGetVoicesResponse);
            Assert.IsNotNull(callsGetVoicesResponse.Voices);
            var voices = callsGetVoicesResponse.Voices;
            Assert.AreEqual(4, voices.Count);

            Assert.AreEqual(expectedFirstName, voices[0].Name);
            Assert.AreEqual(expectedFirstGender, voices[0].Gender);
            Assert.AreEqual(expectedFirstSupplier, voices[0].Supplier);
            Assert.AreEqual(expectedFirstSsmlSupported, voices[0].SsmlSupported);
            Assert.AreEqual(expectedFirstIsDefault, voices[0].IsDefault);
            Assert.AreEqual(expectedFirstIsNeural, voices[0].IsNeural);

            Assert.AreEqual(expectedSecondName, voices[1].Name);
            Assert.AreEqual(expectedSecondGender, voices[1].Gender);
            Assert.AreEqual(expectedSecondSupplier, voices[1].Supplier);
            Assert.AreEqual(expectedSecondSsmlSupported, voices[1].SsmlSupported);
            Assert.AreEqual(expectedSecondIsDefault, voices[1].IsDefault);
            Assert.AreEqual(expectedSecondIsNeural, voices[1].IsNeural);

            Assert.AreEqual(expectedThirdName, voices[2].Name);
            Assert.AreEqual(expectedThirdGender, voices[2].Gender);
            Assert.AreEqual(expectedThirdSupplier, voices[2].Supplier);
            Assert.AreEqual(expectedThirdSsmlSupported, voices[2].SsmlSupported);
            Assert.AreEqual(expectedThirdIsDefault, voices[2].IsDefault);
            Assert.AreEqual(expectedThirdIsNeural, voices[2].IsNeural);

            Assert.AreEqual(expectedFourthName, voices[3].Name);
            Assert.AreEqual(expectedFourthGender, voices[3].Gender);
            Assert.AreEqual(expectedFourthSupplier, voices[3].Supplier);
            Assert.AreEqual(expectedFourthSsmlSupported, voices[3].SsmlSupported);
            Assert.AreEqual(expectedFourthIsDefault, voices[3].IsDefault);
            Assert.AreEqual(expectedFourthIsNeural, voices[3].IsNeural);
        }

        AssertResponse(voiceApi.GetVoices(givenLanguage, givenIncludeNeural), AssertCallsGetVoicesResponse);
        AssertResponse(voiceApi.GetVoicesAsync(givenLanguage, givenIncludeNeural).Result, AssertCallsGetVoicesResponse);
        AssertResponseWithHttpInfo(voiceApi.GetVoicesWithHttpInfo(givenLanguage, givenIncludeNeural),
            AssertCallsGetVoicesResponse, 200);
        AssertResponseWithHttpInfo(voiceApi.GetVoicesWithHttpInfoAsync(givenLanguage, givenIncludeNeural).Result,
            AssertCallsGetVoicesResponse, 200);
    }

    [TestMethod]
    public void ShouldGetSentBulks()
    {
        var expectedBulkId = "5028e2d42f19-42f1-4656-351e-a42c191e5fd2";
        var expectedSendAt = new DateTimeOffset(2023, 9, 26, 14, 7, 35, TimeSpan.FromHours(0));

        var expectedResponse = $@"
            {{
              ""bulkId"": ""{expectedBulkId}"",
              ""sendAt"": ""{expectedSendAt.ToUniversalTime().ToString(DATE_FORMAT)}""
            }}";

        var givenBulkId = "5028e2d42f19-42f1-4656-351e-a42c191e5fd2";
        var givenQueryParamters = new Dictionary<string, string>
        {
            { "bulkId", givenBulkId }
        };

        SetUpGetRequest(VOICE_BULKS_ENDPOINT, 200, expectedResponse, givenQueryParamters);

        var voiceApi = new VoiceApi(configuration);

        void AssertCallsBulkResponse(CallsBulkResponse callsBulkResponse)
        {
            Assert.IsNotNull(callsBulkResponse);
            Assert.AreEqual(expectedBulkId, callsBulkResponse.BulkId);
            Assert.AreEqual(expectedSendAt, callsBulkResponse.SendAt);
        }

        AssertResponse(voiceApi.GetSentBulks(givenBulkId), AssertCallsBulkResponse);
        AssertResponse(voiceApi.GetSentBulksAsync(givenBulkId).Result, AssertCallsBulkResponse);
        AssertResponseWithHttpInfo(voiceApi.GetSentBulksWithHttpInfo(givenBulkId), AssertCallsBulkResponse, 200);
        AssertResponseWithHttpInfo(voiceApi.GetSentBulksWithHttpInfoAsync(givenBulkId).Result, AssertCallsBulkResponse,
            200);
    }

    [TestMethod]
    public void ShouldRescheduleSentBulk()
    {
        var expectedBulkId = "5028e2d42f19-42f1-4656-351e-a42c191e5fd2";
        var expectedSendAt = new DateTimeOffset(2023, 9, 27, 8, 6, 8, TimeSpan.FromHours(0));

        var expectedResponse = $@"
            {{
              ""bulkId"": ""{expectedBulkId}"",
              ""sendAt"": ""{expectedSendAt.ToUniversalTime().ToString(DATE_FORMAT)}""
            }}";

        var givenSendAt = new DateTimeOffset(2023, 9, 27, 8, 6, 8, TimeSpan.FromHours(0));

        var givenRequest = $@"
            {{
              ""sendAt"": ""{givenSendAt.ToUniversalTime().ToString(DATE_FORMAT)}""
            }}";

        var givenBulkId = "5028e2d42f19-42f1-4656-351e-a42c191e5fd2";
        var givenQueryParamters = new Dictionary<string, string>
        {
            { "bulkId", givenBulkId }
        };

        SetUpPutRequest(VOICE_BULKS_ENDPOINT, 200, givenRequest, expectedResponse, givenQueryParamters);

        var voiceApi = new VoiceApi(configuration);

        var callsBulkRequest = new CallsBulkRequest(
            givenSendAt
        );

        void AssertCallsBulkResponse(CallsBulkResponse callsBulkResponse)
        {
            Assert.IsNotNull(callsBulkResponse);
            Assert.AreEqual(expectedBulkId, callsBulkResponse.BulkId);
            Assert.AreEqual(expectedSendAt, callsBulkResponse.SendAt);
        }

        AssertResponse(voiceApi.RescheduleSentBulk(givenBulkId, callsBulkRequest), AssertCallsBulkResponse);
        AssertResponse(voiceApi.RescheduleSentBulkAsync(givenBulkId, callsBulkRequest).Result, AssertCallsBulkResponse);
        AssertResponseWithHttpInfo(voiceApi.RescheduleSentBulkWithHttpInfo(givenBulkId, callsBulkRequest),
            AssertCallsBulkResponse, 200);
        AssertResponseWithHttpInfo(voiceApi.RescheduleSentBulkWithHttpInfoAsync(givenBulkId, callsBulkRequest).Result,
            AssertCallsBulkResponse, 200);
    }

    [TestMethod]
    public void ShouldGetSentBulksStatus()
    {
        var expectedBulkId = "5028e2d42f19-42f1-4656-351e-a42c191e5fd2";
        var expectedStatus = CallsBulkStatus.Pending;

        var expectedResponse = $@"
            {{
              ""bulkId"": ""{expectedBulkId}"",
              ""status"": ""{expectedStatus}""
            }}";

        var givenBulkId = "5028e2d42f19-42f1-4656-351e-a42c191e5fd2";
        var givenQueryParamters = new Dictionary<string, string>
        {
            { "bulkId", givenBulkId }
        };

        SetUpGetRequest(VOICE_BULKS_STATUS_ENDPOINT, 200, expectedResponse, givenQueryParamters);

        var voiceApi = new VoiceApi(configuration);

        void AssertCallsBulkStatusResponse(CallsBulkStatusResponse callsBulkStatusResponse)
        {
            Assert.IsNotNull(callsBulkStatusResponse);
            Assert.AreEqual(expectedBulkId, callsBulkStatusResponse.BulkId);
            Assert.AreEqual(expectedStatus, callsBulkStatusResponse.Status);
        }

        AssertResponse(voiceApi.GetSentBulksStatus(givenBulkId), AssertCallsBulkStatusResponse);
        AssertResponse(voiceApi.GetSentBulksStatusAsync(givenBulkId).Result, AssertCallsBulkStatusResponse);
        AssertResponseWithHttpInfo(voiceApi.GetSentBulksStatusWithHttpInfo(givenBulkId), AssertCallsBulkStatusResponse,
            200);
        AssertResponseWithHttpInfo(voiceApi.GetSentBulksStatusWithHttpInfoAsync(givenBulkId).Result,
            AssertCallsBulkStatusResponse, 200);
    }

    [TestMethod]
    public void ShouldManageSentBulksStatus()
    {
        var expectedBulkId = "5028e2d42f19-42f1-4656-351e-a42c191e5fd2";
        var expectedStatus = CallsBulkStatus.Pending;

        var expectedResponse = $@"
            {{
              ""bulkId"": ""{expectedBulkId}"",
              ""status"": ""{expectedStatus}""
            }}";

        var givenStatus = CallsBulkStatus.Paused;

        var givenRequest = $@"
            {{
              ""status"": ""{givenStatus}""
            }}";

        var givenBulkId = "5028e2d42f19-42f1-4656-351e-a42c191e5fd2";
        var givenQueryParamters = new Dictionary<string, string>
        {
            { "bulkId", givenBulkId }
        };

        SetUpPutRequest(VOICE_BULKS_STATUS_ENDPOINT, 200, givenRequest, expectedResponse, givenQueryParamters);

        var voiceApi = new VoiceApi(configuration);

        var callsUpdateStatusRequest = new CallsUpdateStatusRequest(
            givenStatus
        );

        void AssertCallsBulkStatusResponse(CallsBulkStatusResponse callsBulkStatusResponse)
        {
            Assert.IsNotNull(callsBulkStatusResponse);
            Assert.AreEqual(expectedBulkId, callsBulkStatusResponse.BulkId);
            Assert.AreEqual(expectedStatus, callsBulkStatusResponse.Status);
        }

        AssertResponse(voiceApi.ManageSentBulksStatus(givenBulkId, callsUpdateStatusRequest),
            AssertCallsBulkStatusResponse);
        AssertResponse(voiceApi.ManageSentBulksStatusAsync(givenBulkId, callsUpdateStatusRequest).Result,
            AssertCallsBulkStatusResponse);
        AssertResponseWithHttpInfo(voiceApi.ManageSentBulksStatusWithHttpInfo(givenBulkId, callsUpdateStatusRequest),
            AssertCallsBulkStatusResponse, 200);
        AssertResponseWithHttpInfo(
            voiceApi.ManageSentBulksStatusWithHttpInfoAsync(givenBulkId, callsUpdateStatusRequest).Result,
            AssertCallsBulkStatusResponse, 200);
    }

    [TestMethod]
    public void ShouldGetVoiceDeliveryReports()
    {
        var expectedBulkId = "8c20f086-d82b-48cc-b2b3-3ca5f7aca9fb";
        var expectedMessageId = "ff4804ef-6ab6-4abd-984d-ab3b1387e852";
        var expectedFrom = "385333444";
        var expectedTo = "385981178";
        var expectedSentAt = "2018-06-25T13:38:14.730+0000";
        var expectedMccMnc = "21901";
        var expectedCallbackData = "DLR callback data";
        var expectedFeature = "Voice-message";
        var expectedStartTime = "2018-06-25T13:38:15.000+0000";
        var expectedAnswerTime = "2018-06-25T13:38:25.000+0000";
        var expectedEndTime = "2018-06-25T13:38:28.316+0000";
        var expectedDuration = 10;
        var expectedChargedDuration = 30;
        var expectedFileDuration = 19.3;
        var expectedDtmfCodes = "3, 9";
        var expectedScenarioId = "333";
        var expectedScenarioName = "Scenario name";
        var expectedPricePerSecond = 0.01m;
        var expectedCurrency = "EUR";
        var expectedStatusGroupId = 3;
        var expectedStatusGroupName = "DELIVERED";
        var expectedStatusId = 5;
        var expectedStatusName = "DELIVERED_TO_HANDSET";
        var expectedStatusDescription = "Message delivered to handset";
        var expectedErrorGroupId = 0;
        var expectedErrorGroupName = "OK";
        var expectedErrorId = 5000;
        var expectedErrorName = "VOICE_ANSWERED";
        var expectedErrorDescription = "Call answered by human";
        var expectedErrorPermanent = true;

        var expectedResponse = $@"
            {{
              ""results"": [
                {{
                  ""bulkId"": ""{expectedBulkId}"",
                  ""messageId"": ""{expectedMessageId}"",
                  ""from"": ""{expectedFrom}"",
                  ""to"": ""{expectedTo}"",
                  ""sentAt"": ""{expectedSentAt}"",
                  ""mccMnc"": ""{expectedMccMnc}"",
                  ""callbackData"": ""{expectedCallbackData}"",
                  ""voiceCall"": {{
                    ""feature"": ""{expectedFeature}"",
                    ""startTime"": ""{expectedStartTime}"",
                    ""answerTime"": ""{expectedAnswerTime}"",
                    ""endTime"": ""{expectedEndTime}"",
                    ""duration"": {expectedDuration},
                    ""chargedDuration"": {expectedChargedDuration},
                    ""fileDuration"": {expectedFileDuration},
                    ""dtmfCodes"": ""{expectedDtmfCodes}"",
                    ""ivr"": {{
                      ""scenarioId"": ""{expectedScenarioId}"",
                      ""scenarioName"": ""{expectedScenarioName}"",
                      ""collectedDtmfs"": ""{{\""myFirstVar\"":\""3\"",\""mySecondVar\"":\""9\""}}"",
                      ""collectedMappedDtmfs"": null,
                      ""spokenInput"": null,
                      ""matchedSpokenInput"": null
                    }}
                  }},
                  ""price"": {{
                    ""pricePerSecond"": {expectedPricePerSecond},
                    ""currency"": ""{expectedCurrency}""
                  }},
                  ""status"": {{
                    ""groupId"": {expectedStatusGroupId},
                    ""groupName"": ""{expectedStatusGroupName}"",
                    ""id"": {expectedStatusId},
                    ""name"": ""{expectedStatusName}"",
                    ""description"": ""{expectedStatusDescription}""
                  }},
                  ""error"": {{
                    ""groupId"": {expectedErrorGroupId},
                    ""groupName"": ""{expectedErrorGroupName}"",
                    ""id"": {expectedErrorId},
                    ""name"": ""{expectedErrorName}"",
                    ""description"": ""{expectedErrorDescription}"",
                    ""permanent"": {expectedErrorPermanent.ToString().ToLower()}
                  }}
                }}
              ]
            }}";

        var givenBulkId = "8c20f086-d82b-48cc-b2b3-3ca5f7aca9fb";
        var givenMessageId = "ff4804ef-6ab6-4abd-984d-ab3b1387e852";
        var givenLimit = 10;
        var givenQueryParamters = new Dictionary<string, string>
        {
            { "bulkId", givenBulkId },
            { "messageId", givenMessageId },
            { "limit", givenLimit.ToString() }
        };

        SetUpGetRequest(VOICE_REPORTS_ENDPOINT, 200, expectedResponse, givenQueryParamters);

        var voiceApi = new VoiceApi(configuration);

        void AssertCallsReportResponse(CallsReportResponse callsReportResponse)
        {
            Assert.IsNotNull(callsReportResponse);

            var results = callsReportResponse.Results;
            Assert.IsNotNull(callsReportResponse.Results);
            Assert.AreEqual(1, callsReportResponse.Results.Count);

            Assert.AreEqual(expectedBulkId, callsReportResponse.Results[0].BulkId);
            Assert.AreEqual(expectedMessageId, callsReportResponse.Results[0].MessageId);
            Assert.AreEqual(expectedFrom, callsReportResponse.Results[0].From);
            Assert.AreEqual(expectedTo, callsReportResponse.Results[0].To);
            Assert.AreEqual(expectedSentAt, callsReportResponse.Results[0].SentAt);
            Assert.AreEqual(expectedMccMnc, callsReportResponse.Results[0].MccMnc);
            Assert.AreEqual(expectedCallbackData, callsReportResponse.Results[0].CallbackData);
            Assert.AreEqual(expectedFeature, callsReportResponse.Results[0].VoiceCall.Feature);
            Assert.AreEqual(expectedStartTime, callsReportResponse.Results[0].VoiceCall.StartTime);
            Assert.AreEqual(expectedAnswerTime, callsReportResponse.Results[0].VoiceCall.AnswerTime);
            Assert.AreEqual(expectedEndTime, callsReportResponse.Results[0].VoiceCall.EndTime);
            Assert.AreEqual(expectedDuration, callsReportResponse.Results[0].VoiceCall.Duration);
            Assert.AreEqual(expectedChargedDuration, callsReportResponse.Results[0].VoiceCall.ChargedDuration);
            Assert.AreEqual(expectedFileDuration, callsReportResponse.Results[0].VoiceCall.FileDuration);
            Assert.AreEqual(expectedDtmfCodes, callsReportResponse.Results[0].VoiceCall.DtmfCodes);
            Assert.AreEqual(expectedScenarioId, callsReportResponse.Results[0].VoiceCall.Ivr.ScenarioId);
            Assert.AreEqual(expectedScenarioName, callsReportResponse.Results[0].VoiceCall.Ivr.ScenarioName);
            Assert.AreEqual("{\"myFirstVar\":\"3\",\"mySecondVar\":\"9\"}",
                callsReportResponse.Results[0].VoiceCall.Ivr.CollectedDtmfs);
            Assert.AreEqual(null, callsReportResponse.Results[0].VoiceCall.Ivr.CollectedMappedDtmfs);
            Assert.AreEqual(null, callsReportResponse.Results[0].VoiceCall.Ivr.SpokenInput);
            Assert.AreEqual(null, callsReportResponse.Results[0].VoiceCall.Ivr.MatchedSpokenInput);
            Assert.AreEqual(expectedPricePerSecond, callsReportResponse.Results[0].Price.PricePerSecond);
            Assert.AreEqual(expectedCurrency, callsReportResponse.Results[0].Price.Currency);
            Assert.AreEqual(expectedStatusGroupId, callsReportResponse.Results[0].Status.GroupId);
            Assert.AreEqual(expectedStatusGroupName, callsReportResponse.Results[0].Status.GroupName);
            Assert.AreEqual(expectedStatusId, callsReportResponse.Results[0].Status.Id);
            Assert.AreEqual(expectedStatusName, callsReportResponse.Results[0].Status.Name);
            Assert.AreEqual(expectedStatusDescription, callsReportResponse.Results[0].Status.Description);
            Assert.AreEqual(expectedErrorGroupId, callsReportResponse.Results[0].Error.GroupId);
            Assert.AreEqual(expectedErrorGroupName, callsReportResponse.Results[0].Error.GroupName);
            Assert.AreEqual(expectedErrorId, callsReportResponse.Results[0].Error.Id);
            Assert.AreEqual(expectedErrorName, callsReportResponse.Results[0].Error.Name);
            Assert.AreEqual(expectedErrorDescription, callsReportResponse.Results[0].Error.Description);
            Assert.AreEqual(expectedErrorPermanent, callsReportResponse.Results[0].Error.Permanent);
        }

        AssertResponse(voiceApi.GetVoiceDeliveryReports(givenBulkId, givenMessageId, givenLimit),
            AssertCallsReportResponse);
        AssertResponse(voiceApi.GetVoiceDeliveryReportsAsync(givenBulkId, givenMessageId, givenLimit).Result,
            AssertCallsReportResponse);
        AssertResponseWithHttpInfo(
            voiceApi.GetVoiceDeliveryReportsWithHttpInfo(givenBulkId, givenMessageId, givenLimit),
            AssertCallsReportResponse, 200);
        AssertResponseWithHttpInfo(
            voiceApi.GetVoiceDeliveryReportsWithHttpInfoAsync(givenBulkId, givenMessageId, givenLimit).Result,
            AssertCallsReportResponse, 200);
    }

    [TestMethod]
    public void ShouldGetSentVoiceLogs()
    {
        var expectedBulkId = "06479ba3-5977-47f6-9346-fee0369bc76b";
        var expectedMessageId = "1f21d8d7-f306-4f53-9f6e-eddfce9849ea";
        var expectedTo = "41793026727";
        var expectedFrom = "41793026700";
        var expectedText = "Test voice message.";
        var expectedSentAt = new DateTimeOffset(2018, 6, 25, 13, 38, 14, 730, TimeSpan.FromHours(0));
        var expectedDoneAt = new DateTimeOffset(2018, 6, 25, 13, 38, 14, 730, TimeSpan.FromHours(0));
        var expectedDuration = 10;
        var expectedMccMnc = "21901";
        var expectedPricePerSecond = 0.01m;
        var expectedCurrency = "EUR";
        var expectedStatusGroupId = 3;
        var expectedStatusGroupName = "DELIVERED";
        var expectedStatusId = 5;
        var expectedStatusName = "DELIVERED_TO_HANDSET";
        var expectedStatusDescription = "Message delivered to handset";
        var expectedErrorGroupId = 0;
        var expectedErrorGroupName = "OK";
        var expectedErrorId = 5003;
        var expectedErrorName = "EC_VOICE_NO_ANSWER";
        var expectedErrorDescription = "User was notified, but did not answer call";
        var expectedErrorPermanent = true;

        var expectedResponse = $@"
            {{
              ""results"": [
                {{
                  ""bulkId"": ""{expectedBulkId}"",
                  ""messageId"": ""{expectedMessageId}"",
                  ""to"": ""{expectedTo}"",
                  ""from"": ""{expectedFrom}"",
                  ""text"": ""{expectedText}"",
                  ""sentAt"": ""{expectedSentAt.ToUniversalTime().ToString(DATE_FORMAT)}"",
                  ""doneAt"": ""{expectedDoneAt.ToUniversalTime().ToString(DATE_FORMAT)}"",
                  ""duration"": {expectedDuration},
                  ""mccMnc"": ""{expectedMccMnc}"",
                  ""price"": {{
                    ""pricePerSecond"": {expectedPricePerSecond},
                    ""currency"": ""{expectedCurrency}""
                  }},
                  ""status"": {{
                    ""groupId"": {expectedStatusGroupId},
                    ""groupName"": ""{expectedStatusGroupName}"",
                    ""id"": {expectedStatusId},
                    ""name"": ""{expectedStatusName}"",
                    ""description"": ""{expectedStatusDescription}""
                  }},
                  ""error"": {{
                    ""groupId"": {expectedErrorGroupId},
                    ""groupName"": ""{expectedErrorGroupName}"",
                    ""id"": {expectedErrorId},
                    ""name"": ""{expectedErrorName}"",
                    ""description"": ""{expectedErrorDescription}"",
                    ""permanent"": {expectedErrorPermanent.ToString().ToLower()}
                  }}
                }}
              ]
            }}";

        var givenLimit = 10;
        var givenQueryParamters = new Dictionary<string, string>
        {
            { "limit", givenLimit.ToString() }
        };

        SetUpGetRequest(VOICE_LOGS_ENDPOINT, 200, expectedResponse, givenQueryParamters);

        var voiceApi = new VoiceApi(configuration);

        void AssertCallsLogsResponse(CallsLogsResponse callsLogsResponse)
        {
            Assert.IsNotNull(callsLogsResponse);

            var results = callsLogsResponse.Results;
            Assert.IsNotNull(callsLogsResponse.Results);
            Assert.AreEqual(1, callsLogsResponse.Results.Count);

            Assert.AreEqual(expectedBulkId, callsLogsResponse.Results[0].BulkId);
            Assert.AreEqual(expectedMessageId, callsLogsResponse.Results[0].MessageId);
            Assert.AreEqual(expectedTo, callsLogsResponse.Results[0].To);
            Assert.AreEqual(expectedFrom, callsLogsResponse.Results[0].From);
            Assert.AreEqual(expectedSentAt, callsLogsResponse.Results[0].SentAt);
            Assert.AreEqual(expectedDoneAt, callsLogsResponse.Results[0].DoneAt);
            Assert.AreEqual(expectedDuration, callsLogsResponse.Results[0].Duration);
            Assert.AreEqual(expectedMccMnc, callsLogsResponse.Results[0].MccMnc);
            Assert.AreEqual(expectedPricePerSecond, callsLogsResponse.Results[0].Price.PricePerSecond);
            Assert.AreEqual(expectedCurrency, callsLogsResponse.Results[0].Price.Currency);
            Assert.AreEqual(expectedStatusGroupId, callsLogsResponse.Results[0].Status.GroupId);
            Assert.AreEqual(expectedStatusGroupName, callsLogsResponse.Results[0].Status.GroupName);
            Assert.AreEqual(expectedStatusId, callsLogsResponse.Results[0].Status.Id);
            Assert.AreEqual(expectedStatusName, callsLogsResponse.Results[0].Status.Name);
            Assert.AreEqual(expectedStatusDescription, callsLogsResponse.Results[0].Status.Description);
            Assert.AreEqual(expectedErrorGroupId, callsLogsResponse.Results[0].Error.GroupId);
            Assert.AreEqual(expectedErrorGroupName, callsLogsResponse.Results[0].Error.GroupName);
            Assert.AreEqual(expectedErrorId, callsLogsResponse.Results[0].Error.Id);
            Assert.AreEqual(expectedErrorName, callsLogsResponse.Results[0].Error.Name);
            Assert.AreEqual(expectedErrorDescription, callsLogsResponse.Results[0].Error.Description);
            Assert.AreEqual(expectedErrorPermanent, callsLogsResponse.Results[0].Error.Permanent);
        }

        AssertResponse(voiceApi.GetSentVoiceLogs(limit: givenLimit), AssertCallsLogsResponse);
        AssertResponse(voiceApi.GetSentVoiceLogsAsync(limit: givenLimit).Result, AssertCallsLogsResponse);
        AssertResponseWithHttpInfo(voiceApi.GetSentVoiceLogsWithHttpInfo(limit: givenLimit), AssertCallsLogsResponse,
            200);
        AssertResponseWithHttpInfo(voiceApi.GetSentVoiceLogsWithHttpInfoAsync(limit: givenLimit).Result,
            AssertCallsLogsResponse, 200);
    }

    [TestMethod]
    public void ShouldReceiveVoiceDeliveryReports()
    {
        var expectedBulkId = "8c20f086-d82b-48cc-b2b3-3ca5f7aca9fb";
        var expectedMessageId = "ff4804ef-6ab6-4abd-984d-ab3b1387e852";
        var expectedFrom = "385333444";
        var expectedTo = "385981178";
        var expectedSentAt = "2018-06-25T13:38:14.730+0000";
        var expectedMccMnc = "21901";
        var expectedCallbackData = "DLR callback data";
        var expectedFeature = "Voice-message";
        var expectedStartTime = "2018-06-25T13:38:15.000+0000";
        var expectedAnswerTime = "2018-06-25T13:38:25.000+0000";
        var expectedEndTime = "2018-06-25T13:38:28.316+0000";
        var expectedDuration = 10;
        var expectedChargedDuration = 30;
        var expectedFileDuration = 19.3;
        var expectedDtmfCodes = "3, 9";
        var expectedScenarioId = "333";
        var expectedScenarioName = "Scenario name";
        var expectedPricePerSecond = 0.01m;
        var expectedCurrency = "EUR";
        var expectedStatusGroupId = 3;
        var expectedStatusGroupName = "DELIVERED";
        var expectedStatusId = 5;
        var expectedStatusName = "DELIVERED_TO_HANDSET";
        var expectedStatusDescription = "Message delivered to handset";
        var expectedErrorGroupId = 0;
        var expectedErrorGroupName = "OK";
        var expectedErrorId = 5000;
        var expectedErrorName = "VOICE_ANSWERED";
        var expectedErrorDescription = "Call answered by human";
        var expectedErrorPermanent = true;

        var expectedRequest = $@"
            {{
              ""results"": [
                {{
                  ""bulkId"": ""{expectedBulkId}"",
                  ""messageId"": ""{expectedMessageId}"",
                  ""from"": ""{expectedFrom}"",
                  ""to"": ""{expectedTo}"",
                  ""sentAt"": ""{expectedSentAt}"",
                  ""mccMnc"": ""{expectedMccMnc}"",
                  ""callbackData"": ""{expectedCallbackData}"",
                  ""voiceCall"": {{
                    ""feature"": ""{expectedFeature}"",
                    ""startTime"": ""{expectedStartTime}"",
                    ""answerTime"": ""{expectedAnswerTime}"",
                    ""endTime"": ""{expectedEndTime}"",
                    ""duration"": {expectedDuration},
                    ""chargedDuration"": {expectedChargedDuration},
                    ""fileDuration"": {expectedFileDuration},
                    ""dtmfCodes"": ""{expectedDtmfCodes}"",
                    ""ivr"": {{
                      ""scenarioId"": ""{expectedScenarioId}"",
                      ""scenarioName"": ""{expectedScenarioName}"",
                      ""collectedDtmfs"": ""{{\""myFirstVar\"":\""3\"",\""mySecondVar\"":\""9\""}}"",
                      ""collectedMappedDtmfs"": null,
                      ""spokenInput"": null,
                      ""matchedSpokenInput"": null
                    }}
                  }},
                  ""price"": {{
                    ""pricePerSecond"": {expectedPricePerSecond},
                    ""currency"": ""{expectedCurrency}""
                  }},
                  ""status"": {{
                    ""groupId"": {expectedStatusGroupId},
                    ""groupName"": ""{expectedStatusGroupName}"",
                    ""id"": {expectedStatusId},
                    ""name"": ""{expectedStatusName}"",
                    ""description"": ""{expectedStatusDescription}""
                  }},
                  ""error"": {{
                    ""groupId"": {expectedErrorGroupId},
                    ""groupName"": ""{expectedErrorGroupName}"",
                    ""id"": {expectedErrorId},
                    ""name"": ""{expectedErrorName}"",
                    ""description"": ""{expectedErrorDescription}"",
                    ""permanent"": {expectedErrorPermanent.ToString().ToLower()}
                  }}
                }}
              ]
            }}";

        var callsReportsResponse = JsonConvert.DeserializeObject<CallsReportResponse>(expectedRequest);
        AssertCallsReportResponse(callsReportsResponse!);

        var callsReportsResponseSystemTextJson = JsonSerializer.Deserialize<CallsReportResponse>(expectedRequest);
        AssertCallsReportResponse(callsReportsResponseSystemTextJson!);

        void AssertCallsReportResponse(CallsReportResponse callsReportResponse)
        {
            Assert.IsNotNull(callsReportResponse);

            var results = callsReportResponse.Results;
            Assert.IsNotNull(callsReportResponse.Results);
            Assert.AreEqual(1, callsReportResponse.Results.Count);

            Assert.AreEqual(expectedBulkId, callsReportResponse.Results[0].BulkId);
            Assert.AreEqual(expectedMessageId, callsReportResponse.Results[0].MessageId);
            Assert.AreEqual(expectedFrom, callsReportResponse.Results[0].From);
            Assert.AreEqual(expectedTo, callsReportResponse.Results[0].To);
            Assert.AreEqual(expectedSentAt, callsReportResponse.Results[0].SentAt);
            Assert.AreEqual(expectedMccMnc, callsReportResponse.Results[0].MccMnc);
            Assert.AreEqual(expectedCallbackData, callsReportResponse.Results[0].CallbackData);
            Assert.AreEqual(expectedFeature, callsReportResponse.Results[0].VoiceCall.Feature);
            Assert.AreEqual(expectedStartTime, callsReportResponse.Results[0].VoiceCall.StartTime);
            Assert.AreEqual(expectedAnswerTime, callsReportResponse.Results[0].VoiceCall.AnswerTime);
            Assert.AreEqual(expectedEndTime, callsReportResponse.Results[0].VoiceCall.EndTime);
            Assert.AreEqual(expectedDuration, callsReportResponse.Results[0].VoiceCall.Duration);
            Assert.AreEqual(expectedChargedDuration, callsReportResponse.Results[0].VoiceCall.ChargedDuration);
            Assert.AreEqual(expectedFileDuration, callsReportResponse.Results[0].VoiceCall.FileDuration);
            Assert.AreEqual(expectedDtmfCodes, callsReportResponse.Results[0].VoiceCall.DtmfCodes);
            Assert.AreEqual(expectedScenarioId, callsReportResponse.Results[0].VoiceCall.Ivr.ScenarioId);
            Assert.AreEqual(expectedScenarioName, callsReportResponse.Results[0].VoiceCall.Ivr.ScenarioName);
            Assert.AreEqual("{\"myFirstVar\":\"3\",\"mySecondVar\":\"9\"}",
                callsReportResponse.Results[0].VoiceCall.Ivr.CollectedDtmfs);
            Assert.AreEqual(null, callsReportResponse.Results[0].VoiceCall.Ivr.CollectedMappedDtmfs);
            Assert.AreEqual(null, callsReportResponse.Results[0].VoiceCall.Ivr.SpokenInput);
            Assert.AreEqual(null, callsReportResponse.Results[0].VoiceCall.Ivr.MatchedSpokenInput);
            Assert.AreEqual(expectedPricePerSecond, callsReportResponse.Results[0].Price.PricePerSecond);
            Assert.AreEqual(expectedCurrency, callsReportResponse.Results[0].Price.Currency);
            Assert.AreEqual(expectedStatusGroupId, callsReportResponse.Results[0].Status.GroupId);
            Assert.AreEqual(expectedStatusGroupName, callsReportResponse.Results[0].Status.GroupName);
            Assert.AreEqual(expectedStatusId, callsReportResponse.Results[0].Status.Id);
            Assert.AreEqual(expectedStatusName, callsReportResponse.Results[0].Status.Name);
            Assert.AreEqual(expectedStatusDescription, callsReportResponse.Results[0].Status.Description);
            Assert.AreEqual(expectedErrorGroupId, callsReportResponse.Results[0].Error.GroupId);
            Assert.AreEqual(expectedErrorGroupName, callsReportResponse.Results[0].Error.GroupName);
            Assert.AreEqual(expectedErrorId, callsReportResponse.Results[0].Error.Id);
            Assert.AreEqual(expectedErrorName, callsReportResponse.Results[0].Error.Name);
            Assert.AreEqual(expectedErrorDescription, callsReportResponse.Results[0].Error.Description);
            Assert.AreEqual(expectedErrorPermanent, callsReportResponse.Results[0].Error.Permanent);
        }
    }

    [TestMethod]
    public void ShouldSearchVoiceIVRScenarios()
    {
        var expectedId = "E83E787CF2613450157ADA3476171E3F";
        var expectedName = "scenario";
        var expectedDescription = "Scenario description";
        var expectedCreateTime = new DateTimeOffset(2023, 9, 14, 15, 13, 36, 735, TimeSpan.FromHours(0));
        var expectedUpdateTime = new DateTimeOffset(2023, 9, 15, 15, 13, 36, 735, TimeSpan.FromHours(0));
        var expectedScript = @"
            [
                {
                    ""say"": ""Hello, please press 1 if you wish to subscribe to our newsletter.""
                },
                {
                    ""collectInto"": ""myCollectedVariable"",
                    ""options"": {
                        ""maxInputLength"": 1,
                        ""timeout"": 5
                    }
                }
            ]";
        var expectedLastUsageDate = "2025-02-18";
        var expectedSecondId = "0157ADA3476171E3E83E787CF261345F";
        var expectedSecondName = "My another scenario";
        var expectedSecondDescription = "Another description";
        var expectedSecondCreateTime = new DateTimeOffset(2023, 9, 14, 15, 14, 12, 123, TimeSpan.FromHours(0));
        var expectedSecondUpdateTime = new DateTimeOffset(2023, 9, 15, 15, 14, 12, 123, TimeSpan.FromHours(0));
        var expectedSecondScript = @"
            [
                {
                  ""repeat"": [
                    {
                      ""say"": ""For exit you must press one."",
                      ""actionId"": 100
                    },
                    {
                      ""collectInto"": ""myVariable""
                    }
                  ],
                  ""while"": ""${myVariable} != 1""
                }
              ]";
        var expectedSecondLastUsageDate = "2025-02-15";

        var expectedResponse = $@"
            [
                {{
                  ""id"": ""{expectedId}"",
                  ""name"": ""{expectedName}"",
                  ""description"": ""{expectedDescription}"",
                  ""createTime"": ""{expectedCreateTime.ToUniversalTime().ToString(DATE_FORMAT)}"",
                  ""updateTime"": ""{expectedUpdateTime.ToUniversalTime().ToString(DATE_FORMAT)}"",
                  ""script"": {expectedScript},
                  ""lastUsageDate"": ""{expectedLastUsageDate}""
                }},
                {{
                  ""id"": ""{expectedSecondId}"",
                  ""name"": ""{expectedSecondName}"",
                  ""description"": ""{expectedSecondDescription}"",
                  ""createTime"": ""{expectedSecondCreateTime.ToUniversalTime().ToString(DATE_FORMAT)}"",
                  ""updateTime"": ""{expectedSecondUpdateTime.ToUniversalTime().ToString(DATE_FORMAT)}"",
                  ""script"": {expectedSecondScript},
                  ""lastUsageDate"": ""{expectedSecondLastUsageDate}""
                }}
            ]";

        var givenPage = 1;
        var givenPageSize = 50;
        var givenName = "name";
        var givenQueryParamters = new Dictionary<string, string>
        {
            { "page", givenPage.ToString() },
            { "pageSize", givenPageSize.ToString() },
            { "name", givenName }
        };

        SetUpGetRequest(VOICE_IVR_SCENARIOS_ENDPOINT, 200, expectedResponse, givenQueryParamters);

        var voiceApi = new VoiceApi(configuration);

        void AssertCallsSearchResponse(List<CallsSearchResponse> callsSearchResponses)
        {
            Assert.IsNotNull(callsSearchResponses);
            Assert.AreEqual(2, callsSearchResponses.Count);

            Assert.AreEqual(expectedId, callsSearchResponses[0].Id);
            Assert.AreEqual(expectedName, callsSearchResponses[0].Name);
            Assert.AreEqual(expectedDescription, callsSearchResponses[0].Description);
            Assert.AreEqual(expectedCreateTime, callsSearchResponses[0].CreateTime);
            Assert.AreEqual(expectedUpdateTime, callsSearchResponses[0].UpdateTime);
            Assert.IsTrue(JToken.DeepEquals(JToken.Parse(expectedScript),
                JToken.Parse(callsSearchResponses[0].Script.ToString())));
            Assert.AreEqual(expectedLastUsageDate, callsSearchResponses[0].LastUsageDate);

            Assert.AreEqual(expectedSecondId, callsSearchResponses[1].Id);
            Assert.AreEqual(expectedSecondName, callsSearchResponses[1].Name);
            Assert.AreEqual(expectedSecondDescription, callsSearchResponses[1].Description);
            Assert.AreEqual(expectedSecondCreateTime, callsSearchResponses[1].CreateTime);
            Assert.AreEqual(expectedSecondUpdateTime, callsSearchResponses[1].UpdateTime);
            Assert.IsTrue(JToken.DeepEquals(JToken.Parse(expectedSecondScript),
                JToken.Parse(callsSearchResponses[1].Script.ToString())));
            Assert.AreEqual(expectedSecondLastUsageDate, callsSearchResponses[1].LastUsageDate);
        }

        AssertResponse(voiceApi.SearchVoiceIvrScenarios(givenPage, givenPageSize, givenName),
            AssertCallsSearchResponse);
        AssertResponse(voiceApi.SearchVoiceIvrScenariosAsync(givenPage, givenPageSize, givenName).Result,
            AssertCallsSearchResponse);
        AssertResponseWithHttpInfo(voiceApi.SearchVoiceIvrScenariosWithHttpInfo(givenPage, givenPageSize, givenName),
            AssertCallsSearchResponse, 200);
        AssertResponseWithHttpInfo(
            voiceApi.SearchVoiceIvrScenariosWithHttpInfoAsync(givenPage, givenPageSize, givenName).Result,
            AssertCallsSearchResponse, 200);
    }

    [TestMethod]
    public void ShouldCreateVoiceIVRScenarios()
    {
        var expectedId = "E83E787CF2613450157ADA3476171E3F";
        var expectedName = "Capture speech or digit";
        var expectedDescription = "Capture speech or digit";
        var expectedScript = @"
            [
              {
                ""say"": ""Say discount or press 1 to get discount. Say exit or press 0 to exit.""
              },
              {
                ""capture"": ""myVar"",
                ""timeout"": 5,
                ""speechOptions"": {
                  ""language"": ""en-US"",
                  ""maxSilence"": 2,
                  ""keyPhrases"": [
                    ""discount"",
                    ""exit""
                  ]
                },
                ""dtmfOptions"": {
                  ""maxInputLength"": 1
                }
              },
              {
                ""if"": ""${myVar == 'discount' || myVar == '1'}"",
                ""then"": [
                  {
                    ""say"": ""You will get discount""
                  }
                ],
                ""else"": [
                  {
                    ""if"": ""${myVar == 'exit' || myVar == '0'}"",
                    ""then"": [
                      {
                        ""say"": ""Goodbye""
                      }
                    ],
                    ""else"": [
                      {
                        ""say"": ""I did not understand""
                      }
                    ]
                  }
                ]
              },
              ""hangup""
            ]";
        var expectedCreateTime = new DateTimeOffset(2024, 11, 9, 17, 0, 0, TimeSpan.FromHours(1));

        var expectedResponse = $@"
            {{
              ""id"": ""{expectedId}"",
              ""name"": ""{expectedName}"",
              ""description"": ""{expectedDescription}"",
              ""script"": {expectedScript},
              ""createTime"": ""{expectedCreateTime}""
            }}";

        var givenName = "Capture speech or digit";
        var givenDescription = "Capture speech or digit";
        var givenScript = @"
            [
              {
                ""say"": ""Say discount or press 1 to get discount. Say exit or press 0 to exit.""
              },
              {
                ""capture"": ""myVar"",
                ""timeout"": 5,
                ""speechOptions"": {
                  ""language"": ""en-US"",
                  ""maxSilence"": 2,
                  ""keyPhrases"": [
                    ""discount"",
                    ""exit""
                  ]
                },
                ""dtmfOptions"": {
                  ""maxInputLength"": 1
                }
              },
              {
                ""if"": ""${myVar == 'discount' || myVar == '1'}"",
                ""then"": [
                  {
                    ""say"": ""You will get discount""
                  }
                ],
                ""else"": [
                  {
                    ""if"": ""${myVar == 'exit' || myVar == '0'}"",
                    ""then"": [
                      {
                        ""say"": ""Goodbye""
                      }
                    ],
                    ""else"": [
                      {
                        ""say"": ""I did not understand""
                      }
                    ]
                  }
                ]
              },
              ""hangup""
            ]";

        var givenRequest = $@"
            {{
              ""name"": ""{givenName}"",
              ""description"": ""{givenDescription}"",
              ""script"": {givenScript}
            }}";

        SetUpPostRequest(VOICE_IVR_SCENARIOS_ENDPOINT, 200, givenRequest, expectedResponse);

        var voiceApi = new VoiceApi(configuration);

        var callsUpdateScenarioRequest = new CallsUpdateScenarioRequest(
            givenName,
            givenDescription,
            new JRaw(givenScript)
        );

        void AssertCallsSearchResponse(CallsUpdateScenarioResponse callsUpdateScenarioResponse)
        {
            Assert.IsNotNull(callsUpdateScenarioResponse);
            Assert.AreEqual(expectedId, callsUpdateScenarioResponse.Id);
            Assert.AreEqual(expectedName, callsUpdateScenarioResponse.Name);
            Assert.AreEqual(expectedDescription, callsUpdateScenarioResponse.Description);
            Assert.IsTrue(JToken.DeepEquals(JToken.Parse(expectedScript),
                JToken.Parse(callsUpdateScenarioResponse.Script.ToString())));
        }

        AssertResponse(voiceApi.CreateAVoiceIvrScenario(callsUpdateScenarioRequest), AssertCallsSearchResponse);
        AssertResponse(voiceApi.CreateAVoiceIvrScenarioAsync(callsUpdateScenarioRequest).Result,
            AssertCallsSearchResponse);
        AssertResponseWithHttpInfo(voiceApi.CreateAVoiceIvrScenarioWithHttpInfo(callsUpdateScenarioRequest),
            AssertCallsSearchResponse, 200);
        AssertResponseWithHttpInfo(voiceApi.CreateAVoiceIvrScenarioWithHttpInfoAsync(callsUpdateScenarioRequest).Result,
            AssertCallsSearchResponse, 200);
    }

    [TestMethod]
    public void ShouldGetVoiceIVRScenario()
    {
        var expectedId = "E83E787CF2613450157ADA3476171E3F";
        var expectedName = "Scenario name";
        var expectedDescription = "Scenario description";
        var expectedCreateTime = new DateTimeOffset(2023, 9, 14, 15, 13, 36, 735, TimeSpan.FromHours(0));
        var expectedUpdateTime = new DateTimeOffset(2023, 9, 15, 15, 13, 36, 735, TimeSpan.FromHours(0));
        var expectedScript = @"
            [
              {
                ""say"": ""Hello, please press 1 if you wish to subscribe to our newsletter.""
              },
              {
                ""collectInto"": ""myCollectedVariable"",
                ""options"": {
                  ""maxInputLength"": 1,
                  ""timeout"": 5
                }
              }
            ]";
        var expectedLastUsageDate = "2025-02-15";

        var expectedResponse = $@"
            {{
              ""id"": ""{expectedId}"",
              ""name"": ""{expectedName}"",
              ""description"": ""{expectedDescription}"",
              ""createTime"": ""{expectedCreateTime.ToUniversalTime().ToString(DATE_FORMAT)}"",
              ""updateTime"": ""{expectedUpdateTime.ToUniversalTime().ToString(DATE_FORMAT)}"",
              ""script"": {expectedScript},
              ""lastUsageDate"": ""{expectedLastUsageDate}""
            }}";

        var givenId = "E83E787CF2613450157ADA3476171E3F";

        SetUpGetRequest(VOICE_IVR_SCENARIO_ENDPOINT.Replace("{id}", givenId), 200, expectedResponse);

        var voiceApi = new VoiceApi(configuration);

        void AssertCallsSearchResponse(CallsUpdateScenarioResponse callsUpdateScenarioResponse)
        {
            Assert.IsNotNull(callsUpdateScenarioResponse);
            Assert.AreEqual(expectedId, callsUpdateScenarioResponse.Id);
            Assert.AreEqual(expectedName, callsUpdateScenarioResponse.Name);
            Assert.AreEqual(expectedDescription, callsUpdateScenarioResponse.Description);
            Assert.AreEqual(expectedCreateTime, callsUpdateScenarioResponse.CreateTime);
            Assert.AreEqual(expectedUpdateTime, callsUpdateScenarioResponse.UpdateTime);
            Assert.AreEqual(expectedLastUsageDate, callsUpdateScenarioResponse.LastUsageDate);
            Assert.IsTrue(JToken.DeepEquals(JToken.Parse(expectedScript),
                JToken.Parse(callsUpdateScenarioResponse.Script.ToString())));
        }

        AssertResponse(voiceApi.GetAVoiceIvrScenario(givenId),
            AssertCallsSearchResponse);
        AssertResponse(voiceApi.GetAVoiceIvrScenarioAsync(givenId).Result,
            AssertCallsSearchResponse);
        AssertResponseWithHttpInfo(voiceApi.GetAVoiceIvrScenarioWithHttpInfo(givenId),
            AssertCallsSearchResponse, 200);
        AssertResponseWithHttpInfo(
            voiceApi.GetAVoiceIvrScenarioWithHttpInfoAsync(givenId).Result,
            AssertCallsSearchResponse, 200);
    }

    [TestMethod]
    public void ShouldUpdateVoiceIVRScenarios()
    {
        var expectedId = "E83E787CF2613450157ADA3476171E3F";
        var expectedName = "For-Each";
        var expectedDescription = "Use For-each to perform any action for each of provided values.";
        var expectedScript = @"
            [
              {
                ""forEach"": ""city"",
                ""in"": ""New York,Los Angeles,Boston"",
                ""do"": [
                  {
                    ""say"": ""Hello from ${city}""
                  }
                ]
              }
            ]";
        var expectedCreateTime = "2024-11-09T17:00:00.000+0100";
        var expectedUpdateTime = "2024-11-09T17:10:00.000+0100";

        var expectedResponse = $@"
            {{
              ""id"": ""{expectedId}"",
              ""name"": ""{expectedName}"",
              ""description"": ""{expectedDescription}"",
              ""script"": {expectedScript},
              ""createTime"": ""{expectedCreateTime}"",
              ""updateTime"": ""{expectedUpdateTime}""
            }}";

        var givenName = "For-Each";
        var givenDescription = "Use For-each to perform any action for each of provided values.";
        var givenScript = @"
            [
              {
                ""forEach"": ""city"",
                ""in"": ""New York,Los Angeles,Boston"",
                ""do"": [
                  {
                    ""say"": ""Hello from ${city}""
                  }
                ]
              }
            ]";

        var givenRequest = $@"
            {{
              ""name"": ""{givenName}"",
              ""description"": ""{givenDescription}"",
              ""script"": {givenScript}
            }}";

        var givenId = "E83E787CF2613450157ADA3476171E3F";

        SetUpPutRequest(VOICE_IVR_SCENARIO_ENDPOINT.Replace("{id}", givenId), 200, givenRequest, expectedResponse);

        var voiceApi = new VoiceApi(configuration);

        var callsUpdateScenarioRequest = new CallsUpdateScenarioRequest(
            givenName,
            givenDescription,
            new JRaw(givenScript)
        );

        void AssertCallsSearchResponse(CallsUpdateScenarioResponse callsUpdateScenarioResponse)
        {
            Assert.IsNotNull(callsUpdateScenarioResponse);
            Assert.AreEqual(expectedId, callsUpdateScenarioResponse.Id);
            Assert.AreEqual(expectedName, callsUpdateScenarioResponse.Name);
            Assert.AreEqual(expectedDescription, callsUpdateScenarioResponse.Description);
            Assert.IsTrue(JToken.DeepEquals(JToken.Parse(expectedScript),
                JToken.Parse(callsUpdateScenarioResponse.Script.ToString())));
            Assert.AreEqual(DateTimeOffset.Parse(expectedCreateTime), callsUpdateScenarioResponse.CreateTime);
            Assert.AreEqual(DateTimeOffset.Parse(expectedUpdateTime), callsUpdateScenarioResponse.UpdateTime);
        }

        AssertResponse(voiceApi.UpdateVoiceIvrScenario(givenId, callsUpdateScenarioRequest), AssertCallsSearchResponse);
        AssertResponse(voiceApi.UpdateVoiceIvrScenarioAsync(givenId, callsUpdateScenarioRequest).Result,
            AssertCallsSearchResponse);
        AssertResponseWithHttpInfo(voiceApi.UpdateVoiceIvrScenarioWithHttpInfo(givenId, callsUpdateScenarioRequest),
            AssertCallsSearchResponse, 200);
        AssertResponseWithHttpInfo(
            voiceApi.UpdateVoiceIvrScenarioWithHttpInfoAsync(givenId, callsUpdateScenarioRequest).Result,
            AssertCallsSearchResponse, 200);
    }

    [TestMethod]
    public void ShouldDeleteVoiceIVRScenarios()
    {
        var givenId = "E83E787CF2613450157ADA3476171E3F";

        SetUpDeleteRequest(VOICE_IVR_SCENARIO_ENDPOINT.Replace("{id}", givenId), 200);

        var voiceApi = new VoiceApi(configuration);

        AssertNoBodyResponseWithHttpInfo(voiceApi.DeleteAVoiceIvrScenarioWithHttpInfo(givenId), 200);
        AssertNoBodyResponseWithHttpInfo(voiceApi.DeleteAVoiceIvrScenarioWithHttpInfoAsync(givenId).Result, 200);
    }

    [TestMethod]
    public void ShouldLaunchVoiceIVRScenarios()
    {
        var expectedBulkId = "5028e2d42f19-42f1-4656-351e-a42c191e5fd2";
        var expectedTo = "41793026727";
        var expectedGroupId = 1;
        var expectedGroupName = "PENDING";
        var expectedId = 26;
        var expectedName = "PENDING_ACCEPTED";
        var expectedDescription = "Message accepted, pending for delivery.";
        var expectedMessageId = "4242f196ba50-a356-2f91-831c4aa55f351ed2";
        var expectedSecondTo = "41793026731";
        var expectedSecondGroupId = 1;
        var expectedSecondGroupName = "PENDING";
        var expectedSecondId = 26;
        var expectedSecondName = "PENDING_ACCEPTED";
        var expectedSecondDescription = "Message accepted, pending for delivery.";
        var expectedSecondMessageId = "5f35f896ba50-a356-43a4-91cd81b85f8c689";

        var expectedResponse = $@"
            {{
              ""bulkId"": ""{expectedBulkId}"",
              ""messages"": [
                {{
                  ""to"": ""{expectedTo}"",
                  ""status"": {{
                    ""groupId"": {expectedGroupId},
                    ""groupName"": ""{expectedGroupName}"",
                    ""id"": {expectedId},
                    ""name"": ""{expectedName}"",
                    ""description"": ""{expectedDescription}""
                  }},
                  ""messageId"": ""{expectedMessageId}""
                }},
                {{
                  ""to"": ""{expectedSecondTo}"",
                  ""status"": {{
                    ""groupId"": {expectedSecondGroupId},
                    ""groupName"": ""{expectedSecondGroupName}"",
                    ""id"": {expectedSecondId},
                    ""name"": ""{expectedSecondName}"",
                    ""description"": ""{expectedSecondDescription}""
                  }},
                  ""messageId"": ""{expectedSecondMessageId}""
                }}
              ]
            }}";

        var givenBulkId = "BULK-ID-123-xyz";
        var givenScenarioId = "6298AA7707903A4ED680B436929681AD";
        var givenFrom = "41793026700";
        var givenTo = "41793026727";
        var givenSecondTo = "41793026731";
        var givenNotifyUrl = "https://www.example.com/voice/advanced";
        var givenNotifyContentType = "application/json";
        var givenCallbackData = "DLR callback data";
        var givenValidityPeriod = 720;
        var givenSendAt = new DateTimeOffset(2023, 10, 3, 12, 21, 00, 632, TimeSpan.FromHours(0));
        var givenMinPeriod = 1;
        var givenMaxPeriod = 5;
        var givenMaxCount = 5;
        var givenRecord = false;
        var givenFromHour = 6;
        var givenFromMinute = 15;
        var givenToHour = 15;
        var givenToMinute = 30;
        var givenFirstDay = "MONDAY";
        var givenSecondDay = "TUESDAY";
        var givenThirdDay = "WEDNESDAY";
        var givenFourthDay = "THURSDAY";
        var givenFifthDay = "FRIDAY";
        var givenSixthDay = "SATURDAY";
        var givenSeventhDay = "SUNDAY";

        var givenRequest = $@"
            {{
              ""bulkId"": ""{givenBulkId}"",
              ""messages"": [
                {{
                  ""scenarioId"": ""{givenScenarioId}"",
                  ""from"": ""{givenFrom}"",
                  ""destinations"": [
                    {{
                      ""to"": ""{givenTo}""
                    }},
                    {{
                      ""to"": ""{givenSecondTo}""
                    }}
                  ],
                  ""notifyUrl"": ""{givenNotifyUrl}"",
                  ""notifyContentType"": ""{givenNotifyContentType}"",
                  ""callbackData"": ""{givenCallbackData}"",
                  ""validityPeriod"": {givenValidityPeriod},
                  ""sendAt"": ""{givenSendAt.ToUniversalTime().ToString(DATE_FORMAT)}"",
                  ""retry"": {{
                    ""minPeriod"": {givenMinPeriod},
                    ""maxPeriod"": {givenMaxPeriod},
                    ""maxCount"": {givenMaxCount}
                  }},
                  ""record"": {givenRecord.ToString().ToLower()},
                  ""deliveryTimeWindow"": {{
                    ""from"": {{
                      ""hour"": {givenFromHour},
                      ""minute"": {givenFromMinute}
                    }},
                    ""to"": {{
                      ""hour"": {givenToHour},
                      ""minute"": {givenToMinute}
                    }},
                    ""days"": [
                      ""{givenFirstDay}"",
                      ""{givenSecondDay}"",
                      ""{givenThirdDay}"",
                      ""{givenFourthDay}"",
                      ""{givenFifthDay}"",
                      ""{givenSixthDay}"",
                      ""{givenSeventhDay}""
                    ]
                  }}
                }}
              ]
            }}";

        SetUpPostRequest(VOICE_IVR_MESSAGE_ENDPOINT, 200, givenRequest, expectedResponse);

        var voiceApi = new VoiceApi(configuration);

        var callsLaunchScenarioRequest = new CallsLaunchScenarioRequest(
            givenBulkId,
            new List<CallsIvrMessage>
            {
                new(
                    givenScenarioId,
                    givenFrom,
                    new List<CallsDestination>
                    {
                        new(
                            to: givenTo
                        ),
                        new(
                            to: givenSecondTo
                        )
                    },
                    givenNotifyUrl,
                    givenNotifyContentType,
                    callbackData: givenCallbackData,
                    validityPeriod: givenValidityPeriod,
                    sendAt: givenSendAt,
                    retry: new CallsRetry(
                        minPeriod: givenMinPeriod,
                        maxPeriod: givenMaxPeriod,
                        maxCount: givenMaxCount
                    ),
                    record: givenRecord,
                    deliveryTimeWindow: new DeliveryTimeWindow(
                        from: new DeliveryTime(
                            givenFromHour,
                            givenFromMinute
                        ),
                        to: new DeliveryTime(
                            givenToHour,
                            givenToMinute
                        ),
                        days: new List<DeliveryDay>
                        {
                            DeliveryDay.Monday,
                            DeliveryDay.Tuesday,
                            DeliveryDay.Wednesday,
                            DeliveryDay.Thursday,
                            DeliveryDay.Friday,
                            DeliveryDay.Saturday,
                            DeliveryDay.Sunday
                        }
                    )
                )
            }
        );

        void AssertCallsVoiceResponse(CallsVoiceResponse callsVoiceResponse)
        {
            Assert.IsNotNull(callsVoiceResponse);
            Assert.AreEqual(expectedBulkId, callsVoiceResponse.BulkId);

            Assert.IsNotNull(callsVoiceResponse.Messages);
            var messages = callsVoiceResponse.Messages;
            Assert.AreEqual(2, messages.Count);

            Assert.AreEqual(expectedTo, messages[0].To);
            Assert.AreEqual(expectedGroupId, messages[0].Status.GroupId);
            Assert.AreEqual(expectedGroupName, messages[0].Status.GroupName);
            Assert.AreEqual(expectedId, messages[0].Status.Id);
            Assert.AreEqual(expectedName, messages[0].Status.Name);
            Assert.AreEqual(expectedDescription, messages[0].Status.Description);
            Assert.AreEqual(expectedMessageId, messages[0].MessageId);

            Assert.AreEqual(expectedSecondTo, messages[1].To);
            Assert.AreEqual(expectedSecondGroupId, messages[1].Status.GroupId);
            Assert.AreEqual(expectedSecondGroupName, messages[1].Status.GroupName);
            Assert.AreEqual(expectedSecondId, messages[1].Status.Id);
            Assert.AreEqual(expectedSecondName, messages[1].Status.Name);
            Assert.AreEqual(expectedSecondDescription, messages[1].Status.Description);
            Assert.AreEqual(expectedSecondMessageId, messages[1].MessageId);
        }

        AssertResponse(voiceApi.SendVoiceMessagesWithAnIvrScenario(callsLaunchScenarioRequest),
            AssertCallsVoiceResponse);
        AssertResponse(voiceApi.SendVoiceMessagesWithAnIvrScenarioAsync(callsLaunchScenarioRequest).Result,
            AssertCallsVoiceResponse);
        AssertResponseWithHttpInfo(voiceApi.SendVoiceMessagesWithAnIvrScenarioWithHttpInfo(callsLaunchScenarioRequest),
            AssertCallsVoiceResponse, 200);
        AssertResponseWithHttpInfo(
            voiceApi.SendVoiceMessagesWithAnIvrScenarioWithHttpInfoAsync(callsLaunchScenarioRequest).Result,
            AssertCallsVoiceResponse, 200);
    }

    [TestMethod]
    public void ShouldSearchVoiceIvrRecordedFiles()
    {
        var expectedMessageId = "453e161a-fe4f-4f3c-80c0-ab520de9a969";
        var expectedFrom = "442032864231";
        var expectedTo = "38712345678";
        var expectedScenarioId = "C9CE33CF130511D8E333C1260BABA309";
        var expectedGroupId = "#/script/1";
        var expectedUrl =
            "/voice/ivr/1/files/3C67336FA555A606C85FA9637906A6AB98436B7AFC65D857A416F6521D39F8F0E1D3D2469FF580D8968D3DD89A2DB561";
        var expectedRecordedAt = new DateTimeOffset(2023, 10, 25, 12, 36, 37, 234, TimeSpan.FromHours(0));
        var expectedSecondMessageId = "05b2859d-85c6-4068-9347-2e563b5c9cf4";
        var expectedSecondFrom = "442032864231";
        var expectedSecondTo = "38712345678";
        var expectedSecondScenarioId = "4A6177C9B92039306F1F091708851A2E";
        var expectedSecondGroupId = "#/script/1";
        var expectedSecondUrl =
            "/voice/ivr/1/files/305DE72BA11D81D1BAED75BFC46706761580BDEC2218C22628447FD3814E7913D3058E4ECBFD6F55C80E976235EEB111";
        var expectedSecondRecordedAt = new DateTimeOffset(2023, 10, 25, 12, 36, 37, 240, TimeSpan.FromHours(0));

        var expectedResponse = $@"
            {{
              ""files"": [
                {{
                  ""messageId"": ""{expectedMessageId}"",
                  ""from"": ""{expectedFrom}"",
                  ""to"": ""{expectedTo}"",
                  ""scenarioId"": ""{expectedScenarioId}"",
                  ""groupId"": ""{expectedGroupId}"",
                  ""url"": ""{expectedUrl}"",
                  ""recordedAt"": ""{expectedRecordedAt.ToUniversalTime().ToString(DATE_FORMAT)}""
                }},
                {{
                  ""messageId"": ""{expectedSecondMessageId}"",
                  ""from"": ""{expectedSecondFrom}"",
                  ""to"": ""{expectedSecondTo}"",
                  ""scenarioId"": ""{expectedSecondScenarioId}"",
                  ""groupId"": ""{expectedSecondGroupId}"",
                  ""url"": ""{expectedSecondUrl}"",
                  ""recordedAt"": ""{expectedSecondRecordedAt.ToUniversalTime().ToString(DATE_FORMAT)}""
                }}
              ]
            }}";

        var givenPage = 1;
        var givenPageSize = 20;

        var givenQueryParameters = new Dictionary<string, string>
        {
            { "page", givenPage.ToString() },
            { "pageSize", givenPageSize.ToString() }
        };

        SetUpGetRequest(VOICE_IVR_FILES_ENDPOINT, 200, expectedResponse, givenQueryParameters);

        var voiceApi = new VoiceApi(configuration);

        void AssertCallsRecordedAudioFilesResponses(
            CallsRecordedAudioFilesResponse callsRecordedAudioFilesResponses)
        {
            Assert.IsNotNull(callsRecordedAudioFilesResponses);
            Assert.AreEqual(2, callsRecordedAudioFilesResponses.Files.Count);

            Assert.AreEqual(expectedMessageId, callsRecordedAudioFilesResponses.Files[0].MessageId);
            Assert.AreEqual(expectedFrom, callsRecordedAudioFilesResponses.Files[0].From);
            Assert.AreEqual(expectedTo, callsRecordedAudioFilesResponses.Files[0].To);
            Assert.AreEqual(expectedScenarioId, callsRecordedAudioFilesResponses.Files[0].ScenarioId);
            Assert.AreEqual(expectedGroupId, callsRecordedAudioFilesResponses.Files[0].GroupId);
            Assert.AreEqual(expectedUrl, callsRecordedAudioFilesResponses.Files[0].Url);
            Assert.AreEqual(expectedRecordedAt, callsRecordedAudioFilesResponses.Files[0].RecordedAt);
        }

        AssertResponse(voiceApi.SearchVoiceIvrRecordedFiles(givenPage, givenPageSize),
            AssertCallsRecordedAudioFilesResponses);
        AssertResponse(voiceApi.SearchVoiceIvrRecordedFilesAsync(givenPage, givenPageSize).Result,
            AssertCallsRecordedAudioFilesResponses);
        AssertResponseWithHttpInfo(voiceApi.SearchVoiceIvrRecordedFilesWithHttpInfo(givenPage, givenPageSize),
            AssertCallsRecordedAudioFilesResponses, 200);
        AssertResponseWithHttpInfo(
            voiceApi.SearchVoiceIvrRecordedFilesWithHttpInfoAsync(givenPage, givenPageSize).Result,
            AssertCallsRecordedAudioFilesResponses, 200);
    }

    [TestMethod]
    public void ShouldDownloadVoiceIvrRecordedFile()
    {
        var expectedContentType = "application/octet-stream";
        var expectedContentText = "fileResponse";
        var expectedContent = new MemoryStream(Encoding.UTF8.GetBytes(expectedContentText));
        var expectedFileParameter = new FileParameter(expectedContent);

        var givenId = "file-id-123";

        SetUpGetRequestBinary(VOICE_IVR_FILE_ENDPOINT.Replace("{id}", givenId), 200, expectedContentText);

        var voiceApi = new VoiceApi(configuration);

        void AssertFileParameter(FileParameter fileParameter)
        {
            Assert.IsNotNull(fileParameter);
            Assert.AreEqual(expectedContentText, new StreamReader(fileParameter.Content, Encoding.UTF8).ReadToEnd());
            Assert.AreEqual(expectedContentType, fileParameter.ContentType);
        }

        AssertResponse(voiceApi.DownloadVoiceIvrRecordedFile(givenId), AssertFileParameter);
    }
}