using log4net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using SDETAPI_CSharp.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SDETAPI_CSharp.Features.Unosquare
{
    public class UnosquareFeature : IFeature
    {
        private string _requestsDirectory = @"Requests\Unosquare\";

        public string RequestsDirectory { get => this._requestsDirectory; set => this._requestsDirectory = value; }

        public void SetupQueryParameters(RestRequest request, List<KeyValuePair<string, string>> queryParameters = null)
        {

        }

        public T GetBodyFromJsonFixture<T>(string fileName, ILog log)
        {
            var obj = new SDETAPI_CSharp.Core.JsonReader().GetJObjectFromJsonFile(this.RequestsDirectory, fileName, log);
            var txt = obj.Value<JObject>("RequestBodyFixture").ToString();
            return JsonConvert.DeserializeObject<T>(txt);
        }
    }
}
