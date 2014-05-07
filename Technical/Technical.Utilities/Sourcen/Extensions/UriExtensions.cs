using System;
using System.Web;

namespace Technical.Utilities.Extensions
{
    public static class UriExtensions
    {
        public static Uri AddQuery(this Uri uri, string name, string value)
        {
            var ub = new UriBuilder(uri);
            var queryString = HttpUtility.ParseQueryString(uri.Query);

            if (name != null && value != null)
            {
                var valueEncoded = HttpUtility.UrlEncode(value);
                queryString.Add(name, valueEncoded);
            }

            ub.Query = queryString.ToString();

            return ub.Uri;
        }
    }
}