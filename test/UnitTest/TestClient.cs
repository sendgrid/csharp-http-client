using NUnit.Framework;
using SendGrid.CSharp.HTTP.Client;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;

namespace UnitTest
{
    [TestFixture]
    public class TestClient
    {
        [Test]
        public void TestInitialization()
        {
            var host = "http://api.test.com";
            Dictionary<String, String> requestHeaders = new Dictionary<String, String>();
            var version = "v3";
            var urlPath = "/test/url/path";
            var test_client = new MockClient(host: host, requestHeaders: requestHeaders, version: version, urlPath: urlPath);
            requestHeaders.Add("Authorization", "Bearer SG.XXXX");
            requestHeaders.Add("Content-Type", "application/json");
            requestHeaders.Add("X-TEST", "test");
            Assert.IsNotNull(test_client);
            Assert.AreEqual(host, test_client.Host);
            Assert.AreEqual(requestHeaders, test_client.RequestHeaders);
            Assert.AreEqual(version, test_client.Version);
            Assert.AreEqual(urlPath, test_client.UrlPath);
        }

        [Test]
        public void TestReflection()
        {
            var host = "http://api.test.com";
            dynamic test_client = new MockClient(host: host);
            dynamic url1 = test_client.my.test.path;
            Assert.AreEqual(url1.UrlPath, "/my/test/path");
            url1 = test_client.my._("test").path;
            Assert.AreEqual(url1.UrlPath, "/my/test/path");
            url1 = test_client.version("v4").my.test.path;
            Assert.AreEqual(url1.Version, "v4");
            Assert.AreEqual(url1.UrlPath, "/my/test/path");
            url1 = url1.final.result;
            Assert.AreEqual(url1.UrlPath, "/my/test/path/final/result");
        }

        [Test]
        public void TestMethodCall()
        {
            var host = "http://api.test.com";
            dynamic test_client = new MockClient(host: host);
            Response response = test_client.get();
            Assert.IsNotNull(response);
            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
            var content = new StringContent("{'test': 'test_content'}", Encoding.UTF8, "application/json");
            Assert.AreEqual(response.ResponseBody.ReadAsStringAsync().Result, content.ReadAsStringAsync().Result);
        }
    }
}
