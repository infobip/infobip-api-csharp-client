using System;
using System.Text;

namespace Infobip.Api.Config
{
    public class BasicAuthConfiguration : Configuration
    {
        public string Username { get; }
        public string Password { get; }

        public BasicAuthConfiguration(string baseUrl, string username, string password)
        {
            BaseUrl = baseUrl;
            Username = username;
            Password = password;
        }

        public BasicAuthConfiguration(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public override string GetAuthorizationHeader()
        {
            return "Basic " + Base64Credentials();
        }

        private string Base64Credentials()
        {
            return Convert.ToBase64String(
                Encoding.ASCII.GetBytes(Username + ":" + Password)
            );
        }
    }
}
