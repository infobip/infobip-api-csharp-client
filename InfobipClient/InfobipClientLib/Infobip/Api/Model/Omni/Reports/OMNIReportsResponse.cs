using Infobip.Api.Model.Omni.Reports;
using System.Collections.Generic;
using Newtonsoft.Json;
using System;

namespace Infobip.Api.Model.Omni.Reports
{
    /// <summary>
    /// This is a generated class and is not intended for modification!
    /// </summary>
    public class OMNIReportsResponse
    {
        [JsonProperty("results")]
        public IList<OMNIReport> Results { get; set; }


    }
}