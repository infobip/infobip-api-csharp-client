using InfobipClient.infobip.api.config;
using InfobipClient.infobip.api.model.error;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net.Http;
using System.Text;
using System.Web;
using InfobipClient.infobip.api.model.nc.query;

namespace InfobipClient.infobip.api.client
{
    /// <summary>
    /// This is a generated class and is not intended for modification!
    /// </summary>
    public class NumberContextQuery
    {
        private static string path = "/number/1/query";

        private static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.DateTimeOffset,
            DateFormatString = "yyyy-MM-ddTHH:mm:ss.FFFK"
        };

        private HttpClient client;

        public NumberContextQuery(config.Configuration configuration)
        {
            client = HttpClientProvider.GetHttpClient(configuration);
        }

        public NumberContextResponse Execute(NumberContextRequest bodyObject)
        {
            string endpoint = path;

            string requestJson = JsonConvert.SerializeObject(bodyObject, Settings);
            HttpContent content = new StringContent(requestJson, Encoding.UTF8, "application/json");

            var response = client.PostAsync(endpoint, content).Result;
            string contents = response.Content.ReadAsStringAsync().Result;

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<NumberContextResponse>(contents, Settings);
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