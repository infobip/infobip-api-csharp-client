using System.Globalization;
using Infobip.Api.Client.Api;
using Infobip.Api.Client.Model;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace ApiClient.Tests.Api;

[TestClass]
public class RcsApiTest : ApiTest
{
    protected const string RCS_MESSAGES_ENDPOINT = "/rcs/2/messages";
    protected const string RCS_EVENTS_ENDPOINT = "/rcs/1/events";
    protected const string RCS_REPORTS_ENDPOINT = "/rcs/2/reports";
    protected const string RCS_LOGS_ENDPOINT = "/rcs/2/logs";
    protected const string RCS_CAPABILITY_CHECK_QUERY_ENDPOINT = "/rcs/2/capability-check/query";
    protected const string RCS_CAPABILITY_CHECK_NOTIFY_ENDPOINT = "/rcs/2/capability-check/notify";

    [TestMethod]
    public void ShouldSendRcsTextMessage()
    {
        var givenBulkId = "a28dd97c-2222-4fcf-99f1-0b557ed381da";
        var givenSender = "DemoSender";
        var givenTo = "441134960001";
        var givenMessageId = "a28dd97c-1ffb-4fcf-99f1-0b557ed381da";
        var givenStatusGroupId = 1;
        var givenStatusGroupName = "PENDING";
        var givenStatusId = 26;
        var givenStatusName = "PENDING_ACCEPTED";
        var givenStatusDescription = "Message sent to next instance";
        var givenText = "Some text";

        var givenRequest = $@"
            {{
              ""messages"": [
                {{
                  ""sender"": ""{givenSender}"",
                  ""destinations"": [
                    {{
                      ""to"": ""{givenTo}""
                    }}
                  ],
                  ""content"": {{
                    ""text"": ""{givenText}"",
                    ""type"": ""TEXT""
                  }}
                }}
              ]
            }}";

        var givenResponse = $@"
            {{
              ""bulkId"": ""{givenBulkId}"",
              ""messages"": [
                {{
                  ""messageId"": ""{givenMessageId}"",
                  ""status"": {{
                    ""groupId"": {givenStatusGroupId},
                    ""groupName"": ""{givenStatusGroupName}"",
                    ""id"": {givenStatusId},
                    ""name"": ""{givenStatusName}"",
                    ""description"": ""{givenStatusDescription}""
                  }},
                  ""destination"": ""{givenTo}""
                }}
              ]
            }}";

        SetUpPostRequest(RCS_MESSAGES_ENDPOINT, 200, givenRequest, givenResponse);

        var api = new RcsApi(Configuration);

        var request = new RcsMessageRequest(
            new List<RcsMessage>
            {
                new(
                    givenSender,
                    new List<RcsToDestination>
                    {
                        new(givenTo)
                    },
                    new RcsOutboundTextContent(givenText)
                )
            }
        );

        void AssertResponse(MessageResponse response)
        {
            Assert.IsNotNull(response);
            Assert.AreEqual(givenBulkId, response.BulkId);
            Assert.IsNotNull(response.Messages);
            Assert.AreEqual(1, response.Messages.Count);
            var message = response.Messages[0];
            Assert.AreEqual(givenMessageId, message.MessageId);
            Assert.AreEqual(givenTo, message.Destination);
            Assert.IsNotNull(message.Status);
            Assert.AreEqual(givenStatusGroupId, message.Status.GroupId);
            Assert.AreEqual(givenStatusGroupName, message.Status.GroupName);
            Assert.AreEqual(givenStatusId, message.Status.Id);
            Assert.AreEqual(givenStatusName, message.Status.Name);
            Assert.AreEqual(givenStatusDescription, message.Status.Description);
        }

        AssertResponse(api.SendRcsMessages(request));
        AssertResponse(api.SendRcsMessagesAsync(request).Result);
        AssertResponseWithHttpInfo(api.SendRcsMessagesWithHttpInfo(request), AssertResponse, 200);
        AssertResponseWithHttpInfo(api.SendRcsMessagesWithHttpInfoAsync(request).Result, AssertResponse, 200);
    }

    [TestMethod]
    public void ShouldSendRcsCardMessageWithUrlTracking()
    {
        var givenBulkId = "a28dd97c-2222-4fcf-99f1-0b557ed381da";
        var givenSender = "DemoSender";
        var givenTo = "441134960001";
        var givenMessageId = "a28dd97c-1ffb-4fcf-99f1-0b557ed381da";
        var givenStatusGroupId = 1;
        var givenStatusGroupName = "PENDING";
        var givenStatusId = 26;
        var givenStatusName = "PENDING_ACCEPTED";
        var givenStatusDescription = "Message sent to next instance";
        var givenOrientation = RcsOrientation.Horizontal;
        var givenAlignment = RcsAlignment.Left;
        var givenTitle = "Some title";
        var givenDescription = "Some description";
        var givenFileUrl = "https://www.example.com/video.mp4";
        var givenThumbnailUrl = "https://www.example.com/thumbnail.jpg";
        var givenHeight = RcsHeight.Tall;
        var givenOpenUrlText = "Example text";
        var givenOpenUrlPostbackData = "Example postback data";
        var givenOpenUrlUrl = "https://www.example.com/";
        var givenOpenUrlApplication = RcsOpenUrlApplicationType.Browser;
        var givenReplyText = "Example text";
        var givenReplyPostbackData = "Example postback data";
        var givenCardSuggestionText = "Example text";
        var givenCardSuggestionPostbackData = "Example postback data";
        var givenShortenUrl = true;
        var givenTrackClicks = true;
        var givenTrackingUrl = "https://www.example.com/tracking-callback-server";
        var givenRemoveProtocol = false;

        var givenRequest = $@"
            {{
              ""messages"": [
                {{
                  ""sender"": ""{givenSender}"",
                  ""destinations"": [
                    {{
                      ""to"": ""{givenTo}""
                    }}
                  ],
                  ""content"": {{
                    ""orientation"": ""{GetEnumAttributeValue(givenOrientation)}"",
                    ""alignment"": ""{GetEnumAttributeValue(givenAlignment)}"",
                    ""content"": {{
                      ""title"": ""{givenTitle}"",
                      ""description"": ""{givenDescription}"",
                      ""media"": {{
                        ""file"": {{
                          ""url"": ""{givenFileUrl}""
                        }},
                        ""thumbnail"": {{
                          ""url"": ""{givenThumbnailUrl}""
                        }},
                        ""height"": ""{GetEnumAttributeValue(givenHeight)}""
                      }},
                      ""suggestions"": [
                        {{
                          ""text"": ""{givenOpenUrlText}"",
                          ""postbackData"": ""{givenOpenUrlPostbackData}"",
                          ""url"": ""{givenOpenUrlUrl}"",
                          ""application"": ""{GetEnumAttributeValue(givenOpenUrlApplication)}"",
                          ""type"": ""OPEN_URL""
                        }},
                        {{
                          ""text"": ""{givenReplyText}"",
                          ""postbackData"": ""{givenReplyPostbackData}"",
                          ""type"": ""REPLY""
                        }}
                      ]
                    }},
                    ""suggestions"": [
                      {{
                        ""text"": ""{givenCardSuggestionText}"",
                        ""postbackData"": ""{givenCardSuggestionPostbackData}"",
                        ""type"": ""REPLY""
                      }}
                    ],
                    ""type"": ""CARD""
                  }}
                }}
              ],
              ""options"": {{
                ""tracking"": {{
                  ""shortenUrl"": {GetBooleanValueAsLowerString(givenShortenUrl)},
                  ""trackClicks"": {GetBooleanValueAsLowerString(givenTrackClicks)},
                  ""trackingUrl"": ""{givenTrackingUrl}"",
                  ""removeProtocol"": {GetBooleanValueAsLowerString(givenRemoveProtocol)}
                }}
              }}
            }}";

        var givenResponse = $@"
            {{
              ""bulkId"": ""{givenBulkId}"",
              ""messages"": [
                {{
                  ""messageId"": ""{givenMessageId}"",
                  ""status"": {{
                    ""groupId"": {givenStatusGroupId},
                    ""groupName"": ""{givenStatusGroupName}"",
                    ""id"": {givenStatusId},
                    ""name"": ""{givenStatusName}"",
                    ""description"": ""{givenStatusDescription}""
                  }},
                  ""destination"": ""{givenTo}""
                }}
              ]
            }}";

        SetUpPostRequest(RCS_MESSAGES_ENDPOINT, 200, givenRequest, givenResponse);

        var api = new RcsApi(Configuration);

        var request = new RcsMessageRequest(
            new List<RcsMessage>
            {
                new(
                    givenSender,
                    new List<RcsToDestination>
                    {
                        new(givenTo)
                    },
                    new RcsOutboundCardContent(
                        givenOrientation,
                        givenAlignment,
                        new RcsCardContent(
                            givenTitle,
                            givenDescription,
                            new RcsCardMedia(
                                new RcsCardResourceSchema(givenFileUrl),
                                new RcsResource(givenThumbnailUrl),
                                givenHeight
                            ),
                            new List<RcsSuggestion>
                            {
                                new RcsOpenUrlSuggestion(
                                    givenOpenUrlText,
                                    givenOpenUrlPostbackData,
                                    givenOpenUrlUrl,
                                    givenOpenUrlApplication
                                ),
                                new RcsReplySuggestion(
                                    givenReplyText,
                                    givenReplyPostbackData
                                )
                            }
                        ),
                        new List<RcsSuggestion>
                        {
                            new RcsReplySuggestion(
                                givenCardSuggestionText,
                                givenCardSuggestionPostbackData
                            )
                        }
                    )
                )
            },
            new RcsMessageRequestOptions(
                tracking: new UrlOptions(
                    givenShortenUrl,
                    givenTrackClicks,
                    givenTrackingUrl,
                    givenRemoveProtocol
                )
            )
        );

        void AssertResponse(MessageResponse response)
        {
            Assert.IsNotNull(response);
            Assert.AreEqual(givenBulkId, response.BulkId);
            Assert.IsNotNull(response.Messages);
            Assert.AreEqual(1, response.Messages.Count);
            var message = response.Messages[0];
            Assert.AreEqual(givenMessageId, message.MessageId);
            Assert.AreEqual(givenTo, message.Destination);
            Assert.IsNotNull(message.Status);
            Assert.AreEqual(givenStatusGroupId, message.Status.GroupId);
            Assert.AreEqual(givenStatusGroupName, message.Status.GroupName);
            Assert.AreEqual(givenStatusId, message.Status.Id);
            Assert.AreEqual(givenStatusName, message.Status.Name);
            Assert.AreEqual(givenStatusDescription, message.Status.Description);
        }

        AssertResponse(api.SendRcsMessages(request));
        AssertResponse(api.SendRcsMessagesAsync(request).Result);
        AssertResponseWithHttpInfo(api.SendRcsMessagesWithHttpInfo(request), AssertResponse, 200);
        AssertResponseWithHttpInfo(api.SendRcsMessagesWithHttpInfoAsync(request).Result, AssertResponse, 200);
    }

