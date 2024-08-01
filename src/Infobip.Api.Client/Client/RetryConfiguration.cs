using System.Net.Http;
using Polly;

namespace Infobip.Api.Client
{
    /// <summary>
    ///     Configuration class to set the polly retry policies to be applied to the requests.
    /// </summary>
    public class RetryConfiguration
    {
        /// <summary>
        ///     Async retry policy
        /// </summary>
        public static AsyncPolicy<HttpResponseMessage> AsyncRetryPolicy { get; set; }

        /// <summary>
        ///     Retry policy
        /// </summary>
        public static Policy<HttpResponseMessage> RetryPolicy { get; set; }
    }
}