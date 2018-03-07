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
using Infobip.Api.Model.Sms.Mt.Bulks;

namespace Infobip.Api.Client
{
    /// <summary>
    /// This is a generated class and is not intended for modification!
    /// </summary>
    public class GetBulks
    {
        private static string path = "/sms/1/bulks";

        private Config.Configuration configuration;

        private static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.DateTimeOffset,
            Converters = new List<JsonConverter>(1) { new FormattedDateConverter() }
        };

        public GetBulks(Config.Configuration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<BulkResponse> ExecuteAsync(GetBulksExecuteContext context)
        {
            using (var client = HttpClientProvider.GetHttpClient(configuration))
            {
                NameValueCollection queryParameters = HttpUtility.ParseQueryString(string.Empty);
                SetQueryParamIfNotNull(queryParameters, "bulkId", context.BulkId);

                string queryString = queryParameters.ToString();
                string endpoint = path + "?" + queryString;

                var response = await client.GetAsync(endpoint);
                string contents = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    return JsonConvert.DeserializeObject<BulkResponse>(contents, Settings);
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

        private void SetQueryParamIfNotNull(NameValueCollection queryParameters, string key, object value)
        {
            if (value != null)
            {
                queryParameters[key] = value.ToString();
            }
        }

        private void SetQueryParamIfNotNull(NameValueCollection queryParameters, string key, object[] values)
        {
            if (values != null && values.Length > 0)
            {
                queryParameters[key] = string.Join(",", values);
            }
        }
    }
}