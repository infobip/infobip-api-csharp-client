using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Infobip.Api.Client;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WireMock.Matchers;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using WireMock.Server;
using WireMock.Types;

namespace ApiClient.Tests
{
    public class ApiTest
    {
        protected const string API_KEY_PREFIX = "App";
        protected const string API_KEY = "003026bbc133714df1834b8638bb496e-8f4b3d9a-e931-478d-a994-28a725159ab9";
        protected const string EXPECTED_API_KEY_HEADER_VALUE = API_KEY_PREFIX + " " + API_KEY;
        protected const string EXPECTED_CONTENT_TYPE_HEADER_VALUE = "application/json; charset=utf-8";
        protected const string EXPECTED_USR_AGENT_HEADER_VALUE = "infobip-api-client-csharp/" + Configuration.Version;
        protected const string EXPECTED_ACCEPT_HEADER_VALUE = "application/json";
        protected const string EXPECTED_SERVER_HEADER_VALUE = "SMS API";
        protected const string EXPECTED_SERVER_HEADER_VALUE_COMMA = "SMS,API";
        protected const string EXPECTED_X_REQUEST_ID_HEADER_VALUE = "1234567898765432100";

        protected Configuration configuration;

        protected WireMockServer wireMockServer;

        [TestInitialize]
        public void StartMockServer()
        {
            wireMockServer = WireMockServer.Start();

            configuration = new Configuration
            {
                ApiKey = API_KEY,
                BasePath = "http://localhost:" + wireMockServer.Ports[0]
            };
        }

        [TestCleanup]
        public void TearDown()
        {
            wireMockServer.Stop();
        }

        protected void SetUpGetRequest(string url, string givenResponse, int statusCode)
        {
            SetUpGetRequest(url, new Dictionary<string, string>(), givenResponse, statusCode);
        }

        protected void SetUpPostRequest(string url, string expectedRequest, string givenResponse, int statusCode)
        {
            SetUpPostRequest(url, new Dictionary<string, string>(), expectedRequest, givenResponse, statusCode);
        }

        protected void SetUpPutRequest(string url, string expectedRequest, string givenResponse, int statusCode)
        {
            SetUpPutRequest(url, new Dictionary<string, string>(), expectedRequest, givenResponse, statusCode);
        }

        protected void SetUpDeleteRequest(string url, int statusCode)
        {
            SetUpDeleteRequest(url, new Dictionary<string, string>(), statusCode);
        }

        protected void SetUpGetRequest(string url, Dictionary<string, string> expectedParameters, string givenResponse, int statusCode)
        {
            wireMockServer.Given(Request.Create().UsingGet().WithPath(url)
                .WithHeader("Authorization", new ExactMatcher(EXPECTED_API_KEY_HEADER_VALUE))
                .WithHeader("Accept", new ExactMatcher(EXPECTED_ACCEPT_HEADER_VALUE))
                .WithHeader("User-Agent", new ExactMatcher(EXPECTED_USR_AGENT_HEADER_VALUE))
                .WithParam(EqualToParams(expectedParameters))
                )
                .RespondWith(Response.Create()
                    .WithStatusCode(statusCode)
                    .WithHeader("Content-Type", EXPECTED_CONTENT_TYPE_HEADER_VALUE)
                    .WithHeader("Server", EXPECTED_SERVER_HEADER_VALUE)
                    .WithHeader("X-Request-Id", EXPECTED_X_REQUEST_ID_HEADER_VALUE)
                    .WithBody(givenResponse)
                );
        }

        protected void SetUpPostRequest(string url, Dictionary<string, string> expectedParameters, string expectedRequest, string givenResponse, int statusCode)
        {
            wireMockServer.Given(Request.Create().UsingPost().WithPath(url)
                .WithHeader("Authorization", new ExactMatcher(EXPECTED_API_KEY_HEADER_VALUE))
                .WithHeader("Content-Type", new ExactMatcher(EXPECTED_CONTENT_TYPE_HEADER_VALUE))
                .WithHeader("Accept", new ExactMatcher(EXPECTED_ACCEPT_HEADER_VALUE))
                .WithHeader("User-Agent", new ExactMatcher(EXPECTED_USR_AGENT_HEADER_VALUE))
                .WithParam(EqualToParams(expectedParameters))
                .WithBody(new JsonMatcher(expectedRequest, true, false))
                )
                .RespondWith(Response.Create()
                    .WithStatusCode(statusCode)
                    .WithHeader("Content-Type", EXPECTED_CONTENT_TYPE_HEADER_VALUE)
                    .WithHeader("Server", EXPECTED_SERVER_HEADER_VALUE)
                    .WithHeader("X-Request-Id", EXPECTED_X_REQUEST_ID_HEADER_VALUE)
                    .WithBody(givenResponse)
                );
        }

