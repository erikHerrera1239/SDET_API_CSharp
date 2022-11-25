using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace SDETAPI_CSharp.Features
{
    public interface IFeature
    {
        public string RequestsDirectory { get; set; }

        public abstract void SetupQueryParameters(RestRequest request, List<KeyValuePair<string, string>> queryParameters = null);
    }
}
