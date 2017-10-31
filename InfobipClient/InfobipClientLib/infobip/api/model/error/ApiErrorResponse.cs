using Newtonsoft.Json;

namespace InfobipClient.infobip.api.model.error
{
    public class ApiErrorResponse
    {
        [JsonProperty("requestError")]
        public RequestError RequestError {get; set; }
    }
}
