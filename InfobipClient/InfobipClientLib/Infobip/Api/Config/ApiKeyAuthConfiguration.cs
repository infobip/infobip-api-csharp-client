namespace Infobip.Api.Config
{
    public class ApiKeyAuthConfiguration : Configuration
    {
        public string ApiKey { get; }

        public ApiKeyAuthConfiguration(string baseUrl, string apiKey)
        {
            BaseUrl = baseUrl;
            ApiKey = apiKey;
        }

        public ApiKeyAuthConfiguration(string apiKey)
        {
            ApiKey = apiKey;
        }

        public override string GetAuthorizationHeader()
        {
            return "App " + ApiKey;
        }
    }
}
