using Newtonsoft.Json;

namespace InfobipClient.infobip.api.model.error
{
    public class ServiceException
    {
        [JsonProperty("messageId")]
        public string MessageId { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }
    }
}
