using Infobip.Api.Client.Api;
using Infobip.Api.Client.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace ApiClient.Tests.Api;

[TestClass]
public class CallRoutingApiTest : ApiTest
{
    protected const string CALL_ROUTING_ROUTES = "/callrouting/1/routes";
    protected const string CALL_ROUTING_ROUTE = "/callrouting/1/routes/{routeId}";

    [TestMethod]
    public void ShouldGetCallRoutes()
    {
        var expectedId = "f8fc8aca-786d-4943-9af2-e7ec01b5e80d";
        var expectedName = "SIP endpoint route";
        var expectedUsername = "41793026834";
        var expectedSipTrunkId = "string";
        var expectedCustomHeadersString = "string";
        var expectedValueType = "SIP";
        var expectedConnectTimeout = 30;
        var expectedRecordingType = CallRoutingRecordingType.Audio;
        var expectedRecordingCompositionEnabled = true;
        var expectedCustomDataString = "string";
        var expectedFilePrefix = "string";
        var expectedType = "ENDPOINT";

        var expectedSecondId = "f8fc8aca-786d-4943-9af2-e7ec01b5e80d";
        var expectedSecondName = "Phone endpoint route";
        var expectedSecondPhoneNumber = "41793026834";
        var expectedSecondValueType = "PHONE";
        var expectedSecondConnectTimeout = 30;
        var expectedSecondRecordingType = CallRoutingRecordingType.Audio;
        var expectedSecondRecordingCompositionEnabled = true;
        var expectedSecondCustomDataString = "string";
        var expectedSecondFilePrefix = "string";
        var expectedSecondType = "ENDPOINT";

        var expectedPage = 0;
        var expectedSize = 20;
        var expectedTotalPages = 1;
        var expectedTotalResults = 2;

        var expectedResponse = $@"
            {{
              ""results"": [
                {{
                  ""id"": ""{expectedId}"",
                  ""name"": ""{expectedName}"",
                  ""destinations"": [
                    {{
                      ""value"": {{
                        ""username"": ""{expectedUsername}"",
                        ""sipTrunkId"": ""{expectedSipTrunkId}"",
                        ""customHeaders"": {{
                          ""string"": ""{expectedCustomHeadersString}""
                        }},
                        ""type"": ""{expectedValueType}""
                      }},
                      ""connectTimeout"": {expectedConnectTimeout},
                      ""recording"": {{
                        ""recordingType"": ""{expectedRecordingType}"",
                        ""recordingComposition"": {{
                          ""enabled"": {expectedRecordingCompositionEnabled.ToString().ToLower()}
                        }},
                        ""customData"": {{
                          ""string"": ""{expectedCustomDataString}""
                        }},
                        ""filePrefix"": ""{expectedFilePrefix}""
                      }},
                      ""type"": ""{expectedType}""
                    }}
                  ]
                }},
                {{
                  ""id"": ""{expectedSecondId}"",
                  ""name"": ""{expectedSecondName}"",
                  ""destinations"": [
                    {{
                      ""value"": {{
                        ""phoneNumber"": ""{expectedSecondPhoneNumber}"",
                        ""type"": ""{expectedSecondValueType}""
                      }},
                      ""connectTimeout"": {expectedSecondConnectTimeout},
                      ""recording"": {{
                        ""recordingType"": ""{expectedSecondRecordingType}"",
                        ""recordingComposition"": {{
                          ""enabled"": {expectedSecondRecordingCompositionEnabled.ToString().ToLower()}
                        }},
                        ""customData"": {{
                          ""string"": ""{expectedSecondCustomDataString}""
                        }},
                        ""filePrefix"": ""{expectedSecondFilePrefix}""
                      }},
                      ""type"": ""{expectedSecondType}""
                    }}
                  ]
                }}
              ],
              ""paging"": {{
                ""page"": {expectedPage},
                ""size"": {expectedSize},
                ""totalPages"": {expectedTotalPages},
                ""totalResults"": {expectedTotalResults}
              }}
            }}";

        var givenPage = 0;
        var givenSize = 10;
        var givenQueryParameters = new Dictionary<string, string>
            { { "page", givenPage.ToString() }, { "size", givenSize.ToString() } };

        SetUpGetRequest(CALL_ROUTING_ROUTES, 200, expectedResponse, givenQueryParameters);

        var callRoutingApi = new CallRoutingApi(configuration);

        void AssertCallRoutingRouteResponsePage(CallRoutingRouteResponsePage callRoutingRouteResponsePage)
        {
            Assert.IsNotNull(callRoutingRouteResponsePage);
            Assert.IsNotNull(callRoutingRouteResponsePage.Results);
            Assert.AreEqual(2, callRoutingRouteResponsePage.Results.Count);

            var firstResult = callRoutingRouteResponsePage.Results[0];
            Assert.IsNotNull(firstResult);
            Assert.AreEqual(expectedId, firstResult.Id);
            Assert.AreEqual(expectedName, firstResult.Name);

            var firstDestination = (CallRoutingEndpointDestination)firstResult.Destinations[0];
            Assert.IsNotNull(firstDestination);
            var firstValue = (CallRoutingSipEndpoint)firstDestination.Value;
            Assert.IsNotNull(firstValue);
            Assert.AreEqual(expectedUsername, firstValue.Username);
            Assert.AreEqual(expectedSipTrunkId, firstValue.SipTrunkId);
            Assert.AreEqual(expectedCustomHeadersString, firstValue.CustomHeaders["string"]);

            Assert.AreEqual(expectedConnectTimeout, firstDestination.ConnectTimeout);
            Assert.AreEqual(expectedRecordingType, firstDestination.Recording.RecordingType);
            Assert.AreEqual(expectedRecordingCompositionEnabled,
                firstDestination.Recording.RecordingComposition.Enabled);
            Assert.AreEqual(expectedCustomDataString, firstDestination.Recording.CustomData["string"]);
            Assert.AreEqual(expectedFilePrefix, firstDestination.Recording.FilePrefix);

            var secondResult = callRoutingRouteResponsePage.Results[1];
            Assert.IsNotNull(secondResult);
            Assert.AreEqual(expectedSecondId, secondResult.Id);
            Assert.AreEqual(expectedSecondName, secondResult.Name);

            var secondDestination = (CallRoutingEndpointDestination)secondResult.Destinations[0];
            Assert.IsNotNull(secondDestination);
            var secondValue = (CallRoutingPhoneEndpoint)secondDestination.Value;
            Assert.IsNotNull(secondValue);
            Assert.AreEqual(expectedSecondPhoneNumber, secondValue.PhoneNumber);

            Assert.AreEqual(expectedSecondConnectTimeout, secondDestination.ConnectTimeout);
            Assert.AreEqual(expectedSecondRecordingType, secondDestination.Recording.RecordingType);
            Assert.AreEqual(expectedSecondRecordingCompositionEnabled,
                secondDestination.Recording.RecordingComposition.Enabled);
            Assert.AreEqual(expectedSecondCustomDataString, secondDestination.Recording.CustomData["string"]);
            Assert.AreEqual(expectedSecondFilePrefix, secondDestination.Recording.FilePrefix);

            Assert.IsNotNull(callRoutingRouteResponsePage.Paging);
            Assert.AreEqual(expectedPage, callRoutingRouteResponsePage.Paging.Page);
            Assert.AreEqual(expectedSize, callRoutingRouteResponsePage.Paging.Size);
            Assert.AreEqual(expectedTotalPages, callRoutingRouteResponsePage.Paging.TotalPages);
            Assert.AreEqual(expectedTotalResults, callRoutingRouteResponsePage.Paging.TotalResults);
        }

        AssertResponse(callRoutingApi.GetCallRoutes(givenPage, givenSize), AssertCallRoutingRouteResponsePage);
        AssertResponse(callRoutingApi.GetCallRoutesAsync(givenPage, givenSize).Result,
            AssertCallRoutingRouteResponsePage);
        AssertResponseWithHttpInfo(callRoutingApi.GetCallRoutesWithHttpInfo(givenPage, givenSize),
            AssertCallRoutingRouteResponsePage, 200);
        AssertResponseWithHttpInfo(callRoutingApi.GetCallRoutesWithHttpInfoAsync(givenPage, givenSize).Result,
            AssertCallRoutingRouteResponsePage, 200);
    }

