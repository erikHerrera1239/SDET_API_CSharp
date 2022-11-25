using NUnit.Framework;
using NUnit.Framework.Internal;
using SDETAPI_CSharp.Core;
using SDETAPI_CSharp.Features;
using SDETAPI_CSharp.Features.HealthcareGov;
using SDETAPI_CSharp.Features.HealthcareGov.Models;
using System.IO;
using System.Linq;
using System.Net;

namespace SDETAPI_CSharp.Tests
{
    public class HealthcareTests
    {
        private readonly TextWriter _testWriter = TestContext.Out;

        public RequestBuilder<HealtcareFeature> _requestBuilder;

        [SetUp]
        public void Setup()
        {
            this._requestBuilder = new RequestBuilder<HealtcareFeature>(this._testWriter);
        }

        [Test]
        public void GetArticlesTest()
        {
            var response = this._requestBuilder.PerformRequest("articles");
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            var articles = RestCore.GetInstance.DeserializeJsonResponse<ArticlesResponseModel>(response).articles;
            Assert.That(
                articles.Any(
                    a => a.title.Equals("Reporting income deductions")
                        && a.lang.Equals("en")
                        && a.layout.Equals("With Sidebar")
                ),
                Is.True
            );
        }

        [Test]
        public void GetBlogTest()
        {
            var response = this._requestBuilder.PerformRequest("blog");
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            var blogs = RestCore.GetInstance.DeserializeJsonResponse<BlogResponseModel>(response).blog;
            Assert.That(
                blogs.Any(
                    a => a.title.Equals("Don’t miss out: Get Marketplace insurance that starts Jan 1")
                ),
                Is.True
            );
        }

        [Test]
        public void GetGlossaryTest()
        {
            var response = this._requestBuilder.PerformRequest("glossary");
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            var glossaries = RestCore.GetInstance.DeserializeJsonResponse<GlossaryResponseModel>(response).glossary;
            Assert.That(
                glossaries.Any(
                    a => a.title.Equals("Abortion services")
                ),
                Is.True
            );
        }
    }
}