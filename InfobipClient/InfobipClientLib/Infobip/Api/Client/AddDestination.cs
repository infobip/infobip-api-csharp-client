using Infobip.Api.Config;
using Infobip.Api.Model.Exception;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Infobip.Api.Model.Omni.Campaign;
using System.Net;

namespace Infobip.Api.Client
{
    /// <summary>
    /// This is a generated class and is not intended for modification!
    /// </summary>
    public class AddDestination
    {
        private static string path = "/omni/2/campaigns/{campaignKey}/destinations";

        private Config.Configuration configuration;

        private static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.DateTimeOffset,
            Converters = new List<JsonConverter>(1) { new FormattedDateConverter() }
        };

        public AddDestination(Config.Configuration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<Campaign> ExecuteAsync(string campaignKey, Destinations bodyObject)
        {
            using (var client = HttpClientProvider.GetHttpClient(configuration))
            {
                string endpoint = path;
                endpoint = endpoint.Replace("{campaignKey}", WebUtility.UrlEncode(campaignKey));

                string requestJson = JsonConvert.SerializeObject(bodyObject, Settings);
                HttpContent content = new StringContent(requestJson, Encoding.UTF8, "application/json");

                var response = await client.PutAsync(endpoint, content);
                string contents = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    return JsonConvert.DeserializeObject<Campaign>(contents, Settings);
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
}