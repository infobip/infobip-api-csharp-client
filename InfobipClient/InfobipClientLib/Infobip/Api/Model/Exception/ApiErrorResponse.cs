using Newtonsoft.Json;

namespace Infobip.Api.Model.Exception
{
    public class ApiErrorResponse
    {
        [JsonProperty("requestError")]
        public RequestError RequestError {get; set; }
    }
}
