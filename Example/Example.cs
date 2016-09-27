using System;
using System.Collections.Generic;
using SendGrid.CSharp.HTTP.Client;
using System.Web.Script.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;

// This is a working example, using the SendGrid API
// You will need a SendGrid account and an active API Key
// They key should be stored in an environment variable called SENDGRID_APIKEY
namespace Example
{
    class Example
    {
        static void Main(string[] args)
        {
            Execute().Wait();
        }

        static async Task Execute()
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
            dynamic response = await client.api_keys.get(queryParams: queryParams, requestHeaders: requestHeaders);
            Console.WriteLine(response.StatusCode);
            Console.WriteLine(response.Body.ReadAsStringAsync().Result);
            Console.WriteLine(response.Headers.ToString());

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
            Object json = JsonConvert.DeserializeObject<Object>(requestBody);
            requestHeaders.Clear();
            requestHeaders.Add("X-Test", "test2");
            response = await client.api_keys.post(requestBody: json.ToString(), requestHeaders: requestHeaders);
            Console.WriteLine(response.StatusCode);
            Console.WriteLine(response.Body.ReadAsStringAsync().Result);
            Console.WriteLine(response.Headers.ToString());
            JavaScriptSerializer jss = new JavaScriptSerializer();
            var ds_response = jss.Deserialize<Dictionary<string, dynamic>>(response.Body.ReadAsStringAsync().Result);
            string api_key_id = ds_response["api_key_id"];

            Console.WriteLine("\n\nPress any key to continue to GET single.");
            Console.ReadLine();

            // GET Single
            response = await client.api_keys._(api_key_id).get();
            Console.WriteLine(response.StatusCode);
            Console.WriteLine(response.Body.ReadAsStringAsync().Result);
            Console.WriteLine(response.Headers.ToString());

            Console.WriteLine("\n\nPress any key to continue to PATCH.");
            Console.ReadLine();

            // PATCH
            requestBody = @"{
                'name': 'A New Hope'
            }";
            json = JsonConvert.DeserializeObject<Object>(requestBody);
            response = await client.api_keys._(api_key_id).patch(requestBody: json.ToString());
            Console.WriteLine(response.StatusCode);
            Console.WriteLine(response.Body.ReadAsStringAsync().Result);
            Console.WriteLine(response.Headers.ToString());

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
            json = JsonConvert.DeserializeObject<Object>(requestBody);
            response = await client.api_keys._(api_key_id).put(requestBody: json.ToString());
            Console.WriteLine(response.StatusCode);
            Console.WriteLine(response.Body.ReadAsStringAsync().Result);
            Console.WriteLine(response.Headers.ToString());

            Console.WriteLine("\n\nPress any key to continue to DELETE.");
            Console.ReadLine();

            // DELETE
            response = await client.api_keys._(api_key_id).delete();
            Console.WriteLine(response.StatusCode);
            Console.WriteLine(response.Headers.ToString());

            Console.WriteLine("\n\nPress any key to exit.");
            Console.ReadLine();
        }
    }
}
