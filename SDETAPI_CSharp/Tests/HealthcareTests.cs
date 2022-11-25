using NUnit.Framework;
using SDETAPI_CSharp.Features;
using SDETAPI_CSharp.Features.HealthcareGov;
using System.Net;

namespace SDETAPI_CSharp.Tests
{
    public class HealthcareTests
    {
        public RequestBuilder<HealtcareFeature> _requestBuilder;

        [SetUp]
        public void Setup()
        {
            this._requestBuilder = new RequestBuilder<HealtcareFeature>();
        }

        [Test]
        public void GetArticlesTest()
        {
            var response = this._requestBuilder.PerformRequest("articles");
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public void GetBlogTest()
        {
            var response = this._requestBuilder.PerformRequest("blog");
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public void GetGlossaryTest()
        {
            var response = this._requestBuilder.PerformRequest("glossary");
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
    }
}