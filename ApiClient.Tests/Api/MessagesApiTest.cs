using Infobip.Api.Client.Api;
using Infobip.Api.Client.Model;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace ApiClient.Tests.Api;

[TestClass]
public class MessagesApiTest : ApiTest
{
    protected const string MESSAGES_SEND_ENDPOINT = "/messages-api/1/messages";
    protected const string MESSAGES_VALIDATE_ENDPOINT = "/messages-api/1/messages/validate";
    protected const string MESSAGES_EVENTS_ENDPOINT = "/messages-api/1/events";
    protected const string MESSAGES_REPORTS_ENDPOINT = "/messages-api/1/reports";
    protected const string MESSAGES_INBOUND_ENDPOINT = "/messages-api/1/inbound";

    [TestMethod]
    public void ShouldSendMessagesApiMessage()
    {
        var givenChannel = MessagesApiOutboundMessageChannel.AppleMb;
        var givenSender = "e1c86198-d9bf-43ee-a635-7fe9cbcf45ad";
        var givenTo =
            "urn:mbid:AQAAY6xHR8jJXQr78AG+hTy/xz8H/slwhA06+fLuhMyGKnWAB2DNFenG1r8hAFckmalbZiBRorHQXNcnCg7OK94H+tEF/CI4wDdedyL0E+mDYIwDG+Xcd05xQc0i7GNgRGs1QZmn4Yr5foi6H6ebjivoHbo3cl0=";
        var givenText = "When do you want to meet?";
        var givenImageUrl = "https://example.com/image.jpg";
        var givenEventTitle = "Important meeting";
        var givenFirstSlotDuration = 3600;
        var givenFirstSlotStartTime = DateTimeOffset.Parse("2026-05-26T08:30:00Z");
        var givenSecondSlotDuration = 3600;
        var givenSecondSlotStartTime = DateTimeOffset.Parse("2026-05-26T09:30:00Z");
        var givenLatitude = 44.95305;
        var givenLongitude = 13.85637;
        var givenRadius = 50.0;
        var givenLocationName = "Infobip d.o.o.";
        var givenConfirmationText = "Thanks!";
        var givenConfirmationImageUrl = "https://example.com/thanks.jpg";

        var expectedBulkId = "1688025180464000013";
        var expectedMessageId = "1688025180464000014";
        var expectedStatusGroupId = 1;
        var expectedStatusGroupName = "PENDING";
        var expectedStatusId = 26;
        var expectedStatusName = "MESSAGE_ACCEPTED";
        var expectedStatusDescription = "Message sent to next instance";
        var expectedDestination = "48600700800";

        var givenRequest = $@"
            {{
              ""messages"": [
                {{
                  ""channel"": ""{GetEnumAttributeValue(givenChannel)}"",
                  ""sender"": ""{givenSender}"",
                  ""destinations"": [
                    {{
                      ""to"": ""{givenTo}""
                    }}
                  ],
                  ""content"": {{
                    ""body"": {{
                      ""text"": ""{givenText}"",
                      ""imageUrl"": ""{givenImageUrl}"",
                      ""event"": {{
                        ""title"": ""{givenEventTitle}"",
                        ""timeslots"": [
                          {{
                            ""duration"": {givenFirstSlotDuration},
                            ""startTime"": ""{givenFirstSlotStartTime:yyyy-MM-ddTHH:mm:sszzz}""
                          }},
                          {{
                            ""duration"": {givenSecondSlotDuration},
                            ""startTime"": ""{givenSecondSlotStartTime:yyyy-MM-ddTHH:mm:sszzz}""
                          }}
                        ],
                        ""location"": {{
                          ""latitude"": {givenLatitude},
                          ""longitude"": {givenLongitude},
                          ""radius"": {givenRadius:0.0},
                          ""name"": ""{givenLocationName}""
                        }}
                      }},
                      ""type"": ""TIME_PICKER""
                    }},
                    ""confirmationBody"": {{
                      ""text"": ""{givenConfirmationText}"",
                      ""imageUrl"": ""{givenConfirmationImageUrl}""
                    }}
                  }}
                }}
              ]
            }}";

        var expectedResponse = $@"
            {{
              ""bulkId"": ""{expectedBulkId}"",
              ""messages"": [
                {{
                  ""messageId"": ""{expectedMessageId}"",
                  ""status"": {{
                    ""groupId"": {expectedStatusGroupId},
                    ""groupName"": ""{expectedStatusGroupName}"",
                    ""id"": {expectedStatusId},
                    ""name"": ""{expectedStatusName}"",
                    ""description"": ""{expectedStatusDescription}""
                  }},
                  ""destination"": ""{expectedDestination}""
                }}
              ]
            }}";

        SetUpPostRequest(MESSAGES_SEND_ENDPOINT, 200, givenRequest, expectedResponse);

        var messagesApi = new MessagesApi(Configuration);

        var request = new MessagesApiRequest(
            new List<MessagesApiBaseMessage>
            {
                new(new MessagesApiMessage(
                    givenChannel,
                    givenSender,
                    new List<MessagesApiMessageDestination>
                    {
                        new(new MessagesApiToDestination(givenTo))
                    },
                    new MessagesApiMessageContent(
                        body: new MessagesApiMessageTimePickerBody(
                            givenText,
                            imageUrl: givenImageUrl,
                            @event: new MessagesApiMessageTimePickerEvent(
                                givenEventTitle,
                                new List<MessagesApiMessageTimePickerTimeslot>
                                {
                                    new(givenFirstSlotDuration, givenFirstSlotStartTime),
                                    new(givenSecondSlotDuration, givenSecondSlotStartTime)
                                },
                                new MessagesApiMessageTimePickerLocation(
                                    givenLatitude,
                                    givenLongitude,
                                    givenRadius,
                                    givenLocationName
                                )
                            )
                        ),
                        confirmationBody: new MessagesApiMessageConfirmationBody(
                            givenConfirmationText,
                            imageUrl: givenConfirmationImageUrl
                        )
                    )
                ))
            }
        );

        void AssertMessageResponse(MessageResponse messageResponse)
        {
            Assert.IsNotNull(messageResponse);
            Assert.AreEqual(expectedBulkId, messageResponse.BulkId);

            Assert.IsNotNull(messageResponse.Messages);
            Assert.AreEqual(1, messageResponse.Messages.Count);

            var message = messageResponse.Messages[0];
            Assert.AreEqual(expectedMessageId, message.MessageId);
            Assert.AreEqual(expectedDestination, message.Destination);

            var status = message.Status;
            Assert.IsNotNull(status);
            Assert.AreEqual(expectedStatusGroupId, status.GroupId);
            Assert.AreEqual(expectedStatusGroupName, status.GroupName);
            Assert.AreEqual(expectedStatusId, status.Id);
            Assert.AreEqual(expectedStatusName, status.Name);
            Assert.AreEqual(expectedStatusDescription, status.Description);
        }

        AssertResponse(messagesApi.SendMessagesApiMessage(request), AssertMessageResponse);
        AssertResponse(messagesApi.SendMessagesApiMessageAsync(request).Result, AssertMessageResponse);
        AssertResponseWithHttpInfo(messagesApi.SendMessagesApiMessageWithHttpInfo(request), AssertMessageResponse, 200);
        AssertResponseWithHttpInfo(messagesApi.SendMessagesApiMessageWithHttpInfoAsync(request).Result,
            AssertMessageResponse, 200);
    }

