using InfobipClient.infobip.api.config;
using InfobipClient.infobip.api.model.error;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net.Http;
using System.Text;
using System.Web;
using InfobipClient.infobip.api.model.sms.mt.logs;


namespace InfobipClient.infobip.api.client
{
    /// <summary>
    /// This is a generated class and is not intended for modification!
    /// </summary>
    public class GetSentSmsLogs
    {
        private static string path = "/sms/1/logs";

        private static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.DateTimeOffset,
            DateFormatString = "yyyy-MM-ddTHH:mm:ss.FFFK"
        };

        private HttpClient client;

        public GetSentSmsLogs(config.Configuration configuration)
        {
            client = HttpClientProvider.GetHttpClient(configuration);
        }

        public SMSLogsResponse Execute(GetSentSmsLogsExecuteContext context)
        {
            NameValueCollection queryParameters = HttpUtility.ParseQueryString(string.Empty);
            SetQueryParamIfNotNull(queryParameters, "from", context.From);
            SetQueryParamIfNotNull(queryParameters, "to", context.To);
            SetQueryParamIfNotNull(queryParameters, "bulkId", context.BulkId);
            SetQueryParamIfNotNull(queryParameters, "messageId", context.MessageId);
            SetQueryParamIfNotNull(queryParameters, "generalStatus", context.GeneralStatus);
            SetQueryParamIfNotNull(queryParameters, "sentSince", context.SentSince);
            SetQueryParamIfNotNull(queryParameters, "sentUntil", context.SentUntil);
            SetQueryParamIfNotNull(queryParameters, "limit", context.Limit);
            SetQueryParamIfNotNull(queryParameters, "mcc", context.Mcc);
            SetQueryParamIfNotNull(queryParameters, "mnc", context.Mnc);

            string queryString = queryParameters.ToString();
            string endpoint = path + "?" + queryString;

            var response = client.GetAsync(endpoint).Result;
            string contents = response.Content.ReadAsStringAsync().Result;

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<SMSLogsResponse>(contents, Settings);
            }
            else
            {
                throw new InfobipApiException(
                    response.StatusCode,
                    JsonConvert.DeserializeObject<ApiErrorResponse>(contents, Settings)
                );
            }
        }

        private void SetQueryParamIfNotNull(NameValueCollection queryParameters, string key, object value)
        {
            if (value != null) queryParameters[key] = value.ToString();
        }

        private void SetQueryParamIfNotNull(NameValueCollection queryParameters, string key, object[] values)
        {
            if (values != null && values.Length > 0) queryParameters[key] = string.Join(",", values);
        }
    }
}