    [TestMethod]
    public void ShouldCreateCallRoute()
    {
        var expectedId = "f8fc8aca-786d-4943-9af2-e7ec01b5e80d";
        var expectedName = "SIP endpoint route";
        var expectedUsername = "41793026834";
        var expectedSipTrunkId = "string";
        var expectedCustomHeadersString = "string";
        var expectedValueType = "SIP";
        var expectedConnectTimeout = 30;
        var expectedRecordingType = CallRoutingRecordingType.Audio;
        var expectedRecordingCompositionEnabled = true;
        var expectedCustomDataString = "string";
        var expectedFilePrefix = "string";
        var expectedType = "ENDPOINT";

        var expectedResponse = $@"
            {{
              ""id"": ""{expectedId}"",
              ""name"": ""{expectedName}"",
              ""destinations"": [
                {{
                  ""value"": {{
                    ""username"": ""{expectedUsername}"",
                    ""sipTrunkId"": ""{expectedSipTrunkId}"",
                    ""customHeaders"": {{
                      ""string"": ""{expectedCustomHeadersString}""
                    }},
                    ""type"": ""{expectedValueType}""
                  }},
                  ""connectTimeout"": {expectedConnectTimeout},
                  ""recording"": {{
                    ""recordingType"": ""{expectedRecordingType}"",
                    ""recordingComposition"": {{
                      ""enabled"": {expectedRecordingCompositionEnabled.ToString().ToLower()}
                    }},
                    ""customData"": {{
                      ""string"": ""{expectedCustomDataString}""
                    }},
                    ""filePrefix"": ""{expectedFilePrefix}""
                  }},
                  ""type"": ""{expectedType}""
                }}
              ]
            }}";

        var givenName = "Route with a SIP endpoint destination";
        var givenUsername = "41793026834";
        var givenSipTrunkId = "60d345fd3a799ec";
        var givenHeaderName = "header value";
        var givenValueType = "SIP";
        var givenConnectionTimeout = 30;
        var givenRecordingType = CallRoutingRecordingType.Audio;
        var givenRecordingCompositionEnabled = true;
        var givenCustomDataKey1 = "value1";
        var givenFilePrefix = "rec";
        var givenType = "ENDPOINT";

        var givenRequest = $@"
            {{
              ""name"": ""{givenName}"",
              ""destinations"": [
                {{
                  ""value"": {{
                    ""username"": ""{givenUsername}"",
                    ""sipTrunkId"": ""{givenSipTrunkId}"",
                    ""customHeaders"": {{
                      ""Header-Name"": ""{givenHeaderName}""
                    }},
                    ""type"": ""{givenValueType}""
                  }},
                  ""connectTimeout"": {givenConnectionTimeout},
                  ""recording"": {{
                    ""recordingType"": ""{givenRecordingType}"",
                    ""recordingComposition"": {{
                      ""enabled"": {givenRecordingCompositionEnabled.ToString().ToLower()}
                    }},
                    ""customData"": {{
                      ""key1"": ""{givenCustomDataKey1}""
                    }},
                    ""filePrefix"": ""{givenFilePrefix}""
                  }},
                  ""type"": ""{givenType}""
                }}
              ]
            }}";

        SetUpPostRequest(CALL_ROUTING_ROUTES, 201, givenRequest, expectedResponse);

        var callRoutingApi = new CallRoutingApi(configuration);

        var callroutingRouteRequest = new CallRoutingRouteRequest(
            givenName,
            destinations: new List<CallRoutingDestination>
            {
                new CallRoutingEndpointDestination(
                    new CallRoutingSipEndpoint(
                        givenUsername,
                        givenSipTrunkId,
                        new Dictionary<string, string> { { "Header-Name", givenHeaderName } }
                    ),
                    givenConnectionTimeout,
                    new CallRoutingRecording(
                        givenRecordingType,
                        new CallRoutingRecordingComposition(givenRecordingCompositionEnabled),
                        new Dictionary<string, string> { { "key1", givenCustomDataKey1 } },
                        givenFilePrefix
                    )
                )
            }
        );

        void AssertCallRoutingRouteResponsePage(CallRoutingRouteResponse callRoutingRouteResponse)
        {
            Assert.IsNotNull(callRoutingRouteResponse);
            Assert.AreEqual(expectedId, callRoutingRouteResponse.Id);
            Assert.AreEqual(expectedName, callRoutingRouteResponse.Name);
            var destination = (CallRoutingEndpointDestination)callRoutingRouteResponse.Destinations[0];
            Assert.IsNotNull(destination);
            var value = (CallRoutingSipEndpoint)destination.Value;
            Assert.IsNotNull(value);
            Assert.AreEqual(expectedUsername, value.Username);
            Assert.AreEqual(expectedSipTrunkId, value.SipTrunkId);
            Assert.AreEqual(expectedCustomHeadersString, value.CustomHeaders["string"]);

            Assert.AreEqual(expectedConnectTimeout, destination.ConnectTimeout);
            Assert.AreEqual(expectedRecordingType, destination.Recording.RecordingType);
            Assert.AreEqual(expectedRecordingCompositionEnabled, destination.Recording.RecordingComposition.Enabled);
            Assert.AreEqual(expectedCustomDataString, destination.Recording.CustomData["string"]);
            Assert.AreEqual(expectedFilePrefix, destination.Recording.FilePrefix);
        }

        AssertResponse(callRoutingApi.CreateCallRoute(callroutingRouteRequest), AssertCallRoutingRouteResponsePage);
        AssertResponse(callRoutingApi.CreateCallRouteAsync(callroutingRouteRequest).Result,
            AssertCallRoutingRouteResponsePage);
        AssertResponseWithHttpInfo(callRoutingApi.CreateCallRouteWithHttpInfo(callroutingRouteRequest),
            AssertCallRoutingRouteResponsePage, 201);
        AssertResponseWithHttpInfo(callRoutingApi.CreateCallRouteWithHttpInfoAsync(callroutingRouteRequest).Result,
            AssertCallRoutingRouteResponsePage, 201);
    }

