using System.Globalization;
using System.Reflection;
using System.Runtime.Serialization;
using Infobip.Api.Client;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WireMock.Matchers;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using WireMock.Server;
using WireMock.Types;

namespace ApiClient.Tests.Api;

public class ApiTest
{
    protected const string API_KEY_PREFIX = "App";
    protected const string API_KEY = "003026bbc133714df1834b8638bb496e-8f4b3d9a-e931-478d-a994-28a725159ab9";
    protected const string API_KEY_HEADER_VALUE = API_KEY_PREFIX + " " + API_KEY;
    protected const string CONTENT_TYPE_HEADER_VALUE = "application/json; charset=utf-8";
    protected const string USER_AGENT_HEADER_VALUE = "infobip-api-client-csharp/" + Configuration.Version;
    protected const string ACCEPT_HEADER_VALUE = "application/json";
    protected const string SERVER_HEADER_VALUE = "SMS API";
    protected const string SERVER_HEADER_VALUE_COMMA = "SMS,API";
    protected const string X_REQUEST_ID_HEADER_VALUE = "1608758729810312842";

    protected Configuration? configuration;

    protected WireMockServer? wireMockServer;

    [TestInitialize]
    public void StartMockServer()
    {
        CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;
        
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
        wireMockServer!.Stop();
    }

    protected void SetUpGetRequest(string url, int statusCode, string expectedResponse,
        Dictionary<string, string>? givenParameters = null)
    {
        var request = Request.Create().UsingGet().WithPath(url)
            .WithHeader("Authorization", new ExactMatcher(API_KEY_HEADER_VALUE))
            .WithHeader("Accept", new ExactMatcher(ACCEPT_HEADER_VALUE))
            .WithHeader("User-Agent", new ExactMatcher(USER_AGENT_HEADER_VALUE));

        if (givenParameters != null && givenParameters.Count > 0)
            request = request.WithParam(EqualToParams(givenParameters));

        wireMockServer!.Given(request)
            .RespondWith(Response.Create()
                .WithStatusCode(statusCode)
                .WithHeader("Content-Type", CONTENT_TYPE_HEADER_VALUE)
                .WithHeader("Server", SERVER_HEADER_VALUE)
                .WithHeader("X-Request-Id", X_REQUEST_ID_HEADER_VALUE)
                .WithBody(expectedResponse)
            );
    }

    protected void SetUpGetRequestBinary(string url, int statusCode, string expectedResponse,
        Dictionary<string, string>? givenParameters = null)
    {
        var request = Request.Create().UsingGet().WithPath(url)
            .WithHeader("Authorization", new ExactMatcher(API_KEY_HEADER_VALUE))
            .WithHeader("Accept", new ExactMatcher("application/octet-stream"));

        if (givenParameters != null && givenParameters.Count > 0)
            request = request.WithParam(EqualToParams(givenParameters));

        wireMockServer!.Given(request)
            .RespondWith(Response.Create()
                .WithStatusCode(statusCode)
                .WithHeader("Content-Type", CONTENT_TYPE_HEADER_VALUE)
                .WithHeader("Server", SERVER_HEADER_VALUE)
                .WithHeader("X-Request-Id", X_REQUEST_ID_HEADER_VALUE)
                .WithBody(expectedResponse)
            );
    }

    protected void SetUpPostRequest(string url, int statusCode, string? givenRequest = null,
        string? expectedResponse = null, Dictionary<string, string>? givenParameters = null)
    {
        var request = Request.Create().UsingPost().WithPath(url)
            .WithHeader("Authorization", new ExactMatcher(API_KEY_HEADER_VALUE))
            .WithHeader("Accept", new ExactMatcher(ACCEPT_HEADER_VALUE))
            .WithHeader("User-Agent", new ExactMatcher(USER_AGENT_HEADER_VALUE));

        if (givenParameters != null) request = request.WithParam(EqualToParams(givenParameters));

        if (!string.IsNullOrEmpty(givenRequest))
            request = request.WithHeader("Content-Type", new ExactMatcher(CONTENT_TYPE_HEADER_VALUE))
                .WithBody(new JsonMatcher(givenRequest, true));

        var response = Response.Create().WithStatusCode(statusCode)
            .WithHeader("Server", SERVER_HEADER_VALUE)
            .WithHeader("X-Request-Id", X_REQUEST_ID_HEADER_VALUE);

        if (!string.IsNullOrEmpty(expectedResponse))
            response = response.WithHeader("Content-Type", CONTENT_TYPE_HEADER_VALUE)
                .WithBody(expectedResponse);

        wireMockServer!.Given(request).RespondWith(response);
    }

