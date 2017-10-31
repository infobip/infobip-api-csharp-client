using InfobipClient.infobip.api.config;
using InfobipClient.infobip.api.model.error;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net.Http;
using System.Text;
using System.Web;
using InfobipClient.infobip.api.model.conversion;


namespace InfobipClient.infobip.api.client
{
    /// <summary>
    /// This is a generated class and is not intended for modification!
    /// </summary>
    public class LogEndTag
    {
        private static string path = "/ct/1/log/end/{messageId}";

        private static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.DateTimeOffset,
            DateFormatString = "yyyy-MM-ddTHH:mm:ss.FFFK"
        };

        private HttpClient client;

        public LogEndTag(config.Configuration configuration)
        {
            client = HttpClientProvider.GetHttpClient(configuration);
        }

        public EndTagResponse Execute(string messageId)
        {
            string endpoint = path;
            endpoint = endpoint.Replace("{messageId}", HttpUtility.UrlEncode(messageId));

            var response = client.PostAsync(endpoint, null).Result;
            string contents = response.Content.ReadAsStringAsync().Result;

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<EndTagResponse>(contents, Settings);
            }
            else
            {
                throw new InfobipApiException(
                    response.StatusCode,
                    JsonConvert.DeserializeObject<ApiErrorResponse>(contents, Settings)
                );
            }
        }

    }
}