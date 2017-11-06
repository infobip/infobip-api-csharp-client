using Newtonsoft.Json;

namespace Infobip.Api.Model.Exception
{
    public class RequestError
    {
        [JsonProperty("serviceException")]
        public ServiceException ServiceException {get; set; }
    }
}