    protected void SetUpPatchRequest(string url, int statusCode, string givenRequest, string? expectedResponse = null,
        Dictionary<string, string>? givenParameters = null)
    {
        var request = Request.Create().UsingPatch().WithPath(url)
            .WithHeader("Authorization", new ExactMatcher(API_KEY_HEADER_VALUE))
            .WithHeader("Content-Type", new ExactMatcher(CONTENT_TYPE_HEADER_VALUE))
            .WithHeader("Accept", new ExactMatcher(ACCEPT_HEADER_VALUE))
            .WithHeader("User-Agent", new ExactMatcher(USER_AGENT_HEADER_VALUE))
            .WithBody(new JsonMatcher(givenRequest, true));

        if (givenParameters != null && givenParameters.Count > 0)
            request = request.WithParam(EqualToParams(givenParameters));

        var response = Response.Create()
            .WithStatusCode(statusCode)
            .WithHeader("Server", SERVER_HEADER_VALUE)
            .WithHeader("X-Request-Id", X_REQUEST_ID_HEADER_VALUE);

        if (!string.IsNullOrEmpty(expectedResponse))
            response = response.WithHeader("Content-Type", CONTENT_TYPE_HEADER_VALUE)
                .WithBody(expectedResponse);

        wireMockServer!.Given(request).RespondWith(response);
    }

    protected void SetUpPutRequest(string url, int statusCode, string givenRequest, string? expectedResponse = null,
        Dictionary<string, string>? givenParameters = null)
    {
        var request = Request.Create().UsingPut().WithPath(url)
            .WithHeader("Authorization", new ExactMatcher(API_KEY_HEADER_VALUE))
            .WithHeader("Content-Type", new ExactMatcher(CONTENT_TYPE_HEADER_VALUE))
            .WithHeader("Accept", new ExactMatcher(ACCEPT_HEADER_VALUE))
            .WithHeader("User-Agent", new ExactMatcher(USER_AGENT_HEADER_VALUE))
            .WithBody(new JsonMatcher(givenRequest, true));

        if (givenParameters != null && givenParameters.Count > 0)
            request = request.WithParam(EqualToParams(givenParameters));

        var response = Response.Create()
            .WithStatusCode(statusCode)
            .WithHeader("Server", SERVER_HEADER_VALUE)
            .WithHeader("X-Request-Id", X_REQUEST_ID_HEADER_VALUE);

        if (!string.IsNullOrEmpty(expectedResponse))
            response = response.WithHeader("Content-Type", CONTENT_TYPE_HEADER_VALUE)
                .WithBody(expectedResponse);

        wireMockServer!.Given(request).RespondWith(response);
    }

    protected void SetUpDeleteRequest(string url, int statusCode, string? givenRequest = null,
        string? expectedResponse = null, Dictionary<string, string>? givenParameters = null)
    {
        var request = Request.Create().UsingDelete().WithPath(url)
            .WithHeader("Authorization", new ExactMatcher(API_KEY_HEADER_VALUE))
            .WithHeader("Accept", new ExactMatcher(ACCEPT_HEADER_VALUE));

        if (givenParameters != null) request = request.WithParam(EqualToParams(givenParameters));

        if (!string.IsNullOrEmpty(givenRequest))
            request = request.WithHeader("Content-Type", new ExactMatcher(CONTENT_TYPE_HEADER_VALUE))
                .WithHeader("User-Agent", new ExactMatcher(USER_AGENT_HEADER_VALUE))
                .WithBody(new JsonMatcher(givenRequest, true));

        var response = Response.Create().WithStatusCode(statusCode)
            .WithHeader("Server", SERVER_HEADER_VALUE)
            .WithHeader("X-Request-Id", X_REQUEST_ID_HEADER_VALUE);

        if (!string.IsNullOrEmpty(expectedResponse))
            response = response.WithHeader("Content-Type", CONTENT_TYPE_HEADER_VALUE)
                .WithBody(expectedResponse);

        wireMockServer!.Given(request).RespondWith(response);
    }