    [TestMethod]
    public void ShouldGetCallRoute()
    {
        var givenRouteId = "f8fc8aca-786d-4943-9af2-e7ec01b5e80d";

        var expectedName = "Sample Route Name";
        var expectedUsername = "41793026834";
        var expectedSipTrunkId = "string";
        var expectedCustomHeadersString = "string";
        var expectedValueType = "SIP";
        var expectedConnectTimeout = 30;
        var expectedRecordingType = CallRoutingRecordingType.Audio;
        var expectedRecordingCompositionEnabled = true;
        var expectedCustomDataString = "string";
        var expectedFilePrefix = "string";
        var expectedType = "ENDPOINT";

        var expectedResponse = $@"
            {{
              ""id"": ""{givenRouteId}"",
              ""name"": ""{expectedName}"",
              ""destinations"": [
                {{
                  ""value"": {{
                    ""username"": ""{expectedUsername}"",
                    ""sipTrunkId"": ""{expectedSipTrunkId}"",
                    ""customHeaders"": {{
                      ""string"": ""{expectedCustomHeadersString}""
                    }},
                    ""type"": ""{expectedValueType}""
                  }},
                  ""connectTimeout"": {expectedConnectTimeout},
                  ""recording"": {{
                    ""recordingType"": ""{expectedRecordingType}"",
                    ""recordingComposition"": {{
                      ""enabled"": {expectedRecordingCompositionEnabled.ToString().ToLower()}
                    }},
                    ""customData"": {{
                      ""string"": ""{expectedCustomDataString}""
                    }},
                    ""filePrefix"": ""{expectedFilePrefix}""
                  }},
                  ""type"": ""{expectedType}""
                }}
              ]
            }}";

        SetUpGetRequest(CALL_ROUTING_ROUTE.Replace("{routeId}", givenRouteId), 200, expectedResponse);

        var callRoutingApi = new CallRoutingApi(configuration);

        void AssertCallRoutingRouteResponsePage(CallRoutingRouteResponse callRoutingRouteResponse)
        {
            Assert.IsNotNull(callRoutingRouteResponse);
            Assert.AreEqual(givenRouteId, callRoutingRouteResponse.Id);
            Assert.AreEqual(expectedName, callRoutingRouteResponse.Name);
            var destination = (CallRoutingEndpointDestination)callRoutingRouteResponse.Destinations[0];
            Assert.IsNotNull(destination);
            var value = (CallRoutingSipEndpoint)destination.Value;
            Assert.IsNotNull(value);
            Assert.AreEqual(expectedUsername, value.Username);
            Assert.AreEqual(expectedSipTrunkId, value.SipTrunkId);
            Assert.AreEqual(expectedCustomHeadersString, value.CustomHeaders["string"]);

            Assert.AreEqual(expectedConnectTimeout, destination.ConnectTimeout);
            Assert.AreEqual(expectedRecordingType, destination.Recording.RecordingType);
            Assert.AreEqual(expectedRecordingCompositionEnabled, destination.Recording.RecordingComposition.Enabled);
            Assert.AreEqual(expectedCustomDataString, destination.Recording.CustomData["string"]);
            Assert.AreEqual(expectedFilePrefix, destination.Recording.FilePrefix);
        }

        AssertResponse(callRoutingApi.GetCallRoute(givenRouteId), AssertCallRoutingRouteResponsePage);
        AssertResponse(callRoutingApi.GetCallRouteAsync(givenRouteId).Result, AssertCallRoutingRouteResponsePage);
        AssertResponseWithHttpInfo(callRoutingApi.GetCallRouteWithHttpInfo(givenRouteId),
            AssertCallRoutingRouteResponsePage, 200);
        AssertResponseWithHttpInfo(callRoutingApi.GetCallRouteWithHttpInfoAsync(givenRouteId).Result,
            AssertCallRoutingRouteResponsePage, 200);
    }

