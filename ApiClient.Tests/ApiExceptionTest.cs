using ApiClient.Tests.Api;
using Infobip.Api.Client.Api;
using Infobip.Api.Client.Model;
using ApiException = Infobip.Api.Client.ApiException;

namespace ApiClient.Tests;

[TestClass]
public class ApiExceptionTest : ApiTest
{
    protected const string SMS_MESSAGES_ENDPOINT = "/sms/3/messages";

    internal static readonly Tuple<int, string, string, string>[] ErrorResponses =
    {
        Tuple.Create(400, "BAD_REQUEST", "Bad Request",
            "[messages[0].destinations : size must be between 1 and 2147483647]"),
        Tuple.Create(401, "UNAUTHORIZED", "Unauthorized", "Invalid login details"),
        Tuple.Create(403, "UNAUTHORIZED", "Forbidden", "Unauthorized access"),
        Tuple.Create(404, "NOT_FOUND", "Not Found", "Requested URL not found: /sms/2/text/advanced"),
        Tuple.Create(429, "TOO_MANY_REQUESTS", "Too Many Requests", "Too many requests"),
        Tuple.Create(500, "GENERAL_ERROR", "Internal Server Error", "Something went wrong. Please contact support."),
        Tuple.Create(503, "0", "Service Unavailable", "Error processing email validation request! Please try again")
    };

    [TestMethod]
    [DataRow(0)]
    [DataRow(1)]
    [DataRow(2)]
    [DataRow(3)]
    [DataRow(4)]
    [DataRow(5)]
    [DataRow(6)]
    public void ErrorResponseTest(int errorResponseIndex)
    {
        var httpCode = ErrorResponses[errorResponseIndex].Item1;
        var messageId = ErrorResponses[errorResponseIndex].Item2;
        var errorPhrase = ErrorResponses[errorResponseIndex].Item3;
        var errorText = ErrorResponses[errorResponseIndex].Item4;

        var to = "41793026727";
        var sender = "InfoSMS";
        var message = "This is a sample message";

        var responseJson = $@"
            {{
                ""requestError"": {{
                    ""serviceException"": {{
                    ""messageId"": ""{messageId}"",
                    ""text"": ""{errorText}""
                    }}
                }}
            }}";

        var expectedRequest = $@"
        {{
          ""messages"": [
            {{
              ""sender"": ""{sender}"",
              ""destinations"": [
                {{
                  ""to"": ""{to}""
                }}
              ],
              ""content"": {{
                ""text"": ""{message}""
              }}
            }}
          ]
        }}";

        var responseHeaders = new Dictionary<string, string>
        {
            { "Server", "SMS,API" },
            { "X-Request-ID", "1608758729810312842" },
            { "Content-Type", "application/json; charset=utf-8" }
        };

        SetUpPostRequest(SMS_MESSAGES_ENDPOINT, httpCode, expectedRequest, responseJson);

        var smsApi = new SmsApi(Configuration);

        var request = new SmsRequest(
            new List<SmsMessage>
            {
                new(
                    sender, content: new SmsMessageContent(new SmsTextContent(message)),
                    destinations: new List<SmsDestination> { new(to) }
                )
            }
        );

        try
        {
            //It gets exceptions ErrorResponses as defined at the start of the class but for each it throws Newtonsoft.Json.JsonSerializationException: 'Required property 'messages' not found in JSON.
            smsApi.SendSmsMessages(request);
        }
        catch (ApiException ex)
        {
            Assert.AreEqual(httpCode, ex.ErrorCode);
            Assert.IsNotNull(ex.ErrorContent);
            Assert.AreEqual(responseJson, ex.ErrorContent);
            Assert.IsInstanceOfType(ex, typeof(ApiException));
            Assert.IsTrue(ex.Message.Contains(errorPhrase));
            Assert.IsTrue(ex.ErrorContent.ToString()?.Contains(messageId) == true);
            Assert.IsTrue(ex.ErrorContent.ToString()?.Contains(errorText) == true);
            Assert.IsTrue(responseHeaders.All(h =>
                ex.Headers.ContainsKey(h.Key) && ex.Headers[h.Key].First().Equals(h.Value)));
        }
    }
}