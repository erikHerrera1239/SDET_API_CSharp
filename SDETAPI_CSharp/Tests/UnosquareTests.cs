using NUnit.Framework;
using RestSharp;
using SDETAPI_CSharp.Core;
using SDETAPI_CSharp.Features;
using SDETAPI_CSharp.Features.NasaOpenAPI;
using SDETAPI_CSharp.Features.NasaOpenAPI.Models.Asteroid;
using SDETAPI_CSharp.Features.NasaOpenAPI.Models.PlanetaryApod;
using SDETAPI_CSharp.Features.NasaOpenAPI.Models.TechTransfer;
using SDETAPI_CSharp.Features.Unosquare;
using SDETAPI_CSharp.Features.Unosquare.Models.OrdersPaged;
using SDETAPI_CSharp.Features.Unosquare.Posts.Unosquare.OrdersPaged;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace SDETAPI_CSharp.Tests
{
    [TestFixture]
    public class UnosquareTests : BaseTestClass<UnosquareTests>
    {
        private RequestBuilder<UnosquareFeature> _requestBuilder;

        [SetUp]
        public void Setup()
        {
            this._requestBuilder = new RequestBuilder<UnosquareFeature>(Log);
        }

        [Test, Category("Unosquare")]
        public void PostOrdersPagedTest()
        {
            var reqFileName = "ordersPaged";
            var originalCounter = 0;
            var response = this._requestBuilder.PerformRequest(
                reqFileName,
                customAction: (r, f) =>
                {
                    var obj = ((UnosquareFeature)f).GetBodyFromJsonFixture<OrdersPagedRequestModel>(reqFileName, Log);
                    r.AddJsonBody(obj);
                    originalCounter = obj.counter;
                }
            );
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            var responseObject = RestCore.GetInstance.DeserializeJsonResponse<OrdersPagedResponseModel>(response);
            Assert.That(
                responseObject.Counter == originalCounter,
                Is.True
            );
        }

        [Test, Category("Unosquare")]
        public void PostOrdersPagedVariableCounterTest()
        {
            var reqFileName = "ordersPaged";
            var counter = new Random().Next(1, 11);
            var response = this._requestBuilder.PerformRequest(
                reqFileName,
                customAction: (r, f) =>
                {
                    var obj = ((UnosquareFeature)f).GetBodyFromJsonFixture<OrdersPagedRequestModel>(reqFileName, Log);
                    r.AddJsonBody(obj);
                    obj.counter = counter;
                }
            );
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            var responseObject = RestCore.GetInstance.DeserializeJsonResponse<OrdersPagedResponseModel>(response);
            Assert.That(
                responseObject.Counter == counter,
                Is.True
            );
        }
    }
}