    [TestMethod]
    public void ShouldSendRcsTypingIndicatorEvent()
    {
        var givenBulkId = "a28dd97c-2222-4fcf-99f1-0b557ed381da";
        var givenSender = "DemoSender";
        var givenTo = "441134960001";
        var givenMessageId = "a28dd97c-1ffb-4fcf-99f1-0b557ed381da";
        var givenStatusGroupId = 1;
        var givenStatusGroupName = "PENDING";
        var givenStatusId = 26;
        var givenStatusName = "PENDING_ACCEPTED";
        var givenStatusDescription = "Message sent to next instance";

        var givenRequest = $@"
            {{
              ""events"": [
                {{
                  ""sender"": ""{givenSender}"",
                  ""destinations"": [
                    {{
                      ""to"": ""{givenTo}""
                    }}
                  ],
                  ""content"": {{
                    ""type"": ""TYPING_INDICATOR""
                  }}
                }}
              ]
            }}";

        var givenResponse = $@"
            {{
              ""bulkId"": ""{givenBulkId}"",
              ""messages"": [
                {{
                  ""messageId"": ""{givenMessageId}"",
                  ""status"": {{
                    ""groupId"": {givenStatusGroupId},
                    ""groupName"": ""{givenStatusGroupName}"",
                    ""id"": {givenStatusId},
                    ""name"": ""{givenStatusName}"",
                    ""description"": ""{givenStatusDescription}""
                  }},
                  ""destination"": ""{givenTo}""
                }}
              ]
            }}";

        SetUpPostRequest(RCS_EVENTS_ENDPOINT, 200, givenRequest, givenResponse);

        var api = new RcsApi(Configuration);

        var request = new RcsEventRequest(
            new List<RcsEvent>
            {
                new(
                    givenSender,
                    new List<RcsToDestination>
                    {
                        new(givenTo)
                    },
                    new RcsOutboundEventTypingIndicatorContent()
                )
            }
        );

        void AssertResponse(MessageResponse response)
        {
            Assert.IsNotNull(response);
            Assert.AreEqual(givenBulkId, response.BulkId);
            Assert.IsNotNull(response.Messages);
            Assert.AreEqual(1, response.Messages.Count);
            var message = response.Messages[0];
            Assert.AreEqual(givenMessageId, message.MessageId);
            Assert.AreEqual(givenTo, message.Destination);
            Assert.IsNotNull(message.Status);
            Assert.AreEqual(givenStatusGroupId, message.Status.GroupId);
            Assert.AreEqual(givenStatusGroupName, message.Status.GroupName);
            Assert.AreEqual(givenStatusId, message.Status.Id);
            Assert.AreEqual(givenStatusName, message.Status.Name);
            Assert.AreEqual(givenStatusDescription, message.Status.Description);
        }

        AssertResponse(api.SendRcsEvents(request));
        AssertResponse(api.SendRcsEventsAsync(request).Result);
        AssertResponseWithHttpInfo(api.SendRcsEventsWithHttpInfo(request), AssertResponse, 200);
        AssertResponseWithHttpInfo(api.SendRcsEventsWithHttpInfoAsync(request).Result, AssertResponse, 200);
    }

    [TestMethod]
    public void ShouldSendRcsSeenEvent()
    {
        var givenBulkId = "a28dd97c-2222-4fcf-99f1-0b557ed381da";
        var givenSender = "DemoSender";
        var givenTo = "441134960001";
        var givenMessageId = "a28dd97c-1ffb-4fcf-99f1-0b557ed381da";
        var givenStatusGroupId = 1;
        var givenStatusGroupName = "PENDING";
        var givenStatusId = 26;
        var givenStatusName = "PENDING_ACCEPTED";
        var givenStatusDescription = "Message sent to next instance";
        var givenSeenMessageId = "a28dd97c-1ffb-4fcf-99f1-0b557ed381da";

        var givenRequest = $@"
            {{
              ""events"": [
                {{
                  ""sender"": ""{givenSender}"",
                  ""destinations"": [
                    {{
                      ""to"": ""{givenTo}""
                    }}
                  ],
                  ""content"": {{
                    ""messageId"": ""{givenSeenMessageId}"",
                    ""type"": ""SEEN""
                  }}
                }}
              ]
            }}";

        var givenResponse = $@"
            {{
              ""bulkId"": ""{givenBulkId}"",
              ""messages"": [
                {{
                  ""messageId"": ""{givenMessageId}"",
                  ""status"": {{
                    ""groupId"": {givenStatusGroupId},
                    ""groupName"": ""{givenStatusGroupName}"",
                    ""id"": {givenStatusId},
                    ""name"": ""{givenStatusName}"",
                    ""description"": ""{givenStatusDescription}""
                  }},
                  ""destination"": ""{givenTo}""
                }}
              ]
            }}";

        SetUpPostRequest(RCS_EVENTS_ENDPOINT, 200, givenRequest, givenResponse);

        var api = new RcsApi(Configuration);

        var request = new RcsEventRequest(
            new List<RcsEvent>
            {
                new(
                    givenSender,
                    new List<RcsToDestination>
                    {
                        new(givenTo)
                    },
                    new RcsOutboundEventSeenContent(givenSeenMessageId)
                )
            }
        );

        void AssertResponse(MessageResponse response)
        {
            Assert.IsNotNull(response);
            Assert.AreEqual(givenBulkId, response.BulkId);
            Assert.IsNotNull(response.Messages);
            Assert.AreEqual(1, response.Messages.Count);
            var message = response.Messages[0];
            Assert.AreEqual(givenMessageId, message.MessageId);
            Assert.AreEqual(givenTo, message.Destination);
            Assert.IsNotNull(message.Status);
            Assert.AreEqual(givenStatusGroupId, message.Status.GroupId);
            Assert.AreEqual(givenStatusGroupName, message.Status.GroupName);
            Assert.AreEqual(givenStatusId, message.Status.Id);
            Assert.AreEqual(givenStatusName, message.Status.Name);
            Assert.AreEqual(givenStatusDescription, message.Status.Description);
        }

        AssertResponse(api.SendRcsEvents(request));
        AssertResponse(api.SendRcsEventsAsync(request).Result);
        AssertResponseWithHttpInfo(api.SendRcsEventsWithHttpInfo(request), AssertResponse, 200);
        AssertResponseWithHttpInfo(api.SendRcsEventsWithHttpInfoAsync(request).Result, AssertResponse, 200);
    }

    [TestMethod]
    public void ShouldSendRcsEventWithDeliveryTimeWindow()
    {
        var givenBulkId = "a28dd97c-2222-4fcf-99f1-0b557ed381da";
        var givenSender = "DemoSender";
        var givenTo = "441134960001";
        var givenMessageId = "a28dd97c-1ffb-4fcf-99f1-0b557ed381da";
        var givenStatusGroupId = 1;
        var givenStatusGroupName = "PENDING";
        var givenStatusId = 26;
        var givenStatusName = "PENDING_ACCEPTED";
        var givenStatusDescription = "Message sent to next instance";
        var givenEntityId = "Example entity id";
        var givenApplicationId = "Example application ID";
        var givenFromHour = 9;
        var givenFromMinute = 0;
        var givenToHour = 17;
        var givenToMinute = 0;
        var givenDay1 = DeliveryDay.Monday;
        var givenDay2 = DeliveryDay.Tuesday;

        var givenRequest = $@"
            {{
              ""events"": [
                {{
                  ""sender"": ""{givenSender}"",
                  ""destinations"": [
                    {{
                      ""to"": ""{givenTo}""
                    }}
                  ],
                  ""content"": {{
                    ""type"": ""TYPING_INDICATOR""
                  }},
                  ""options"": {{
                    ""platform"": {{
                      ""entityId"": ""{givenEntityId}"",
                      ""applicationId"": ""{givenApplicationId}""
                    }},
                    ""deliveryTimeWindow"": {{
                      ""days"": [""{GetEnumAttributeValue(givenDay1)}"", ""{GetEnumAttributeValue(givenDay2)}""],
                      ""from"": {{
                        ""hour"": {givenFromHour},
                        ""minute"": {givenFromMinute}
                      }},
                      ""to"": {{
                        ""hour"": {givenToHour},
                        ""minute"": {givenToMinute}
                      }}
                    }}
                  }}
                }}
              ]
            }}";

        var givenResponse = $@"
            {{
              ""bulkId"": ""{givenBulkId}"",
              ""messages"": [
                {{
                  ""messageId"": ""{givenMessageId}"",
                  ""status"": {{
                    ""groupId"": {givenStatusGroupId},
                    ""groupName"": ""{givenStatusGroupName}"",
                    ""id"": {givenStatusId},
                    ""name"": ""{givenStatusName}"",
                    ""description"": ""{givenStatusDescription}""
                  }},
                  ""destination"": ""{givenTo}""
                }}
              ]
            }}";

        SetUpPostRequest(RCS_EVENTS_ENDPOINT, 200, givenRequest, givenResponse);

        var api = new RcsApi(Configuration);

        var request = new RcsEventRequest(
            new List<RcsEvent>
            {
                new(
                    givenSender,
                    new List<RcsToDestination>
                    {
                        new(givenTo)
                    },
                    new RcsOutboundEventTypingIndicatorContent(),
                    new RcsEventOptions(
                        new Platform(
                            givenEntityId,
                            givenApplicationId
                        ),
                        new DeliveryTimeWindow(
                            new List<DeliveryDay> { givenDay1, givenDay2 },
                            new DeliveryTime(givenFromHour, givenFromMinute),
                            new DeliveryTime(givenToHour, givenToMinute)
                        )
                    )
                )
            }
        );

        void AssertResponse(MessageResponse response)
        {
            Assert.IsNotNull(response);
            Assert.AreEqual(givenBulkId, response.BulkId);
            Assert.IsNotNull(response.Messages);
            Assert.AreEqual(1, response.Messages.Count);
            var message = response.Messages[0];
            Assert.AreEqual(givenMessageId, message.MessageId);
            Assert.AreEqual(givenTo, message.Destination);
            Assert.IsNotNull(message.Status);
            Assert.AreEqual(givenStatusGroupId, message.Status.GroupId);
            Assert.AreEqual(givenStatusGroupName, message.Status.GroupName);
            Assert.AreEqual(givenStatusId, message.Status.Id);
            Assert.AreEqual(givenStatusName, message.Status.Name);
            Assert.AreEqual(givenStatusDescription, message.Status.Description);
        }

        AssertResponse(api.SendRcsEvents(request));
        AssertResponse(api.SendRcsEventsAsync(request).Result);
        AssertResponseWithHttpInfo(api.SendRcsEventsWithHttpInfo(request), AssertResponse, 200);
        AssertResponseWithHttpInfo(api.SendRcsEventsWithHttpInfoAsync(request).Result, AssertResponse, 200);
    }

