using NUnit.Framework;
using NUnit.Framework.Internal;
using RestSharp;
using System;
using System.Collections.Generic;

namespace SDETAPI_CSharp.Core
{
    //Builder
    public class RestCore : IRestCore
    {
        private RestClient _restClient { get; }

        public RestCore(string baseUrl)
        {
            _restClient = new RestClient(baseUrl);
        }

        public RestRequest CreateRequestWithHeaders(string methodType, List<KeyValuePair<string, string>> headerList, string path = null)
        {
            methodType = methodType.ToUpper();
            RestRequest restRequest;
            switch (methodType)
            {
                case "GET":
                    restRequest = new RestRequest(path, Method.Get);
                    break;

                case "POST":
                    restRequest = new RestRequest(path, Method.Post);
                    break;

                case "PUT":
                    restRequest = new RestRequest(path, Method.Put);
                    break;

                case "DELETE":
                    restRequest = new RestRequest(path, Method.Delete);
                    break;

                default:
                    throw new NotImplementedException($"Rest Method not valid. Must specifiy correctly. Current value: [{methodType}]" +
                                                      $"Current valid types: Get, Post, Put and Delete");
            }

            restRequest.AddHeaders(headerList);

            return restRequest;
        }

        public void AddRequestBody(RestRequest restRequest, object body)
        {
            restRequest.AddJsonBody(body);
            Console.WriteLine(body.ToString());
        }

        public RestResponse ExecuteRequest(RestRequest restRequest)
        {
            var response = this._restClient.Execute(restRequest);
            Console.WriteLine(response.StatusDescription);
            Console.WriteLine(response.Content.ToString());
            return response;
        }
    }
}
