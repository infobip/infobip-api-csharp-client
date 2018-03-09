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
using Infobip.Api.Model.Omni.Scenarios;
namespace Infobip.Api.Client
{
    /// <summary>
    /// This is a generated class and is not intended for modification!
    /// </summary>
    public class CreateScenario
    {
        private static string path = "/omni/1/scenarios";

        private Config.Configuration configuration;

        private static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.DateTimeOffset,
            Converters = new List<JsonConverter>(1) { new FormattedDateConverter() }
        };

        public CreateScenario(Config.Configuration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<Scenario> ExecuteAsync(Scenario bodyObject)
        {
            using (var client = HttpClientProvider.GetHttpClient(configuration))
            {
                string endpoint = path;

                string requestJson = JsonConvert.SerializeObject(bodyObject, Settings);
                HttpContent content = new StringContent(requestJson, Encoding.UTF8, "application/json");

                var response = await client.PostAsync(endpoint, content);
                string contents = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    return JsonConvert.DeserializeObject<Scenario>(contents, Settings);
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