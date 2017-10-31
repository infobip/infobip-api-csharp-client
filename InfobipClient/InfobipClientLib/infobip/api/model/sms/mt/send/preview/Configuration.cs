using System.Collections.Generic;
using Newtonsoft.Json;
using InfobipClient.infobip.api.model.sms.mt.send;
using System;

namespace InfobipClient.infobip.api.model.sms.mt.send.preview
{
    /// <summary>
    /// This is a generated class and is not intended for modification!
    /// </summary>
    public class Configuration
    {
        [JsonProperty("language")]
        public Language Language { get; set; }

        [JsonProperty("transliteration")]
        public string Transliteration { get; set; }

        public override bool Equals(object obj)
        {
            var thisClass = obj as Configuration;
            return thisClass != null &&
                EqualityComparer<Language>.Default.Equals(Language, thisClass.Language) &&
                EqualityComparer<string>.Default.Equals(Transliteration, thisClass.Transliteration);
        }

        public override int GetHashCode()
        {
            var hashCode = -1559463931;
            hashCode = hashCode * -1521134295 +  EqualityComparer<Language>.Default.GetHashCode(Language);
            hashCode = hashCode * -1521134295 +  EqualityComparer<string>.Default.GetHashCode(Transliteration);
            return hashCode;
        }
    }
}