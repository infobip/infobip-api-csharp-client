using System.Collections.Generic;
using Newtonsoft.Json;
using System;

namespace Infobip.Api.Model.Omni
{
    /// <summary>
    /// This is a generated class and is not intended for modification!
    /// </summary>
    public class To
    {
        [JsonProperty("phoneNumber")]
        public string PhoneNumber { get; set; }

        [JsonProperty("emailAddress")]
        public string EmailAddress { get; set; }

        [JsonProperty("pushRegistrationId")]
        public string PushRegistrationId { get; set; }

        [JsonProperty("facebookUserKey")]
        public string FacebookUserKey { get; set; }

        [JsonProperty("lineUserKey")]
        public string LineUserKey { get; set; }


    }
}