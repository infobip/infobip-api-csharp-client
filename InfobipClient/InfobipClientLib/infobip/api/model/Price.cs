using System.Collections.Generic;
using Newtonsoft.Json;
using System;

namespace Infobip.Api.Model
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


    }
}