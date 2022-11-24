using NUnit.Framework;
using NUnit.Framework.Internal;
using RestSharp;
using System;
using System.Collections.Generic;

namespace SDETAPI_CSharp.Core
{
    public interface IRestCore
    {
        RestRequest CreateRequestWithHeaders(string methodType, List<KeyValuePair<string, string>> headerList, string path = null);

        RestResponse ExecuteRequest(RestRequest restRequest);

        void AddRequestBody(RestRequest restRequest, object body);
    }
}
