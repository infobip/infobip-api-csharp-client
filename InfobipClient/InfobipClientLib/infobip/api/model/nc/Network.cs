using System.Collections.Generic;
using Newtonsoft.Json;
using System;

namespace Infobip.Api.Model.Nc
{
    /// <summary>
    /// This is a generated class and is not intended for modification!
    /// </summary>
    public class Network
    {
        [JsonProperty("countryPrefix")]
        public string CountryPrefix { get; set; }

        [JsonProperty("networkName")]
        public string NetworkName { get; set; }

        [JsonProperty("countryName")]
        public string CountryName { get; set; }

        [JsonProperty("networkPrefix")]
        public string NetworkPrefix { get; set; }


    }
}