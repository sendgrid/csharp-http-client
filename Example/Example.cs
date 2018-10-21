namespace Example
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Web.Script.Serialization;
    using Newtonsoft.Json;
    using SendGrid.CSharp.HTTP.Client;

    // This is a working example, using the SendGrid API
    // You will need a SendGrid account and an active API Key
    // They key should be stored in an environment variable called SENDGRID_APIKEY
    internal class Example
    {
        private static void Main(string[] args)
        {
            Execute().Wait();
        }

        private static async Task Execute()
        {
            string host = "https://e9sk3d3bfaikbpdq7.stoplight-proxy.io";
            Dictionary<string, string> globalRequestHeaders = new Dictionary<string, string>();
            string apiKey = Environment.GetEnvironmentVariable("SENDGRID_APIKEY", EnvironmentVariableTarget.User);
            globalRequestHeaders.Add("Authorization", "Bearer " + apiKey);
            globalRequestHeaders.Add("Content-Type", "application/json");

            string version = "v3";
            dynamic client = new Client(host: host, requestHeaders: globalRequestHeaders, version: version);

            // GET Collection
            string queryParams = @"{
                'limit': 100
            }";
            Dictionary<string, string> requestHeaders = new Dictionary<string, string>();
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

            object json = JsonConvert.DeserializeObject<object>(requestBody);
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
            json = JsonConvert.DeserializeObject<object>(requestBody);
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
            json = JsonConvert.DeserializeObject<object>(requestBody);
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