    [TestMethod]
    public void ShouldValidateMessagesApiMessage()
    {
        var givenChannel = MessagesApiOutboundMessageChannel.Sms;
        var givenSender = "447491163862";
        var givenTo = "123456789";
        var givenText = "Sending you lots of otterly delightful vibes today!";
        var givenBodyType = MessagesApiMessageBodyType.Text;

        var expectedDescription =
            "Request can be sent through '/messages' endpoint and should be accepted by our platform.";
        var expectedAction = "No action is required, but it is recommended to check and address any violations.";
        var expectedViolationProperty = "messages[0].metadata";
        var expectedViolationMessage = "Unknown property";

        var givenRequest = $@"
            {{
              ""messages"": [
                {{
                  ""channel"": ""{GetEnumAttributeValue(givenChannel)}"",
                  ""sender"": ""{givenSender}"",
                  ""destinations"": [
                    {{
                      ""to"": ""{givenTo}""
                    }}
                  ],
                  ""content"": {{
                    ""body"": {{
                      ""text"": ""{givenText}"",
                      ""type"": ""{GetEnumAttributeValue(givenBodyType)}""
                    }}
                  }}
                }}
              ]
            }}";

        var expectedResponse = $@"
            {{
              ""description"": ""{expectedDescription}"",
              ""action"": ""{expectedAction}"",
              ""skippableViolations"": [
                {{
                  ""property"": ""{expectedViolationProperty}"",
                  ""violation"": ""{expectedViolationMessage}""
                }}
              ]
            }}";

        SetUpPostRequest(MESSAGES_VALIDATE_ENDPOINT, 200, givenRequest, expectedResponse);

        var messagesApi = new MessagesApi(Configuration);

        var request = new MessagesApiRequest(
            new List<MessagesApiBaseMessage>
            {
                new(new MessagesApiMessage(
                    givenChannel,
                    givenSender,
                    new List<MessagesApiMessageDestination>
                    {
                        new(new MessagesApiToDestination(givenTo))
                    },
                    new MessagesApiMessageContent(
                        body: new MessagesApiMessageTextBody(givenText)
                    )
                ))
            }
        );

        void AssertValidationResponse(MessagesApiValidationOkResponse validationResponse)
        {
            Assert.IsNotNull(validationResponse);
            Assert.AreEqual(expectedDescription, validationResponse.Description);
            Assert.AreEqual(expectedAction, validationResponse.Action);

            Assert.IsNotNull(validationResponse.SkippableViolations);
            Assert.AreEqual(1, validationResponse.SkippableViolations.Count);

            var violation = validationResponse.SkippableViolations[0];
            Assert.AreEqual(expectedViolationProperty, violation.Property);
            Assert.AreEqual(expectedViolationMessage, violation.Violation);
        }

        AssertResponse(messagesApi.ValidateMessagesApiMessage(request), AssertValidationResponse);
        AssertResponse(messagesApi.ValidateMessagesApiMessageAsync(request).Result, AssertValidationResponse);
        AssertResponseWithHttpInfo(messagesApi.ValidateMessagesApiMessageWithHttpInfo(request),
            AssertValidationResponse, 200);
        AssertResponseWithHttpInfo(messagesApi.ValidateMessagesApiMessageWithHttpInfoAsync(request).Result,
            AssertValidationResponse, 200);
    }

