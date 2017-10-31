using System.Collections.Generic;

namespace InfobipClient.infobip.api.config
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

        public override bool Equals(object obj)
        {
            var configuration = obj as ApiKeyAuthConfiguration;
            return configuration != null &&
                base.Equals(obj) &&
                ApiKey == configuration.ApiKey;
        }

        public override int GetHashCode()
        {
            var hashCode = 1317362606;
            hashCode = hashCode * -1521134295 + base.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ApiKey);
            return hashCode;
        }
    }
}
