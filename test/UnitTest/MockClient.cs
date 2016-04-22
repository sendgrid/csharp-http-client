using SendGrid.CSharp.HTTP.Client;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest
{
    // Mock the Client so that we intercept network calls
    public class MockClient : Client
    {
        public MockClient(string host, Dictionary<string, string> requestHeaders = null, string version = null, string urlPath = null) : base(host, requestHeaders, version, urlPath)
        {
        }

        public async override Task<Response> MakeRequest(HttpClient client, HttpRequestMessage request)
        {
            HttpResponseMessage response = new HttpResponseMessage();
            response.Content = new StringContent("{'test': 'test_content'}", Encoding.UTF8, "application/json");
            response.StatusCode = HttpStatusCode.OK;
            return new Response(response.StatusCode, response.Content, response.Headers);
        }
    }
}
