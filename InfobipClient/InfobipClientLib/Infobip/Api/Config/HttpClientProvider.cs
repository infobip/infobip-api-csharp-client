using System;
using System.Net.Http;

namespace Infobip.Api.Config
{
    public class HttpClientProvider
    {
        public static HttpClient GetHttpClient(Configuration configuration)
        {
            HttpClient client = new HttpClient
            {
                BaseAddress = new Uri(configuration.BaseUrl),
                Timeout = TimeSpan.FromMilliseconds(configuration.ConnectionTimeout)
            };
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Add("Authorization", configuration.GetAuthorizationHeader());
            client.DefaultRequestHeaders.Add("User-Agent", "C#-Client-Library");
            return client;
        }

    }
}
