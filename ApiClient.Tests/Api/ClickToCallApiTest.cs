using Infobip.Api.Client.Api;
using Infobip.Api.Client.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ApiClient.Tests.Api;

[TestClass]
public class ClickToCallApiTest : ApiTest
{
    protected const string SEND_CTC_ENDPOINT = "/voice/ctc/1/send";

    [TestMethod]
    public void ShouldSendClickToCallMessage()
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

        var givenBulkId = "BULK-ID-123-xyz";
        var givenFrom = "41793026700";
        var givenFromB = "41793026701";
        var givenDestinationA = "41793026727";
        var givenDestinationB = "41793026731";
        var givenMessageId = "MESSAGE-ID-123-xyz";
        var givenText = "Test Voice message.";
        var givenLanguage = "en";
        var givenName = "Joanna";
        var givenGender = "female";
        var givenAnonymization = false;
        var givenNotifyUrl = "https://www.example.com/voice/clicktocall";
        var givenNotifyContentType = "application/json";
        var givenMaxDuration = 60;
        var givenWarningTime = 5;
        var givenMinPeriod = 1;
        var givenMaxPeriod = 5;
        var givenMaxCount = 5;
        var givenMachineDetection = "hangup";
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
                  ""fromB"": ""{givenFromB}"",
                  ""destinationA"": ""{givenDestinationA}"",
                  ""destinationB"": ""{givenDestinationB}"",
                  ""messageId"": ""{givenMessageId}"",
                  ""text"": ""{givenText}"",
                  ""language"": ""{givenLanguage}"",
                  ""voice"": {{
                    ""name"": ""{givenName}"",
                    ""gender"": ""{givenGender}""
                  }},
                  ""anonymization"": {givenAnonymization.ToString().ToLower()},
                  ""notifyUrl"": ""{givenNotifyUrl}"",
                  ""notifyContentType"": ""{givenNotifyContentType}"",
                  ""maxDuration"": {givenMaxDuration},
                  ""warningTime"": {givenWarningTime},
                  ""retry"": {{
                    ""minPeriod"": {givenMinPeriod},
                    ""maxPeriod"": {givenMaxPeriod},
                    ""maxCount"": {givenMaxCount}
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

        SetUpPostRequest(SEND_CTC_ENDPOINT, 200, givenRequest, expectedResponse);

        var clickToCallApi = new ClickToCallApi(configuration);

        var callsClickToCallMessageBody = new CallsClickToCallMessageBody(
            givenBulkId,
            new List<CallsClickToCallMessage>
            {
                new(
                    from: givenFrom,
                    fromB: givenFromB,
                    destinationA: givenDestinationA,
                    destinationB: givenDestinationB,
                    messageId: givenMessageId,
                    text: givenText,
                    language: givenLanguage,
                    voice: new CallsVoice(
                        name: givenName,
                        gender: givenGender
                    ),
                    notifyUrl: givenNotifyUrl,
                    anonymization: givenAnonymization,
                    notifyContentType: givenNotifyContentType,
                    maxDuration: givenMaxDuration,
                    warningTime: givenWarningTime,
                    retry: new CallsRetry(
                        minPeriod: givenMinPeriod,
                        maxPeriod: givenMaxPeriod,
                        maxCount: givenMaxCount
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
            Assert.AreEqual(1, messages.Count);

            Assert.AreEqual(expectedTo, messages[0].To);
            Assert.AreEqual(expectedGroupId, messages[0].Status.GroupId);
            Assert.AreEqual(expectedGroupName, messages[0].Status.GroupName);
            Assert.AreEqual(expectedId, messages[0].Status.Id);
            Assert.AreEqual(expectedName, messages[0].Status.Name);
            Assert.AreEqual(expectedDescription, messages[0].Status.Description);
            Assert.AreEqual(expectedMessageId, messages[0].MessageId);
        }

        AssertResponse(clickToCallApi.SendClickToCallMessage(callsClickToCallMessageBody), AssertCallsVoiceResponse);
        AssertResponse(clickToCallApi.SendClickToCallMessageAsync(callsClickToCallMessageBody).Result,
            AssertCallsVoiceResponse);
        AssertResponseWithHttpInfo(clickToCallApi.SendClickToCallMessageWithHttpInfo(callsClickToCallMessageBody),
            AssertCallsVoiceResponse, 200);
        AssertResponseWithHttpInfo(
            clickToCallApi.SendClickToCallMessageWithHttpInfoAsync(callsClickToCallMessageBody).Result,
            AssertCallsVoiceResponse, 200);
    }
}