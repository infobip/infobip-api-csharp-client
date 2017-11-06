namespace Infobip.Api.Config
{
    public abstract class Configuration
    {
        public string BaseUrl { get; set; } = "https://api.infobip.com";
        public int ConnectionTimeout { get; set; } = 10000;
        public int ReadTimeout { get; set; } = 10000;

        abstract public string GetAuthorizationHeader();
    }
}