    [TestMethod]
    public void ShouldSendRcsMultipleEvents()
    {
        var givenBulkId = "a28dd97c-2222-4fcf-99f1-0b557ed381da";
        var givenSender = "DemoSender";
        var givenTo = "441134960001";
        var givenMessageId = "a28dd97c-1ffb-4fcf-99f1-0b557ed381da";
        var givenStatusGroupId = 1;
        var givenStatusGroupName = "PENDING";
        var givenStatusId = 26;
        var givenStatusName = "PENDING_ACCEPTED";
        var givenStatusDescription = "Message sent to next instance";
        var givenSeenMessageId = "a28dd97c-1ffb-4fcf-99f1-0b557ed381da";

        var givenRequest = $@"
            {{
              ""events"": [
                {{
                  ""sender"": ""{givenSender}"",
                  ""destinations"": [
                    {{
                      ""to"": ""{givenTo}""
                    }}
                  ],
                  ""content"": {{
                    ""type"": ""TYPING_INDICATOR""
                  }}
                }},
                {{
                  ""sender"": ""{givenSender}"",
                  ""destinations"": [
                    {{
                      ""to"": ""{givenTo}""
                    }}
                  ],
                  ""content"": {{
                    ""messageId"": ""{givenSeenMessageId}"",
                    ""type"": ""SEEN""
                  }}
                }}
              ]
            }}";

        var givenResponse = $@"
            {{
              ""bulkId"": ""{givenBulkId}"",
              ""messages"": [
                {{
                  ""messageId"": ""{givenMessageId}"",
                  ""status"": {{
                    ""groupId"": {givenStatusGroupId},
                    ""groupName"": ""{givenStatusGroupName}"",
                    ""id"": {givenStatusId},
                    ""name"": ""{givenStatusName}"",
                    ""description"": ""{givenStatusDescription}""
                  }},
                  ""destination"": ""{givenTo}""
                }}
              ]
            }}";

        SetUpPostRequest(RCS_EVENTS_ENDPOINT, 200, givenRequest, givenResponse);

        var api = new RcsApi(Configuration);

        var request = new RcsEventRequest(
            new List<RcsEvent>
            {
                new(
                    givenSender,
                    new List<RcsToDestination>
                    {
                        new(givenTo)
                    },
                    new RcsOutboundEventTypingIndicatorContent()
                ),
                new(
                    givenSender,
                    new List<RcsToDestination>
                    {
                        new(givenTo)
                    },
                    new RcsOutboundEventSeenContent(givenSeenMessageId)
                )
            }
        );

        void AssertResponse(MessageResponse response)
        {
            Assert.IsNotNull(response);
            Assert.AreEqual(givenBulkId, response.BulkId);
            Assert.IsNotNull(response.Messages);
            Assert.AreEqual(1, response.Messages.Count);
            var message = response.Messages[0];
            Assert.AreEqual(givenMessageId, message.MessageId);
            Assert.AreEqual(givenTo, message.Destination);
            Assert.IsNotNull(message.Status);
            Assert.AreEqual(givenStatusGroupId, message.Status.GroupId);
            Assert.AreEqual(givenStatusGroupName, message.Status.GroupName);
            Assert.AreEqual(givenStatusId, message.Status.Id);
            Assert.AreEqual(givenStatusName, message.Status.Name);
            Assert.AreEqual(givenStatusDescription, message.Status.Description);
        }

        AssertResponse(api.SendRcsEvents(request));
        AssertResponse(api.SendRcsEventsAsync(request).Result);
        AssertResponseWithHttpInfo(api.SendRcsEventsWithHttpInfo(request), AssertResponse, 200);
        AssertResponseWithHttpInfo(api.SendRcsEventsWithHttpInfoAsync(request).Result, AssertResponse, 200);
    }

    [TestMethod]
    public void ShouldParseRcsInboundTextMessage()
    {
        var givenCampaignReferenceId = "CAMP-2026-Q1";
        var givenSender = "+385911234567";
        var givenTo = "+385911111111";
        var givenIntegrationType = "RCS";
        var givenReceivedAt = DateTimeOffset.Parse("2026-03-03T14:22:30.000+0000");
        var givenInteractionType = RcsMessageInteractionType.BasicMessage;
        var givenRcsCount = 1;
        var givenKeyword = "START";
        var givenMessageId = "msg-abc123";
        var givenPairedMessageId = "msg-xyz456";
        var givenCallbackData = "custom-user-data";
        var givenText = "Hello, world!";
        var givenTrafficType = RcsMoTrafficType.Basic;
        var givenPricePerMessage = 0.005m;
        var givenCurrency = "EUR";
        var givenCanInitiate = true;
        var givenApplicationId = "ext-app-001";
        var givenEntityId = "ext-entity-001";
        var givenMessageCount = 1;
        var givenPendingMessageCount = 0;

        var givenRequest = $@"
            {{
              ""results"": [
                {{
                  ""campaignReferenceId"": ""{givenCampaignReferenceId}"",
                  ""sender"": ""{givenSender}"",
                  ""to"": ""{givenTo}"",
                  ""integrationType"": ""{givenIntegrationType}"",
                  ""receivedAt"": ""{givenReceivedAt:yyyy-MM-ddTHH:mm:ss.fffzzz}"",
                  ""interactionType"": ""{GetEnumAttributeValue(givenInteractionType)}"",
                  ""rcsCount"": {givenRcsCount},
                  ""keyword"": ""{givenKeyword}"",
                  ""messageId"": ""{givenMessageId}"",
                  ""pairedMessageId"": ""{givenPairedMessageId}"",
                  ""callbackData"": ""{givenCallbackData}"",
                  ""message"": {{
                    ""text"": ""{givenText}"",
                    ""type"": ""TEXT""
                  }},
                  ""price"": {{
                    ""trafficType"": ""{GetEnumAttributeValue(givenTrafficType)}"",
                    ""pricePerMessage"": {givenPricePerMessage.ToString(CultureInfo.InvariantCulture)},
                    ""currency"": ""{givenCurrency}""
                  }},
                  ""conversation"": {{
                    ""canInitiate"": {GetBooleanValueAsLowerString(givenCanInitiate)},
                    ""id"": null
                  }},
                  ""platform"": {{
                    ""applicationId"": ""{givenApplicationId}"",
                    ""entityId"": ""{givenEntityId}""
                  }}
                }}
              ],
              ""messageCount"": {givenMessageCount},
              ""pendingMessageCount"": {givenPendingMessageCount}
            }}";

        var inboundMessages = JsonConvert.DeserializeObject<RcsInboundMessages>(givenRequest)!;
        var stjInboundMessages = JsonSerializer.Deserialize<RcsInboundMessages>(givenRequest)!;

        void AssertResult(RcsInboundMessages result)
        {
            Assert.IsNotNull(result);
            Assert.AreEqual(givenMessageCount, result.MessageCount);
            Assert.AreEqual(givenPendingMessageCount, result.PendingMessageCount);
            Assert.IsNotNull(result.Results);
            Assert.AreEqual(1, result.Results.Count);
            var message = result.Results[0];
            Assert.AreEqual(givenCampaignReferenceId, message.CampaignReferenceId);
            Assert.AreEqual(givenSender, message.Sender);
            Assert.AreEqual(givenTo, message.To);
            Assert.AreEqual(givenIntegrationType, message.IntegrationType);
            Assert.AreEqual(givenReceivedAt, message.ReceivedAt);
            Assert.AreEqual(givenInteractionType, message.InteractionType);
            Assert.AreEqual(givenRcsCount, message.RcsCount);
            Assert.AreEqual(givenKeyword, message.Keyword);
            Assert.AreEqual(givenMessageId, message.MessageId);
            Assert.AreEqual(givenPairedMessageId, message.PairedMessageId);
            Assert.AreEqual(givenCallbackData, message.CallbackData);
            Assert.IsNotNull(message.Message);
            Assert.IsInstanceOfType(message.Message, typeof(RcsInboundTextContent));
            var content = (RcsInboundTextContent)message.Message;
            Assert.AreEqual(givenText, content.Text);
            Assert.IsNotNull(message.Price);
            Assert.AreEqual(givenTrafficType, message.Price.TrafficType);
            Assert.AreEqual(givenPricePerMessage, message.Price.PricePerMessage);
            Assert.AreEqual(givenCurrency, message.Price.Currency);
            Assert.IsNotNull(message.Conversation);
            Assert.AreEqual(givenCanInitiate, message.Conversation.CanInitiate);
            Assert.IsNotNull(message.Platform);
            Assert.AreEqual(givenApplicationId, message.Platform.ApplicationId);
            Assert.AreEqual(givenEntityId, message.Platform.EntityId);
        }

        AssertResult(inboundMessages);
        AssertResult(stjInboundMessages);
    }

    [TestMethod]
    public void ShouldParseRcsInboundFileMessage()
    {
        var givenCampaignReferenceId = "CAMP-2026-Q1";
        var givenSender = "+385911234567";
        var givenTo = "+385911111111";
        var givenIntegrationType = "RCS";
        var givenReceivedAt = DateTimeOffset.Parse("2026-03-03T14:22:30.000+0000");
        var givenInteractionType = RcsMessageInteractionType.SingleMessage;
        var givenRcsCount = 1;
        var givenKeyword = "START";
        var givenMessageId = "msg-abc123";
        var givenPairedMessageId = "msg-xyz456";
        var givenCallbackData = "custom-user-data";
        var givenUrl = "https://example.com/file.pdf";
        var givenName = "file.pdf";
        var givenContentType = "pdf";
        var givenSize = 123456L;
        var givenTrafficType = RcsMoTrafficType.Single;
        var givenPricePerMessage = 0.005m;
        var givenCurrency = "EUR";
        var givenCanInitiate = false;
        var givenConversationId = "conv-xyz789";
        var givenApplicationId = "ext-app-001";
        var givenEntityId = "ext-entity-001";
        var givenMessageCount = 1;
        var givenPendingMessageCount = 0;

        var givenRequest = $@"
            {{
              ""results"": [
                {{
                  ""campaignReferenceId"": ""{givenCampaignReferenceId}"",
                  ""sender"": ""{givenSender}"",
                  ""to"": ""{givenTo}"",
                  ""integrationType"": ""{givenIntegrationType}"",
                  ""receivedAt"": ""{givenReceivedAt:yyyy-MM-ddTHH:mm:ss.fffzzz}"",
                  ""interactionType"": ""{GetEnumAttributeValue(givenInteractionType)}"",
                  ""rcsCount"": {givenRcsCount},
                  ""keyword"": ""{givenKeyword}"",
                  ""messageId"": ""{givenMessageId}"",
                  ""pairedMessageId"": ""{givenPairedMessageId}"",
                  ""callbackData"": ""{givenCallbackData}"",
                  ""message"": {{
                    ""url"": ""{givenUrl}"",
                    ""name"": ""{givenName}"",
                    ""contentType"": ""{givenContentType}"",
                    ""size"": {givenSize},
                    ""type"": ""FILE""
                  }},
                  ""price"": {{
                    ""trafficType"": ""{GetEnumAttributeValue(givenTrafficType)}"",
                    ""pricePerMessage"": {givenPricePerMessage.ToString(CultureInfo.InvariantCulture)},
                    ""currency"": ""{givenCurrency}""
                  }},
                  ""conversation"": {{
                    ""canInitiate"": {GetBooleanValueAsLowerString(givenCanInitiate)},
                    ""id"": ""{givenConversationId}""
                  }},
                  ""platform"": {{
                    ""applicationId"": ""{givenApplicationId}"",
                    ""entityId"": ""{givenEntityId}""
                  }}
                }}
              ],
              ""messageCount"": {givenMessageCount},
              ""pendingMessageCount"": {givenPendingMessageCount}
            }}";

        var inboundMessages = JsonConvert.DeserializeObject<RcsInboundMessages>(givenRequest)!;
        var stjInboundMessages = JsonSerializer.Deserialize<RcsInboundMessages>(givenRequest)!;

        void AssertResult(RcsInboundMessages result)
        {
            Assert.IsNotNull(result);
            Assert.AreEqual(givenMessageCount, result.MessageCount);
            Assert.AreEqual(givenPendingMessageCount, result.PendingMessageCount);
            Assert.IsNotNull(result.Results);
            Assert.AreEqual(1, result.Results.Count);
            var message = result.Results[0];
            Assert.AreEqual(givenCampaignReferenceId, message.CampaignReferenceId);
            Assert.AreEqual(givenSender, message.Sender);
            Assert.AreEqual(givenTo, message.To);
            Assert.AreEqual(givenIntegrationType, message.IntegrationType);
            Assert.AreEqual(givenReceivedAt, message.ReceivedAt);
            Assert.AreEqual(givenInteractionType, message.InteractionType);
            Assert.AreEqual(givenRcsCount, message.RcsCount);
            Assert.AreEqual(givenKeyword, message.Keyword);
            Assert.AreEqual(givenMessageId, message.MessageId);
            Assert.AreEqual(givenPairedMessageId, message.PairedMessageId);
            Assert.AreEqual(givenCallbackData, message.CallbackData);
            Assert.IsNotNull(message.Message);
            Assert.IsInstanceOfType(message.Message, typeof(RcsInboundFileContent));
            var content = (RcsInboundFileContent)message.Message;
            Assert.AreEqual(givenUrl, content.Url);
            Assert.AreEqual(givenName, content.Name);
            Assert.AreEqual(givenContentType, content.ContentType);
            Assert.AreEqual(givenSize, content.Size);
            Assert.IsNotNull(message.Price);
            Assert.AreEqual(givenTrafficType, message.Price.TrafficType);
            Assert.AreEqual(givenPricePerMessage, message.Price.PricePerMessage);
            Assert.AreEqual(givenCurrency, message.Price.Currency);
            Assert.IsNotNull(message.Conversation);
            Assert.AreEqual(givenCanInitiate, message.Conversation.CanInitiate);
            Assert.AreEqual(givenConversationId, message.Conversation.Id);
            Assert.IsNotNull(message.Platform);
            Assert.AreEqual(givenApplicationId, message.Platform.ApplicationId);
            Assert.AreEqual(givenEntityId, message.Platform.EntityId);
        }

        AssertResult(inboundMessages);
        AssertResult(stjInboundMessages);
    }

