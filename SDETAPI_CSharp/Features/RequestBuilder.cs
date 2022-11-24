using RestSharp;
using SDETAPI_CSharp.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace SDETAPI_CSharp.Features
{
    public class RequestBuilder
    {
        private IRestCore _restCore;

        public RequestBuilder(IRestCore restCore)
        {
            _restCore = restCore;
        }

        public RestResponse PerformRequest(string method, string path, List<KeyValuePair<string, string>> headers, object body)
        {
            var request = _restCore.CreateRequestWithHeaders(method, headers, path);
            _restCore.AddRequestBody(request, body);
            return _restCore.ExecuteRequest(request);
        }
    }
}
