using Newtonsoft.Json.Linq;
using RestSharp;
using SDETAPI_CSharp.Core;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace SDETAPI_CSharp.Features.HealthcareGov
{
    public class HealtcareFeature : IFeature
    {
        private string _requestsDirectory = @"Requests\HealthcareGov\";

        public string RequestsDirectory { get => this._requestsDirectory; set => this._requestsDirectory = value; }

        public void SetupQueryParameters(RestRequest request, List<KeyValuePair<string, string>> queryParameters = null)
        {

        }


    }
}
