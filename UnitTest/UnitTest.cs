﻿using System;
using NUnit.Framework;
using SendGrid.CSharp.HTTP.Client;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text;
using System.Net;

namespace UnitTest
{

    // Mock the Client so that we intercept network calls
    public class MockClient : Client
    {
        public MockClient(string host, Dictionary<string, string> requestHeaders = null, string version = null, string urlPath = null) : base (host, requestHeaders, version, urlPath)
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

    public class MockFailingClient : Client
    {
        public MockFailingClient(string host, Dictionary<string, string> requestHeaders = null, string version = null, string urlPath = null) : base(host, requestHeaders, version, urlPath)
        {
        }

        public async override Task<Response> MakeRequest(HttpClient client, HttpRequestMessage request)
        {
            throw new HttpRequestException("Testing failures");
        }
    }

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
        public async void TestMethodCall()
        {
            var host = "http://api.test.com";
            dynamic test_client = new MockClient(host: host);
            Response response = await test_client.get();
            Assert.IsNotNull(response);
            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
            var content = new StringContent("{'test': 'test_content'}", Encoding.UTF8, "application/json");
            Assert.AreEqual(response.Body.ReadAsStringAsync().Result, content.ReadAsStringAsync().Result);
        }

        [Test]
        public async void TestFailingMethodCall()
        {
            var host = "http://api.test.com";
            dynamic test_client = new MockFailingClient(host: host);
            Response response = await test_client.get();
            Assert.IsNotNull(response);
            Assert.AreEqual(response.StatusCode, HttpStatusCode.InternalServerError);
            Assert.True(response.Body.ReadAsStringAsync().Result.Contains(".NET HttpRequestException"));
        }
    }
}
