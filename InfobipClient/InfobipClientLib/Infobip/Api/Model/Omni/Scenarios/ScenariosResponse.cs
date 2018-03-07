using System.Collections.Generic;
using Infobip.Api.Model.Omni.Scenarios;
using Newtonsoft.Json;
using System;

namespace Infobip.Api.Model.Omni.Scenarios
{
    /// <summary>
    /// This is a generated class and is not intended for modification!
    /// </summary>
    public class ScenariosResponse
    {
        [JsonProperty("scenarios")]
        public IList<Scenario> Scenarios { get; set; }


    }
}