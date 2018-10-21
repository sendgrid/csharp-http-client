namespace SendGrid.CSharp.HTTP.Client
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Web.Script.Serialization;

    public class Response
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="Response"/> class
        ///     for holding the response from an API call.
        /// </summary>
        /// <param name="statusCode">https://msdn.microsoft.com/en-us/library/system.net.httpstatuscode(v=vs.110).aspx</param>
        /// <param name="responseBody">https://msdn.microsoft.com/en-us/library/system.net.http.httpcontent(v=vs.118).aspx</param>
        /// <param name="responseHeaders">https://msdn.microsoft.com/en-us/library/system.net.http.headers.httpresponseheaders(v=vs.118).aspx</param>
        public Response(HttpStatusCode statusCode, HttpContent responseBody, HttpResponseHeaders responseHeaders)
        {
            StatusCode = statusCode;
            Body = responseBody;
            Headers = responseHeaders;
        }

        public HttpStatusCode StatusCode { get; set; }

        public HttpContent Body { get; set; }

        public HttpResponseHeaders Headers { get; set; }

        /// <summary>
        ///     Converts string formatted response body to a Dictionary.
        /// </summary>
        /// <param name="content">https://msdn.microsoft.com/en-us/library/system.net.http.httpcontent(v=vs.118).aspx</param>
        /// <returns>Dictionary object representation of HttpContent</returns>
        public virtual Dictionary<string, dynamic> DeserializeResponseBody(HttpContent content)
        {
            JavaScriptSerializer jss = new JavaScriptSerializer();
            var dsContent = jss.Deserialize<Dictionary<string, dynamic>>(content.ReadAsStringAsync().Result);
            return dsContent;
        }

        /// <summary>
        ///     Converts string formatted response headers to a Dictionary.
        /// </summary>
        /// <param name="content">https://msdn.microsoft.com/en-us/library/system.net.http.headers.httpresponseheaders(v=vs.118).aspx</param>
        /// <returns>Dictionary object representation of  HttpRepsonseHeaders</returns>
        public virtual Dictionary<string, string> DeserializeResponseHeaders(HttpResponseHeaders content)
        {
            var dsContent = new Dictionary<string, string>();
            foreach (var pair in content)
            {
                dsContent.Add(pair.Key, pair.Value.First());
            }

            return dsContent;
        }
    }
}
