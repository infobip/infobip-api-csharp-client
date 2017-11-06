namespace Infobip.Api.Config
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
    }
}
