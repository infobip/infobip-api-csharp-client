using Newtonsoft.Json;

namespace Infobip.Api.Model.Exception
{
    public class ServiceException
    {
        [JsonProperty("messageId")]
        public string MessageId { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }
    }
}