    [TestMethod]
    public void ShouldParseRcsInboundSuggestionMessage()
    {
        var givenCampaignReferenceId = "CAMP-2026-Q1";
        var givenSender = "+385911234567";
        var givenTo = "+385911111111";
        var givenIntegrationType = "RCS";
        var givenReceivedAt = DateTimeOffset.Parse("2026-03-03T14:22:30.000+0000");
        var givenInteractionType = RcsMessageInteractionType.BasicMessage;
        var givenRcsCount = 1;
        var givenKeyword = "START";
        var givenMessageId = "msg-abc123";
        var givenPairedMessageId = "msg-xyz456";
        var givenCallbackData = "custom-user-data";
        var givenText = "suggestionText";
        var givenPostbackData = "suggestionPostbackData";
        var givenTrafficType = RcsMoTrafficType.Basic;
        var givenPricePerMessage = 0.005m;
        var givenCurrency = "EUR";
        var givenCanInitiate = false;
        var givenConversationId = "conv-xyz789";
        var givenApplicationId = "ext-app-001";
        var givenEntityId = "ext-entity-001";
        var givenMessageCount = 1;
        var givenPendingMessageCount = 0;

        var givenRequest = $@"
            {{
              ""results"": [
                {{
                  ""campaignReferenceId"": ""{givenCampaignReferenceId}"",
                  ""sender"": ""{givenSender}"",
                  ""to"": ""{givenTo}"",
                  ""integrationType"": ""{givenIntegrationType}"",
                  ""receivedAt"": ""{givenReceivedAt:yyyy-MM-ddTHH:mm:ss.fffzzz}"",
                  ""interactionType"": ""{GetEnumAttributeValue(givenInteractionType)}"",
                  ""rcsCount"": {givenRcsCount},
                  ""keyword"": ""{givenKeyword}"",
                  ""messageId"": ""{givenMessageId}"",
                  ""pairedMessageId"": ""{givenPairedMessageId}"",
                  ""callbackData"": ""{givenCallbackData}"",
                  ""message"": {{
                    ""text"": ""{givenText}"",
                    ""postbackData"": ""{givenPostbackData}"",
                    ""type"": ""SUGGESTION""
                  }},
                  ""price"": {{
                    ""trafficType"": ""{GetEnumAttributeValue(givenTrafficType)}"",
                    ""pricePerMessage"": {givenPricePerMessage.ToString(CultureInfo.InvariantCulture)},
                    ""currency"": ""{givenCurrency}""
                  }},
                  ""conversation"": {{
                    ""canInitiate"": {GetBooleanValueAsLowerString(givenCanInitiate)},
                    ""id"": ""{givenConversationId}""
                  }},
                  ""platform"": {{
                    ""applicationId"": ""{givenApplicationId}"",
                    ""entityId"": ""{givenEntityId}""
                  }}
                }}
              ],
              ""messageCount"": {givenMessageCount},
              ""pendingMessageCount"": {givenPendingMessageCount}
            }}";

        var inboundMessages = JsonConvert.DeserializeObject<RcsInboundMessages>(givenRequest)!;
        var stjInboundMessages = JsonSerializer.Deserialize<RcsInboundMessages>(givenRequest)!;

        void AssertResult(RcsInboundMessages result)
        {
            Assert.IsNotNull(result);
            Assert.AreEqual(givenMessageCount, result.MessageCount);
            Assert.AreEqual(givenPendingMessageCount, result.PendingMessageCount);
            Assert.IsNotNull(result.Results);
            Assert.AreEqual(1, result.Results.Count);
            var message = result.Results[0];
            Assert.AreEqual(givenCampaignReferenceId, message.CampaignReferenceId);
            Assert.AreEqual(givenSender, message.Sender);
            Assert.AreEqual(givenTo, message.To);
            Assert.AreEqual(givenIntegrationType, message.IntegrationType);
            Assert.AreEqual(givenReceivedAt, message.ReceivedAt);
            Assert.AreEqual(givenInteractionType, message.InteractionType);
            Assert.AreEqual(givenRcsCount, message.RcsCount);
            Assert.AreEqual(givenKeyword, message.Keyword);
            Assert.AreEqual(givenMessageId, message.MessageId);
            Assert.AreEqual(givenPairedMessageId, message.PairedMessageId);
            Assert.AreEqual(givenCallbackData, message.CallbackData);
            Assert.IsNotNull(message.Message);
            Assert.IsInstanceOfType(message.Message, typeof(RcsInboundSuggestionContent));
            var content = (RcsInboundSuggestionContent)message.Message;
            Assert.AreEqual(givenText, content.Text);
            Assert.AreEqual(givenPostbackData, content.PostbackData);
            Assert.IsNotNull(message.Price);
            Assert.AreEqual(givenTrafficType, message.Price.TrafficType);
            Assert.AreEqual(givenPricePerMessage, message.Price.PricePerMessage);
            Assert.AreEqual(givenCurrency, message.Price.Currency);
            Assert.IsNotNull(message.Conversation);
            Assert.AreEqual(givenCanInitiate, message.Conversation.CanInitiate);
            Assert.AreEqual(givenConversationId, message.Conversation.Id);
            Assert.IsNotNull(message.Platform);
            Assert.AreEqual(givenApplicationId, message.Platform.ApplicationId);
            Assert.AreEqual(givenEntityId, message.Platform.EntityId);
        }

        AssertResult(inboundMessages);
        AssertResult(stjInboundMessages);
    }

    [TestMethod]
    public void ShouldParseRcsInboundLocationMessage()
    {
        var givenCampaignReferenceId = "CAMP-2026-Q1";
        var givenSender = "+385911234567";
        var givenTo = "+385911111111";
        var givenIntegrationType = "RCS";
        var givenReceivedAt = DateTimeOffset.Parse("2026-03-03T14:22:30.000+0000");
        var givenInteractionType = RcsMessageInteractionType.BasicMessage;
        var givenRcsCount = 1;
        var givenKeyword = "START";
        var givenMessageId = "msg-abc123";
        var givenPairedMessageId = "msg-xyz456";
        var givenCallbackData = "custom-user-data";
        var givenLatitude = 37.7749;
        var givenLongitude = -122.4194;
        var givenTrafficType = RcsMoTrafficType.Basic;
        var givenPricePerMessage = 0.005m;
        var givenCurrency = "EUR";
        var givenCanInitiate = false;
        var givenConversationId = "conv-xyz789";
        var givenApplicationId = "ext-app-001";
        var givenEntityId = "ext-entity-001";
        var givenMessageCount = 1;
        var givenPendingMessageCount = 0;

        var givenRequest = $@"
            {{
              ""results"": [
                {{
                  ""campaignReferenceId"": ""{givenCampaignReferenceId}"",
                  ""sender"": ""{givenSender}"",
                  ""to"": ""{givenTo}"",
                  ""integrationType"": ""{givenIntegrationType}"",
                  ""receivedAt"": ""{givenReceivedAt:yyyy-MM-ddTHH:mm:ss.fffzzz}"",
                  ""interactionType"": ""{GetEnumAttributeValue(givenInteractionType)}"",
                  ""rcsCount"": {givenRcsCount},
                  ""keyword"": ""{givenKeyword}"",
                  ""messageId"": ""{givenMessageId}"",
                  ""pairedMessageId"": ""{givenPairedMessageId}"",
                  ""callbackData"": ""{givenCallbackData}"",
                  ""message"": {{
                    ""latitude"": {givenLatitude.ToString(CultureInfo.InvariantCulture)},
                    ""longitude"": {givenLongitude.ToString(CultureInfo.InvariantCulture)},
                    ""type"": ""LOCATION""
                  }},
                  ""price"": {{
                    ""trafficType"": ""{GetEnumAttributeValue(givenTrafficType)}"",
                    ""pricePerMessage"": {givenPricePerMessage.ToString(CultureInfo.InvariantCulture)},
                    ""currency"": ""{givenCurrency}""
                  }},
                  ""conversation"": {{
                    ""canInitiate"": {GetBooleanValueAsLowerString(givenCanInitiate)},
                    ""id"": ""{givenConversationId}""
                  }},
                  ""platform"": {{
                    ""applicationId"": ""{givenApplicationId}"",
                    ""entityId"": ""{givenEntityId}""
                  }}
                }}
              ],
              ""messageCount"": {givenMessageCount},
              ""pendingMessageCount"": {givenPendingMessageCount}
            }}";

        var inboundMessages = JsonConvert.DeserializeObject<RcsInboundMessages>(givenRequest)!;
        var stjInboundMessages = JsonSerializer.Deserialize<RcsInboundMessages>(givenRequest)!;

        void AssertResult(RcsInboundMessages result)
        {
            Assert.IsNotNull(result);
            Assert.AreEqual(givenMessageCount, result.MessageCount);
            Assert.AreEqual(givenPendingMessageCount, result.PendingMessageCount);
            Assert.IsNotNull(result.Results);
            Assert.AreEqual(1, result.Results.Count);
            var message = result.Results[0];
            Assert.AreEqual(givenCampaignReferenceId, message.CampaignReferenceId);
            Assert.AreEqual(givenSender, message.Sender);
            Assert.AreEqual(givenTo, message.To);
            Assert.AreEqual(givenIntegrationType, message.IntegrationType);
            Assert.AreEqual(givenReceivedAt, message.ReceivedAt);
            Assert.AreEqual(givenInteractionType, message.InteractionType);
            Assert.AreEqual(givenRcsCount, message.RcsCount);
            Assert.AreEqual(givenKeyword, message.Keyword);
            Assert.AreEqual(givenMessageId, message.MessageId);
            Assert.AreEqual(givenPairedMessageId, message.PairedMessageId);
            Assert.AreEqual(givenCallbackData, message.CallbackData);
            Assert.IsNotNull(message.Message);
            Assert.IsInstanceOfType(message.Message, typeof(RcsInboundLocationContent));
            var content = (RcsInboundLocationContent)message.Message;
            Assert.AreEqual(givenLatitude, content.Latitude);
            Assert.AreEqual(givenLongitude, content.Longitude);
            Assert.IsNotNull(message.Price);
            Assert.AreEqual(givenTrafficType, message.Price.TrafficType);
            Assert.AreEqual(givenPricePerMessage, message.Price.PricePerMessage);
            Assert.AreEqual(givenCurrency, message.Price.Currency);
            Assert.IsNotNull(message.Conversation);
            Assert.AreEqual(givenCanInitiate, message.Conversation.CanInitiate);
            Assert.AreEqual(givenConversationId, message.Conversation.Id);
            Assert.IsNotNull(message.Platform);
            Assert.AreEqual(givenApplicationId, message.Platform.ApplicationId);
            Assert.AreEqual(givenEntityId, message.Platform.EntityId);
        }

        AssertResult(inboundMessages);
        AssertResult(stjInboundMessages);
    }

