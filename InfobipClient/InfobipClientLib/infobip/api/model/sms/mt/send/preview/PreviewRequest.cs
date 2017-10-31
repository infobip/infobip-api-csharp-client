using System.Collections.Generic;
using Newtonsoft.Json;
using System;

namespace InfobipClient.infobip.api.model.sms.mt.send.preview
{
    /// <summary>
    /// This is a generated class and is not intended for modification!
    /// </summary>
    public class PreviewRequest
    {
        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("languageCode")]
        public string LanguageCode { get; set; }

        [JsonProperty("transliteration")]
        public string Transliteration { get; set; }

        public override bool Equals(object obj)
        {
            var thisClass = obj as PreviewRequest;
            return thisClass != null &&
                EqualityComparer<string>.Default.Equals(Text, thisClass.Text) &&
                EqualityComparer<string>.Default.Equals(LanguageCode, thisClass.LanguageCode) &&
                EqualityComparer<string>.Default.Equals(Transliteration, thisClass.Transliteration);
        }

        public override int GetHashCode()
        {
            var hashCode = -1559463931;
            hashCode = hashCode * -1521134295 +  EqualityComparer<string>.Default.GetHashCode(Text);
            hashCode = hashCode * -1521134295 +  EqualityComparer<string>.Default.GetHashCode(LanguageCode);
            hashCode = hashCode * -1521134295 +  EqualityComparer<string>.Default.GetHashCode(Transliteration);
            return hashCode;
        }
    }
}