        protected void SetUpPostRequestBinary(string url, Dictionary<string, string> expectedParameters, byte[] expectedRequest, string givenResponse, int statusCode)
        {
            wireMockServer.Given(Request.Create().UsingPost().WithPath(url)
                .WithHeader("Authorization", new ExactMatcher(EXPECTED_API_KEY_HEADER_VALUE))
                .WithHeader("Content-Type", new ExactMatcher("application/octet-stream"))
                .WithHeader("Accept", new ExactMatcher(EXPECTED_ACCEPT_HEADER_VALUE))
                .WithHeader("User-Agent", new ExactMatcher(EXPECTED_USR_AGENT_HEADER_VALUE))
                .WithParam(EqualToParams(expectedParameters))
                .WithBody(expectedRequest)
                )
                .RespondWith(Response.Create()
                    .WithStatusCode(statusCode)
                    .WithHeader("Content-Type", EXPECTED_CONTENT_TYPE_HEADER_VALUE)
                    .WithHeader("Server", EXPECTED_SERVER_HEADER_VALUE)
                    .WithHeader("X-Request-Id", EXPECTED_X_REQUEST_ID_HEADER_VALUE)
                    .WithBody(givenResponse)
                );
        }

        protected void SetUpNoRequestBodyNoResponseBodyPostRequest(string url, int statusCode)
        {
            wireMockServer.Given(Request.Create().UsingPost().WithPath(url)
                .WithHeader("Authorization", new ExactMatcher(EXPECTED_API_KEY_HEADER_VALUE))
                .WithHeader("Accept", new ExactMatcher(EXPECTED_ACCEPT_HEADER_VALUE))
                .WithHeader("User-Agent", new ExactMatcher(EXPECTED_USR_AGENT_HEADER_VALUE))
                )
                .RespondWith(Response.Create()
                    .WithStatusCode(statusCode)
                    .WithHeader("Server", EXPECTED_SERVER_HEADER_VALUE)
                    .WithHeader("X-Request-Id", EXPECTED_X_REQUEST_ID_HEADER_VALUE)
                );
        }

        protected void SetUpPutRequest(string url, Dictionary<string, string> expectedParameters, string expectedRequest, string givenResponse, int statusCode)
        {
            wireMockServer.Given(Request.Create().UsingPut().WithPath(url)
                .WithHeader("Authorization", new ExactMatcher(EXPECTED_API_KEY_HEADER_VALUE))
                .WithHeader("Content-Type", new ExactMatcher(EXPECTED_CONTENT_TYPE_HEADER_VALUE))
                .WithHeader("Accept", new ExactMatcher(EXPECTED_ACCEPT_HEADER_VALUE))
                .WithHeader("User-Agent", new ExactMatcher(EXPECTED_USR_AGENT_HEADER_VALUE))
                .WithParam(EqualToParams(expectedParameters))
                .WithBody(new JsonMatcher(expectedRequest, true, false))
                )
                .RespondWith(Response.Create()
                    .WithStatusCode(statusCode)
                    .WithHeader("Content-Type", EXPECTED_CONTENT_TYPE_HEADER_VALUE)
                    .WithHeader("Server", EXPECTED_SERVER_HEADER_VALUE)
                    .WithHeader("X-Request-Id", EXPECTED_X_REQUEST_ID_HEADER_VALUE)
                    .WithBody(givenResponse)
                );
        }

        protected void SetUpDeleteRequest(string url, Dictionary<string, string> expectedParameters, int statusCode)
        {
            wireMockServer.Given(Request.Create().UsingDelete().WithPath(url)
                .WithHeader("Authorization", new ExactMatcher(EXPECTED_API_KEY_HEADER_VALUE))
                .WithHeader("Accept", new ExactMatcher(EXPECTED_ACCEPT_HEADER_VALUE))
                .WithParam(EqualToParams(expectedParameters))
                )
                .RespondWith(Response.Create()
                    .WithStatusCode(statusCode)
                    .WithHeader("Server", EXPECTED_SERVER_HEADER_VALUE)
                    .WithHeader("X-Request-Id", EXPECTED_X_REQUEST_ID_HEADER_VALUE)
                );
        }

