using System.Collections.Generic;
using Infobip.Api.Model.Omni.Scenarios;
using Newtonsoft.Json;
using System;

namespace Infobip.Api.Model.Omni.Scenarios
{
    /// <summary>
    /// This is a generated class and is not intended for modification!
    /// </summary>
    public class Scenario
    {
        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("flow")]
        public IList<Step> Flow { get; set; }

        [JsonProperty("defaultScenario")]
        public bool? DefaultScenario { get; set; }


    }
}