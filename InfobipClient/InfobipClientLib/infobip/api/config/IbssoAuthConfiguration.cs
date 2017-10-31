using System.Collections.Generic;

namespace InfobipClient.infobip.api.config
{
    public class IbssoAuthConfiguration : Configuration
    {
        public string IbssoToken { get; }

        public IbssoAuthConfiguration(string baseUrl, string ibssoToken)
        {
            BaseUrl = baseUrl;
            IbssoToken = ibssoToken;
        }

        public IbssoAuthConfiguration(string ibssoToken)
        {
            IbssoToken = ibssoToken;
        }

        public override string GetAuthorizationHeader()
        {
            return "IBSSO " + IbssoToken;
        }

        public override bool Equals(object obj)
        {
            var configuration = obj as IbssoAuthConfiguration;
            return configuration != null &&
                base.Equals(obj) &&
                IbssoToken == configuration.IbssoToken;
        }

        public override int GetHashCode()
        {
            var hashCode = -644159750;
            hashCode = hashCode * -1521134295 + base.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(IbssoToken);
            return hashCode;
        }
    }
}