        protected void SetUpDeleteRequestWithResponseBody(string url, Dictionary<string, string> expectedParameters, string givenResponse, int statusCode)
        {
            wireMockServer.Given(Request.Create().UsingDelete().WithPath(url)
                .WithHeader("Authorization", new ExactMatcher(EXPECTED_API_KEY_HEADER_VALUE))
                .WithHeader("Accept", new ExactMatcher(EXPECTED_ACCEPT_HEADER_VALUE))
                .WithParam(EqualToParams(expectedParameters))
                )
                .RespondWith(Response.Create()
                    .WithStatusCode(statusCode)
                    .WithHeader("Server", EXPECTED_SERVER_HEADER_VALUE)
                    .WithHeader("X-Request-Id", EXPECTED_X_REQUEST_ID_HEADER_VALUE)
                    .WithHeader("Content-Type", EXPECTED_CONTENT_TYPE_HEADER_VALUE)
                    .WithBody(givenResponse)
                );
        }

        protected void SetUpMultipartFormRequest(string url, Multimap<string, string> expectedParts, string givenResponse, int statusCode = 200)
        {
            var req = Request.Create().UsingPost().WithPath(url)
                .WithHeader("Authorization", new ExactMatcher(EXPECTED_API_KEY_HEADER_VALUE))
                .WithHeader("Content-Type", new WildcardMatcher("multipart/form-data; boundary=\"---------*", true))
                .WithHeader("Accept", new ExactMatcher(EXPECTED_ACCEPT_HEADER_VALUE))
                .WithHeader("User-Agent", new ExactMatcher(EXPECTED_USR_AGENT_HEADER_VALUE));

            req.WithBody((body) => {
                var allKeysFound = expectedParts.All(kvp => body.Contains($"name={kvp.Key}", StringComparison.InvariantCultureIgnoreCase));
                var allValuesFound = expectedParts.All(kvp => kvp.Value.All(value => body.Contains(value, StringComparison.InvariantCultureIgnoreCase)));
                return allValuesFound && allKeysFound;
            });

            var resp = Response.Create()
                    .WithStatusCode(statusCode)
                    .WithHeader("Content-Type", EXPECTED_CONTENT_TYPE_HEADER_VALUE)
                    .WithHeader("Server", EXPECTED_SERVER_HEADER_VALUE)
                    .WithHeader("X-Request-Id", EXPECTED_X_REQUEST_ID_HEADER_VALUE)
                    .WithBody(givenResponse);

            wireMockServer.Given(req).RespondWith(resp);
        }

        private Func<IDictionary<string, WireMockList<string>>, bool>[] EqualToParams(Dictionary<string, string> parameters)
        {
            var funcs = new List<Func<IDictionary<string, WireMockList<string>>, bool>>();
            foreach (var param in parameters)
            {
                funcs.Add(delegate (IDictionary<string, WireMockList<string>> inputParams)
                {
                    return inputParams[param.Key][0] == param.Value;
                });
            }
            if (funcs.Count == 0) funcs.Add(x => true); // Hack for System.ArgumentException: The collection argument 'funcs' must contain at least one element.
            return funcs.ToArray();
        }

        public static void AssertResponse<T>(T apiResponse, Action<T> assertion)
        {
            assertion.Invoke(apiResponse);
        }

        public static void AssertResponseWithHttpInfo<T>(ApiResponse<T> apiResponse, Action<T> assertion)
        {
            Assert.AreEqual(HttpStatusCode.OK, apiResponse.StatusCode);

            Assert.AreEqual(EXPECTED_SERVER_HEADER_VALUE_COMMA, apiResponse.Headers["Server"][0]);
            Assert.AreEqual(EXPECTED_X_REQUEST_ID_HEADER_VALUE, apiResponse.Headers["X-Request-ID"][0]);
            Assert.AreEqual(EXPECTED_CONTENT_TYPE_HEADER_VALUE, apiResponse.Headers["Content-Type"][0]);

            assertion.Invoke(apiResponse.Data);
        }

        public static void AssertNoBodyResponseWithHttpInfo<T>(ApiResponse<T> apiResponse, HttpStatusCode expectedHttpStatusCode)
        {
            Assert.AreEqual(expectedHttpStatusCode, apiResponse.StatusCode);

            Assert.AreEqual(EXPECTED_SERVER_HEADER_VALUE_COMMA, apiResponse.Headers["Server"][0]);
            Assert.AreEqual(EXPECTED_X_REQUEST_ID_HEADER_VALUE, apiResponse.Headers["X-Request-ID"][0]);
        }
    }
}