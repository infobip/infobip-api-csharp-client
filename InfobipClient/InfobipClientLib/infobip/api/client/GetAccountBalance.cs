using InfobipClient.infobip.api.config;
using InfobipClient.infobip.api.model.error;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net.Http;
using System.Text;
using System.Web;
using InfobipClient.infobip.api.model.account;


namespace InfobipClient.infobip.api.client
{
    /// <summary>
    /// This is a generated class and is not intended for modification!
    /// </summary>
    public class GetAccountBalance
    {
        private static string path = "/account/1/balance";

        private static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.DateTimeOffset,
            DateFormatString = "yyyy-MM-ddTHH:mm:ss.FFFK"
        };

        private HttpClient client;

        public GetAccountBalance(config.Configuration configuration)
        {
            client = HttpClientProvider.GetHttpClient(configuration);
        }

        public AccountBalance Execute()
        {
            string endpoint = path;

            var response = client.GetAsync(endpoint).Result;
            string contents = response.Content.ReadAsStringAsync().Result;

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<AccountBalance>(contents, Settings);
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