    [TestMethod]
    public void ShouldSendMessagesApiEvent()
    {
        var givenChannel = MessagesApiOutboundTypingStartedEventChannel.AppleMb;
        var givenSender = "e1c86198-d9bf-43ee-a635-7fe9cbcf45ad";
        var givenTo =
            "urn:mbid:AQAAY6xHR8jJXQr78AG+hTy/xz8H/slwhA06+fLuhMyGKnWAB2DNFenG1r8hAFckmalbZiBRorHQXNcnCg7OK94H+tEF/CI4wDdedyL0E+mDYIwDG+Xcd05xQc0i7GNgRGs1QZmn4Yr5foi6H6ebjivoHbo3cl0=";
        var givenEventType = MessagesApiOutboundEventType.TypingStarted;

        var expectedBulkId = "1688025180464000013";
        var expectedMessageId = "1688025180464000014";
        var expectedStatusGroupId = 1;
        var expectedStatusGroupName = "PENDING";
        var expectedStatusId = 26;
        var expectedStatusName = "MESSAGE_ACCEPTED";
        var expectedStatusDescription = "Message sent to next instance";
        var expectedDestination = "48600700800";

        var givenRequest = $@"
            {{
              ""events"": [
                {{
                  ""channel"": ""{GetEnumAttributeValue(givenChannel)}"",
                  ""sender"": ""{givenSender}"",
                  ""destinations"": [
                    {{
                      ""to"": ""{givenTo}""
                    }}
                  ],
                  ""event"": ""{GetEnumAttributeValue(givenEventType)}""
                }}
              ]
            }}";

        var expectedResponse = $@"
            {{
              ""bulkId"": ""{expectedBulkId}"",
              ""messages"": [
                {{
                  ""messageId"": ""{expectedMessageId}"",
                  ""status"": {{
                    ""groupId"": {expectedStatusGroupId},
                    ""groupName"": ""{expectedStatusGroupName}"",
                    ""id"": {expectedStatusId},
                    ""name"": ""{expectedStatusName}"",
                    ""description"": ""{expectedStatusDescription}""
                  }},
                  ""destination"": ""{expectedDestination}""
                }}
              ]
            }}";

        SetUpPostRequest(MESSAGES_EVENTS_ENDPOINT, 200, givenRequest, expectedResponse);

        var messagesApi = new MessagesApi(Configuration);

        var request = new MessagesApiEventRequest(
            new List<MessagesApiOutboundEvent>
            {
                new MessagesApiOutboundTypingStartedEvent(
                    givenChannel,
                    givenSender,
                    new List<MessagesApiToDestination>
                    {
                        new(givenTo)
                    }
                )
            }
        );

        void AssertMessageResponse(MessageResponse messageResponse)
        {
            Assert.IsNotNull(messageResponse);
            Assert.AreEqual(expectedBulkId, messageResponse.BulkId);

            Assert.IsNotNull(messageResponse.Messages);
            Assert.AreEqual(1, messageResponse.Messages.Count);

            var message = messageResponse.Messages[0];
            Assert.AreEqual(expectedMessageId, message.MessageId);
            Assert.AreEqual(expectedDestination, message.Destination);

            var status = message.Status;
            Assert.IsNotNull(status);
            Assert.AreEqual(expectedStatusGroupId, status.GroupId);
            Assert.AreEqual(expectedStatusGroupName, status.GroupName);
            Assert.AreEqual(expectedStatusId, status.Id);
            Assert.AreEqual(expectedStatusName, status.Name);
            Assert.AreEqual(expectedStatusDescription, status.Description);
        }

        AssertResponse(messagesApi.SendMessagesApiEvents(request), AssertMessageResponse);
        AssertResponse(messagesApi.SendMessagesApiEventsAsync(request).Result, AssertMessageResponse);
        AssertResponseWithHttpInfo(messagesApi.SendMessagesApiEventsWithHttpInfo(request), AssertMessageResponse, 200);
        AssertResponseWithHttpInfo(messagesApi.SendMessagesApiEventsWithHttpInfoAsync(request).Result,
            AssertMessageResponse, 200);
    }