    [TestMethod]
    public void ShouldUpdateCallRoutes()
    {
        var givenRouteId = "56b3e3ea-e91f-44ed-9d57-c7f05cd358ba";

        var expectedName = "Sample Route Name";
        var expectedUsername = "41793026834";
        var expectedSipTrunkId = "string";
        var expectedCustomHeadersString = "string";
        var expectedValueType = "SIP";
        var expectedConnectTimeout = 30;
        var expectedRecordingType = CallRoutingRecordingType.Audio;
        var expectedRecordingCompositionEnabled = true;
        var expectedCustomDataString = "string";
        var expectedFilePrefix = "string";
        var expectedType = "ENDPOINT";

        var expectedResponse = $@"
            {{
              ""id"": ""{givenRouteId}"",
              ""name"": ""{expectedName}"",
              ""destinations"": [
                {{
                  ""value"": {{
                    ""username"": ""{expectedUsername}"",
                    ""sipTrunkId"": ""{expectedSipTrunkId}"",
                    ""customHeaders"": {{
                      ""string"": ""{expectedCustomHeadersString}""
                    }},
                    ""type"": ""{expectedValueType}""
                  }},
                  ""connectTimeout"": {expectedConnectTimeout},
                  ""recording"": {{
                    ""recordingType"": ""{expectedRecordingType}"",
                    ""recordingComposition"": {{
                      ""enabled"": {expectedRecordingCompositionEnabled.ToString().ToLower()}
                    }},
                    ""customData"": {{
                      ""string"": ""{expectedCustomDataString}""
                    }},
                    ""filePrefix"": ""{expectedFilePrefix}""
                  }},
                  ""type"": ""{expectedType}""
                }}
              ]
            }}";

        var givenName = "Route with a SIP endpoint destination";
        var givenUsername = "41793026834";
        var givenSipTrunkId = "60d345fd3a799ec";
        var givenHeaderName = "header value";
        var givenValueType = "SIP";
        var givenConnectionTimeout = 30;
        var givenRecordingType = CallRoutingRecordingType.Audio;
        var givenRecordingCompositionEnabled = true;
        var givenCustomDataKey1 = "value1";
        var givenFilePrefix = "rec";
        var givenType = "ENDPOINT";

        var givenRequest = $@"
            {{
              ""name"": ""{givenName}"",
              ""destinations"": [
                {{
                  ""value"": {{
                    ""username"": ""{givenUsername}"",
                    ""sipTrunkId"": ""{givenSipTrunkId}"",
                    ""customHeaders"": {{
                      ""Header-Name"": ""{givenHeaderName}""
                    }},
                    ""type"": ""{givenValueType}""
                  }},
                  ""connectTimeout"": {givenConnectionTimeout},
                  ""recording"": {{
                    ""recordingType"": ""{givenRecordingType}"",
                    ""recordingComposition"": {{
                      ""enabled"": {givenRecordingCompositionEnabled.ToString().ToLower()}
                    }},
                    ""customData"": {{
                      ""key1"": ""{givenCustomDataKey1}""
                    }},
                    ""filePrefix"": ""{givenFilePrefix}""
                  }},
                  ""type"": ""{givenType}""
                }}
              ]
            }}";

        SetUpPutRequest(CALL_ROUTING_ROUTE.Replace("{routeId}", givenRouteId), 200, givenRequest, expectedResponse);

        var callRoutingApi = new CallRoutingApi(configuration);

        var callroutingRouteRequest = new CallRoutingRouteRequest(
            givenName,
            destinations: new List<CallRoutingDestination>
            {
                new CallRoutingEndpointDestination(
                    new CallRoutingSipEndpoint(
                        givenUsername,
                        givenSipTrunkId,
                        new Dictionary<string, string> { { "Header-Name", givenHeaderName } }
                    ),
                    givenConnectionTimeout,
                    new CallRoutingRecording(
                        givenRecordingType,
                        new CallRoutingRecordingComposition(givenRecordingCompositionEnabled),
                        new Dictionary<string, string> { { "key1", givenCustomDataKey1 } },
                        givenFilePrefix
                    )
                )
            }
        );

        void AssertCallRoutingRouteResponsePage(CallRoutingRouteResponse callRoutingRouteResponse)
        {
            Assert.IsNotNull(callRoutingRouteResponse);
            Assert.AreEqual(givenRouteId, callRoutingRouteResponse.Id);
            Assert.AreEqual(expectedName, callRoutingRouteResponse.Name);
            var destination = (CallRoutingEndpointDestination)callRoutingRouteResponse.Destinations[0];
            Assert.IsNotNull(destination);
            var value = (CallRoutingSipEndpoint)destination.Value;
            Assert.IsNotNull(value);
            Assert.AreEqual(expectedUsername, value.Username);
            Assert.AreEqual(expectedSipTrunkId, value.SipTrunkId);
            Assert.AreEqual(expectedCustomHeadersString, value.CustomHeaders["string"]);

            Assert.AreEqual(expectedConnectTimeout, destination.ConnectTimeout);
            Assert.AreEqual(expectedRecordingType, destination.Recording.RecordingType);
            Assert.AreEqual(expectedRecordingCompositionEnabled, destination.Recording.RecordingComposition.Enabled);
            Assert.AreEqual(expectedCustomDataString, destination.Recording.CustomData["string"]);
            Assert.AreEqual(expectedFilePrefix, destination.Recording.FilePrefix);
        }

        AssertResponse(callRoutingApi.UpdateCallRoute(givenRouteId, callroutingRouteRequest),
            AssertCallRoutingRouteResponsePage);
        AssertResponse(callRoutingApi.UpdateCallRouteAsync(givenRouteId, callroutingRouteRequest).Result,
            AssertCallRoutingRouteResponsePage);
        AssertResponseWithHttpInfo(callRoutingApi.UpdateCallRouteWithHttpInfo(givenRouteId, callroutingRouteRequest),
            AssertCallRoutingRouteResponsePage, 200);
        AssertResponseWithHttpInfo(
            callRoutingApi.UpdateCallRouteWithHttpInfoAsync(givenRouteId, callroutingRouteRequest).Result,
            AssertCallRoutingRouteResponsePage, 200);
    }

