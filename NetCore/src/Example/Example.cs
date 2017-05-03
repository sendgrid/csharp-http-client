using System;
using System.Collections.Generic;
using SendGrid.CSharp.HTTP.Client;
using System.Web.Script.Serialization;

// This is a working example, using the SendGrid API
// You will need a SendGrid account and an active API Key
// They key should be stored in an environment variable called SENDGRID_APIKEY
namespace Example
{
    class Example
    {
        static void Main(string[] args)
        {
            String host = "https://e9sk3d3bfaikbpdq7.stoplight-proxy.io";
            Dictionary<String, String> globalRequestHeaders = new Dictionary<String, String>();
            string apiKey = Environment.GetEnvironmentVariable("SENDGRID_APIKEY", EnvironmentVariableTarget.User);
            globalRequestHeaders.Add("Authorization", "Bearer " + apiKey);
            globalRequestHeaders.Add("Content-Type", "application/json");

            String version = "v3";
            dynamic client = new Client(host: host, requestHeaders: globalRequestHeaders, version: version);

            // GET Collection
            string queryParams = @"{
                'limit': 100
            }";
            Dictionary<String, String> requestHeaders = new Dictionary<String, String>();
            requestHeaders.Add("X-Test", "test");
            dynamic response = client.version("v3").api_keys.get(queryParams: queryParams, requestHeaders: requestHeaders);
            // Console.WriteLine(response.StatusCode);
            // Console.WriteLine(response.ResponseBody.ReadAsStringAsync().Result);
            // Console.WriteLine(response.ResponseHeaders.ToString());

            var dssResponseBody = response.DeserializeResponseBody(response.ResponseBody);
            foreach ( var value in dssResponseBody["result"])
            {
                Console.WriteLine("name: {0}, api_key_id: {1}",value["name"], value["api_key_id"]);
            }

            var dssResponseHeaders = response.DeserializeResponseHeaders(response.ResponseHeaders);
            foreach (var pair in dssResponseHeaders)
            {
                Console.WriteLine("{0}: {1}", pair.Key, pair.Value);
            }

            Console.WriteLine("\n\nPress any key to continue to POST.");
            Console.ReadLine();

            // POST
            string requestBody = @"{
                'name': 'My API Key 5',
                'scopes': [
                    'mail.send',
                    'alerts.create',
                    'alerts.read'
                ]
            }";
            requestHeaders.Clear();
            requestHeaders.Add("X-Test", "test2");
            response = client.api_keys.post(requestBody: requestBody, requestHeaders: requestHeaders);
            Console.WriteLine(response.StatusCode);
            Console.WriteLine(response.ResponseBody.ReadAsStringAsync().Result);
            Console.WriteLine(response.ResponseHeaders.ToString());
            JavaScriptSerializer jss = new JavaScriptSerializer();
            var ds_response = jss.Deserialize<Dictionary<string, dynamic>>(response.ResponseBody.ReadAsStringAsync().Result);
            string api_key_id = ds_response["api_key_id"];

            Console.WriteLine("\n\nPress any key to continue to GET single.");
            Console.ReadLine();

            // GET Single
            response = client.api_keys._(api_key_id).get();
            Console.WriteLine(response.StatusCode);
            Console.WriteLine(response.ResponseBody.ReadAsStringAsync().Result);
            Console.WriteLine(response.ResponseHeaders.ToString());

            Console.WriteLine("\n\nPress any key to continue to PATCH.");
            Console.ReadLine();

            // PATCH
            requestBody = @"{
                'name': 'A New Hope'
            }";
            response = client.api_keys._(api_key_id).patch(requestBody: requestBody);
            Console.WriteLine(response.StatusCode);
            Console.WriteLine(response.ResponseBody.ReadAsStringAsync().Result);
            Console.WriteLine(response.ResponseHeaders.ToString());

            Console.WriteLine("\n\nPress any key to continue to PUT.");
            Console.ReadLine();

            // PUT
            requestBody = @"{
                'name': 'A New Hope',
                'scopes': [
                    'user.profile.read',
                    'user.profile.update'
                ]
            }";
            response = client.api_keys._(api_key_id).put(requestBody: requestBody);
            Console.WriteLine(response.StatusCode);
            Console.WriteLine(response.ResponseBody.ReadAsStringAsync().Result);
            Console.WriteLine(response.ResponseHeaders.ToString());

            Console.WriteLine("\n\nPress any key to continue to DELETE.");
            Console.ReadLine();

            // DELETE
            response = client.api_keys._(api_key_id).delete();
            Console.WriteLine(response.StatusCode);
            Console.WriteLine(response.ResponseHeaders.ToString());

            Console.WriteLine("\n\nPress any key to exit.");
            Console.ReadLine();
        }
    }
}
