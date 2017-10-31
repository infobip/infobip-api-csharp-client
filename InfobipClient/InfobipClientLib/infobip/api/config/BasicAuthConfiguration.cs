using System;
using System.Collections.Generic;
using System.Text;

namespace InfobipClient.infobip.api.config
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

        public override bool Equals(object obj)
        {
            var configuration = obj as BasicAuthConfiguration;
            return configuration != null &&
                base.Equals(obj) &&
                Username == configuration.Username &&
                Password == configuration.Password;
        }

        public override int GetHashCode()
        {
            var hashCode = 568732665;
            hashCode = hashCode * -1521134295 + base.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Username);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Password);
            return hashCode;
        }
    }
}