    [TestMethod]
    public void ShouldDeleteCallRoutes()
    {
        var givenRouteId = "56b3e3ea-e91f-44ed-9d57-c7f05cd358ba";

        var expectedName = "Sample Route Name";
        var expectedUsername = "41793026834";
        var expectedSipTrunkId = "string";
        var expectedCustomHeadersString = "string";
        var expectedValueType = "SIP";
        var expectedConnectTimeout = 30;
        var expectedRecordingType = CallRoutingRecordingType.Audio;
        var expectedRecordingCompositionEnabled = true;
        var expectedCustomDataString = "string";
        var expectedFilePrefix = "string";
        var expectedType = "ENDPOINT";

        var exectedResponse = $@"
            {{
              ""id"": ""{givenRouteId}"",
              ""name"": ""{expectedName}"",
              ""destinations"": [
                {{
                  ""value"": {{
                    ""username"": ""{expectedUsername}"",
                    ""sipTrunkId"": ""{expectedSipTrunkId}"",
                    ""customHeaders"": {{
                      ""string"": ""{expectedCustomHeadersString}""
                    }},
                    ""type"": ""{expectedValueType}""
                  }},
                  ""connectTimeout"": {expectedConnectTimeout},
                  ""recording"": {{
                    ""recordingType"": ""{expectedRecordingType}"",
                    ""recordingComposition"": {{
                      ""enabled"": {expectedRecordingCompositionEnabled.ToString().ToLower()}
                    }},
                    ""customData"": {{
                      ""string"": ""{expectedCustomDataString}""
                    }},
                    ""filePrefix"": ""{expectedFilePrefix}""
                  }},
                  ""type"": ""{expectedType}""
                }}
              ]
            }}";

        SetUpDeleteRequest(CALL_ROUTING_ROUTE.Replace("{routeId}", givenRouteId), 200,
            expectedResponse: exectedResponse, givenParameters: new Dictionary<string, string>());

        var callRoutingApi = new CallRoutingApi(configuration);

        void AssertCallRoutingRouteResponsePage(CallRoutingRouteResponse callRoutingRouteResponse)
        {
            Assert.IsNotNull(callRoutingRouteResponse);
            Assert.AreEqual(givenRouteId, callRoutingRouteResponse.Id);
            Assert.AreEqual(expectedName, callRoutingRouteResponse.Name);
            var destination = (CallRoutingEndpointDestination)callRoutingRouteResponse.Destinations[0];
            Assert.IsNotNull(destination);
            var value = (CallRoutingSipEndpoint)destination.Value;
            Assert.IsNotNull(value);
            Assert.AreEqual(expectedUsername, value.Username);
            Assert.AreEqual(expectedSipTrunkId, value.SipTrunkId);
            Assert.AreEqual(expectedCustomHeadersString, value.CustomHeaders["string"]);

            Assert.AreEqual(expectedConnectTimeout, destination.ConnectTimeout);
            Assert.AreEqual(expectedRecordingType, destination.Recording.RecordingType);
            Assert.AreEqual(expectedRecordingCompositionEnabled, destination.Recording.RecordingComposition.Enabled);
            Assert.AreEqual(expectedCustomDataString, destination.Recording.CustomData["string"]);
            Assert.AreEqual(expectedFilePrefix, destination.Recording.FilePrefix);
        }

        AssertResponse(callRoutingApi.DeleteCallRoute(givenRouteId), AssertCallRoutingRouteResponsePage);
        AssertResponse(callRoutingApi.DeleteCallRouteAsync(givenRouteId).Result, AssertCallRoutingRouteResponsePage);
        AssertResponseWithHttpInfo(callRoutingApi.DeleteCallRouteWithHttpInfo(givenRouteId),
            AssertCallRoutingRouteResponsePage, 200);
        AssertResponseWithHttpInfo(callRoutingApi.DeleteCallRouteWithHttpInfoAsync(givenRouteId).Result,
            AssertCallRoutingRouteResponsePage, 200);
    }

