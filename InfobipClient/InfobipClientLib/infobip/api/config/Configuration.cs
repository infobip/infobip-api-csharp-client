using System.Collections.Generic;

namespace InfobipClient.infobip.api.config
{
    public abstract class Configuration
    {
        public string BaseUrl { get; set; } = "https://api.infobip.com";
        public int ConnectionTimeout { get; set; } = 10000;
        public int ReadTimeout { get; set; } = 10000;

        abstract public string GetAuthorizationHeader();

        public override bool Equals(object obj)
        {
            var configuration = obj as Configuration;
            return configuration != null &&
                   BaseUrl == configuration.BaseUrl &&
                   ConnectionTimeout == configuration.ConnectionTimeout &&
                   ReadTimeout == configuration.ReadTimeout;
        }

        public override int GetHashCode()
        {
            var hashCode = 251280853;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(BaseUrl);
            hashCode = hashCode * -1521134295 + ConnectionTimeout.GetHashCode();
            hashCode = hashCode * -1521134295 + ReadTimeout.GetHashCode();
            return hashCode;
        }
    }
}
