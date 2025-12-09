using Infobip.Api.Client.Api;
using Infobip.Api.Client.Model;

namespace ApiClient.Tests.Api;

[TestClass]
public class FlowApiTest : ApiTest
{
    protected const string FLOW_ADD_PARTICIPANTS_ENDPOINT = "/moments/1/flows/{campaignId}/participants";
    protected const string FLOW_GET_PARTICIPANTS_REPORT_ENDPOINT = "/moments/1/flows/{campaignId}/participants/report";
    protected const string FLOW_DELETE_PARTICIPANTS_ENDPOINT = "/communication/1/flows/{campaignId}/participants";

    [TestMethod]
    public void ShouldAddParticipantsToFlow()
    {
        var expectedOperationId = "03f2d474-0508-46bf-9f3d-d8e2c28adaea";

        var expectedResponse = $@"
            {{
              ""operationId"": ""{expectedOperationId}""
            }}";

        var givenIdentifier = "370329180020364";
        var givenType = FlowPersonUniqueFieldType.Facebook;
        var givenSecondIdentifier = "test@example.com";
        var givenSecondType = FlowPersonUniqueFieldType.Email;
        var givenSecondOrderNumber = 1167873391;
        var givenThirdIdentifier = "test2@example.com";
        var givenThirdType = FlowPersonUniqueFieldType.Email;
        var givenThirdOrderNumber = 1595299041;
        var givenThirdExternalId = "optional_external_person_id";
        var givenThirdContractExpiry = "2023-04-01";
        var givenThirdCompany = "Infobip";
        var givenThirdAddress = "test@example.com";
        var givenNotifyUrl = "https://mydomain/callback";
        var givenCallbackData = "Callback Data";

        var givenRequest = $@"
            {{
              ""participants"": [
                {{
                  ""identifyBy"": {{
                    ""identifier"": ""{givenIdentifier}"",
                    ""type"": ""{givenType}""
                  }}
                }},
                {{
                  ""identifyBy"": {{
                    ""identifier"": ""{givenSecondIdentifier}"",
                    ""type"": ""{givenSecondType}""
                  }},
                  ""variables"": {{
                    ""orderNumber"": {givenSecondOrderNumber}
                  }}
                }},
                {{
                  ""identifyBy"": {{
                    ""identifier"": ""{givenThirdIdentifier}"",
                    ""type"": ""{givenThirdType}""
                  }},
                  ""variables"": {{
                    ""orderNumber"": {givenThirdOrderNumber}
                  }},
                  ""person"": {{
                    ""externalId"": ""{givenThirdExternalId}"",
                    ""customAttributes"": {{
                      ""Contract Expiry"": ""{givenThirdContractExpiry}"",
                      ""Company"": ""{givenThirdCompany}""
                    }},
                    ""contactInformation"": {{
                      ""email"": [
                        {{
                          ""address"": ""{givenThirdAddress}""
                        }}
                      ]
                    }}
                  }}
                }}
              ],
              ""notifyUrl"": ""{givenNotifyUrl}"",
              ""callbackData"": ""{givenCallbackData}""
            }}";

        var givenCampaignId = 200000000000001;

        SetUpPostRequest(FLOW_ADD_PARTICIPANTS_ENDPOINT.Replace("{campaignId}", givenCampaignId.ToString()), 200,
            givenRequest, expectedResponse);

        var flowApi = new FlowApi(Configuration);

        var addFlowParticipantsRequest = new FlowAddFlowParticipantsRequest(
            new List<FlowParticipant>
            {
                new(
                    new FlowPersonUniqueField(
                        givenIdentifier,
                        givenType
                    )
                ),
                new(
                    new FlowPersonUniqueField(
                        givenSecondIdentifier,
                        givenSecondType
                    ),
                    new Dictionary<string, object>
                    {
                        { "orderNumber", givenSecondOrderNumber }
                    }
                ),
                new(
                    new FlowPersonUniqueField(
                        givenThirdIdentifier,
                        givenThirdType
                    ),
                    new Dictionary<string, object>
                    {
                        { "orderNumber", givenThirdOrderNumber }
                    },
                    new FlowPerson(
                        externalId: givenThirdExternalId,
                        customAttributes: new Dictionary<string, object>
                        {
                            { "Contract Expiry", givenThirdContractExpiry },
                            { "Company", givenThirdCompany }
                        },
                        contactInformation: new FlowPersonContacts(
                            email: new List<FlowEmailContact>
                            {
                                new(
                                    givenThirdAddress
                                )
                            }
                        )
                    )
                )
            },
            givenNotifyUrl,
            givenCallbackData
        );

        void AssertFlowAddFlowParticipantsResponse(FlowAddFlowParticipantsResponse flowAddFlowParticipantsResponse)
        {
            Assert.IsNotNull(flowAddFlowParticipantsResponse);
            Assert.AreEqual(expectedOperationId, flowAddFlowParticipantsResponse.OperationId);
        }

        AssertResponse(flowApi.AddFlowParticipants(givenCampaignId, addFlowParticipantsRequest),
            AssertFlowAddFlowParticipantsResponse);
        AssertResponse(flowApi.AddFlowParticipantsAsync(givenCampaignId, addFlowParticipantsRequest).Result,
            AssertFlowAddFlowParticipantsResponse);
        AssertResponseWithHttpInfo(flowApi.AddFlowParticipantsWithHttpInfo(givenCampaignId, addFlowParticipantsRequest),
            AssertFlowAddFlowParticipantsResponse, 200);
        AssertResponseWithHttpInfo(
            flowApi.AddFlowParticipantsWithHttpInfoAsync(givenCampaignId, addFlowParticipantsRequest).Result,
            AssertFlowAddFlowParticipantsResponse, 200);
    }

