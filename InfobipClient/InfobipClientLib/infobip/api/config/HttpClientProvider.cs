using System;
using System.Collections.Concurrent;
using System.Net.Http;

namespace InfobipClient.infobip.api.config
{
    public class HttpClientProvider
    {
        private static ConcurrentDictionary<Configuration, HttpClient> clients = new ConcurrentDictionary<Configuration, HttpClient>();

        public static HttpClient GetHttpClient(Configuration configuration)
        {
            return clients.GetOrAdd(configuration, CreateClient);
        }

        private static HttpClient CreateClient(Configuration configuration)
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
