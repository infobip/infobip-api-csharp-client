using Infobip.Api.Model.Nc;
using System.Collections.Generic;
using Newtonsoft.Json;
using System;
using Infobip.Api.Model;

namespace Infobip.Api.Model.Nc.Query
{
    /// <summary>
    /// This is a generated class and is not intended for modification!
    /// </summary>
    public class NumberContextResponseDetails
    {
        [JsonProperty("to")]
        public string To { get; set; }

        [JsonProperty("mccMnc")]
        public string MccMnc { get; set; }

        [JsonProperty("imsi")]
        public string Imsi { get; set; }

        [JsonProperty("originalNetwork")]
        public Network OriginalNetwork { get; set; }

        [JsonProperty("ported")]
        public bool? Ported { get; set; }

        [JsonProperty("portedNetwork")]
        public Network PortedNetwork { get; set; }

        [JsonProperty("roaming")]
        public bool? Roaming { get; set; }

        [JsonProperty("roamingNetwork")]
        public Network RoamingNetwork { get; set; }

        [JsonProperty("servingMSC")]
        public string ServingMSC { get; set; }

        [JsonProperty("status")]
        public Status Status { get; set; }

        [JsonProperty("error")]
        public Error Error { get; set; }


    }
}