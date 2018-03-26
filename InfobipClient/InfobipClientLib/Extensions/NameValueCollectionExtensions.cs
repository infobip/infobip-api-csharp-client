using System;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;

namespace Infobip.Extensions
{
    internal static class NameValueCollectionExtensions
    {
        public static string ToQueryString(this NameValueCollection nvc)
        {
            return string.Join("&", nvc.AllKeys.Select(a => a + "=" + WebUtility.UrlEncode(nvc[a])));
        }
    }
}