    protected void SetUpMultipartFormRequest(string url, Multimap<string, string> givenParts, string expectedResponse,
        int statusCode = 200)
    {
        var req = Request.Create().UsingPost().WithPath(url)
            .WithHeader("Authorization", new ExactMatcher(API_KEY_HEADER_VALUE))
            .WithHeader("Content-Type", new WildcardMatcher("multipart/form-data; boundary=\"---------*", true))
            .WithHeader("Accept", new ExactMatcher(ACCEPT_HEADER_VALUE))
            .WithHeader("User-Agent", new ExactMatcher(USER_AGENT_HEADER_VALUE));

        req.WithBody(body =>
        {
            var allKeysFound = givenParts.All(kvp =>
                body.Contains($"name={kvp.Key}", StringComparison.InvariantCultureIgnoreCase));
            var allValuesFound = givenParts.All(kvp =>
                kvp.Value.All(value => body.Contains(value, StringComparison.InvariantCultureIgnoreCase)));
            return allValuesFound && allKeysFound;
        });

        var resp = Response.Create()
            .WithStatusCode(statusCode)
            .WithHeader("Content-Type", CONTENT_TYPE_HEADER_VALUE)
            .WithHeader("Server", SERVER_HEADER_VALUE)
            .WithHeader("X-Request-Id", X_REQUEST_ID_HEADER_VALUE)
            .WithBody(expectedResponse);

        wireMockServer!.Given(req).RespondWith(resp);
    }

    private Func<IDictionary<string, WireMockList<string>>, bool>[] EqualToParams(Dictionary<string, string> parameters)
    {
        var funcs = new List<Func<IDictionary<string, WireMockList<string>>, bool>>();
        foreach (var param in parameters)
            funcs.Add(delegate(IDictionary<string, WireMockList<string>> inputParams)
            {
                return inputParams[param.Key][0] == param.Value;
            });
        if (funcs.Count == 0) funcs.Add(x => true);
        return funcs.ToArray();
    }

    public static void AssertResponse<T>(T apiResponse, Action<T> assertion)
    {
        assertion.Invoke(apiResponse);
    }

    public static void AssertResponseWithHttpInfo<T>(ApiResponse<T> apiResponse, Action<T> assertion,
        int expectedHttpStatusCode)
    {
        Assert.AreEqual(expectedHttpStatusCode, (int)apiResponse.StatusCode);

        Assert.AreEqual(SERVER_HEADER_VALUE_COMMA, apiResponse.Headers["Server"][0]);
        Assert.AreEqual(X_REQUEST_ID_HEADER_VALUE, apiResponse.Headers["X-Request-ID"][0]);
        Assert.AreEqual(CONTENT_TYPE_HEADER_VALUE, apiResponse.Headers["Content-Type"][0]);

        assertion.Invoke(apiResponse.Data);
    }

    public static void AssertNoBodyResponseWithHttpInfo<T>(ApiResponse<T> apiResponse,
        int expectedHttpStatusCode)
    {
        Assert.AreEqual(expectedHttpStatusCode, (int)apiResponse.StatusCode);

        Assert.AreEqual(SERVER_HEADER_VALUE_COMMA, apiResponse.Headers["Server"][0]);
        Assert.AreEqual(X_REQUEST_ID_HEADER_VALUE, apiResponse.Headers["X-Request-ID"][0]);
    }

    public static string GetEnumAttributeValue(Enum value)
    {
        return value.GetType().GetField(value.ToString())?
                   .GetCustomAttribute<EnumMemberAttribute>()?.Value
               ?? value.ToString();
    }

    public static string GetBooleanValueAsLowerString(bool value)
    {
        return value.ToString().ToLower();
    }
}