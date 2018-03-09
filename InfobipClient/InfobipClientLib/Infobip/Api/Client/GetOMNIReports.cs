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
using Infobip.Api.Model.Omni.Reports;

namespace Infobip.Api.Client
{
    /// <summary>
    /// This is a generated class and is not intended for modification!
    /// </summary>
    public class GetOMNIReports
    {
        private static string path = "/omni/1/reports";

        private Config.Configuration configuration;

        private static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.DateTimeOffset,
            Converters = new List<JsonConverter>(1) { new FormattedDateConverter() }
        };

        public GetOMNIReports(Config.Configuration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<OMNIReportsResponse> ExecuteAsync(GetOMNIReportsExecuteContext context)
        {
            using (var client = HttpClientProvider.GetHttpClient(configuration))
            {
                NameValueCollection queryParameters = HttpUtility.ParseQueryString(string.Empty);
                SetQueryParamIfNotNull(queryParameters, "bulkId", context.BulkId);
                SetQueryParamIfNotNull(queryParameters, "messageId", context.MessageId);
                SetQueryParamIfNotNull(queryParameters, "limit", context.Limit);
                SetQueryParamIfNotNull(queryParameters, "channel", context.Channel);

                string queryString = queryParameters.ToString();
                string endpoint = path + "?" + queryString;

                var response = await client.GetAsync(endpoint);
                string contents = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    return JsonConvert.DeserializeObject<OMNIReportsResponse>(contents, Settings);
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