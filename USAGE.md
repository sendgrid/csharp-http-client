Below code uses for Importing Namespaces
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
// Here we are executing the host server. And Waiting till complete the Async method.
            Execute().Wait();
        }
// Creating Asyncronous task to execute the API methods.
        static async Task Execute()
        {
// Creating Host file for reference services in the applicaiton. Providing URL to create Host.
            String host = "https://e9sk3d3bfaikbpdq7.stoplight-proxy.io";
            Dictionary<String, String> globalRequestHeaders = new Dictionary<String, String>();
// Passing ApiKey for Authentication purpose
            string apiKey = Environment.GetEnvironmentVariable("SENDGRID_APIKEY", EnvironmentVariableTarget.User);
// Creating / Forming Header Object.
            globalRequestHeaders.Add("Authorization", "Bearer " + apiKey);
            globalRequestHeaders.Add("Content-Type", "application/json");

            String version = "v3";
// Creating Client Object by passing Host details.  
            dynamic client = new Client(host: host, requestHeaders: globalRequestHeaders, version: version);

            // GET Collection
            string queryParams = @"{
                'limit': 100
            }";
// DeSerializing request to send to API
            Dictionary<String, String> requestHeaders = new Dictionary<String, String>();
            requestHeaders.Add("X-Test", "test");
// Here we are calling API mehtod.
            dynamic response = await client.api_keys.get(queryParams: queryParams, requestHeaders: requestHeaders);
// Below lines we are checking for Response status.
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
// DeSerializing request to send to API
            Object json = JsonConvert.DeserializeObject<Object>(requestBody);
            requestHeaders.Clear();
            requestHeaders.Add("X-Test", "test2");
// Here we are calling API mehtod.
            response = await client.api_keys.post(requestBody: json.ToString(), requestHeaders: requestHeaders);
// Below lines we are checking for Response status.            
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
// DeSerializing request to send to API
            json = JsonConvert.DeserializeObject<Object>(requestBody);
// Here we are calling API mehtod.
            response = await client.api_keys._(api_key_id).patch(requestBody: json.ToString());
// Below lines we are checking for Response status.
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
// Here we are calling API mehtod.
            response = await client.api_keys._(api_key_id).put(requestBody: json.ToString());
// Below lines we are checking for Response status.
            Console.WriteLine(response.StatusCode);
            Console.WriteLine(response.Body.ReadAsStringAsync().Result);
            Console.WriteLine(response.Headers.ToString());

            Console.WriteLine("\n\nPress any key to continue to DELETE.");
            Console.ReadLine();
// Here calling API to Delete.
            // DELETE
            response = await client.api_keys._(api_key_id).delete();
// Below lines we are checking for Response status.
            Console.WriteLine(response.StatusCode);
            Console.WriteLine(response.Headers.ToString());

            Console.WriteLine("\n\nPress any key to exit.");
            Console.ReadLine();
        }
    }
}
