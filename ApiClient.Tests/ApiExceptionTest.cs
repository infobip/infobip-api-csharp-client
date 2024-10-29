using Infobip.Api.Client.Api;
using Infobip.Api.Client.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using ApiException = Infobip.Api.Client.ApiException;

namespace ApiClient.Tests
{
    [TestClass]
    public class ApiExceptionTest : ApiTest
    {
        protected const string SMS_SEND_TEXT_ADVANCED_ENDPOINT = "/sms/2/text/advanced";

        internal static readonly Tuple<int, string, string, string>[] ErrorResponses =
        {
            Tuple.Create(400, "BAD_REQUEST", "Bad Request", "[messages[0].destinations : size must be between 1 and 2147483647]"),
            Tuple.Create(401, "UNAUTHORIZED", "Unauthorized", "Invalid login details"),
            Tuple.Create(403, "UNAUTHORIZED", "Forbidden", "Unauthorized access"),
            Tuple.Create(404, "NOT_FOUND", "Not Found", "Requested URL not found: /sms/2/text/advanced"),
            Tuple.Create(429, "TOO_MANY_REQUESTS", "Too Many Requests", "Too many requests"),
            Tuple.Create(500, "GENERAL_ERROR", "Internal Server Error", "Something went wrong. Please contact support."),
            Tuple.Create(503, "0", "Service Unavailable", "Error processing email validation request! Please try again"),
        };

        [DataTestMethod]
        [DataRow(0)]
        [DataRow(1)]
        [DataRow(2)]
        [DataRow(3)]
        [DataRow(4)]
        [DataRow(5)]
        [DataRow(6)]
        public void ErrorResponseTest(int errorResponseIndex)
        {
            int httpCode = ErrorResponses[errorResponseIndex].Item1;
            string messageId = ErrorResponses[errorResponseIndex].Item2;
            string errorPhrase = ErrorResponses[errorResponseIndex].Item3;
            string errorText = ErrorResponses[errorResponseIndex].Item4;

            string to = "41793026727";
            string from = "InfoSMS";
            string message = "This is a sample message";

            string responseJson = $@"
            {{
                ""requestError"": {{
                    ""serviceException"": {{
                    ""messageId"": ""{messageId}"",
                    ""text"": ""{errorText}""
                    }}
                }}
            }}";

            string expectedRequest = $@"
            {{
                ""messages"": [
                {{
                    ""destinations"": [
                    {{
                        ""to"": ""{to}""
                    }}
                      ],
                    ""flash"":false,
                    ""from"": ""{from}"",
                    ""intermediateReport"":false,
                    ""text"": ""{message}""
                }}
                ],
                    ""includeSmsCountInResponse"":false
            }}";

            Dictionary<string, string> responseHeaders = new Dictionary<string, string>()
            {
                { "Server", "SMS,API" },
                { "X-Request-ID", "1234567898765432100" },
                { "Content-Type", "application/json; charset=utf-8" }
            };

            SetUpPostRequest(SMS_SEND_TEXT_ADVANCED_ENDPOINT, expectedRequest, responseJson, httpCode);

            var smsApi = new SmsApi(this.configuration);

            var request = new SmsAdvancedTextualRequest(
                messages: new List<SmsTextualMessage> {
                    new SmsTextualMessage(
                        from: from, text: message, destinations: new List<SmsDestination>{ new SmsDestination(to: to) }
                    )
                }
            );

            try
            {
                var result = smsApi.SendSmsMessage(request);
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
                Assert.IsTrue(responseHeaders.All(h => ex.Headers.ContainsKey(h.Key) && ex.Headers[h.Key].First().Equals(h.Value)));
            }
        }
    }
}