    [TestMethod]
    public void ShouldGetAReportOnParticipantsAddedToFlow()
    {
        var expectedOperationId = "03f2d474-0508-46bf-9f3d-d8e2c28adaea";
        var expectedCampaignId = 200000000000001;
        var expectedCallbackData = "Callback Data";
        var expectedIdentifier = "test@example.com";
        var expectedType = FlowPersonUniqueFieldType.Email;
        var expectedStatus = FlowAddFlowParticipantStatus.Accepted;
        var expectedSecondIdentifier = "test2@example.com";
        var expectedSecondType = FlowPersonUniqueFieldType.Email;
        var expectedSecondStatus = FlowAddFlowParticipantStatus.Rejected;
        var expectedSecondErrorReason = FlowErrorStatusReason.InvalidContact;

        var expectedResponse = $@"
            {{
              ""operationId"": ""{expectedOperationId}"",
              ""campaignId"": {expectedCampaignId},
              ""callbackData"": ""{expectedCallbackData}"",
              ""participants"": [
                {{
                  ""identifyBy"": {{
                    ""identifier"": ""{expectedIdentifier}"",
                    ""type"": ""{expectedType}""
                  }},
                  ""status"": ""{expectedStatus}""
                }},
                {{
                  ""identifyBy"": {{
                    ""identifier"": ""{expectedSecondIdentifier}"",
                    ""type"": ""{expectedSecondType}""
                  }},
                  ""status"": ""{expectedSecondStatus}"",
                  ""errorReason"": ""{expectedSecondErrorReason}""
                }}
              ]
            }}";

        var givenQueryParameters = new Dictionary<string, string> { { "operationId", expectedOperationId } };

        SetUpGetRequest(FLOW_GET_PARTICIPANTS_REPORT_ENDPOINT.Replace("{campaignId}", expectedCampaignId.ToString()),
            200, expectedResponse, givenQueryParameters);

        var flowApi = new FlowApi(Configuration);

        void AssertFlowParticipantsReportResponse(FlowParticipantsReportResponse flowParticipantsReportResponse)
        {
            Assert.IsNotNull(flowParticipantsReportResponse);
            Assert.AreEqual(expectedOperationId, flowParticipantsReportResponse.OperationId);
            Assert.AreEqual(expectedCampaignId, flowParticipantsReportResponse.CampaignId);
            Assert.AreEqual(expectedCallbackData, flowParticipantsReportResponse.CallbackData);

            var participants = flowParticipantsReportResponse.Participants;
            Assert.IsNotNull(participants);
            Assert.AreEqual(2, participants.Count);

            Assert.AreEqual(expectedIdentifier, participants[0].IdentifyBy.Identifier);
            Assert.AreEqual(expectedType, participants[0].IdentifyBy.Type);
            Assert.AreEqual(expectedStatus, participants[0].Status);

            Assert.AreEqual(expectedSecondIdentifier, participants[1].IdentifyBy.Identifier);
            Assert.AreEqual(expectedSecondType, participants[1].IdentifyBy.Type);
            Assert.AreEqual(expectedSecondStatus, participants[1].Status);
            Assert.AreEqual(expectedSecondErrorReason, participants[1].ErrorReason);
        }

        AssertResponse(flowApi.GetFlowParticipantsAddedReport(expectedCampaignId, expectedOperationId),
            AssertFlowParticipantsReportResponse);
        AssertResponse(flowApi.GetFlowParticipantsAddedReportAsync(expectedCampaignId, expectedOperationId).Result,
            AssertFlowParticipantsReportResponse);
        AssertResponseWithHttpInfo(
            flowApi.GetFlowParticipantsAddedReportWithHttpInfo(expectedCampaignId, expectedOperationId),
            AssertFlowParticipantsReportResponse, 200);
        AssertResponseWithHttpInfo(
            flowApi.GetFlowParticipantsAddedReportWithHttpInfoAsync(expectedCampaignId, expectedOperationId).Result,
            AssertFlowParticipantsReportResponse, 200);
    }

    [TestMethod]
    public void ShouldRemovePersonFromFlow()
    {
        var givenCampaignId = 10159347;
        var givenPhone = "19123456789";
        var givenEmail = "janewilliams@example.com";
        var givenExternalId = "8edb24b5-0319-48cd-a1d9-1e8bc5d577ab";

        var givenQueryParameters = new Dictionary<string, string>
        {
            { "phone", givenPhone },
            { "email", givenEmail },
            { "externalId", givenExternalId }
        };

        SetUpDeleteRequest(FLOW_DELETE_PARTICIPANTS_ENDPOINT.Replace("{campaignId}", givenCampaignId.ToString()), 200,
            givenParameters: givenQueryParameters);

        var flowApi = new FlowApi(Configuration);

        AssertNoBodyResponseWithHttpInfo(
            flowApi.RemovePeopleFromFlowWithHttpInfo(givenCampaignId, givenPhone, givenEmail, givenExternalId), 200);
        AssertNoBodyResponseWithHttpInfo(
            flowApi.RemovePeopleFromFlowWithHttpInfoAsync(givenCampaignId, givenPhone, givenEmail, givenExternalId)
                .Result, 200);
    }
}