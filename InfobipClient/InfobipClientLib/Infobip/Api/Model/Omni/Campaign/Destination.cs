using System.Collections.Generic;
using Newtonsoft.Json;
using Infobip.Api.Model.Omni.Campaign;
using System;

namespace Infobip.Api.Model.Omni.Campaign
{
    /// <summary>
    /// This is a generated class and is not intended for modification!
    /// </summary>
    public class Destination
    {
        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("middleName")]
        public string MiddleName { get; set; }

        [JsonProperty("gsm")]
        public string Gsm { get; set; }

        [JsonProperty("landline")]
        public string Landline { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("gender")]
        public Gender Gender { get; set; }

        [JsonProperty("birthday")]
        public string Birthday { get; set; }


    }
}