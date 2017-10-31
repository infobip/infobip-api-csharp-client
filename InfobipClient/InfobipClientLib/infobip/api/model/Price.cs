using System.Collections.Generic;
using Newtonsoft.Json;
using System;

namespace InfobipClient.infobip.api.model
{
    /// <summary>
    /// This is a generated class and is not intended for modification!
    /// </summary>
    public class Price
    {
        [JsonProperty("pricePerLookup")]
        public decimal? PricePerLookup { get; set; }

        [JsonProperty("pricePerMessage")]
        public decimal? PricePerMessage { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        public override bool Equals(object obj)
        {
            var thisClass = obj as Price;
            return thisClass != null &&
                EqualityComparer<decimal?>.Default.Equals(PricePerLookup, thisClass.PricePerLookup) &&
                EqualityComparer<decimal?>.Default.Equals(PricePerMessage, thisClass.PricePerMessage) &&
                EqualityComparer<string>.Default.Equals(Currency, thisClass.Currency);
        }

        public override int GetHashCode()
        {
            var hashCode = -1559463931;
            hashCode = hashCode * -1521134295 +  EqualityComparer<decimal?>.Default.GetHashCode(PricePerLookup);
            hashCode = hashCode * -1521134295 +  EqualityComparer<decimal?>.Default.GetHashCode(PricePerMessage);
            hashCode = hashCode * -1521134295 +  EqualityComparer<string>.Default.GetHashCode(Currency);
            return hashCode;
        }
    }
}