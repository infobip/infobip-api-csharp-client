using System.Collections.Generic;
using Newtonsoft.Json;
using Infobip.Api.Model.Omni.Campaign;
using System;

namespace Infobip.Api.Model.Omni.Campaign
{
    /// <summary>
    /// This is a generated class and is not intended for modification!
    /// </summary>
    public class CampaignsResponse
    {
        [JsonProperty("campaigns")]
        public IList<Campaign> Campaigns { get; set; }

        [JsonProperty("campaignCount")]
        public long? CampaignCount { get; set; }


    }
}