    [TestMethod]
    public void ShouldReceiveRcsUserActionEvent()
    {
        var givenCampaignReferenceId = "CAMP-2026-Q1";
        var givenSender = "+385911234567";
        var givenTo = "+385911111111";
        var givenIntegrationType = "RCS";
        var givenReceivedAt = DateTimeOffset.Parse("2026-03-03T14:22:30.000+0000");
        var givenInteractionType = RcsEventInteractionType.Event;
        var givenKeyword = "START";
        var givenMessageId = "msg-abc123";
        var givenPairedMessageId = "msg-xyz456";
        var givenCallbackData = "custom-user-data";
        var givenText = "suggestionText";
        var givenPostbackData = "suggestionPostbackData";
        var givenPricePerMessage = 0m;
        var givenCurrency = "EUR";
        var givenCanInitiate = false;
        var givenConversationId = "conv-xyz789";
        var givenApplicationId = "ext-app-001";
        var givenEntityId = "ext-entity-001";
        var givenMessageCount = 1;
        var givenPendingMessageCount = 0;

        var givenRequest = $@"
            {{
              ""results"": [
                {{
                  ""campaignReferenceId"": ""{givenCampaignReferenceId}"",
                  ""sender"": ""{givenSender}"",
                  ""to"": ""{givenTo}"",
                  ""integrationType"": ""{givenIntegrationType}"",
                  ""receivedAt"": ""{givenReceivedAt:yyyy-MM-ddTHH:mm:ss.fffzzz}"",
                  ""interactionType"": ""{GetEnumAttributeValue(givenInteractionType)}"",
                  ""keyword"": ""{givenKeyword}"",
                  ""messageId"": ""{givenMessageId}"",
                  ""pairedMessageId"": ""{givenPairedMessageId}"",
                  ""callbackData"": ""{givenCallbackData}"",
                  ""message"": {{
                    ""text"": ""{givenText}"",
                    ""postbackData"": ""{givenPostbackData}"",
                    ""type"": ""SUGGESTION""
                  }},
                  ""price"": {{
                    ""trafficType"": null,
                    ""pricePerMessage"": {givenPricePerMessage.ToString(CultureInfo.InvariantCulture)},
                    ""currency"": ""{givenCurrency}""
                  }},
                  ""conversation"": {{
                    ""canInitiate"": {GetBooleanValueAsLowerString(givenCanInitiate)},
                    ""id"": ""{givenConversationId}""
                  }},
                  ""platform"": {{
                    ""applicationId"": ""{givenApplicationId}"",
                    ""entityId"": ""{givenEntityId}""
                  }}
                }}
              ],
              ""messageCount"": {givenMessageCount},
              ""pendingMessageCount"": {givenPendingMessageCount}
            }}";

        var inboundEvents = JsonConvert.DeserializeObject<RcsInboundEvents>(givenRequest)!;
        var stjInboundEvents = JsonSerializer.Deserialize<RcsInboundEvents>(givenRequest)!;

        void AssertResult(RcsInboundEvents result)
        {
            Assert.IsNotNull(result);
            Assert.AreEqual(givenMessageCount, result.MessageCount);
            Assert.AreEqual(givenPendingMessageCount, result.PendingMessageCount);
            Assert.IsNotNull(result.Results);
            Assert.AreEqual(1, result.Results.Count);
            var eventResult = result.Results[0];
            Assert.AreEqual(givenCampaignReferenceId, eventResult.CampaignReferenceId);
            Assert.AreEqual(givenSender, eventResult.Sender);
            Assert.AreEqual(givenTo, eventResult.To);
            Assert.AreEqual(givenIntegrationType, eventResult.IntegrationType);
            Assert.AreEqual(givenReceivedAt, eventResult.ReceivedAt);
            Assert.AreEqual(givenInteractionType, eventResult.InteractionType);
            Assert.AreEqual(givenKeyword, eventResult.Keyword);
            Assert.AreEqual(givenMessageId, eventResult.MessageId);
            Assert.AreEqual(givenPairedMessageId, eventResult.PairedMessageId);
            Assert.AreEqual(givenCallbackData, eventResult.CallbackData);
            Assert.IsNotNull(eventResult.Message);
            Assert.IsInstanceOfType(eventResult.Message, typeof(RcsInboundSuggestionContent));
            var content = (RcsInboundSuggestionContent)eventResult.Message;
            Assert.AreEqual(givenText, content.Text);
            Assert.AreEqual(givenPostbackData, content.PostbackData);
            Assert.IsNotNull(eventResult.Price);
            Assert.IsNull(eventResult.Price.TrafficType);
            Assert.AreEqual(givenPricePerMessage, eventResult.Price.PricePerMessage);
            Assert.AreEqual(givenCurrency, eventResult.Price.Currency);
            Assert.IsNotNull(eventResult.Conversation);
            Assert.AreEqual(givenCanInitiate, eventResult.Conversation.CanInitiate);
            Assert.AreEqual(givenConversationId, eventResult.Conversation.Id);
            Assert.IsNotNull(eventResult.Platform);
            Assert.AreEqual(givenApplicationId, eventResult.Platform.ApplicationId);
            Assert.AreEqual(givenEntityId, eventResult.Platform.EntityId);
        }

        AssertResult(inboundEvents);
        AssertResult(stjInboundEvents);
    }

    [TestMethod]
    public void ShouldReceiveRcsTypingIndicatorEvent()
    {
        var givenSender = "+385911111111";
        var givenTo = "+385911234567";
        var givenReceivedAt = "2026-03-03T14:22:30Z";
        var givenEventType = RcsIsTypingEventType.TypingIndicator;
        var givenEntityId = "ext-entity-001";
        var givenApplicationId = "ext-app-001";
        var givenEventCount = 1;
        var givenPendingEventCount = 0;

        var givenRequest = $@"
            {{
              ""results"": [
                {{
                  ""sender"": ""{givenSender}"",
                  ""to"": ""{givenTo}"",
                  ""receivedAt"": ""{givenReceivedAt}"",
                  ""event"": {{
                    ""type"": ""{GetEnumAttributeValue(givenEventType)}""
                  }},
                  ""entityId"": ""{givenEntityId}"",
                  ""applicationId"": ""{givenApplicationId}""
                }}
              ],
              ""eventCount"": {givenEventCount},
              ""pendingEventCount"": {givenPendingEventCount}
            }}";

        var isTypingEvents = JsonConvert.DeserializeObject<RcsIsTypingEvents>(givenRequest)!;
        var stjIsTypingEvents = JsonSerializer.Deserialize<RcsIsTypingEvents>(givenRequest)!;

        void AssertResult(RcsIsTypingEvents result)
        {
            Assert.IsNotNull(result);
            Assert.AreEqual(givenEventCount, result.EventCount);
            Assert.AreEqual(givenPendingEventCount, result.PendingEventCount);
            Assert.IsNotNull(result.Results);
            Assert.AreEqual(1, result.Results.Count);
            var eventResult = result.Results[0];
            Assert.AreEqual(givenSender, eventResult.Sender);
            Assert.AreEqual(givenTo, eventResult.To);
            Assert.AreEqual(givenReceivedAt, eventResult.ReceivedAt);
            Assert.IsNotNull(eventResult.Event);
            Assert.AreEqual(givenEventType, eventResult.Event.Type);
            Assert.AreEqual(givenEntityId, eventResult.EntityId);
            Assert.AreEqual(givenApplicationId, eventResult.ApplicationId);
        }

        AssertResult(isTypingEvents);
        AssertResult(stjIsTypingEvents);
    }

