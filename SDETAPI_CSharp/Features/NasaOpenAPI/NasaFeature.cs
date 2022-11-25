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
        private string _requestsDirectory = @"Requests\NasaOpenAPI\";

        public string RequestsDirectory { get => this._requestsDirectory; set => this._requestsDirectory = value; }

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
