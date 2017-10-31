using System.Collections.Generic;
using Newtonsoft.Json;
using System;

namespace InfobipClient.infobip.api.model.sms.mt.send.preview
{
    /// <summary>
    /// This is a generated class and is not intended for modification!
    /// </summary>
    public class PreviewResponse
    {
        [JsonProperty("originalText")]
        public string OriginalText { get; set; }

        [JsonProperty("previews")]
        public List<Preview> Previews { get; set; } = new List<Preview>();

        public override bool Equals(object obj)
        {
            var thisClass = obj as PreviewResponse;
            return thisClass != null &&
                EqualityComparer<string>.Default.Equals(OriginalText, thisClass.OriginalText) &&
                EqualityComparer<List<Preview>>.Default.Equals(Previews, thisClass.Previews);
        }

        public override int GetHashCode()
        {
            var hashCode = -1559463931;
            hashCode = hashCode * -1521134295 +  EqualityComparer<string>.Default.GetHashCode(OriginalText);
            hashCode = hashCode * -1521134295 +  EqualityComparer<List<Preview>>.Default.GetHashCode(Previews);
            return hashCode;
        }
    }
}