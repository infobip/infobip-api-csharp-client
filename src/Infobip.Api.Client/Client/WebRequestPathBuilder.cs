/*
 * Infobip Client API Libraries OpenAPI Specification
 * OpenAPI specification containing public endpoints supported in client API libraries.
 *
 * Contact: support@infobip.com
 *
 * NOTE: This class is auto generated by OpenAPI Generator (https://openapi-generator.tech).
 * Do not edit the class manually.
 */

using System.Collections.Generic;

namespace Infobip.Api.Client
{
    /// <summary>
    ///     A URI builder
    /// </summary>
    internal class WebRequestPathBuilder
    {
        private readonly string _baseUrl;

        private string _path;

        private string _query = "?";

        public WebRequestPathBuilder(string baseUrl, string path)
        {
            _baseUrl = baseUrl;
            _path = path;
        }

        public void AddPathParameters(IDictionary<string, string> parameters)
        {
            foreach (var parameter in parameters)
                _path = _path.Replace("{" + parameter.Key + "}", parameter.Value);
        }

        public void AddQueryParameters(Multimap<string, string> parameters)
        {
            foreach (var parameter in parameters)
            foreach (var value in parameter.Value)
                _query = _query + parameter.Key + "=" + ClientUtils.UrlEncode(value) + "&";
        }

        public string GetFullUri()
        {
            return $"{_baseUrl}{_path}{_query.Substring(0, _query.Length - 1)}";
        }
    }
}