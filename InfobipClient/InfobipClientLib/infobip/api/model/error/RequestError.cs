using Newtonsoft.Json;

namespace InfobipClient.infobip.api.model.error
{
    public class RequestError
    {
        [JsonProperty("serviceException")]
        public ServiceException ServiceException {get; set; }
    }
}
