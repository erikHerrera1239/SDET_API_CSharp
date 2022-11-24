using RestSharp;
using SDETAPI_CSharp.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace SDETAPI_CSharp.Features
{
    public interface IRequestBuilder
    {
        RestResponse CreateRequest(string method, string path, List<KeyValuePair<string, string>> headers);
    }
}
