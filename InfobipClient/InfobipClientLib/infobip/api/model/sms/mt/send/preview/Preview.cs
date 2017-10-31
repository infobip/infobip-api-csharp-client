using System.Collections.Generic;
using Newtonsoft.Json;
using System;

namespace InfobipClient.infobip.api.model.sms.mt.send.preview
{
    /// <summary>
    /// This is a generated class and is not intended for modification!
    /// </summary>
    public class Preview
    {
        [JsonProperty("textPreview")]
        public string TextPreview { get; set; }

        [JsonProperty("messageCount")]
        public int? MessageCount { get; set; }

        [JsonProperty("configuration")]
        public Configuration Configuration { get; set; }

        [JsonProperty("charactersRemaining")]
        public int? CharactersRemaining { get; set; }

        public override bool Equals(object obj)
        {
            var thisClass = obj as Preview;
            return thisClass != null &&
                EqualityComparer<string>.Default.Equals(TextPreview, thisClass.TextPreview) &&
                EqualityComparer<int?>.Default.Equals(MessageCount, thisClass.MessageCount) &&
                EqualityComparer<Configuration>.Default.Equals(Configuration, thisClass.Configuration) &&
                EqualityComparer<int?>.Default.Equals(CharactersRemaining, thisClass.CharactersRemaining);
        }

        public override int GetHashCode()
        {
            var hashCode = -1559463931;
            hashCode = hashCode * -1521134295 +  EqualityComparer<string>.Default.GetHashCode(TextPreview);
            hashCode = hashCode * -1521134295 +  EqualityComparer<int?>.Default.GetHashCode(MessageCount);
            hashCode = hashCode * -1521134295 +  EqualityComparer<Configuration>.Default.GetHashCode(Configuration);
            hashCode = hashCode * -1521134295 +  EqualityComparer<int?>.Default.GetHashCode(CharactersRemaining);
            return hashCode;
        }
    }
}