    [TestMethod]
    public void ShouldGetMessagesApiDeliveryReports()
    {
        var givenLimit = 1;
        var givenEntityId = "promotional-traffic-entity";
        var givenApplicationId = "marketing-automation-application";
        var givenCampaignReferenceId = "summersale";

        var expectedEvent = "DELIVERY";
        var expectedChannel = MessagesApiInboundDlrChannel.Whatsapp;
        var expectedSender = "44444444444";
        var expectedDestination = "410000000";
        var expectedSentAt = "2024-02-06T14:18:29.797+0000";
        var expectedDoneAt = "2024-02-06T14:18:29.812+0000";
        var expectedBulkId = "1688025180464000013";
        var expectedMessageId = "1688025180464000014";
        var expectedMessageCount = 1;
        var expectedStatusGroupId = 3;
        var expectedStatusGroupName = "DELIVERED";
        var expectedStatusId = 5;
        var expectedStatusName = "DELIVERED_TO_HANDSET";
        var expectedStatusDescription = "Message delivered to handset";
        var expectedErrorGroupId = 0;
        var expectedErrorGroupName = "OK";
        var expectedErrorId = 0;
        var expectedErrorName = "NO_ERROR";
        var expectedErrorDescription = "No Error";
        var expectedErrorPermanent = false;
        var expectedEntityId = givenEntityId;
        var expectedApplicationId = givenApplicationId;
        var expectedCampaignReferenceId = givenCampaignReferenceId;

        var expectedResponse = $@"
            {{
              ""results"": [
                {{
                  ""event"": ""{expectedEvent}"",
                  ""channel"": ""{GetEnumAttributeValue(expectedChannel)}"",
                  ""sender"": ""{expectedSender}"",
                  ""destination"": ""{expectedDestination}"",
                  ""sentAt"": ""{expectedSentAt}"",
                  ""doneAt"": ""{expectedDoneAt}"",
                  ""bulkId"": ""{expectedBulkId}"",
                  ""messageId"": ""{expectedMessageId}"",
                  ""messageCount"": {expectedMessageCount},
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
                    ""permanent"": {GetBooleanValueAsLowerString(expectedErrorPermanent)}
                  }},
                  ""platform"": {{
                    ""entityId"": ""{expectedEntityId}"",
                    ""applicationId"": ""{expectedApplicationId}""
                  }},
                  ""campaignReferenceId"": ""{expectedCampaignReferenceId}""
                }}
              ]
            }}";

        var givenQueryParameters = new Dictionary<string, string>
        {
            { "limit", givenLimit.ToString() },
            { "entityId", givenEntityId },
            { "applicationId", givenApplicationId },
            { "campaignReferenceId", givenCampaignReferenceId }
        };

        SetUpGetRequest(MESSAGES_REPORTS_ENDPOINT, 200, expectedResponse, givenQueryParameters);

        var messagesApi = new MessagesApi(Configuration);

        void AssertDeliveryReportResponse(MessagesApiDeliveryReportResponse deliveryReportResponse)
        {
            Assert.IsNotNull(deliveryReportResponse);
            Assert.IsNotNull(deliveryReportResponse.Results);
            Assert.AreEqual(1, deliveryReportResponse.Results.Count);

            var result = deliveryReportResponse.Results[0];
            Assert.AreEqual(expectedEvent, result.Event);
            Assert.AreEqual(expectedChannel, result.Channel);
            Assert.AreEqual(expectedSender, result.Sender);
            Assert.AreEqual(expectedDestination, result.Destination);
            Assert.AreEqual(expectedSentAt, result.SentAt);
            Assert.AreEqual(expectedDoneAt, result.DoneAt);
            Assert.AreEqual(expectedBulkId, result.BulkId);
            Assert.AreEqual(expectedMessageId, result.MessageId);
            Assert.AreEqual(expectedMessageCount, result.MessageCount);

            var status = result.Status;
            Assert.IsNotNull(status);
            Assert.AreEqual(expectedStatusGroupId, status.GroupId);
            Assert.AreEqual(expectedStatusGroupName, status.GroupName);
            Assert.AreEqual(expectedStatusId, status.Id);
            Assert.AreEqual(expectedStatusName, status.Name);
            Assert.AreEqual(expectedStatusDescription, status.Description);

            var error = result.Error;
            Assert.IsNotNull(error);
            Assert.AreEqual(expectedErrorGroupId, error.GroupId);
            Assert.AreEqual(expectedErrorGroupName, error.GroupName);
            Assert.AreEqual(expectedErrorId, error.Id);
            Assert.AreEqual(expectedErrorName, error.Name);
            Assert.AreEqual(expectedErrorDescription, error.Description);
            Assert.AreEqual(expectedErrorPermanent, error.Permanent);

            var platform = result.Platform;
            Assert.IsNotNull(platform);
            Assert.AreEqual(expectedEntityId, platform.EntityId);
            Assert.AreEqual(expectedApplicationId, platform.ApplicationId);

            Assert.AreEqual(expectedCampaignReferenceId, result.CampaignReferenceId);
        }

        AssertResponse(messagesApi.GetMessagesApiDeliveryReports(limit: givenLimit, entityId: givenEntityId,
                applicationId: givenApplicationId, campaignReferenceId: givenCampaignReferenceId),
            AssertDeliveryReportResponse);
        AssertResponse(messagesApi.GetMessagesApiDeliveryReportsAsync(limit: givenLimit, entityId: givenEntityId,
                applicationId: givenApplicationId, campaignReferenceId: givenCampaignReferenceId).Result,
            AssertDeliveryReportResponse);
        AssertResponseWithHttpInfo(messagesApi.GetMessagesApiDeliveryReportsWithHttpInfo(limit: givenLimit,
            entityId: givenEntityId, applicationId: givenApplicationId,
            campaignReferenceId: givenCampaignReferenceId), AssertDeliveryReportResponse, 200);
        AssertResponseWithHttpInfo(messagesApi.GetMessagesApiDeliveryReportsWithHttpInfoAsync(limit: givenLimit,
            entityId: givenEntityId, applicationId: givenApplicationId,
            campaignReferenceId: givenCampaignReferenceId).Result, AssertDeliveryReportResponse, 200);
    }

    [TestMethod]
    public void ShouldReceiveMessagesApiDeliveryReportsWebhook()
    {
        var givenEvent = "DELIVERY";
        var givenChannel = "WHATSAPP";
        var givenSender = "senderNumber";
        var givenDestination = "41793026727";
        var givenSentAt = "2024-02-06T14:18:29.797+0000";
        var givenDoneAt = "2024-02-06T17:18:29.797+0000";
        var givenBulkId = "1688025180464000013";
        var givenMessageId = "ABEGVUGWh3gEAgo-sLTvmQCS5kwjhsy";
        var givenMessageCount = 1;
        var givenStatusGroupId = 3;
        var givenStatusGroupName = "DELIVERED";
        var givenStatusId = 5;
        var givenStatusName = "DELIVERED_TO_HANDSET";
        var givenStatusDescription = "Message delivered to handset";
        var givenErrorGroupId = 0;
        var givenErrorGroupName = "OK";
        var givenErrorId = 0;
        var givenErrorName = "NO_ERROR";
        var givenErrorDescription = "No Error";
        var givenErrorPermanent = false;
        var givenEntityId = "my-entity-id";
        var givenApplicationId = "my-application-id";
        var givenDeviceDetails = "deviceDetails";
        var givenNetworkId = 1;
        var givenCampaignReferenceId = "campaignRef";

        var givenRequest = $@"
            {{
              ""results"": [
                {{
                  ""event"": ""{givenEvent}"",
                  ""channel"": ""{givenChannel}"",
                  ""sender"": ""{givenSender}"",
                  ""destination"": ""{givenDestination}"",
                  ""sentAt"": ""{givenSentAt}"",
                  ""doneAt"": ""{givenDoneAt}"",
                  ""bulkId"": ""{givenBulkId}"",
                  ""messageId"": ""{givenMessageId}"",
                  ""messageCount"": {givenMessageCount},
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
                  ""platform"": {{
                    ""entityId"": ""{givenEntityId}"",
                    ""applicationId"": ""{givenApplicationId}""
                  }},
                  ""deviceDetails"": ""{givenDeviceDetails}"",
                  ""networkId"": {givenNetworkId},
                  ""campaignReferenceId"": ""{givenCampaignReferenceId}""
                }}
              ]
            }}";

        var deliveryReportResponse = JsonConvert.DeserializeObject<MessagesApiDeliveryReportResponse>(givenRequest);
        AssertMessagesApiDeliveryReportResponse(deliveryReportResponse!);

        var stjDeliveryReportResponse = JsonSerializer.Deserialize<MessagesApiDeliveryReportResponse>(givenRequest);
        AssertMessagesApiDeliveryReportResponse(stjDeliveryReportResponse!);

        void AssertMessagesApiDeliveryReportResponse(MessagesApiDeliveryReportResponse response)
        {
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Results);
            Assert.AreEqual(1, response.Results.Count);

            var result = response.Results[0];
            Assert.AreEqual(givenEvent, result.Event);
            Assert.AreEqual(MessagesApiInboundDlrChannel.Whatsapp, result.Channel);
            Assert.AreEqual(givenSender, result.Sender);
            Assert.AreEqual(givenDestination, result.Destination);
            Assert.AreEqual(givenSentAt, result.SentAt);
            Assert.AreEqual(givenDoneAt, result.DoneAt);
            Assert.AreEqual(givenBulkId, result.BulkId);
            Assert.AreEqual(givenMessageId, result.MessageId);
            Assert.AreEqual(givenMessageCount, result.MessageCount);

            var status = result.Status;
            Assert.IsNotNull(status);
            Assert.AreEqual(givenStatusGroupId, status.GroupId);
            Assert.AreEqual(givenStatusGroupName, status.GroupName);
            Assert.AreEqual(givenStatusId, status.Id);
            Assert.AreEqual(givenStatusName, status.Name);
            Assert.AreEqual(givenStatusDescription, status.Description);

            var error = result.Error;
            Assert.IsNotNull(error);
            Assert.AreEqual(givenErrorGroupId, error.GroupId);
            Assert.AreEqual(givenErrorGroupName, error.GroupName);
            Assert.AreEqual(givenErrorId, error.Id);
            Assert.AreEqual(givenErrorName, error.Name);
            Assert.AreEqual(givenErrorDescription, error.Description);
            Assert.AreEqual(givenErrorPermanent, error.Permanent);

            var platform = result.Platform;
            Assert.IsNotNull(platform);
            Assert.AreEqual(givenEntityId, platform.EntityId);
            Assert.AreEqual(givenApplicationId, platform.ApplicationId);

            Assert.AreEqual(givenDeviceDetails, result.DeviceDetails);
            Assert.AreEqual(givenNetworkId, result.NetworkId);
            Assert.AreEqual(givenCampaignReferenceId, result.CampaignReferenceId);
        }
    }

    [TestMethod]
    public void ShouldReceiveSeenReportsWebhook()
    {
        var givenEvent = "SEEN";
        var givenChannel = MessagesApiInboundSeenChannel.Whatsapp;
        var givenSender = "senderNumber";
        var givenDestination = "41793026727";
        var givenSentAt = "2024-02-06T14:18:29.797+0000";
        var givenSeenAt = "2024-02-06T14:28:29.797+0000";
        var givenBulkId = "1688025180464000013";
        var givenMessageId = "ABEGVUGWh3gEAgo-sLTvmQCS5kwjhsy";
        var givenCallbackData = "reference-callback-data-from-outbound-message";
        var givenEntityId = "my-entity-id";
        var givenApplicationId = "my-application-id";
        var givenCampaignReferenceId = "campaignRef";

        var givenRequest = $@"
            {{
              ""results"": [
                {{
                  ""event"": ""{givenEvent}"",
                  ""channel"": ""{GetEnumAttributeValue(givenChannel)}"",
                  ""sender"": ""{givenSender}"",
                  ""destination"": ""{givenDestination}"",
                  ""sentAt"": ""{givenSentAt}"",
                  ""seenAt"": ""{givenSeenAt}"",
                  ""bulkId"": ""{givenBulkId}"",
                  ""messageId"": ""{givenMessageId}"",
                  ""callbackData"": ""{givenCallbackData}"",
                  ""platform"": {{
                    ""entityId"": ""{givenEntityId}"",
                    ""applicationId"": ""{givenApplicationId}""
                  }},
                  ""campaignReferenceId"": ""{givenCampaignReferenceId}""
                }}
              ]
            }}";

        var seenReport = JsonConvert.DeserializeObject<MessagesApiSeenReport>(givenRequest);
        AssertSeenReport(seenReport!);

        var stjSeenReport = JsonSerializer.Deserialize<MessagesApiSeenReport>(givenRequest);
        AssertSeenReport(stjSeenReport!);

        void AssertSeenReport(MessagesApiSeenReport response)
        {
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Results);
            Assert.AreEqual(1, response.Results.Count);

            var result = response.Results[0];
            Assert.AreEqual(givenEvent, result.Event);
            Assert.AreEqual(givenChannel, result.Channel);
            Assert.AreEqual(givenSender, result.Sender);
            Assert.AreEqual(givenDestination, result.Destination);
            Assert.AreEqual(givenSentAt, result.SentAt);
            Assert.AreEqual(givenSeenAt, result.SeenAt);
            Assert.AreEqual(givenBulkId, result.BulkId);
            Assert.AreEqual(givenMessageId, result.MessageId);
            Assert.AreEqual(givenCallbackData, result.CallbackData);

            var platform = result.Platform;
            Assert.IsNotNull(platform);
            Assert.AreEqual(givenEntityId, platform.EntityId);
            Assert.AreEqual(givenApplicationId, platform.ApplicationId);

            Assert.AreEqual(givenCampaignReferenceId, result.CampaignReferenceId);
        }
    }

    [TestMethod]
    public void ShouldGetInboundMessages()
    {
        var givenChannel = MessagesApiInboundMoGetEndpointChannel.Sms;
        var givenLimit = 2;
        var givenApplicationId = "marketing-automation-application";
        var givenEntityId = "promotional-traffic-entity";
        var givenCampaignReferenceId = "mycampaign";

        var expectedChannel = MessagesApiInboundMoEventChannel.Sms;
        var expectedSender = "48123234567";
        var expectedDestination = "48123098765";
        var expectedText = "Text message 123";
        var expectedCleanText = "Text message";
        var expectedContentType = MessagesApiWebhookEventContentType.Text;
        var expectedReceivedAt = DateTimeOffset.Parse("2020-02-06T14:18:29.797+0000");
        var expectedMessageId = "ABEGVUGWh3gEAgo-sLTvmQCS5kwjhsy";
        var expectedMessageCount = 1;
        var expectedEntityId = "my-entity-id";
        var expectedApplicationId = "my-application-id";
        var expectedEvent = MessagesApiInboundEventType.Mo;
        var expectedTotalMessageCount = 1;
        var expectedPendingMessageCount = 0;

        var expectedResponse = $@"
            {{
              ""results"": [
                {{
                  ""channel"": ""{GetEnumAttributeValue(expectedChannel)}"",
                  ""sender"": ""{expectedSender}"",
                  ""destination"": ""{expectedDestination}"",
                  ""content"": [
                    {{
                      ""text"": ""{expectedText}"",
                      ""cleanText"": ""{expectedCleanText}"",
                      ""type"": ""{GetEnumAttributeValue(expectedContentType)}""
                    }}
                  ],
                  ""receivedAt"": ""{expectedReceivedAt:yyyy-MM-ddTHH:mm:ss.fffzzz}"",
                  ""messageId"": ""{expectedMessageId}"",
                  ""messageCount"": {expectedMessageCount},
                  ""platform"": {{
                    ""entityId"": ""{expectedEntityId}"",
                    ""applicationId"": ""{expectedApplicationId}""
                  }},
                  ""event"": ""{GetEnumAttributeValue(expectedEvent)}""
                }}
              ],
              ""messageCount"": {expectedTotalMessageCount},
              ""pendingMessageCount"": {expectedPendingMessageCount}
            }}";

        var givenQueryParameters = new Dictionary<string, string>
        {
            { "channel", GetEnumAttributeValue(givenChannel) },
            { "limit", givenLimit.ToString() },
            { "applicationId", givenApplicationId },
            { "entityId", givenEntityId },
            { "campaignReferenceId", givenCampaignReferenceId }
        };

        SetUpGetRequest(MESSAGES_INBOUND_ENDPOINT, 200, expectedResponse, givenQueryParameters);

        var messagesApi = new MessagesApi(Configuration);

        void AssertInboundMessageResponse(MessagesApiIncomingMessageResponse response)
        {
            Assert.IsNotNull(response);
            Assert.AreEqual(expectedTotalMessageCount, response.MessageCount);
            Assert.AreEqual(expectedPendingMessageCount, response.PendingMessageCount);
            Assert.IsNotNull(response.Results);
            Assert.AreEqual(1, response.Results.Count);

            var result = (MessagesApiWebhookEvent)response.Results[0];
            Assert.AreEqual(expectedChannel, result.Channel);
            Assert.AreEqual(expectedSender, result.Sender);
            Assert.AreEqual(expectedDestination, result.Destination);
            Assert.AreEqual(expectedReceivedAt, result.ReceivedAt);
            Assert.AreEqual(expectedMessageId, result.MessageId);
            Assert.AreEqual(expectedMessageCount, result.MessageCount);
            Assert.AreEqual(expectedEvent, result.Event);

            var platform = result.Platform;
            Assert.IsNotNull(platform);
            Assert.AreEqual(expectedEntityId, platform.EntityId);
            Assert.AreEqual(expectedApplicationId, platform.ApplicationId);

            Assert.IsNotNull(result.Content);
            Assert.AreEqual(1, result.Content.Count);
            var content = (MessagesApiWebhookEventTextContent)result.Content[0];
            Assert.AreEqual(expectedText, content.Text);
            Assert.AreEqual(expectedCleanText, content.CleanText);
            Assert.AreEqual(expectedContentType, content.Type);
        }

        AssertResponse(messagesApi.GetMessagesApiInboundMessages(givenChannel, givenLimit,
            givenApplicationId, givenEntityId,
            givenCampaignReferenceId), AssertInboundMessageResponse);
        AssertResponse(messagesApi.GetMessagesApiInboundMessagesAsync(givenChannel, givenLimit,
            givenApplicationId, givenEntityId,
            givenCampaignReferenceId).Result, AssertInboundMessageResponse);
        AssertResponseWithHttpInfo(messagesApi.GetMessagesApiInboundMessagesWithHttpInfo(givenChannel,
            givenLimit, givenApplicationId, givenEntityId,
            givenCampaignReferenceId), AssertInboundMessageResponse, 200);
        AssertResponseWithHttpInfo(messagesApi.GetMessagesApiInboundMessagesWithHttpInfoAsync(givenChannel,
            givenLimit, givenApplicationId, givenEntityId,
            givenCampaignReferenceId).Result, AssertInboundMessageResponse, 200);
    }

    [TestMethod]
    public void ShouldReceiveInboundMessagesWebhook()
    {
        var givenChannel = MessagesApiInboundMoEventChannel.Sms;
        var givenSender = "48123234567";
        var givenDestination = "48123098765";
        var givenText = "Text message 123";
        var givenCleanText = "Text message";
        var givenContentType = MessagesApiWebhookEventContentType.Text;
        var givenReceivedAt = DateTimeOffset.Parse("2020-02-06T14:18:29.797+0000");
        var givenMessageId = "ABEGVUGWh3gEAgo-sLTvmQCS5kwjhsy";
        var givenMessageCount = 1;
        var givenEntityId = "my-entity-id";
        var givenApplicationId = "my-application-id";
        var givenEvent = MessagesApiInboundEventType.Mo;

        var givenRequest = $@"
            {{
              ""results"": [
                {{
                  ""channel"": ""{GetEnumAttributeValue(givenChannel)}"",
                  ""sender"": ""{givenSender}"",
                  ""destination"": ""{givenDestination}"",
                  ""content"": [
                    {{
                      ""text"": ""{givenText}"",
                      ""cleanText"": ""{givenCleanText}"",
                      ""type"": ""{GetEnumAttributeValue(givenContentType)}""
                    }}
                  ],
                  ""receivedAt"": ""{givenReceivedAt:yyyy-MM-ddTHH:mm:ss.fffzzz}"",
                  ""messageId"": ""{givenMessageId}"",
                  ""messageCount"": {givenMessageCount},
                  ""platform"": {{
                    ""entityId"": ""{givenEntityId}"",
                    ""applicationId"": ""{givenApplicationId}""
                  }},
                  ""event"": ""{GetEnumAttributeValue(givenEvent)}""
                }}
              ]
            }}";

        var inboundMessages = JsonConvert.DeserializeObject<MessagesApiIncomingMessageResponse>(givenRequest);
        AssertInboundMessages(inboundMessages!);

        var stjInboundMessages = JsonSerializer.Deserialize<MessagesApiIncomingMessageResponse>(givenRequest);
        AssertInboundMessages(stjInboundMessages!);

        void AssertInboundMessages(MessagesApiIncomingMessageResponse response)
        {
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Results);
            Assert.AreEqual(1, response.Results.Count);

            var result = (MessagesApiWebhookEvent)response.Results[0];
            Assert.AreEqual(givenChannel, result.Channel);
            Assert.AreEqual(givenSender, result.Sender);
            Assert.AreEqual(givenDestination, result.Destination);
            Assert.AreEqual(givenReceivedAt, result.ReceivedAt);
            Assert.AreEqual(givenMessageId, result.MessageId);
            Assert.AreEqual(givenMessageCount, result.MessageCount);
            Assert.AreEqual(givenEvent, result.Event);

            var platform = result.Platform;
            Assert.IsNotNull(platform);
            Assert.AreEqual(givenEntityId, platform.EntityId);
            Assert.AreEqual(givenApplicationId, platform.ApplicationId);

            Assert.IsNotNull(result.Content);
            Assert.AreEqual(1, result.Content.Count);
            var content = (MessagesApiWebhookEventTextContent)result.Content[0];
            Assert.AreEqual(givenText, content.Text);
            Assert.AreEqual(givenCleanText, content.CleanText);
            Assert.AreEqual(givenContentType, content.Type);
        }
    }
}