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
        public string RequestsDirectory => @"Requests\HealthcareGov\";

        public void SetupQueryParameters(RestRequest request, List<KeyValuePair<string, string>> queryParameters = null)
        {

        }


    }
}
