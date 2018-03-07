using System.Collections.Generic;
using Newtonsoft.Json;
using Infobip.Api.Model.Omni;
using System;

namespace Infobip.Api.Model.Omni.Scenarios
{
    /// <summary>
    /// This is a generated class and is not intended for modification!
    /// </summary>
    public class Step
    {
        [JsonProperty("from")]
        public string From { get; set; }

        [JsonProperty("channel")]
        public OmniChannel Channel { get; set; }


    }
}