using log4net;
using log4net.Repository;
using NUnit.Framework;
using NUnit.Framework.Internal;
using SDETAPI_CSharp.Core;
using SDETAPI_CSharp.Features;
using SDETAPI_CSharp.Features.HealthcareGov;
using SDETAPI_CSharp.Features.HealthcareGov.Models;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;

namespace SDETAPI_CSharp.Tests
{
    [TestFixture]
    public class HealthcareTests : BaseTestClass<HealthcareTests>
    {
        public RequestBuilder<HealtcareFeature> _requestBuilder;

        [SetUp]
        public void Setup()
        {
            this._requestBuilder = new RequestBuilder<HealtcareFeature>(Log);
        }

        [Test, Category("Healtcare")]
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

        [Test, Category("Healtcare")]
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
            var blogDate = (from b in blogs where b.title == "Don’t miss out: Get Marketplace insurance that starts Jan 1" select b.date).SingleOrDefault();
            Assert.That(blogDate, Is.EqualTo("2022-11-17 00:00:00 +0000"));
        }

        [Test, Category("Healtcare")]
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
            var glossariesContainingServices = (from g in glossaries where g.title.Contains("services", System.StringComparison.OrdinalIgnoreCase) select g).ToList();
            glossariesContainingServices.ForEach(g => Log.Info($"{g.title}: {g.content}"));
            Assert.That(glossariesContainingServices.Count, Is.EqualTo(12));
        }
    }
}