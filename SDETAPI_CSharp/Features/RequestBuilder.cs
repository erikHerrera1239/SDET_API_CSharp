﻿using log4net;
using Newtonsoft.Json.Linq;
using RestSharp;
using SDETAPI_CSharp.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SDETAPI_CSharp.Features
{
    public class RequestBuilder<TFeature> where TFeature : IFeature, new()
    {
        internal readonly string _requestDirectory;
        private readonly TFeature _feature;
        private readonly ILog _log;

        public RequestBuilder(ILog log)
        {
            _log = log;
            this._feature = new TFeature();
            this._requestDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, this._feature.RequestsDirectory);
        }

        internal RestCore RestCore => RestCore.GetInstance;

        public RestResponse PerformRequest(string fileName, List<KeyValuePair<string, string>> headers = null, List<KeyValuePair<string, string>> queryParams = null, object body = null, Action<RestRequest> customAction = null)
        {
            var obj = this.GetJObjectFromJsonFile(fileName);
            var method = obj.Value<string>("Method");
            var url = obj.Value<string>("URL");
            var request = headers == null
                ? RestCore.CreateRequest(method, _log, url)
                : RestCore.CreateRequestWithHeaders(method, headers, _log, url);
            this._feature.SetupQueryParameters(request, queryParams);
            if (customAction != null)
            {
                customAction.Invoke(request);
            }
            if (body != null) RestCore.AddRequestBody(request, body, _log);
            return RestCore.ExecuteRequest(request, _log);
        }

        private JObject GetJObjectFromJsonFile(string fileName)
        {
            var files = Directory.GetFiles(this._requestDirectory, "*", SearchOption.AllDirectories);
            var filePath = files.Single(f => Path.GetFileName(f) == fileName + ".json");
            return new JsonReader().ReadJsonFile(filePath, _log);
        }
    }
}
