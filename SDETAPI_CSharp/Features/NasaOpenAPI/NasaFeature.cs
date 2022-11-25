using RestSharp;
using SDETAPI_CSharp.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SDETAPI_CSharp.Features.NasaOpenAPI
{
    public class NasaFeature : IFeature
    {
        public string RequestsDirectory => @"Requests\NasaOpenAPI\";
        private readonly string ApiKey = "j9WCjynrbXfZfmYFDlDK4jtWtF78TBSvGgtiGPWm";

        public void SetupQueryParameters(RestRequest request, List<KeyValuePair<string, string>> queryParameters = null)
        {
            request.AddQueryParameter("api_key", this.ApiKey);

            if(queryParameters != null)
            {
                RestCore.GetInstance.AddQueryParameters(request, queryParameters);
            }
        }
    }
}
