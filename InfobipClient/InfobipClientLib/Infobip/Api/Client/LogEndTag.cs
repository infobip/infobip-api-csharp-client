using Infobip.Api.Config;
using Infobip.Api.Model.Exception;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Infobip.Api.Model.Conversion;

namespace Infobip.Api.Client
{
    /// <summary>
    /// This is a generated class and is not intended for modification!
    /// </summary>
    public class LogEndTag
    {
        private static string path = "/ct/1/log/end/{messageId}";

        private Config.Configuration configuration;

        private static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.DateTimeOffset,
            Converters = new List<JsonConverter>(1) { new FormattedDateConverter() }
        };

        public LogEndTag(Config.Configuration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<EndTagResponse> ExecuteAsync(string messageId)
        {
            using (var client = HttpClientProvider.GetHttpClient(configuration))
            {
                string endpoint = path;
                endpoint = endpoint.Replace("{messageId}", HttpUtility.UrlEncode(messageId));

                var response = await client.PostAsync(endpoint, null);
                string contents = await response.Content.ReadAsStringAsync();

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
}