    [TestMethod]
    public void ShouldUrlDestinationWebhook()
    {
        var expectedUsername = "41793026834";
        var expectedSipTrunkId = "60d345fd3a799ec";
        var expectedValueType = "SIP";
        var expectedConnectTimeout = 30;
        var expectedRecordingType = CallRoutingRecordingType.Audio;
        var expectedType = "ENDPOINT";

        var expectedResponse = $@"
            {{
              ""value"": {{
                ""username"": ""{expectedUsername}"",
                ""sipTrunkId"": ""{expectedSipTrunkId}"",
                ""type"": ""{expectedValueType}""
              }},
              ""connectTimeout"": {expectedConnectTimeout},
              ""recording"": {{
                ""recordingType"": ""{expectedRecordingType}""
              }},
              ""type"": ""{expectedType}""
            }}";

        var callRoutingEndpointDestinationResponse =
            JsonConvert.DeserializeObject<CallRoutingEndpointDestinationResponse>(expectedResponse);
        AssertCallRoutingEndpointDestinationResponse(callRoutingEndpointDestinationResponse!);

        var callRoutingEndpointDestinationResponseSystemTextJson =
            JsonSerializer.Deserialize<CallRoutingEndpointDestinationResponse>(expectedResponse);
        AssertCallRoutingEndpointDestinationResponse(callRoutingEndpointDestinationResponseSystemTextJson!);

        var givenApplicationId = "CALL_ROUTING";
        var givenRouteId = "f8fc8aca-786d-4943-9af2-e7ec01b5e80d";
        var givenCallId = "d8d84155-3831-43fb-91c9-bb897149a79d";
        var givenFrom = "44790123456";
        var givenTo = "44790123456";
        var givenStartTime = "2024-01-01T10:00:00Z";

        var givenRequest = $@"
            {{
              ""applicationId"": ""{givenApplicationId}"",
              ""routeId"": ""{givenRouteId}"",
              ""callId"": ""{givenCallId}"",
              ""from"": ""{givenFrom}"",
              ""to"": ""{givenTo}"",
              ""startTime"": ""{givenStartTime}""
            }}";

        var callRoutingUrlDestinationHttpRequest =
            JsonConvert.DeserializeObject<CallRoutingUrlDestinationHttpRequest>(givenRequest);
        AssertCallRoutingUrlDestinationHttpRequest(callRoutingUrlDestinationHttpRequest!);

        var callRoutingUrlDestinationHttpRequestSystemTextJson =
            JsonSerializer.Deserialize<CallRoutingUrlDestinationHttpRequest>(givenRequest);
        AssertCallRoutingUrlDestinationHttpRequest(callRoutingUrlDestinationHttpRequestSystemTextJson!);

        void AssertCallRoutingEndpointDestinationResponse(
            CallRoutingEndpointDestinationResponse callRoutingEndpointDestinationResponse)
        {
            Assert.IsNotNull(callRoutingEndpointDestinationResponse);

            var callRoutingSipEndpoint = (CallRoutingSipEndpoint)callRoutingEndpointDestinationResponse.Value;

            Assert.AreEqual(expectedUsername, callRoutingSipEndpoint.Username);
            Assert.AreEqual(expectedSipTrunkId, callRoutingSipEndpoint.SipTrunkId);

            Assert.AreEqual(expectedConnectTimeout, callRoutingEndpointDestinationResponse.ConnectTimeout);
            Assert.AreEqual(expectedRecordingType, callRoutingEndpointDestinationResponse.Recording.RecordingType);
        }

        void AssertCallRoutingUrlDestinationHttpRequest(
            CallRoutingUrlDestinationHttpRequest callRoutingUrlDestinationHttpRequest)
        {
            Assert.IsNotNull(callRoutingUrlDestinationHttpRequest);
            Assert.AreEqual(givenApplicationId, callRoutingUrlDestinationHttpRequest.ApplicationId);
            Assert.AreEqual(givenRouteId, callRoutingUrlDestinationHttpRequest.RouteId);
            Assert.AreEqual(givenCallId, callRoutingUrlDestinationHttpRequest.CallId);
            Assert.AreEqual(givenFrom, callRoutingUrlDestinationHttpRequest.From);
            Assert.AreEqual(givenTo, callRoutingUrlDestinationHttpRequest.To);
            Assert.AreEqual(DateTimeOffset.Parse(givenStartTime), callRoutingUrlDestinationHttpRequest.StartTime);
        }
    }
}