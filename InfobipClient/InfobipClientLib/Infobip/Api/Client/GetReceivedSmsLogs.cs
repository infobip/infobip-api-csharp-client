using Infobip.Api.Config;
using Infobip.Api.Model.Exception;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Infobip.Api.Model.Sms.Mo.Logs;
using Infobip.Extensions;

namespace Infobip.Api.Client
{
    /// <summary>
    /// This is a generated class and is not intended for modification!
    /// </summary>
    public class GetReceivedSmsLogs
    {
        private static string path = "/sms/1/inbox/logs";

        private Config.Configuration configuration;

        private static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.DateTimeOffset,
            Converters = new List<JsonConverter>(1) { new FormattedDateConverter() }
        };

        public GetReceivedSmsLogs(Config.Configuration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<MOLogsResponse> ExecuteAsync(GetReceivedSmsLogsExecuteContext context)
        {
            using (var client = HttpClientProvider.GetHttpClient(configuration))
            {
                NameValueCollection queryParameters = new NameValueCollection();
                SetQueryParamIfNotNull(queryParameters, "to", context.To);
                SetQueryParamIfNotNull(queryParameters, "receivedSince", context.ReceivedSince);
                SetQueryParamIfNotNull(queryParameters, "receivedUntil", context.ReceivedUntil);
                SetQueryParamIfNotNull(queryParameters, "limit", context.Limit);
                SetQueryParamIfNotNull(queryParameters, "keyword", context.Keyword);

                string queryString = queryParameters.ToQueryString();
                string endpoint = path + "?" + queryString;

                var response = await client.GetAsync(endpoint);
                string contents = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    return JsonConvert.DeserializeObject<MOLogsResponse>(contents, Settings);
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