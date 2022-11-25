using NUnit.Framework;
using RestSharp;
using SDETAPI_CSharp.Features;
using SDETAPI_CSharp.Features.NasaOpenAPI;
using System.Collections.Generic;
using System.Net;

namespace SDETAPI_CSharp.Tests
{
    public class NASATests
    {
        private RequestBuilder<NasaFeature> _requestBuilder;

        [SetUp]
        public void Setup()
        {
            this._requestBuilder = new RequestBuilder<NasaFeature>();
        }

        [Test]
        public void GetApodTest()
        {
            var response = this._requestBuilder.PerformRequest("apod");
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public void GetAsteroidsNewWsTest()
        {
            var response = this._requestBuilder.PerformRequest("asteroidsNewWs");
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public void GetTechTransferTest()
        {
            var queryParams = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("engine", "")
            };
            var resourceList = new List<string>()
            {
                "patent",
                "patent_issued",
                "software",
                "spinoff"
            };

            foreach(var resource in resourceList)
            {
                var response = this._requestBuilder.PerformRequest(
                    "techTransfer",
                    queryParams: queryParams,
                    customAction: r => r.AddUrlSegment("resource", resource)
                );
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            }

        }
    }
}