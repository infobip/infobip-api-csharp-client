using System.Collections.Generic;
using Newtonsoft.Json;
using System;

namespace InfobipClient.infobip.api.model.nc.notify
{
    /// <summary>
    /// This is a generated class and is not intended for modification!
    /// </summary>
    public class NumberContextRequest
    {
        [JsonProperty("notifyUrl")]
        public string NotifyUrl { get; set; }

        [JsonProperty("to")]
        public List<string> To { get; set; } = new List<string>();

        [JsonProperty("notifyContentType")]
        public string NotifyContentType { get; set; }

        public override bool Equals(object obj)
        {
            var thisClass = obj as NumberContextRequest;
            return thisClass != null &&
                EqualityComparer<string>.Default.Equals(NotifyUrl, thisClass.NotifyUrl) &&
                EqualityComparer<List<string>>.Default.Equals(To, thisClass.To) &&
                EqualityComparer<string>.Default.Equals(NotifyContentType, thisClass.NotifyContentType);
        }

        public override int GetHashCode()
        {
            var hashCode = -1559463931;
            hashCode = hashCode * -1521134295 +  EqualityComparer<string>.Default.GetHashCode(NotifyUrl);
            hashCode = hashCode * -1521134295 +  EqualityComparer<List<string>>.Default.GetHashCode(To);
            hashCode = hashCode * -1521134295 +  EqualityComparer<string>.Default.GetHashCode(NotifyContentType);
            return hashCode;
        }
    }
}