    [TestMethod]
    public void ShouldGetRcsDeliveryReports()
    {
        var givenBulkId = "BULK-123456";
        var givenStatusGroupId = 3;
        var givenStatusGroupName = "DELIVERED";
        var givenStatusId = 5;
        var givenStatusName = "DELIVERED_TO_HANDSET";
        var givenStatusDescription = "Message delivered to handset";
        var givenErrorGroupId = 0;
        var givenErrorGroupName = "OK";
        var givenErrorId = 0;
        var givenErrorName = "NO_ERROR";
        var givenErrorDescription = "No error";
        var givenErrorIsPermanent = false;
        var givenMessageId = "msg-abc123";
        var givenDoneAt = DateTimeOffset.Parse("2026-03-03T14:22:35.000+0100");
        var givenMessageCount = 1;
        var givenSentAt = DateTimeOffset.Parse("2026-03-03T14:22:30.000+0100");
        var givenMccMnc = "21910";
        var givenCallbackData = "custom-user-data";
        var givenTo = "+385911234567";
        var givenSender = "sender";
        var givenEntityId = "ext-entity-001";
        var givenApplicationId = "ext-app-001";
        var givenCampaignReferenceId = "CAMP-2026-Q1";
        var givenQueryLimit = 1;
        var givenQueryEntityId = "promotional-traffic-entity";
        var givenQueryApplicationId = "marketing-automation-application";
        var givenQueryCampaignReferenceId = "summersale";

        var givenResponse = $@"
            {{
              ""results"": [
                {{
                  ""bulkId"": ""{givenBulkId}"",
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
                    ""permanent"": {GetBooleanValueAsLowerString(givenErrorIsPermanent)}
                  }},
                  ""messageId"": ""{givenMessageId}"",
                  ""doneAt"": ""{givenDoneAt:yyyy-MM-ddTHH:mm:ss.fffzzz}"",
                  ""messageCount"": {givenMessageCount},
                  ""sentAt"": ""{givenSentAt:yyyy-MM-ddTHH:mm:ss.fffzzz}"",
                  ""mccMnc"": ""{givenMccMnc}"",
                  ""callbackData"": ""{givenCallbackData}"",
                  ""to"": ""{givenTo}"",
                  ""sender"": ""{givenSender}"",
                  ""platform"": {{
                    ""entityId"": ""{givenEntityId}"",
                    ""applicationId"": ""{givenApplicationId}""
                  }},
                  ""campaignReferenceId"": ""{givenCampaignReferenceId}""
                }}
              ]
            }}";

        SetUpGetRequest(RCS_REPORTS_ENDPOINT, 200, givenResponse, new Dictionary<string, string>
        {
            { "limit", givenQueryLimit.ToString() },
            { "entityId", givenQueryEntityId },
            { "applicationId", givenQueryApplicationId },
            { "campaignReferenceId", givenQueryCampaignReferenceId }
        });

        var api = new RcsApi(Configuration);

        void AssertReports(RcsDeliveryReports reports)
        {
            Assert.IsNotNull(reports);
            Assert.IsNotNull(reports.Results);
            Assert.AreEqual(1, reports.Results.Count);
            var result = reports.Results[0];
            Assert.AreEqual(givenBulkId, result.BulkId);
            Assert.IsNotNull(result.Status);
            Assert.AreEqual(givenStatusGroupId, result.Status.GroupId);
            Assert.AreEqual(givenStatusGroupName, result.Status.GroupName);
            Assert.AreEqual(givenStatusId, result.Status.Id);
            Assert.AreEqual(givenStatusName, result.Status.Name);
            Assert.AreEqual(givenStatusDescription, result.Status.Description);
            Assert.IsNotNull(result.Error);
            Assert.AreEqual(givenErrorGroupId, result.Error.GroupId);
            Assert.AreEqual(givenErrorGroupName, result.Error.GroupName);
            Assert.AreEqual(givenErrorId, result.Error.Id);
            Assert.AreEqual(givenErrorName, result.Error.Name);
            Assert.AreEqual(givenErrorDescription, result.Error.Description);
            Assert.AreEqual(givenErrorIsPermanent, result.Error.Permanent);
            Assert.AreEqual(givenMessageId, result.MessageId);
            Assert.AreEqual(givenDoneAt, result.DoneAt);
            Assert.AreEqual(givenMessageCount, result.MessageCount);
            Assert.AreEqual(givenSentAt, result.SentAt);
            Assert.AreEqual(givenMccMnc, result.MccMnc);
            Assert.AreEqual(givenCallbackData, result.CallbackData);
            Assert.AreEqual(givenTo, result.To);
            Assert.AreEqual(givenSender, result.Sender);
            Assert.IsNotNull(result.Platform);
            Assert.AreEqual(givenEntityId, result.Platform.EntityId);
            Assert.AreEqual(givenApplicationId, result.Platform.ApplicationId);
            Assert.AreEqual(givenCampaignReferenceId, result.CampaignReferenceId);
        }

        AssertReports(api.GetOutboundRcsMessageDeliveryReports(limit: givenQueryLimit, entityId: givenQueryEntityId,
            applicationId: givenQueryApplicationId, campaignReferenceId: givenQueryCampaignReferenceId));
        AssertReports(api.GetOutboundRcsMessageDeliveryReportsAsync(limit: givenQueryLimit,
            entityId: givenQueryEntityId, applicationId: givenQueryApplicationId,
            campaignReferenceId: givenQueryCampaignReferenceId).Result);
        AssertResponseWithHttpInfo(
            api.GetOutboundRcsMessageDeliveryReportsWithHttpInfo(limit: givenQueryLimit, entityId: givenQueryEntityId,
                applicationId: givenQueryApplicationId, campaignReferenceId: givenQueryCampaignReferenceId),
            AssertReports, 200);
        AssertResponseWithHttpInfo(
            api.GetOutboundRcsMessageDeliveryReportsWithHttpInfoAsync(limit: givenQueryLimit,
                entityId: givenQueryEntityId, applicationId: givenQueryApplicationId,
                campaignReferenceId: givenQueryCampaignReferenceId).Result, AssertReports, 200);
    }

    [TestMethod]
    public void ShouldGetRcsMessageLogs()
    {
        var givenSender = "string";
        var givenDestination = "string";
        var givenBulkId = "BULK-ID-123-xyz";
        var givenMessageId = "string";
        var givenSentAt = DateTimeOffset.Parse("2019-08-24T14:15:22Z");
        var givenDoneAt = DateTimeOffset.Parse("2019-08-24T14:15:22Z");
        var givenMessageCount = 0;
        var givenPricePerMessage = 0m;
        var givenCurrency = "string";
        var givenStatusGroupId = 0;
        var givenStatusGroupName = "ACCEPTED";
        var givenStatusId = 0;
        var givenStatusName = "string";
        var givenStatusDescription = "string";
        var givenStatusAction = "string";
        var givenErrorGroupId = 0;
        var givenErrorGroupName = "OK";
        var givenErrorId = 0;
        var givenErrorName = "string";
        var givenErrorDescription = "string";
        var givenErrorIsPermanent = true;
        var givenEntityId = "string";
        var givenApplicationId = "string";
        var givenCampaignReferenceId = "string";
        var givenCursorLimit = 0;
        var givenNextCursor = "string";
        var givenQueryBulkId = "BULK-ID-123-xyz";
        var givenQueryMessageId1 = "MESSAGE-ID-123-xyz";
        var givenQueryMessageId2 = "MESSAGE-ID-124-xyz";
        var givenSentSince = DateTimeOffset.Parse("2020-02-22T17:42:05.390+01:00");
        var givenSentUntil = DateTimeOffset.Parse("2020-02-23T17:42:05.390+01:00");
        var givenQueryEntityId = "promotional-traffic-entity";
        var givenQueryApplicationId = "marketing-automation-application";
        var givenQueryCampaignReferenceId = "summersale";

        var givenResponse = $@"
            {{
              ""results"": [
                {{
                  ""sender"": ""{givenSender}"",
                  ""destination"": ""{givenDestination}"",
                  ""bulkId"": ""{givenBulkId}"",
                  ""messageId"": ""{givenMessageId}"",
                  ""sentAt"": ""{givenSentAt:yyyy-MM-ddTHH:mm:sszzz}"",
                  ""doneAt"": ""{givenDoneAt:yyyy-MM-ddTHH:mm:sszzz}"",
                  ""messageCount"": {givenMessageCount},
                  ""price"": {{
                    ""pricePerMessage"": {givenPricePerMessage},
                    ""currency"": ""{givenCurrency}""
                  }},
                  ""status"": {{
                    ""groupId"": {givenStatusGroupId},
                    ""groupName"": ""{givenStatusGroupName}"",
                    ""id"": {givenStatusId},
                    ""name"": ""{givenStatusName}"",
                    ""description"": ""{givenStatusDescription}"",
                    ""action"": ""{givenStatusAction}""
                  }},
                  ""error"": {{
                    ""groupId"": {givenErrorGroupId},
                    ""groupName"": ""{givenErrorGroupName}"",
                    ""id"": {givenErrorId},
                    ""name"": ""{givenErrorName}"",
                    ""description"": ""{givenErrorDescription}"",
                    ""permanent"": {GetBooleanValueAsLowerString(givenErrorIsPermanent)}
                  }},
                  ""platform"": {{
                    ""entityId"": ""{givenEntityId}"",
                    ""applicationId"": ""{givenApplicationId}""
                  }},
                  ""content"": {{
                    ""type"": ""TEXT""
                  }},
                  ""campaignReferenceId"": ""{givenCampaignReferenceId}""
                }}
              ],
              ""cursor"": {{
                ""limit"": {givenCursorLimit},
                ""nextCursor"": ""{givenNextCursor}""
              }}
            }}";

        SetUpGetRequest(RCS_LOGS_ENDPOINT, 200, givenResponse, new Dictionary<string, string>
        {
            { "bulkId", givenQueryBulkId },
            { "messageId", $"{givenQueryMessageId1},{givenQueryMessageId2}" },
            { "sentSince", givenSentSince.ToString("yyyy-MM-ddTHH:mm:ss.fffzzz") },
            { "sentUntil", givenSentUntil.ToString("yyyy-MM-ddTHH:mm:ss.fffzzz") },
            { "entityId", givenQueryEntityId },
            { "applicationId", givenQueryApplicationId },
            { "campaignReferenceId", givenQueryCampaignReferenceId }
        });

        var api = new RcsApi(Configuration);

        void AssertLogs(RcsLogsResponse logs)
        {
            Assert.IsNotNull(logs);
            Assert.IsNotNull(logs.Results);
            Assert.AreEqual(1, logs.Results.Count);
            var result = logs.Results[0];
            Assert.AreEqual(givenSender, result.Sender);
            Assert.AreEqual(givenDestination, result.Destination);
            Assert.AreEqual(givenBulkId, result.BulkId);
            Assert.AreEqual(givenMessageId, result.MessageId);
            Assert.AreEqual(givenSentAt, result.SentAt);
            Assert.AreEqual(givenDoneAt, result.DoneAt);
            Assert.AreEqual(givenMessageCount, result.MessageCount);
            Assert.IsNotNull(result.Price);
            Assert.AreEqual(givenPricePerMessage, result.Price.PricePerMessage);
            Assert.AreEqual(givenCurrency, result.Price.Currency);
            Assert.IsNotNull(result.Status);
            Assert.AreEqual(givenStatusGroupId, result.Status.GroupId);
            Assert.AreEqual(givenStatusGroupName, result.Status.GroupName);
            Assert.AreEqual(givenStatusId, result.Status.Id);
            Assert.AreEqual(givenStatusName, result.Status.Name);
            Assert.AreEqual(givenStatusDescription, result.Status.Description);
            Assert.AreEqual(givenStatusAction, result.Status.Action);
            Assert.IsNotNull(result.Error);
            Assert.AreEqual(givenErrorGroupId, result.Error.GroupId);
            Assert.AreEqual(givenErrorGroupName, result.Error.GroupName);
            Assert.AreEqual(givenErrorId, result.Error.Id);
            Assert.AreEqual(givenErrorName, result.Error.Name);
            Assert.AreEqual(givenErrorDescription, result.Error.Description);
            Assert.AreEqual(givenErrorIsPermanent, result.Error.Permanent);
            Assert.IsNotNull(result.Platform);
            Assert.AreEqual(givenEntityId, result.Platform.EntityId);
            Assert.AreEqual(givenApplicationId, result.Platform.ApplicationId);
            Assert.IsInstanceOfType(result.Content, typeof(RcsOutboundTextContent));
            Assert.AreEqual(givenCampaignReferenceId, result.CampaignReferenceId);
            Assert.IsNotNull(logs.Cursor);
            Assert.AreEqual(givenCursorLimit, logs.Cursor.Limit);
            Assert.AreEqual(givenNextCursor, logs.Cursor.NextCursor);
        }

        AssertResponse(
            api.GetOutboundRcsMessageLogs(bulkId: new List<string> { givenQueryBulkId },
                messageId: new List<string> { givenQueryMessageId1, givenQueryMessageId2 }, sentSince: givenSentSince,
                sentUntil: givenSentUntil, entityId: givenQueryEntityId, applicationId: givenQueryApplicationId,
                campaignReferenceId: new List<string> { givenQueryCampaignReferenceId }), AssertLogs);
        AssertResponse(
            api.GetOutboundRcsMessageLogsAsync(bulkId: new List<string> { givenQueryBulkId },
                messageId: new List<string> { givenQueryMessageId1, givenQueryMessageId2 }, sentSince: givenSentSince,
                sentUntil: givenSentUntil, entityId: givenQueryEntityId, applicationId: givenQueryApplicationId,
                campaignReferenceId: new List<string> { givenQueryCampaignReferenceId }).Result, AssertLogs);
        AssertResponseWithHttpInfo(
            api.GetOutboundRcsMessageLogsWithHttpInfo(bulkId: new List<string> { givenQueryBulkId },
                messageId: new List<string> { givenQueryMessageId1, givenQueryMessageId2 }, sentSince: givenSentSince,
                sentUntil: givenSentUntil, entityId: givenQueryEntityId, applicationId: givenQueryApplicationId,
                campaignReferenceId: new List<string> { givenQueryCampaignReferenceId }), AssertLogs, 200);
        AssertResponseWithHttpInfo(
            api.GetOutboundRcsMessageLogsWithHttpInfoAsync(bulkId: new List<string> { givenQueryBulkId },
                messageId: new List<string> { givenQueryMessageId1, givenQueryMessageId2 }, sentSince: givenSentSince,
                sentUntil: givenSentUntil, entityId: givenQueryEntityId, applicationId: givenQueryApplicationId,
                campaignReferenceId: new List<string> { givenQueryCampaignReferenceId }).Result, AssertLogs, 200);
    }

    [TestMethod]
    public void ShouldReceiveRcsDeliveryReports()
    {
        var givenBulkId = "BULK-123456";
        var givenTrafficType = RcsDlrTrafficType.Basic;
        var givenPricePerMessage = 0.005m;
        var givenCurrency = "EUR";
        var givenStatusGroupId = 3;
        var givenStatusGroupName = "DELIVERED";
        var givenStatusId = 5;
        var givenStatusName = "DELIVERED_TO_HANDSET";
        var givenStatusDescription = "Message delivered to handset";
        var givenErrorGroupId = 0;
        var givenErrorGroupName = "OK";
        var givenErrorId = 0;
        var givenErrorName = "NO_ERROR";
        var givenErrorDescription = "No error";
        var givenErrorIsPermanent = false;
        var givenConversationCanInitiate = true;
        var givenMessageId = "msg-abc123";
        var givenDoneAt = DateTimeOffset.Parse("2026-03-03T14:22:35.000+01:00");
        var givenInteractionType = RcsMessageInteractionType.BasicMessage;
        var givenMessageCount = 1;
        var givenSentAt = DateTimeOffset.Parse("2026-03-03T14:22:30.000+01:00");
        var givenMccMnc = "21910";
        var givenCallbackData = "custom-user-data";
        var givenTo = "+385911234567";
        var givenSender = "sender";
        var givenEntityId = "ext-entity-001";
        var givenApplicationId = "ext-app-001";
        var givenCampaignReferenceId = "CAMP-2026-Q1";

        var givenRequest = $@"
            {{
              ""results"": [
                {{
                  ""bulkId"": ""{givenBulkId}"",
                  ""price"": {{
                    ""trafficType"": ""{GetEnumAttributeValue(givenTrafficType)}"",
                    ""pricePerMessage"": {givenPricePerMessage.ToString(CultureInfo.InvariantCulture)},
                    ""currency"": ""{givenCurrency}""
                  }},
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
                    ""permanent"": {GetBooleanValueAsLowerString(givenErrorIsPermanent)}
                  }},
                  ""conversation"": {{
                    ""canInitiate"": {GetBooleanValueAsLowerString(givenConversationCanInitiate)},
                    ""id"": null
                  }},
                  ""messageId"": ""{givenMessageId}"",
                  ""doneAt"": ""{givenDoneAt:yyyy-MM-ddTHH:mm:ss.fffzzz}"",
                  ""interactionType"": ""{GetEnumAttributeValue(givenInteractionType)}"",
                  ""messageCount"": {givenMessageCount},
                  ""sentAt"": ""{givenSentAt:yyyy-MM-ddTHH:mm:ss.fffzzz}"",
                  ""mccMnc"": ""{givenMccMnc}"",
                  ""callbackData"": ""{givenCallbackData}"",
                  ""to"": ""{givenTo}"",
                  ""sender"": ""{givenSender}"",
                  ""platform"": {{
                    ""entityId"": ""{givenEntityId}"",
                    ""applicationId"": ""{givenApplicationId}""
                  }},
                  ""campaignReferenceId"": ""{givenCampaignReferenceId}""
                }}
              ]
            }}";

        void AssertReport(RcsWebhookDeliveryReports reports)
        {
            Assert.IsNotNull(reports);
            Assert.IsNotNull(reports.Results);
            Assert.AreEqual(1, reports.Results.Count);
            var report = reports.Results[0];
            Assert.AreEqual(givenBulkId, report.BulkId);
            Assert.IsNotNull(report.Price);
            Assert.AreEqual(givenTrafficType, report.Price.TrafficType);
            Assert.AreEqual(givenPricePerMessage, report.Price.PricePerMessage);
            Assert.AreEqual(givenCurrency, report.Price.Currency);
            Assert.IsNotNull(report.Status);
            Assert.AreEqual(givenStatusGroupId, report.Status.GroupId);
            Assert.AreEqual(givenStatusGroupName, report.Status.GroupName);
            Assert.AreEqual(givenStatusId, report.Status.Id);
            Assert.AreEqual(givenStatusName, report.Status.Name);
            Assert.AreEqual(givenStatusDescription, report.Status.Description);
            Assert.IsNotNull(report.Error);
            Assert.AreEqual(givenErrorGroupId, report.Error.GroupId);
            Assert.AreEqual(givenErrorGroupName, report.Error.GroupName);
            Assert.AreEqual(givenErrorId, report.Error.Id);
            Assert.AreEqual(givenErrorName, report.Error.Name);
            Assert.AreEqual(givenErrorDescription, report.Error.Description);
            Assert.AreEqual(givenErrorIsPermanent, report.Error.Permanent);
            Assert.IsNotNull(report.Conversation);
            Assert.AreEqual(givenConversationCanInitiate, report.Conversation.CanInitiate);
            Assert.IsNull(report.Conversation.Id);
            Assert.AreEqual(givenMessageId, report.MessageId);
            Assert.AreEqual(givenDoneAt, report.DoneAt);
            Assert.AreEqual(givenInteractionType, report.InteractionType);
            Assert.AreEqual(givenMessageCount, report.MessageCount);
            Assert.AreEqual(givenSentAt, report.SentAt);
            Assert.AreEqual(givenMccMnc, report.MccMnc);
            Assert.AreEqual(givenCallbackData, report.CallbackData);
            Assert.AreEqual(givenTo, report.To);
            Assert.AreEqual(givenSender, report.Sender);
            Assert.IsNotNull(report.Platform);
            Assert.AreEqual(givenEntityId, report.Platform.EntityId);
            Assert.AreEqual(givenApplicationId, report.Platform.ApplicationId);
            Assert.AreEqual(givenCampaignReferenceId, report.CampaignReferenceId);
        }

        AssertReport(JsonConvert.DeserializeObject<RcsWebhookDeliveryReports>(givenRequest)!);
        AssertReport(JsonSerializer.Deserialize<RcsWebhookDeliveryReports>(givenRequest)!);
    }

    [TestMethod]
    public void ShouldReceiveSeenReports()
    {
        var givenMessageId = "string";
        var givenFrom = "string";
        var givenTo = "string";
        var givenSentAt = DateTimeOffset.Parse("2019-08-24T14:15:22Z");
        var givenSeenAt = DateTimeOffset.Parse("2019-08-24T14:15:22Z");
        var givenApplicationId = "string";
        var givenEntityId = "string";
        var givenCampaignReferenceId = "string";

        var givenRequest = $@"
            {{
              ""results"": [
                {{
                  ""messageId"": ""{givenMessageId}"",
                  ""from"": ""{givenFrom}"",
                  ""to"": ""{givenTo}"",
                  ""sentAt"": ""{givenSentAt:yyyy-MM-ddTHH:mm:sszzz}"",
                  ""seenAt"": ""{givenSeenAt:yyyy-MM-ddTHH:mm:sszzz}"",
                  ""applicationId"": ""{givenApplicationId}"",
                  ""entityId"": ""{givenEntityId}"",
                  ""campaignReferenceId"": ""{givenCampaignReferenceId}""
                }}
              ]
            }}";

        void AssertReports(RcsSeenReports reports)
        {
            Assert.IsNotNull(reports);
            Assert.IsNotNull(reports.Results);
            Assert.AreEqual(1, reports.Results.Count);
            var report = reports.Results[0];
            Assert.AreEqual(givenMessageId, report.MessageId);
            Assert.AreEqual(givenFrom, report.From);
            Assert.AreEqual(givenTo, report.To);
            Assert.AreEqual(givenSentAt, report.SentAt);
            Assert.AreEqual(givenSeenAt, report.SeenAt);
            Assert.AreEqual(givenApplicationId, report.ApplicationId);
            Assert.AreEqual(givenEntityId, report.EntityId);
            Assert.AreEqual(givenCampaignReferenceId, report.CampaignReferenceId);
        }

        AssertReports(JsonConvert.DeserializeObject<RcsSeenReports>(givenRequest)!);
        AssertReports(JsonSerializer.Deserialize<RcsSeenReports>(givenRequest)!);
    }

    [TestMethod]
    public void ShouldReceiveRcsConversationStartedEvent()
    {
        var givenMessageId = "msg-abc123";
        var givenTrafficType = RcsConvStartedTrafficType.A2PCONVERSATION;
        var givenConversationType = RcsConversationType.A2P;
        var givenConversationId = "conv-xyz789";
        var givenConversationStartTime = DateTimeOffset.Parse("2026-06-14T09:12:00.000+0000");
        var givenConversationEndTime = DateTimeOffset.Parse("2026-06-15T09:12:00.000+0000");
        var givenEntityId = "ext-entity-001";
        var givenApplicationId = "ext-app-001";
        var givenEventCount = 1;
        var givenPendingEventCount = 0;

        var givenRequest = $@"
            {{
              ""results"": [
                {{
                  ""messageId"": ""{givenMessageId}"",
                  ""trafficType"": ""{GetEnumAttributeValue(givenTrafficType)}"",
                  ""event"": {{
                    ""type"": ""CONVERSATION_STARTED""
                  }},
                  ""conversation"": {{
                    ""type"": ""{GetEnumAttributeValue(givenConversationType)}"",
                    ""id"": ""{givenConversationId}"",
                    ""startTime"": ""{givenConversationStartTime:yyyy-MM-ddTHH:mm:ss.fffzzz}"",
                    ""endTime"": ""{givenConversationEndTime:yyyy-MM-ddTHH:mm:ss.fffzzz}""
                  }},
                  ""platform"": {{
                    ""entityId"": ""{givenEntityId}"",
                    ""applicationId"": ""{givenApplicationId}""
                  }}
                }}
              ],
              ""eventCount"": {givenEventCount},
              ""pendingEventCount"": {givenPendingEventCount}
            }}";

        void AssertEvents(RcsConversationStartedEvents events)
        {
            Assert.IsNotNull(events);
            Assert.AreEqual(givenEventCount, events.EventCount);
            Assert.AreEqual(givenPendingEventCount, events.PendingEventCount);
            Assert.IsNotNull(events.Results);
            Assert.AreEqual(1, events.Results.Count);
            var result = events.Results[0];
            Assert.AreEqual(givenMessageId, result.MessageId);
            Assert.AreEqual(givenTrafficType, result.TrafficType);
            Assert.IsNotNull(result.Event);
            Assert.AreEqual(RcsConversationStartedEventType.ConversationStarted, result.Event.Type);
            Assert.IsNotNull(result.Conversation);
            Assert.AreEqual(givenConversationType, result.Conversation.Type);
            Assert.AreEqual(givenConversationId, result.Conversation.Id);
            Assert.AreEqual(givenConversationStartTime, result.Conversation.StartTime);
            Assert.AreEqual(givenConversationEndTime, result.Conversation.EndTime);
            Assert.IsNotNull(result.Platform);
            Assert.AreEqual(givenEntityId, result.Platform.EntityId);
            Assert.AreEqual(givenApplicationId, result.Platform.ApplicationId);
        }

        AssertEvents(JsonConvert.DeserializeObject<RcsConversationStartedEvents>(givenRequest)!);
        AssertEvents(JsonSerializer.Deserialize<RcsConversationStartedEvents>(givenRequest)!);
    }

    [TestMethod]
    public void ShouldCheckRcsCapability()
    {
        var givenSender = "DemoSender";
        var givenPhoneNumber1 = "441134960001";
        var givenPhoneNumber2 = "441134960002";
        var givenEntityId = "Example entity id";
        var givenApplicationId = "Example application id";
        var givenMessageId1 = "d5c3bdff-2d44-4f74-8a8e-3792fa57dfc8";
        var givenMessageId2 = "b5c3bdff-2d44-4f74-8a8e-3792fa57dfc3";
        var givenCode1 = RcsCapabilityCheckResponseCode.Enabled;
        var givenCode2 = RcsCapabilityCheckResponseCode.Unreachable;

        var givenRequest = $@"
            {{
              ""sender"": ""{givenSender}"",
              ""phoneNumbers"": [
                ""{givenPhoneNumber1}"",
                ""{givenPhoneNumber2}""
              ],
              ""options"": {{
                ""platform"": {{
                  ""entityId"": ""{givenEntityId}"",
                  ""applicationId"": ""{givenApplicationId}""
                }}
              }}
            }}";

        var givenResponse = $@"
            {{
              ""capabilityCheckResults"": [
                {{
                  ""messageId"": ""{givenMessageId1}"",
                  ""phoneNumber"": ""{givenPhoneNumber1}"",
                  ""code"": ""{GetEnumAttributeValue(givenCode1)}""
                }},
                {{
                  ""messageId"": ""{givenMessageId2}"",
                  ""phoneNumber"": ""{givenPhoneNumber2}"",
                  ""code"": ""{GetEnumAttributeValue(givenCode2)}""
                }}
              ],
              ""options"": {{
                ""platform"": {{
                  ""entityId"": ""{givenEntityId}"",
                  ""applicationId"": ""{givenApplicationId}""
                }}
              }}
            }}";

        SetUpPostRequest(RCS_CAPABILITY_CHECK_QUERY_ENDPOINT, 200, givenRequest, givenResponse);

        var api = new RcsApi(Configuration);

        void AssertResponse(RcsCapabilityCheckSyncResponse response)
        {
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.CapabilityCheckResults);
            Assert.AreEqual(2, response.CapabilityCheckResults.Count);
            var result1 = response.CapabilityCheckResults[0];
            Assert.AreEqual(givenMessageId1, result1.MessageId);
            Assert.AreEqual(givenPhoneNumber1, result1.PhoneNumber);
            Assert.AreEqual(givenCode1, result1.Code);
            var result2 = response.CapabilityCheckResults[1];
            Assert.AreEqual(givenMessageId2, result2.MessageId);
            Assert.AreEqual(givenPhoneNumber2, result2.PhoneNumber);
            Assert.AreEqual(givenCode2, result2.Code);
            Assert.IsNotNull(response.Options);
            Assert.IsNotNull(response.Options.Platform);
            Assert.AreEqual(givenEntityId, response.Options.Platform.EntityId);
            Assert.AreEqual(givenApplicationId, response.Options.Platform.ApplicationId);
        }

        var request = new RcsCapabilityCheckSyncRequest(
            givenSender,
            new List<string> { givenPhoneNumber1, givenPhoneNumber2 },
            new RcsCapabilityCheckOptions(
                new Platform(givenEntityId, givenApplicationId)
            )
        );

        AssertResponse(api.CapabilityCheckRcsDestinationsQuery(request));
        AssertResponse(api.CapabilityCheckRcsDestinationsQueryAsync(request).Result);
        AssertResponseWithHttpInfo(api.CapabilityCheckRcsDestinationsQueryWithHttpInfo(request), AssertResponse, 200);
        AssertResponseWithHttpInfo(api.CapabilityCheckRcsDestinationsQueryWithHttpInfoAsync(request).Result,
            AssertResponse, 200);
    }

    [TestMethod]
    public void ShouldCheckRcsCapabilityAsync()
    {
        var givenSender = "DemoSender";
        var givenPhoneNumber1 = "441134960001";
        var givenPhoneNumber2 = "441134960002";
        var givenNotifyUrl = "http://example.com/notify";
        var givenNotifyContentType = "application/json";
        var givenEntityId = "Example entity id";
        var givenApplicationId = "Example application id";
        var givenBulkId = "d5c3bdff-2d44-4f74-8a8e-3792fa57dfc8";
        var givenMessageId1 = "d5c3bdff-2d44-4f74-8a8e-3792fa57dfc8";
        var givenMessageId2 = "b5c3bdff-2d44-4f74-8a8e-3792fa57dfc3";
        var givenStatus = RcsStatusReason.PendingEnroute;

        var givenRequest = $@"
            {{
              ""sender"": ""{givenSender}"",
              ""phoneNumbers"": [
                ""{givenPhoneNumber1}"",
                ""{givenPhoneNumber2}""
              ],
              ""notifyUrl"": ""{givenNotifyUrl}"",
              ""notifyContentType"": ""{givenNotifyContentType}"",
              ""options"": {{
                ""platform"": {{
                  ""entityId"": ""{givenEntityId}"",
                  ""applicationId"": ""{givenApplicationId}""
                }}
              }}
            }}";

        var givenResponse = $@"
            {{
              ""bulkId"": ""{givenBulkId}"",
              ""capabilityCheckRequestStates"": [
                {{
                  ""messageId"": ""{givenMessageId1}"",
                  ""phoneNumber"": ""{givenPhoneNumber1}"",
                  ""status"": ""{GetEnumAttributeValue(givenStatus)}""
                }},
                {{
                  ""messageId"": ""{givenMessageId2}"",
                  ""phoneNumber"": ""{givenPhoneNumber2}"",
                  ""status"": ""{GetEnumAttributeValue(givenStatus)}""
                }}
              ]
            }}";

        SetUpPostRequest(RCS_CAPABILITY_CHECK_NOTIFY_ENDPOINT, 200, givenRequest, givenResponse);

        var api = new RcsApi(Configuration);

        void AssertResponse(RcsCapabilityCheckAsyncResponse response)
        {
            Assert.IsNotNull(response);
            Assert.AreEqual(givenBulkId, response.BulkId);
            Assert.IsNotNull(response.CapabilityCheckRequestStates);
            Assert.AreEqual(2, response.CapabilityCheckRequestStates.Count);
            var state1 = response.CapabilityCheckRequestStates[0];
            Assert.AreEqual(givenMessageId1, state1.MessageId);
            Assert.AreEqual(givenPhoneNumber1, state1.PhoneNumber);
            Assert.AreEqual(givenStatus, state1.Status);
            var state2 = response.CapabilityCheckRequestStates[1];
            Assert.AreEqual(givenMessageId2, state2.MessageId);
            Assert.AreEqual(givenPhoneNumber2, state2.PhoneNumber);
            Assert.AreEqual(givenStatus, state2.Status);
        }

        var request = new RcsCapabilityCheckAsyncRequest(
            givenSender,
            new List<string> { givenPhoneNumber1, givenPhoneNumber2 },
            givenNotifyUrl,
            givenNotifyContentType,
            new RcsCapabilityCheckOptions(
                new Platform(givenEntityId, givenApplicationId)
            )
        );

        AssertResponse(api.CapabilityCheckRcsDestinationsNotify(request));
        AssertResponse(api.CapabilityCheckRcsDestinationsNotifyAsync(request).Result);
        AssertResponseWithHttpInfo(api.CapabilityCheckRcsDestinationsNotifyWithHttpInfo(request), AssertResponse, 200);
        AssertResponseWithHttpInfo(api.CapabilityCheckRcsDestinationsNotifyWithHttpInfoAsync(request).Result,
            AssertResponse, 200);
    }

    [TestMethod]
    public void ShouldReceiveCapabilityCheckResult()
    {
        var givenBulkId = "d5c3bdff-2d44-4f74-8a8e-3792fa57dfc8";
        var givenMessageId = "b5c3bdff-2d44-4f74-8a8e-3792fa57dfc3";
        var givenPhoneNumber = "441134960001";
        var givenCode = RcsCapabilityCheckResponseCode.Enabled;
        var givenEntityId = "Example entity id";
        var givenApplicationId = "Example application id";

        var givenRequest = $@"
            {{
              ""capabilityCheckResult"": {{
                ""bulkId"": ""{givenBulkId}"",
                ""messageId"": ""{givenMessageId}"",
                ""phoneNumber"": ""{givenPhoneNumber}"",
                ""code"": ""{GetEnumAttributeValue(givenCode)}""
              }},
              ""options"": {{
                ""platform"": {{
                  ""entityId"": ""{givenEntityId}"",
                  ""applicationId"": ""{givenApplicationId}""
                }}
              }}
            }}";

        void AssertResult(RcsCapabilityCheckAsyncResult result)
        {
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.CapabilityCheckResult);
            Assert.AreEqual(givenBulkId, result.CapabilityCheckResult.BulkId);
            Assert.AreEqual(givenMessageId, result.CapabilityCheckResult.MessageId);
            Assert.AreEqual(givenPhoneNumber, result.CapabilityCheckResult.PhoneNumber);
            Assert.AreEqual(givenCode, result.CapabilityCheckResult.Code);
            Assert.IsNotNull(result.Options);
            Assert.IsNotNull(result.Options.Platform);
            Assert.AreEqual(givenEntityId, result.Options.Platform.EntityId);
            Assert.AreEqual(givenApplicationId, result.Options.Platform.ApplicationId);
        }

        AssertResult(JsonConvert.DeserializeObject<RcsCapabilityCheckAsyncResult>(givenRequest)!);
        AssertResult(JsonSerializer.Deserialize<RcsCapabilityCheckAsyncResult>(givenRequest)!);
    }
}