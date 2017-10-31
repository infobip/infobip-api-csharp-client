using System.Collections.Generic;
using Newtonsoft.Json;
using System;

namespace InfobipClient.infobip.api.model.sms.mt.send
{
    /// <summary>
    /// This is a generated class and is not intended for modification!
    /// </summary>
    public class Tracking
    {
        [JsonProperty("processKey")]
        public string ProcessKey { get; set; }

        [JsonProperty("track")]
        public string Track { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        public override bool Equals(object obj)
        {
            var thisClass = obj as Tracking;
            return thisClass != null &&
                EqualityComparer<string>.Default.Equals(ProcessKey, thisClass.ProcessKey) &&
                EqualityComparer<string>.Default.Equals(Track, thisClass.Track) &&
                EqualityComparer<string>.Default.Equals(Type, thisClass.Type);
        }

        public override int GetHashCode()
        {
            var hashCode = -1559463931;
            hashCode = hashCode * -1521134295 +  EqualityComparer<string>.Default.GetHashCode(ProcessKey);
            hashCode = hashCode * -1521134295 +  EqualityComparer<string>.Default.GetHashCode(Track);
            hashCode = hashCode * -1521134295 +  EqualityComparer<string>.Default.GetHashCode(Type);
            return hashCode;
        }
    }
}