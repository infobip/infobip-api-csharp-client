using System.Net;
using ApiClient.Tests.Api;
using Infobip.Api.Client;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;

namespace ApiClient.Tests;

[TestClass]
public class GeneralSetupTest : ApiTest
{
    protected const string SMS_SEND_TEXT_ADVANCED_ENDPOINT = "/sms/2/text/advanced";

    [TestMethod]
    public void UsingExampleFromDocs()
    {
        var givenRequest = @"
            {
                ""messages"": [
                {
                    ""from"": ""InfoSMS"",
                    ""destinations"": [
                        {
                            ""to"": ""41793026727""
                        }
                      ],
                    ""text"": ""This is a sample message""
                }
                ]
            }";

        var expectedResponse = @"
            {
              ""bulkId"": ""2034072219640523072"",
              ""messages"": [
                {
                  ""to"": ""41793026727"",
                  ""status"": {
                      ""groupId"": 1,
                      ""groupName"": ""PENDING"",
                      ""id"": 26,
                      ""name"": ""MESSAGE_ACCEPTED"",
                      ""description"": ""Message sent to next instance""
                  },
                  ""messageId"": ""2250be2d4219-3af1-78856-aabe-1362af1edfd2""
                }
              ]
            }";

        SetUpPostRequest(SMS_SEND_TEXT_ADVANCED_ENDPOINT, new Dictionary<string, string> { { "param1", "val1" } },
            givenRequest, expectedResponse, 200);

        var client = new RestClient(configuration!.BasePath + SMS_SEND_TEXT_ADVANCED_ENDPOINT)
        {
            UserAgent = "infobip-api-client-csharp/" + Configuration.Version,
            Timeout = -1
        };
        var request = new RestRequest(Method.POST);
        request.AddHeader("Authorization", configuration.ApiKeyWithPrefix);
        request.AddHeader("Content-Type", "application/json; charset=utf-8");
        request.AddHeader("Accept", "application/json");
        request.AddQueryParameter("param1", "val1");
        request.AddParameter("application/json", givenRequest, ParameterType.RequestBody);
        var response = client.Execute(request);

        Assert.IsNotNull(response);
        Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        Assert.AreEqual(expectedResponse, response.Content);
    }
}