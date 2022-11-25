using NUnit.Framework;
using RestSharp;
using SDETAPI_CSharp.Core;
using SDETAPI_CSharp.Features;
using SDETAPI_CSharp.Features.NasaOpenAPI;
using SDETAPI_CSharp.Features.NasaOpenAPI.Models.Asteroid;
using SDETAPI_CSharp.Features.NasaOpenAPI.Models.PlanetaryApod;
using SDETAPI_CSharp.Features.NasaOpenAPI.Models.TechTransfer;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace SDETAPI_CSharp.Tests
{
    [TestFixture]
    public class NASATests : BaseTestClass<NASATests>
    {
        private RequestBuilder<NasaFeature> _requestBuilder;

        [SetUp]
        public void Setup()
        {
            this._requestBuilder = new RequestBuilder<NasaFeature>(Log);
        }

        [Test, Category("NASA")]
        public void GetApodTest()
        {
            var response = this._requestBuilder.PerformRequest("apod");
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            var planetaryApod = RestCore.GetInstance.DeserializeJsonResponse<PlanetaryApodResponseModel>(response);
            Assert.That(
                planetaryApod.title == "NGC 6744: Extragalactic Close-Up",
                Is.True
            );
        }

        [Test, Category("NASA")]
        public void GetAsteroidsNewWsTest()
        {
            var response = this._requestBuilder.PerformRequest(
                "asteroidsNewWs",
                customAction: r => r.AddUrlSegment("id", 3542519)
            );
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            var id = RestCore.GetInstance.DeserializeJsonResponse<AsteroidResponseModel>(response).id;
            Assert.That(
                id.Equals("3542519"),
                Is.True
            );
        }

        [Test, Category("NASA")]
        public void GetTechTransferTest()
        {
            var queryParams = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("engine", "")
            };
            var resourceList = new List<KeyValuePair<string, int>>()
            {
                new KeyValuePair<string, int>("patent", 48),
                new KeyValuePair<string, int>("patent_issued", 41),
                new KeyValuePair<string, int>("software", 44),
                new KeyValuePair<string, int>("spinoff", 101)
            };

            foreach(var resource in resourceList)
            {
                var response = this._requestBuilder.PerformRequest(
                    "techTransfer",
                    queryParams: queryParams,
                    customAction: r => r.AddUrlSegment("resource", resource.Key)
                );
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                var result = RestCore.GetInstance.DeserializeJsonResponse<TechTransferResponseModel>(response);
                Assert.Multiple(() =>
                {
                    Assert.That(result.results, Has.Count.EqualTo(resource.Value));
                    Assert.That(result.count, Is.EqualTo(resource.Value));
                });
            }
        }
    }
}